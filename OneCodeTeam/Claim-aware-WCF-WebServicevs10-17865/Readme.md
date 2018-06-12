# Claim-aware WCF WebService[vs10] (VBSharePointCallClaimsAwareWCF)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* SharePoint
## Topics
* SharePoint
* web service
* SAF
## IsPublished
* True
## ModifiedDate
* 2012-07-22 07:46:54
## Description

<h1><span style="">How to custom claim-aware WCF Web Service for SharePoint 2010 </span>
(<span style="">VBSharePointCallClaimsAwareWCF</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code will demonstrate how to call a Claims-Aware WCF Service from a SharePoint 2010 Claims Site. We use Service Application Framework (SAF) to host WCF Web Service in IIS.<span style="">&nbsp;
</span>On the caller's side, we need to use CreateChannelActingAsLoggedOnUser method to send the Claim based SharePoint Logged-on user's security token to our custom web service.<span style="">&nbsp;
</span>In our custom WCF web service, we need to use System.Threading.Thread.CurrentPrincipal.Identity to get the claim based security token.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal"><span style="">First, make sure you have created a Claims-Aware Site.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span> <img src="/site/view/file/62039/1/image.png" alt="" width="593" height="203" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the VBSharePointCallClaimsAwareWCF.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: After that right-click the &quot;VBSharePointCallClaimsAwareWCF&quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="line-height:normal"><span style=""><br>
Step 3: Run the AppInstaller.ps1 to install service and service proxy.<br>
</span><span lang="EN" style="">Here's what our service application looks like in the &quot;Manage Service Applications&quot; UX:<span style="color:blue"><br>
</span></span><span style=""><img src="/site/view/file/62040/1/image.png" alt="" width="730" height="373" align="middle">
</span><span lang="EN" style=""></span></p>
<p><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">And here's what it looks like in IIS Manager (on a server where the Calculator service instance has been started):
</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><img src="/site/view/file/62041/1/image.png" alt="" width="562" height="347" align="middle">
</span><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><br>
</span><span style="">Step 4: Visit the test page through the link in your browser:</span>
<span style=""><span style="">&nbsp;</span>yoursite/_layouts/customservice/test.aspx.<br>
<span style=""><img src="/site/view/file/62042/1/image.png" alt="" width="720" height="106" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a VB &quot;Empty</span> <span style="">SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;VBSharePointCallClaimsAwareWCF&quot;.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""></span></p>
<p class="MsoNormal"><span style="">Step 2: In the Solution Explorer, right-click the project.<br>
First, we will add the Mapped Folder follow the steps below.<br>
Select &quot;Add SharePoint Mapped Folder&quot;.<br>
We click &quot;CONFIG&quot; then select &quot;POWERSHELL&quot; then double-click the &quot;Registration&quot;, it is used to register our CMD lets.<br>
We click &quot;TEMPLATE&quot; then double-click the &quot;LAYOUTS&quot;. It is used to deploy our test page.<br>
We click &quot;TEMPLATE&quot; then double-click the &quot;SQL&quot;. It is used to store script
</span><span style="">t</span><span style="">o associate with a service database.<br>
We double-click the &quot;WebClients&quot;. It is used to </span><span style="">store</span><span style=""> client-side configuration file.<br>
We double-click the &quot;WebServices&quot;. It is used to</span><span style=""> store</span><span style=""> Services file
</span><span style="">(.svc)</span><span style=""> and service-side configuration file.<br>
<br>
After that, we will add two folders for the organization of services and client code.<span style="">&nbsp;
</span>We named them &quot;Service&quot; and &quot;Client&quot;. </span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 3: We'll start by building a WCF service with two single methods, the &quot;Add&quot; method and &quot;HelloWorld&quot; method.</span>
<span style="">Here's the service contract: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;ServiceContract()&gt; _
   Public Interface ICustomServiceContract
       &lt;OperationContractAttribute(Name:=&quot;Add&quot;)&gt; _
       Function Add(ByVal a As Integer, ByVal b As Integer) As Integer


       &lt;OperationContractAttribute(Name:=&quot;HelloWorld&quot;)&gt; _
       Function HelloWorld() As String
   End Interface

</pre>
<pre id="codePreview" class="vb">
&lt;ServiceContract()&gt; _
   Public Interface ICustomServiceContract
       &lt;OperationContractAttribute(Name:=&quot;Add&quot;)&gt; _
       Function Add(ByVal a As Integer, ByVal b As Integer) As Integer


       &lt;OperationContractAttribute(Name:=&quot;HelloWorld&quot;)&gt; _
       Function HelloWorld() As String
   End Interface

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Here's the contract implementation in CustomServiceApplication.cs:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICustomServiceContract.Add
           DemandAccess(CustomServiceAccessRights.Add)
           Return a &#43; b
       End Function


       Public Function HelloWorld() As String Implements ICustomServiceContract.HelloWorld
           DemandAccess(CustomServiceAccessRights.Hello)
           Dim id As String = GetIdentityClass.GetIdentity()


           Return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; & id
       End Function

</pre>
<pre id="codePreview" class="vb">
Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICustomServiceContract.Add
           DemandAccess(CustomServiceAccessRights.Add)
           Return a &#43; b
       End Function


       Public Function HelloWorld() As String Implements ICustomServiceContract.HelloWorld
           DemandAccess(CustomServiceAccessRights.Hello)
           Dim id As String = GetIdentityClass.GetIdentity()


           Return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; & id
       End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The GetIdentityClass class is used to get SharePoint Logged-on user's security Token.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private Const IdentityClaimType As String = &quot;http://schemas.microsoft.com/sharepoint/2009/08/claims/userid&quot;


        Public Shared Function GetIdentity() As String
            'Identity Name
            Dim identityName As String = [String].Empty
            'Get the Identity of the Current Principal
            Dim claimsIdentity As IClaimsIdentity = TryCast(System.Threading.Thread.CurrentPrincipal.Identity, IClaimsIdentity)


            If claimsIdentity IsNot Nothing Then
                ' claim
                For Each claim As Claim In claimsIdentity.Claims
                    If [String].Equals(IdentityClaimType, claim.ClaimType, StringComparison.OrdinalIgnoreCase) Then
                        identityName = claim.Value
                        Exit For
                    End If
                Next
            Else
                identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name
            End If


            Return identityName
        End Function

</pre>
<pre id="codePreview" class="vb">
Private Const IdentityClaimType As String = &quot;http://schemas.microsoft.com/sharepoint/2009/08/claims/userid&quot;


        Public Shared Function GetIdentity() As String
            'Identity Name
            Dim identityName As String = [String].Empty
            'Get the Identity of the Current Principal
            Dim claimsIdentity As IClaimsIdentity = TryCast(System.Threading.Thread.CurrentPrincipal.Identity, IClaimsIdentity)


            If claimsIdentity IsNot Nothing Then
                ' claim
                For Each claim As Claim In claimsIdentity.Claims
                    If [String].Equals(IdentityClaimType, claim.ClaimType, StringComparison.OrdinalIgnoreCase) Then
                        identityName = claim.Value
                        Exit For
                    End If
                Next
            Else
                identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name
            End If


            Return identityName
        End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 4: <span style="color:black">Configure the service by specifying endpoint information and other behavior information.</span>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;
    &lt;services&gt;
      &lt;service
        name=&quot;CustomService.CustomService.CustomServiceApplication&quot;&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpSecureBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpsBinding&quot; /&gt;
      &lt;/service&gt;
    &lt;/services&gt;
    &lt;bindings&gt;
      &lt;customBinding&gt;
        &lt;binding
          name=&quot;CustomServiceTcpBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot;
            allowInsecureTransport=&quot;true&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;tcpTransport
            maxReceivedMessageSize=&quot;2162688&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceTcpSecureBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot; /&gt;
          &lt;sslStreamSecurity /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;tcpTransport
            maxReceivedMessageSize=&quot;2162688&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceHttpBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot;
            allowInsecureTransport=&quot;true&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;httpTransport
            maxReceivedMessageSize=&quot;2162688&quot;
            authenticationScheme=&quot;Anonymous&quot;
            useDefaultWebProxy=&quot;false&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceHttpsBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;httpsTransport
            maxReceivedMessageSize=&quot;2162688&quot;
            authenticationScheme=&quot;Anonymous&quot;
            useDefaultWebProxy=&quot;false&quot; /&gt;
        &lt;/binding&gt;
      &lt;/customBinding&gt;
    &lt;/bindings&gt;
  &lt;/system.serviceModel&gt;
  &lt;system.webServer&gt;
    &lt;security&gt;
      &lt;authentication&gt;
        &lt;anonymousAuthentication enabled=&quot;true&quot; /&gt;
        &lt;windowsAuthentication enabled=&quot;false&quot; /&gt;
      &lt;/authentication&gt;
    &lt;/security&gt;
  &lt;/system.webServer&gt;
&lt;/configuration&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
  &lt;system.serviceModel&gt;
    &lt;services&gt;
      &lt;service
        name=&quot;CustomService.CustomService.CustomServiceApplication&quot;&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpSecureBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpsBinding&quot; /&gt;
      &lt;/service&gt;
    &lt;/services&gt;
    &lt;bindings&gt;
      &lt;customBinding&gt;
        &lt;binding
          name=&quot;CustomServiceTcpBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot;
            allowInsecureTransport=&quot;true&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;tcpTransport
            maxReceivedMessageSize=&quot;2162688&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceTcpSecureBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot; /&gt;
          &lt;sslStreamSecurity /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;tcpTransport
            maxReceivedMessageSize=&quot;2162688&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceHttpBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot;
            allowInsecureTransport=&quot;true&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;httpTransport
            maxReceivedMessageSize=&quot;2162688&quot;
            authenticationScheme=&quot;Anonymous&quot;
            useDefaultWebProxy=&quot;false&quot; /&gt;
        &lt;/binding&gt;
        &lt;binding
          name=&quot;CustomServiceHttpsBinding&quot;&gt;
          &lt;security
            authenticationMode=&quot;IssuedTokenOverTransport&quot; /&gt;
          &lt;binaryMessageEncoding&gt;
            &lt;readerQuotas
              maxStringContentLength=&quot;1048576&quot;
              maxArrayLength=&quot;2097152&quot; /&gt;
          &lt;/binaryMessageEncoding&gt;
          &lt;httpsTransport
            maxReceivedMessageSize=&quot;2162688&quot;
            authenticationScheme=&quot;Anonymous&quot;
            useDefaultWebProxy=&quot;false&quot; /&gt;
        &lt;/binding&gt;
      &lt;/customBinding&gt;
    &lt;/bindings&gt;
  &lt;/system.serviceModel&gt;
  &lt;system.webServer&gt;
    &lt;security&gt;
      &lt;authentication&gt;
        &lt;anonymousAuthentication enabled=&quot;true&quot; /&gt;
        &lt;windowsAuthentication enabled=&quot;false&quot; /&gt;
      &lt;/authentication&gt;
    &lt;/security&gt;
  &lt;/system.webServer&gt;
&lt;/configuration&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Since we'll be hosting this service in IIS, we need a svc file to enable the service to be activated. I've named it CustomService.svc:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;%@ServiceHost Language=&quot;VB&quot; Debug=&quot;true&quot; 
               Service=&quot;CustomService.CustomService.CustomServiceApplication, CustomService, Version=1.0.0.0, 
Culture=neutral, PublicKeyToken=1f05333457a126f9&quot; 
               Factory=&quot;CustomService.CustomService.CustomServiceHostFactory, CustomService, Version=1.0.0.0, 
Culture=neutral, PublicKeyToken=1f05333457a126f9&quot; %&gt;

</pre>
<pre id="codePreview" class="vb">
&lt;%@ServiceHost Language=&quot;VB&quot; Debug=&quot;true&quot; 
               Service=&quot;CustomService.CustomService.CustomServiceApplication, CustomService, Version=1.0.0.0, 
Culture=neutral, PublicKeyToken=1f05333457a126f9&quot; 
               Factory=&quot;CustomService.CustomService.CustomServiceHostFactory, CustomService, Version=1.0.0.0, 
Culture=neutral, PublicKeyToken=1f05333457a126f9&quot; %&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For this, we create a custom service Host Factory. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Friend NotInheritable Class CustomServiceHostFactory
       Inherits ServiceHostFactory
       Public Overrides Function CreateServiceHost(ByVal constructorString As String, ByVal baseAddresses As Uri()) As ServiceHostBase
           Dim serviceHost As New ServiceHost(GetType(CustomServiceApplication), baseAddresses)
           ' configure the service host for claims authentication
           serviceHost.Configure(SPServiceAuthenticationMode.Claims)
           Return serviceHost
       End Function
   End Class

</pre>
<pre id="codePreview" class="vb">
Friend NotInheritable Class CustomServiceHostFactory
       Inherits ServiceHostFactory
       Public Overrides Function CreateServiceHost(ByVal constructorString As String, ByVal baseAddresses As Uri()) As ServiceHostBase
           Dim serviceHost As New ServiceHost(GetType(CustomServiceApplication), baseAddresses)
           ' configure the service host for claims authentication
           serviceHost.Configure(SPServiceAuthenticationMode.Claims)
           Return serviceHost
       End Function
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 5:</span><span lang="EN" style=""> We'll integrate our service with the SharePoint management experience so that SharePoint administrators can choose which machines in the server farm should
 host the service.</span><span lang="EN" style=""> </span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class CustomService
       Inherits SPIisWebService
       Implements IServiceAdministration


       ''' &lt;summary&gt;
       ''' Internal use only.
       ''' &lt;/summary&gt;
       Public Sub New()
       End Sub


       ''' &lt;summary&gt;
       ''' Creates a new service proxy.
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;farm&quot;&gt;The parent farm object.&lt;/param&gt;
       Public Sub New(ByVal farm As SPFarm)
           MyBase.New(farm)
       End Sub


#Region &quot;IServiceAdministration Members&quot;
       Public Function CreateApplication(ByVal name As String, ByVal serviceApplicationType As System.Type, 
ByVal provisioningContext As Microsoft.SharePoint.Administration.SPServiceProvisioningContext)
 As Microsoft.SharePoint.Administration.SPServiceApplication Implements 
Microsoft.SharePoint.Administration.IServiceAdministration.CreateApplication
           '#Region &quot;validation&quot;
      ...
   End Class

</pre>
<pre id="codePreview" class="vb">
Public Class CustomService
       Inherits SPIisWebService
       Implements IServiceAdministration


       ''' &lt;summary&gt;
       ''' Internal use only.
       ''' &lt;/summary&gt;
       Public Sub New()
       End Sub


       ''' &lt;summary&gt;
       ''' Creates a new service proxy.
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;farm&quot;&gt;The parent farm object.&lt;/param&gt;
       Public Sub New(ByVal farm As SPFarm)
           MyBase.New(farm)
       End Sub


#Region &quot;IServiceAdministration Members&quot;
       Public Function CreateApplication(ByVal name As String, ByVal serviceApplicationType As System.Type, 
ByVal provisioningContext As Microsoft.SharePoint.Administration.SPServiceProvisioningContext)
 As Microsoft.SharePoint.Administration.SPServiceApplication Implements 
Microsoft.SharePoint.Administration.IServiceAdministration.CreateApplication
           '#Region &quot;validation&quot;
      ...
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span lang="EN" style="">Next, we'll create the object that represents an instance of our Calculator service hosted on a specific server (SPServer) in the server farm:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public Class CustomServiceInstance
       Inherits SPIisWebServiceInstance
       Public Sub New()
       End Sub


       Public Sub New(ByVal server As SPServer, ByVal service As CustomService)
           MyBase.New(server, service)
       End Sub


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service&quot;
           End Get
       End Property
   End Class

</pre>
<pre id="codePreview" class="vb">
Public Class CustomServiceInstance
       Inherits SPIisWebServiceInstance
       Public Sub New()
       End Sub


       Public Sub New(ByVal server As SPServer, ByVal service As CustomService)
           MyBase.New(server, service)
       End Sub


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service&quot;
           End Get
       End Property
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;</span>A common SQL Server database provisioning infrastructure (to use your own database to store data)
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;System.Runtime.InteropServices.Guid(&quot;FE92B481-00B1-4ad7-9E89-2DFEF629F38A&quot;)&gt; _
   Friend NotInheritable Class CustomServiceDatabase
       Inherits SPDatabase
       Public Sub New()
       End Sub


       Friend Sub New(ByVal dbParameters As SPDatabaseParameters)
           MyBase.New(dbParameters)
           Me.Status = SPObjectStatus.Disabled
       End Sub


       Public Overrides Sub Provision()
           ' stop if DB is already provisioned
           If SPObjectStatus.Online = Me.Status Then
               Return
           End If


           Me.Status = SPObjectStatus.Provisioning
           Me.Update()


           Dim options As New Dictionary(Of String, Boolean)(1)
           options.Add(SqlDatabaseOption(CInt(DatabaseOptions.AutoClose)), False)


           SPDatabase.Provision(Me.DatabaseConnectionString, SPUtility.GetGenericSetupPath(&quot;Template\sql\CustomService.sql&quot;), options)


           Me.Status = SPObjectStatus.Online
           Me.Update()
       End Sub


       Friend Sub GrantApplicationPoolAccess(ByVal processSecurityIdentifier As SecurityIdentifier)
           Me.GrantAccess(processSecurityIdentifier, &quot;db_owner&quot;)
       End Sub


   End Class

</pre>
<pre id="codePreview" class="vb">
&lt;System.Runtime.InteropServices.Guid(&quot;FE92B481-00B1-4ad7-9E89-2DFEF629F38A&quot;)&gt; _
   Friend NotInheritable Class CustomServiceDatabase
       Inherits SPDatabase
       Public Sub New()
       End Sub


       Friend Sub New(ByVal dbParameters As SPDatabaseParameters)
           MyBase.New(dbParameters)
           Me.Status = SPObjectStatus.Disabled
       End Sub


       Public Overrides Sub Provision()
           ' stop if DB is already provisioned
           If SPObjectStatus.Online = Me.Status Then
               Return
           End If


           Me.Status = SPObjectStatus.Provisioning
           Me.Update()


           Dim options As New Dictionary(Of String, Boolean)(1)
           options.Add(SqlDatabaseOption(CInt(DatabaseOptions.AutoClose)), False)


           SPDatabase.Provision(Me.DatabaseConnectionString, SPUtility.GetGenericSetupPath(&quot;Template\sql\CustomService.sql&quot;), options)


           Me.Status = SPObjectStatus.Online
           Me.Update()
       End Sub


       Friend Sub GrantApplicationPoolAccess(ByVal processSecurityIdentifier As SecurityIdentifier)
           Me.GrantAccess(processSecurityIdentifier, &quot;db_owner&quot;)
       End Sub


   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span lang="EN" style="">The code of the script as shown below:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">mysql</span>
<pre class="hidden">
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SampleTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [dbo].[SampleTable]
(
    [PartitionId] [uniqueidentifier] NOT NULL ,
    [ItemKey] [uniqueidentifier] NOT NULL ,
    [ItemValue] [int] NULL ,


    CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED ( [PartitionId], [ItemKey] )
)
GO


INSERT INTO dbo.SampleTable
(
    PartitionId,
    ItemKey,
    ItemValue
)
VALUES
(
    '00000000-0000-0000-0000-000000000000',
    '00000000-0000-0000-0000-000000000000',
    0
)
GO


SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

</pre>
<pre id="codePreview" class="mysql">
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO


if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SampleTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [dbo].[SampleTable]
(
    [PartitionId] [uniqueidentifier] NOT NULL ,
    [ItemKey] [uniqueidentifier] NOT NULL ,
    [ItemValue] [int] NULL ,


    CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED ( [PartitionId], [ItemKey] )
)
GO


INSERT INTO dbo.SampleTable
(
    PartitionId,
    ItemKey,
    ItemValue
)
VALUES
(
    '00000000-0000-0000-0000-000000000000',
    '00000000-0000-0000-0000-000000000000',
    0
)
GO


SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Here's the Service Application implementation in CustomServiceApplication.cs:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public NotInheritable Class CustomServiceApplication
       Inherits SPIisWebServiceApplication
       Implements ICustomServiceContract


       &lt;Persisted()&gt; _
       Private _setting As Integer


       &lt;Persisted()&gt; _
       Private _database As CustomServiceDatabase


#Region &quot;constructors&quot;
       Public Sub New()
       End Sub


       Private Sub New(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As
 SPIisWebServiceApplicationPool, ByVal database As CustomServiceDatabase)
           MyBase.New(name, service, applicationPool)
           If database Is Nothing Then
               Throw New ArgumentNullException(&quot;database&quot;)
           End If


           _database = database
       End Sub
#End Region


       Public Shared Function Create(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As
 SPIisWebServiceApplicationPool, ByVal databaseParameters As SPDatabaseParameters) As CustomServiceApplication
           '#Region &quot;validation&quot;
           If name Is Nothing Then
               Throw New ArgumentNullException(&quot;name&quot;)
           End If


           If service Is Nothing Then
               Throw New ArgumentNullException(&quot;service&quot;)
           End If


           If applicationPool Is Nothing Then
               Throw New ArgumentNullException(&quot;applicationPool&quot;)
           End If


           If databaseParameters Is Nothing Then
               Throw New ArgumentNullException(&quot;databaseParameters&quot;)
           End If
           '#End Region


           ' Register the database
           Dim database As New CustomServiceDatabase(databaseParameters)
           database.Update()


           ' Create and persist the service application
           Dim serviceApplication As New CustomServiceApplication(name, service, applicationPool, database)
           serviceApplication.Update()


           ' register supported endpoints
           serviceApplication.AddServiceEndpoint(&quot;tcp&quot;, SPIisWebServiceBindingType.NetTcp)
           serviceApplication.AddServiceEndpoint(&quot;tcp-ssl&quot;, SPIisWebServiceBindingType.NetTcp, &quot;secure&quot;)
           serviceApplication.AddServiceEndpoint(&quot;http&quot;, SPIisWebServiceBindingType.Http)
           serviceApplication.AddServiceEndpoint(&quot;https&quot;, SPIisWebServiceBindingType.Https, &quot;secure&quot;)


           Return serviceApplication
       End Function


#Region &quot;Required serice app details...&quot;
       Protected Overrides ReadOnly Property DefaultEndpointName() As String
           Get
               Return &quot;http&quot;
           End Get
       End Property


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service Application&quot;
           End Get
       End Property


       ' The InstallPath property tells SharePoint where to find our service files
       Protected Overrides ReadOnly Property InstallPath() As String
           Get
               Return SPUtility.GetGenericSetupPath(&quot;WebServices\CustomService&quot;)
           End Get
       End Property


       ' The VirtualPath property tells SharePoint the URI of your service endpoint relative to the InstallPath directory, in this case, CustomService.svc&#157;. 
       Protected Overrides ReadOnly Property VirtualPath() As String
           Get
               Return &quot;CustomService.svc&quot;
           End Get
       End Property


       Public Overrides ReadOnly Property ApplicationClassId() As Guid
           Get
               Return New Guid(&quot;A12A5C1C-9784-4118-BF9D-B58B24337E34&quot;)
           End Get
       End Property


       Public Overrides ReadOnly Property ApplicationVersion() As Version
           Get
               Return New Version(&quot;1.0.0.0&quot;)
           End Get
       End Property
#End Region


       ''' &lt;summary&gt;
       ''' Setting persisted in configuration database.
       ''' &lt;/summary&gt;
       Public Property Setting() As Integer
           Get
               Return _setting
           End Get


           ' NOTE: Since this method requires an access check, it must impersonate the client.
           &lt;OperationBehavior(Impersonation:=ImpersonationOption.Required)&gt; _
           Set(ByVal value As Integer)
               ' Demand the &quot;Write&quot; custom administration right
               DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write)


               _setting = value
           End Set
       End Property


       Public Overrides Sub Provision()
           _database.Provision()
           MyBase.Provision()
       End Sub


       Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
           MyBase.Unprovision(deleteData)
           _database.Unprovision()
       End Sub


       Protected Overrides Sub OnProcessIdentityChanged(ByVal processSecurityIdentifier As SecurityIdentifier)
           MyBase.OnProcessIdentityChanged(processSecurityIdentifier)
           _database.GrantApplicationPoolAccess(processSecurityIdentifier)
       End Sub


       ''' &lt;summary&gt;
       ''' Target location admin is sent to from within CA when clicking on Service App or 
       ''' selecting it and picking Manage in the ribbon from CA &gt; Manage Service Apps page.
       ''' &lt;/summary&gt;
       Public Overrides ReadOnly Property ManageLink() As SPAdministrationLink
           Get
               Return New SPAdministrationLink(&quot;/_admin/ManageSample?id=&quot; & Me.Id.ToString())
           End Get
       End Property


       ''' &lt;summary&gt;
       ''' Target location admin is sent to from within CA when selecting the service all
       ''' and picking Properties in the ribbon from CA &gt; Manage Service Apps page.
       ''' &lt;/summary&gt;
       Public Overrides ReadOnly Property PropertiesLink() As SPAdministrationLink
           Get
               Return New SPAdministrationLink(&quot;/_admin/EditSample?id=&quot; & Me.Id.ToString())
           End Get
       End Property


#Region &quot;Custom Permissions & Access Rights&quot;
       ''' &lt;summary&gt;
       ''' Override the default named administration access rights to include custom rights.
       ''' These options will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Administrators
       ''' &lt;/summary&gt;
       ''' &lt;remarks&gt;The returned items will be used for display in the ACL editor UI 
       ''' control and the PowerShell Grant and Revoke Cmdlets.&lt;/remarks&gt;
       Protected Overrides ReadOnly Property AdministrationAccessRights() As SPNamedCentralAdministrationRights()
           Get
               Return New SPNamedCentralAdministrationRights() {SPNamedCentralAdministrationRights.FullControl,
 New SPNamedCentralAdministrationRights(&quot;Modify&quot;, SPCentralAdministrationRights.Read Or CustomServiceCentralAdministrationRights.Write), SPNamedCentralAdministrationRights.Read}
           End Get
       End Property


       ''' &lt;summary&gt;
       ''' Override the default access rights to include custom rights.
       ''' These optiosn will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Permissions
       ''' &lt;/summary&gt;
       ''' &lt;remarks&gt;These can be used to ensure the caller has specific rights granted to it, and enforced in 
       ''' the caller below using the DemandAccess() method.&lt;/remarks&gt;
       Protected Overrides ReadOnly Property AccessRights() As SPNamedIisWebServiceApplicationRights()
           Get
               Return New SPNamedIisWebServiceApplicationRights() {SPNamedIisWebServiceApplicationRights.FullControl, 
New SPNamedIisWebServiceApplicationRights(&quot;Add&quot;, CustomServiceAccessRights.Add), 
New SPNamedIisWebServiceApplicationRights(&quot;Subtract&quot;, CustomServiceAccessRights.Subtract), SPNamedIisWebServiceApplicationRights.Read}
           End Get
       End Property
#End Region


#Region &quot;All the methods that do the work within the service application. {ISampleWebServiceContract Members}&quot;
       Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICustomServiceContract.Add
           DemandAccess(CustomServiceAccessRights.Add)
           Return a &#43; b
       End Function


       Public Function Subtract(ByVal a As Integer, ByVal b As Integer) As Integer
           DemandAccess(CustomServiceAccessRights.Subtract)
           Return a - b
       End Function


       Public Function HelloWorld() As String Implements ICustomServiceContract.HelloWorld
           DemandAccess(CustomServiceAccessRights.Hello)
           Dim id As String = GetIdentityClass.GetIdentity()


           Return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; & id
       End Function


#End Region


   End Class

</pre>
<pre id="codePreview" class="vb">
Public NotInheritable Class CustomServiceApplication
       Inherits SPIisWebServiceApplication
       Implements ICustomServiceContract


       &lt;Persisted()&gt; _
       Private _setting As Integer


       &lt;Persisted()&gt; _
       Private _database As CustomServiceDatabase


#Region &quot;constructors&quot;
       Public Sub New()
       End Sub


       Private Sub New(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As
 SPIisWebServiceApplicationPool, ByVal database As CustomServiceDatabase)
           MyBase.New(name, service, applicationPool)
           If database Is Nothing Then
               Throw New ArgumentNullException(&quot;database&quot;)
           End If


           _database = database
       End Sub
#End Region


       Public Shared Function Create(ByVal name As String, ByVal service As CustomService, ByVal applicationPool As
 SPIisWebServiceApplicationPool, ByVal databaseParameters As SPDatabaseParameters) As CustomServiceApplication
           '#Region &quot;validation&quot;
           If name Is Nothing Then
               Throw New ArgumentNullException(&quot;name&quot;)
           End If


           If service Is Nothing Then
               Throw New ArgumentNullException(&quot;service&quot;)
           End If


           If applicationPool Is Nothing Then
               Throw New ArgumentNullException(&quot;applicationPool&quot;)
           End If


           If databaseParameters Is Nothing Then
               Throw New ArgumentNullException(&quot;databaseParameters&quot;)
           End If
           '#End Region


           ' Register the database
           Dim database As New CustomServiceDatabase(databaseParameters)
           database.Update()


           ' Create and persist the service application
           Dim serviceApplication As New CustomServiceApplication(name, service, applicationPool, database)
           serviceApplication.Update()


           ' register supported endpoints
           serviceApplication.AddServiceEndpoint(&quot;tcp&quot;, SPIisWebServiceBindingType.NetTcp)
           serviceApplication.AddServiceEndpoint(&quot;tcp-ssl&quot;, SPIisWebServiceBindingType.NetTcp, &quot;secure&quot;)
           serviceApplication.AddServiceEndpoint(&quot;http&quot;, SPIisWebServiceBindingType.Http)
           serviceApplication.AddServiceEndpoint(&quot;https&quot;, SPIisWebServiceBindingType.Https, &quot;secure&quot;)


           Return serviceApplication
       End Function


#Region &quot;Required serice app details...&quot;
       Protected Overrides ReadOnly Property DefaultEndpointName() As String
           Get
               Return &quot;http&quot;
           End Get
       End Property


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service Application&quot;
           End Get
       End Property


       ' The InstallPath property tells SharePoint where to find our service files
       Protected Overrides ReadOnly Property InstallPath() As String
           Get
               Return SPUtility.GetGenericSetupPath(&quot;WebServices\CustomService&quot;)
           End Get
       End Property


       ' The VirtualPath property tells SharePoint the URI of your service endpoint relative to the InstallPath directory, in this case, CustomService.svc&#157;. 
       Protected Overrides ReadOnly Property VirtualPath() As String
           Get
               Return &quot;CustomService.svc&quot;
           End Get
       End Property


       Public Overrides ReadOnly Property ApplicationClassId() As Guid
           Get
               Return New Guid(&quot;A12A5C1C-9784-4118-BF9D-B58B24337E34&quot;)
           End Get
       End Property


       Public Overrides ReadOnly Property ApplicationVersion() As Version
           Get
               Return New Version(&quot;1.0.0.0&quot;)
           End Get
       End Property
#End Region


       ''' &lt;summary&gt;
       ''' Setting persisted in configuration database.
       ''' &lt;/summary&gt;
       Public Property Setting() As Integer
           Get
               Return _setting
           End Get


           ' NOTE: Since this method requires an access check, it must impersonate the client.
           &lt;OperationBehavior(Impersonation:=ImpersonationOption.Required)&gt; _
           Set(ByVal value As Integer)
               ' Demand the &quot;Write&quot; custom administration right
               DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write)


               _setting = value
           End Set
       End Property


       Public Overrides Sub Provision()
           _database.Provision()
           MyBase.Provision()
       End Sub


       Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
           MyBase.Unprovision(deleteData)
           _database.Unprovision()
       End Sub


       Protected Overrides Sub OnProcessIdentityChanged(ByVal processSecurityIdentifier As SecurityIdentifier)
           MyBase.OnProcessIdentityChanged(processSecurityIdentifier)
           _database.GrantApplicationPoolAccess(processSecurityIdentifier)
       End Sub


       ''' &lt;summary&gt;
       ''' Target location admin is sent to from within CA when clicking on Service App or 
       ''' selecting it and picking Manage in the ribbon from CA &gt; Manage Service Apps page.
       ''' &lt;/summary&gt;
       Public Overrides ReadOnly Property ManageLink() As SPAdministrationLink
           Get
               Return New SPAdministrationLink(&quot;/_admin/ManageSample?id=&quot; & Me.Id.ToString())
           End Get
       End Property


       ''' &lt;summary&gt;
       ''' Target location admin is sent to from within CA when selecting the service all
       ''' and picking Properties in the ribbon from CA &gt; Manage Service Apps page.
       ''' &lt;/summary&gt;
       Public Overrides ReadOnly Property PropertiesLink() As SPAdministrationLink
           Get
               Return New SPAdministrationLink(&quot;/_admin/EditSample?id=&quot; & Me.Id.ToString())
           End Get
       End Property


