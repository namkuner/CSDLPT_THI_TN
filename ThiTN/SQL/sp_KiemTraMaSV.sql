create procedure sp_KiemTraMaSV
@MASV nchar(8)
as
BEGIN
	IF( EXISTS( SELECT * FROM SINHVIEN WHERE MASV = @MASV) )
		RETURN 1;
	--check o phan manh con lai
	ELSE IF( EXISTS( SELECT * FROM LINK1.TN_CSDLPT.DBO.SINHVIEN WHERE MASV = @MASV ) )
		RETURN 1;
	RETURN 0;
END

--test code, khong exec khi tao sp
declare @result int
exec @result = sp_KiemTraMaSV '012'
select @result