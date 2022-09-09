CardAccess 4K Software Readme    06/17/2022   Rev-Q   


This document contains items the user should be aware of regarding the current release of the CardAccess 4K software package.  The list below contains pre-installation, installation and functional notes.
Please take the time to read this document in its entirety.  For a list of "New Features" by software version, see the bottom of this document.  



Version 1.1.61.165		
------------------

Firmware Versions:
	Accelerator / Accelaterm 		-  4.0.263
	Universe panel (std)			-  4.0.261 (NLM 12.8.2)
	Universe panel (Aperio)			-  4.0.361 (NLM 12.8.2)
	Super 2					-  4.0.233
	Turbo Super					-  4.0.233
	Wireless Locks S95xx, S90xx 		-  4.40
	Wireless Locks N95xx, N90xx 		-  4.46
	Wireless Narrow style PDL1300 	-  4.40
	Wireless Double Side  PDL6300 	-  4.45
	Wireless Locks all other types	-  4.40
	Net Panel					-  4.50
      Wireless Locks PDL4100, PDL4500	-  4.42
	Wireless Locks Gateway			-  G1-4.34, G2-5.48 , G3-6.28
	Wireless Expanders			-  2.38
	CA4K iLock for Continenetal App	-  Android 0.0.49, iOS 0.0.49
	CA4K App					-  Android 1.0.6, iOS 1.0.5
	CA4K App web				-  1.0.22 (137)	


CardAccess 4K new Features/Improvements:
1. GEN3- Xpico Gateway supported.
2. OSDP-V2 R485 secure reader support for CicP2100 panels (Limited to two readers)  
3. ATM Mode Operation for Badge - for CICP2100, Super 2, Accelerator and Accelaterm panels
4. Option to enable password expiration for operators
5. AES Enabled for Super 2, Accelerator and Accelaterm panels. CICP1300 LAN module and CICP1800 LAN Module required
6. Following Pages are added to CA4K web - 
	i)	System: 
			- Audit Trail
	ii)	Access: 
			- Badge Holders In
			- Lockdown Areas
	iii)	Administration:
			- Facility Codes
			- Badge Format
			- Operator Response
			- Operator Instructions
			- Operator Instruction Link
			- Threat Level Management
	iv)	Configuration:
			- Activity Link
			- Category Counter
			- Com Server & Ports
			- Shunt Group
	v)	Reports:
			- Audit Trail

7. Ca4K GUI Events report for personnel, additional personal fields can be appended to report (up to 4 fields)
8. Random PIN generator by button click on Badge Screen
9. Pair to Pair Lockdown supported (CICP1300 LAN module and CICP1800 LAN Module required)
10. SQL database backup for LiveConfig database
11. Option to enable local lockdown for 8600 locks using bolt

Bug Fixes:

1. Luxriot DVR DecodeMediaType error fixed.

Known Issues:





**************************************************************************

Version 1.1.54.162		
------------------

Firmware Versions:
	Accelerator / Accelaterm 		-  4.0.261
	Universe panel (std)			-  4.0.261 (NLM 12.8.2)
	Universe panel (Aperio)			-  4.0.361 (NLM 12.8.2)
	Super 2							-  4.0.233
	Turbo Super						-  4.0.233
	Wireless Locks S95xx, S90xx 	-  4.40
	Wireless Locks N95xx, N90xx 	-  4.46
	Wireless Narrow style PDL1300 	-  4.40
	Wireless Double Side  PDL6300 	-  4.45
	Wireless Locks all other types	-  4.40
	Net Panel						-  4.50
      Wireless Locks PDL4100, PDL4500	-  4.42
	Wireless Locks Gateway			-  G1-4.34, G2-5.48 , G3-6.28
	Wireless Expanders				-  2.38
	CA4K iLock for Continenetal App	-  Android 0.0.49, iOS 0.0.49
	CA4K App						-  Android 1.0.6, iOS 1.0.5
	CA4K App web					-  1.0.22 (137)	


CardAccess 4K new Features/Improvements:

1. Bluetooth Reader support for panels - download "iLock For Continental" Mobile App.
2. Milestone DVR API updated to 2021 R1 (x86).
3. Aperio support enhanced for CICP2100 and Acceleterm Panels up to 16 readers.
4. Aperio manual control supported for version 3 Locks with version 3 hubs for CICP2100 and Acceleterm Panels.
5. OSDP Time/Date display for Acceleterm, Super2 and Turbo Panels.
6. Password Lockout if type in wrong password more than 4 times. (Gui and web client).
7. Milestone Access plugin added (Refer DVD folder \VideoPlugins\Milestone). 
8. CrystalReports runtime version upgraded to 13.0.24

Bug Fixes:

1. Batch modify multiple issues fixed related to facility codes criteria, partition and person with multiple badges.
2. RESTful API multiple bug fixes and enhancements.
3. .NET API multiple bug fixes and enhancements.
4. Acceleterm keypad entry issue fixed. V 4.02.61
5. WEB: Multiple bug fixes and UI improved.
6. TimeSchedule doesn't go to panel when create new - intermittent issue fixed.
7. Cabinet lock type was changing to type while update from old version to current.
8. 9-digit PIN code issue fixed for NetPanel.
9. Luxriot DVR DecodeMediaType error fixed.

Known Issues:

1. Mobile Credential - It is recommended to use reliable paid service as SMS domain. Otherwise, SMS might get delayed or door name might get truncated. User might need to update the name manually
2. Multiple Time Schedule changes to an Access Group can cause badges that were once part of a valid Time schedule and no longer part of the new Time schedule to still be valid. A Badge download or a full download will need to be performed. This only affects Super2 and Turbo Super panels.


**************************************************************************

CardAccess 4K Software Readme  07/26/2021  CA4K 1.1.35.149  Service Pack 1


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 1 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version CA4K 1.1.35.149 Service Pack 1
-------------------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  No Change
	Wireless Locks all other types	-  No Change
	Accelerator / Acceleterm 	-  No Change
	Universe panel 			-  No Change
	Super 2				-  4.0.232
	Turbo Super			-  4.0.232


Fixes in Service Pack 1 

1. Data Migration Access group's time schedules shows 'Not used' fixed.
2. Fix Badge Modify - change badge Partition with criteria on badge and facility.
3. Milestone DVR camera index issue fixed.
4. Web Client Door Strike Time Override in Manual Door Control.
5. Add readme to CardAccess.APITest project.
6. Fixed Badge report not show records for some dates search criteria (US and Dutch cultures).
7. Operator with CA4k Admin Partition only shows Admin Partition in Reports(Events and Audit Trail).
8. Event Report: Partition new feature of "By Person" in Personnel tab.
9. CA4k facility maps will lock up ca4k application when map file sixze is too big.
10. Fix EventGridView not receives event after messaingService restart.
11. Superterm/super2 firmwareupdate to 04.02.31 to fix 'Unable to get lcokdown to trigger with threat level on turbo/Super2 40027.
12. API new feature "BadgeInfobyField" search Badge info by DB field name and value.
13. APB Area entry/exit event fix for Superterm/super2 firmware version 04.02.32.
14. Dynamic mapping icon status change for a non-pending event.
15. Manual Control default to Keypad check box when removing Door or Reader Action check.

