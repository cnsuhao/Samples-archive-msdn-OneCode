# Write / add SPN to user or computer account in AD (CSDsWriteAccountSPN)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* ADSI
* Active Directory
* Directory Services
## Topics
* Active Directory
* spn
* Service Principal Name
## IsPublished
* True
## ModifiedDate
* 2012-02-05 07:02:39
## Description

<div class="WordSection1">
<h1>This sample demonstrates how to write/add Service Principal Name (SPN) to any user or computer account object in Active Directory. (<span class="SpellE">CSDsWriteAccountSPN</span>)</h1>
<h2>Introduction</h2>
<div class="MsoNormal">This sample application demonstrates how to write/add Service Principal Name (SPN) to any user or computer account object in Active Directory. This sample must be run on domain environment and under the Domain Admin privileges.</div>
<h2>Running the Sample</h2>
<div class="MsoNormal">You can execute this sample by creating the exe via Visual Studio but it must be running under the domain admin credentials. Also this code must be running either on Domain controller or any one of the member servers.</div>
<h2>Using the Code</h2>
<div class="MsoNormal">We are using first <span class="SpellE">DsCrackSpn</span> to parse its SPN into its component strings. Then we need to bind to the Domain Controller using
<span class="SpellE">DsBind</span>. Now we would require constructing the SPN using
<span class="SpellE">DsGetSpn</span> by specifying its type. Once we get the pointer to the SPN, we can write it to the object by calling
<span class="SpellE">DsWriteAccountSpn</span>.</div>
<div class="MsoNormal"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Initial call to DsCrackSpn should result in BUFFER_OVERFLOW...
uint crackSpnResult = DsCrackSpn(spn, ref serviceClassSize, sTemp, ref serviceNameSize, 
    sTemp, ref instanceNameSize, sTemp, out port);
 
