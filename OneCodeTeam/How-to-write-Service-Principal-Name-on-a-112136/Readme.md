# How to write Service Principal Name on a Computer/User (VS2010, VB)
## Requires
* Visual Studio 2010
## License
* Apache License, Version 2.0
## Technologies
* Active Directory
* Computer Accounts
* User Accounts
## Topics
* Directory Services
## IsPublished
* True
## ModifiedDate
* 2015-02-02 06:34:41
## Description

<h1>The project illustrates how to write Service Principal Name on a Computer/User object (VBDsWriteAccountSPN2010)</h1>
<h2>Introduction</h2>
<p>This sample application demonstrates how to write/add Service Principal Name (SPN) to any user or computer account object in Active Directory. This sample must be run on domain environment and under the Domain Admin privileges.</p>
<p>Lots of developers ask about this in the MSDN forums, so we created the code sample to address the frequently asked programming scenario.</p>
<p><strong>Reference</strong></p>
<p>DsWriteAccountSpn</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms676056%28v=vs.85%29.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms676056(v=vs.85).aspx</a>&nbsp;</p>
<p>&nbsp;</p>
<p>DsGetSpn</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675993%28v=vs.85%29.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675993(v=vs.85).aspx</a>&nbsp;</p>
<p>&nbsp;</p>
<p>DsCrackSpn</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675971%28v=vs.85%29.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675971(v=vs.85).aspx</a></p>
<p>&nbsp;</p>
<p>DsBind</p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms675931%28v=vs.85%29.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/ms675931(v=vs.85).aspx</a></p>
<p>&nbsp;</p>
<h2>Building the Project</h2>
<p>&nbsp;</p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating a VB console application (VBDsWriteAccountSPN2010)</strong></p>
<ol>
<li>In the Visual Studio 2010, create a console application </li><li>Using the System.Runtime.InteropServices encapsulated classes for interop calls
</li><li>We are using first DsCrackSpn to parse its SPN into its component strings. </li><li>Then we need to bind to the Domain Controller using DsBind. </li><li>Now we would require constructing the SPN using DsGetSpn by specifying its type.
</li><li>Once we get the pointer to the SPN, we can write it to the object by calling DsWriteAccountSpn.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">' Initial call to DsCrackSpn should result in BUFFER_OVERFLOW...

        Dim crackSpnResult As UInteger = DsCrackSpn(spn, serviceClassSize, sTemp, serviceNameSize, sTemp, instanceNameSize, _

         sTemp, port)

 

        ' Check for buffer overflow

        If crackSpnResult = ERROR_BUFFER_OVERFLOW Then

            ' Resize our SB's

            Dim serviceClass As New StringBuilder(serviceClassSize)

            Dim serviceName As New StringBuilder(serviceNameSize)

            Dim instanceName As New StringBuilder(instanceNameSize)

 

            ' Crack this spn using DsCrackSpn

            crackSpnResult = DsCrackSpn(spn, serviceClassSize, serviceClass, serviceNameSize, serviceName, instanceNameSize, _

             instanceName, port)

 

            ' If Success

            If crackSpnResult = NO_ERROR Then

                Dim hostArray As String() = {serviceName.ToString()}

                Dim portArray As UShort() = {port}

                Dim spnCount As UShort = 1

                Dim spnArrayPointer As New IntPtr()

                Dim spnArrayCount As Int32 = 0

 

                ' Call to DsBind to get handle for Directory

                Dim hDS As System.IntPtr

                Dim result As UInteger = DsBind(domainControllerName, dnsDomainName, hDS)

 

                If result &lt;&gt; NO_ERROR Then

                    Console.WriteLine(&quot;DSBind Failed.&quot;)

                    Return

                End If

 

                ' Call to DsgetSpn to construct an spn

                Dim getSPNResult As UInteger = DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST, serviceClass.ToString(), Nothing, port, spnCount, hostArray, _

                 portArray, spnArrayCount, spnArrayPointer)

 

                If getSPNResult = NO_ERROR Then

                    ' Call the CSDsWriteAccountSPN for writing this spn to the object

                    Dim dsWriteSpnResult As UInteger = DsWriteAccountSpn(hDS, DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP, servicePrincipalName, spnArrayCount, spnArrayPointer)

 

                    If dsWriteSpnResult = NO_ERROR Then

                        Console.WriteLine(&quot;DsWriteAccountSpn Succeed. Please check the user/Computer object for ServicePrincipalName.&quot;)

                        Console.ReadKey()

                    Else

                        Console.WriteLine(&quot;DsWriteAccountSpn Failed.&quot;)

                        Return

                    End If

                Else

                    Console.WriteLine(&quot;DsGetSPN Failed.&quot;)

                    Return

                End If

            Else

                Console.WriteLine(&quot;DsCrackSpn Failed.&quot;)

                Return

            End If

        End If

 </pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;Initial&nbsp;call&nbsp;to&nbsp;DsCrackSpn&nbsp;should&nbsp;result&nbsp;in&nbsp;BUFFER_OVERFLOW...</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;crackSpnResult&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UInteger</span>&nbsp;=&nbsp;DsCrackSpn(spn,&nbsp;serviceClassSize,&nbsp;sTemp,&nbsp;serviceNameSize,&nbsp;sTemp,&nbsp;instanceNameSize,&nbsp;_&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sTemp,&nbsp;port)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Check&nbsp;for&nbsp;buffer&nbsp;overflow</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;crackSpnResult&nbsp;=&nbsp;ERROR_BUFFER_OVERFLOW&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Resize&nbsp;our&nbsp;SB's</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;serviceClass&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder(serviceClassSize)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;serviceName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder(serviceNameSize)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;instanceName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder(instanceNameSize)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Crack&nbsp;this&nbsp;spn&nbsp;using&nbsp;DsCrackSpn</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;crackSpnResult&nbsp;=&nbsp;DsCrackSpn(spn,&nbsp;serviceClassSize,&nbsp;serviceClass,&nbsp;serviceNameSize,&nbsp;serviceName,&nbsp;instanceNameSize,&nbsp;_&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;instanceName,&nbsp;port)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;If&nbsp;Success</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;crackSpnResult&nbsp;=&nbsp;NO_ERROR&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hostArray&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>()&nbsp;=&nbsp;{serviceName.ToString()}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;portArray&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UShort</span>()&nbsp;=&nbsp;{port}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;spnCount&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UShort</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;spnArrayPointer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;IntPtr()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;spnArrayCount&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Call&nbsp;to&nbsp;DsBind&nbsp;to&nbsp;get&nbsp;handle&nbsp;for&nbsp;Directory</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;hDS&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.IntPtr&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UInteger</span>&nbsp;=&nbsp;DsBind(domainControllerName,&nbsp;dnsDomainName,&nbsp;hDS)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;result&nbsp;&lt;&gt;&nbsp;NO_ERROR&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;DSBind&nbsp;Failed.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Call&nbsp;to&nbsp;DsgetSpn&nbsp;to&nbsp;construct&nbsp;an&nbsp;spn</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;getSPNResult&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UInteger</span>&nbsp;=&nbsp;DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_DNS_HOST,&nbsp;serviceClass.ToString(),&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;port,&nbsp;spnCount,&nbsp;hostArray,&nbsp;_&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;portArray,&nbsp;spnArrayCount,&nbsp;spnArrayPointer)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;getSPNResult&nbsp;=&nbsp;NO_ERROR&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Call&nbsp;the&nbsp;CSDsWriteAccountSPN&nbsp;for&nbsp;writing&nbsp;this&nbsp;spn&nbsp;to&nbsp;the&nbsp;object</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dsWriteSpnResult&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">UInteger</span>&nbsp;=&nbsp;DsWriteAccountSpn(hDS,&nbsp;DS_SPN_WRITE_OP.DS_SPN_ADD_SPN_OP,&nbsp;servicePrincipalName,&nbsp;spnArrayCount,&nbsp;spnArrayPointer)&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;dsWriteSpnResult&nbsp;=&nbsp;NO_ERROR&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;DsWriteAccountSpn&nbsp;Succeed.&nbsp;Please&nbsp;check&nbsp;the&nbsp;user/Computer&nbsp;object&nbsp;for&nbsp;ServicePrincipalName.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;DsWriteAccountSpn&nbsp;Failed.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;DsGetSPN&nbsp;Failed.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;DsCrackSpn&nbsp;Failed.&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h2>Running the Sample</h2>
<p>You can execute this sample by creating the exe via Visual Studio but it must be running under the domain admin credentials. Also this code must be running either on Domain controller or any one of the member servers.</p>