Known Issues:

1. Personal and Badge Modify – If a person has multiple badges, by design all badges will be forced into same partition(s) regardless of Badge number and/or Facility code.


**************************************************************************

CardAccess 4K Software Readme    3/15/2021   Rev-M   


This document contains items the user should be aware of regarding the current release of the CardAccess 4K software package.  The list below contains pre-installation, installation and functional notes.
Please take the time to read this document in its entirety.  For a list of "New Features" by software version, see the bottom of this document.  


Version 1.1.35.149		
------------------

Firmware Versions:
	Accelerator / Accelaterm 		-  4.0.252
	Universe panel 				-  4.0.249 (NLM 12.8.2)
	Super 2					-  4.0.228
	Turbo Super				-  4.0.228
	Wireless Locks S95xx, S90xx 		-  4.40
	Wireless Locks N95xx, N90xx 		-  4.46
	Wireless Narrow style PDL1300 		-  4.40
	Wireless Double Side  PDL6300 		-  4.45
	Wireless Locks all other types		-  4.40
	Net Panel				-  4.42
        Wireless Locks PDL4100, PDL4500		-  4.42
	Wireless Locks Gateway			-  G1-4.34, G2-5.48 , G3-6.28
	Wireless Expanders			-  2.38
	CA4K iLock Cont app			-  Android 27, iOS 28
	CA4K App				-  Android 1.0.6, iOS 1.0.5
	CA4K App web				-  1.0.22 (137)	


CardAccess 4K new Features/Improvements:

1. SQL Server 2019 supported.
2. Expired Access groups in Reports are optional.
3. Event grid – added a menu to show all events except Valid Badge Events.
4. DVR - Video Insight API upgrade to support - RESTFUL API.
5. Architect Back-Button/Side-Button can be configured in system settings for Free Access functions. 
6. Integrated Wireless locks Battery booster support.
7. Added Napco integration configurations pages to web client.
8. Added Custom fields to be included in web client Personnel Reports.
9. Middle Name can be displayed display in the main GUI (optional).
10.Description filed is added for Wireless Gateway and Expanders in Wireless configuration screen.
11.Avigilon DVR API upgraded to 6.14.12.8 and requires DirectX 9.0c June 2007 Redistributable (installer is in Drivers->DirectX folder)
12.Remote clock support using AUX board added to Supper2 panels.
13.New generation of Wireless Gateway ( Gen - 3) supported.
14.A new search feature added, called “Quick Search” in personal screen.
15.Added privacy mode for new Lock types PDL4100 and PDL4500.
16.Added Canadian toggle mode for Architect locks types N9500 and N9000.
17.Napco integration page- Added a button to upload zone descriptions from napco panels.
18.CA4K RESTful - API added to help seamless integration by third party applications.
19.C#.NET API installer added to DVD.

Bug Fixes:

1. Batch modify not work if Facility code entered.
2. Wireless equipment going offline often.
3. ImportExportUtilit under report menu not importing into correct partitions.
4. No longer can preview and print in alphabetical order as in CA3000.
5. When trying to modify Access groups getting error pop up Cannot access a disposed object.
6. When changing any fields and saving in the Access Group screen error pop up for Key Already Exists.
7. DB Server installs, MBL log is growing issue fixed.
8. Email address giving error when there is a number included in email address.
9. Schedule Changes do not keep the correct data when adding multiple Changes.
10.When running SP2 install on HCS server on a different subnet, error pops up when attempting to connect to the DB Server 
11.When language set to Dutch and Filter set to APB Area no information is displayed. Yet if set to English they do show information.
12.Unable to shift and select multiple readers in access group window.  
13.Data pump issue on import fixed.
14.When adding Avigilon DVR, after saving Object reference not set to an instance of an object error fixed.
15.Select Filter option by selecting readers (not working in Dutch and English)
16.Getting Collation error on Dutch OS after upgrading from 1.1 SP1 to 1.1 SP2.
17.API - String was not recognized as a valid Date Time for GetEvents function.
18.Grand Total added on TA report.
19.System settings - removed 6 AG label limit for Wireless Locks.
20.MBL Error when DB server is installing on separate computer.
21.Schedule changes do not keep the correct data when adding multiple changes.
22.Email address giving error when there is a number included in the email address.
23.Unable to shift and select multiple readers in access group window. 
24.Badge Holders in list (Dutch Language) error fixed.
25.Data pump badge import error when change existing access group.
26.Signature Pad - Signatures "pops off" screen when saved on new record.
27.Archive Service crash at service start for some Database server setup, hang archive not more than 5000 records at a time.
28.Dynamic Maps - Can't create new map. After adding name and description and selecting OK nothing happens. 
29.Data migration - When attempting to add a new card system is not updating the panel, due to table AccGrp, TimeZone, PanelTimeSchdule all contains a mysterious timezone number 4095.
30.Fixed Scripting not print In-List report –Dutch OS.
31.Reports- Operator (has admin permission, not super admin) that is set for CA4k Admin Partition will only get the Admin Partition to show on the drop menu. 
32.Customer cannot see any events in View History. Personnel screen only show partial activity
when running SP2 update. 



Known Issues and Pre-Installation Notes:

1.Avigilon DVR requires DirectX 9.0c June 2007 Redistributable (installer is in Drivers->DirectX folder)
2.Some of the DVR camera features may not be available due to third party API limitations.


**************************************************************************

CardAccess 4K Software Readme  09/23/2021  CA4K 1.1.16.137  Service Pack 3


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 3 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    



Version CA4K 1.1.16.137 Service Pack 3
-------------------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  No Change
	Wireless Locks all other types	-  No Change
	Accelerator / Acceleterm 	-  No Change
	Universe panel 			-  No Change
	Super 2				-  4.0.232
	Turbo Super			-  4.0.232


Fixes in Service Pack 3 

