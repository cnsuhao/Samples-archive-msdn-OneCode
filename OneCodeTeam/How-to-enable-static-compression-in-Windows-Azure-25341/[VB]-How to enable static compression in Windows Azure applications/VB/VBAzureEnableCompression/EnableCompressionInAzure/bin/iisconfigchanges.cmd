%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+"staticTypes.[mimeType='application/x-javascript',enabled='True']" /commit:apphost
%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+"staticTypes.[mimeType='text/javascript',enabled='True']" /commit:apphost
%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+"staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.wordprocessingml.document',enabled='True']" /commit:apphost
%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+"staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',enabled='True']" /commit:apphost
%windir%\system32\inetsrv\appcmd.exe set config -section:system.webServer/httpCompression /+"staticTypes.[mimeType='application/vnd.openxmlformats-officedocument.presentationml.presentation',enabled='True']" /commit:apphost
%windir%\system32\inetsrv\appcmd.exe set config -section:serverruntime /frequentHitThreshold:1 /commit:APPHOST
exit /b 0