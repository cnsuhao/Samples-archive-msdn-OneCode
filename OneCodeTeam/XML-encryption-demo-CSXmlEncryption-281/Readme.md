# XML encryption demo (CSXmlEncryption)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Security
* XML
## Topics
* Encryption/Decryption
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:16:07
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : CSXmlEncryption Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
CSXmlEncryption demonstrates how to use .NET built-in classes to encrypt and <br>
decrypt Xml document:<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Use .NET built-in classes to encrypt and decrypt Xml document.<br>
<br>
A. Creates a cryptographic provider object which supplies public/private<br>
&nbsp; key pair.<br>
B. Creates a separate session key using symmetric algorithm.<br>
C. Uses the session key to encrypt the XML document and then uses public key<br>
&nbsp; of stepA f to encrypt the session key.<br>
D. Saves the encrypted AES session key and the encrypted XML data to the XML<br>
&nbsp; document within a new &lt;EncryptedData&gt; element.<br>
E. To decrypt the XML element, we retrieve the private key of stepA, use it <br>
&nbsp; to decrypt the session key, and then use the session key to decrypt the <br>
&nbsp; document.<br>
<br>
</p>
<h3>References:</h3>
<p style="font-family:Courier New"><br>
.NET Security and Cryptography <br>
<a target="_blank" href="http://www.amazon.com/Security-Cryptography-Integrated-Object-Innovations/dp/013100851X">http://www.amazon.com/Security-Cryptography-Integrated-Object-Innovations/dp/013100851X</a><br>
<br>
RSACryptoServiceProvider Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider.aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.rsacryptoserviceprovider.aspx</a><br>
<br>
Cryptography in .NET<br>
<a target="_blank" href="http://www.developer.com/net/net/article.php/1548761">http://www.developer.com/net/net/article.php/1548761</a><br>
<br>
DSACryptoServiceProvider Class<br>
<a target="_blank" href="http://msdn.microsoft.com/en-us/library/system.security.cryptography.dsacryptoserviceprovider.aspx">http://msdn.microsoft.com/en-us/library/system.security.cryptography.dsacryptoserviceprovider.aspx</a><br>
<br>
Cryptography in Microsoft.NET Part I: Encryption<br>
<a target="_blank" href="http://www.c-sharpcorner.com/UploadFile/gsparamasivam/CryptEncryption11282005061028AM/CryptEncryption.aspx">http://www.c-sharpcorner.com/UploadFile/gsparamasivam/CryptEncryption11282005061028AM/CryptEncryption.aspx</a><br>
<br>
Cryptography in Microsoft.NET Part II: Digital Envelop and Digital Signatures<br>
<a target="_blank" href="http://www.c-sharpcorner.com/UploadFile/Gowri%20S%20Paramasivam/Cryptography211242005003308AM/Cryptography2.aspx">http://www.c-sharpcorner.com/UploadFile/Gowri%20S%20Paramasivam/Cryptography211242005003308AM/Cryptography2.aspx</a><br>
<br>
<br>
</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo">
</a></div>
