# Claim-aware WCF WebService[vs10] (CSSharePointCallClaimsAwareWCF)
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
* 2012-07-22 07:47:11
## Description

<h1><a name="OLE_LINK2"></a><a name="OLE_LINK1"><span style=""><span style="">How to custom claim-aware WCF Web Service for SharePoint 2010
</span>(</span></a><span style=""><span style=""><span style="">CSSharePointCallClaimsAwareWCF</span>)</span></span></h1>
<h2>Introduction </h2>
<p class="MsoNormal" style=""><span style="">This sample code will demonstrate how to call a Claims-Aware WCF Service from a SharePoint 2010 Claims Site. We use Service Application Framework (SAF) to host WCF Web Service in IIS.<span style="">&nbsp;
</span>On the caller's side, we need to use CreateChannelActingAsLoggedOnUser method to send the Claim based SharePoint Logged-on user's security token to our custom web service.<span style="">&nbsp;
</span>In our custom WCF web service, we need to use System.Threading.Thread.CurrentPrincipal.Identity to get the claim based security token.
</span></p>
<h2>Running the Sample</h2>
<p class="MsoNormal"><span style="">Please follow the steps below. </span></p>
<p class="MsoNormal"><span style="">First, make sure you have created a Claims-Aware Site.
</span></p>
<p class="MsoNormal"><span style=""><span style="">&nbsp;</span> <img src="/site/view/file/62043/1/image.png" alt="" width="593" height="203" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style="">Step 1: Open the CSSharePointCallClaimsAwareWCF.sln file and then set the &quot;Site URL&quot; to your own site.
</span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal">
<span style=""></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 2: After that right-click the &quot;CSSharePointCallClaimsAwareWCF&quot; project and click &quot;Deploy&quot;.
</span></p>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 3: Run the AppInstaller.ps1 to install service and service proxy.<br>
</span><span lang="EN" style="">Here's what our service application looks like in the &quot;Manage Service Applications&quot; UX:<span style="color:blue"><br>
</span></span><span style=""><img src="/site/view/file/62044/1/image.png" alt="" width="730" height="373" align="middle">
</span><span lang="EN" style=""></span></p>
<p><span lang="EN" style="font-size:11.0pt; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">And here's what it looks like in IIS Manager (on a server where the Calculator service instance has been started):
</span></p>
<p class="MsoNormal"><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><img src="/site/view/file/62045/1/image.png" alt="" width="562" height="347" align="middle">
</span><span style="font-size:9.5pt; line-height:115%; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;; color:black"><br>
</span><span style="">Step 4: Visit the test page through the link in your browser:</span>
<span style=""><span style="">&nbsp;</span>yoursite/_layouts/customservice/test.aspx.<br>
<span style=""><img src="/site/view/file/62046/1/image.png" alt="" width="720" height="106" align="middle">
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="font-size:9.5pt"></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 5: Validation is completed. </span></p>
<h2>Using the Code</h2>
<p class="MsoNormal" style=""><span style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></p>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Step 1: Create a C# &quot;Empty</span> <span style="">SharePoint Project&quot; in Visual Studio 2010 and named it as &quot;CSSharePointCallClaimsAwareWCF&quot;.
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[ServiceContract]
    public interface ICustomServiceContract
    {     
        [OperationContractAttribute(Name = &quot;Add&quot;)]
        int Add(int a, int b);


        [OperationContractAttribute(Name = &quot;HelloWorld&quot;)]
        string HelloWorld();
    }

</pre>
<pre id="codePreview" class="csharp">
[ServiceContract]
    public interface ICustomServiceContract
    {     
        [OperationContractAttribute(Name = &quot;Add&quot;)]
        int Add(int a, int b);


        [OperationContractAttribute(Name = &quot;HelloWorld&quot;)]
        string HelloWorld();
    }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">Here's the contract implementation in CustomServiceApplication.cs:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public int Add(int a, int b)
       {
           DemandAccess(CustomServiceAccessRights.Add);
           return a &#43; b;
       }       


       public string HelloWorld()
       {
           DemandAccess(CustomServiceAccessRights.Hello);
           string id = GetIdentityClass.GetIdentity();           


           return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; &#43; id;
       }   

</pre>
<pre id="codePreview" class="csharp">
public int Add(int a, int b)
       {
           DemandAccess(CustomServiceAccessRights.Add);
           return a &#43; b;
       }       


       public string HelloWorld()
       {
           DemandAccess(CustomServiceAccessRights.Hello);
           string id = GetIdentityClass.GetIdentity();           


           return &quot;Hello World from WCF and SharePoint 2010; GetIdentity&quot; &#43; id;
       }   

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">The GetIdentityClass class is used to get SharePoint Logged-on user's security Token.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
private const string IdentityClaimType = @&quot;http://schemas.microsoft.com/sharepoint/2009/08/claims/userid&quot;;


      public static string GetIdentity()
      {
          //Identity Name
          string identityName = String.Empty;
          //Get the Identity of the Current Principal
          IClaimsIdentity claimsIdentity =System.Threading.Thread.CurrentPrincipal.Identity as IClaimsIdentity;


          if (claimsIdentity != null)
          {
              // claim
              foreach (Claim claim in claimsIdentity.Claims)
              {
                  if (String.Equals(IdentityClaimType, claim.ClaimType,
                    StringComparison.OrdinalIgnoreCase))
                  {
                      identityName = claim.Value;
                      break;
                  }
              }
          }
          else
          {
              identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
          }


          return identityName;
      }</pre>
<pre id="codePreview" class="csharp">
private const string IdentityClaimType = @&quot;http://schemas.microsoft.com/sharepoint/2009/08/claims/userid&quot;;


      public static string GetIdentity()
      {
          //Identity Name
          string identityName = String.Empty;
          //Get the Identity of the Current Principal
          IClaimsIdentity claimsIdentity =System.Threading.Thread.CurrentPrincipal.Identity as IClaimsIdentity;


          if (claimsIdentity != null)
          {
              // claim
              foreach (Claim claim in claimsIdentity.Claims)
              {
                  if (String.Equals(IdentityClaimType, claim.ClaimType,
                    StringComparison.OrdinalIgnoreCase))
                  {
                      identityName = claim.Value;
                      break;
                  }
              }
          }
          else
          {
              identityName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
          }


          return identityName;
      }</pre>
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
        name=&quot;CustomService.CustomServiceApplication&quot;&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpSecureBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
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
        name=&quot;CustomService.CustomServiceApplication&quot;&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceTcpSecureBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
          binding=&quot;customBinding&quot;
          bindingConfiguration=&quot;CustomServiceHttpBinding&quot; /&gt;
        &lt;endpoint
          address=&quot;secure&quot;
          contract=&quot;CustomService.ICustomServiceContract&quot;
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;%@ServiceHost Language=&quot;C#&quot; Debug=&quot;true&quot; 
               Service=&quot;CustomService.CustomServiceApplication, CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot; 
               Factory=&quot;CustomService.CustomServiceHostFactory, CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot; %&gt;

