CREATE PROCEDURE sp_TaoDeChoSV
    @MAMH CHAR(8),
    @MALOP NVARCHAR(15),
    @NGAYTHI DATETIME,
    @LAN SMALLINT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION; -- Bắt đầu giao dịch

        -- Tạo bảng tạm để lưu trữ MASV
        CREATE TABLE #SINHVIENTempTable (
            MASV CHAR(8)
        );

        -- Chèn MASV từ bảng SINHVIEN vào bảng tạm
        INSERT INTO #SINHVIENTempTable (MASV)
        SELECT MASV
        FROM SINHVIEN
        WHERE MALOP = @MALOP;

        -- Kiểm tra nếu không có dữ liệu nào trong bảng tạm
        IF NOT EXISTS (SELECT 1 FROM #SINHVIENTempTable)
        BEGIN
            RAISERROR ('Không có sinh viên nào trong lớp này.', 16, 1);
            RETURN;
        END

        -- Lấy MAGVDK từ GIAOVIEN_DANGKY
        DECLARE @MAGVDK INT;
        SELECT @MAGVDK = MAGVDK
        FROM GIAOVIEN_DANGKY
        WHERE MAMH = @MAMH AND MALOP = @MALOP AND NGAYTHI = @NGAYTHI AND LAN = @LAN;

        -- Kiểm tra nếu không tìm thấy MAGVDK
        IF @MAGVDK IS NULL
        BEGIN
            RAISERROR ('Không tìm thấy MAGVDK cho các điều kiện đã cho.', 16, 1);
            RETURN;
        END

        -- Tạo bảng tạm để lưu trữ bộ đề giảng viên đăng ký
        CREATE TABLE #BODETempTable (
            CAUHOI INT,
            MAMH CHAR(8),
            TRINHDO CHAR(1)
        );

        -- Nạp dữ liệu vào bảng tạm
        INSERT INTO #BODETempTable (CAUHOI, MAMH, TRINHDO)
        SELECT bd.CAUHOI, bd.MAMH, bd.TRINHDO
        FROM BODE AS bd
        JOIN BODE_DANGKY AS bddk ON bd.CAUHOI = bddk.CAUHOI
        WHERE bddk.MAGVDK = @MAGVDK;

        -- Kiểm tra nếu không có dữ liệu nào trong bảng tạm
        IF NOT EXISTS (SELECT 1 FROM #BODETempTable)
        BEGIN
            RAISERROR ('Không có bộ đề nào được đăng ký bởi giáo viên cho các điều kiện đã cho.', 16, 1);
            RETURN;
        END

        -- Lặp qua từng sinh viên để thêm dữ liệu vào bảng BANGDIEM và CT_BAITHI
        DECLARE @MASV CHAR(8);

        DECLARE SinhVienCursor CURSOR FOR
        SELECT MASV FROM #SINHVIENTempTable;

        OPEN SinhVienCursor;
        FETCH NEXT FROM SinhVienCursor INTO @MASV;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Thêm vào bảng BANGDIEM
            INSERT INTO BANGDIEM (MASV, MAMH, LAN, NGAYTHI, DIEM, MAGVDK)
            VALUES (@MASV, @MAMH, @LAN, @NGAYTHI, NULL,@MAGVDK);

            DECLARE @MABD INT = SCOPE_IDENTITY();

            -- Tạo bảng tạm cho từng sinh viên để lưu các câu hỏi và đáp án ngẫu nhiên
            CREATE TABLE #StudentQuestionTempTable (
                CAUHOI INT,
                STT INT,
                A CHAR(1),
                B CHAR(1),
                C CHAR(1),
                D CHAR(1)
            );

            -- Nạp dữ liệu vào bảng tạm của sinh viên
            DECLARE @CAUHOI INT;
            DECLARE QuestionCursor CURSOR FOR
            SELECT CAUHOI FROM #BODETempTable ORDER BY NEWID(); -- Xáo trộn câu hỏi

            OPEN QuestionCursor;
            FETCH NEXT FROM QuestionCursor INTO @CAUHOI;

            DECLARE @STT INT = 1;

            WHILE @@FETCH_STATUS = 0
            BEGIN
                -- Tạo bảng tạm để lưu trữ các đáp án A, B, C, D ngẫu nhiên
                CREATE TABLE #AnswerTempTable (
                    Answer CHAR(1) PRIMARY KEY
                );

                -- Nạp dữ liệu vào bảng tạm cho đáp án
                INSERT INTO #AnswerTempTable (Answer)
                VALUES ('A'), ('B'), ('C'), ('D');

                -- Lấy các đáp án ngẫu nhiên
                DECLARE @A CHAR(1), @B CHAR(1), @C CHAR(1), @D CHAR(1);

                -- Sử dụng bảng tạm để xáo trộn đáp án
                SELECT @A = Answer FROM #AnswerTempTable ORDER BY NEWID();
                SELECT @B = Answer FROM #AnswerTempTable WHERE Answer != @A ORDER BY NEWID();
                SELECT @C = Answer FROM #AnswerTempTable WHERE Answer NOT IN (@A, @B) ORDER BY NEWID();
                SELECT @D = Answer FROM #AnswerTempTable WHERE Answer NOT IN (@A, @B, @C) ORDER BY NEWID();

                -- Chèn câu hỏi và đáp án vào bảng tạm của sinh viên
                INSERT INTO #StudentQuestionTempTable (CAUHOI, STT, A, B, C, D)
                VALUES (@CAUHOI, @STT, @A, @B, @C, @D);

                SET @STT = @STT + 1;
                FETCH NEXT FROM QuestionCursor INTO @CAUHOI;

                -- Xóa bảng tạm cho đáp án
                DROP TABLE #AnswerTempTable;
            END

            CLOSE QuestionCursor;
            DEALLOCATE QuestionCursor;

            -- Thêm dữ liệu vào bảng CT_BAITHI
            INSERT INTO CT_BAITHI (MABD, STT, CAUHOI, A, B, C, D, DAP_AN)
            SELECT 
                @MABD,
                STT,
                CAUHOI,
                A,
                B,
                C,
                D,
                NULL -- DAP_AN ban đầu là NULL
            FROM #StudentQuestionTempTable;

            -- Xóa bảng tạm của sinh viên sau khi sử dụng
            DROP TABLE #StudentQuestionTempTable;

            FETCH NEXT FROM SinhVienCursor INTO @MASV;
        END

        CLOSE SinhVienCursor;
        DEALLOCATE SinhVienCursor;

        -- Xóa các bảng tạm sau khi sử dụng
        DROP TABLE #SINHVIENTempTable;
        DROP TABLE #BODETempTable;

        -- Nếu mọi thao tác đều thành công, commit giao dịch
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback giao dịch
        ROLLBACK TRANSACTION;

        -- Xóa các bảng tạm nếu có lỗi
        IF OBJECT_ID('tempdb..#SINHVIENTempTable') IS NOT NULL DROP TABLE #SINHVIENTempTable;
        IF OBJECT_ID('tempdb..#BODETempTable') IS NOT NULL DROP TABLE #BODETempTable;

        -- Thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