1. Batch modify will not modify facility codes.
2. Added Category Counter feature in API.
3. Wireless CNet-Panel going offline.
4. Badholder in report last names ordering in alfabetical order and  web client report still with two English words. - Dutch OS. 
5. SP2 Update collection error. Fixed
6. Wichita Import max badge length issue. Fixed
7. Import/Export Utiity - correct import facility/badge/lastname position are hard coded. Fixed; give a progress cue when import in process. 
8. Archive service UpdateDababaseListDates exception when run under Dutch Culture. Fixed
9. Added new format to Badge Holders In List.
10. Grand Total added on Time-and-Attendance report.
11. Access groups screen error with Spanish Culture Fixed; access groups 'key already exists' error so some sort order. Fixed
12. MBL Error log when DB server install on another machine. Fixed
13. Email address giving error when there is a number included in email address. Fixed
14. Badge Holders In List (Dutch Language) show text at incorrect position. Fixed
15. Unable to shift and select multiple readers in access group window. Fixed
17. update a API func for Chico State University.
18. data pump Import issue for deleted record. Fixed
19. API fixs - 
	-String was not recognized as a valid DateTime for GetEvents;
	-EmbossedID added on UpdateBadge and Search Badge by Field;
	-Add CompanyName to GetAllBadgesByPerson return columns and other Enhancements;
	-Added functions GetStatus and GetStatusDefinition to get devcie status with codes. 
        -Badge Operation Fixed 
20. Restful API added.
21. Prevent dup item in cboDestinationDatabases at DataMigration screen
22. Migration executing subquery error for some Ca3000 DB. Fixed
23. Signature Pad not Save some captures. fixed.
24. Unable to get lcokdown to trigger with threat level on turbo/Super-2, firmware version 40027. Fixed
25. Archiving slowing sysytem down, not archive more than 5000 each archive cycle. fixed
26. Dynamic Maps can't create new map. fixed
27. Mystery 4095 Timezone carried to Ca4k DB after Migration. fixed
28. Scripting not print inList report. fixed
29. Operator with 'CA4k Administration' role only see 'Admin Partition' in dropdown at Report screens. Fixed.
30. View History and Persnnel not showing events and get error popup.
31. Batch Modify not move to target partitioning correctly when criterias are Badge and facility. fixed.
32. Add a Restful API Demo project to Ca4k software distribution.
33. Badge report - Deactivation no record found fixed.
34. Milestone DVR integration camera list shifts when adding new camera. (Should turn on the database flag manually)
35. Archive events – improved performance.
36. Multiple event archive database created in Dutch language.
37. Personal report issue fixed.
38. Manual Control default to Keypad check box when removing Door or Reader Action check
39. At end Service pack install, MBL not start in correct order
40. API UpdateBadgeParams can't clear Badge.actvDate or Exprdate
41. Web Client Door Strke Time Override in Manual Door Control minuets
42. Add readme to CardAccess.APITest project
43. Fixed Badge report not show records for some dates input criteria
44. Operator with CA4k Admin Partition only shows Admin Partition in Reports(Events and Audit Trail)
45. Event Report: Partition new feature of "By Person" in Personnel tab
46. CA4k facility maps will lock up ca4k application when map file sixze is too big
47. Fix EventGridView not receives event after messaingService restart
48. Superterm/super2 firmwareupdate to 04.02.31 to fix 'Unable to get lcokdown to trigger with threat level on turbo/Super2 40027'
49. API new feature "BadgeInfobyField" search Badge info by DB field name and value.
50. APB Area entry/exit event fix for Superterm/super2 firmware version 04.02.32.
51. Dynamic mapping icon status change for a non-pending event.
52. RESTful API – Get Relay, Links and Get Readers, Readers Detail fixes.
53. Can’t edit badge on web if Mobile credential is enabled.
54. Web report Compress mode fixed.
55. Web report – Time and attendance 12 and 24 hour format fixed.
56. Web - Supervisor not loaded on the grid and also can’t preview report when selected.
57. Access Group usage count not found correct record for old existing Access Group.
58. Deleting Time Schedule allows before delete the Access Group which associated in WEB.
59. Data Migration - Cannot insert the value NULL into column Partition Name on Partition table.
60. Scripting Messaging Templates duplicate ID issue fixed.
61. Badges modify with facility code criteria and access group change Fixed.
62. Activate Directory - handle no user or password called into GetAllADGroups.
63. DVR Video Insight Legacy API - Allow custom data and command ports along with IP address.
64. Two digit length badges can’t be edited.
65. Badge report  - a specific date don’t find any record.


Known Issues:
1. Personal and Badge Modify
	a.If a person has multiple badges, by design all badges will be forced into same partition(s) regardless of Badge number and/or Facility code.
	b."Create and/or Modify All" may not work for Control, Personal and Custom tabs. Please use "Create New Only" or "Modify Existing Only" options.
	c."Create and/or Modify All" may not work when a badge with 0 facility code exists in the range of badges.Please use "Create New Only" or "Modify Existing Only" options.


**************************************************************************

CardAccess 4K Software Readme  07/09/2020  CA4K 1.1.16.137  Service Pack 2

This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 2 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version CA4K 1.1.16.137 Service Pack 2
-------------------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  No Change
	Wireless Locks all other types	-  No Change
	Accelerator / Acceleterm 	-  No Change
	Universe panel 			-  No Change
	Super 2				-  No Change
	Turbo Super			-  No Change


Fixes in Service Pack 2 

1. Migration- Dynamic mapping points are missing after migration and do not come over for all operators.
2. Dynamic Mapping- can't operate a door while camera operating.
3. Active directory synchronization doesn’t import any users for some groups and throw exception.
4. Event Report doesn’t work if an input or relay name is more than 50 characters.
5. API- UpdateBadgeParams function doesn’t work for UseCount parameter.
6. Reports - Badge Report doesn’t work for Access List with sub category Access Groups.
7. Scripting service cannot be stopped, intermittent issue.
8. Personal badge access report - some access groups are missing.
9. Badges report- Same badge with two different facility codes doesn’t show properly.
10. Web station screen doesn’t filter logged in users as per Partition. 
12. Personal report doesn’t work if a user filed name is same as one of the database field.
13. Web reports don’t work from other computers other than the one where web client was installed.
14. System settings can't be open due to RPC service error - Fixed to show system settings with error displayed.
15. System Settings doesn’t show all Active directory groups.
16. Badge report - Reader Access shows badges that are disabled in the report. Now user can select to include or exclude disabled badges.
17. Personal Reports might not show any records if one or more user defined field’s name matches ca4k database column’s name.
18. Stations screen should filter Login Users by Partition, fixed for GUI and Web.
19. Cardholder Search function doesn’t short find-criteria fields alphabetically in Dutch language.
20. Migration - Cannot Resolve The Collation Conflict error, Fixed.
21. Dynamic Mapping- Camera List was not populationg.
22. Top of the hour multiple Archive Database creation, fixed.
23. SAP Crystal Report option to Export excel file is removed. Recommended to use PrintToFile.
24. Find usages Access Group access list is ordered by name.
25. Batch Modify will not allow an access group to be changed to "No Access", Fixed.
26. Inputs and Relays could disappears from Link and ActivityLinks when they are deleted.
27. Search Badge Number at Personnel Screen will find only the first badge number when a person has multiple badges.




