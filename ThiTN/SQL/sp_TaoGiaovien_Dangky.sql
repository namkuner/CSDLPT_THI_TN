
ALTER PROCEDURE sp_ThemGiaovienDangky
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
	BEGIN TRANSACTION
	-- Lấy mã lớp và mã khoa từ tên lớp
    DECLARE @MaKhoa NCHAR(8), @MaCoSo NCHAR(3),@MaCoSoConLai NChar(3);
    SELECT  @MaKhoa = MAKH
    FROM LOP
    WHERE MALOP = @MALOP;

    -- Lấy mã cơ sở từ mã khoa
    SELECT @MaCoSo = MACS
    FROM KHOA
    WHERE MAKH = @MaKhoa;

	--Lấy mã cơ sở còn lại
	SELECT @MaCoSoConLai = MACS
	FROM COSO
	WHERE MACS != @MaCoSo;
	
	--Trình độ thấp hơn
	DECLARE @TrinhDoThapHon NCHAR(1);
	SET @TrinhDoThapHon = NCHAR(ASCII(@TrinhDo) + 1);
    -- Thêm mới bản ghi vào bảng GIAOVIEN_DANGKY
	
    DECLARE @MaGVDK INT;
    INSERT INTO GIAOVIEN_DANGKY (MAGV, MAMH, MALOP, TRINHDO, NGAYTHI, LAN, SOCAUTHI, THOIGIAN)
    VALUES (@MAGV, @MaMonHoc, @MALOP, @TrinhDo, @NgayThi, @LanThi, @SoCauThi, @ThoiGian);
    SET @MaGVDK = SCOPE_IDENTITY();
	PRINT 'Mã Giáo viên đk: ' + CAST(@MaGVDK AS VARCHAR(10))
	DECLARE @SoCauLay INT
	DECLARE @SoDong INT;
	DECLARE @CauHoiDaThem TABLE (CauHoi INT);
	IF @TrinhDo != 'C'
	BEGIN
		-- Lấy Câu thi ở cơ sở hiện tại
		
		INSERT INTO @CauHoiDaThem (CauHoi)
		EXEC sp_LayCauHoi @SoCauThi, @TrinhDo, @MaMonHoc,@MaCoSo
		SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
		-- Nếu lấy đủ RETURN  
		IF @SoDong = @SoCauThi --Trường hợp Lấy 100 câu thi, số lượng câu ở trình độ A,B là CS1[A,B] CS2[A,B]:  100,CS1[110,110],CS2[110,110] 
		BEGIN
			INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
			SELECT CauHoi, @MaGVDK
			FROM @CauHoiDaThem;
			COMMIT TRANSACTION
			RETURN 0;
		END
		ELSE IF @SoDong > CEILING(0.7 * @SoCauThi)
		BEGIN
			
			SET @SoCauLay = @SoCauThi -@SoDong
			INSERT INTO @CauHoiDaThem (CauHoi)
			EXEC sp_LayCauHoi @SoCauLay, @TrinhDoThapHon, @MaMonHoc,@MaCoSo
			SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
			--Trường hợp lấy hết câu có trình độ thấp hơn nhưng vẫn không đủ bộ đề
			IF @SoDong = @SoCauThi -- 100,CS1[80,110],CS2[110,110] 
			BEGIN
				INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
				SELECT CauHoi, @MaGVDK
				FROM @CauHoiDaThem;
				COMMIT TRANSACTION
				RETURN 0;
			END
			ELSE
			BEGIN
				SET @SoCauLay = @SoCauThi -@SoDong
				INSERT INTO @CauHoiDaThem (CauHoi)
				EXEC sp_LayCauHoi @SoCauLay, @TrinhDo, @MaMonHoc,@MaCoSoConLai
				SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
				IF  @SoDong = @SoCauThi -- 100,CS1[80,10],CS2[10,110] 
				BEGIN
					INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
					SELECT CauHoi, @MaGVDK
					FROM @CauHoiDaThem;
					COMMIT TRANSACTION
					RETURN 0; -- 80A CS1,10B CS1, 10A CS2 
				END
					
				ELSE
				BEGIN
					SET @SoCauLay = @SoCauThi -@SoDong
					INSERT INTO @CauHoiDaThem (CauHoi)
					EXEC sp_LayCauHoi @SoCauLay, @TrinhDoThapHon, @MaMonHoc,@MaCoSoConLai
					SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;	
					IF @SoDong = @SoCauThi --100,CS1[80,10],CS2[5,110]
					BEGIN
						INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
						SELECT CauHoi, @MaGVDK
						FROM @CauHoiDaThem;
						COMMIT TRANSACTION
						RETURN 0; -- 80A CS1,10B CS1, 5A CS2 , 5B CS2
					END
						
					ELSE-- 100,CS1[80,10],CS2[5,3]
					BEGIN
						ROLLBACK TRANSACTION
						RAISERROR( 'Không thể tạo đề do số câu không đủ', 16, 1) --Không đủ 100 câu
					END
				END
			END
		END
		ELSE -- @SoDong < CEILING(0.7 * @SoCauThi); chỉ có 50A câu ở CS1
		BEGIN 
			
			DECLARE @tmp TABLE (CauHoi INT);
			DECLARE @RowCount INT;
			INSERT INTO @tmp (CauHoi)
			EXEC sp_LayCauHoi @SoCauThi, @TrinhDo, @MaMonHoc,@MaCoSoConLai
			SELECT @RowCount = COUNT(*) FROM @tmp 

			--Điều chú ý ở đây là CS1 không đủ thì  giờ qua CS2, 
			--vậy thì nên lấy bao nhiêu câu của cơ sở 2 ?
			--Do thầy kêu ưu tiên cơ sở > trình độ, nhưng tối thiểu phải đạt 70% câu hỏi loại A thì mới được tạo đề
			--Nên sau khi lấy đủ 70% thì lại về CS1 để lấy trình độ thấp hơn (Ưu tiên cơ sở > trình độ) 
			IF @RowCount + @SoDong> CEILING(0.7 * @SoCauThi)
			BEGIN
				
				SET @SoCauLay = CEILING(0.7 * @SoCauThi) - @SoDong
				INSERT INTO @CauHoiDaThem (CauHoi)
				SELECT TOP (@SoCauLay) CauHoi FROM @tmp
				SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
				DELETE TOP (@SoCauLay) FROM @tmp

				SET @SoCauLay = @SoCauThi - @SoDong
				INSERT INTO @CauHoiDaThem (CauHoi)
				EXEC sp_LayCauHoi @SoCauLay, @TrinhDoThapHon, @MaMonHoc,@MaCoSo
				SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;	

				IF @SoDong = @SoCauLay -- 100,CS1[50,110],CS2[110,110]
				BEGIN
					INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
					SELECT CauHoi, @MaGVDK
					FROM @CauHoiDaThem;
					COMMIT TRANSACTION
					RETURN 0;-- 50A CS1, 20A CS2, 30B CS1
				END
				ELSE
				BEGIN
					SET @SoCauLay = @SoCauThi - @SoDong
					INSERT INTO @CauHoiDaThem (CauHoi)
					EXEC sp_LayCauHoi @SoCauLay, @TrinhDo, @MaMonHoc,@MaCoSoConLai
					SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
					IF @SoDong = @SoCauLay -- 100,CS1[50,10],CS2[110,110]
					BEGIN
						INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
						SELECT CauHoi, @MaGVDK
						FROM @CauHoiDaThem;
						COMMIT TRANSACTION
						RETURN 0; -- 50A CS1, 20A CS2, 10B CS1, 20A CS2
					END
						
					ELSE
					BEGIN
						SET @SoCauLay = @SoCauThi - @SoDong
						INSERT INTO @CauHoiDaThem (CauHoi)
						EXEC sp_LayCauHoi @SoCauLay, @TrinhDoThapHon, @MaMonHoc,@MaCoSoConLai
						SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
						IF @SoDong =@SoCauLay -- 100,CS1[50,10],CS2[30,110]
						BEGIN
							INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
							SELECT CauHoi, @MaGVDK
							FROM @CauHoiDaThem;
							COMMIT TRANSACTION
							RETURN 0;  -- 50A CS1, 20A CS2, 10B CS1, 10A CS2, 10B CS2
						END
							
						ELSE --100,CS1[50,10],CS2[30,5]
						BEGIN
							ROLLBACK TRANSACTION
							RAISERROR( 'Không thể tạo đề do số câu không đủ', 16, 1) -- chỉ có 95 câu. Không đủ để tạo đề
						END
					END
				END
			END
			ELSE---- 100,CS1[30,10],CS2[30,110]
			BEGIN
				ROLLBACK TRANSACTION
				RAISERROR( 'Không thể tạo đề do số câu không đủ', 16, 1)-- 100,CS1[30],CS2[30]	
			END
		END
	END
	ELSE-- Lấy Câu hỏi trình độ C
	BEGIN
		
		INSERT INTO @CauHoiDaThem (CauHoi)
		EXEC sp_LayCauHoi @SoCauThi, @TrinhDo, @MaMonHoc,@MaCoSo
		SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
		IF @SoDong =@SoCauThi -- 100,CS1[100],CS2[100]
		BEGIN
			INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
			SELECT CauHoi, @MaGVDK
			FROM @CauHoiDaThem;
			COMMIT TRANSACTION
			RETURN 0;--100C CS1
		END	
		ELSE
		BEGIN
			
			SET @SoCauLay = @SoCauThi - @SoDong
			INSERT INTO @CauHoiDaThem (CauHoi)
			EXEC sp_LayCauHoi @SoCauLay, @TrinhDo, @MaMonHoc,@MaCoSoConLai
			SELECT @SoDong = COUNT(*) FROM @CauHoiDaThem;
			IF @SoDong =@SoCauLay -- 100,CS1[30],CS2[100]
			BEGIN
				INSERT INTO BODE_DANGKY (CAUHOI, MAGVDK)
				SELECT CauHoi, @MaGVDK
				FROM @CauHoiDaThem;
				COMMIT TRANSACTION
				RETURN 0;
			END
			ELSE
			BEGIN
				ROLLBACK TRANSACTION
				RAISERROR( 'Không thể tạo đề do số câu không đủ', 16, 1)-- 100,CS1[30],CS2[30]	
			END
		END
	END
	
END