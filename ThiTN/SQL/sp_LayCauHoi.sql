CREATE PROCEDURE sp_LayCauHoi 
	@SoCau INT,
	@TrinhDo CHAR(1),
	@MaMonHoc CHAR(5),
	@MaCoSo	NChar(3)
	
AS
BEGIN
	SELECT TOP (@SoCau) CAUHOI
    FROM BODE
    WHERE TRINHDO = @TrinhDo AND MAMH = @MaMonHoc AND MAGV IN (
        SELECT MAGV
        FROM GIAOVIEN
        WHERE MAKH IN (
            SELECT MAKH
            FROM KHOA
            WHERE MACS = @MaCoSo
        )
    )
    ORDER BY NEWID();
END

EXEC sp_LayCauHoi 50, 'A', 'AVCB' , 'CS1'
SELECT * FROM BODE