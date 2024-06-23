CREATE PROCEDURE [dbo].[sp_XoaLoginVaGiaoVien]
    @MAGV_XOA NVARCHAR(50),  -- Mã giáo viên bị xóa
    @USER CHAR(8)       -- Mã giáo viên thực hiện xóa
AS
BEGIN
    DECLARE @error INT;
    DECLARE @UserRole NVARCHAR(50)S;
    DECLARE @USRNAME NVARCHAR(50) = @MAGV_XOA;
    DECLARE @LGNAME NVARCHAR(50) = @MAGV_XOA;

    -- Kiểm tra nếu người xóa trùng với người bị xóa
    IF @MAGV_XOA = @USER
    BEGIN
        RAISERROR('Người xóa không được trùng với người bị xóa.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        -- Kiểm tra quyền của người xóa
		SELECT @UserRole = rp.name
		FROM sys.database_role_members drm
		JOIN sys.database_principals rp ON (drm.role_principal_id = rp.principal_id)
		JOIN sys.database_principals mp ON (drm.member_principal_id = mp.principal_id)
		WHERE mp.name = @User;

        IF @UserRole = 'Truong' 
        BEGIN
            -- Chỉ được xóa user thuộc nhóm trường
            IF EXISTS (SELECT * 
					FROM sys.database_role_members drm
					JOIN sys.database_principals rp ON (drm.role_principal_id = rp.principal_id)
					JOIN sys.database_principals mp ON (drm.member_principal_id = mp.principal_id)
					WHERE mp.name = @MAGV_XOA AND rp.name = 'Truong')
            BEGIN
                -- Xóa user và login
				EXEC Xoa_Login @LGNAME,@LGNAME

                -- Xóa record trong bảng GIAOVIEN
                DELETE FROM GIAOVIEN WHERE MAGV = @MAGV_XOA;
            END
            ELSE
            BEGIN
                RAISERROR('Không được xóa user không thuộc nhóm trường.', 16, 1);
                RETURN;
            END
        END
        ELSE IF @UserRole IN ('CoSo', 'Giangvien', 'Sinhvien')
        BEGIN
            -- Không được xóa user thuộc nhóm trường
            IF NOT EXISTS (SELECT * 
					FROM sys.database_role_members drm
					JOIN sys.database_principals rp ON (drm.role_principal_id = rp.principal_id)
					JOIN sys.database_principals mp ON (drm.member_principal_id = mp.principal_id)
					WHERE mp.name = @MAGV_XOA AND rp.name = 'Truong')
            BEGIN

				EXEC Xoa_Login @MAGV_XOA,@MAGV_XOA
				DELETE FROM GIAOVIEN WHERE MAGV = @MAGV_XOA;

            END
            ELSE
            BEGIN
                RAISERROR('Không được xóa user thuộc nhóm trường.', 16, 1);
                RETURN;
            END
        END
        ELSE
        BEGIN
            RAISERROR('Người xóa không có quyền hợp lệ.', 16, 1);
            RETURN;
        END
    END TRY
    BEGIN CATCH
        SET @error = @@ERROR;
		DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- In ra thông báo lỗi
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

    END CATCH
END