
CREATE PROCEDURE sp_LayCauHoi 
    @SoCau INT,
    @TrinhDo CHAR(1),
    @MaMonHoc CHAR(5),
    @MaCoSo NCHAR(3),
    @CoSoHienTai BIT
AS
BEGIN
    IF @CoSoHienTai = 1
    BEGIN
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
          AND CAUHOI NOT IN (SELECT CauHoi FROM #CauHoiDaThem)
        ORDER BY NEWID();
    END
    ELSE
    BEGIN
        SELECT TOP (@SoCau) CAUHOI
        FROM BODE
        WHERE TRINHDO = @TrinhDo 
          AND MAMH = @MaMonHoc
          AND CAUHOI NOT IN (SELECT CauHoi FROM #CauHoiDaThem)
        ORDER BY NEWID();
    END

END