</pre>
<pre id="codePreview" class="csharp">
&lt;%@ServiceHost Language=&quot;C#&quot; Debug=&quot;true&quot; 
               Service=&quot;CustomService.CustomServiceApplication, CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot; 
               Factory=&quot;CustomService.CustomServiceHostFactory, CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot; %&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style="">For this, we create a custom service Host Factory. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
internal sealed class CustomServiceHostFactory : ServiceHostFactory
   {
       public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
       {
           ServiceHost serviceHost = new ServiceHost(typeof(CustomServiceApplication), baseAddresses);
           // configure the service host for claims authentication
           serviceHost.Configure(SPServiceAuthenticationMode.Claims);
           return serviceHost;
       }
   }



</pre>
<pre id="codePreview" class="csharp">
internal sealed class CustomServiceHostFactory : ServiceHostFactory
   {
       public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
       {
           ServiceHost serviceHost = new ServiceHost(typeof(CustomServiceApplication), baseAddresses);
           // configure the service host for claims authentication
           serviceHost.Configure(SPServiceAuthenticationMode.Claims);
           return serviceHost;
       }
   }



</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 5:</span><span lang="EN" style=""> We'll integrate our service with the SharePoint management experience so that SharePoint administrators can choose which machines in the server farm should
 host the service.</span><span lang="EN" style=""> </span><span style=""></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CustomService : SPIisWebService, IServiceAdministration
   {
       /// &lt;summary&gt;
       /// Internal use only.
       /// &lt;/summary&gt;
       public CustomService() { }


       /// &lt;summary&gt;
       /// Creates a new service proxy.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;farm&quot;&gt;The parent farm object.&lt;/param&gt;
       public CustomService(SPFarm farm) : base(farm) { }


       #region IServiceAdministration Members
       public SPServiceApplication CreateApplication(string name, Type serviceApplicationType, SPServiceProvisioningContext provisioningContext)
       {
           #region validation
           if (provisioningContext == null)
               throw new ArgumentNullException(&quot;provisioningContext&quot;);
           if (serviceApplicationType != typeof(CustomServiceApplication))
               throw new NotSupportedException();
           #endregion


           // check to see if this service application already exists
           CustomServiceApplication application = 
               this.Farm.GetObject(
                   name,
                   this.Id,
                   serviceApplicationType) as CustomServiceApplication;


           if (application == null)
           {


       ...
   }

</pre>
<pre id="codePreview" class="csharp">
public class CustomService : SPIisWebService, IServiceAdministration
   {
       /// &lt;summary&gt;
       /// Internal use only.
       /// &lt;/summary&gt;
       public CustomService() { }


       /// &lt;summary&gt;
       /// Creates a new service proxy.
       /// &lt;/summary&gt;
       /// &lt;param name=&quot;farm&quot;&gt;The parent farm object.&lt;/param&gt;
       public CustomService(SPFarm farm) : base(farm) { }


       #region IServiceAdministration Members
       public SPServiceApplication CreateApplication(string name, Type serviceApplicationType, SPServiceProvisioningContext provisioningContext)
       {
           #region validation
           if (provisioningContext == null)
               throw new ArgumentNullException(&quot;provisioningContext&quot;);
           if (serviceApplicationType != typeof(CustomServiceApplication))
               throw new NotSupportedException();
           #endregion


           // check to see if this service application already exists
           CustomServiceApplication application = 
               this.Farm.GetObject(
                   name,
                   this.Id,
                   serviceApplicationType) as CustomServiceApplication;


           if (application == null)
           {


       ...
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span lang="EN" style="">Next, we'll create the object that represents an instance of our Calculator service hosted on a specific server (SPServer) in the server farm:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class CustomServiceInstance : SPIisWebServiceInstance
   {
       public CustomServiceInstance() { }


       public CustomServiceInstance(SPServer server, CustomService service)
           : base(server, service) { }


       public override string TypeName
       {
           get { return &quot;Custom Service&quot;; }
       }
   }

</pre>
<pre id="codePreview" class="csharp">
public class CustomServiceInstance : SPIisWebServiceInstance
   {
       public CustomServiceInstance() { }


       public CustomServiceInstance(SPServer server, CustomService service)
           : base(server, service) { }


       public override string TypeName
       {
           get { return &quot;Custom Service&quot;; }
       }
   }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0in; margin-bottom:.0001pt; line-height:normal; text-autospace:none">
<span style=""><span style="">&nbsp;</span>A common SQL Server database provisioning infrastructure (to use your own database to store data)
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[System.Runtime.InteropServices.Guid(&quot;FE92B481-00B1-4ad7-9E89-2DFEF629F38A&quot;)]
   internal sealed class CustomServiceDatabase : SPDatabase
   {
       public CustomServiceDatabase() { }


       internal CustomServiceDatabase(SPDatabaseParameters dbParameters)
           : base(dbParameters)
       {
           this.Status = SPObjectStatus.Disabled;
       }


       public override void Provision()
       {
           // stop if DB is already provisioned
           if (SPObjectStatus.Online == this.Status)
               return;


           this.Status = SPObjectStatus.Provisioning;
           this.Update();


           Dictionary&lt;string, bool&gt; options = new Dictionary&lt;string, bool&gt;(1);
           options.Add(SqlDatabaseOption[(int)DatabaseOptions.AutoClose], false);


           SPDatabase.Provision(
               this.DatabaseConnectionString,
               SPUtility.GetGenericSetupPath(@&quot;Template\sql\CustomService.sql&quot;),
               options);


           this.Status = SPObjectStatus.Online;
           this.Update();
       }


       internal void GrantApplicationPoolAccess(SecurityIdentifier processSecurityIdentifier)
       {
           this.GrantAccess(processSecurityIdentifier, &quot;db_owner&quot;);
       }


   }

</pre>
<pre id="codePreview" class="csharp">
[System.Runtime.InteropServices.Guid(&quot;FE92B481-00B1-4ad7-9E89-2DFEF629F38A&quot;)]
   internal sealed class CustomServiceDatabase : SPDatabase
   {
       public CustomServiceDatabase() { }


       internal CustomServiceDatabase(SPDatabaseParameters dbParameters)
           : base(dbParameters)
       {
           this.Status = SPObjectStatus.Disabled;
       }


       public override void Provision()
       {
           // stop if DB is already provisioned
           if (SPObjectStatus.Online == this.Status)
               return;


           this.Status = SPObjectStatus.Provisioning;
           this.Update();


           Dictionary&lt;string, bool&gt; options = new Dictionary&lt;string, bool&gt;(1);
           options.Add(SqlDatabaseOption[(int)DatabaseOptions.AutoClose], false);


           SPDatabase.Provision(
               this.DatabaseConnectionString,
               SPUtility.GetGenericSetupPath(@&quot;Template\sql\CustomService.sql&quot;),
               options);


           this.Status = SPObjectStatus.Online;
           this.Update();
       }


       internal void GrantApplicationPoolAccess(SecurityIdentifier processSecurityIdentifier)
       {
           this.GrantAccess(processSecurityIdentifier, &quot;db_owner&quot;);
       }


   }

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public sealed class CustomServiceApplication : SPIisWebServiceApplication, ICustomServiceContract
   {
       [Persisted]
       private int _setting;


       [Persisted]
       private CustomServiceDatabase _database;


       #region constructors
       public CustomServiceApplication() { }


       private CustomServiceApplication(
           string name,
           CustomService service,
           SPIisWebServiceApplicationPool applicationPool,
           CustomServiceDatabase database)
           : base(name, service, applicationPool)
       {
           if (database == null)
               throw new ArgumentNullException(&quot;database&quot;);


           _database = database;
       }
       #endregion


       public static CustomServiceApplication Create(string name, CustomService service, SPIisWebServiceApplicationPool applicationPool, SPDatabaseParameters databaseParameters)
       {
           #region validation
           if (null == name)
               throw new ArgumentNullException(&quot;name&quot;);


           if (null == service)
               throw new ArgumentNullException(&quot;service&quot;);


           if (null == applicationPool)
               throw new ArgumentNullException(&quot;applicationPool&quot;);


           if (null == databaseParameters)
               throw new ArgumentNullException(&quot;databaseParameters&quot;);
           #endregion


           // Register the database
           CustomServiceDatabase database = new CustomServiceDatabase(databaseParameters);
           database.Update();


           // Create and persist the service application
           CustomServiceApplication serviceApplication = new CustomServiceApplication(
               name,
               service,
               applicationPool,
               database);
           serviceApplication.Update();


           // register supported endpoints
           serviceApplication.AddServiceEndpoint(&quot;tcp&quot;, SPIisWebServiceBindingType.NetTcp);
           serviceApplication.AddServiceEndpoint(&quot;tcp-ssl&quot;, SPIisWebServiceBindingType.NetTcp, &quot;secure&quot;);
           serviceApplication.AddServiceEndpoint(&quot;http&quot;, SPIisWebServiceBindingType.Http);
           serviceApplication.AddServiceEndpoint(&quot;https&quot;, SPIisWebServiceBindingType.Https, &quot;secure&quot;);


           return serviceApplication;
       }


       #region Required serice app details...
       protected override string DefaultEndpointName
       {
           get { return &quot;http&quot;; }
       }


       public override string TypeName
       {
           get { return &quot;Custom Service Application&quot;; }
       }


       protected override string InstallPath
       {
           get { return SPUtility.GetGenericSetupPath(@&quot;WebServices\CustomService&quot;); }
       }


       protected override string VirtualPath
       {
           get { return &quot;CustomService.svc&quot;; }
       }


       public override Guid ApplicationClassId
       {
           get { return new Guid(&quot;A12A5C1C-9784-4118-BF9D-B58B24337E34&quot;); }
       }


       public override Version ApplicationVersion
       {
           get { return new Version(&quot;1.0.0.0&quot;); }
       }
       #endregion


       /// &lt;summary&gt;
       /// Setting persisted in configuration database.
       /// &lt;/summary&gt;
       public int Setting
       {
           get { return _setting; }


           // NOTE: Since this method requires an access check, it must impersonate the client.
           [OperationBehavior(Impersonation = ImpersonationOption.Required)]
           set
           {
               // Demand the &quot;Write&quot; custom administration right
               DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write);


               _setting = value;
           }
       }


       public override void Provision()
       {
           _database.Provision();
           base.Provision();
       }


       public override void Unprovision(bool deleteData)
       {
           base.Unprovision(deleteData);
           _database.Unprovision();
       }


       protected override void OnProcessIdentityChanged(SecurityIdentifier processSecurityIdentifier)
       {
           base.OnProcessIdentityChanged(processSecurityIdentifier);
           _database.GrantApplicationPoolAccess(processSecurityIdentifier);
       }


       /// &lt;summary&gt;
       /// Target location admin is sent to from within CA when clicking on Service App or 
       /// selecting it and picking Manage in the ribbon from CA &gt; Manage Service Apps page.
       /// &lt;/summary&gt;
       public override SPAdministrationLink ManageLink
       {
           get { return new SPAdministrationLink(&quot;/_admin/ManageSample?id=&quot; &#43; this.Id.ToString()); }
       }


       /// &lt;summary&gt;
       /// Target location admin is sent to from within CA when selecting the service all
       /// and picking Properties in the ribbon from CA &gt; Manage Service Apps page.
       /// &lt;/summary&gt;
       public override SPAdministrationLink PropertiesLink
       {
           get { return new SPAdministrationLink(&quot;/_admin/EditSample?id=&quot; &#43; this.Id.ToString()); }
       }


       #region Custom Permissions & Access Rights
       /// &lt;summary&gt;
       /// Override the default named administration access rights to include custom rights.
       /// These options will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Administrators
       /// &lt;/summary&gt;
       /// &lt;remarks&gt;The returned items will be used for display in the ACL editor UI 
       /// control and the PowerShell Grant and Revoke Cmdlets.&lt;/remarks&gt;
       protected override SPNamedCentralAdministrationRights[] AdministrationAccessRights
       {
           get
           {
               return new SPNamedCentralAdministrationRights[]
               {
                   SPNamedCentralAdministrationRights.FullControl,
                   new SPNamedCentralAdministrationRights(&quot;Modify&quot;, SPCentralAdministrationRights.Read | CustomServiceCentralAdministrationRights.Write),
                   SPNamedCentralAdministrationRights.Read,
               };
           }
       }


       /// &lt;summary&gt;
       /// Override the default access rights to include custom rights.
       /// These optiosn will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Permissions
       /// &lt;/summary&gt;
       /// &lt;remarks&gt;These can be used to ensure the caller has specific rights granted to it, and enforced in 
       /// the caller below using the DemandAccess() method.&lt;/remarks&gt;
       protected override SPNamedIisWebServiceApplicationRights[] AccessRights
       {
           get
           {
               return new SPNamedIisWebServiceApplicationRights[]{
                   SPNamedIisWebServiceApplicationRights.FullControl, 
                   new SPNamedIisWebServiceApplicationRights(&quot;Add&quot;, CustomServiceAccessRights.Add),
                   new SPNamedIisWebServiceApplicationRights(&quot;Subtract&quot;, CustomServiceAccessRights.Subtract),
                   SPNamedIisWebServiceApplicationRights.Read
               };
           }
       }
       #endregion

</pre>
<pre id="codePreview" class="csharp">
public sealed class CustomServiceApplication : SPIisWebServiceApplication, ICustomServiceContract
   {
       [Persisted]
       private int _setting;


       [Persisted]
       private CustomServiceDatabase _database;


       #region constructors
       public CustomServiceApplication() { }


       private CustomServiceApplication(
           string name,
           CustomService service,
           SPIisWebServiceApplicationPool applicationPool,
           CustomServiceDatabase database)
           : base(name, service, applicationPool)
       {
           if (database == null)
               throw new ArgumentNullException(&quot;database&quot;);


           _database = database;
       }
       #endregion


       public static CustomServiceApplication Create(string name, CustomService service, SPIisWebServiceApplicationPool applicationPool, SPDatabaseParameters databaseParameters)
       {
           #region validation
           if (null == name)
               throw new ArgumentNullException(&quot;name&quot;);


           if (null == service)
               throw new ArgumentNullException(&quot;service&quot;);


           if (null == applicationPool)
               throw new ArgumentNullException(&quot;applicationPool&quot;);


           if (null == databaseParameters)
               throw new ArgumentNullException(&quot;databaseParameters&quot;);
           #endregion


           // Register the database
           CustomServiceDatabase database = new CustomServiceDatabase(databaseParameters);
           database.Update();


           // Create and persist the service application
           CustomServiceApplication serviceApplication = new CustomServiceApplication(
               name,
               service,
               applicationPool,
               database);
           serviceApplication.Update();


           // register supported endpoints
           serviceApplication.AddServiceEndpoint(&quot;tcp&quot;, SPIisWebServiceBindingType.NetTcp);
           serviceApplication.AddServiceEndpoint(&quot;tcp-ssl&quot;, SPIisWebServiceBindingType.NetTcp, &quot;secure&quot;);
           serviceApplication.AddServiceEndpoint(&quot;http&quot;, SPIisWebServiceBindingType.Http);
           serviceApplication.AddServiceEndpoint(&quot;https&quot;, SPIisWebServiceBindingType.Https, &quot;secure&quot;);


           return serviceApplication;
       }


       #region Required serice app details...
       protected override string DefaultEndpointName
       {
           get { return &quot;http&quot;; }
       }


       public override string TypeName
       {
           get { return &quot;Custom Service Application&quot;; }
       }


       protected override string InstallPath
       {
           get { return SPUtility.GetGenericSetupPath(@&quot;WebServices\CustomService&quot;); }
       }


       protected override string VirtualPath
       {
           get { return &quot;CustomService.svc&quot;; }
       }


       public override Guid ApplicationClassId
       {
           get { return new Guid(&quot;A12A5C1C-9784-4118-BF9D-B58B24337E34&quot;); }
       }


       public override Version ApplicationVersion
       {
           get { return new Version(&quot;1.0.0.0&quot;); }
       }
       #endregion


       /// &lt;summary&gt;
       /// Setting persisted in configuration database.
       /// &lt;/summary&gt;
       public int Setting
       {
           get { return _setting; }


           // NOTE: Since this method requires an access check, it must impersonate the client.
           [OperationBehavior(Impersonation = ImpersonationOption.Required)]
           set
           {
               // Demand the &quot;Write&quot; custom administration right
               DemandAdministrationAccess(CustomServiceCentralAdministrationRights.Write);


               _setting = value;
           }
       }


       public override void Provision()
       {
           _database.Provision();
           base.Provision();
       }


       public override void Unprovision(bool deleteData)
       {
           base.Unprovision(deleteData);
           _database.Unprovision();
       }


       protected override void OnProcessIdentityChanged(SecurityIdentifier processSecurityIdentifier)
       {
           base.OnProcessIdentityChanged(processSecurityIdentifier);
           _database.GrantApplicationPoolAccess(processSecurityIdentifier);
       }


       /// &lt;summary&gt;
       /// Target location admin is sent to from within CA when clicking on Service App or 
       /// selecting it and picking Manage in the ribbon from CA &gt; Manage Service Apps page.
       /// &lt;/summary&gt;
       public override SPAdministrationLink ManageLink
       {
           get { return new SPAdministrationLink(&quot;/_admin/ManageSample?id=&quot; &#43; this.Id.ToString()); }
       }


       /// &lt;summary&gt;
       /// Target location admin is sent to from within CA when selecting the service all
       /// and picking Properties in the ribbon from CA &gt; Manage Service Apps page.
       /// &lt;/summary&gt;
       public override SPAdministrationLink PropertiesLink
       {
           get { return new SPAdministrationLink(&quot;/_admin/EditSample?id=&quot; &#43; this.Id.ToString()); }
       }


       #region Custom Permissions & Access Rights
       /// &lt;summary&gt;
       /// Override the default named administration access rights to include custom rights.
       /// These options will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Administrators
       /// &lt;/summary&gt;
       /// &lt;remarks&gt;The returned items will be used for display in the ACL editor UI 
       /// control and the PowerShell Grant and Revoke Cmdlets.&lt;/remarks&gt;
       protected override SPNamedCentralAdministrationRights[] AdministrationAccessRights
       {
           get
           {
               return new SPNamedCentralAdministrationRights[]
               {
                   SPNamedCentralAdministrationRights.FullControl,
                   new SPNamedCentralAdministrationRights(&quot;Modify&quot;, SPCentralAdministrationRights.Read | CustomServiceCentralAdministrationRights.Write),
                   SPNamedCentralAdministrationRights.Read,
               };
           }
       }


       /// &lt;summary&gt;
       /// Override the default access rights to include custom rights.
       /// These optiosn will show in the CA &gt; Manage Service Apps &gt; [select service app] &gt; Permissions
       /// &lt;/summary&gt;
       /// &lt;remarks&gt;These can be used to ensure the caller has specific rights granted to it, and enforced in 
       /// the caller below using the DemandAccess() method.&lt;/remarks&gt;
       protected override SPNamedIisWebServiceApplicationRights[] AccessRights
       {
           get
           {
               return new SPNamedIisWebServiceApplicationRights[]{
                   SPNamedIisWebServiceApplicationRights.FullControl, 
                   new SPNamedIisWebServiceApplicationRights(&quot;Add&quot;, CustomServiceAccessRights.Add),
                   new SPNamedIisWebServiceApplicationRights(&quot;Subtract&quot;, CustomServiceAccessRights.Subtract),
                   SPNamedIisWebServiceApplicationRights.Read
               };
           }
       }
       #endregion

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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[Cmdlet(VerbsLifecycle.Install, &quot;CustomService&quot;, SupportsShouldProcess = true)]
   public class InstallCustomService : SPCmdlet
   {
       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff


           SPFarm farm = SPFarm.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           SPServer server = SPServer.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           #endregion






           if (ShouldProcess(&quot;Custom Service&quot;))
           {
               // ensure the custom service exists
               CustomService service = farm.Services.GetValue&lt;CustomService&gt;();


               // if the service is NOT already installed, install it
               if (service == null)
               {
                   // create the service
                   service = new CustomService(farm);
                   service.Update();
               }


               // with the service added to the farm, see if there is a running instance on the server... 
               //   if not, create it
               CustomServiceInstance serverSvcInstance = new CustomServiceInstance(server, service);
               serverSvcInstance.Update(true);
           }
       }
   }


   [Cmdlet(VerbsCommon.New, &quot;CustomServiceApplication&quot;, SupportsShouldProcess = true)]
   public class NewCustomServiceApplication : SPCmdlet
   {
       private const string DbPrefix = &quot;CustomService&quot;;


       #region Cmdlet Parameters
       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string Name;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public SPIisWebServiceApplicationPoolPipeBind ApplicationPool;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public string DatabaseServer;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public string FailoverDatabaseServer;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string DatabaseName;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public PSCredential DatabaseCredentials;
       #endregion


       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff
           // ensure can hit farm
           SPFarm farm = SPFarm.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit local server
           SPServer server = SPServer.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit service application
           CustomService service = farm.Services.GetValue&lt;CustomService&gt;();
           if (service == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Custom Service not found (likely not installed).&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit app pool
           SPIisWebServiceApplicationPool appPool = this.ApplicationPool.Read();
           if (appPool == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Application pool not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit database
           string dbServer = this.DatabaseServer;
           if (string.IsNullOrEmpty(dbServer))
           {
               dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource;
           }
           #endregion


           // ensure a service application does not already exist
           CustomServiceApplication existingCustomServiceApp = service.Applications.GetValue&lt;CustomServiceApplication&gt;();
           if (existingCustomServiceApp != null)
           {
               WriteError(new InvalidOperationException(&quot;Custom service application already exists.&quot;),
                   ErrorCategory.ResourceExists,
                   existingCustomServiceApp);
               SkipProcessCurrentRecord();
           }


           // get database credentials
           string dbUsername = null;
           string dbPassword = null;
           if (DatabaseCredentials != null)
           {
               NetworkCredential dbCredential = (NetworkCredential)DatabaseCredentials;
               dbUsername = dbCredential.UserName;
               dbPassword = dbCredential.Password;
           }


           SPDatabaseParameterOptions dbOptions = SPDatabaseParameterOptions.None;


           // get database name
           string dbName = DatabaseName;
           if (dbName == null)
           {
               dbName = &quot;CustomServiceDB&quot;;
               dbOptions = SPDatabaseParameterOptions.GenerateUniqueName;
           }


           // create settings for a new database
           SPDatabaseParameters dbParameters = SPDatabaseParameters.CreateParameters(
               dbName,
               dbServer,
               dbUsername,
               dbPassword,
               FailoverDatabaseServer,
               dbOptions);


           // create & provision the service application 
           if (ShouldProcess(this.Name))
           {
               CustomServiceApplication serviceApp = CustomServiceApplication.Create(
                   this.Name,
                   service,
                   appPool,
                   dbParameters);


               // provision the service app
               serviceApp.Provision();


               // pass service app to the PS pipeline
               WriteObject(serviceApp);
           }
       }
   }

</pre>
<pre id="codePreview" class="csharp">
[Cmdlet(VerbsLifecycle.Install, &quot;CustomService&quot;, SupportsShouldProcess = true)]
   public class InstallCustomService : SPCmdlet
   {
       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff


           SPFarm farm = SPFarm.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           SPServer server = SPServer.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           #endregion






           if (ShouldProcess(&quot;Custom Service&quot;))
           {
               // ensure the custom service exists
               CustomService service = farm.Services.GetValue&lt;CustomService&gt;();


               // if the service is NOT already installed, install it
               if (service == null)
               {
                   // create the service
                   service = new CustomService(farm);
                   service.Update();
               }


               // with the service added to the farm, see if there is a running instance on the server... 
               //   if not, create it
               CustomServiceInstance serverSvcInstance = new CustomServiceInstance(server, service);
               serverSvcInstance.Update(true);
           }
       }
   }


   [Cmdlet(VerbsCommon.New, &quot;CustomServiceApplication&quot;, SupportsShouldProcess = true)]
   public class NewCustomServiceApplication : SPCmdlet
   {
       private const string DbPrefix = &quot;CustomService&quot;;


       #region Cmdlet Parameters
       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string Name;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public SPIisWebServiceApplicationPoolPipeBind ApplicationPool;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public string DatabaseServer;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public string FailoverDatabaseServer;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string DatabaseName;


       [Parameter(Mandatory = false)]
       [ValidateNotNullOrEmpty]
       public PSCredential DatabaseCredentials;
       #endregion


       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff
           // ensure can hit farm
           SPFarm farm = SPFarm.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit local server
           SPServer server = SPServer.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit service application
           CustomService service = farm.Services.GetValue&lt;CustomService&gt;();
           if (service == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Custom Service not found (likely not installed).&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit app pool
           SPIisWebServiceApplicationPool appPool = this.ApplicationPool.Read();
           if (appPool == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Application pool not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure can hit database
           string dbServer = this.DatabaseServer;
           if (string.IsNullOrEmpty(dbServer))
           {
               dbServer = SPWebService.ContentService.DefaultDatabaseInstance.NormalizedDataSource;
           }
           #endregion


           // ensure a service application does not already exist
           CustomServiceApplication existingCustomServiceApp = service.Applications.GetValue&lt;CustomServiceApplication&gt;();
           if (existingCustomServiceApp != null)
           {
               WriteError(new InvalidOperationException(&quot;Custom service application already exists.&quot;),
                   ErrorCategory.ResourceExists,
                   existingCustomServiceApp);
               SkipProcessCurrentRecord();
           }


           // get database credentials
           string dbUsername = null;
           string dbPassword = null;
           if (DatabaseCredentials != null)
           {
               NetworkCredential dbCredential = (NetworkCredential)DatabaseCredentials;
               dbUsername = dbCredential.UserName;
               dbPassword = dbCredential.Password;
           }


           SPDatabaseParameterOptions dbOptions = SPDatabaseParameterOptions.None;


           // get database name
           string dbName = DatabaseName;
           if (dbName == null)
           {
               dbName = &quot;CustomServiceDB&quot;;
               dbOptions = SPDatabaseParameterOptions.GenerateUniqueName;
           }


           // create settings for a new database
           SPDatabaseParameters dbParameters = SPDatabaseParameters.CreateParameters(
               dbName,
               dbServer,
               dbUsername,
               dbPassword,
               FailoverDatabaseServer,
               dbOptions);


           // create & provision the service application 
           if (ShouldProcess(this.Name))
           {
               CustomServiceApplication serviceApp = CustomServiceApplication.Create(
                   this.Name,
                   service,
                   appPool,
                   dbParameters);


               // provision the service app
               serviceApp.Provision();


               // pass service app to the PS pipeline
               WriteObject(serviceApp);
           }
       }
   }

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
  &lt;ps:Assembly Name=&quot;CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InstallCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplication&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.NewCustomServiceApplication&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InstallCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplication&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.NewCustomServiceApplication&lt;/ps:ClassName&gt;
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[IisWebServiceApplicationProxyBackupBehavior]
    [Guid(&quot;D409CE5C-19BD-4269-8B16-8F3EDCCB1039&quot;)]
    public sealed class CustomServiceApplicationProxy : SPIisWebServiceApplicationProxy
    {
        // these are used in caching the client channel factory
        private ChannelFactory&lt;ICustomServiceContract&gt; _channelFactory;
        private object _channelFactoryLock = new object();
        private string _endpointConfigName;


        [Persisted]
        private SPServiceLoadBalancer _loadBalancer;


        #region constructors
        public CustomServiceApplicationProxy() { }


        public CustomServiceApplicationProxy(string name, CustomServiceProxy serviceProxy, Uri serviceAppAddress)
            : base(name, serviceProxy, serviceAppAddress)
        {
            // create a new round robin load balancer
            _loadBalancer = new SPRoundRobinServiceLoadBalancer(serviceAppAddress);
        }
        #endregion


        #region app proxy infrastructure
        private ChannelFactory&lt;T&gt; CreateChannelFactory&lt;T&gt;(string endpointConfigName)
        {
…

</pre>
<pre id="codePreview" class="csharp">
[IisWebServiceApplicationProxyBackupBehavior]
    [Guid(&quot;D409CE5C-19BD-4269-8B16-8F3EDCCB1039&quot;)]
    public sealed class CustomServiceApplicationProxy : SPIisWebServiceApplicationProxy
    {
        // these are used in caching the client channel factory
        private ChannelFactory&lt;ICustomServiceContract&gt; _channelFactory;
        private object _channelFactoryLock = new object();
        private string _endpointConfigName;


        [Persisted]
        private SPServiceLoadBalancer _loadBalancer;


        #region constructors
        public CustomServiceApplicationProxy() { }


        public CustomServiceApplicationProxy(string name, CustomServiceProxy serviceProxy, Uri serviceAppAddress)
            : base(name, serviceProxy, serviceAppAddress)
        {
            // create a new round robin load balancer
            _loadBalancer = new SPRoundRobinServiceLoadBalancer(serviceAppAddress);
        }
        #endregion


        #region app proxy infrastructure
        private ChannelFactory&lt;T&gt; CreateChannelFactory&lt;T&gt;(string endpointConfigName)
        {
…

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 8:</span><span style="">
</span><span style="color:black">Build a client application. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public sealed class CustomServiceClient
  {
      private SPServiceContext _serviceContext;


      public CustomServiceClient(SPServiceContext serviceContext)
      {
          if (serviceContext == null)
              throw new ArgumentNullException(&quot;serviceContext&quot;);


          _serviceContext = serviceContext;
      }


      public int Add(int a, int b)
      {
          return Add(a, b, ExecuteOptions.None);
      }


      public int Add(int a, int b, ExecuteOptions options)
      {
          int sum = 0;
          CustomServiceApplicationProxy.Invoke(_serviceContext, proxy =&gt; sum = proxy.Add(a, b, options));
          return sum;
      }


      public string HelloWorld()
      {
          return HelloWorld(ExecuteOptions.None);
      }


      public string HelloWorld(ExecuteOptions options)
      {
          string result = string.Empty;


          CustomServiceApplicationProxy.Invoke(_serviceContext, proxy =&gt; result = proxy.HelloWorld(options));


          return result;
      }
  }

</pre>
<pre id="codePreview" class="csharp">
public sealed class CustomServiceClient
  {
      private SPServiceContext _serviceContext;


      public CustomServiceClient(SPServiceContext serviceContext)
      {
          if (serviceContext == null)
              throw new ArgumentNullException(&quot;serviceContext&quot;);


          _serviceContext = serviceContext;
      }


      public int Add(int a, int b)
      {
          return Add(a, b, ExecuteOptions.None);
      }


      public int Add(int a, int b, ExecuteOptions options)
      {
          int sum = 0;
          CustomServiceApplicationProxy.Invoke(_serviceContext, proxy =&gt; sum = proxy.Add(a, b, options));
          return sum;
      }


      public string HelloWorld()
      {
          return HelloWorld(ExecuteOptions.None);
      }


      public string HelloWorld(ExecuteOptions options)
      {
          string result = string.Empty;


          CustomServiceApplicationProxy.Invoke(_serviceContext, proxy =&gt; result = proxy.HelloWorld(options));


          return result;
      }
  }

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="line-height:normal"><span style="">Step 9:</span><span style="">
</span><span style="color:black">Write the service application proxy installation code
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[Cmdlet(VerbsLifecycle.Install, &quot;CustomServiceProxy&quot;, SupportsShouldProcess = true)]
   public class InstallCustomServiceProxy : SPCmdlet
   {
       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff


           SPFarm farm = SPFarm.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           SPServer server = SPServer.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           #endregion


           // install the service proxy into the farm if isn't already installed
           if (ShouldProcess(&quot;Custom Service Proxy&quot;))
           {
               CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue&lt;CustomServiceProxy&gt;();


               if (serviceProxy == null)
               {
                   serviceProxy = new CustomServiceProxy(farm);
                   serviceProxy.Update(true);
               }
           }
       }
   }


   [Cmdlet(VerbsCommon.New, &quot;CustomServiceApplicationProxy&quot;, SupportsShouldProcess = true)]
   public class NewCustomServiceApplicationProxy : SPCmdlet
   {
       private string _name;
       private Uri _uri;
       private SPServiceApplicationPipeBind _pipeBind;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }


       [Parameter(Mandatory = true, ParameterSetName = &quot;Uri&quot;)]
       [ValidateNotNullOrEmpty]
       public string Uri
       {
           get { return _uri.ToString(); }
           set { _uri = new Uri(value); }
       }


       [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = &quot;ServiceApplication&quot;)]
       public SPServiceApplicationPipeBind ServiceApplication
       {
           get { return _pipeBind; }
           set { _pipeBind = value; }
       }


       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff
           // ensure can hit farm
           SPFarm farm = SPFarm.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure the service proxy is installed
           CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue&lt;CustomServiceProxy&gt;();
           if (serviceProxy == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Custom service application proxy not found.&quot;), ErrorCategory.NotInstalled, this);
           }


           // ensure the proxy isn't already created
           CustomServiceApplicationProxy existingServiceAppProxy = serviceProxy.ApplicationProxies.GetValue&lt;CustomServiceApplicationProxy&gt;();
           if (existingServiceAppProxy != null)
           {
               WriteError(new InvalidOperationException(&quot;Custom service application proxy already exists.&quot;), ErrorCategory.ResourceExists, existingServiceAppProxy);
               // skip this command
               SkipProcessCurrentRecord();
           }
           #endregion


           Uri serviceAppUri = null;
           if (ParameterSetName == &quot;Uri&quot;)
               serviceAppUri = _uri;
           else if (ParameterSetName == &quot;ServiceApplication&quot;)
           {
               SPServiceApplication serviceApp = _pipeBind.Read();
               if (serviceApp == null)
               {
                   WriteError(new InvalidOperationException(&quot;Service application not found.&quot;), ErrorCategory.ResourceExists, serviceApp);
                   SkipProcessCurrentRecord();
               }


               ISharedServiceApplication sharedServiceApp = serviceApp as ISharedServiceApplication;
               if (sharedServiceApp == null)
               {
                   WriteError(new InvalidOperationException(&quot;Connecting to specified service application is not supported.&quot;), ErrorCategory.ResourceExists, serviceApp);
                   SkipProcessCurrentRecord();
               }


               serviceAppUri = sharedServiceApp.Uri;
           }
           else
               ThrowTerminatingError(new InvalidOperationException(&quot;Invalid parameter set.&quot;), ErrorCategory.InvalidArgument, this);


           if ((serviceAppUri != null) && ShouldProcess(Name))
           {
               // create service app proxy
               CustomServiceApplicationProxy serviceAppProxy = new CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri);


               // provision the sample service app proxy
               serviceAppProxy.Provision();


               // write new sample service app proxy to pipeline
               WriteObject(serviceAppProxy);
           }


       }
   }


   [Cmdlet(&quot;Invoke&quot;, &quot;CustomService&quot;, SupportsShouldProcess = true)]
   public class InvokeCustomService : SPCmdlet
   {
       private int[] _values;
       private SPServiceContextPipeBind _serviceContext;


       [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
       public SPServiceContextPipeBind ServiceContext
       {
           get { return _serviceContext; }
           set { _serviceContext = value; }
       }


       [Parameter(ParameterSetName = &quot;Add&quot;, Mandatory = true)]
       public int[] Add
       {
           get { return _values; }
           set { _values = value; }
       }


       protected override void InternalProcessRecord()
       {
           // Read the specified service context pipebind
           SPServiceContext serviceCtx = _serviceContext.Read();
           if (serviceCtx == null)
           {
               WriteError(new InvalidOperationException(&quot;Invalid service context.&quot;),
                   ErrorCategory.ResourceExists, serviceCtx);


               return;
           }
           else
           {
               // Create a new Service client
               CustomServiceClient client = new CustomServiceClient(serviceCtx);


               // validate at least two values were passed in
               if (_values.Length &lt; 2)
                   WriteError(new InvalidOperationException(&quot;A minimum of two values are required for this operation.&quot;), ErrorCategory.InvalidArgument, _values);
               else
               {
                   // loop through all values passed in, calling the service app, to add them up
                   int sum = _values[0];
                   for (int x = 1; x &lt; _values.Length; x&#43;&#43;)
                       sum = client.Add(sum, _values[x], ExecuteOptions.None);


                   // write the results
                   WriteObject(sum);
               }


               // result 
               string result = client.HelloWorld();


               // Write the sum to the pipeline
               this.WriteObject(result);
           }
       }


   }
}

</pre>
<pre id="codePreview" class="csharp">
[Cmdlet(VerbsLifecycle.Install, &quot;CustomServiceProxy&quot;, SupportsShouldProcess = true)]
   public class InstallCustomServiceProxy : SPCmdlet
   {
       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff


           SPFarm farm = SPFarm.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           SPServer server = SPServer.Local;
           if (farm == null)
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint local server not found.&quot;), ErrorCategory.ResourceUnavailable, this);


           #endregion


           // install the service proxy into the farm if isn't already installed
           if (ShouldProcess(&quot;Custom Service Proxy&quot;))
           {
               CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue&lt;CustomServiceProxy&gt;();


               if (serviceProxy == null)
               {
                   serviceProxy = new CustomServiceProxy(farm);
                   serviceProxy.Update(true);
               }
           }
       }
   }


   [Cmdlet(VerbsCommon.New, &quot;CustomServiceApplicationProxy&quot;, SupportsShouldProcess = true)]
   public class NewCustomServiceApplicationProxy : SPCmdlet
   {
       private string _name;
       private Uri _uri;
       private SPServiceApplicationPipeBind _pipeBind;


       [Parameter(Mandatory = true)]
       [ValidateNotNullOrEmpty]
       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }


       [Parameter(Mandatory = true, ParameterSetName = &quot;Uri&quot;)]
       [ValidateNotNullOrEmpty]
       public string Uri
       {
           get { return _uri.ToString(); }
           set { _uri = new Uri(value); }
       }


       [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = &quot;ServiceApplication&quot;)]
       public SPServiceApplicationPipeBind ServiceApplication
       {
           get { return _pipeBind; }
           set { _pipeBind = value; }
       }


       protected override bool RequireUserFarmAdmin()
       {
           return true;
       }


       protected override void InternalProcessRecord()
       {
           #region validation stuff
           // ensure can hit farm
           SPFarm farm = SPFarm.Local;
           if (farm == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;SharePoint farm not found.&quot;), ErrorCategory.ResourceUnavailable, this);
               SkipProcessCurrentRecord();
           }


           // ensure the service proxy is installed
           CustomServiceProxy serviceProxy = farm.ServiceProxies.GetValue&lt;CustomServiceProxy&gt;();
           if (serviceProxy == null)
           {
               ThrowTerminatingError(new InvalidOperationException(&quot;Custom service application proxy not found.&quot;), ErrorCategory.NotInstalled, this);
           }


           // ensure the proxy isn't already created
           CustomServiceApplicationProxy existingServiceAppProxy = serviceProxy.ApplicationProxies.GetValue&lt;CustomServiceApplicationProxy&gt;();
           if (existingServiceAppProxy != null)
           {
               WriteError(new InvalidOperationException(&quot;Custom service application proxy already exists.&quot;), ErrorCategory.ResourceExists, existingServiceAppProxy);
               // skip this command
               SkipProcessCurrentRecord();
           }
           #endregion


           Uri serviceAppUri = null;
           if (ParameterSetName == &quot;Uri&quot;)
               serviceAppUri = _uri;
           else if (ParameterSetName == &quot;ServiceApplication&quot;)
           {
               SPServiceApplication serviceApp = _pipeBind.Read();
               if (serviceApp == null)
               {
                   WriteError(new InvalidOperationException(&quot;Service application not found.&quot;), ErrorCategory.ResourceExists, serviceApp);
                   SkipProcessCurrentRecord();
               }


               ISharedServiceApplication sharedServiceApp = serviceApp as ISharedServiceApplication;
               if (sharedServiceApp == null)
               {
                   WriteError(new InvalidOperationException(&quot;Connecting to specified service application is not supported.&quot;), ErrorCategory.ResourceExists, serviceApp);
                   SkipProcessCurrentRecord();
               }


               serviceAppUri = sharedServiceApp.Uri;
           }
           else
               ThrowTerminatingError(new InvalidOperationException(&quot;Invalid parameter set.&quot;), ErrorCategory.InvalidArgument, this);


           if ((serviceAppUri != null) && ShouldProcess(Name))
           {
               // create service app proxy
               CustomServiceApplicationProxy serviceAppProxy = new CustomServiceApplicationProxy(Name, serviceProxy, serviceAppUri);


               // provision the sample service app proxy
               serviceAppProxy.Provision();


               // write new sample service app proxy to pipeline
               WriteObject(serviceAppProxy);
           }


       }
   }


   [Cmdlet(&quot;Invoke&quot;, &quot;CustomService&quot;, SupportsShouldProcess = true)]
   public class InvokeCustomService : SPCmdlet
   {
       private int[] _values;
       private SPServiceContextPipeBind _serviceContext;


       [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0)]
       public SPServiceContextPipeBind ServiceContext
       {
           get { return _serviceContext; }
           set { _serviceContext = value; }
       }


       [Parameter(ParameterSetName = &quot;Add&quot;, Mandatory = true)]
       public int[] Add
       {
           get { return _values; }
           set { _values = value; }
       }


       protected override void InternalProcessRecord()
       {
           // Read the specified service context pipebind
           SPServiceContext serviceCtx = _serviceContext.Read();
           if (serviceCtx == null)
           {
               WriteError(new InvalidOperationException(&quot;Invalid service context.&quot;),
                   ErrorCategory.ResourceExists, serviceCtx);


               return;
           }
           else
           {
               // Create a new Service client
               CustomServiceClient client = new CustomServiceClient(serviceCtx);


               // validate at least two values were passed in
               if (_values.Length &lt; 2)
                   WriteError(new InvalidOperationException(&quot;A minimum of two values are required for this operation.&quot;), ErrorCategory.InvalidArgument, _values);
               else
               {
                   // loop through all values passed in, calling the service app, to add them up
                   int sum = _values[0];
                   for (int x = 1; x &lt; _values.Length; x&#43;&#43;)
                       sum = client.Add(sum, _values[x], ExecuteOptions.None);


                   // write the results
                   WriteObject(sum);
               }


               // result 
               string result = client.HelloWorld();


               // Write the sum to the pipeline
               this.WriteObject(result);
           }
       }


   }
}

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
  &lt;ps:Assembly Name=&quot;CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomServiceProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InstallCustomServiceProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplicationProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.NewCustomServiceApplicationProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Invoke-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InvokeCustomService&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
  &lt;/ps:Assembly&gt;
&lt;/ps:Config&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;ps:Config xmlns:ps=&quot;urn:Microsoft.SharePoint.PowerShell&quot;
           xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;
           xmlns:schemaLocation=&quot;urn:Microsoft.SharePoint.PowerShell  SPCmdletSchema.xml&quot;&gt;
  &lt;ps:Assembly Name=&quot;CustomService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=2cb5dde18d8cf06f&quot;&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Install-CustomServiceProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InstallCustomServiceProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;New-CustomServiceApplicationProxy&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.NewCustomServiceApplicationProxy&lt;/ps:ClassName&gt;
      &lt;ps:HelpFile /&gt;
    &lt;/ps:Cmdlet&gt;
    &lt;ps:Cmdlet&gt;
      &lt;ps:VerbName&gt;Invoke-CustomService&lt;/ps:VerbName&gt;
      &lt;ps:ClassName&gt;CustomService.PowerShell.InvokeCustomService&lt;/ps:ClassName&gt;
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
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
CustomServiceClient client = new CustomServiceClient(SPServiceContext.Current);


           int sum = client.Add(1, 1);


           string strSayHello = client.HelloWorld();


           TestOutputLabel.Text = String.Format(&quot;1 &#43; 1 = {0}&quot;, sum) &#43; &quot;<br>&quot; &#43; strSayHello;

</pre>
<pre id="codePreview" class="csharp">
CustomServiceClient client = new CustomServiceClient(SPServiceContext.Current);


           int sum = client.Add(1, 1);


           string strSayHello = client.HelloWorld();


           TestOutputLabel.Text = String.Format(&quot;1 &#43; 1 = {0}&quot;, sum) &#43; &quot;<br>&quot; &#43; strSayHello;

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
