EXEC sp_serveroption @@SERVERNAME, 'DATA ACCESS', 'true'
GO

declare @caDBVersion int, @caDBType int 
exec ca_sp_DatabaseVersion @caDBVersion OUTPUT,@caDBType OUTPUT
IF @caDBType = 0 
BEGIN
	exec('Update [dbo].[Reader] set NoSound = 0  where NoSound is null')

	exec ('UPDATE [dbo].[Reader] set DecReader = 0  where DecReader is null')

	exec('update dbo.Input set  VideoEventType = 1 where VideoEventType = null;
		 update dbo.Input set  RecordingSchedule = 1 where RecordingSchedule = null;
		 update dbo.Input set  VideoStartTime = 50 where VideoStartTime = 0;
		 update dbo.Input set  VideoEndTime = 50 where VideoEndTime = 0;')

	exec('UPDATE dbo.Com SET Baud = NULL WHERE Type = 10')

	exec ('update dbo.operators set EventCount = case when EventCount > 300 then 300 else case when EventCount < 1 then 1 else EventCount end end;
		   update dbo.operators set LogoffTime = case when LogoffTime > 9999 then 9999 else case when LogoffTime < 1 then 1 else LogoffTime end end;
		   update dbo.operators set AutoAckTime = case when AutoAckTime > 9999 then 9999 else case when AutoAckTime < 1 then 1 else AutoAckTime end end')

	--- Clean up created roles for those operators which used to have CA4K Administration roles and changed while update to 1.1.16 -------
	UPDATE Operators
	SET RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139'
	FROM Operators AS O INNER JOIN Roles AS R ON O.RoleID = R.RoleID
	WHERE R.RoleName LIKE 'New Role (%'

	DELETE RolePartitions
	FROM RolePartitions AS RP INNER JOIN Roles AS R ON RP.RoleID = R.RoleID
	WHERE R.RoleName LIKE 'New Role (%'


	DELETE RolePlugins 
	FROM RolePlugins AS RP INNER JOIN Roles AS R ON RP.RoleID = R.RoleID
	WHERE RoleName LIKE 'New Role (%'

	DELETE Roles
	WHERE RoleName LIKE 'New Role (%'
	------------------------------------------------------------------------------------------------------------------------------------------

	-------- SET CA4K Administration role to admin operator if not exists -----
	IF NOT EXISTS (SELECT TOP 1 1 FROM Operators WHERE OperatorID = '1EEB696C-0E28-4702-8598-C379C95B45E1' AND RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139')
	BEGIN
	UPDATE Operators SET RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139' WHERE OperatorID = '1EEB696C-0E28-4702-8598-C379C95B45E1'
	END

	-------- Delete all partitions for CA4K Administration Role except for Admin Partition -------------
	DELETE FROM RolePartitions
	WHERE RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139'
	AND PartitionID <> '3DC78C7B-C9CE-4485-A835-63D577F623E6'

	-------- Insert missing CA4K Administration Role to RolePartitions table
	IF NOT EXISTS (SELECT RoleID FROM RolePartitions WHERE RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139' AND PartitionID = '3DC78C7B-C9CE-4485-A835-63D577F623E6')
	BEGIN
	INSERT INTO RolePartitions (PartitionID, RoleID, Restriction, LastUpdated) VALUES ('3DC78C7B-C9CE-4485-A835-63D577F623E6', '82B19834-4EF0-405B-9AD1-23860AAF4139', 0, GETUTCDATE())
	END

	-------- Clean OperatorPartitions Table ----------------
	DELETE FROM OperatorPartitions
	WHERE OperatorID IN
	(
	SELECT O.OperatorID --, OP.PartitionID
	FROM OperatorPartitions OP
	INNER JOIN Operators O ON O.OperatorID = OP.OperatorID
	WHERE
	O.RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139'
	AND O.OperatorID <> '1EEB696C-0E28-4702-8598-C379C95B45E1'
	)
	AND PartitionID <> '3DC78C7B-C9CE-4485-A835-63D577F623E6'

	------- Check If Admin Partition is available for the CA4K Administration Role's Operators If not insert data into OperatorPartitions -------------
	INSERT INTO OperatorPartitions(PartitionID, OperatorID, IsPrimaryPartition)
	SELECT DISTINCT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, O.OperatorID, 1 AS IsPrimaryPartition FROM Operators O
	WHERE O.RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139'
	AND NOT EXISTS (SELECT TOP 1 1 FROM OperatorPartitions WHERE OperatorPartitions.OperatorID = O.OperatorID AND OperatorPartitions.PartitionID = '3DC78C7B-C9CE-4485-A835-63D577F623E6')

	------- Set Admin Partition to Primary Partition ----------------
	UPDATE OperatorPartitions
	SET IsPrimaryPartition = 1
	WHERE OperatorID IN
	(
		SELECT O.OperatorID FROM OperatorPartitions OP
		INNER JOIN Operators O ON O.OperatorID = OP.OperatorID
		WHERE
		O.RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139'
		AND OP.PartitionID = '3DC78C7B-C9CE-4485-A835-63D577F623E6'
	)

 -- This section is only usefull when update from CA4K beta release for users who had admin privileges and less number of devices in their partition
  	CREATE TABLE #TMP_ROLES
    (
  	  RoleID UNIQUEIDENTIFIER,
  	  OperatorID UNIQUEIDENTIFIER,
  	  RoleName NVARCHAR(1000),
  	  LastOperator UNIQUEIDENTIFIER
    )
  
    INSERT INTO #TMP_ROLES
    SELECT NEWID() RoleID, [OperatorID], 'New Role (' + [OperLoginName] + ')' AS RoleName, '1EEB696C-0E28-4702-8598-C379C95B45E1' as LastOperator from (
  	  SELECT distinct 
		   O.[OperatorID]
  		  ,O.[RoleID]
  		  ,O.[OperLoginName]
  	  FROM [Operators] O
  	  INNER JOIN [Roles] R ON R.RoleID = O.RoleID
  	  INNER JOIN [OperatorPartitions] OP ON OP.OperatorID = O.OperatorID
  	  WHERE O.[RoleID] = '82B19834-4EF0-405B-9AD1-23860AAF4139' and OP.[PartitionID] <> '3DC78C7B-C9CE-4485-A835-63D577F623E6'
	  AND O.[OperatorID] <> '1EEB696C-0E28-4702-8598-C379C95B45E1'
    ) AS TAB_ROLES
    
	IF EXISTS(SELECT 1 FROM #TMP_ROLES)
	BEGIN
	 	INSERT INTO [Roles] ([RoleID], [RoleName], [LastOperator]) SELECT RoleID, RoleName, LastOperator FROM #TMP_ROLES
  
		INSERT INTO RolePlugins (RoleID, pluginId)
		SELECT ROLES.RoleID, P.pluginId FROM 
		( 
  			SELECT N'2fb18291-24fc-4c94-be0a-961d568c3704'	as pluginId     union
  			SELECT N'5c269286-19ec-491b-9ed0-5ce58a59d472'	as pluginId	union
  			SELECT N'c1faa462-1e95-4f5f-ac90-56906da8d277'	as pluginId	union
  			SELECT N'2a369362-fa7d-41cd-ba0f-a73d08c1cee5'	as pluginId	union
  			SELECT N'087c90e4-3886-45de-b741-d1d72bc5a4d4'	as pluginId	union
  			SELECT N'ad41ebe0-90a3-4efe-845a-329b86f5f268'	as pluginId	union
  			SELECT N'9ab5fd17-d971-4a36-b84d-104a8f6dd901'	as pluginId	union
  			SELECT N'85f9faec-30a9-4040-840f-8445da537c4a'	as pluginId	union
  			SELECT N'9a7e0c9f-7df7-4c7e-a83d-6ee8c1bdb340'	as pluginId	union
  			SELECT N'f0c63b93-fb9b-4a45-8c8b-079a483bb5cf'	as pluginId	union
  			SELECT N'e72d425b-b6f2-498e-a85e-251327bfbb18'	as pluginId	union
  			SELECT N'bafca1bc-1968-427d-b865-171ef6f31fd9'	as pluginId	union
  			SELECT N'0a431dea-5039-412e-a578-25e991ecfc6b'	as pluginId	union
  			SELECT N'75a541fe-fa44-45ee-a32c-ad14660c8d83'	as pluginId	union
  			SELECT N'f046efde-1b3b-4e1e-a9d0-e8443f7dc96d'	as pluginId	union
  			SELECT N'088cb9a2-e5df-49fd-8bfd-e56a74465a52'	as pluginId	union
  			SELECT N'60b08fd7-cd5d-4b47-9f1e-63378822c270'	as pluginId	union
  			SELECT N'1c2231e9-137b-4fa5-994f-dcfbd91d9766'	as pluginId	union
  			SELECT N'd6f2ba94-92ad-421e-9200-219d75c2b901'	as pluginId	union
  			SELECT N'df3744df-8af7-41c2-9956-dd02e4f9e615'	as pluginId	union
  			SELECT N'74191911-7E00-41F6-B203-32D739307F45'	as pluginId	union
  			SELECT N'D0FB68C3-51DB-4525-9D5B-3259EB527694'	as pluginId	union
  			SELECT N'DC2D62CA-7380-46CC-9D66-5BE19A5040A2'	as pluginId	union
  			SELECT N'7A39C363-7078-4CBC-8D68-B5320026CAD2'	as pluginId	union
  			SELECT N'A66B238B-4BE8-4196-918D-EE13A50B964F'	as pluginId	union
  			SELECT N'212CADEF-98A8-4B65-B364-A617FBB17293'	as pluginId	union
  			SELECT N'F38A64E0-E1F4-4A37-B94E-3C64BBF605ED'	as pluginId	union
  			SELECT N'F38A64E0-E1F4-4A37-B94E-3C64BBF605EE'	as pluginId	
		) P
		CROSS JOIN #TMP_ROLES  AS ROLES

		INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
		SELECT N'3dc78c7b-c9ce-4485-a835-63d577f623e6' AS [PartitionID], R.caObjectID AS [caObjectID] FROM [Roles] AS R
		INNER JOIN #TMP_ROLES AS T ON R.RoleID = T.RoleID

  		DECLARE @RoleID AS UNIQUEIDENTIFIER
  		DECLARE ROLES_Cursor CURSOR  
  			FOR SELECT RoleID FROM #TMP_ROLES
  		OPEN ROLES_Cursor  
  		FETCH NEXT FROM ROLES_Cursor INTO @RoleID
			
  		WHILE @@FETCH_STATUS = 0  
  		BEGIN  
  			exec ca_sp_InsertRolePrivileges @RoleID, 0
			UPDATE [RolePrivileges] SET SecurityLevel = 3 WHERE ScreenObjectID = 0 AND RoleID = @RoleID
  			FETCH NEXT FROM ROLES_Cursor INTO @RoleID
  		END
  		CLOSE ROLES_Cursor  
		DEALLOCATE ROLES_Cursor

		UPDATE O
		SET O.RoleID = ROLES.RoleID
		FROM #TMP_ROLES AS ROLES INNER JOIN [Operators] AS O ON  ROLES.OperatorID = O.OperatorID
	END
    DROP TABLE #TMP_ROLES
	--END This section is only usefull when update from CA4K beta release for users who had admin privileges and less number of devices in their partition

	DELETE FROM RolePartitions
	exec('INSERT INTO [dbo].[RolePartitions]([PartitionID],[RoleID])
    SELECT distinct OperatorPartitions.PartitionID, Operators.RoleID
    FROM   Operators INNER JOIN OperatorPartitions ON Operators.OperatorID = OperatorPartitions.OperatorID')

	UPDATE [Timezone] 
	SET [TimeFrom] = DATEADD(YEAR, 2006 - YEAR([TimeFrom]), [TimeFrom]), [TimeTo] = DATEADD(YEAR, 2006 - YEAR([TimeTo]), [TimeTo])
	WHERE YEAR([TimeFrom]) < 2006 OR YEAR([TimeTo]) < 2006

	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT N'3dc78c7b-c9ce-4485-a835-63d577f623e6' AS [PartitionID], D.DvrID AS [caObjectID] FROM [DvrConfig] AS D
	WHERE D.DvrID <> N'00000000-0000-0000-0000-000000000000'
	AND NOT EXISTS (SELECT TOP 1 1 FROM DevicePartitions WHERE [caObjectID] = D.DvrID)

	--GUIPlugin(Added Helper.dll)
	INSERT INTO [dbo].[guiPlugins] ([loadOrder], [pluginId], [displayName], [pluginAssembly], [availPartGroups]) 
    SELECT 150, N'5FC9C206-8A23-494C-BAAF-A2F1B0514575', N'Help',    N'CardAccess.Help.dll',    NULL WHERE NOT EXISTS(SELECT 1 FROM guiPlugins WHERE pluginId='5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	
	INSERT INTO RolePlugins ([RoleID], [pluginId])
	SELECT N'82B19834-4EF0-405B-9AD1-23860AAF4139', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'82B19834-4EF0-405B-9AD1-23860AAF4139' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'82B19834-4EF0-405B-9AD1-23860AAF4139')
	union
	SELECT N'AFC5A5C7-8834-4EB0-A4CA-307A2C38D135', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'AFC5A5C7-8834-4EB0-A4CA-307A2C38D135' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'AFC5A5C7-8834-4EB0-A4CA-307A2C38D135')
	union
	SELECT N'2F9D40EE-3B9B-42E9-BE20-35100860298C', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'2F9D40EE-3B9B-42E9-BE20-35100860298C' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'2F9D40EE-3B9B-42E9-BE20-35100860298C')
	union
	SELECT N'C123ADF5-9023-4A9D-83D7-5146DFBAEE77', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'C123ADF5-9023-4A9D-83D7-5146DFBAEE77' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'C123ADF5-9023-4A9D-83D7-5146DFBAEE77')
	union
	SELECT N'F9EE89FC-1971-49BF-959F-57E23350BFD8', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'F9EE89FC-1971-49BF-959F-57E23350BFD8' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'F9EE89FC-1971-49BF-959F-57E23350BFD8')
	union
	SELECT N'0DEDD8D6-C408-4B85-97C8-E34F332A406F', N'5FC9C206-8A23-494C-BAAF-A2F1B0514575'
	WHERE NOT EXISTS (SELECT TOP 1 1 FROM RolePlugins WHERE [RoleID] = N'0DEDD8D6-C408-4B85-97C8-E34F332A406F' AND [pluginId] = N'5FC9C206-8A23-494C-BAAF-A2F1B0514575')
	AND EXISTS (SELECT TOP 1 1 FROM Roles WHERE [RoleID] = N'0DEDD8D6-C408-4B85-97C8-E34F332A406F')

	--Operator Partition 
	SELECT PartitionID, Operators.OperatorID,1 as IsPrimaryPartition, RolePartitions.LastUpdated
	INTO [#TMP_RolePartitions]
	FROM RolePartitions inner join Operators on Operators.RoleID = RolePartitions.RoleID
	Where NOT EXISTS (SELECT TOP 1 1 FROM OperatorPartitions WHERE OperatorPartitions.OperatorID = Operators.OperatorID)

	UPDATE [#TMP_RolePartitions]
	SET IsPrimaryPartition = 0
	FROM [#TMP_RolePartitions] AS TAB1
	WHERE EXISTS (
			SELECT 1 FROM (
				SELECT max(cast(PartitionID as nvarchar(50))) MAXPartitionID, OperatorID, MAX(LastUpdated) MAXLastUpdated
				FROM [#TMP_RolePartitions]
				group by OperatorID
				HAVING COUNT(PartitionID) > 1
			) TAB2
			WHERE TAB2.OperatorID = TAB1.OperatorID AND TAB2.MAXPartitionID != TAB1.PartitionID  
			)
	INSERT INTO OperatorPartitions(PartitionID,OperatorID,IsPrimaryPartition,LastUpdated)
		SELECT PartitionID,OperatorID,IsPrimaryPartition,LastUpdated FROM [#TMP_RolePartitions]

	DROP TABLE [#TMP_RolePartitions]

	--Non Partition Panel insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM Panel
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition APBAreas insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM APBAreas
	WHERE AreaNo NOT IN(0,1,255) AND caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition Badge insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, PersonID FROM Badge
	WHERE PersonID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition Input insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM Input
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition Link insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM Link
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MAccGrp insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MAccGrp
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MActiveLinks insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MActiveLinks
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MActiveThreatLevel insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MActiveThreatLevel
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MCom insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MCom
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MHoliday insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MHoliday
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MLockdownAreas insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MLockdownAreas
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition MShunt insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM MShunt
	WHERE ShuntId>0 AND caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition Reader insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM Reader
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)

	--Non Partition Relay insert into DevicePartition with Admin
	INSERT INTO DevicePartitions ([PartitionID], [caObjectID])
	SELECT '3DC78C7B-C9CE-4485-A835-63D577F623E6' AS PartitionID, caObjectID FROM Relay
	WHERE caObjectID NOT IN (SELECT caObjectID FROM DevicePartitions)
	
	-- Insert Default values int DevicePartitions
	-- MTimezone 'Not Used'
	INSERT INTO DevicePartitions
	SELECT PartitionID,	'971B59B1-B15B-4880-B056-1D7D83337ACF' as caObjectID 
	FROM Partition
	WHERE NOT EXISTS(SELECT 1 FROM DevicePartitions WHERE DevicePartitions.PartitionID = Partition.PartitionID AND DevicePartitions.caObjectID = '971B59B1-B15B-4880-B056-1D7D83337ACF')
	
	 --1. Replace LastName=LN and Firstname=FN if LastName or Firstname is empty or null
	 UPDATE [dbo].[Person] SET LastName='LN' where LastName IS NULL OR LastName =''
	 UPDATE [dbo].[Person] SET FrstName='FN' where FrstName IS NULL OR FrstName =''
 
	 --2. Delete Person if there are no Badge records.
	 DELETE FROM dbo.Person WHERE NOT EXISTS(SELECT PersonID FROM Badge WHERE Badge.PersonID=Person.PersonID)
 
	 --3. Delete BadgeAccess data if there is no Badge record.
	 DELETE FROM dbo.BadgeAccess WHERE NOT EXISTS(SELECT Badge FROM dbo.Badge WHERE Badge.Badge=BadgeAccess.Badge and Badge.Facility=BadgeAccess.Facility)
 
	 --4. Delete BadgeCategories data if there is no Badge record.
	 DELETE FROM dbo.BadgeCategories WHERE NOT EXISTS(SELECT Badge FROM dbo.Badge WHERE Badge.Badge=BadgeCategories.Badge and Badge.Facility=BadgeCategories.Facility)
	 IF NOT EXISTS(Select [variableName] from [GlobalVariables] WHERE [variableName] = 'PhoneCredential_CloudUri')
		BEGIN
			INSERT INTO [dbo].[GlobalVariables]([variableName],[variableValue]) VALUES('PhoneCredential_CloudUri','http://ca4k.napconoc2.com:9595/ca4kapi')
		END

	 IF EXISTS(SELECT TOP 1 1 from AccGrp WHERE Agno = 0)
	 BEGIN
		DELETE FROM AccGrp WHERE Agno = 0
	 END

	 EXEC('UPDATE [dbo].[SystemSettings] SET AutoBadgeDeletionTime=10')

	 --------------Panel Time Schedule for each Panel------------------------
	 IF(NOT EXISTS ( SELECT TOP 1 1 FROM PanelTimeSchdule))
	 BEGIN
		declare @sqlStr varchar(max)
		set @sqlStr='
	 DECLARE [PanelTimeSchedule] CURSOR LOCAL
	 	FOR
	     SELECT PnlNo FROM Panel
	 	OPEN [PanelTimeSchedule]
	 	BEGIN TRY
	 		DECLARE @PanelNo INT
	 		FETCH NEXT FROM [PanelTimeSchedule] INTO @PanelNo
	 		WHILE @@FETCH_STATUS = 0
	 		BEGIN
	 			IF(@PanelNo>0)
	 			BEGIN
	 				INSERT INTO PanelTimeSchdule(LocalTzNo,PanelTzNo,PanelNo,caObjectId,LastUpdated)
	 				Select Schedule AS LocalTzNo, Schedule AS PanelTzNo, PnlRef AS PanelNo, NEWID() as caObjectId, GETUTCDate() as LastUpdated
	 				FROM
	 				(
	 				SELECT PnlRef, Ctz AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND Ctz > 0
	 				UNION
	 				SELECT PnlRef, Cctz AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND Cctz > 0
	 				UNION
	 				SELECT PnlRef, Cytz AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND Cytz > 0
	 				UNION
	 				SELECT PnlRef, Fatz AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND Fatz > 0
	 				UNION
	 				SELECT PnlRef, DegrSchedule AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND DegrSchedule > 0
	 				UNION
	 				SELECT PnlRef, OTLSchedule AS Schedule FROM Reader WHERE PnlRef = @PanelNo AND OTLSchedule > 0
	 				UNION
	 				SELECT PnlRef, TrackTz AS Schedule FROM Relay WHERE PnlRef = @PanelNo AND TrackTz > 0
	 				UNION
	 				SELECT PnlRef, InpTz AS Schedule FROM Input WHERE PnlRef = @PanelNo AND InpTz > 0
	 				UNION
	 				SELECT PnlRef, LimitSchedule AS Schedule FROM Input WHERE PnlRef = @PanelNo AND LimitSchedule > 0
	 				UNION
	 				SELECT PnlRef, ETz AS Schedule FROM Link WHERE PnlRef = @PanelNo AND ETz > 0
	 				UNION
	 				SELECT PnlRef, TrkTZ AS Schedule FROM Link WHERE PnlRef = @PanelNo AND TrkTZ > 0
	 				UNION
	 				SELECT PnlRef, Schedule FROM MActiveLinks WHERE PnlRef = @PanelNo AND Schedule > 0
	 				UNION
	 				SELECT PnlRef, Tz1 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz1 > 0
	 				UNION
	 				SELECT PnlRef, Tz2 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz2 > 0
	 				UNION
	 				SELECT PnlRef, Tz3 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz3 > 0
	 				UNION
	 				SELECT PnlRef, Tz4 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz4 > 0
	 				UNION
	 				SELECT PnlRef, Tz5 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz5 > 0
	 				UNION
	 				SELECT PnlRef, Tz6 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz6 > 0
	 				UNION
	 				SELECT PnlRef, Tz7 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz7 > 0
	 				UNION
	 				SELECT PnlRef, Tz8 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz8 > 0
	 				UNION
	 				SELECT PnlRef, Tz9 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz9 > 0
	 				UNION
	 				SELECT PnlRef, Tz10 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz10 > 0
	 				UNION
	 				SELECT PnlRef, Tz11 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz11 > 0
	 				UNION
	 				SELECT PnlRef, Tz12 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz12 > 0
	 				UNION
	 				SELECT PnlRef, Tz13 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz13 > 0
	 				UNION
	 				SELECT PnlRef, Tz14 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz14 > 0
	 				UNION
	 				SELECT PnlRef, Tz15 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz15 > 0
	 				UNION
	 				SELECT PnlRef, Tz16 AS Schedule FROM AccGrp WHERE PnlRef = @PanelNo AND Tz16 > 0	
	 				UNION
	 				SELECT PnlNo AS PnlRef, Schedule FROM SchedEvent WHERE PnlNo = @PanelNo AND Schedule > 0
	 				) AS TAB
	 
	 				FETCH NEXT FROM [PanelTimeSchedule] INTO @PanelNo
	 			END
	 		END
	 	END TRY
	 BEGIN CATCH
	 END CATCH
	 CLOSE [PanelTimeSchedule]
	 DEALLOCATE [PanelTimeSchedule]'
	 	 exec(@sqlStr)
	 END
	 
	 --------------Holiday for each Panel------------------------
	 IF(NOT EXISTS ( SELECT TOP 1 1 FROM PanelHoliday))
	 BEGIN
	 	declare @sqlStr2 varchar(max)
		set @sqlStr2='
	 DECLARE [PanelHoliday] CURSOR LOCAL
	 	FOR
	     SELECT PnlNo FROM Panel
	 	OPEN [PanelHoliday]
	 	BEGIN TRY
	 		DECLARE @pPanelNo INT
	 		FETCH NEXT FROM [PanelHoliday] INTO @pPanelNo
	 		WHILE @@FETCH_STATUS = 0
	 		BEGIN
	 			IF(@pPanelNo>0)
	 			BEGIN
	 				INSERT INTO PanelHoliday(LocalCalendarNo, PanelCalendarNo, PanelNo, caObjectId, LastUpdated)
	 				SELECT Holiday AS LocalCalendarNo, Holiday AS PanelCalendarNo, PnlNo AS PanelNo,NEWID() as caObjectId, GETUTCDate() as LastUpdated
	 				FROM (
	 					SELECT PnlNo, DefaultCalendar AS Holiday FROM Panel WHERE PnlNo = @pPanelNo AND DefaultCalendar > 0
	 					UNION ALL
	 					SELECT PnlNo, Holiday FROM (
	 					SELECT DISTINCT AG.PnlRef AS PnlNo, B.HolidayCalendar AS Holiday, B.Badge
	 					FROM AccGrp AS AG INNER JOIN BadgeAccess AS BA ON BA.AGroupNo = AG.Agno INNER JOIN Badge AS B ON B.Badge = BA.Badge AND B.Facility = BA.Facility 
	 					WHERE B.HolidayCalendar > 0 AND AG.PnlRef = @pPanelNo
	 					) AS BADGE_TAB
	 				) AS TAB 
	 				GROUP BY PnlNo, Holiday
	 				ORDER BY Holiday
	 
	 				FETCH NEXT FROM [PanelHoliday] INTO @pPanelNo
	 			END
	 		END
	 	END TRY
	 BEGIN CATCH
	 END CATCH
	 CLOSE [PanelHoliday]
	 DEALLOCATE [PanelHoliday]'
	 exec(@sqlStr2)
	 END

	 ----Remove all partitions for "CA4K Administration" role from RolePartitions Table Except "Admin Partition"-----
	 DELETE FROM [RolePartitions] 
	 WHERE RoleID = '82B19834-4EF0-405B-9AD1-23860AAF4139' AND PartitionID <> '3DC78C7B-C9CE-4485-A835-63D577F623E6'
	 
	 ----Set "Admin Partition" as PrimaryPartition for "Admin" operator-----
	 UPDATE OperatorPartitions  SET IsPrimaryPartition = 1 
	 WHERE PartitionID = '3DC78C7B-C9CE-4485-A835-63D577F623E6' AND OperatorID = '1EEB696C-0E28-4702-8598-C379C95B45E1'
	 
	 ----Remove Unused partitions from OperatorPartitions-----
	 DELETE FROM OperatorPartitions
	 WHERE NOT EXISTS 
	 (
	 	SELECT RP.PartitionID, O.OperatorID  FROM Operators O
	 	INNER JOIN RolePartitions RP ON RP.RoleID = O.RoleID
	 	WHERE OperatorPartitions.OperatorID = O.OperatorID AND OperatorPartitions.PartitionID = RP.PartitionID
	 )

	exec('IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N''EnableAperio'' AND Object_ID = Object_ID(N''Panel''))
	BEGIN
		UPDATE Panel SET EnableAperio = 1 WHERE PanelType = 16
	END')
	------------ Badge Format for Mobile Cridential LEN = 64 --------------------------
	IF NOT EXISTS (SELECT TOP 1 1 FROM Format WHERE FmtLength = 64)
    BEGIN
	DECLARE @maxFmtNo INT;
	SELECT @maxFmtNo = MAX(FmtNo) FROM  Format;

	INSERT INTO [dbo].[Format] ([FmtNo], [Description], [FmtLength], [FmtType], [FmtSS], [FmtSSO], [FmtES], [FmtESO], [FmtFS], [FmtFSO], [FmtCLen], [FmtCOff], [FmtILen], [FmtIOff], [FmtFLen], [FmtFOff],  [LastUpdated], [caObjectID]) 
	VALUES (@maxFmtNo + 1, N'Mobile Credential', 64, 0, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 0, 0,    getUTCDate(), NEWID())
    END

END
--IF @caDBType = 1 
--BEGIN
--	delete from dbo.Station 
--END
GO 
