EXEC sp_serveroption @@SERVERNAME, 'DATA ACCESS', 'true'
GO

declare @caDBVersion int, @caDBType int 
exec ca_sp_DatabaseVersion @caDBVersion OUTPUT,@caDBType OUTPUT

IF @caDBType = 0 -- CONFIG
BEGIN
	IF OBJECT_ID(N'dbo.PanelTimeSchdule', N'U') IS NOT NULL 
		DELETE FROM PanelTimeSchdule WHERE PanelNo NOT IN (SELECT PnlNo FROM Panel)

	IF OBJECT_ID(N'dbo.PanelHoliday', N'U') IS NOT NULL 
		DELETE FROM dbo.PanelHoliday WHERE PanelNo NOT IN (SELECT PnlNo FROM Panel)
END

IF @caDBType = 2 
BEGIN
	delete from dbo.ActiveLinks 
	delete from dbo.APBAreas
	delete from dbo.Badge
	delete from dbo.CategoryCounters
	delete from dbo.EventClassDefs
	delete from dbo.Input
	delete from dbo.Link
	delete from dbo.MActiveLinks
	delete from dbo.Panel
	delete from dbo.Person
	delete from dbo.Reader
	delete from dbo.Relay
	delete from Zones
END
GO 
