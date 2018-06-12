How to list the group membership of user?

Introduction
This sample lists the group membership of the user, similar to what command "whoami" does. This sample can also list the group membership for the user when the machine is not connected. It gets the details from cache.

Building the Sample
This sample is built using Visual Studio 2012. There are no extra steps to build the sample. 

Running the Sample
After building the sample, you can use the exe without any arguments.


Using the Code
The sample code opens the process token of current process using OpenProcessToken() and then uses GetTokenInformation() with TokenGroups. 
With the Sids for the groups received, we need to convert them to readable form. Here LookupAccountSid() is used. 

For disconnected state, the sample gets the information from local cache. Ignore error 1789 to continue the sample in disconnected state. 
 
You may compare the results with "whoami /all" output for same user. 

More Information
http://msdn.microsoft.com/en-us/library/windows/desktop/aa379295(v=vs.85).aspx
http://msdn.microsoft.com/en-us/library/windows/desktop/aa446671(v=vs.85).aspx
http://msdn.microsoft.com/en-us/library/windows/desktop/aa375213(v=vs.85).aspx
http://msdn.microsoft.com/en-us/library/windows/desktop/aa379166(v=vs.85).aspx