**************************************************************************

CardAccess 4K Software Readme  04/24/2020  CA4K 1.1.16.137  Service Pack 1


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 1 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version CA4K 1.1.16.137 Service Pack 1
-------------------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  No Change
	Wireless Locks all other types	-  No Change
	Accelerator / Acceleterm 	-  No Change
	Universe panel 			-  No Change
	Super 2				-  No Change
	Turbo Super			-  No Change


Fixes in Service Pack 1 

1. Super2 followed by few Turbo Superterm panel's firmware download Aborted. Firmware and data download might be still slow. (Recommended to disable all panels and download one panel at time to speed up)	
2. Events Reports might take long time to open or hang when Live Event and Archive database became big and/or numbers of Archive database(s) are high.
3. Access group screen can be shorted by Description or Panel number (Right click on the first column to see these options).
4. Wireless Locks "Badge Violate Time of the day" events when use many time schedules.
5. Unable to Create New Activity Links "Object Reference Error".
6. Panel and Reader screens take long time to open.
7. Event Report for a Reader showing multiple records of the same event.
8. Default calendar holiday edit not going down to the locks without manual download.
9. View history or filtering too slow when event database size is larger.
10. Add/change time schedule to a reader of hardwired panels lock and re-opens other doors.
11. View History - Slowness Issue - Fixed - By Individual Database
12. Language nl-NL resources updated.
13. Fix for Ca4KApi PostEvent.
14. Lock Type CETPDNIRX not displaying the keypad option in the reader screen. 
15. After Migration signature pad info not showing in personnel screen.
16. LDAP and Web Client Not working for Logins.
17. Salient DVR Error Message On Camera Call up when DB stored cameras differ than current cambers on server.
18. DVR-Pelco, if camera offline, CRASH occurs if you try to access it.
19. Fix Auto Archive /Manual Archive Event logic so that max reduce time-out issue.
20. Language Translate - Inlist Report.
21. Event Report screen takes longer to open.
22. Multiple fixes for Luxriot DVR- Improved performance and crash issue.
23. Com Port screen will not allow a second com port with the same IP address.
24. EPI - Badge Signature Pad Image Saving fixed.
25. Data pump service fixed for Badge Import service - Date of Birth not insert/updated and few other improvements (for type 1).
26. Fix Auto Archive /Manual Archive Event logic improved to handle larger database size.
27. Scripting in-list printing doesn’t work (intermittent) for network printers. 
28. Script In-list printing by Partition.
29. Scripting Server stops running the script and "SCRIPT EXECUTION ERROR" event fix.
30. API BadgeOperation fix to allow PIN code as an optional parameter and doesn't allow AGseqNo = 0 to be inserted by UpdateBadgeAccessGroup.
31. Warning message if Event Report Stat time is greater than End time.
32. Data Migration Duplicate Operator Name issue fixed.
33. In some cases editing existing operator could crash the MBL service. 
34. Web page Personal Photo doesn’t maintain the aspect ratio.
35. Input screen doesn’t display camera names correctly.
36. Basic search window doesn’t filter names properly for first name and last name.   
37. EPI-Alerts/Events Aspect Ratio of photo changes.
38. Database update from 1.0.50 to 1.1.16 - Admin role operator issues.
39. Criteria search using badge number or anyother fields last searched value will be cleared by default.
40. Access group screen expanded reader selection will not collapse when access group selection is changed.
41. Access Group time schedule assignment now allows type in search filtering.
42. Personal screen Badge number allows copy and paste.
43. Personal screen allows search filter by Partition/Group.
44. Active Directory synchronization doesn’t work if an Active Directory Group is not readable by Import process.
45. A new CardAccess.ClientConnect.exe utility program was added to tools folder. This software can be used for workstation connect to multiple CA4K systems from a single computer.
46. Luxriot DVR integration will not support MPEG and JPEG video formats. 

Known Issues

1) Luxriot DVR timestamp display overlay is not supported. 



**************************************************************************

CardAccess 4K Software Readme    11/15/2019   Rev-J   


This document contains items the user should be aware of regarding the current release of the CardAccess 4K software package.  The list below contains pre-installation, installation and functional notes.
Please take the time to read this document in its entirety.  For a list of "New Features" by software version, see the bottom of this document.  


Version 1.1.16.137		
------------------

Firmware Versions:
	Accelerator / Accelaterm 		-  4.0.245
	Universe panel 				-  4.0.249 (NLM 12.8.2)
	Super 2					-  4.0.227
	Turbo Super				-  4.0.227
	Wireless Locks S95xx, S90xx 		-  4.40
	Wireless Locks N95xx, N90xx 		-  4.40
	Wireless Narrow style PDL1300 		-  4.40
	Wireless Locks all other types		-  4.40
	Net Panel				-  4.40
	Wireless Locks Gateway			-  G1 4.34, G2 5.48
	Wireless Expanders			-  2.38
	CA4K iLock Cont app			-  Android 27, iOS 28
	CA4K App				-  Android 1.0.6, iOS 1.0.5
	CA4K App web				-  1.0.8 (137)	

CardAccess 4K new features/Improvements:

1.Wireless Locks blue tooth credential to work with iOS and Android apps to unlock doors. 
2.Privacy mode of Personal Information deletion for Europe customers.
3.Auto Badge Import process added to Data Pump service. Replaces CA3000 Import.exe.
4.Added export reports content to excel files. (Similar feature as in CA3000).
5.Added device filter and sorting to web Events Report.
6.AES 128 encryption added to Universe Panel, requires NLM firmware version 12.7.9 or later.
7.Emergency door unlock function added to Universe Panel, requires panel firmware version 4.0.242 or later.
8.Updated Milestone DVR SDK to 3.0 to support latest Milestone VMS.
9.Updated Salient DVR SDK to ver 4.8.0.36 to support latest Salient VMS.
10.Added new DVR type "PelcoVideo Expert" SDK ver 2.1.0.92 to support latest Pelco VMS.
11.Added new DVR type "Aventura" with SDK ver 8.9.11.
12.CA4K to runs with SQL Server 2016 and 2017. Please note SQL Server 2008 R2 is not tested with this release and SQL 2012 and 2014 are still supported.
13.Wireless Locks can support 16 Access Groups like hardwired panels.
14.Active directory synchronization to import card holders from Active directory.
15.Allow more than 254 Time schedules to configure in the software. Limit of maximum of 254 time schedule per panel still exists.
16.Can configure unlimited Holiday Calendars per system with each Holiday calendar having up to 100 holidays. Each panel is limited to 5 Holiday calendars.
17.Badge Expiration by number days of disuse to removed badges if they are not used for certain period.
18.Scripting screen is improved to list all configured scripts to the left side of the window.
19.Central station reporting screen is improved to list all configured reporting to the left side of the window.
20.2nd Level privileges like in CA3000 is added allow partial privileges to be applied with in a Partition/Group.
21.Few more user friendly navigation menus added to show related Readers/Relays/Inputs from Panel screen etc.
22.Simple search added to configuration screens and manual control screen.
23.Filtering text box added to panel download screen.
24.Firmware/data download to multiple Locks by Group command. Reduce firmware download time.
25.New screen added to wireless lock configuration screen to download all locks firmware by gateway.
26.Soft click sound option added to Reader screen for Wireless Locks.
27.Double tab override feature added to Reader screen for Wireless Locks. If enabled, door in free access can be locked by double tab.   
28.CA4K App with limited features for iOS and Android mobile devices.
29.Luxriot DVR integrated.
30.CA4K API enhanced with lots of additional functions.
31.Lock type CETPLNiRx integrated.
32.Lock type CPDL1300 integrated.

