# How to use ASHWID to implement per-device logic safely
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows 8
## Topics
* Windows 8 App with Cloud Service
## IsPublished
* True
## ModifiedDate
* 2013-04-16 10:22:49
## Description

<p style="font-family:Courier New">&nbsp;<a href="http://www.microsoft.com/click/services/Redirect2.ashx?CR_CC=200144420" target="_blank"><img id="79969" src="http://i1.code.msdn.s-msft.com/csazurebingmaps-bab92df1/image/file/79969/1/120x90_azure_web_en_us.jpg" alt="" width="360" height="90"></a></p>
<h1>Use App Specific Hardware ID (ASHWID) to implement per-device logic in a Windows Store app (CSWindowsStoreAppASHWID)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span>The sample demonstrates how to use App Specific Hardware ID (ASHWID) to uniquely identify a device and go step further to implement a per-device logic in the Windows Store app.<span>&nbsp;
</span>You can find the answers for all the following questions in the code sample:
</span></p>
<p class="MsoListBulletCxSpFirst"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>How to generate the ASHWID in a Windows Store app? </span>
</p>
<p class="MsoListBulletCxSpMiddle"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>How to authenticate the ASHWID in the cloud? </span></p>
<p class="MsoListBulletCxSpLast"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>How to account for the hardware drift and process the ASHWID in the cloud?
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span>To build this sample, you must reference the Security.dll authored by Microsoft CLR Security team.<span>&nbsp;
</span>Security.dll extends the security APIs shipped with the .NET Framework to provide additional functionality with the Code Access Security system in the .NET Framework.<span>&nbsp;&nbsp;
</span>By leveraging the CLR Security API in Security.dll, the attached cloud side codes can use PSS padding and validate the trustworthiness and genuine of the Hardware ID uploaded from the client.
</span></p>
<p class="MsoNormal"><span>The CLR Security assemblies are available for download from the CLR Security
<span class="SpellE">CodePlex</span> Site:</span> <a href="http://clrsecurity.codeplex.com/">
Download the CLR Security assemblies here</a><span>. </span></p>
<p class="MsoNormal"><strong><span>Note</span></strong><span>: the Security.dll has already been included in the code samples attached.<span>&nbsp;&nbsp;&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-right:22.0pt; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open<span> this sample solution in VS2012 on Win8 machine, </span>
you will see two projects in a Client-Server model.<span>&nbsp; </span>The client codes locates in CSWindowsStoreAppDeviceClient project while the server codes in CSWindowsStoreAppDeviceService project.<span>&nbsp;
</span>In this demonstration, you will deploy both client and server on the same Windows 8 machine.<span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>One of the Service's responsibility is to verify the trustworthiness of the Hardware ID value uploaded from the client Windows Store app.<span>&nbsp;&nbsp;&nbsp;
</span>For the purpose of the genuine verification, codes assumes </span>that the &quot;Microsoft Assurance Designation Root 2011&quot; root certificate is trusted on the server side.<span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt">Please <strong>
import the certificate &quot;Microsoft Assurance Designation Root 2011&quot; to the trusted root certification store</strong> on the server side as below illustration depicts.<span>&nbsp;
</span>(Note: You could find the certificate DER encoded binary <strong>MADR2011.cer</strong> under the project root folder of
<span class="SpellE">CSWindowsStoreAppDeviceService</span>.)<span> </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span><img src="/site/view/file/78822/1/image.png" alt="" width="549" height="535" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Launch the <span class="SpellE">CSWindowsStoreAppDeviceService</span> in VS2012 as following:<span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click the CSWin8DeviceService in the Solution Explorer<span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Choose &quot;Set as Start Project&quot; in the pop-up context menu.<span>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>On the VS main menu Debug, choose &quot;Start without Debugging&quot; and you will see the
<span class="SpellE">WebApi</span> Service launched on the local port 12345 as below:
</span></p>
<p class="MsoNormal" style="margin-right:22.0pt; text-indent:.25in"><span><img src="/site/view/file/78823/1/image.png" alt="" width="576" height="350" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Start the Windows Store client by following: </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:1.0in; text-indent:-.25in">
<span><span>a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click the CSWindowsStoreAppDeviceClient in the Solution Explorer<span>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:1.0in; text-indent:-.25in">
<span><span>b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Choose &quot;Set as Start Project&quot; in the pop-up context menu.<span>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:1.0in; text-indent:-.25in">
<span><span>c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Press F5 to run it. </span></p>
<p class="MsoNormal" style="text-indent:.25in"><span><img src="/site/view/file/78824/1/image.png" alt="" width="595" height="379" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Click the &quot;Register Device on Cloud&quot; button to register the unique Hardware ID to the service.<span>&nbsp;&nbsp;
</span>The step will upload the Hardware ID from the client to the server and store it as the base Hardware Id with the binding Customer ID in the backend database.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>You will see from the Output information, a unique ASHWID is generated in byte stream and uploaded to the server.<span>&nbsp;
</span>Below is one of the sample ASHWIDs from one of the Windows 8 machine: </span>
</p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>03-00-0A-51-05-00-BC-0C-<strong>05-00-AD-35</strong>-05-00-D4-E1-06-00-01-00-04-00-FE-15-04-00-9E-2B-04-00-30-3C-01-00-74-F2-02-00-D8-78-09-00-78-D5
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast">Note: The byte stream consists of multiple groups of four bytes. The first two bytes contain the type of the component and the next two bytes contain the value. The table below identifies the type of each component:</p>
<table class="MsoTable15Grid1Light" border="1" cellspacing="0" cellpadding="0" style="margin-left:41.0pt; border-collapse:collapse; border:none">
<tbody>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-bottom:solid #666666 1.5pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>Byte Stream representation </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:solid #999999 1.0pt; border-left:none; border-bottom:solid #666666 1.5pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>Component </strong></p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>01-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Processor</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>02-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Memory</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>03-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Disk Device</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>04-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Network Adapter</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>05-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Audio Adapter</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>06-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Docking Station</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>07-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Mobile Broadband</p>
</td>
</tr>
<tr>
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing"><strong>08-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Bluetooth</p>
</td>
</tr>
<tr style="height:2.5pt">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt; height:2.5pt">
<p class="MsoNoSpacing"><strong>09-00 </strong></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt; height:2.5pt">
<p class="MsoNoSpacing">System BIOS</p>
</td>
</tr>
</tbody>
</table>
<p class="MsoListParagraphCxSpFirst">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Do a slight change on the components of the device, for example, unplug your USB headset, and try to verify the device on the server by click the &quot;Verify Device on Cloud&quot; button.<span>&nbsp;&nbsp;
</span>You will retrieve a new byte stream which four bytes indicates one Audio Adapter bolded in step #6 is missing.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>03-00-0A-51-05-00-BC-0C-05-00-D4-E1-06-00-01-00-04-00-FE-15-04-00-9E-2B-04-00-30-3C-01-00-74-F2-02-00-D8-78-09-00-78-D5
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast"><span>The slight change mentioned here is referred as &quot;<strong>hardware drift</strong>&quot;.<span>&nbsp;
</span></span>The ASHWID from a given device may change for a variety of reasons depending on when it is queried:<span>
</span></p>
<p class="MsoListBulletCxSpFirst" style="margin-left:.75in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>User may temporarily connect peripherals to their devices that add to the list of components.
</span></p>
<p class="MsoListBulletCxSpMiddle" style="margin-left:.75in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Power management devices (for slates and devices running on ARM processors) might switch off certain hardware components to conserve battery life.
</span></p>
<p class="MsoListBulletCxSpLast" style="margin-left:.5in; text-indent:0in">One of the ways the app can account for hardware drift is to compute a score by attaching weights to each of the returned component IDs based on its business logic. The computed score
 must pass the threshold set by the cloud component to be identified as the same device.</p>
