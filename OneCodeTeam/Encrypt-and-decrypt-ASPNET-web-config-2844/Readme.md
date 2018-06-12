# Encrypt and decrypt ASP.NET web config (VBASPNETEncryptAndDecryptConfiguration)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Encryption/Decryption
## IsPublished
* True
## ModifiedDate
* 2011-05-05 09:39:31
## Description

<p style="font-family:Courier New"></p>
<h2>ASP.NET APPLICATION : VBASPNETEncryptAndDecryptConfiguration Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
This sample shows how to use RSA encryption algorithm API to encrypt and decrypt <br>
configuration section in order to protect the sensitive information from interception<br>
or hijack in ASP.NET web application.<br>
<br>
This project contains two snippets. The First One demonstrates how to use RSA provider
<br>
and RSA container to encrypt and decrypt some words or values in web application.<br>
the purpose of first snippet is to let us know the overview of RSA mechanism.<br>
Second one shows how to use RSA configuration provider to encrypt and decrypt<br>
configuration section in web.config.<br>
</p>
<h3>Prerequisites:</h3>
<p style="font-family:Courier New"><br>
If your application hasn't web.config, please create one. And also specify some <br>
section such as appSetting, connectSetting in this web.config.<br>
<br>
How to create Web.config in application:<br>
<a target="_blank" href="http://support.microsoft.com/kb/815179/">http://support.microsoft.com/kb/815179/</a><br>
<br>
Working with Web.config Files:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms460914.aspx">http://msdn.microsoft.com/en-us/library/ms460914.aspx</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New">Start this project:<br>
<br>
1.launch VBASPNETEncryptAndDecryptConfiguration.sln as administrator.<br>
<br>
<br>
2.Right click the CommonEncryption.aspx or ConfigurationEncryption.aspx. Choose<br>
&quot;view in browser&quot; option in menu.<br>
<br>
&nbsp;CommonEncrytion:<br>
&nbsp;&nbsp;&nbsp;&nbsp;1) Enter some values in the top textbox. click the &quot;encrypt it&quot; button
<br>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; below this textbox. You will observe the RSA encrypt result string in
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; the multiLine textbox.<br>
&nbsp;&nbsp;&nbsp;&nbsp;2) Then you can click the another button in this page named &quot;decrypt it&quot;.<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; And the decrypt result will show on next multiline textbox. You will
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; find that this string is equal to the value which you first entered in<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; the top textbox.<br>
<br>
&nbsp;ConfigurationEncryption:<br>
&nbsp;&nbsp;&nbsp;&nbsp;1) Choose a configuration section in dropdownlist.<br>
&nbsp;&nbsp;&nbsp;&nbsp;2) Click &quot;encrypt it&quot; button in below. if the encryption successed, then open
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; web.config file, you will observe the specific section is &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; encrypted and is replaced by some RSA data section.<br>
&nbsp; &nbsp; &nbsp; <br>
&nbsp; &nbsp; &nbsp; &nbsp;3) If you want to recover this section to plain text. Click &quot;decrypt it&quot;
<br>
&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; button and check web.config again.<br>
<br>
&nbsp;Note: If you are running this application from the file system, when you close the<br>
&nbsp;&nbsp;&nbsp;&nbsp;application, Visual Studio will display a dialog with the message of &quot;The file
<br>
&nbsp;&nbsp;&nbsp;&nbsp;has been modified outside the editor. Do you want to reload it?&quot; Click yes and
<br>
&nbsp;&nbsp;&nbsp;&nbsp;then view the web.config.<br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New">Code Logic:<br>
<br>
CommonEncrytion:<br>
<br>
1. Create a new instance of a CspParameters class and pass the name that you want to call
<br>
the key container to the CspParameters.KeyContainerName field.<br>
2. Create a new RSACryptoServiceProvider instance and pass CsParameter to its' constructor.<br>
3. Create byte arrays to hold original, encrypted, and decrypted data.<br>
4. Pass the byte arrays data to ENCRYPT mehotd and get the result of encrypt byte arrays.<br>
5. Convert this byte array data to its equivalent string by using Convert.ToBase64String
<br>
and display it in multiline textbox.<br>
<br>
ConfigurationEncryption:<br>
<br>
1. Get the dropdownlist selected value to assign which configuration section to encrypt
<br>
or decrypt.<br>
2. Open the web.config in this web application. <br>
3. Find the specific section and use RSAProtectedConfigurationProvider to encrypt or
<br>
decrypt it.<br>
4. If success, this section will be encrypted by RSA and replaced by soem RSA section
<br>
in web.config.<br>
<br>
<br>
Note: If you store sensitive data in any of the following configuration sections, you cannot<br>
encrypt it by using a protected configuration provider and the Aspnet_regiis.exe tool:<br>
<br>
&lt;processModel&gt;<br>
&lt;runtime&gt;<br>
&lt;mscorlib&gt;<br>
&lt;startup&gt;<br>
&lt;system.runtime.remoting&gt;<br>
&lt;configProtectedData&gt;<br>
&lt;satelliteassemblies&gt;<br>
&lt;cryptographySettings&gt;<br>
&lt;cryptoNameMapping&gt;<br>
&lt;cryptoClasses&gt;<br>
<br>
The RSAProtectedConfigurationProvider supports machine-level and user-level key containers<br>
for key storage. In this project, we all use machine-level.<br>
<br>
Understanding Machine-Level and User-Level RSA Key Containers:<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/f5cs0acs.aspx">http://msdn.microsoft.com/en-us/library/f5cs0acs.aspx</a><br>
<br>
Without use RSA provider and API, we can also use Aspnet_regiis.exe tool to encrypt and decrypt section.<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms998283.aspx">http://msdn.microsoft.com/en-us/library/ms998283.aspx</a><br>
</p>
<h3></h3>
<p style="font-family:Courier New">References:<br>
<br>
RSACryptoServiceProvider<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider(VS.80).aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider(VS.80).aspx</a><br>
<br>
CspParameters<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.cspparameters(VS.80).aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.cspparameters(VS.80).aspx</a><br>
<br>
<br>
ConfigurationSection<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx</a><br>
<br>
SectionInformation.ProtectSection <br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.protectsection.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.protectsection.aspx</a><br>
<br>
</p>
<h3></h3>
<p style="font-family:Courier New"><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
