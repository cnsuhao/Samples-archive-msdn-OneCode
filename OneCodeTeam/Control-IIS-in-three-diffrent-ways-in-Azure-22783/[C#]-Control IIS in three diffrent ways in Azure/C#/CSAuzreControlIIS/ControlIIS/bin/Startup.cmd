%systemroot%\system32\inetsrv\appcmd.exe set config  -section:system.applicationHost/log /centralW3CLogFile.logExtFileFlags:"Date, SiteName"  /commit:apphost