Bug Fixes:

1.Auto Events and Audit logs archive time out fix when number of records is high.
2.LDAP fix with domain name. LDAP path is not required anymore and a domain user can pull user groups and authorize/authenticate against Active Directory.
3.Badge Violate Void at panel Script issue when use system wide specific badge (Introduced in SP2).
4.Personal screen User field edit hang the GUI when change facility code and clear a user field at the same time.
5.Optimized Wireless commands execution for large number of Locks. (Optimize interval 60 seconds)
6.Optimized Wireless Lock Access Group edit to send only affected locks to minimize commands download. 
7.Firmware and Data downloads restarts after socket restart.
8.Expanded Access Group view keeps collapsing when click on the scroll bar.
9.Remark field doesn’t show full content in the Badges report.
10.In some cases delete data from a custom field doesn’t delete the records.
11.LDAP web log in Fixed (Introduced in SP2)
12.Web - Operators changing Privileges for child operator in Manual Control not working as expected.
13.Send clock sync to particular Lock if any event received from the lock having Time Stamp difference more than 10 min from its Zone Local Time.
14.Universe Finder utility improved to configure Universe panel LAN settings from application additional to the web page.
15.Batch Modify by criteria fixed.
16.Dedicated Access groups fixes. Deleting other access groups ,doesn’t show name correctly, etc.
17.Status screen - Inputs Status doesn’t display correctly for some inputs. 
18.In-List screen when select Company in User field Dropdown Grid not show company name, nor sort.
19.Web time schedule selection doesn’t save in IE browser.
20.Multiple times adding and removing Partition to a privilege remove that partition.
21.Keypad Lock Firmware fix for common code FFFF.
22.Wireless lock firmware download fix for losing badges and download issues.
23.Scripting execution failed after days of operation.
24.Red-X appear in the event grid after days of operation.
25.Gateway and Expander firmware fix for check sum error.(Fixed in Gen-1 ver 4.34, Gen-2 ver 5.48, Expander ver 2.38)
26.Wireless lock firmware download fix for Locks on the Expander (may see in Lock firmware ver 4.09). Return address bug fixed and bootloader push.
27.Wireless lock Proper Battery voltage display and Low battery event.
28.Wireless lock Badge violate void at Lock fixed by liner search (may see in Lock firmware ver 4.09).
29.Wireless lock freeze-up fix (continuous beep with RED led or motor cranking). (may see in Lock firmware ver 4.09).
30.Double tab 2 seconds wait time increased to 6 seconds to allow enough time for Card and PIN entry.
31.Acceleterm firmware fix for Input status display will not reflect actual panel input status.
32.Acceleterm firmware fixes to enable faster keypad PIN entry.
33.Hardwired panels PIN entry improved for Acceleterm and Supper-2 by clearing previous PIN entries.

Known Issues and Pre-Installation Notes:

1.Unlock wireless Lock doors using Samsung Android phones might experience failure at first try. Re-try may require.
2.Sending mobile credential using SMS for Wireless Lock might not work properly for some carriers due to the restrictions of text length. Should use email or "Upload file to cloud" as alternative.
3.Unlocking Wireless Lock doors using mobile phones might experience delay in some cases where lots of blue tooth devices are being used. Re-try may require.
4.Some universe panel’s in repeat mode might not auto request firmware or data download when power failed or reset. Manual download from software will fix the issue.
5.If “Privacy Settings” is enabled and “Privacy Mode Delay” is set to 0 days in the system settings, when an existing badge is disabled by user, this badge holder’s personal information will not be deleted automatically.
6. Bluetooth Mobile credential does not support two person reader features.  
7. Architect Keypad firmware should be updated from Wireless Lock Configurations screens for Architect Keypad Locks. New firmware can be verified by pressing and holding #1 button and hear 1 long beep followed by 3 short beeps. This test should be done within 10 minutes after new keypad firmware download.
8. Following features are not supported for mobile credential - Embossed, Re-Issue, Facility, Batch Modify and Import/Export Utility.
9. iLock Continental App minimum requirements - Android 4.3 and iOS 9.0.
10.Anti-Pass back (APB) is not supported for Wireless Locks Mobile credentials.
11.Card and Pin feature isn't supported with Wireless Locks Mobile Credentials.
12.CA4K is not tested with SQL Server 2008R2.
13.Salient DVR Forward and Rewind function may not work properly.
14.Pelco Video Expert - Export Video and Image capture may not work properly.
15.Badge Modify will not restrict Holidays and Time schedules for panel, but will be trimmed to their maximum allowed when download to panel.



********************************************************************

CardAccess 4K Software Readme  10/10/2019  1.0.50.72 Service Pack 3


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 3 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version 1.0.50.72 Service Pack 3
-------------------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  3.72
	Wireless Locks all other types	-  3.61
	Accelerator / Acceleterm 	-  40242
	Universe panel 			-  40236 (LAN NXP- 12.7.8)
	Super 2				-  40226
	Turbo Super			-  40226


Fixes in Service Pack 3 