<p class="MsoListParagraphCxSpFirst">You could refer to the codes of <strong>bullet #6 &quot;How to deal with the device difference by setting a threshold for the same device?&quot; in the &quot;Using the Code&quot; section</strong> to get some idea how to set the threshold
 based on your business logic.<span> </span></p>
<p class="MsoListParagraphCxSpMiddle"><span>&nbsp;</span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span><span>8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>In the sample code attached, the threshold score is set to zero.<span>&nbsp;&nbsp;
</span>That means no matter what kind of minor hardware change, you will get an alert from the cloud as following:
</span></p>
<p class="MsoNormal" style="margin-left:.25in"><span><img src="/site/view/file/78825/1/image.png" alt="" width="595" height="96" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span><span>9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>The main page will finally be shown as following after you unplug one USB headset from the device you tested:
</span></p>
<p class="MsoListBullet"><span><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span><img src="/site/view/file/78826/1/image.png" alt="" width="595" height="379" align="middle">
</span><span>&nbsp;</span></p>
<p class="MsoNormal"><span>The code sample provides the following reusable functions:
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><strong><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong><span>How to generate the ASHWID in a Windows Store app client?
</span></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
HardwareToken packageSpecificToken = HardwareIdentification.GetPackageSpecificToken(nonce);
var hwId = new Ashwid
&nbsp; {
&nbsp;&nbsp;&nbsp; CustomerId = _customerId,
&nbsp;&nbsp;&nbsp; HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
&nbsp;&nbsp;&nbsp; Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
&nbsp;&nbsp;&nbsp; Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature),
&nbsp; };

