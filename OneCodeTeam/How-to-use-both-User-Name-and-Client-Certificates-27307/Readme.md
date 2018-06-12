# How to use both User Name and Client Certificates as client credential in WCF
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* .NET Development
* Windows Communication Framework (WCF)
## Topics
* WCF
## IsPublished
* True
## ModifiedDate
* 2014-02-18 07:13:48
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodesampletopbanner">
</a></div>
<h1>How to use both User Name and Client Certificates as client credential type in WCF (CSWCFServiceDualAuthentication)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to use both User Name and Client Certificates as client credential type in WCF. A lot of Microsoft customers are harried when they need to use Dual Authentication in WCF and we have a lot of instances of these
 cases being created.</p>
<h2>Building the Project</h2>
<p class="MsoNormal">&nbsp;</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><strong><span><span>A.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>Prerequisites before we create a client and service :
</strong></p>
<p class="MsoListParagraphCxSpMiddle"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Make sure that you have a valid Client Certificate with Private Key.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>The SSL settings should be enabled in IIS</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span>Anonymous Authentication enabled </span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>We need to create custom binding to define the UserName Password Class</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span><span>B.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><strong>Creating a WCF Service (CSWCFServiceDualAuthentication )</strong></p>
<p class="MsoListParagraphCxSpMiddle">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in; text-indent:-.25in">
<strong><span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>In the Visual Studio 2012 create a WCF Service Application.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in; text-indent:-.25in">
<strong><span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Add reference&nbsp;System.ServiceModel<span>&nbsp;to the project.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:1.0in; text-indent:-.25in">
<strong><span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Create IService1.cs interface and define the OperationContract as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceContract]
public interface IService1
{
    [OperationContract]
    string GetData(string value);
}

</pre>
<div class="preview">
<pre class="csharp">[ServiceContract]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IService1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;GetData(<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>);&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:1.0in; text-indent:-.25in"><strong><span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Implement the above interface in Service1.cs as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class Service1 : IService1
{
    public string GetData(string value)
    {
        return string.Format(&quot;You entered: {0}&quot;, value);
    }
}

