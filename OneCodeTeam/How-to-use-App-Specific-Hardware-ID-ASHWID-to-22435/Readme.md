# How to use App Specific Hardware ID (ASHWID) to implement per-device logic in Wi
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* Microsoft Azure
* Windows
* Windows 8
* Windows Store app Development
## Topics
* Windows 8 App with Cloud Service
## IsPublished
* False
## ModifiedDate
* 2013-06-05 12:38:48
## Description

<h1>Use App Specific Hardware ID (ASHWID) to implement per-device logic in a Windows Store app (VBWindowsStoreAppASHWID)</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The sample demonstrates how to use App Specific Hardware ID (ASHWID) to uniquely identify a device and go step further to implement a per-device logic in the Windows Store app.<span style="">&nbsp;
</span>You can find the answers for all the following questions in the code sample:
</span></p>
<p class="MsoListBulletCxSpFirst" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to generate the ASHWID in a Windows Store app?
</span></p>
<p class="MsoListBulletCxSpMiddle" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to authenticate the ASHWID in the cloud? </span>
</p>
<p class="MsoListBulletCxSpLast" style=""><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">How to account for the hardware drift and process the ASHWID in the cloud?
</span></p>
<h2>Building the Sample</h2>
<p class="MsoNormal"><span style="">To build this sample, you must reference the Security.dll authored by Microsoft CLR Security team.<span style="">&nbsp;
</span>Security.dll extends the security APIs shipped with the .NET Framework to provide additional functionality with the Code Access Security system in the .NET Framework.<span style="">&nbsp;&nbsp;
</span>By leveraging the CLR Security API in Security.dll, the attached cloud side codes can use PSS padding and validate the trustworthiness and genuine of the Hardware ID uploaded from the client.
</span></p>
<p class="MsoNormal"><span style="">The CLR Security assemblies are available for download from the CLR Security CodePlex Site:</span>
<a href="http://clrsecurity.codeplex.com/">Download the CLR Security assemblies here</a><span style="">.
</span></p>
<p class="MsoNormal"><b style=""><span style="">Note</span></b><span style="">: the Security.dll has already been included in the code samples attached.<span style="">&nbsp;&nbsp;&nbsp;
</span></span></p>
<h2>Running the Sample</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-right:22.0pt; text-indent:-.25in">
<span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open<span style=""> this sample solution in VS2012 on Win8 machine,
</span>you will see two projects in a Client-Server model.<span style="">&nbsp; </span>
The client codes locates in VBWindowsStoreAppDeviceClient project while the server codes in VBWindowsStoreAppDeviceService project.<span style="">&nbsp;
</span>In this demonstration, you will deploy both client and server on the same Windows 8 machine.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt; text-indent:-.25in">
<span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">One of the Service's responsibility is to verify the trustworthiness of the Hardware ID value uploaded from the client Windows Store app.<span style="">&nbsp;&nbsp;&nbsp;
</span>For the purpose of the genuine verification, codes assumes </span>that the &quot;Microsoft Assurance Designation Root 2011&quot; root certificate is trusted on the server side.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt">Please <b style="">
import the certificate &quot;Microsoft Assurance Designation Root 2011&quot; to the trusted root certification store</b> on the server side as below illustration depicts.<span style="">&nbsp;
</span>(Note: You could find the certificate DER encoded binary <b style="">MADR2011.cer</b> under the project root folder of VBWindowsStoreAppDeviceService.)<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span style=""><img src="/site/view/file/83565/1/image.png" alt="" width="549" height="535" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-right:22.0pt; text-indent:-.25in">
<span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Launch the VBWindowsStoreAppDeviceService in VS2012 as following:<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click the VBWin8DeviceService in the Solution Explorer<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Choose &quot;Set as Start Project&quot; in the pop-up context menu.<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:.75in; text-indent:-.25in">
<span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">On the VS main menu Debug, choose &quot;Start without Debugging&quot; and you will see the WebApi Service launched on the local port 12345 as below:
</span></p>
<p class="MsoNormal" style="margin-right:22.0pt; text-indent:.25in"><span style=""><img src="/site/view/file/83566/1/image.png" alt="" width="576" height="401" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Start the Windows Store client by following: </span>
</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:1.0in; text-indent:-.25in">
<span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Right-click the VBWindowsStoreAppDeviceClient in the Solution Explorer<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:22.0pt; margin-bottom:10.0pt; margin-left:1.0in; text-indent:-.25in">
<span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Choose &quot;Set as Start Project&quot; in the pop-up context menu.<span style="">
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:1.0in; text-indent:-.25in">
<span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Press F5 to run it. </span></p>
<p class="MsoNormal" style="text-indent:.25in"><span style=""><img src="/site/view/file/83567/1/image.png" alt="" width="595" height="380" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Click the &quot;Register Device on Cloud&quot; button to register the unique Hardware ID to the service.<span style="">&nbsp;&nbsp;
</span>The step will upload the Hardware ID from the client to the server and store it as the base Hardware Id with the binding Customer ID in the backend database.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">You will see from the Output information, a unique ASHWID is generated in byte stream and uploaded to the server.<span style="">&nbsp;
</span>Below is one of the sample ASHWIDs from one of the Windows 8 machine: </span>
</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">03-00-0A-51-05-00-BC-0C-<b style="">05-00-AD-35</b>-05-00-D4-E1-06-00-01-00-04-00-FE-15-04-00-9E-2B-04-00-30-3C-01-00-74-F2-02-00-D8-78-09-00-78-D5
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast">Note: The byte stream consists of multiple groups of four bytes. The first two bytes contain the type of the component and the next two bytes contain the value. The table below identifies the type of each component:</p>
<table class="MsoTable15Grid1Light" border="1" cellspacing="0" cellpadding="0" style="margin-left:41.0pt; border-collapse:collapse; border:none">
<tbody>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-bottom:solid #666666 1.5pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>Byte Stream representation </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:solid #999999 1.0pt; border-left:none; border-bottom:solid #666666 1.5pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>Component </b></p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>01-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Processor </p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>02-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Memory </p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>03-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Disk Device </p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>04-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Network Adapter</p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>05-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Audio Adapter</p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>06-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Docking Station</p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>07-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Mobile Broadband</p>
</td>
</tr>
<tr style="">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing" style=""><b>08-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt">
<p class="MsoNoSpacing">Bluetooth </p>
</td>
</tr>
<tr style="height:2.5pt">
<td width="125" valign="top" style="width:93.75pt; border:solid #999999 1.0pt; border-top:none; padding:0in 5.4pt 0in 5.4pt; height:2.5pt">
<p class="MsoNoSpacing" style=""><b>09-00 </b></p>
</td>
<td width="150" valign="top" style="width:112.5pt; border-top:none; border-left:none; border-bottom:solid #999999 1.0pt; border-right:solid #999999 1.0pt; padding:0in 5.4pt 0in 5.4pt; height:2.5pt">
<p class="MsoNoSpacing">System BIOS</p>
</td>
</tr>
</tbody>
</table>
<p class="MsoListParagraphCxSpFirst"></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style=""><span style="">7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Do a slight change on the components of the device, for example, unplug your USB headset, and try to verify the device on the server by click the &quot;Verify Device on Cloud&quot; button.<span style="">&nbsp;&nbsp;
</span>You will retrieve a new byte stream which four bytes indicates one Audio Adapter bolded in step #6 is missing.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">03-00-0A-51-05-00-BC-0C-05-00-D4-E1-06-00-01-00-04-00-FE-15-04-00-9E-2B-04-00-30-3C-01-00-74-F2-02-00-D8-78-09-00-78-D5
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast"><span style="">The slight change mentioned here is referred as &quot;<b style="">hardware drift</b>&quot;.<span style="">&nbsp;
</span></span>The ASHWID from a given device may change for a variety of reasons depending on when it is queried:<span style="">
</span></p>
<p class="MsoListBulletCxSpFirst" style="margin-left:.75in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">User may temporarily connect peripherals to their devices that add to the list of components.
</span></p>
<p class="MsoListBulletCxSpMiddle" style="margin-left:.75in"><span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Power management devices (for slates and devices running on ARM processors) might switch off certain hardware components to conserve battery life.
</span></p>
<p class="MsoListBulletCxSpLast" style="margin-left:.5in; text-indent:0in">One of the ways the app can account for hardware drift is to compute a score by attaching weights to each of the returned component IDs based on its business logic. The computed score
 must pass the threshold set by the cloud component to be identified as the same device.</p>
