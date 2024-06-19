CREATE TYPE dbo.CauHoiDaThemTableType AS TABLE
(
    CauHoi INT
);

ALTER PROCEDURE sp_LayCauHoi 
    @SoCau INT,
    @TrinhDo CHAR(1),
    @MaMonHoc CHAR(5),
    @MaCoSo NCHAR(3),
    @CoSoHienTai BIT,
    @CauHoiDaThem dbo.CauHoiDaThemTableType READONLY
AS
BEGIN
    -- Biến tạm để chứa kết quả tạm thời
    DECLARE @TempCauHoi TABLE (CAUHOI INT);
    
    IF @CoSoHienTai = 1
    BEGIN
        -- Lấy câu hỏi từ cơ sở hiện tại
        INSERT INTO @TempCauHoi (CAUHOI)
        SELECT TOP (@SoCau) CAUHOI
        FROM BODE
        WHERE TRINHDO = @TrinhDo 
          AND MAMH = @MaMonHoc 
          AND MAGV IN (
              SELECT MAGV
              FROM GIAOVIEN
              WHERE MAKH IN (
                  SELECT MAKH
                  FROM KHOA
                  WHERE MACS = @MaCoSo
              )
          )
          AND CAUHOI NOT IN (SELECT CauHoi FROM @CauHoiDaThem)
        ORDER BY NEWID();
    END
    ELSE
    BEGIN
        -- Lấy câu hỏi từ tất cả các cơ sở
        INSERT INTO @TempCauHoi (CAUHOI)
        SELECT TOP (@SoCau) CAUHOI
        FROM BODE
        WHERE TRINHDO = @TrinhDo 
          AND MAMH = @MaMonHoc
          AND CAUHOI NOT IN (SELECT CauHoi FROM @CauHoiDaThem)
        ORDER BY NEWID();
    END

    -- Trả về kết quả
    SELECT * FROM @TempCauHoi;
END

