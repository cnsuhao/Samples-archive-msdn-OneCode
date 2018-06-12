# Encrypt and decrypt ASP.NET web config
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* Security
## IsPublished
* True
## ModifiedDate
* 2013-07-03 11:03:48
## Description

<h1>Use RSA encryption algorithm API to encrypt and decrypt Configuration section. (VBASPNETEncryptAndDecryptConfiguration)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">This sample shows how to use RSA encryption algorithm API to encrypt and decrypt configuration section in order to protect the sensitive information from interception or hijack in ASP.NET web application.<br>
This project contains two snippets. The First One demonstrates how to use RSA provider and RSA container to encrypt and decrypt some words or values in web application. The purpose of first snippet is to let us know the overview of RSA mechanism. Second one
 shows how to use RSA configuration provider to encrypt and decrypt configuration section in web.config.</p>
<h2>Building the Sample</h2>
<p class="MsoNormal">If your application hasn't web.config, please create one. And also specify some section such as appSetting, connectSetting in this web.config.<br>
How to create Web.config in application: <br>
<a href="http://support.microsoft.com/kb/815179">http://support.microsoft.com/kb/815179</a><br>
Working with Web.config Files: <br>
<a href="http://msdn.microsoft.com/en-us/library/ms460914.aspx">http://msdn.microsoft.com/en-us/library/ms460914.aspx</a><span style="">
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Step 1: Open the VBASPNETEncryptAndDecryptConfiguration.sln.<br>
Step 2: Right click the CommonEncryption.aspx or ConfigurationEncryption.aspx. Choose<br>
<span style="">&nbsp;</span>&quot;View in browser&quot; option in menu.<br>
CommonEncrytion:<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>1) Enter some values in the top textbox. Click the &quot;encrypt it&quot; button below this textbox. You will observe the RSA encrypt result string in the multiline textbox.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91608/1/image.png" alt="" width="575" height="120" align="middle">
</span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>2) Then you can click another button in this page named &quot;decrypt it&quot;.<span style="">&nbsp;
</span>And the decrypt result will show on next multiline textbox. You will find that this string is equal to the value which you first entered in the top textbox.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91609/1/image.png" alt="" width="575" height="77" align="middle">
</span></p>
<p class="MsoNormal"></p>
<p class="MsoNormal"><span style="">&nbsp; </span>ConfigurationEncryption:<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>1) Choose a configuration section in dropdown list.<br>
<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>2) Click &quot;encrypt it&quot; button in below. If the encryption successes, then open<span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>web.config file, you will observe the specific section is encrypted and is replaced by some RSA data section.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/91610/1/image.png" alt="" width="394" height="86" align="middle">
</span><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></p>
<p class="MsoNormal"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>3) If you want to recover this section to plain text. Click &quot;decrypt it&quot; button and check web.config again.<br>
<span style=""><img src="/site/view/file/91611/1/image.png" alt="" width="373" height="103" align="middle">
</span><br>
<b style=""><span style="">Note</span></b><span style="">: If you are running this application from the file system, when you close the application, Visual Studio will display a dialog with the message of &quot;The file has been modified outside the editor.
 Do you want to reload it?&quot; Click yes and <span style="">&nbsp;&nbsp;&nbsp;&nbsp; </span>then view the web.config.</span><br>
Step 3: Validation is complete.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Step 1: CommonEncrytion:</p>
<p class="MsoNormal">1. Create a new instance of a CspParameters class and pass the name that you want to call the key container to the CspParameters.KeyContainerName field.<br>
2. Create a new RSACryptoServiceProvider instance and pass CsParameter to its' constructor.<br>
3. Create byte arrays to hold original, encrypted, and decrypted data.<br>
4. Pass the byte arrays data to ENCRYPT method and get the result of encrypt byte arrays.<br>
5. Convert this byte array data to its equivalent string by using Convert.ToBase64String and display it in multiline textbox.</p>
<p class="MsoNormal">ConfigurationEncryption: <br>
1. Get the dropdown list selected value to assign which configuration section to encrypt or decrypt.<br>
2. Open the web.config in this web application. <br>
3. Find the specific section and use RSAProtectedConfigurationProvider to encrypt or decrypt it.<br>
4. If success, this section will be encrypted by RSA and replaced by some RSA section in web.config.</p>
<p class="MsoNormal"><b style="">Note</b>: If you store sensitive data in any of the following configuration sections, you cannot encrypt it by using a protected configuration provider and the Aspnet_regiis.exe tool:
<br>
<b style="">&lt;processModel&gt;<br>
&lt;runtime&gt;<br>
&lt;mscorlib&gt;<br>
&lt;startup&gt;<br>
&lt;system.runtime.remoting&gt;<br>
&lt;configProtectedData&gt;<br>
&lt;satelliteassemblies&gt;<br>
&lt;cryptographySettings&gt;<br>
&lt;cryptoNameMapping&gt;<br>
&lt;cryptoClasses&gt;</b></p>
<p class="MsoNormal">The RSAProtectedConfigurationProvider supports machine-level and user-level key containers<br>
for key storage. In this project, we all use machine-level.<br>
Understanding Machine-Level and User-Level RSA Key Containers: <br>
<a href="http://msdn.microsoft.com/en-us/library/f5cs0acs.aspx">http://msdn.microsoft.com/en-us/library/f5cs0acs.aspx</a>.<br>
Without use RSA provider and API, we can also use Aspnet_regiis.exe tool to encrypt and decrypt section.<br>
<a href="http://msdn.microsoft.com/en-us/library/ms998283.aspx">http://msdn.microsoft.com/en-us/library/ms998283.aspx</a>.<br>
Step <span style="">5</span>: Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal">RSACryptoServiceProvider<br>
<a href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider(VS.80).aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider(VS.80).aspx</a><br>
CspParameters<br>
<a href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.cspparameters(VS.80).aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.cspparameters(VS.80).aspx</a><br>
ConfigurationSection<br>
<a href="http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.configurationsection.aspx</a><br>
SectionInformation.ProtectSection <br>
<a href="http://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.protectsection.aspx">http://msdn.microsoft.com/en-us/library/system.configuration.sectioninformation.protectsection.aspx</a><br style="">
<br style="">
<span style=""></span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