</pre>
<pre id="codePreview" class="csharp">// Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
HardwareToken packageSpecificToken = HardwareIdentification.GetPackageSpecificToken(nonce);
var hwId = new Ashwid
&nbsp; {
&nbsp;&nbsp;&nbsp; CustomerId = _customerId,
&nbsp;&nbsp;&nbsp; HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
&nbsp;&nbsp;&nbsp; Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
&nbsp;&nbsp;&nbsp; Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature),
&nbsp; };

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoListParagraph" style="text-indent:-.25in"><strong><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>How to get a random nonce in a Json HttpRequest ?
</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private IBuffer GetNonce()
{
&nbsp;&nbsp;&nbsp; try
&nbsp; &nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; using (var client = new HttpClient())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Add a unique AgentId to the request header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use JSON request to get the nonce from the cloud side.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.BaseAddress = new Uri(ServiceBaseUri);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string content = client.GetStringAsync(GetNonceApiUriPath).Result;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var stream = new MemoryStream(Encoding.Unicode.GetBytes(content));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Deserialize the OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var serializer = new DataContractJsonSerializer(typeof(OneTimePassword));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var otpObj = serializer.ReadObject(stream) as OneTimePassword;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (otpObj != null &amp;&amp; !string.IsNullOrEmpty(otpObj.Nonce))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8);
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (HttpRequestException hReqEx)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (new MessageDialog(String.Format(&quot;HttpRequest error: {0}&quot;, hReqEx.Message))).ShowAsync();
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (new MessageDialog(String.Format(&quot;HttpRequest error: {0}&quot;, ex.Message))).ShowAsync();
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return null;
}

</pre>
<pre id="codePreview" class="csharp">private IBuffer GetNonce()
{
&nbsp;&nbsp;&nbsp; try
&nbsp; &nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; using (var client = new HttpClient())
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Add a unique AgentId to the request header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use JSON request to get the nonce from the cloud side.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.BaseAddress = new Uri(ServiceBaseUri);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string content = client.GetStringAsync(GetNonceApiUriPath).Result;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var stream = new MemoryStream(Encoding.Unicode.GetBytes(content));


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Deserialize the OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var serializer = new DataContractJsonSerializer(typeof(OneTimePassword));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var otpObj = serializer.ReadObject(stream) as OneTimePassword;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (otpObj != null &amp;&amp; !string.IsNullOrEmpty(otpObj.Nonce))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8);
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (HttpRequestException hReqEx)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (new MessageDialog(String.Format(&quot;HttpRequest error: {0}&quot;, hReqEx.Message))).ShowAsync();
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (new MessageDialog(String.Format(&quot;HttpRequest error: {0}&quot;, ex.Message))).ShowAsync();
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return null;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><strong><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>How to generate the One Time Password nonce in the cloud by using ASP.NET MVC API controller with Entity Framework?
</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// GET api/OneTimePassword
/// Get OTP nonce from the cloud
/// &lt;/summary&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public OneTimePassword GetOneTimePasswords()
{
&nbsp;&nbsp;&nbsp; var userAgent = Request.Headers.UserAgent.ToString();
&nbsp;&nbsp;&nbsp; if (!userAgent.StartsWith(&quot;AllInOneCode-&quot;))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return null;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length);
&nbsp;&nbsp;&nbsp; var userAgentGuid = new Guid(userAgent);


