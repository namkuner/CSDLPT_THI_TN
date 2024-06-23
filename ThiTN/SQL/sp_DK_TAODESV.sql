ALTER PROC sp_DK_TAODESV
    @MAGV CHAR(8),
    @MALOP NVARCHAR(15),
    @MaMonHoc CHAR(5),
    @TrinhDo CHAR(1),
    @LanThi SMALLINT,
    @SoCauThi SMALLINT,
    @NgayThi DATETIME,
    @ThoiGian SMALLINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            -- Register the teacher for the exam
            EXEC [dbo].[sp_ThemGiaovienDangky] @MAGV, @MALOP, @MaMonHoc, @TrinhDo, @LanThi, @SoCauThi, @NgayThi, @ThoiGian

            -- Create the exam for students
            EXEC sp_TaoDeChoSV @MaMonHoc, @MALOP, @NgayThi, @LanThi

        COMMIT TRANSACTION
        
        -- Return success code
        RETURN 0;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION

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
        
        -- Return error code
        RETURN -1;
    END CATCH
END