#Region &quot;Custom Permissions & Access Rights&quot;
       ''' &lt;summary&gt;
       ''' Override the default named administration access rights to include custom rights.
       ''' These options will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Administrators
       ''' &lt;/summary&gt;
       ''' &lt;remarks&gt;The returned items will be used for display in the ACL editor UI 
       ''' control and the PowerShell Grant and Revoke Cmdlets.&lt;/remarks&gt;
       Protected Overrides ReadOnly Property AdministrationAccessRights() As SPNamedCentralAdministrationRights()
           Get
               Return New SPNamedCentralAdministrationRights() {SPNamedCentralAdministrationRights.FullControl,
 New SPNamedCentralAdministrationRights(&quot;Modify&quot;, SPCentralAdministrationRights.Read Or CustomServiceCentralAdministrationRights.Write), SPNamedCentralAdministrationRights.Read}
           End Get
       End Property


       ''' &lt;summary&gt;
       ''' Override the default access rights to include custom rights.
       ''' These optiosn will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Permissions
       ''' &lt;/summary&gt;
       ''' &lt;remarks&gt;These can be used to ensure the caller has specific rights granted to it, and enforced in 
       ''' the caller below using the DemandAccess() method.&lt;/remarks&gt;
       Protected Overrides ReadOnly Property AccessRights() As SPNamedIisWebServiceApplicationRights()
           Get
               Return New SPNamedIisWebServiceApplicationRights() {SPNamedIisWebServiceApplicationRights.FullControl, 
New SPNamedIisWebServiceApplicationRights(&quot;Add&quot;, CustomServiceAccessRights.Add), 
New SPNamedIisWebServiceApplicationRights(&quot;Subtract&quot;, CustomServiceAccessRights.Subtract), SPNamedIisWebServiceApplicationRights.Read}
           End Get
       End Property
