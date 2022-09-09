if not exists (select * from master.dbo.syslogins where loginname = N'cic')
BEGIN
	declare @logindb nvarchar(132), 
			@loginlang nvarchar(132) 
	select @logindb = N'master', 
	@loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	if exists(SELECT cmptlevel FROM master.dbo.sysdatabases Where cmptlevel >= 90)
	BEGIN
      exec('CREATE LOGIN cic WITH PASSWORD = ''Cic!23456789'', DEFAULT_DATABASE = '+@logindb+' , DEFAULT_LANGUAGE = '+@loginlang+' , CHECK_POLICY = OFF');
	END
	ELSE
	BEGIN
		exec sp_addlogin N'cic', 'Cic!23456789', @logindb, @loginlang
	END
END
GO
/****** Object:  Login cic    Script Date: 6/26/2002 7:00:22 PM ******/
exec sp_addsrvrolemember N'cic', sysadmin
GO

/****** Object:  Login cic    Script Date: 6/26/2002 7:00:22 PM ******/
exec sp_addsrvrolemember N'cic', securityadmin
GO

/****** Object:  Login cic    Script Date: 6/26/2002 7:00:22 PM ******/
exec sp_addsrvrolemember N'cic', serveradmin
GO