1.	Auto Badge Import feature added to Data Pump service (Can be used only at Host PC, Server only or HCS).- Replace of CA3000 Import.exe.  
2.	Data Migration fixed for Database only installs.
3.	Auto archive - Audit log archive timeout fix and events struck in the event table.
4.	LDAP fix with domain name.
5.	Scripting fix for system wide Badge Violate void at panel for a specific badge.
6.	Personal screen hang when change facility codes after empty a user field.
7.	Optimized wireless Locks commands download for a larger system which uses Badge Import service (optimize command execution; Access Group edit to send only effected locks, etc.).
8.	Firmware and Data download re-starts after Wireless Lock socket server is restarted.
9.	Access Group keep collapsing when click to stroll bar.
10.	Badges report -The Field Remarks isn't showing the full content when executing the report.
11.	Web client LDAP login fix.
12.	Reports - added simple export to excel menu like in CA3000.
13.	Changing Operator’s Permissions in the Web Client not working.
14.	Send clock sync to a particular Lock if any event received from the lock having Time Stamp difference is more than 10 min from its Zone Local Time. 
15.	Universe finder utility- added feature to configure LAN settings from application. Eliminate the use of web interface.
16.	Batch Modify fix for - Modify Badges base on criteria selection, Assign partition using criteria.
17.	Dedicated Access group not showing correct first and last name,  no proper audit log and Multiple issues when right clicking AG and removing AG.
18.	Status screen doesn’t show correct Input Status and slow update.
19.	In List screen when select a Company in User field Dropdown Grid not show company, nor sort.
20.	Web Event Report modified to have Filter Devices.
21.	Web time schedule selection fix.
22.	Events from Secondary Com Server Not Being Written To Database.
23.	Migrated archive database does not show up in the event reports -Customer Events Report and View History issue. Also fixed for web client.
24.	Scripting activates for disabled relay.
25.	Door now close to de-activates threat level not working with scripting.
26.	HCS fix for event broadcast slowing down panel download on a larger system with hundreds of panels.
27.	Lockdown Area screen Reader Sort and Expand only assigned Panel.
28.	Fix for HCS ComDb badge update caused by invalid Metadata.
29.	HCS Crash Fixed for “Cannot access a disposed object" on a larger system.
30.	Secondary HCS event broadcasting Packet failed error fixed.
31.	A button added to Customer service utility for Manual event archive. 
32.	Few partition issues fixed for post migration. After Migration Database Partitions missing.
33.	Crash exception handled if use Net Link connection type for Napco integration.
34.	Wireless Locks - Valid cards start coming up Deined Void after some period of time.
35.	Scripting fails after a few cycles- changed to work by polling event database, also improved messaging.
36.	Activity Link stops working after migration.
37.	PIV 75 Bit not working after migration Turbo Accelerator Panels - HCS fix.
38.	Personal screen fix for imported photo display stretched.
39.	Video Integration does not pull correct time when viewing in Browse Mode.
40.	Web Client Photo Popup doesn’t work always.
41.	Red-X fix for event grids. May block other popup features if events comes more than few a seconds.
42.	Replacing a lock from a gateway to another gateway lock lost the configurations.
43.	Allow to add more than 128 gateways.
44.	After a ca3000 migration Time & Attendance badge holder filtering by partition.
45.	Acceleterm firmware fix for Input status display will not reflect panel input status correctly.
46.	Acceleterm firmware fixes to enable faster keypad entry.
47.	Hardwired panels PIN entry improved for Acceleterm and Super two by clearing PIN entries and with 6 sec PIN timeout.


Known Issues

1) Unable to use keyboard tab in Personnel to move from field to field in Custom created forms.
2) Superterm (Legacy) panels still requires V2 chip to run with CA4K.
3) Wireless Locks could send multiple Lock Start up events once they are power down or low battery.
4) SQL Server 2008R2 data migration  might throw nested error during migration, upgrading to SQL Server 2012 or SQL Server 2014 will solve the problem.
5) Multiple Network Adapter - If using Wi-Fi Network adapter and the Wi-Fi adapter isn't the first priority in the network metric. You will need to      disable all other network adapters.Or from the CA4K customer service utility under the configuration settings set the IPAddress option to the Wi-Fi      IP address.



********************************************************************
CardAccess 4K Software Readme  8/21/2018  1.0.50.72 Service Pack 2 


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 2 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version 1.0.50.72 Service Pack 2
---------------------------------

Firmware Versions:
	Wireless Locks S95xx, S90xx 	-  3.72
	Wireless Locks all other types	-  3.61
	Accelerator / Acceleterm 	-  4.0.237
	Universe panel 			-  4.0.231 
	Super 2				-  4.0.225
	Turbo Super			-  4.0.225

Installation :
1. Service Pack 2 must be installed before executing CA3K migration.


Fixes in Service Pack 2 

1.	Fixed Bogus PIV text in Badge Event ( Eg. BADGE VALID (Series), etc.) from Turbo Superterm Panels. 
2.	Report menu rearranged in CardAccess GUI.
3.	Some Language related fix for Netherland Operating system.
4.	HCS Service fixed to allow auto IP address to be used with loopback adaptor. Required for panels connect via RS232 and no network cables.
5.	API - Default values are allowed for activate/deactivate for UpdateBadgeAccessGroup function.
6.	CardAccess GUI fix for Configuration file read error with certain user policies.
7.	Improved messaging service slowness issue when configured with hundreds of panels. 
8.	HCS service fix to improve initialization of hundreds of panels.
9.	Added manual control Keypad Enable/Disable feature. (GUI and Web).
10.	Double tab feature added for all non-legacy panels.
11. 	Highlight Repeaters if signal levels are low.
12.	Wireless lock socket server optimized for badge downloads.
13.	Architect lock types keypad support enabled.
14.	Wireless lock socket server optimized for Access group edit and time schedule edit.  
15. 	Data Migration fix for value NULL in EPI_Format Table.
16.	Badge modify fix when use batch criteria for Access Groups.
17.	Scripting Area Unlock SubType event now available.Lockdown Deactivate event fix to enable reader.
18.	HCS/WLSS fix for multiple network adaptor and to specify the network adaptor to use for callback.
19.	Lockdown by Scripting doesn't display banner in the status bar.
20.	Settings file fix to save configuration at both Public and Program data folders. This fix also implements the Events Lost when creating a new database after installinfg SP1.
21.	Improved the speed of Loading Access groups view.
22.	CICP2100 Panel data lost after power re-cycle.
23.	Badge modify wipe out PIN code entry in personal screen.
24. 	CaDBUtils does not allow blank password anymore.


Known Issues

1) Unable to use keyboard tab in Personnel to move from field to field in Custom created forms.
2) Superterm (Legacy) panels still requires V2 chip to run with CA4K.
3) Wireless Locks could send multiple Lock Start up events once they are power down or low battery.
4) SQL Server 2008R2 data migration  might throw nested error during migration, upgrading to SQL Server 2012 or SQL Server 2014 will solve the problem.
5) Multiple Network Adapter - If using Wi-Fi Network adapter and the Wi-Fi adapter isn't the first priority in the network metric. You will need to disable all other network adapters.Or from the CA4K customer service utility under the configuration settings set the IPAddress option to the Wi-Fi IP address.





********************************************************************
CardAccess 4K Software Readme  6/5/2018  1.0.50.72 Service Pack 1  