#End Region


#Region &quot;All the methods that do the work within the service application. {ISampleWebServiceContract Members}&quot;
       Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer Implements ICustomServiceContract.Add
           DemandAccess(CustomServiceAccessRights.Add)
           Return a &#43; b
       End Function


       Public Function Subtract(ByVal a As Integer, ByVal b As Integer) As Integer
           DemandAccess(CustomServiceAccessRights.Subtract)
           Return a - b
       End Function


       Public Function HelloWorld() As String Implements ICustomServiceContract.HelloWorld
           DemandAccess(CustomServiceAccessRights.Hello)
           Dim id As String = GetIdentityClass.GetIdentity()


           Return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; & id
       End Function


#End Region


   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 6:</span><span lang="EN" style=""> Now that we've created the classes that represent our Calculator service and service instances, we need an installation process to persist these classes
 into the SharePoint configuration database on a target server farm. We'll create a cmdlet named
<strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">New-</span></strong></span><span style="">CustomService</span><span lang="EN" style=""> that will take two required parameters: the name of the new service application, and the application pool that will
 host it. The cmdlet will then create the new service application and provision it. The first thing we'll do is create the
<strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">New-</span></strong> </span>
<span style="">CustomService</span><span lang="EN" style=""> cmdlet by subclassing
<strong><span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">SPCmdlet:</span></strong>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Cmdlet(VerbsLifecycle.Install, &quot;CustomService&quot;, SupportsShouldProcess:=True)&gt; _
    Public Class InstallCustomService
        Inherits SPCmdlet
        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function


        Protected Overrides Sub InternalProcessRecord()
            '#Region &quot;validation stuff&quot;


            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
            End If


            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
            End If


            '#End Region






            If ShouldProcess(&quot;Custom Service&quot;) Then
                ' ensure the custom service exists
                Dim service As CustomService = farm.Services.GetValue(Of CustomService)()


                ' if the service is NOT already installed, install it
                If service Is Nothing Then
                    ' create the service
                    service = New CustomService(farm)
                    service.Update()
                End If


                ' with the service added to the farm, see if there is a running instance on the server... 
                '   if not, create it
                Dim serverSvcInstance As New CustomServiceInstance(server, service)
                serverSvcInstance.Update(True)
            End If
        End Sub
    End Class


    &lt;Cmdlet(VerbsCommon.[New], &quot;CustomServiceApplication&quot;, SupportsShouldProcess:=True)&gt; _
    Public Class NewCustomServiceApplication
        Inherits SPCmdlet
        Private Const DbPrefix As String = &quot;CustomService&quot;