<p class="MsoListParagraphCxSpFirst">You could refer to the codes of <b style="">
bullet #6 &quot;How to deal with the device difference by setting a threshold for the same device?&quot; in the &quot;Using the Code&quot; section</b> to get some idea how to set the threshold based on your business logic.<span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style=""><span style="">8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">In the sample code attached, the threshold score is set to zero.<span style="">&nbsp;&nbsp;
</span>That means no matter what kind of minor hardware change, you will get an alert from the cloud as following:
</span></p>
<p class="MsoNormal" style="margin-left:.25in"><span style=""><img src="/site/view/file/83568/1/image.png" alt="" width="595" height="96" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><span style=""><span style="">9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">The main page will finally be shown as following after you unplug one USB headset from the device you tested:
</span></p>
<p class="MsoListBullet" style=""><span style=""><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
</span><span style=""><img src="/site/view/file/83569/1/image.png" alt="" width="595" height="380" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style="">The code sample provides the following reusable functions:
</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">How to generate the ASHWID in a Windows Store app client?
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim packageSpecificToken As HardwareToken = HardwareIdentification.GetPackageSpecificToken(nonce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim hwId As New Ashwid With {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .CustomerId = _customerId,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
<pre id="codePreview" class="vb">
' Hardware id, signature, certificate IBuffer objects that can be accessed through properties.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim packageSpecificToken As HardwareToken = HardwareIdentification.GetPackageSpecificToken(nonce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim hwId As New Ashwid With {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .CustomerId = _customerId,
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .HardwareId = Utilities.ConvertBufferToByteArray(packageSpecificToken.Id),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Certificate = Utilities.ConvertBufferToByteArray(packageSpecificToken.Certificate),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Signature = Utilities.ConvertBufferToByteArray(packageSpecificToken.Signature)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">How to get a random nonce in a Json HttpRequest ?
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Request a nonce from the server
''' &lt;/summary&gt;
''' &lt;returns&gt;
''' Return the nonce from the cloud.
''' If get the request error, return null by default.
''' &lt;/returns&gt;
Private Async Function GetNonce() As Task(Of IBuffer)
&nbsp;&nbsp;&nbsp; Dim errMsg As String = String.Empty


&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using client As HttpClient = New HttpClient
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a unique AgentId to the request header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId)


&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Use JSON request to get the nonce from the cloud side.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.BaseAddress = New Uri(ServiceBaseUri)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim content As String = client.GetStringAsync(GetNonceApiUriPath).Result
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stream As New MemoryStream(Encoding.Unicode.GetBytes(content))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Deserialize the OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New DataContractJsonSerializer(GetType(OneTimePassword))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim otpObj As OneTimePassword = TryCast(serializer.ReadObject(DirectCast(stream, Stream)), OneTimePassword)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ((otpObj Is Nothing) OrElse String.IsNullOrEmpty(otpObj.Nonce)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; Catch hReqEx As HttpRequestException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; errMsg = String.Format(&quot;HttpRequest error: {0}&quot;, hReqEx.Message)
&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; errMsg = String.Format(&quot;HttpRequest error: {0}&quot;, ex.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(errMsg) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await New MessageDialog(errMsg).ShowAsync
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return Nothing
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Request a nonce from the server
''' &lt;/summary&gt;
''' &lt;returns&gt;
''' Return the nonce from the cloud.
''' If get the request error, return null by default.
''' &lt;/returns&gt;
Private Async Function GetNonce() As Task(Of IBuffer)
&nbsp;&nbsp;&nbsp; Dim errMsg As String = String.Empty


&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Using client As HttpClient = New HttpClient
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Add a unique AgentId to the request header.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.UserAgent.ParseAdd(_clientAgentId)


&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Use JSON request to get the nonce from the cloud side.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue(MediaTypeHeaderJson))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; client.BaseAddress = New Uri(ServiceBaseUri)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim content As String = client.GetStringAsync(GetNonceApiUriPath).Result
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim stream As New MemoryStream(Encoding.Unicode.GetBytes(content))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Deserialize the OneTimePassword
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim serializer As New DataContractJsonSerializer(GetType(OneTimePassword))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim otpObj As OneTimePassword = TryCast(serializer.ReadObject(DirectCast(stream, Stream)), OneTimePassword)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ((otpObj Is Nothing) OrElse String.IsNullOrEmpty(otpObj.Nonce)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return CryptographicBuffer.ConvertStringToBinary(otpObj.Nonce, BinaryStringEncoding.Utf8)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Using
&nbsp;&nbsp;&nbsp; Catch hReqEx As HttpRequestException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; errMsg = String.Format(&quot;HttpRequest error: {0}&quot;, hReqEx.Message)
&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; errMsg = String.Format(&quot;HttpRequest error: {0}&quot;, ex.Message)
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; If Not String.IsNullOrEmpty(errMsg) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Await New MessageDialog(errMsg).ShowAsync
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return Nothing
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><b style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">How to generate the One Time Password nonce in the cloud by using ASP.NET MVC API controller with Entity Framework?
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' GET api/OneTimePassword
' Get OTP nonce from the cloud
Function GetOneTimePasswords() As OneTimePassword


&nbsp;&nbsp;&nbsp; Dim userAgent As String = Request.Headers.UserAgent.ToString
&nbsp;&nbsp;&nbsp; If Not userAgent.StartsWith(&quot;AllInOneCode-&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length)
&nbsp;&nbsp;&nbsp; Dim userAgentGuid As New Guid(userAgent)


&nbsp;&nbsp;&nbsp; Dim otp As OneTimePassword = Nothing
&nbsp;&nbsp;&nbsp; If ModelState.IsValid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = db.OneTimePasswords.Find(userAgentGuid)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not otp Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Found the original otp in the database, renew the expired time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;db.Entry(otp).State = EntityState.Modified
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Password will be expired in one minute by default.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Nonce will be generated randomly in a substring of GUID value.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = New OneTimePassword With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AgentId = New Guid(userAgent), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ExpiredTime = DateTime.UtcNow.AddMinutes(1), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Nonce = Guid.NewGuid().ToString().Substring(0, 6) _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.OneTimePasswords.Add(otp)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch duce As DbUpdateConcurrencyException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.StackTrace)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return otp
End Function

</pre>
<pre id="codePreview" class="vb">
' GET api/OneTimePassword
' Get OTP nonce from the cloud
Function GetOneTimePasswords() As OneTimePassword


&nbsp;&nbsp;&nbsp; Dim userAgent As String = Request.Headers.UserAgent.ToString
&nbsp;&nbsp;&nbsp; If Not userAgent.StartsWith(&quot;AllInOneCode-&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Return Nothing
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length)
&nbsp;&nbsp;&nbsp; Dim userAgentGuid As New Guid(userAgent)


&nbsp;&nbsp;&nbsp; Dim otp As OneTimePassword = Nothing
&nbsp;&nbsp;&nbsp; If ModelState.IsValid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = db.OneTimePasswords.Find(userAgentGuid)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not otp Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Found the original otp in the database, renew the expired time.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.ExpiredTime = DateTime.UtcNow.AddMinutes(1)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp.Nonce = Guid.NewGuid().ToString().Substring(0, 6)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;db.Entry(otp).State = EntityState.Modified
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Password will be expired in one minute by default.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Nonce will be generated randomly in a substring of GUID value.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; otp = New OneTimePassword With { _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.AgentId = New Guid(userAgent), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .ExpiredTime = DateTime.UtcNow.AddMinutes(1), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; .Nonce = Guid.NewGuid().ToString().Substring(0, 6) _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.OneTimePasswords.Add(otp)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; db.SaveChanges()
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch duce As DbUpdateConcurrencyException
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(duce.StackTrace)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try
&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp; Return otp
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">How to validate the nonce in one API controller?
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
''' &lt;/summary&gt;
Private ReadOnly Property NonceIsValid As Boolean
&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim userAgent As String = Request.Headers.UserAgent.ToString
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userAgent.StartsWith(&quot;AllInOneCode-&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim userAgentGuid As New Guid(userAgent)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;_otp = db.OneTimePasswords.Find(userAgentGuid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ((Not _otp Is Nothing) AndAlso _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) &gt; 0) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp;&nbsp; End Get
End Property

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Determine if the returned nonce is valid. By default, nonce will be expired in 1 min.
''' &lt;/summary&gt;
Private ReadOnly Property NonceIsValid As Boolean
&nbsp;&nbsp;&nbsp; Get
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim userAgent As String = Request.Headers.UserAgent.ToString
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If userAgent.StartsWith(&quot;AllInOneCode-&quot;) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; userAgent = userAgent.Substring(&quot;AllInOneCode-&quot;.Length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim userAgentGuid As New Guid(userAgent)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;_otp = db.OneTimePasswords.Find(userAgentGuid)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If ((Not _otp Is Nothing) AndAlso _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DateTime.Compare(_otp.ExpiredTime, DateTime.UtcNow) &gt; 0) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return False
&nbsp;&nbsp;&nbsp; End Get
End Property

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><b style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">How to verify the trustworthiness and genuine of the uploaded Hardware ID in the cloud?
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Verify the trustworthiness and genuine of the posted Hardware Id
''' by using nonce, signature and certificate.
''' &lt;/summary&gt;
''' &lt;param name=&quot;ashwid&quot;&gt;ASHWID with Hardware Id, certificate and signature&lt;/param&gt;
''' &lt;returns&gt;The enum type of DataGenuineResult&lt;/returns&gt;
Private Function VerifyDataGenuine(ByVal ashwid As Ashwid) As DataGenuineResult


&nbsp;&nbsp;&nbsp; Const basicConstraintName As String = &quot;Basic Constraints&quot;
&nbsp;&nbsp;&nbsp; Const leafCertEku As String = &quot;1.3.6.1.4.1.311.10.5.40&quot;


&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Extract certificates from the ASHWID certificate blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Certificate blob is a PKCS#7 formatted certification chain.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim cms As New SignedCms
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cms.Decode(ashwid.Certificate)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Looping through all certificates to find the leaf certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim leafCert As X509Certificate2 = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each x509 As X509Certificate2 In cms.Certificates
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim basicConstraintExtensionExists As Boolean = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each extension As X509Extension In x509.Extensions
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (extension.Oid.FriendlyName = basicConstraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;basicConstraintExtensionExists = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ext As X509BasicConstraintsExtension = DirectCast(extension, X509BasicConstraintsExtension)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ext.CertificateAuthority Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit For
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not leafCert Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit For
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not basicConstraintExtensionExists AndAlso (x509.Issuer &lt;&gt; x509.Subject)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (leafCert Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.NoLeafCert
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Validating the certificate chain. Ignore the errors due to online revocation check not 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' being available. Also we are not failing validation due to expired certificates. Microsoft
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' will be revoking the certificates that were exploided.


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim chain As New X509Chain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy = New X509ChainPolicy
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.RevocationMode = X509RevocationMode.Online
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlNotTimeValid Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreEndRevocationUnknown Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlSignerRevocationUnknown


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.ApplicationPolicy.Add(New Oid(leafCertEku))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim valid As Boolean = chain.Build(leafCert)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not valid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each status As X509ChainStatus In chain.ChainStatus
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case status.Status
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case X509ChainStatusFlags.NoError, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.NotTimeValid, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.NotTimeNested, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.CtlNotTimeValid, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.RevocationStatusUnknown, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.OfflineRevocation
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.CertificationChainVerificationFailure
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GRootPublicKey is the hard coded public key for the root certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Compare the public key on the root certificate with the hard coded one. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' They must match.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rootCertificate As X509Certificate2 = chain.ChainElements(chain.ChainElements.Count - 1).Certificate
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.RootCertificateInvalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Using the leaf Certificate we verify the signature of blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' We use CLR Security API by CLR Security's team under:
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Concatenate nonce and HardwareId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nonce As Byte() = Encoding.UTF8.GetBytes(_otp.Nonce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rawData As Byte() = New Byte((nonce.Length &#43; ashwid.HardwareId.Length) - 1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim publicKey As RSACryptoServiceProvider = TryCast(leafCert.PublicKey.Key, RSACryptoServiceProvider)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not publicKey Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rsa As New RSACng(1024)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.EncryptionHashAlgorithm = CngAlgorithm.Sha256
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignatureHashAlgorithm = CngAlgorithm.Sha1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' Use Pss padding here by CLR Security API
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignaturePaddingMode = AsymmetricPaddingMode.Pss
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignatureSaltBytes = 0


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parameters As RSAParameters = publicKey.ExportParameters(False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.ImportParameters(parameters)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use the leaf certificate to verify that the signed hash signature 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' matches the original nonce that was sent from the cloud service 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' and the received hardware byte stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim isSignatureValid As Boolean = rsa.VerifyData(rawData, ashwid.Signature)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not isSignatureValid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.SignatureInvalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.StackTrace)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.Invalid
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return DataGenuineResult.Genuine
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Verify the trustworthiness and genuine of the posted Hardware Id
''' by using nonce, signature and certificate.
''' &lt;/summary&gt;
''' &lt;param name=&quot;ashwid&quot;&gt;ASHWID with Hardware Id, certificate and signature&lt;/param&gt;
''' &lt;returns&gt;The enum type of DataGenuineResult&lt;/returns&gt;
Private Function VerifyDataGenuine(ByVal ashwid As Ashwid) As DataGenuineResult


&nbsp;&nbsp;&nbsp; Const basicConstraintName As String = &quot;Basic Constraints&quot;
&nbsp;&nbsp;&nbsp; Const leafCertEku As String = &quot;1.3.6.1.4.1.311.10.5.40&quot;


&nbsp;&nbsp;&nbsp; Try
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Extract certificates from the ASHWID certificate blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Certificate blob is a PKCS#7 formatted certification chain.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim cms As New SignedCms
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; cms.Decode(ashwid.Certificate)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Looping through all certificates to find the leaf certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim leafCert As X509Certificate2 = Nothing
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each x509 As X509Certificate2 In cms.Certificates
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim basicConstraintExtensionExists As Boolean = False
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each extension As X509Extension In x509.Extensions
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (extension.Oid.FriendlyName = basicConstraintName) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;basicConstraintExtensionExists = True
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim ext As X509BasicConstraintsExtension = DirectCast(extension, X509BasicConstraintsExtension)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not ext.CertificateAuthority Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit For
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not leafCert Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit For
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not basicConstraintExtensionExists AndAlso (x509.Issuer &lt;&gt; x509.Subject)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; leafCert = x509
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (leafCert Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.NoLeafCert
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Validating the certificate chain. Ignore the errors due to online revocation check not 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' being available. Also we are not failing validation due to expired certificates. Microsoft
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' will be revoking the certificates that were exploided.


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim chain As New X509Chain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy = New X509ChainPolicy
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.RevocationMode = X509RevocationMode.Online
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreNotTimeValid Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlNotTimeValid Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreEndRevocationUnknown Or _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509VerificationFlags.IgnoreCtlSignerRevocationUnknown


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; chain.ChainPolicy.ApplicationPolicy.Add(New Oid(leafCertEku))


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim valid As Boolean = chain.Build(leafCert)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not valid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each status As X509ChainStatus In chain.ChainStatus
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case status.Status
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case X509ChainStatusFlags.NoError, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.NotTimeValid, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.NotTimeNested, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.CtlNotTimeValid, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.RevocationStatusUnknown, _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; X509ChainStatusFlags.OfflineRevocation
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.CertificationChainVerificationFailure
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' GRootPublicKey is the hard coded public key for the root certificate. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' Compare the public key on the root certificate with the hard coded one. 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' They must match.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rootCertificate As X509Certificate2 = chain.ChainElements(chain.ChainElements.Count - 1).Certificate
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not rootCertificate.PublicKey.EncodedKeyValue.RawData.SequenceEqual(GRootPublicKey) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.RootCertificateInvalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Using the leaf Certificate we verify the signature of blob.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' The RSACryptoServiceProvider does not provide a way to pass in different padding mode.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' We use CLR Security API by CLR Security's team under:
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' http://clrsecurity.codeplex.com/wikipage?title=Security.Cryptography.RSACng


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Concatenate nonce and HardwareId
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim nonce As Byte() = Encoding.UTF8.GetBytes(_otp.Nonce)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rawData As Byte() = New Byte((nonce.Length &#43; ashwid.HardwareId.Length) - 1) {}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(nonce, 0, rawData, 0, nonce.Length)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Buffer.BlockCopy(ashwid.HardwareId, 0, rawData, nonce.Length, ashwid.HardwareId.Length)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim publicKey As RSACryptoServiceProvider = TryCast(leafCert.PublicKey.Key, RSACryptoServiceProvider)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not publicKey Is Nothing) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim rsa As New RSACng(1024)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.EncryptionHashAlgorithm = CngAlgorithm.Sha256
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignatureHashAlgorithm = CngAlgorithm.Sha1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;' Use Pss padding here by CLR Security API
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignaturePaddingMode = AsymmetricPaddingMode.Pss
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.SignatureSaltBytes = 0


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim parameters As RSAParameters = publicKey.ExportParameters(False)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; rsa.ImportParameters(parameters)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Use the leaf certificate to verify that the signed hash signature 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' matches the original nonce that was sent from the cloud service 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;' and the received hardware byte stream.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;Dim isSignatureValid As Boolean = rsa.VerifyData(rawData, ashwid.Signature)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If Not isSignatureValid Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.SignatureInvalid
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp; Catch ex As Exception
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.Message)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Debug.WriteLine(ex.StackTrace)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return DataGenuineResult.Invalid
&nbsp;&nbsp;&nbsp; End Try


&nbsp;&nbsp;&nbsp; Return DataGenuineResult.Genuine
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst"><b style=""></b></p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><b style=""><span style=""><span style="">6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style="">How to deal with the device difference by setting a threshold for the same device?
</b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
' Try to find the base Hardware Id when registering the app.
Dim baseHardwareId As Ashwid = db.Ashwids.Find(ashwid.CustomerId)


' You could adjust the thresold for hardware drift.
' For the demonstration purpose, whenever there's a minior device change,
' the device is considered different.
Const thresholdForBeingTheSameDevice As Integer = 0


If ((Not baseHardwareId Is Nothing) AndAlso (Not ashwid.HardwareId Is Nothing)) Then
&nbsp;&nbsp;&nbsp; Dim diffValue As Double = DiffDeviceDictionary( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertHwIdToDevDic(baseHardwareId.HardwareId), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ConvertHwIdToDevDic(ashwid.HardwareId))


&nbsp;&nbsp;&nbsp; If (diffValue &gt; thresholdForBeingTheSameDevice) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Request.CreateErrorResponse(HttpStatusCode.Forbidden, My.Resources.LicenseRefused)
&nbsp;&nbsp;&nbsp; End If
Else

</pre>
<pre id="codePreview" class="vb">
' Try to find the base Hardware Id when registering the app.
Dim baseHardwareId As Ashwid = db.Ashwids.Find(ashwid.CustomerId)


' You could adjust the thresold for hardware drift.
' For the demonstration purpose, whenever there's a minior device change,
' the device is considered different.
Const thresholdForBeingTheSameDevice As Integer = 0


If ((Not baseHardwareId Is Nothing) AndAlso (Not ashwid.HardwareId Is Nothing)) Then
&nbsp;&nbsp;&nbsp; Dim diffValue As Double = DiffDeviceDictionary( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertHwIdToDevDic(baseHardwareId.HardwareId), _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ConvertHwIdToDevDic(ashwid.HardwareId))


&nbsp;&nbsp;&nbsp; If (diffValue &gt; thresholdForBeingTheSameDevice) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Request.CreateErrorResponse(HttpStatusCode.Forbidden, My.Resources.LicenseRefused)
&nbsp;&nbsp;&nbsp; End If
Else

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Convert serialized hardwareId to well formed HardwareId structures so that 
''' it can be easily consumed. 
''' &lt;/summary&gt;
''' &lt;param name=&quot;hardwareId&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Shared Function ConvertHwIdToDevDic( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal hardwareId As Byte()) As IDictionary(Of Integer, List(Of String))


&nbsp;&nbsp;&nbsp; Dim hardwareIdString As String = BitConverter.ToString(hardwareId).Replace(&quot;-&quot;, &quot;&quot;)


&nbsp;&nbsp;&nbsp; Dim deviceDic As New Dictionary(Of Integer, List(Of String))
&nbsp;&nbsp;&nbsp; ' Invalid
&nbsp;&nbsp;&nbsp; deviceDic.Add(0, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Processor
&nbsp;&nbsp;&nbsp; deviceDic.Add(1, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Memory
&nbsp;&nbsp;&nbsp; deviceDic.Add(2, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Disk Device
&nbsp;&nbsp;&nbsp; deviceDic.Add(3, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Network Adapter
&nbsp;&nbsp;&nbsp; deviceDic.Add(4, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Audio Adapter
&nbsp;&nbsp;&nbsp; deviceDic.Add(5, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Docking Station
&nbsp;&nbsp;&nbsp; deviceDic.Add(6, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Mobile Broadband
&nbsp;&nbsp;&nbsp; deviceDic.Add(7, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Bluetooth
&nbsp;&nbsp;&nbsp; deviceDic.Add(8, New List(Of String))
&nbsp;&nbsp;&nbsp; ' System BIOS
&nbsp;&nbsp;&nbsp; deviceDic.Add(9, New List(Of String))


&nbsp;&nbsp;&nbsp; For i As Integer = 0 To (hardwareIdString.Length / 8) - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case hardwareIdString.Substring((i * 8), 4)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0100&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(1).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0200&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(2).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0300&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(3).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0400&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(4).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0500&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(5).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0600&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(6).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0700&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(7).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0800&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(8).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0900&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(9).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; Return deviceDic
End Function


''' &lt;summary&gt;
''' Compare two devices to see the difference.
''' The granularity for the difference is 0.1
''' &lt;/summary&gt;
''' &lt;param name=&quot;devDicBase&quot;&gt;Base Device Dictionary&lt;/param&gt;
''' &lt;param name=&quot;devDicNew&quot;&gt;New Device Dictionary&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Shared Function DiffDeviceDictionary( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal devDicBase As IDictionary(Of Integer, List(Of String)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal devDicNew As IDictionary(Of Integer, List(Of String))) As Double


&nbsp;&nbsp;&nbsp; ' Component Weight in Percentage, updated per the business logic.
&nbsp;&nbsp;&nbsp; ' 0 - Invalid - 0%
&nbsp;&nbsp;&nbsp; ' 1 - Processor - 10%
&nbsp;&nbsp;&nbsp; ' 2 - Memory - 10%
&nbsp;&nbsp;&nbsp; ' 3 - Disk Device - 20%
&nbsp;&nbsp;&nbsp; ' 4 - Network Adapter - 10%
&nbsp;&nbsp;&nbsp; ' 5 - Audio Adapater - 10%
&nbsp;&nbsp;&nbsp; ' 6 - Docking Station - 5%
&nbsp;&nbsp;&nbsp; ' 7 - Mobile Broadband - 10%
&nbsp;&nbsp;&nbsp; ' 8 - Bluetooth - 5%
&nbsp;&nbsp;&nbsp; ' 9 - System BIOS - 20%
&nbsp;&nbsp;&nbsp; Dim compWeightPercentage As Integer() = New Integer() {0, 10, 10, 20, 10, 10, 5, 10, 5, 20}


&nbsp;&nbsp;&nbsp; Dim diffValue As Double = 0
&nbsp;&nbsp;&nbsp; For i As Integer = 1 To 10 - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim diffCount As Integer = (devDicBase(i).Count - devDicNew(i).Count)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' the base component size is bigger than the New one.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (diffCount &gt;= 0) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each component As String In devDicNew(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not devDicBase(i).Contains(component)) Then
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diffCount &#43;= 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each component As String In devDicBase(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not devDicNew(i).Contains(component)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffValue &#43;= (diffCount * compWeightPercentage(i))
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; Return diffValue / 100
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Convert serialized hardwareId to well formed HardwareId structures so that 
''' it can be easily consumed. 
''' &lt;/summary&gt;
''' &lt;param name=&quot;hardwareId&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
Private Shared Function ConvertHwIdToDevDic( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal hardwareId As Byte()) As IDictionary(Of Integer, List(Of String))


&nbsp;&nbsp;&nbsp; Dim hardwareIdString As String = BitConverter.ToString(hardwareId).Replace(&quot;-&quot;, &quot;&quot;)


&nbsp;&nbsp;&nbsp; Dim deviceDic As New Dictionary(Of Integer, List(Of String))
&nbsp;&nbsp;&nbsp; ' Invalid
&nbsp;&nbsp;&nbsp; deviceDic.Add(0, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Processor
&nbsp;&nbsp;&nbsp; deviceDic.Add(1, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Memory
&nbsp;&nbsp;&nbsp; deviceDic.Add(2, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Disk Device
&nbsp;&nbsp;&nbsp; deviceDic.Add(3, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Network Adapter
&nbsp;&nbsp;&nbsp; deviceDic.Add(4, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Audio Adapter
&nbsp;&nbsp;&nbsp; deviceDic.Add(5, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Docking Station
&nbsp;&nbsp;&nbsp; deviceDic.Add(6, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Mobile Broadband
&nbsp;&nbsp;&nbsp; deviceDic.Add(7, New List(Of String))
&nbsp;&nbsp;&nbsp; ' Bluetooth
&nbsp;&nbsp;&nbsp; deviceDic.Add(8, New List(Of String))
&nbsp;&nbsp;&nbsp; ' System BIOS
&nbsp;&nbsp;&nbsp; deviceDic.Add(9, New List(Of String))


&nbsp;&nbsp;&nbsp; For i As Integer = 0 To (hardwareIdString.Length / 8) - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Case hardwareIdString.Substring((i * 8), 4)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0100&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(1).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0200&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(2).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0300&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(3).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0400&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(4).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0500&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(5).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0600&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(6).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0700&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(7).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0800&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(8).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Case &quot;0900&quot;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; deviceDic(9).Add(hardwareIdString.Substring(((i * 8) &#43; 4), 4))
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Select
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Select
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; Return deviceDic
End Function


''' &lt;summary&gt;
''' Compare two devices to see the difference.
''' The granularity for the difference is 0.1
''' &lt;/summary&gt;
''' &lt;param name=&quot;devDicBase&quot;&gt;Base Device Dictionary&lt;/param&gt;
''' &lt;param name=&quot;devDicNew&quot;&gt;New Device Dictionary&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Private Shared Function DiffDeviceDictionary( _
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal devDicBase As IDictionary(Of Integer, List(Of String)),
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal devDicNew As IDictionary(Of Integer, List(Of String))) As Double


&nbsp;&nbsp;&nbsp; ' Component Weight in Percentage, updated per the business logic.
&nbsp;&nbsp;&nbsp; ' 0 - Invalid - 0%
&nbsp;&nbsp;&nbsp; ' 1 - Processor - 10%
&nbsp;&nbsp;&nbsp; ' 2 - Memory - 10%
&nbsp;&nbsp;&nbsp; ' 3 - Disk Device - 20%
&nbsp;&nbsp;&nbsp; ' 4 - Network Adapter - 10%
&nbsp;&nbsp;&nbsp; ' 5 - Audio Adapater - 10%
&nbsp;&nbsp;&nbsp; ' 6 - Docking Station - 5%
&nbsp;&nbsp;&nbsp; ' 7 - Mobile Broadband - 10%
&nbsp;&nbsp;&nbsp; ' 8 - Bluetooth - 5%
&nbsp;&nbsp;&nbsp; ' 9 - System BIOS - 20%
&nbsp;&nbsp;&nbsp; Dim compWeightPercentage As Integer() = New Integer() {0, 10, 10, 20, 10, 10, 5, 10, 5, 20}


&nbsp;&nbsp;&nbsp; Dim diffValue As Double = 0
&nbsp;&nbsp;&nbsp; For i As Integer = 1 To 10 - 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim diffCount As Integer = (devDicBase(i).Count - devDicNew(i).Count)


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' the base component size is bigger than the New one.
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (diffCount &gt;= 0) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each component As String In devDicNew(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not devDicBase(i).Contains(component)) Then
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;diffCount &#43;= 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Each component As String In devDicBase(i)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If (Not devDicNew(i).Contains(component)) Then
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffCount &#43;= 1
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; diffValue &#43;= (diffCount * compWeightPercentage(i))
&nbsp;&nbsp;&nbsp; Next


&nbsp;&nbsp;&nbsp; Return diffValue / 100
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph"><b style=""></b></p>
<h2>More Information</h2>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
