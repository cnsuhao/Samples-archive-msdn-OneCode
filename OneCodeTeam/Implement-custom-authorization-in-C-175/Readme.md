# Implement custom authorization in C# (CSCustomAuthorization)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Security
## Topics
* Authentication
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:23:12
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : CSCustomAuthorization Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
The .NET Framework provides an extensible framework for authorizing and <br>
authenticating users.<br>
<br>
This sample demonstrates how to implement custom authentication and <br>
authorization by using classes that derive from IIdentity and IPrincipal. <br>
It also demonstrates how to override the application thread's default <br>
identity, the Windows identity, by setting CurrentPrincipal to an instance of <br>
the class that derives from IPrincipal. Based on credentials supplied by the <br>
user, we can provide access to resources based on that role. <br>
<br>
1. To create a class that implements IIdentity. An identity object represents<br>
the user on whose behalf the code is running.<br>
<br>
2. To create a class that implements IPrincipal. A principal object represents<br>
the security context of the user on whose behalf the code is running, <br>
including that user's identity (IIdentity) and any roles to which they belong.<br>
<br>
3. Collect user information to authenticate user. Then sets the thread's &nbsp;<br>
current principal for role-based security) <br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
Walkthrough: Implementing Custom Authentication and Authorization &nbsp;<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms172766.aspx">http://msdn.microsoft.com/en-us/library/ms172766.aspx</a><br>
<br>
Authentication and Authorization in the .NET Framework with Visual Basic &nbsp;<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms233780.aspx">http://msdn.microsoft.com/en-us/library/ms233780.aspx</a><br>
<br>
Role-Based Security<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/52kd59t0.aspx">http://msdn.microsoft.com/en-us/library/52kd59t0.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
