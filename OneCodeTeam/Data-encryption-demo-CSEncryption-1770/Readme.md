# Data encryption demo (CSEncryption)
## Requires
* Visual Studio 2008
## License
* Apache License, Version 2.0
## Technologies
* Windows Security
## Topics
* Encryption/Decryption
## IsPublished
* True
## ModifiedDate
* 2011-05-05 05:29:17
## Description

<p style="font-family:Courier New"></p>
<h2>WINDOWS APPLICATION : CSEncryption Project Overview</h2>
<p style="font-family:Courier New"></p>
<h3>Use:</h3>
<p style="font-family:Courier New"><br>
Cryptography is used to protect data and has many valuable uses. It can <br>
protect data from being viewed, modified, or to ensure the integrity <br>
from the originator. Cryptography can be used as a mechanism to provide secure<br>
communication over an unsecured network, such as the Internet, by encrypting <br>
data, sending it across the network in the encrypted state, and then the <br>
decrypting the data on the receiving end. Encryption can also be used as an<br>
additional security mechanism to further protect data such as passwords <br>
stored in a database to prevent them from being human readable or <br>
understandable. There are two types of cryptography: asymmetric algorithm <br>
and symmetric algorithm.<br>
<br>
<br>
Symmetric algorithms:<br>
A symmetric algorithm is a cipher in which encryption and decryption use the <br>
same key or keys that are mathematically related to one another in such a way<br>
that it is easy to compute one key from knowledge of the other, which is <br>
effectively a single key.Some symmetric algorithms commonly used are DES,<br>
TripleDES, RC2,RijnDael.The following private-key algorithms are available in<br>
the .NET Framework. <br>
<br>
Data Encryption Standard (DES) &nbsp;<br>
RC2 <br>
TripleDES <br>
Rijndael &nbsp;<br>
<br>
<br>
Asymmetric algorithms:<br>
It uses a public and private key pair to encrypt and decrypt data. The public<br>
key is made available to anyone and is used to encrypt data to be sent to the <br>
owner of the private key. The private key, as the name implies, is kept private <br>
. The private key is used to decrypt the data and will only work if the correct<br>
public key was used when encrypting the data. The private key is the only key <br>
that will allow data encrypted with the public key to be decrypted. The <br>
following public-key algorithms are available for use in the .NET Framework:<br>
<br>
Digital Signature Algorithm (DSA) <br>
RSA <br>
<br>
Hashing Algorithms<br>
A hash is a function that maps an arbitrary-length binary data input to a <br>
small, fixed-length binary data output, often referred to as a message digest<br>
or finger print.A good hash function should have the property that it is a very<br>
low probability that two distinct inputs collide, producing the same hash <br>
value result.The .NET Framework provides support for the following hash <br>
algorithms:<br>
<br>
HMACSHA1 <br>
MACTripleDES <br>
MD5CryptoServiceProvider <br>
SHA1Managed <br>
SHA256Managed <br>
SHA384Managed <br>
SHA512Managed <br>
<br>
<br>
CSEncryption demonstrates how to use .NET built-in classes to encrypt and <br>
decrypt data.<br>
<br>
</p>
<h3>Code Logic:</h3>
<p style="font-family:Courier New"><br>
1. Use symmetric algorithm to encrypt and decrypt data in .NET.<br>
<br>
A. Create the secret key, Initial vector, padding mode, cipher mode for a <br>
&nbsp; cryptographic provider object which is used later to encrypt or decrypt <br>
&nbsp; data<br>
B. Get plaintext as byte array<br>
C. Create one symmetric algorithm provider which is initialized by parameters<br>
&nbsp; from stepA. Using this object encrypts data via same secret key which is <br>
&nbsp; also used in decryption and gets ciphered data.<br>
D. Create one symmetric algorithm provider which is initialized by parameters<br>
&nbsp; from stepA. Using this object encrypts data via same secret key and gets <br>
&nbsp; ciphered data.<br>
<br>
2. Use asymmetric algorithm to encrypt and decrypt data in .NET.<br>
<br>
A. Create a cryptographic provider object to get public key and private key.<br>
&nbsp; The private key is used to decrypt data. The public key is used to encrypt<br>
&nbsp; data.<br>
B. Get plaintext as byte array<br>
C. Create one asymmetric algorithm provider which is initialized by public key<br>
&nbsp; from stepA. Using this object encrypts data via public key and gets <br>
&nbsp; ciphered data.<br>
D. Create one symmetric algorithm provider which is initialized by public key<br>
&nbsp; and private key from stepA. Using this object encrypts data and gets <br>
&nbsp; ciphered data.<br>
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