This document contains items the user should be aware of regarding the CardAccess 4K Service Pack 1 software package.  The list below contains pre-installation, installation and functional notes.

Please take the time to read this document in its entirety.    


Version 1.0.50.72 Service Pack 1  
---------------------------------

Pre-Installation Notes: 

1. 	After creating new databases, Service Pack 1 must be executed again. 

Fixes in Service Pack 1 

1.	Concurrent badge edits change the badge number and access groups
2.	Concurrent edit from any web pages caused configurations cross over to partitions
3.	EPI badging CA3000 data migration of User field, Department, Location and Company doesn't show upon template and Image doesn’t popup Cropping window
4.	EPI badging text Auto size property shrinks the font size.
5.	Import/Export Utility with default values doesn’t import badges correctly.
6.	Universe controller - Virtual Inputs (Input 49 – Input 56) are not configurable.
7.	Universe controller – Reader 2 Bypass Input - should be able to disable it by setting to "0"
8.	Expanders after migrating from CA3000 to CA4k did not get migrated properly
9.	Compressed Format of Badge Report added to Desktop client.
10.	Alpha sorting in multiple screens
11.	Acceleterm fix for missing keypad strokes due to slow timing handling of keypad
12.	Wrong panel count exceeded message when have many Wireless Locks in the system.
13.	“*” Values keep showing up in Reader, Input and Relay screens when panel count > 1000
14.	Allow Event and Time Attendance Report to print using Windows Task Scheduler and report schedules migration
15.	Acceleterm Activity Links doesn't work for readers 9-16 and not getting "Input Normal" event
16.	DL'S and ETPD locks don’t have the LED check box in the reader screen
17.	Audit Trail Logs are not filtering and showing to upper lever Administrator users
18.	Personal - PIN code and SSN should be in the search fields if not hidden in the system settings
19.	Personnel data cannot be changed after saving when badge ID 10 digits or higher
20.	Batch modify wipe out existing access groups
21.	HCS - Legacy panels badge download fix
22.	Scripting Deactivate Threat Level fixed
23.	COM DB didn’t get updated when a Badge
24.	Wireless Lock - Improved Threat Level speed using Group command, Daylight saving, Configuration Screen grid header sorting.
25.	Reflect Date Time Format from User PC (for en-US)
26.	Event Report - Advanced Search Error "Unable to cast Object of type"
27.	Events migration from CA3000 doesn't migrate Audit entries and Events
28.	Fixed other CA3000 migration issues including Scripting, Duplicate/Numeric  user field, some users shows full privilege, Events reports from archive database doesn’t show any records etc.
29.	In-list, Reports and Events grid and Regional date time fix for Asian/ Europe settings
30.	Schedule Changes activate all schedules
31.	Improved saving changes from personal when have thousands of Access groups and Badges
32.	Badges do not get downloaded when the system has a single panel - intermitted problem
33.	Web Report - fixed partition user "Object reference error"
34.	Web Edit Only privileges in Personnel screen, Access group doesn’t display reader > 8
35.	Web logout user while clicking multiple times on Save Button
36.	Web add a new badge or change access group or change badge number  doesn’t download to the panel without data download.
37.	Web personnel report is added
38.	When a badge has a Dedicated Access Group, editing the badge caused badge download to all related panels
39.	Desktop client requires local PC administrative privileges
40.	Web 'As UTC' item was selected in Time Format Dropdown, now 'As Local Time' item select
41.     Unable to edit PIV 75 bit badge format
42.     Universe Controller - "On Close" not working
43.     HCS - Ignore LAN internet connection check because some customers use only RS232 cables or network without internet
44.     Personnel - Unable to use keyboard tab to move from field to field in Personal
45.     Panel Screen - Right Click Show Events not showing any results.
46.     HCS - If a comport is failed, CPU usage of 99%.
47.     SP1 Install- Error ExecuteQuery: 'CONCAT' is not a recognized built-in function name during SP1 install. This occurs when you have MSQL 2008 R2          DB
48.     Expressions / Formula that combine fields in a Template.



Known Issues

1) Unable to use keyboard tab in Personnel to move from field to field in Custom created forms.
2) Superterm (Legacy) panels still requires V2 chip to run with CA4K.
3) Wireless Locks could send multiple Lock Start up events once they are power down or low battery.
4) SQL Server 2008R2 data migration  might throw nested error during migration, upgrading to SQL Server 2012 or SQL Server 2014 will solve the problem.
5) Superterm panel could send event append with (Agency), (OrgId) etc. Re download firmware should solve this problem.






********************************************************************
CardAccess 4K Software Readme		9/14/2017   Rev D 

Version 1.0.50.72		
------------------

Known Issues and Pre-Installation Notes: 

1. All versions of CardAccess 3000 must be uninstalled prior to performing a CardAccess 4K installation. 
2. Due to Windows permissions, the SQL Server Installation and Database Creation might fail if installed from a mapped drive. It is recommended to install SQL Server from a Local Folder or a DVD. 
3. Currently, only one panel per Com Port is supported while using the new non-polling mode feature.
4. Currently, Data Migration from CardAccess 3000 is supported on Version 2.9.88.276 through 2.11.77.295. During the Data Migration, the Database will be updated to 2.11.77 first and then migrated
   to CardAccess 4K.
5. During the Data Migration from CardAccess 3000, all user passwords and DVR server passwords will be replaced with a default password of "user@4k". This is due to the new "Strong Password" implementation.
   Note: after the Data Migration is completed, the DVR server password must be changed by user to match DVR.
6. If a Reader is configured for Escort and Napco Arm/Disarm at the same time, intermittent functionality might be experienced. It is recommended to use only one of these features at a time.
7. When creating new badges in Batch modify, it is not recommended to create over 10,000 badges at one time. The creation and download of over 10,000 badges may take a very long time to download. 
8. When enabling a secondary HCS, Scripting, Napco Integration, Wireless Locks services from a PC other than the PC they will be running on, it might be required to restart all Services on all computers. 
9. If the new 9 Digit PIN code selection is enabled in System Settings, old 4 Digit PIN numbers can be still used by entering the 4 digit pin code followed by the # sign. It is now required to enter a
    # sign at the end of all PIN code entries (1-9 digits in length).       
10. IBridge Napco Integration “Area Armed” and “Area Disarmed” events are not supported. Any type of Arm or Disarm will be reported as “Building Automation Arm” and “Building Automation Disarm”.
11. When using a badge with Napco permissions to arm/disarm areas from continental readers, it is required to include all areas of the reader to the Napco permission.
12. Language resource dlls in each language folders are sample dll's and are for demonstration purposes only. Proper Language translation could be accomplished using external resources and compiling
    particular resource dll using the ResourceEditor.exe in the tools folder.
