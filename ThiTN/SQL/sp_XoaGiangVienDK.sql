ALTER PROC sp_XoaGiangVienDK
    @MAGVDK int
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem bộ đề đăng ký đã thi chưa?
    IF EXISTS (
        SELECT MABD
        FROM BANGDIEM
        WHERE MAGVDK = @MAGVDK AND DIEM IS NOT NULL
    )
    BEGIN
        RAISERROR ('BỘ ĐỀ ĐĂNG KÝ NÀY ĐÃ ĐƯỢC THI. KHÔNG THỂ XÓA.', 16, 1);
        RETURN -1;
    END

    -- Nếu chưa được thi, thực hiện xóa dữ liệu từ các bảng liên quan
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Xóa dữ liệu từ bảng CT_BAITHI
        DELETE FROM CT_BAITHI
		WHERE MABD IN (
			SELECT TOP 1 MABD FROM BANGDIEM
			WHERE MAGVDK = @MAGVDK
			)

        -- Xóa dữ liệu từ bảng BANGDIEM
        DELETE FROM BANGDIEM WHERE MAGVDK = @MAGVDK;

        -- Xóa dữ liệu từ bảng BODE_DANGKY
        DELETE FROM BODE_DANGKY WHERE MAGVDK = @MAGVDK;

        -- Xóa dữ liệu từ bảng GIANGVIEN_DANGKY
        DELETE FROM GIAOVIEN_DANGKY WHERE MAGVDK = @MAGVDK;

        COMMIT TRANSACTION;
		RETURN 0;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Capture the error details
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- Re-raise the error to the caller
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		RETURN -1;
    END CATCH
END