#Region &quot;Cmdlet Parameters&quot;
        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public Name As String


        ' The SPIisWebServiceApplicationPoolPipeBind parameter accepts a service
        ' application pool object, which can be created by the New-SPServiceApplicationPool
        ' cmdlet. Alternatively, an administration can use the Get-SPServiceApplicationPool
        ' cmdlet to select an existing service application pool to be used for the new
        ' service application.
        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public ApplicationPool As SPIisWebServiceApplicationPoolPipeBind


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseServer As String


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public FailoverDatabaseServer As String


        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseName As String


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseCredentials As PSCredential
#End Region


        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function


        ''' &lt;summary&gt;
        ''' The InternalProcessRecord method is where the work happens.
        ''' &lt;/summary&gt;
        Protected Overrides Sub InternalProcessRecord()
            '#Region &quot;validation stuff&quot;
            ' ensure can hit farm
            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit local server
            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit service application
            Dim service As CustomService = farm.Services.GetValue(Of CustomService)()
            If service Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;Custom Service not found (likely not installed).&quot;),
 ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit app pool
            Dim appPool As SPIisWebServiceApplicationPool = Me.ApplicationPool.Read()
            If appPool Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;Application pool not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit database
            Dim dbServer As String = Me.DatabaseServer
            If String.IsNullOrEmpty(dbServer) Then
                dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource
            End If
            '#End Region


            ' ensure a service application does not already exist
            Dim existingCustomServiceApp As CustomServiceApplication = service.Applications.GetValue(Of CustomServiceApplication)()
            If existingCustomServiceApp IsNot Nothing Then
                WriteError(New InvalidOperationException(&quot;Custom service application already exists.&quot;), 
ErrorCategory.ResourceExists, existingCustomServiceApp)
                SkipProcessCurrentRecord()
            End If


            ' get database credentials
            Dim dbUsername As String = Nothing
            Dim dbPassword As String = Nothing
            If DatabaseCredentials IsNot Nothing Then
                Dim dbCredential As NetworkCredential = CType(DatabaseCredentials, NetworkCredential)
                dbUsername = dbCredential.UserName
                dbPassword = dbCredential.Password
            End If


            Dim dbOptions As SPDatabaseParameterOptions = SPDatabaseParameterOptions.None


            ' get database name
            Dim dbName As String = DatabaseName
            If dbName Is Nothing Then
                dbName = &quot;CustomServiceDB&quot;
                dbOptions = SPDatabaseParameterOptions.GenerateUniqueName
            End If


            ' create settings for a new database
            Dim dbParameters As SPDatabaseParameters = SPDatabaseParameters.CreateParameters(
dbName, dbServer, dbUsername, dbPassword, FailoverDatabaseServer, dbOptions)


            ' create & provision the service application 
            If ShouldProcess(Me.Name) Then
                Dim serviceApp As CustomServiceApplication = CustomServiceApplication.Create(Me.Name, service, appPool, dbParameters)


                ' provision the service app
                serviceApp.Provision()


                ' writes the new service application object out to the PowerShell pipeline
                ' where it can be piped as input to the next cmdlet in the pipeline.
                WriteObject(serviceApp)
            End If
        End Sub
    End Class

</pre>
<pre id="codePreview" class="vb">
&lt;Cmdlet(VerbsLifecycle.Install, &quot;CustomService&quot;, SupportsShouldProcess:=True)&gt; _
    Public Class InstallCustomService
        Inherits SPCmdlet
        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function


        Protected Overrides Sub InternalProcessRecord()
            '#Region &quot;validation stuff&quot;


            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
            End If


            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
            End If


            '#End Region






            If ShouldProcess(&quot;Custom Service&quot;) Then
                ' ensure the custom service exists
                Dim service As CustomService = farm.Services.GetValue(Of CustomService)()


                ' if the service is NOT already installed, install it
                If service Is Nothing Then
                    ' create the service
                    service = New CustomService(farm)
                    service.Update()
                End If


                ' with the service added to the farm, see if there is a running instance on the server... 
                '   if not, create it
                Dim serverSvcInstance As New CustomServiceInstance(server, service)
                serverSvcInstance.Update(True)
            End If
        End Sub
    End Class


    &lt;Cmdlet(VerbsCommon.[New], &quot;CustomServiceApplication&quot;, SupportsShouldProcess:=True)&gt; _
    Public Class NewCustomServiceApplication
        Inherits SPCmdlet
        Private Const DbPrefix As String = &quot;CustomService&quot;


#Region &quot;Cmdlet Parameters&quot;
        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public Name As String


        ' The SPIisWebServiceApplicationPoolPipeBind parameter accepts a service
        ' application pool object, which can be created by the New-SPServiceApplicationPool
        ' cmdlet. Alternatively, an administration can use the Get-SPServiceApplicationPool
        ' cmdlet to select an existing service application pool to be used for the new
        ' service application.
        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public ApplicationPool As SPIisWebServiceApplicationPoolPipeBind


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseServer As String


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public FailoverDatabaseServer As String


        &lt;Parameter(Mandatory:=True)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseName As String


        &lt;Parameter(Mandatory:=False)&gt; _
        &lt;ValidateNotNullOrEmpty()&gt; _
        Public DatabaseCredentials As PSCredential
#End Region


        Protected Overrides Function RequireUserFarmAdmin() As Boolean
            Return True
        End Function


        ''' &lt;summary&gt;
        ''' The InternalProcessRecord method is where the work happens.
        ''' &lt;/summary&gt;
        Protected Overrides Sub InternalProcessRecord()
            '#Region &quot;validation stuff&quot;
            ' ensure can hit farm
            Dim farm As SPFarm = SPFarm.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit local server
            Dim server As SPServer = SPServer.Local
            If farm Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit service application
            Dim service As CustomService = farm.Services.GetValue(Of CustomService)()
            If service Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;Custom Service not found (likely not installed).&quot;),
 ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit app pool
            Dim appPool As SPIisWebServiceApplicationPool = Me.ApplicationPool.Read()
            If appPool Is Nothing Then
                ThrowTerminatingError(New InvalidOperationException(&quot;Application pool not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
                SkipProcessCurrentRecord()
            End If


            ' ensure can hit database
            Dim dbServer As String = Me.DatabaseServer
            If String.IsNullOrEmpty(dbServer) Then
                dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource
            End If
            '#End Region


            ' ensure a service application does not already exist
            Dim existingCustomServiceApp As CustomServiceApplication = service.Applications.GetValue(Of CustomServiceApplication)()
            If existingCustomServiceApp IsNot Nothing Then
                WriteError(New InvalidOperationException(&quot;Custom service application already exists.&quot;), 
ErrorCategory.ResourceExists, existingCustomServiceApp)
                SkipProcessCurrentRecord()
            End If


            ' get database credentials
            Dim dbUsername As String = Nothing
            Dim dbPassword As String = Nothing
            If DatabaseCredentials IsNot Nothing Then
                Dim dbCredential As NetworkCredential = CType(DatabaseCredentials, NetworkCredential)
                dbUsername = dbCredential.UserName
                dbPassword = dbCredential.Password
            End If


            Dim dbOptions As SPDatabaseParameterOptions = SPDatabaseParameterOptions.None


            ' get database name
            Dim dbName As String = DatabaseName
            If dbName Is Nothing Then
                dbName = &quot;CustomServiceDB&quot;
                dbOptions = SPDatabaseParameterOptions.GenerateUniqueName
            End If


            ' create settings for a new database
            Dim dbParameters As SPDatabaseParameters = SPDatabaseParameters.CreateParameters(
dbName, dbServer, dbUsername, dbPassword, FailoverDatabaseServer, dbOptions)


            ' create & provision the service application 
            If ShouldProcess(Me.Name) Then
                Dim serviceApp As CustomServiceApplication = CustomServiceApplication.Create(Me.Name, service, appPool, dbParameters)


                ' provision the service app
                serviceApp.Provision()


                ' writes the new service application object out to the PowerShell pipeline
                ' where it can be piped as input to the next cmdlet in the pipeline.
                WriteObject(serviceApp)
            End If
        End Sub
    End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span lang="EN" style="">The Cmdlet attribute defines the cmdlet verb and noun. The SPCmdlet attribute ensures that the local machine is joined to a SharePoint farm and that the caller is a farm administrator
 before the cmdlet is executed.<br>
Now, we need to tell SharePoint Management Shell about our new cmdlet. This is done by first creating an xml registration file as follows:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;$SharePoint.Project.AssemblyFullName$&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InstallCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplication&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.NewCustomServiceApplication&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;$SharePoint.Project.AssemblyFullName$&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InstallCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplication&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.NewCustomServiceApplication&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span lang="EN" style="">We simply register our assembly full name (line 4), our cmdlet verb and name (line 6), the class that implements the cmdlet (line 7), and a help file (line 8). We won't actually create
 the help file for now since it's optional.<br>
</span><span style="">Step 7:</span><span style=""> </span><span style="color:black">Create the service application proxy
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;IisWebServiceApplicationProxyBackupBehavior()&gt; _
   &lt;Guid(&quot;D409CE5C-19BD-4269-8B16-8F3EDCCB1039&quot;)&gt; _
   Public NotInheritable Class CustomServiceApplicationProxy
       Inherits SPIisWebServiceApplicationProxy
       ' these are used in caching the client channel factory
       Private _channelFactory As ChannelFactory(Of ICustomServiceContract)
       Private _channelFactoryLock As New Object()
       Private _endpointConfigName As String


       &lt;Persisted()&gt; _
       Private _loadBalancer As SPServiceLoadBalancer


#Region &quot;constructors&quot;
       Public Sub New()
       End Sub


       Public Sub New(ByVal name As String, ByVal serviceProxy As CustomServiceProxy, ByVal serviceAppAddress As Uri)
           MyBase.New(name, serviceProxy, serviceAppAddress)
           ' create a new round robin load balancer
           _loadBalancer = New SPRoundRobinServiceLoadBalancer(serviceAppAddress)
       End Sub
#End Region


#Region &quot;app proxy infrastructure&quot;
       Private Function CreateChannelFactory(Of T)(ByVal endpointConfigName As String) As ChannelFactory(Of T)
           ' open client.config
           Dim clientConfigPath As String = SPUtility.GetGenericSetupPath(&quot;WebClients\CustomService&quot;)
           Dim clientConfig As Configuration = OpenClientConfiguration(clientConfigPath)
           Dim factory As New ConfigurationChannelFactory(Of T)(endpointConfigName, clientConfig, Nothing)


           ' configure the channel factory for IDFx claims auth
           factory.ConfigureCredentials(SPServiceAuthenticationMode.Claims)


           Return factory
       End Function


       Friend Delegate Sub CodeToRunOnApplicationProxy(ByVal appProxy As CustomServiceApplicationProxy)
       Friend Shared Sub Invoke(ByVal serviceContext As SPServiceContext, ByVal codeBlock As CodeToRunOnApplicationProxy)
           If serviceContext Is Nothing Then
               Throw New ArgumentNullException(&quot;serviceContext&quot;)
           End If


           ' get sample service app proxy from context
           Dim proxy As CustomServiceApplicationProxy = DirectCast(serviceContext.GetDefaultProxy(
GetType(CustomServiceApplicationProxy)), CustomServiceApplicationProxy)
           If proxy Is Nothing Then
               Throw New InvalidOperationException(&quot;Custom service application proxy not found.&quot;)
           End If


           ' ensure the current service context is correctly set
           Using New SPServiceContextScope(serviceContext)
               ' execute the delegate
               codeBlock(proxy)
           End Using
       End Sub


       Private Delegate Sub CodeToRunOnChannel(ByVal serviceContract As ICustomServiceContract)
       Private Sub ExecuteOnChannel(ByVal operationName As String, ByVal options As ExecuteOptions, ByVal codeBlock As CodeToRunOnChannel)
           Using New SPMonitoredScope(&quot;ExecuteOnChannel:&quot; & operationName)
               Dim loadBalancerCtx As SPServiceLoadBalancerContext = _loadBalancer.BeginOperation()
               Try
                   ' get a channel to the service app endpoint
                   Dim channel As IChannel = DirectCast(GetChannel(loadBalancerCtx.EndpointAddress, options), IChannel)
                   Try
                       ' execute the delegate
                       codeBlock(DirectCast(channel, ICustomServiceContract))


                       'close the channel
                       channel.Close()
                   Catch generatedExceptionName As TimeoutException
                       loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                       Throw
                   Catch generatedExceptionName As EndpointNotFoundException
                       loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                       Throw
                   Finally
                       If channel.State &lt;&gt; CommunicationState.Closed Then
                           channel.Abort()
                       End If
                   End Try
               Finally
                   loadBalancerCtx.EndOperation()
               End Try
           End Using
       End Sub


       ''' &lt;summary&gt;
       ''' Gets the endpoint configuration name for a given endpoint address.
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;address&quot;&gt;Endpoint address.&lt;/param&gt;
       ''' &lt;returns&gt;The endpoint configuration name.&lt;/returns&gt;
       ''' &lt;remarks&gt;The returned endpont must match one of the endpoint element names in the client.config file.&lt;/remarks&gt;
       Private Function GetEndpointConfigurationName(ByVal address As Uri) As String
           If address Is Nothing Then
               Throw New ArgumentNullException(&quot;address&quot;)
           End If


           Dim configName As String


           If address.Scheme = Uri.UriSchemeNetTcp Then
               If address.AbsolutePath.EndsWith(&quot;/secure&quot;, StringComparison.OrdinalIgnoreCase) Then
                   configName = &quot;tcp-ssl&quot;
               Else
                   configName = &quot;tcp&quot;
               End If
           ElseIf address.Scheme = Uri.UriSchemeHttps Then
               configName = &quot;https&quot;
           ElseIf address.Scheme = Uri.UriSchemeHttp Then
               configName = &quot;http&quot;
           Else
               Throw New NotSupportedException(&quot;Unsupported endpoint address.&quot;)
           End If


           Return configName
       End Function


       Private Function GetChannel(ByVal address As Uri, ByVal options As ExecuteOptions) As ICustomServiceContract
           ' get the endpoint config name
           Dim endpointConfigName As String = GetEndpointConfigurationName(address)


           ' check for a cached channel factory for the endpoint config
           If (_channelFactory Is Nothing) OrElse (endpointConfigName &lt;&gt; _endpointConfigName) Then
               SyncLock _channelFactoryLock
                   ' create a channel factory using the default endpoing config name
                   _channelFactory = CreateChannelFactory(Of ICustomServiceContract)(endpointConfigName)


                   ' cache the endpoint config name
                   _endpointConfigName = endpointConfigName
               End SyncLock
           End If


           Dim channel As ICustomServiceContract


           If ExecuteOptions.AsProcess = (options And ExecuteOptions.AsProcess) Then
               ' create a channel that acts as the service's process user when authenticating with the service
               channel = _channelFactory.CreateChannelAsProcess(New EndpointAddress(address))
           Else
               ' create a channel that acts as the loged on user when authenticating with the service
               channel = _channelFactory.CreateChannelActingAsLoggedOnUser(New EndpointAddress(address))
           End If


           ' create a channel from the factory
           Return channel
       End Function
#End Region


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service Application Proxy&quot;
           End Get
       End Property


       Public Overrides Sub Provision()
           _loadBalancer.Provision()
           MyBase.Provision()
           Me.Update()
       End Sub


       Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
           _loadBalancer.Unprovision()
           MyBase.Unprovision(deleteData)
           Me.Update()
       End Sub


       ''' &lt;summary&gt;
       ''' Client method executed on WFE (front-end), for example, by a web part.
       ''' &lt;/summary&gt;
#Region &quot;service app methods&quot;
       Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
           Dim result As Integer = 0


           ExecuteOnChannel(&quot;Add&quot;, options, Function(proxy) InlineAssignHelper(result, proxy.Add(a, b)))


           Return result
       End Function


       Public Function HelloWorld(ByVal options As ExecuteOptions) As String
           Dim result As String = String.Empty


           ' Execute the service application method
           Me.ExecuteOnChannel(&quot;HelloWorld&quot;, options, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld()))


           Return result
       End Function


       Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
           target = value
           Return value
       End Function
#End Region
   End Class

</pre>
<pre id="codePreview" class="vb">
&lt;IisWebServiceApplicationProxyBackupBehavior()&gt; _
   &lt;Guid(&quot;D409CE5C-19BD-4269-8B16-8F3EDCCB1039&quot;)&gt; _
   Public NotInheritable Class CustomServiceApplicationProxy
       Inherits SPIisWebServiceApplicationProxy
       ' these are used in caching the client channel factory
       Private _channelFactory As ChannelFactory(Of ICustomServiceContract)
       Private _channelFactoryLock As New Object()
       Private _endpointConfigName As String


       &lt;Persisted()&gt; _
       Private _loadBalancer As SPServiceLoadBalancer


#Region &quot;constructors&quot;
       Public Sub New()
       End Sub


       Public Sub New(ByVal name As String, ByVal serviceProxy As CustomServiceProxy, ByVal serviceAppAddress As Uri)
           MyBase.New(name, serviceProxy, serviceAppAddress)
           ' create a new round robin load balancer
           _loadBalancer = New SPRoundRobinServiceLoadBalancer(serviceAppAddress)
       End Sub
#End Region


#Region &quot;app proxy infrastructure&quot;
       Private Function CreateChannelFactory(Of T)(ByVal endpointConfigName As String) As ChannelFactory(Of T)
           ' open client.config
           Dim clientConfigPath As String = SPUtility.GetGenericSetupPath(&quot;WebClients\CustomService&quot;)
           Dim clientConfig As Configuration = OpenClientConfiguration(clientConfigPath)
           Dim factory As New ConfigurationChannelFactory(Of T)(endpointConfigName, clientConfig, Nothing)


           ' configure the channel factory for IDFx claims auth
           factory.ConfigureCredentials(SPServiceAuthenticationMode.Claims)


           Return factory
       End Function


       Friend Delegate Sub CodeToRunOnApplicationProxy(ByVal appProxy As CustomServiceApplicationProxy)
       Friend Shared Sub Invoke(ByVal serviceContext As SPServiceContext, ByVal codeBlock As CodeToRunOnApplicationProxy)
           If serviceContext Is Nothing Then
               Throw New ArgumentNullException(&quot;serviceContext&quot;)
           End If


           ' get sample service app proxy from context
           Dim proxy As CustomServiceApplicationProxy = DirectCast(serviceContext.GetDefaultProxy(
GetType(CustomServiceApplicationProxy)), CustomServiceApplicationProxy)
           If proxy Is Nothing Then
               Throw New InvalidOperationException(&quot;Custom service application proxy not found.&quot;)
           End If


           ' ensure the current service context is correctly set
           Using New SPServiceContextScope(serviceContext)
               ' execute the delegate
               codeBlock(proxy)
           End Using
       End Sub


       Private Delegate Sub CodeToRunOnChannel(ByVal serviceContract As ICustomServiceContract)
       Private Sub ExecuteOnChannel(ByVal operationName As String, ByVal options As ExecuteOptions, ByVal codeBlock As CodeToRunOnChannel)
           Using New SPMonitoredScope(&quot;ExecuteOnChannel:&quot; & operationName)
               Dim loadBalancerCtx As SPServiceLoadBalancerContext = _loadBalancer.BeginOperation()
               Try
                   ' get a channel to the service app endpoint
                   Dim channel As IChannel = DirectCast(GetChannel(loadBalancerCtx.EndpointAddress, options), IChannel)
                   Try
                       ' execute the delegate
                       codeBlock(DirectCast(channel, ICustomServiceContract))


                       'close the channel
                       channel.Close()
                   Catch generatedExceptionName As TimeoutException
                       loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                       Throw
                   Catch generatedExceptionName As EndpointNotFoundException
                       loadBalancerCtx.Status = SPServiceLoadBalancerStatus.Failed
                       Throw
                   Finally
                       If channel.State &lt;&gt; CommunicationState.Closed Then
                           channel.Abort()
                       End If
                   End Try
               Finally
                   loadBalancerCtx.EndOperation()
               End Try
           End Using
       End Sub


       ''' &lt;summary&gt;
       ''' Gets the endpoint configuration name for a given endpoint address.
       ''' &lt;/summary&gt;
       ''' &lt;param name=&quot;address&quot;&gt;Endpoint address.&lt;/param&gt;
       ''' &lt;returns&gt;The endpoint configuration name.&lt;/returns&gt;
       ''' &lt;remarks&gt;The returned endpont must match one of the endpoint element names in the client.config file.&lt;/remarks&gt;
       Private Function GetEndpointConfigurationName(ByVal address As Uri) As String
           If address Is Nothing Then
               Throw New ArgumentNullException(&quot;address&quot;)
           End If


           Dim configName As String


           If address.Scheme = Uri.UriSchemeNetTcp Then
               If address.AbsolutePath.EndsWith(&quot;/secure&quot;, StringComparison.OrdinalIgnoreCase) Then
                   configName = &quot;tcp-ssl&quot;
               Else
                   configName = &quot;tcp&quot;
               End If
           ElseIf address.Scheme = Uri.UriSchemeHttps Then
               configName = &quot;https&quot;
           ElseIf address.Scheme = Uri.UriSchemeHttp Then
               configName = &quot;http&quot;
           Else
               Throw New NotSupportedException(&quot;Unsupported endpoint address.&quot;)
           End If


           Return configName
       End Function


       Private Function GetChannel(ByVal address As Uri, ByVal options As ExecuteOptions) As ICustomServiceContract
           ' get the endpoint config name
           Dim endpointConfigName As String = GetEndpointConfigurationName(address)


           ' check for a cached channel factory for the endpoint config
           If (_channelFactory Is Nothing) OrElse (endpointConfigName &lt;&gt; _endpointConfigName) Then
               SyncLock _channelFactoryLock
                   ' create a channel factory using the default endpoing config name
                   _channelFactory = CreateChannelFactory(Of ICustomServiceContract)(endpointConfigName)


                   ' cache the endpoint config name
                   _endpointConfigName = endpointConfigName
               End SyncLock
           End If


           Dim channel As ICustomServiceContract


           If ExecuteOptions.AsProcess = (options And ExecuteOptions.AsProcess) Then
               ' create a channel that acts as the service's process user when authenticating with the service
               channel = _channelFactory.CreateChannelAsProcess(New EndpointAddress(address))
           Else
               ' create a channel that acts as the loged on user when authenticating with the service
               channel = _channelFactory.CreateChannelActingAsLoggedOnUser(New EndpointAddress(address))
           End If


           ' create a channel from the factory
           Return channel
       End Function
#End Region


       Public Overrides ReadOnly Property TypeName() As String
           Get
               Return &quot;Custom Service Application Proxy&quot;
           End Get
       End Property


       Public Overrides Sub Provision()
           _loadBalancer.Provision()
           MyBase.Provision()
           Me.Update()
       End Sub


       Public Overrides Sub Unprovision(ByVal deleteData As Boolean)
           _loadBalancer.Unprovision()
           MyBase.Unprovision(deleteData)
           Me.Update()
       End Sub


       ''' &lt;summary&gt;
       ''' Client method executed on WFE (front-end), for example, by a web part.
       ''' &lt;/summary&gt;
#Region &quot;service app methods&quot;
       Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
           Dim result As Integer = 0


           ExecuteOnChannel(&quot;Add&quot;, options, Function(proxy) InlineAssignHelper(result, proxy.Add(a, b)))


           Return result
       End Function


       Public Function HelloWorld(ByVal options As ExecuteOptions) As String
           Dim result As String = String.Empty


           ' Execute the service application method
           Me.ExecuteOnChannel(&quot;HelloWorld&quot;, options, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld()))


           Return result
       End Function


       Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
           target = value
           Return value
       End Function
#End Region
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 8:</span><span style="">
</span><span style="color:black">Build a client application. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Public NotInheritable Class CustomServiceClient
       Private _serviceContext As SPServiceContext


       Public Sub New(ByVal serviceContext As SPServiceContext)
           If serviceContext Is Nothing Then
               Throw New ArgumentNullException(&quot;serviceContext&quot;)
           End If


           _serviceContext = serviceContext
       End Sub


       Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
           Return Add(a, b, ExecuteOptions.None)
       End Function


       Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
           Dim sum As Integer = 0
           CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(sum, proxy.Add(a, b, options)))
           Return sum
       End Function


       Public Function HelloWorld() As String
           Return HelloWorld(ExecuteOptions.None)
       End Function


       Public Function HelloWorld(ByVal options As ExecuteOptions) As String
           Dim result As String = String.Empty


           CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld(options)))


           Return result
       End Function
       Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
           target = value
           Return value
       End Function
   End Class