&nbsp;&nbsp;&nbsp; OneTimePassword otp = null;
&nbsp;&nbsp;&nbsp; if (ModelState.IsValid)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = db.OneTimePasswords.Find(userAgentGuid);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (otp != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Found the original otp in the database, renew the expired time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Entry(otp).State = EntityState.Modified;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = new OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AgentId = new Guid(userAgent),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Password will be expired in one minute by default.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExpiredTime = DateTime.UtcNow.AddMinutes(1),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Nonce will be generated randomly in a substring of GUID value.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nonce = Guid.NewGuid().ToString().Substring(0, 6)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.OneTimePasswords.Add(otp);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (DbUpdateConcurrencyException duce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.StackTrace);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return otp;
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// GET api/OneTimePassword
/// Get OTP nonce from the cloud
/// &lt;/summary&gt;
/// &lt;returns&gt;&lt;/returns&gt;
public OneTimePassword GetOneTimePasswords()
{
&nbsp;&nbsp;&nbsp; var userAgent = Request.Headers.UserAgent.ToString();
&nbsp;&nbsp;&nbsp; if (!userAgent.StartsWith(&quot;AllInOneCode-&quot;))
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return null;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length);
&nbsp;&nbsp;&nbsp; var userAgentGuid = new Guid(userAgent);


&nbsp;&nbsp;&nbsp; OneTimePassword otp = null;
&nbsp;&nbsp;&nbsp; if (ModelState.IsValid)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = db.OneTimePasswords.Find(userAgentGuid);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (otp != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Found the original otp in the database, renew the expired time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.Entry(otp).State = EntityState.Modified;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = new OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AgentId = new Guid(userAgent),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Password will be expired in one minute by default.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExpiredTime = DateTime.UtcNow.AddMinutes(1),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Nonce will be generated randomly in a substring of GUID value.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nonce = Guid.NewGuid().ToString().Substring(0, 6)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.OneTimePasswords.Add(otp);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; catch (DbUpdateConcurrencyException duce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.StackTrace);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return otp;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><strong><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>How to validate the nonce in one API controller?
</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
/// &lt;/summary&gt;
private bool NonceIsValid
{
&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var userAgent = Request.Headers.UserAgent.ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (userAgent.StartsWith(&quot;AllInOneCode-&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var userAgentGuid = new Guid(userAgent);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _otp = db.OneTimePasswords.Find(userAgentGuid);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (_otp != null &amp;&amp; (DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) &gt; 0))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return false;
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
/// &lt;/summary&gt;
private bool NonceIsValid
{
&nbsp;&nbsp;&nbsp; get
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var userAgent = Request.Headers.UserAgent.ToString();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (userAgent.StartsWith(&quot;AllInOneCode-&quot;))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var userAgentGuid = new Guid(userAgent);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; _otp = db.OneTimePasswords.Find(userAgentGuid);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (_otp != null &amp;&amp; (DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) &gt; 0))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return false;
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><strong><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>How to verify the trustworthiness and genuine of the uploaded Hardware ID in the cloud?
</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Verify the trustworthiness and genuine of the posted Hardware Id
/// by using nonce, signature and certificate.
/// &lt;/summary&gt;
/// &lt;param name=&quot;ashwid&quot;&gt;
/// ASHWID with Hardware Id, certificate and signature
/// &lt;/param&gt;
/// &lt;returns&gt;The enum type of DataGenuineResult&lt;/returns&gt;
private DataGenuineResult VerifyDataGenuine(Ashwid ashwid)
{
&nbsp;&nbsp;&nbsp; const string basicConstraintName = &quot;Basic Constraints&quot;;
&nbsp;&nbsp;&nbsp; const string leafCertEku = &quot;1.3.6.1.4.1.311.10.5.40&quot;;
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Extract certificates from the ASHWID certificate blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Certificate blob is a PKCS#7 formatted certification chain.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var cms = new SignedCms();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cms.Decode(ashwid.Certificate);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Looping through all certificates to find the leaf certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2 leafCert = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (var x509 in cms.Certificates)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bool basicConstraintExtensionExists = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (X509Extension extension in x509.Extensions)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (extension.Oid.FriendlyName == basicConstraintName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; basicConstraintExtensionExists = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var ext = (X509BasicConstraintsExtension) extension;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!ext.CertificateAuthority)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;}


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leafCert != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!basicConstraintExtensionExists)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (x509.Issuer != x509.Subject)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leafCert == null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.NoLeafCert;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Validating the certificate chain. Ignore the errors due to online revocation check not 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// being available. Also we are not failing validation due to expired certificates. Microsoft
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // will be revoking the certificates that were exploided. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var chain = new X509Chain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ChainPolicy =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RevocationFlag = X509RevocationFlag.EntireChain,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RevocationMode = X509RevocationMode.Online,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlNotTimeValid |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreEndRevocationUnknown |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlSignerRevocationUnknown
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chain.ChainPolicy.ApplicationPolicy.Add(new Oid(leafCertEku));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var valid = chain.Build(leafCert);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!valid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (X509ChainStatus status in chain.ChainStatus)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (status.Status)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NoError:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NotTimeValid:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NotTimeNested:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.CtlNotTimeValid:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.RevocationStatusUnknown:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.OfflineRevocation:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;return DataGenuineResult.CertificationChainVerificationFailure;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // GRootPublicKey is the hard coded public key for the root certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Compare the public key on the root certificate with the hard coded one. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// They must match.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rootCertificate = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;return DataGenuineResult.RootCertificateInvalid;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Using the leaf Certificate we verify the signature of blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // We use CLR Security API by CLR Security's team under:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Concatenate nonce and HardwareId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var nonce = Encoding.UTF8.GetBytes(_otp.Nonce);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rawData = new byte[nonce.Length &#43; ashwid.HardwareId.Length];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var publicKey = leafCert.PublicKey.Key as RSACryptoServiceProvider;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (publicKey != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rsa = new RSACng(1024)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EncryptionHashAlgorithm = CngAlgorithm.Sha256,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignatureHashAlgorithm = CngAlgorithm.Sha1,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use Pss padding here by CLR Security API
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignaturePaddingMode = AsymmetricPaddingMode.Pss,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignatureSaltBytes = 0,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var parameters = publicKey.ExportParameters(false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.ImportParameters(parameters);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use the leaf certificate to verify that the signed hash signature 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// matches the original nonce that was sent from the cloud service 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// and the received hardware byte stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bool isSignatureValid = rsa.VerifyData(rawData, ashwid.Signature);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!isSignatureValid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.SignatureInvalid;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp; &nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.StackTrace);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.Invalid;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return DataGenuineResult.Genuine;
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Verify the trustworthiness and genuine of the posted Hardware Id
/// by using nonce, signature and certificate.
/// &lt;/summary&gt;
/// &lt;param name=&quot;ashwid&quot;&gt;
/// ASHWID with Hardware Id, certificate and signature
/// &lt;/param&gt;
/// &lt;returns&gt;The enum type of DataGenuineResult&lt;/returns&gt;
private DataGenuineResult VerifyDataGenuine(Ashwid ashwid)
{
&nbsp;&nbsp;&nbsp; const string basicConstraintName = &quot;Basic Constraints&quot;;
&nbsp;&nbsp;&nbsp; const string leafCertEku = &quot;1.3.6.1.4.1.311.10.5.40&quot;;
&nbsp;&nbsp;&nbsp; try
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Extract certificates from the ASHWID certificate blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Certificate blob is a PKCS#7 formatted certification chain.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var cms = new SignedCms();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cms.Decode(ashwid.Certificate);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Looping through all certificates to find the leaf certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X509Certificate2 leafCert = null;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (var x509 in cms.Certificates)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bool basicConstraintExtensionExists = false;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (X509Extension extension in x509.Extensions)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (extension.Oid.FriendlyName == basicConstraintName)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; basicConstraintExtensionExists = true;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var ext = (X509BasicConstraintsExtension) extension;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!ext.CertificateAuthority)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;}


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leafCert != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!basicConstraintExtensionExists)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (x509.Issuer != x509.Subject)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (leafCert == null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.NoLeafCert;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Validating the certificate chain. Ignore the errors due to online revocation check not 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// being available. Also we are not failing validation due to expired certificates. Microsoft
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // will be revoking the certificates that were exploided. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var chain = new X509Chain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ChainPolicy =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RevocationFlag = X509RevocationFlag.EntireChain,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RevocationMode = X509RevocationMode.Online,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlNotTimeValid |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreEndRevocationUnknown |
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlSignerRevocationUnknown
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chain.ChainPolicy.ApplicationPolicy.Add(new Oid(leafCertEku));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var valid = chain.Build(leafCert);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!valid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; foreach (X509ChainStatus status in chain.ChainStatus)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (status.Status)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NoError:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NotTimeValid:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.NotTimeNested:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.CtlNotTimeValid:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.RevocationStatusUnknown:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case X509ChainStatusFlags.OfflineRevocation:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; default:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;return DataGenuineResult.CertificationChainVerificationFailure;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // GRootPublicKey is the hard coded public key for the root certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// Compare the public key on the root certificate with the hard coded one. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// They must match.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rootCertificate = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;return DataGenuineResult.RootCertificateInvalid;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Using the leaf Certificate we verify the signature of blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // We use CLR Security API by CLR Security's team under:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Concatenate nonce and HardwareId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var nonce = Encoding.UTF8.GetBytes(_otp.Nonce);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rawData = new byte[nonce.Length &#43; ashwid.HardwareId.Length];
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var publicKey = leafCert.PublicKey.Key as RSACryptoServiceProvider;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (publicKey != null)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var rsa = new RSACng(1024)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EncryptionHashAlgorithm = CngAlgorithm.Sha256,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignatureHashAlgorithm = CngAlgorithm.Sha1,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use Pss padding here by CLR Security API
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignaturePaddingMode = AsymmetricPaddingMode.Pss,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SignatureSaltBytes = 0,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var parameters = publicKey.ExportParameters(false);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.ImportParameters(parameters);


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Use the leaf certificate to verify that the signed hash signature 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// matches the original nonce that was sent from the cloud service 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;// and the received hardware byte stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; bool isSignatureValid = rsa.VerifyData(rawData, ashwid.Signature);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (!isSignatureValid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.SignatureInvalid;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; catch (Exception ex)
&nbsp; &nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.Message);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.StackTrace);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return DataGenuineResult.Invalid;
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return DataGenuineResult.Genuine;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><strong><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>How to deal with the device difference by setting a threshold for the same device?
</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Try to find the base Hardware Id when registering the app.
var baseHardwareId = db.Ashwids.Find(ashwid.CustomerId);


// You could adjust the thresold for hardware drift.
// For the demonstration purpose, whenever there's a minior device change,
// the device is considered different.
const int thresholdForBeingTheSameDevice = 0;


if (baseHardwareId != null &amp;&amp; ashwid.HardwareId != null)
{
&nbsp;&nbsp;&nbsp; var diffValue = DiffDeviceDictionary(ConvertHwIdToDevDic(baseHardwareId.HardwareId),
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertHwIdToDevDic(ashwid.HardwareId));


&nbsp;&nbsp;&nbsp; if (diffValue &gt; thresholdForBeingTheSameDevice)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateErrorResponse(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HttpStatusCode.Forbidden, Resources.LicenseRefused);
&nbsp;&nbsp;&nbsp; }
}

</pre>
<pre id="codePreview" class="csharp">// Try to find the base Hardware Id when registering the app.
var baseHardwareId = db.Ashwids.Find(ashwid.CustomerId);


// You could adjust the thresold for hardware drift.
// For the demonstration purpose, whenever there's a minior device change,
// the device is considered different.
const int thresholdForBeingTheSameDevice = 0;


if (baseHardwareId != null &amp;&amp; ashwid.HardwareId != null)
{
&nbsp;&nbsp;&nbsp; var diffValue = DiffDeviceDictionary(ConvertHwIdToDevDic(baseHardwareId.HardwareId),
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertHwIdToDevDic(ashwid.HardwareId));


&nbsp;&nbsp;&nbsp; if (diffValue &gt; thresholdForBeingTheSameDevice)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return Request.CreateErrorResponse(
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HttpStatusCode.Forbidden, Resources.LicenseRefused);
&nbsp;&nbsp;&nbsp; }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// Convert serialized hardwareId to well formed HardwareId structures so that 
/// it can be easily consumed. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hardwareId&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static IDictionary&lt;int, List&lt;string&gt;&gt; ConvertHwIdToDevDic(Byte[] hardwareId)
{
&nbsp;&nbsp;&nbsp; var hardwareIdString = BitConverter.ToString(hardwareId).Replace(&quot;-&quot;, &quot;&quot;);
&nbsp;&nbsp;&nbsp; // make the empty Device Dictionary data structure
&nbsp;&nbsp;&nbsp; var deviceDic = new Dictionary&lt;int, List&lt;string&gt;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;{0, new List&lt;string&gt;()}, // Invalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {1, new List&lt;string&gt;()}, // Processor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {2, new List&lt;string&gt;()}, // Memory
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {3, new List&lt;string&gt;()}, // Disk Device
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {4, new List&lt;string&gt;()}, // Network Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {5, new List&lt;string&gt;()}, // Audio Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {6, new List&lt;string&gt;()}, // Docking Station
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {7, new List&lt;string&gt;()}, // Mobile Broadband
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {8, new List&lt;string&gt;()}, // Bluetooth
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {9, new List&lt;string&gt;()}, // System BIOS
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };


&nbsp;&nbsp;&nbsp; for (var i = 0; i &lt; hardwareIdString.Length / 8; i&#43;&#43;)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (hardwareIdString.Substring(i * 8, 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0100&quot;: // Processor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[1].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0200&quot;: // Memory
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[2].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0300&quot;: // Disk Device
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[3].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0400&quot;: // Network Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[4].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0500&quot;: // Audio Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[5].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0600&quot;: // Docking Station
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[6].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0700&quot;: // Mobile Broadband
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;deviceDic[7].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0800&quot;: // Bluetooth
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[8].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0900&quot;: // System BIOS
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[9].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return deviceDic;
}


/// &lt;summary&gt;
/// Compare two devices to see the difference.
/// The granularity for the difference is 0.1
/// &lt;/summary&gt;
/// &lt;param name=&quot;devDicBase&quot;&gt;Base Device Dictionary&lt;/param&gt;
/// &lt;param name=&quot;devDicNew&quot;&gt;New Device Dictionary&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static double DiffDeviceDictionary(IDictionary&lt;int, List&lt;string&gt;&gt; devDicBase, IDictionary&lt;int, List&lt;string&gt;&gt; devDicNew)
{
&nbsp;&nbsp;&nbsp; // Component Weight in Percentage, updated per the business logic.
&nbsp;&nbsp;&nbsp; int[] compWeightPercentage =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 0,&nbsp; // 0 - Invalid - 0%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 1 - Processor - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 2 - Memory - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 20, // 3 - Disk Device - 20%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 4 - Network Adapter - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 5 - Audio Adapater - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5,&nbsp; // 6 - Docking Station - 5%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 7 - Mobile Broadband - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5,&nbsp; // 8 - Bluetooth - 5%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 20&nbsp; // 9 - System BIOS - 20%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };


&nbsp;&nbsp;&nbsp; double diffValue = 0;
&nbsp;&nbsp;&nbsp; for (var i = 1; i &lt; 10; &#43;&#43;i)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var diffCount = devDicBase[i].Count - devDicNew[i].Count;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // the base component size is bigger than the New one.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (diffCount &gt;= 0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= devDicNew[i].Count(component =&gt; !devDicBase[i].Contains(component));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= devDicBase[i].Count(component =&gt; !devDicNew[i].Contains(component));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffValue &#43;= (diffCount * compWeightPercentage[i]);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return diffValue / 100;
}

</pre>
<pre id="codePreview" class="csharp">/// &lt;summary&gt;
/// Convert serialized hardwareId to well formed HardwareId structures so that 
/// it can be easily consumed. 
/// &lt;/summary&gt;
/// &lt;param name=&quot;hardwareId&quot;&gt;&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static IDictionary&lt;int, List&lt;string&gt;&gt; ConvertHwIdToDevDic(Byte[] hardwareId)
{
&nbsp;&nbsp;&nbsp; var hardwareIdString = BitConverter.ToString(hardwareId).Replace(&quot;-&quot;, &quot;&quot;);
&nbsp;&nbsp;&nbsp; // make the empty Device Dictionary data structure
&nbsp;&nbsp;&nbsp; var deviceDic = new Dictionary&lt;int, List&lt;string&gt;&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;{0, new List&lt;string&gt;()}, // Invalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {1, new List&lt;string&gt;()}, // Processor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {2, new List&lt;string&gt;()}, // Memory
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {3, new List&lt;string&gt;()}, // Disk Device
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {4, new List&lt;string&gt;()}, // Network Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {5, new List&lt;string&gt;()}, // Audio Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {6, new List&lt;string&gt;()}, // Docking Station
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {7, new List&lt;string&gt;()}, // Mobile Broadband
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {8, new List&lt;string&gt;()}, // Bluetooth
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {9, new List&lt;string&gt;()}, // System BIOS
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };


&nbsp;&nbsp;&nbsp; for (var i = 0; i &lt; hardwareIdString.Length / 8; i&#43;&#43;)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; switch (hardwareIdString.Substring(i * 8, 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0100&quot;: // Processor
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[1].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0200&quot;: // Memory
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[2].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0300&quot;: // Disk Device
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[3].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0400&quot;: // Network Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[4].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0500&quot;: // Audio Adapter
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[5].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0600&quot;: // Docking Station
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[6].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0700&quot;: // Mobile Broadband
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;deviceDic[7].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0800&quot;: // Bluetooth
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[8].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case &quot;0900&quot;: // System BIOS
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic[9].Add(hardwareIdString.Substring(i * 8 &#43; 4, 4));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return deviceDic;
}


/// &lt;summary&gt;
/// Compare two devices to see the difference.
/// The granularity for the difference is 0.1
/// &lt;/summary&gt;
/// &lt;param name=&quot;devDicBase&quot;&gt;Base Device Dictionary&lt;/param&gt;
/// &lt;param name=&quot;devDicNew&quot;&gt;New Device Dictionary&lt;/param&gt;
/// &lt;returns&gt;&lt;/returns&gt;
private static double DiffDeviceDictionary(IDictionary&lt;int, List&lt;string&gt;&gt; devDicBase, IDictionary&lt;int, List&lt;string&gt;&gt; devDicNew)
{
&nbsp;&nbsp;&nbsp; // Component Weight in Percentage, updated per the business logic.
&nbsp;&nbsp;&nbsp; int[] compWeightPercentage =
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 0,&nbsp; // 0 - Invalid - 0%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 1 - Processor - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 2 - Memory - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 20, // 3 - Disk Device - 20%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 4 - Network Adapter - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 5 - Audio Adapater - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5,&nbsp; // 6 - Docking Station - 5%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10, // 7 - Mobile Broadband - 10%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 5,&nbsp; // 8 - Bluetooth - 5%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 20&nbsp; // 9 - System BIOS - 20%
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; };


&nbsp;&nbsp;&nbsp; double diffValue = 0;
&nbsp;&nbsp;&nbsp; for (var i = 1; i &lt; 10; &#43;&#43;i)
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; var diffCount = devDicBase[i].Count - devDicNew[i].Count;


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // the base component size is bigger than the New one.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (diffCount &gt;= 0)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= devDicNew[i].Count(component =&gt; !devDicBase[i].Contains(component));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= devDicBase[i].Count(component =&gt; !devDicNew[i].Contains(component));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffValue &#43;= (diffCount * compWeightPercentage[i]);
&nbsp;&nbsp;&nbsp; }


&nbsp;&nbsp;&nbsp; return diffValue / 100;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><strong>&nbsp;</strong></p>
<h2>More Information</h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
