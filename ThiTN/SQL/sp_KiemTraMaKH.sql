create procedure sp_KiemTraMaKH
@MAKH nchar(8)
as
BEGIN
	IF( EXISTS( SELECT * FROM KHOA WHERE MAKH = @MAKH ) )
		RETURN 1;
	--check o phan manh con lai
	ELSE IF( EXISTS( SELECT * FROM LINK1.TN_CSDLPT.DBO.KHOA WHERE MAKH = @MAKH ) )
		RETURN 1;
	RETURN 0;
END