// Check for buffer overflow
if (crackSpnResult == ERROR_BUFFER_OVERFLOW)
{
    // Resize our SB's
    StringBuilder serviceClass  = new StringBuilder(serviceClassSize);
    StringBuilder serviceName   = new StringBuilder(serviceNameSize);
    StringBuilder instanceName  = new StringBuilder(instanceNameSize);
 
    // Crack this spn using DsCrackSpn
    crackSpnResult = DsCrackSpn(spn, ref serviceClassSize, serviceClass, ref serviceNameSize, 
        serviceName, ref instanceNameSize, instanceName, out port);
    
    // If Success
    if (crackSpnResult == NO_ERROR)
    {
        string[] hostArray = { serviceName.ToString() };
        ushort[] portArray = { port };
        ushort spnCount = 1;
        IntPtr spnArrayPointer = new IntPtr();
        Int32 spnArrayCount = 0;
 
        // Call to DsBind to get handle for Directory
        System.IntPtr hDS;
        uint result = DsBind(domainControllerName, dnsDomainName, out hDS);
 
        if (result != NO_ERROR)
        {
            Console.WriteLine(&quot;DSBind Failed.&quot;);
            return;
        }
 
        // Call to DsgetSpn to construct an spn
        uint getSPNResult = DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST, serviceClass.ToString(), 
            null, port, spnCount, hostArray, portArray, ref spnArrayCount, ref spnArrayPointer);
 
        if (getSPNResult == NO_ERROR)
        {
            // Call the CSDsWriteAccountSPN for writing this spn to the object
            uint dsWriteSpnResult = DsWriteAccountSpn(hDS, DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP, 
                servicePrincipalName, spnArrayCount, spnArrayPointer);
 
            if (dsWriteSpnResult == NO_ERROR)
            {
                Console.WriteLine(&quot;DsWriteAccountSpn Succeed. Please check the user/Computer object for ServicePrincipalName.&quot;);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(&quot;DsWriteAccountSpn Failed.&quot;);
                return;
            }
        }
        else
        {
            Console.WriteLine(&quot;DsGetSPN Failed.&quot;);
            return;
        }
    }
    else
    {
        Console.WriteLine(&quot;DsCrackSpn Failed.&quot;);
        return;
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Initial&nbsp;call&nbsp;to&nbsp;DsCrackSpn&nbsp;should&nbsp;result&nbsp;in&nbsp;BUFFER_OVERFLOW...</span>&nbsp;
<span class="cs__keyword">uint</span>&nbsp;crackSpnResult&nbsp;=&nbsp;DsCrackSpn(spn,&nbsp;<span class="cs__keyword">ref</span>&nbsp;serviceClassSize,&nbsp;sTemp,&nbsp;<span class="cs__keyword">ref</span>&nbsp;serviceNameSize,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sTemp,&nbsp;<span class="cs__keyword">ref</span>&nbsp;instanceNameSize,&nbsp;sTemp,&nbsp;<span class="cs__keyword">out</span>&nbsp;port);&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Check&nbsp;for&nbsp;buffer&nbsp;overflow</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(crackSpnResult&nbsp;==&nbsp;ERROR_BUFFER_OVERFLOW)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Resize&nbsp;our&nbsp;SB's</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;serviceClass&nbsp;&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(serviceClassSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;serviceName&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(serviceNameSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;instanceName&nbsp;&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(instanceNameSize);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Crack&nbsp;this&nbsp;spn&nbsp;using&nbsp;DsCrackSpn</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;crackSpnResult&nbsp;=&nbsp;DsCrackSpn(spn,&nbsp;<span class="cs__keyword">ref</span>&nbsp;serviceClassSize,&nbsp;serviceClass,&nbsp;<span class="cs__keyword">ref</span>&nbsp;serviceNameSize,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serviceName,&nbsp;<span class="cs__keyword">ref</span>&nbsp;instanceNameSize,&nbsp;instanceName,&nbsp;<span class="cs__keyword">out</span>&nbsp;port);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;Success</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(crackSpnResult&nbsp;==&nbsp;NO_ERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;hostArray&nbsp;=&nbsp;{&nbsp;serviceName.ToString()&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">ushort</span>[]&nbsp;portArray&nbsp;=&nbsp;{&nbsp;port&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">ushort</span>&nbsp;spnCount&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntPtr&nbsp;spnArrayPointer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IntPtr();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Int32&nbsp;spnArrayCount&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;to&nbsp;DsBind&nbsp;to&nbsp;get&nbsp;handle&nbsp;for&nbsp;Directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IntPtr&nbsp;hDS;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;result&nbsp;=&nbsp;DsBind(domainControllerName,&nbsp;dnsDomainName,&nbsp;<span class="cs__keyword">out</span>&nbsp;hDS);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;!=&nbsp;NO_ERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DSBind&nbsp;Failed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;to&nbsp;DsgetSpn&nbsp;to&nbsp;construct&nbsp;an&nbsp;spn</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;getSPNResult&nbsp;=&nbsp;DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST,&nbsp;serviceClass.ToString(),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">null</span>,&nbsp;port,&nbsp;spnCount,&nbsp;hostArray,&nbsp;portArray,&nbsp;<span class="cs__keyword">ref</span>&nbsp;spnArrayCount,&nbsp;<span class="cs__keyword">ref</span>&nbsp;spnArrayPointer);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(getSPNResult&nbsp;==&nbsp;NO_ERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;the&nbsp;CSDsWriteAccountSPN&nbsp;for&nbsp;writing&nbsp;this&nbsp;spn&nbsp;to&nbsp;the&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">uint</span>&nbsp;dsWriteSpnResult&nbsp;=&nbsp;DsWriteAccountSpn(hDS,&nbsp;DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;servicePrincipalName,&nbsp;spnArrayCount,&nbsp;spnArrayPointer);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dsWriteSpnResult&nbsp;==&nbsp;NO_ERROR)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DsWriteAccountSpn&nbsp;Succeed.&nbsp;Please&nbsp;check&nbsp;the&nbsp;user/Computer&nbsp;object&nbsp;for&nbsp;ServicePrincipalName.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DsWriteAccountSpn&nbsp;Failed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DsGetSPN&nbsp;Failed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;DsCrackSpn&nbsp;Failed.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<h2>More Information&nbsp;</h2>
<div class="MsoNormal">DsWriteAccountSpn</div>
<div class="MsoNormal"><span><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms676056(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms676056(v=vs.85).aspx</a></span></div>
<div class="MsoNormal"><span>&nbsp;</span></div>
<div class="MsoNormal"><span>DsGetSpn</span></div>
<div class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675993(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675993(v=vs.85).aspx</a></div>
<div class="MsoNormal">&nbsp;</div>
<div class="MsoNormal">DsCrackSpn</div>
<div class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675971(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675971(v=vs.85).aspx</a></div>
<div class="MsoNormal">&nbsp;</div>
<div class="MsoNormal">DsBind</div>
<div class="MsoNormal"><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675931(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675931(v=vs.85).aspx</a></div>
<div class="MsoNormal"></div>
<div class="MsoNormal"><br>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
</div>
</div>
