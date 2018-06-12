# C# app signs XML with digital signature (CSXmlDigitalSignature)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Security
* XML
## Topics
* Digital Signature
## IsPublished
* True
## ModifiedDate
* 2011-05-05 07:15:28
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : CSXmlDigitalSignature Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Digital Signatures:<br>
<br>
We take the original message and create a message digest by applying the hash<br>
algorithm on the message. The message digest is then encrypted using the <br>
private key known only to the private key owner (i.e., the sender).The signed<br>
message is formed by concatenating the original message with the unique <br>
digital signature and the public key that is associated with the private key <br>
that produced that signature. This entire signed message is then sent to the <br>
desired recipient.<br>
<br>
The received signed message is broken into its three components: the original<br>
message, the public key, and the digital signature. For comparison against <br>
the hash of the original message, it is necessary to compute the hash of the <br>
received message. If the message digest has not changed, then you can be very<br>
confident that the message itself has not changed. On the other hand, if the<br>
message digest has changed, then you can be quite certain that the received <br>
message has been corrupted or tampered with.<br>
<br>
CSDigitalSignature demonstrates how to use .NET built-in classes to implement <br>
Digital Signature for Xml documents.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
Use .NET built-in classes to implement XML digital signature.<br>
<br>
A. Creates a cryptographic provider object which supplies public/private<br>
&nbsp; key pair.<br>
B. Uses the private key to sign an entire XML document.<br>
C. Attaches the signature to the document in &lt;Signature&gt; element.<br>
D. Uses the public key to verify the digital signature<br>
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
