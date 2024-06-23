create procedure sp_KiemTraMaLop
@MALOP nchar(8)
as
BEGIN
	IF( EXISTS( SELECT * FROM LOP WHERE MALOP = @MALOP ) )
		RETURN 1;
	--check o phan manh con lai
	ELSE IF( EXISTS( SELECT * FROM LINK1.TN_CSDLPT.DBO.LOP WHERE MALOP = @MALOP ) )
		RETURN 1;
	RETURN 0;
END

--test code, khong exec khi tao sp
declare @result int
exec @result = sp_KiemTraMaLop 'TH04'
select @result