13. Help files/documentation will continuously be updated after the final release. 
14. Video insight playback will play continuous in a loop and doesn’t support rewind.
15. Controlling Napco relays on Siemans panels are not supported.
16. Badge does not provide access at V1 Superterm (Legacy) – need to update Firmware chip to Ver 2.0
17. Multiple lock startup events possible if a reset lock exists within the system.
18. No vehicle tag violation event if driver badge presented without vehicle first.
19. Resource editor requires Microsoft Office for exporting languages.
20. Currently, in some cases, a full download is required for real-time changes in locks and panels.
21. Currently, adding more than 5 locks at a time using multiple lock addition can be inconsistent. 
22. Currently, Hardware license security keys may not work on certain PC hardware due HASP driver issue. 
23. By default Badge UseLimit Controller check box will be checked since in CA3000 by default all readers are enabled for Badge UseLimit.
24. During upgrade Insert DISK 1 error might occur if the upgrade is performed from different folder path than the original installation. Upgrade has to be done from the same path as the original installation.
25. SQL default instance uses 1433 TCP port for connection and this port number will be added to firewall rules during CA4K installation. However when SQL named instances are installed port numbers are assigned dynamically by SQL installer. User has to define a fixed TCP port and include that to firewall rule. (Port can be changed at Configuration Manager->Sql server network configuration->Protocols for <SERVER NAME> right click on TCP/IP -> properties and “IP Addresses” tab).
26. When using SQL express edition as the database server, in some cases HCS PC couldn’t connect to Host PC database using UNC name. Use IP address for database server name or modify hosts file and mappings of IP addresses to host names will solve the problem.
27. Each com server license will enable 256 comports regardless of how many com servers are configured in the system and will allow adding all available comports to a single com server.
28. In some cases if the messaging is disconnected, logout the GUI and login back will solve the problem. 
29. When Enable Global APB broadcast is checked in the system settings, APB update will be broadcast to all servers in the system else APB will be broadcast only between HCS and Wireless Socket Server running on the same PC.
30. Software License must be registered before activation.
31. CA4K uses date and Hour for activation and deactivation. Date has to be entered as mm/dd/yyyy 12AM to mm/dd+1/yyyy 12AM to allow a badge to be active 24 hour. It’s a change in design from CA3000. During data migration Badge, Access Group and Schedule expiration dates will be pumped by 1 day to adopt CA4K time schema.
32. Wireless Locks requires full download or Badge edit to enable a badge which was Deactivated by Access Group Expiration and wanted to activate again.
33. Acceleterm panels can't be connected in repeat mode with Single Door Controllers. This configuration requires new boot loader that will be released in Q3,2017.
34. During standard Data migration events and audit entries will be transferred only from source database not from any archive databases. CA3000 Archive database events and audit entries can be transferred separately.
35. Audit Log doesn’t support time zone, all audit log date time entries will be based on host time zone.
36. In Privileges screen some of the screens will be disabled for read only privileges.  This will be fixed in upcoming release.

37. Avigilon DVR doesn't show video on any Virtual Computers and Remote Desktop.
38. Avigilon DVR image capture might produce multiple image clips for each frame.
39. Schedule changes may not reflect actual schedule change status, if a Device and PC where it configured from are in two different time zones. But, Schedule changes will work as excepted.
40. Badge enabled checkbox in the personal screen may not reflect actual status, if the badge belongs to panels in multiple time zones and activate/deactivate times are used. But, badge activation and deactivation will work as excepted.


CardAccess 4K new features/Improvements (Features not available in the CardAccess 3000):

1. Panels can be configured for a non-polling mode (Supported panel types include Accelaterms, Accelerators, Super Two's and Turbo Superterms). 
2. Web interface now includes Wireless locks manual door control, relay configuration, Time schedule configuration, Access group configuration and additional reports (ideal for hosted services).
3. Web interface now supports real time events monitoring (Video and Map viewing currently not supported).
4. Video Integration now includes support for Video Insight and Exacq DVR's.
5. All applications are Windows Service applications except for CardAccess 4K graphical user interface (GUI) and other utility programs.
6. Panels configured for polling mode will be polled multithreaded to increase performance and reduce CPU usage. 
7. Time zone support added for wireless locks. (Currently Inactive)
8. iBridge based Napco integration for faster Arm/Disarm response. 
9. Dynamic Mapping now includes Napco integration support. 
10. A customizable System health (data) report has been added with the ability to add more Sql queries to XML schema.
11. Remote COM DB architecture to provide secondary COM servers (HCS) with improved performance.
12. A new and improved Database Design with a total of 5 databases. The new design includes the separation of Configuration and Events databases for greatly improved performance.    
13. Unlimited Threat Level configuration with the ability to assign Lockdown areas to Threat Level with system level allow or deny access.
14. Reporting OTL on a door may now be enabled/disabled in an Activity Link Program based on any event.
15. Door Bypass control may be Enabled/Disabled  via an Activity Link Program based on any event.
16. Reader Category Counters may be Incremented/Decremented via an Activity Link Program based on any event.
17. Category counter control is now available for Inputs. 
18. Added ability to configure Badge Activation/Expiration down to the hour.
19. Added ability to configure Access Groups Activation/Expiration down to the hour.   
20. Multiple credentials can now be assigned to one user.  
21. In Addition to a 4 Digit PIN code, a 9 Digit PIN code option has been added to provide support for a 1-9 digit PIN code. 
22. The addition of a Configurable Custom menu to launch external applications through CardAccess software. (Eg: Launching 3rd party badging application application)
23. Added ability to manually add a new gateway using the IP address of the gateway to allow communication between subnets.     
24. Developers/Integrators can now write their own GUI plug-in applications including Event processor support to capture events.(Currently inactive) 
25. Improved API for third party integration where user can register call back functions to receive events.
26. Improved Database partitioning for dealer hosted business model.
27. Overhaul of GUI for improved user experience.
28. Plug-in architecture implementation for ease of expandability.
29. Wireless Lock Gateways and Expander communications are supervised and create event when failed.
30. Panel and Wireless Lock Status can be viewed in Status screen of GUI, Mapping and Web.
32. Wireless Lock now supports time zone.
33. Web interface now supports Holiday’s configuration.
34. Web interface now supports Operator management configuration.
35. Web interface now supports Schedule Changes configuration.
36. Web interface now supports Status View for Panels and Wireless Locks.

37. Avigilon DVR integration is supported.
38. OTIS Elevator control integration is supported.
39. CA4K API extended to support 50+ functions including adding PIV/PIVI badges.
40. Microsoft SQL Server 2014 support added.
41. CA4K tested with Windows Server 2016.
42. Multiple Host Communication Services and Wireless Lock Servers.
43. Wireless Locks now support schedule changes for Readers.


--end--