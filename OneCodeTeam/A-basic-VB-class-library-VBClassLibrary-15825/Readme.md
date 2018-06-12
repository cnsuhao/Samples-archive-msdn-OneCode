# A basic VB class library (VBClassLibrary)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* .NET Framework
## Topics
* Class Library
## IsPublished
* True
## ModifiedDate
* 2012-08-22 03:46:54
## Description

<h1>LIBRARY APPLICATION <span style="">(</span>VBClassLibrary)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The code sample demonstrates a <span style="">VB.Net</span> class library that we can use in other applications. The class library exposes a simple class named VBSimpleObject.
</p>
<p class="MsoNormal">The class contains:<span style=""> </span></p>
<p class="MsoNormal"><span style="">Constructor: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
 Public Sub New()
 End Sub

</pre>
<pre id="codePreview" class="vb">
 Public Sub New()
 End Sub

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Instance field and property: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
Private fField As Single = 0.0F


       ''' &lt;summary&gt;
       ''' This is a public Property. It allows you to get and set the value 
       ''' of a float field.
       ''' &lt;/summary&gt;
       Public Property FloatProperty() As Single
           Get
               Return fField
           End Get
           Set(ByVal value As Single)
               ' Fire the event FloatPropertyChanging
               Dim cancel As Boolean = False
               RaiseEvent FloatPropertyChanging(value, cancel)


               ' If the change is not canceled, make the change.
               If Not cancel Then
                   fField = value
               End If
           End Set
       End Property

</pre>
<pre id="codePreview" class="vb">
Private fField As Single = 0.0F


       ''' &lt;summary&gt;
       ''' This is a public Property. It allows you to get and set the value 
       ''' of a float field.
       ''' &lt;/summary&gt;
       Public Property FloatProperty() As Single
           Get
               Return fField
           End Get
           Set(ByVal value As Single)
               ' Fire the event FloatPropertyChanging
               Dim cancel As Boolean = False
               RaiseEvent FloatPropertyChanging(value, cancel)


               ' If the change is not canceled, make the change.
               If Not cancel Then
                   fField = value
               End If
           End Set
       End Property

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Instance method: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Returns a String that represents the current Object. Here, we 
''' return the string form of the float field fField.
''' &lt;/summary&gt;
''' &lt;returns&gt;the string form of the float field fField.&lt;/returns&gt;
Public Overrides Function ToString() As String
    Return Me.fField.ToString(&quot;F2&quot;)
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Returns a String that represents the current Object. Here, we 
''' return the string form of the float field fField.
''' &lt;/summary&gt;
''' &lt;returns&gt;the string form of the float field fField.&lt;/returns&gt;
Public Overrides Function ToString() As String
    Return Me.fField.ToString(&quot;F2&quot;)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Shared (static) method: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' This is a public static method. It returns the number of 
''' characters in a string.
''' &lt;/summary&gt;
''' &lt;param name=&quot;str&quot;&gt;a string&lt;/param&gt;
''' &lt;returns&gt;the number of characters in the string&lt;/returns&gt;
Public Shared Function GetStringLength(ByVal str As String) As Integer
      Return str.Length
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' This is a public static method. It returns the number of 
''' characters in a string.
''' &lt;/summary&gt;
''' &lt;param name=&quot;str&quot;&gt;a string&lt;/param&gt;
''' &lt;returns&gt;the number of characters in the string&lt;/returns&gt;
Public Shared Function GetStringLength(ByVal str As String) As Integer
      Return str.Length
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">Instance event: </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' This is an event. The event is fired when the float property is 
''' set.
''' &lt;/summary&gt;
Public Event FloatPropertyChanging As PropertyChangingEventHandler

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' This is an event. The event is fired when the float property is 
''' set.
''' &lt;/summary&gt;
Public Event FloatPropertyChanging As PropertyChangingEventHandler

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><span style="">The process of creating the class library is very straight-forward.
</span></p>
<h2>Implementation:</h2>
<h3>A. Creating the project</h3>
<p class="MsoNormal">Step1. Create a Visual <span style="">VB.Net</span> / Class Library project named VBClassLibrary in Visual Studio 2010.</p>
<h3>B. Adding a class <span class="SpellE"><span style="">VB</span>impleObject</span> to the project and define its fields, properties, methods, and events.</h3>
<p class="MsoNormal">Step1. In Solution Explorer, add a new Class item to the project and name it<span style="">
</span>as VBSimpleObject.</p>
<p class="MsoNormal">Step2. Edit the file VBSimpleObject.vb to add the fields, properties, methods,<span style="">
</span>and events.</p>
<h3>C. Signing the assembly with a strong name (Optional)</h3>
<p class="MsoNormal">Strong names are required to store shared assemblies in Global Assembly Cache(GAC). This helps avoid DLL Hell. Strong names also protects the assembly from being hacked (replaced or injected). A strong name consists of the assembly's
 identity—its simple text name, version number, and culture info<span style=""> </span>
(if provided)—plus a public key and a digital signature. It is generated from an assembly file using the corresponding private key.
</p>
<p class="MsoNormal">Step1. Right-click the project and open its Properties page.</p>
<p class="MsoNormal">Step2. Turn to the Signing tab, and check the Sign the assembly checkbox.
</p>
<p class="MsoNormal">Step3. In the Choose a strong name key file drop-down, select New. The &quot;Create Strong Name Key&quot; dialog appears. In the Key file name text box, type<span style="">
</span>the desired key name. If necessary, we can protect the strong name key file with a password. Click the OK button.<span style="">
</span></p>
<h2>More Information</h2>
<p class="MsoListParagraphCxSpFirst" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/b0b8dk77.aspx">MSDN: Creating Assemblies</a>
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/xc31ft41.aspx">How to: Sign an Assembly with a Strong Name</a>
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-bottom:0cm; margin-bottom:.0001pt; text-indent:5.0pt; line-height:normal; text-autospace:none">
<span style="font-family:Symbol"><span style="">&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="font-family:新宋体"><a href="http://msdn.microsoft.com/en-us/library/3707x96z.aspx">How to: Create and Use C# DLLs (C# Programming Guide)</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