</pre>
<div class="preview">
<pre class="csharp">[ServiceBehavior(IncludeExceptionDetailInFaults&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Service1&nbsp;:&nbsp;IService1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetData(<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;You&nbsp;entered:&nbsp;{0}&quot;</span>,&nbsp;<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:1.0in; text-indent:-.25in">
<strong><span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Next define the UserNamePassword Validator Class by specifying the UserName and Password as below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class MyUserNamePasswordValidator : UserNamePasswordValidator
   {
       public override void Validate(string userName, string password)
       {
           if (null == userName || null == password)
           {
               throw new ArgumentNullException();
           }

           if (!(userName == &quot;Melissa&quot; &amp;&amp; password == &quot;123@abc&quot;))
           {
               // This throws an informative fault to the client.
               throw new FaultException(&quot;Unknown Username or Incorrect Password&quot;);
              
           }
       }
   }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyUserNamePasswordValidator&nbsp;:&nbsp;UserNamePasswordValidator&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(<span class="cs__keyword">string</span>&nbsp;userName,&nbsp;<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">null</span>&nbsp;==&nbsp;userName&nbsp;||&nbsp;<span class="cs__keyword">null</span>&nbsp;==&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!(userName&nbsp;==&nbsp;<span class="cs__string">&quot;Melissa&quot;</span>&nbsp;&amp;&amp;&nbsp;password&nbsp;==&nbsp;<span class="cs__string">&quot;123@abc&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;throws&nbsp;an&nbsp;informative&nbsp;fault&nbsp;to&nbsp;the&nbsp;client.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;FaultException(<span class="cs__string">&quot;Unknown&nbsp;Username&nbsp;or&nbsp;Incorrect&nbsp;Password&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p class="MsoListParagraph" style="margin-left:1.0in; text-indent:-.25in"><strong><span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Define the Certificate Validator class and check for the Incoming client Certificate by either identifying it by its Issuer Name or thumbprint as below :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class CertificateValidate : X509CertificateValidator
    {  
        public override void Validate(X509Certificate2 Certificate)
        {
            //Check for the certificate

            if (Certificate == null)
                throw new ArgumentNullException(&quot;Unable to find certificate&quot;);

            // Check the Incoming client certificate
            if (Certificate.IssuerName.Name != &quot;CN=MSIT Enterprise CA 2&quot;)
                throw new System.IdentityModel.Tokens.SecurityTokenValidationException(&quot;Cannot find the issuer&quot;);
            }        
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CertificateValidate&nbsp;:&nbsp;X509CertificateValidator&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Validate(X509Certificate2&nbsp;Certificate)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;for&nbsp;the&nbsp;certificate</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Certificate&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;Unable&nbsp;to&nbsp;find&nbsp;certificate&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;the&nbsp;Incoming&nbsp;client&nbsp;certificate</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Certificate.IssuerName.Name&nbsp;!=&nbsp;<span class="cs__string">&quot;CN=MSIT&nbsp;Enterprise&nbsp;CA&nbsp;2&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;System.IdentityModel.Tokens.SecurityTokenValidationException(<span class="cs__string">&quot;Cannot&nbsp;find&nbsp;the&nbsp;issuer&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraph" style="margin-left:1.0in; text-indent:-.25in"><strong><span style="color:black"><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>In the web.config file we need to define the custom binding, endpoint and the behavior for the UserName Password as shown below :
<span style="color:black">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;!-- Define the custom Binding --&gt;
   &lt;bindings&gt;
     &lt;customBinding&gt;
       &lt;binding name=&quot;custom&quot;&gt;
         &lt;security authenticationMode=&quot;UserNameOverTransport&quot; /&gt;
         &lt;textMessageEncoding messageVersion=&quot;Soap11WSAddressing10&quot; /&gt;
         &lt;httpsTransport requireClientCertificate=&quot;true&quot; /&gt;
       &lt;/binding&gt;      
     &lt;/customBinding&gt;
   &lt;/bindings&gt;

   &lt;!-- Define the endpoint --&gt;
   &lt;services&gt;
     &lt;service name=&quot;CSWCFServiceDualAuthentication.Service1&quot; behaviorConfiguration=&quot;serverbehavior&quot;&gt;
       &lt;endpoint address=&quot;https://mesa.fareast.corp.microsoft.com/CSWCFDualAuth/Service1.svc&quot; binding=&quot;customBinding&quot; bindingConfiguration=&quot;custom&quot; name=&quot;custom&quot; contract=&quot;CSWCFServiceDualAuthentication.IService1&quot; /&gt;
     &lt;/service&gt;
   &lt;/services&gt;

   &lt;!-- Define the Service Behavior --&gt;

   &lt;behaviors&gt;
     &lt;serviceBehaviors&gt;
       &lt;behavior name=&quot;serverbehavior&quot;&gt;
         &lt;!-- To avoid disclosing metadata information, set the values below to false before deployment --&gt;
         &lt;serviceMetadata httpGetEnabled=&quot;false&quot; httpsGetEnabled=&quot;true&quot; /&gt;
         &lt;!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information --&gt;
         &lt;serviceDebug includeExceptionDetailInFaults=&quot;true&quot; /&gt;

         &lt;serviceCredentials&gt;

           &lt;!-- &quot;For username and password authentication&quot; --&gt;
           &lt;userNameAuthentication userNamePasswordValidationMode=&quot;Custom&quot; customUserNamePasswordValidatorType=&quot;CSWCFServiceDualAuthentication.MyUserNamePasswordValidator, CSWCFServiceDualAuthentication&quot; /&gt;

           &lt;!--For client certificate Authentication --&gt;
           
           &lt;clientCertificate&gt;
           &lt;authentication certificateValidationMode=&quot;Custom&quot;
                            customCertificateValidatorType=&quot;CSWCFServiceDualAuthentication.CertificateValidate, CSWCFServiceDualAuthentication&quot;/&gt;       
       &lt;/clientCertificate&gt;

         &lt;/serviceCredentials&gt;
       &lt;/behavior&gt;
     &lt;/serviceBehaviors&gt;
   &lt;/behaviors&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__comment">&lt;!--&nbsp;Define&nbsp;the&nbsp;custom&nbsp;Binding&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;bindings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;customBinding</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;binding</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;custom&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;security</span>&nbsp;<span class="xml__attr_name">authenticationMode</span>=<span class="xml__attr_value">&quot;UserNameOverTransport&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;textMessageEncoding</span>&nbsp;<span class="xml__attr_name">messageVersion</span>=<span class="xml__attr_value">&quot;Soap11WSAddressing10&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;httpsTransport</span>&nbsp;<span class="xml__attr_name">requireClientCertificate</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/binding&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/customBinding&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/bindings&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;Define&nbsp;the&nbsp;endpoint&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;services</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;service</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;CSWCFServiceDualAuthentication.Service1&quot;</span>&nbsp;<span class="xml__attr_name">behaviorConfiguration</span>=<span class="xml__attr_value">&quot;serverbehavior&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;endpoint</span>&nbsp;<span class="xml__attr_name">address</span>=<span class="xml__attr_value">&quot;https://mesa.fareast.corp.microsoft.com/CSWCFDualAuth/Service1.svc&quot;</span>&nbsp;<span class="xml__attr_name">binding</span>=<span class="xml__attr_value">&quot;customBinding&quot;</span>&nbsp;<span class="xml__attr_name">bindingConfiguration</span>=<span class="xml__attr_value">&quot;custom&quot;</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;custom&quot;</span>&nbsp;<span class="xml__attr_name">contract</span>=<span class="xml__attr_value">&quot;CSWCFServiceDualAuthentication.IService1&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/service&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/services&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;Define&nbsp;the&nbsp;Service&nbsp;Behavior&nbsp;--&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;behaviors</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceBehaviors</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;behavior</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;serverbehavior&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;To&nbsp;avoid&nbsp;disclosing&nbsp;metadata&nbsp;information,&nbsp;set&nbsp;the&nbsp;values&nbsp;below&nbsp;to&nbsp;false&nbsp;before&nbsp;deployment&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceMetadata</span>&nbsp;<span class="xml__attr_name">httpGetEnabled</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;<span class="xml__attr_name">httpsGetEnabled</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;To&nbsp;receive&nbsp;exception&nbsp;details&nbsp;in&nbsp;faults&nbsp;for&nbsp;debugging&nbsp;purposes,&nbsp;set&nbsp;the&nbsp;value&nbsp;below&nbsp;to&nbsp;true.&nbsp;&nbsp;Set&nbsp;to&nbsp;false&nbsp;before&nbsp;deployment&nbsp;to&nbsp;avoid&nbsp;disclosing&nbsp;exception&nbsp;information&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceDebug</span>&nbsp;<span class="xml__attr_name">includeExceptionDetailInFaults</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;serviceCredentials</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--&nbsp;&quot;For&nbsp;username&nbsp;and&nbsp;password&nbsp;authentication&quot;&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;userNameAuthentication</span>&nbsp;<span class="xml__attr_name">userNamePasswordValidationMode</span>=<span class="xml__attr_value">&quot;Custom&quot;</span>&nbsp;<span class="xml__attr_name">customUserNamePasswordValidatorType</span>=<span class="xml__attr_value">&quot;CSWCFServiceDualAuthentication.MyUserNamePasswordValidator,&nbsp;CSWCFServiceDualAuthentication&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--For&nbsp;client&nbsp;certificate&nbsp;Authentication&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;clientCertificate</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;authentication</span>&nbsp;<span class="xml__attr_name">certificateValidationMode</span>=<span class="xml__attr_value">&quot;Custom&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">customCertificateValidatorType</span>=<span class="xml__attr_value">&quot;CSWCFServiceDualAuthentication.CertificateValidate,&nbsp;CSWCFServiceDualAuthentication&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/clientCertificate&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/serviceCredentials&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/behavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/serviceBehaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/behaviors&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><strong><span><span>8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong>Build the project. The WCF Service is now ready.</p>
<p class="MsoListParagraphCxSpMiddle">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><strong><span><span>C.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>Hosting the WCF Service in IIS : </strong></p>
<p class="MsoListParagraphCxSpMiddle"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Launch IIS. Start &rarr; Run &rarr; inetmgr</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Create a new Site &rarr; Right Click on Default Website &rarr;Select New Application &rarr; Give it a name like CSWCFDualAuth &rarr; specify the path to the project and click on OK.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Now the service is hosted.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>For the site CSWCFDualAuth &rarr; Go to Features view &rarr;Double click on Authentication and make sure that Anonymous Authentication is enabled</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>For the site CSWCFDualAuth &rarr;Go to Features view &rarr;Double click on SSL Setting and select the option 揜equire SSL ? and client certificate 揜equire?and click on apply as shown below:</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in"><span><img height="218" alt="" src="/site/view/file/108939/1/image.png" width="576" align="middle">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>6.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Next, we need to create mapping for this certificate</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>7.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Since I just want to use only one client certificate and authenticate it just for that one certificate I will use just onetoone mapping</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>8.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Go to Default Site and double click on Configuration Editor</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>9.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Under Section : set it to &quot;system.webServer/security/authentication/iisClientCertificateMappingAuthentication&quot;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>10.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>Enable OnetoOneCertificateMappingsEnabled mapping to true</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>11.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>Next on onetooneMappings click on the browse box and click on Add</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>12.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>We get a Properties page. Under Certificate we need to specify the certificate hash. To do so, export the client certificate and save as .cer. Edit it with notepad and
 make sure that everything is in just one line. Copy this and paste it in Certificate</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>13.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>Next, specify the username and password. Hit Enter and this should save it</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>14.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>In case you want to use Many to One Mapping follow the steps mentioned in the link :<span>?
</span><a href="http://blogs.iis.net/webtopics/archive/2010/04/27/configuring-many-to-one-client-certificate-mappings-for-iis-7-7-5.aspx">http://blogs.iis.net/webtopics/archive/2010/04/27/configuring-many-to-one-client-certificate-mappings-for-iis-7-7-5.aspx</a></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>15.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span></span></span>Now go to the site CSWCFDualAuth &rarr; Double click on Configuration Editor and set the enabled option to true as shown below :</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in">&nbsp;</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in"><span><img height="189" alt="" src="/site/view/file/108940/1/image.png" width="576" align="middle">
</span><span>?/span&gt;</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<strong><span><span>16.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp; </span>
</span></span></strong>Now try to browse the service. It will ask for the client certificate and select the concerned one.
<strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><strong><span><span>D.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></strong><strong>Build Client console application (CSWCFClientTest)
</strong></p>
<p class="MsoListParagraphCxSpMiddle"><strong>&nbsp;</strong></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>To the same solution, add a new windows Console Application</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:.75in; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Add the Service Reference to this client project</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the Program.cs define the proxy as below :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace CSWCFClientTest
{
    class Program
    {
        static void Main(string[] args)
        {      
            string output = &quot;&quot;;

            //Define the proxy 
            ServiceReference1.Service1Client c = new ServiceReference1.Service1Client();

            c.ClientCredentials.UserName.UserName = &quot;Melissa&quot;;
            c.ClientCredentials.UserName.Password = &quot;123@abc&quot;;
            output = c.GetData(&quot;123&quot;);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;CSWCFClientTest&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;output&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Define&nbsp;the&nbsp;proxy&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceReference1.Service1Client&nbsp;c&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceReference1.Service1Client();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.ClientCredentials.UserName.UserName&nbsp;=&nbsp;<span class="cs__string">&quot;Melissa&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.ClientCredentials.UserName.Password&nbsp;=&nbsp;<span class="cs__string">&quot;123@abc&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;output&nbsp;=&nbsp;c.GetData(<span class="cs__string">&quot;123&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(output);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst">&nbsp;</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in; text-indent:-.25in">
<span><span>4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>In the config file, we need to define the endpoint and the behavior as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;bindings&gt;
          &lt;customBinding&gt;
              &lt;binding name=&quot;custom&quot;&gt;
                  &lt;security defaultAlgorithmSuite=&quot;Default&quot; authenticationMode=&quot;UserNameOverTransport&quot;
                      requireDerivedKeys=&quot;true&quot; includeTimestamp=&quot;true&quot; messageSecurityVersion=&quot;WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10&quot;&gt;
                      &lt;localClientSettings detectReplays=&quot;false&quot; /&gt;
                      &lt;localServiceSettings detectReplays=&quot;false&quot; /&gt;
                  &lt;/security&gt;
                  &lt;textMessageEncoding messageVersion=&quot;Soap11WSAddressing10&quot; /&gt;
                  &lt;httpsTransport requireClientCertificate=&quot;true&quot; /&gt;
              &lt;/binding&gt;
          &lt;/customBinding&gt;
      &lt;/bindings&gt;

    &lt;!--Define the client endpoint and behavior--&gt;
    
      &lt;client&gt;
          &lt;endpoint address=&quot;https://mesa.fareast.corp.microsoft.com/CSWCFDualAuth/Service1.svc&quot; behaviorConfiguration=&quot;clientbeh&quot;
              binding=&quot;customBinding&quot; bindingConfiguration=&quot;custom&quot; contract=&quot;ServiceReference1.IService1&quot;
              name=&quot;custom&quot; /&gt;
      &lt;/client&gt;
    
    &lt;behaviors&gt;
      &lt;endpointBehaviors&gt;
        &lt;behavior name=&quot;clientbeh&quot;&gt;
          &lt;clientCredentials &gt;              
            &lt;clientCertificate findValue=&quot;MSIT Enterprise CA 2&quot;
                               storeLocation=&quot;CurrentUser&quot;
                               storeName=&quot;My&quot;
                               x509FindType=&quot;FindByIssuerName&quot; /&gt;
            &lt;/clientCredentials&gt;
          &lt;/behavior&gt;
      &lt;/endpointBehaviors&gt;      
    &lt;/behaviors&gt;

</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;bindings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;customBinding</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;binding</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;custom&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;security</span>&nbsp;<span class="xml__attr_name">defaultAlgorithmSuite</span>=<span class="xml__attr_value">&quot;Default&quot;</span>&nbsp;<span class="xml__attr_name">authenticationMode</span>=<span class="xml__attr_value">&quot;UserNameOverTransport&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">requireDerivedKeys</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">includeTimestamp</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__attr_name">messageSecurityVersion</span>=<span class="xml__attr_value">&quot;WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;localClientSettings</span>&nbsp;<span class="xml__attr_name">detectReplays</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;localServiceSettings</span>&nbsp;<span class="xml__attr_name">detectReplays</span>=<span class="xml__attr_value">&quot;false&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/security&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;textMessageEncoding</span>&nbsp;<span class="xml__attr_name">messageVersion</span>=<span class="xml__attr_value">&quot;Soap11WSAddressing10&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;httpsTransport</span>&nbsp;<span class="xml__attr_name">requireClientCertificate</span>=<span class="xml__attr_value">&quot;true&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/binding&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/customBinding&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/bindings&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__comment">&lt;!--Define&nbsp;the&nbsp;client&nbsp;endpoint&nbsp;and&nbsp;behavior--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;client</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;endpoint</span>&nbsp;<span class="xml__attr_name">address</span>=<span class="xml__attr_value">&quot;https://mesa.fareast.corp.microsoft.com/CSWCFDualAuth/Service1.svc&quot;</span>&nbsp;<span class="xml__attr_name">behaviorConfiguration</span>=<span class="xml__attr_value">&quot;clientbeh&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">binding</span>=<span class="xml__attr_value">&quot;customBinding&quot;</span>&nbsp;<span class="xml__attr_name">bindingConfiguration</span>=<span class="xml__attr_value">&quot;custom&quot;</span>&nbsp;<span class="xml__attr_name">contract</span>=<span class="xml__attr_value">&quot;ServiceReference1.IService1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;custom&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/client&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;behaviors</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;endpointBehaviors</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;behavior</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;clientbeh&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;clientCredentials</span>&nbsp;<span class="xml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;clientCertificate</span>&nbsp;<span class="xml__attr_name">findValue</span>=<span class="xml__attr_value">&quot;MSIT&nbsp;Enterprise&nbsp;CA&nbsp;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">storeLocation</span>=<span class="xml__attr_value">&quot;CurrentUser&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">storeName</span>=<span class="xml__attr_value">&quot;My&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">x509FindType</span>=<span class="xml__attr_value">&quot;FindByIssuerName&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/clientCredentials&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/behavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/endpointBehaviors&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/behaviors&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:.75in; text-indent:-.25in">
<span><span>5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Build the project.</p>
<p class="MsoListParagraphCxSpLast" style="margin-left:.75in">&nbsp;</p>
<h2>Running the Sample:</h2>
<p class="MsoNormal" style="margin-bottom:.0001pt">&nbsp;</p>
<p class="MsoListParagraphCxSpFirst" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.75in; text-indent:-.25in">
<span><span>1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Make sure that the service can be browsed over https.</p>
<p class="MsoListParagraphCxSpMiddle" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.75in; text-indent:-.25in">
<span><span>2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Open a command prompt and browse to the location of the client project</p>
<p class="MsoListParagraphCxSpLast" style="margin-top:0in; margin-right:0in; margin-bottom:.0001pt; margin-left:.75in; text-indent:-.25in">
<span><span>3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>Launch the client application and you should get the output as &quot;123&quot;</p>
<p class="MsoNormal">&nbsp;</p>
<h2>More Information</h2>
<p class="MsoNormal">Creating WCF Services:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/bb386386.aspx">http://msdn.microsoft.com/en-us/library/bb386386.aspx</a><strong>
</strong></p>
<p class="MsoNormal">UserName Password Validator Class:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa354513.aspx">http://msdn.microsoft.com/en-us/library/aa354513.aspx</a></p>
<p class="MsoNormal">Certificate Validator Class:</p>
<p class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/aa354512.aspx">http://msdn.microsoft.com/en-us/library/aa354512.aspx</a></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