</pre>
<pre id="codePreview" class="vb">
Public NotInheritable Class CustomServiceClient
       Private _serviceContext As SPServiceContext


       Public Sub New(ByVal serviceContext As SPServiceContext)
           If serviceContext Is Nothing Then
               Throw New ArgumentNullException(&quot;serviceContext&quot;)
           End If


           _serviceContext = serviceContext
       End Sub


       Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
           Return Add(a, b, ExecuteOptions.None)
       End Function


       Public Function Add(ByVal a As Integer, ByVal b As Integer, ByVal options As ExecuteOptions) As Integer
           Dim sum As Integer = 0
           CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(sum, proxy.Add(a, b, options)))
           Return sum
       End Function


       Public Function HelloWorld() As String
           Return HelloWorld(ExecuteOptions.None)
       End Function


       Public Function HelloWorld(ByVal options As ExecuteOptions) As String
           Dim result As String = String.Empty


           CustomServiceApplicationProxy.Invoke(_serviceContext, Function(proxy) InlineAssignHelper(result, proxy.HelloWorld(options)))


           Return result
       End Function
       Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
           target = value
           Return value
       End Function
   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 9:</span><span style="">
</span><span style="color:black">Write the service application proxy installation code
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
&lt;Cmdlet(VerbsLifecycle.Install, &quot;CustomServiceProxy&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class InstallCustomServiceProxy
       Inherits SPCmdlet
       Protected Overrides Function RequireUserFarmAdmin() As Boolean
           Return True
       End Function


       Protected Overrides Sub InternalProcessRecord()
           '#Region &quot;validation stuff&quot;


           Dim farm As SPFarm = SPFarm.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
           End If


           Dim server As SPServer = SPServer.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
           End If


           '#End Region


           ' install the service proxy into the farm if isn't already installed
           If ShouldProcess(&quot;Custom Service Proxy&quot;) Then
               Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()


               If serviceProxy Is Nothing Then
                   serviceProxy = New CustomServiceProxy(farm)
                   serviceProxy.Update(True)
               End If
           End If
       End Sub
   End Class


   &lt;Cmdlet(VerbsCommon.[New], &quot;CustomServiceApplicationProxy&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class NewCustomServiceApplicationProxy
       Inherits SPCmdlet
       Private _name As String
       Private _uri As Uri
       Private _pipeBind As SPServiceApplicationPipeBind


       &lt;Parameter(Mandatory:=True)&gt; _
       &lt;ValidateNotNullOrEmpty()&gt; _
       Public Property Name() As String
           Get
               Return _name
           End Get
           Set(ByVal value As String)
               _name = value
           End Set
       End Property


       &lt;Parameter(Mandatory:=True, ParameterSetName:=&quot;Uri&quot;)&gt; _
       &lt;ValidateNotNullOrEmpty()&gt; _
       Public Property Uri() As String
           Get
               Return _uri.ToString()
           End Get
           Set(ByVal value As String)
               _uri = New Uri(value)
           End Set
       End Property


       &lt;Parameter(Mandatory:=True, ValueFromPipeline:=True, ParameterSetName:=&quot;ServiceApplication&quot;)&gt; _
       Public Property ServiceApplication() As SPServiceApplicationPipeBind
           Get
               Return _pipeBind
           End Get
           Set(ByVal value As SPServiceApplicationPipeBind)
               _pipeBind = value
           End Set
       End Property


       Protected Overrides Function RequireUserFarmAdmin() As Boolean
           Return True
       End Function


       Protected Overrides Sub InternalProcessRecord()
           '#Region &quot;validation stuff&quot;
           ' ensure can hit farm
           Dim farm As SPFarm = SPFarm.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
               SkipProcessCurrentRecord()
           End If


           ' ensure the service proxy is installed
           Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()
           If serviceProxy Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;Custom service application proxy not found.&quot;), ErrorCategory.NotInstalled, Me)
           End If


           ' ensure the proxy isn't already created
           Dim existingServiceAppProxy As CustomServiceApplicationProxy = serviceProxy.ApplicationProxies.GetValue(Of CustomServiceApplicationProxy)()
           If existingServiceAppProxy IsNot Nothing Then
               WriteError(New InvalidOperationException(&quot;Custom service application proxy already exists.&quot;), 
ErrorCategory.ResourceExists, existingServiceAppProxy)
               ' skip this command
               SkipProcessCurrentRecord()
           End If
           '#End Region


           Dim serviceAppUri As Uri = Nothing
           If ParameterSetName = &quot;Uri&quot; Then
               serviceAppUri = _uri
           ElseIf ParameterSetName = &quot;ServiceApplication&quot; Then
               Dim serviceApp As SPServiceApplication = _pipeBind.Read()
               If serviceApp Is Nothing Then
                   WriteError(New InvalidOperationException(&quot;Service application not found.&quot;), ErrorCategory.ResourceExists, serviceApp)
                   SkipProcessCurrentRecord()
               End If


               Dim sharedServiceApp As ISharedServiceApplication = TryCast(serviceApp, ISharedServiceApplication)
               If sharedServiceApp Is Nothing Then
                   WriteError(New InvalidOperationException(&quot;Connecting to specified service application is not supported.&quot;), ErrorCategory.ResourceExists, serviceApp)
                   SkipProcessCurrentRecord()
               End If


               serviceAppUri = sharedServiceApp.Uri
           Else
               ThrowTerminatingError(New InvalidOperationException(&quot;Invalid parameter set.&quot;), ErrorCategory.InvalidArgument, Me)
           End If


           If (serviceAppUri IsNot Nothing) AndAlso ShouldProcess(Name) Then
               ' create service app proxy
               Dim serviceAppProxy As New CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri)


               ' provision the sample service app proxy
               serviceAppProxy.Provision()


               ' write new sample service app proxy to pipeline
               WriteObject(serviceAppProxy)
           End If


       End Sub
   End Class


   &lt;Cmdlet(&quot;Invoke&quot;, &quot;CustomService&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class InvokeCustomService
       Inherits SPCmdlet
       Private _values As Integer()
       Private _serviceContext As SPServiceContextPipeBind


       &lt;Parameter(Mandatory:=True, ValueFromPipeline:=True, Position:=0)&gt; _
       Public Property ServiceContext() As SPServiceContextPipeBind
           Get
               Return _serviceContext
           End Get
           Set(ByVal value As SPServiceContextPipeBind)
               _serviceContext = value
           End Set
       End Property


       &lt;Parameter(ParameterSetName:=&quot;Add&quot;, Mandatory:=True)&gt; _
       Public Property Add() As Integer()
           Get
               Return _values
           End Get
           Set(ByVal value As Integer())
               _values = value
           End Set
       End Property


       Protected Overrides Sub InternalProcessRecord()
           ' Read the specified service context pipebind
           Dim serviceCtx As SPServiceContext = _serviceContext.Read()
           If serviceCtx Is Nothing Then
               WriteError(New InvalidOperationException(&quot;Invalid service context.&quot;), ErrorCategory.ResourceExists, serviceCtx)


               Return
           Else
               ' Create a new Service client
               Dim client As New CustomServiceClient(serviceCtx)


               ' validate at least two values were passed in
               If _values.Length &lt; 2 Then
                   WriteError(New InvalidOperationException(&quot;A minimum of two values are required for this operation.&quot;), ErrorCategory.InvalidArgument, _values)
               Else
                   ' loop through all values passed in, calling the service app, to add them up
                   Dim sum As Integer = _values(0)
                   For x As Integer = 1 To _values.Length - 1
                       sum = client.Add(sum, _values(x), ExecuteOptions.None)
                   Next


                   ' write the results
                   WriteObject(sum)
               End If


               ' result 
               Dim result As String = client.HelloWorld()


               ' Write the sum to the pipeline
               Me.WriteObject(result)
           End If
       End Sub


   End Class

</pre>
<pre id="codePreview" class="vb">
&lt;Cmdlet(VerbsLifecycle.Install, &quot;CustomServiceProxy&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class InstallCustomServiceProxy
       Inherits SPCmdlet
       Protected Overrides Function RequireUserFarmAdmin() As Boolean
           Return True
       End Function


       Protected Overrides Sub InternalProcessRecord()
           '#Region &quot;validation stuff&quot;


           Dim farm As SPFarm = SPFarm.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
           End If


           Dim server As SPServer = SPServer.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
           End If


           '#End Region


           ' install the service proxy into the farm if isn't already installed
           If ShouldProcess(&quot;Custom Service Proxy&quot;) Then
               Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()


               If serviceProxy Is Nothing Then
                   serviceProxy = New CustomServiceProxy(farm)
                   serviceProxy.Update(True)
               End If
           End If
       End Sub
   End Class


   &lt;Cmdlet(VerbsCommon.[New], &quot;CustomServiceApplicationProxy&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class NewCustomServiceApplicationProxy
       Inherits SPCmdlet
       Private _name As String
       Private _uri As Uri
       Private _pipeBind As SPServiceApplicationPipeBind


       &lt;Parameter(Mandatory:=True)&gt; _
       &lt;ValidateNotNullOrEmpty()&gt; _
       Public Property Name() As String
           Get
               Return _name
           End Get
           Set(ByVal value As String)
               _name = value
           End Set
       End Property


       &lt;Parameter(Mandatory:=True, ParameterSetName:=&quot;Uri&quot;)&gt; _
       &lt;ValidateNotNullOrEmpty()&gt; _
       Public Property Uri() As String
           Get
               Return _uri.ToString()
           End Get
           Set(ByVal value As String)
               _uri = New Uri(value)
           End Set
       End Property


       &lt;Parameter(Mandatory:=True, ValueFromPipeline:=True, ParameterSetName:=&quot;ServiceApplication&quot;)&gt; _
       Public Property ServiceApplication() As SPServiceApplicationPipeBind
           Get
               Return _pipeBind
           End Get
           Set(ByVal value As SPServiceApplicationPipeBind)
               _pipeBind = value
           End Set
       End Property


       Protected Overrides Function RequireUserFarmAdmin() As Boolean
           Return True
       End Function


       Protected Overrides Sub InternalProcessRecord()
           '#Region &quot;validation stuff&quot;
           ' ensure can hit farm
           Dim farm As SPFarm = SPFarm.Local
           If farm Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, Me)
               SkipProcessCurrentRecord()
           End If


           ' ensure the service proxy is installed
           Dim serviceProxy As CustomServiceProxy = farm.ServiceProxies.GetValue(Of CustomServiceProxy)()
           If serviceProxy Is Nothing Then
               ThrowTerminatingError(New InvalidOperationException(&quot;Custom service application proxy not found.&quot;), ErrorCategory.NotInstalled, Me)
           End If


           ' ensure the proxy isn't already created
           Dim existingServiceAppProxy As CustomServiceApplicationProxy = serviceProxy.ApplicationProxies.GetValue(Of CustomServiceApplicationProxy)()
           If existingServiceAppProxy IsNot Nothing Then
               WriteError(New InvalidOperationException(&quot;Custom service application proxy already exists.&quot;), 
ErrorCategory.ResourceExists, existingServiceAppProxy)
               ' skip this command
               SkipProcessCurrentRecord()
           End If
           '#End Region


           Dim serviceAppUri As Uri = Nothing
           If ParameterSetName = &quot;Uri&quot; Then
               serviceAppUri = _uri
           ElseIf ParameterSetName = &quot;ServiceApplication&quot; Then
               Dim serviceApp As SPServiceApplication = _pipeBind.Read()
               If serviceApp Is Nothing Then
                   WriteError(New InvalidOperationException(&quot;Service application not found.&quot;), ErrorCategory.ResourceExists, serviceApp)
                   SkipProcessCurrentRecord()
               End If


               Dim sharedServiceApp As ISharedServiceApplication = TryCast(serviceApp, ISharedServiceApplication)
               If sharedServiceApp Is Nothing Then
                   WriteError(New InvalidOperationException(&quot;Connecting to specified service application is not supported.&quot;), ErrorCategory.ResourceExists, serviceApp)
                   SkipProcessCurrentRecord()
               End If


               serviceAppUri = sharedServiceApp.Uri
           Else
               ThrowTerminatingError(New InvalidOperationException(&quot;Invalid parameter set.&quot;), ErrorCategory.InvalidArgument, Me)
           End If


           If (serviceAppUri IsNot Nothing) AndAlso ShouldProcess(Name) Then
               ' create service app proxy
               Dim serviceAppProxy As New CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri)


               ' provision the sample service app proxy
               serviceAppProxy.Provision()


               ' write new sample service app proxy to pipeline
               WriteObject(serviceAppProxy)
           End If


       End Sub
   End Class


   &lt;Cmdlet(&quot;Invoke&quot;, &quot;CustomService&quot;, SupportsShouldProcess:=True)&gt; _
   Public Class InvokeCustomService
       Inherits SPCmdlet
       Private _values As Integer()
       Private _serviceContext As SPServiceContextPipeBind


       &lt;Parameter(Mandatory:=True, ValueFromPipeline:=True, Position:=0)&gt; _
       Public Property ServiceContext() As SPServiceContextPipeBind
           Get
               Return _serviceContext
           End Get
           Set(ByVal value As SPServiceContextPipeBind)
               _serviceContext = value
           End Set
       End Property


       &lt;Parameter(ParameterSetName:=&quot;Add&quot;, Mandatory:=True)&gt; _
       Public Property Add() As Integer()
           Get
               Return _values
           End Get
           Set(ByVal value As Integer())
               _values = value
           End Set
       End Property


       Protected Overrides Sub InternalProcessRecord()
           ' Read the specified service context pipebind
           Dim serviceCtx As SPServiceContext = _serviceContext.Read()
           If serviceCtx Is Nothing Then
               WriteError(New InvalidOperationException(&quot;Invalid service context.&quot;), ErrorCategory.ResourceExists, serviceCtx)


               Return
           Else
               ' Create a new Service client
               Dim client As New CustomServiceClient(serviceCtx)


               ' validate at least two values were passed in
               If _values.Length &lt; 2 Then
                   WriteError(New InvalidOperationException(&quot;A minimum of two values are required for this operation.&quot;), ErrorCategory.InvalidArgument, _values)
               Else
                   ' loop through all values passed in, calling the service app, to add them up
                   Dim sum As Integer = _values(0)
                   For x As Integer = 1 To _values.Length - 1
                       sum = client.Add(sum, _values(x), ExecuteOptions.None)
                   Next


                   ' write the results
                   WriteObject(sum)
               End If


               ' result 
               Dim result As String = client.HelloWorld()


               ' Write the sum to the pipeline
               Me.WriteObject(result)
           End If
       End Sub


   End Class

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 10:</span><span style="">
</span><span style="color:black">Install and provision the service application proxy
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;$SharePoint.Project.AssemblyFullName$&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomServiceProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InstallCustomServiceProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplicationProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.NewCustomServiceApplicationProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Invoke-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InvokeCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;$SharePoint.Project.AssemblyFullName$&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomServiceProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InstallCustomServiceProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplicationProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.NewCustomServiceApplicationProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Invoke-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.CustomService.PowerShell.InvokeCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 11:</span><span style="">
</span><span style="color:black">Create the service application consumers:</span><span style="">
</span><span style="color:black">Test.aspx </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;asp:Content ID=&quot;Content3&quot; ContentPlaceHolderId=&quot;PlaceHolderMain&quot; runat=&quot;server&quot;&gt;
    &lt;asp:Label ID=&quot;TestOutputLabel&quot; runat=&quot;server&quot; /&gt;
&lt;/asp:Content&gt;

</pre>
<pre id="codePreview" class="html">
&lt;asp:Content ID=&quot;Content3&quot; ContentPlaceHolderId=&quot;PlaceHolderMain&quot; runat=&quot;server&quot;&gt;
    &lt;asp:Label ID=&quot;TestOutputLabel&quot; runat=&quot;server&quot; /&gt;
&lt;/asp:Content&gt;

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
Dim client As New CustomServiceClient(SPServiceContext.Current)


         Dim sum As Integer = client.Add(1, 1)


         Dim strSayHello As String = client.HelloWorld()


         TestOutputLabel.Text = [String].Format(&quot;1 &#43; 1 = {0}&quot;, sum) & &quot;<br>&quot; & strSayHello

</pre>
<pre id="codePreview" class="vb">
Dim client As New CustomServiceClient(SPServiceContext.Current)


         Dim sum As Integer = client.Add(1, 1)


         Dim strSayHello As String = client.HelloWorld()


         TestOutputLabel.Text = [String].Format(&quot;1 &#43; 1 = {0}&quot;, sum) & &quot;<br>&quot; & strSayHello

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="text-autospace:none"><span style="">Step 12: Deploy. After run the AppInstaller.ps1 you can debug and test it.
</span></p>
<p class="MsoNormal" style="">Service Application Framework<br>
<a href="http://msdn.microsoft.com/en-us/library/ee536263">http://msdn.microsoft.com/en-us/library/ee536263</a><br>
Service Application Framework Architecture<br>
<a href="http://msdn.microsoft.com/en-us/library/ee536537.aspx">http://msdn.microsoft.com/en-us/library/ee536537.aspx</a><br>
Service Object Model<br>
<a href="http://msdn.microsoft.com/en-us/library/ee537799">http://msdn.microsoft.com/en-us/library/ee537799</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
