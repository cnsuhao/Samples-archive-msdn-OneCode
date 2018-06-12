# Search and Highlight in TextBlock (VBWPFSearchAndHighlightTextBlockControl)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* WPF
## Topics
* Controls
* TextBlock
## IsPublished
* True
## ModifiedDate
* 2011-12-28 09:16:29
## Description

<h1>Search and Highlight Keywords in TextBlock</h1>
<h2>Summary</h2>
<p>The WPF code sample demonstrates how to search and highlight keywords in a TextBlock control.</p>
<p><img src="/site/view/file/48102/1/VBWPFSearchAndHighlightTextBlockControl.png" alt="" width="522" height="348"></p>
<p>The sample includes a custom user control &quot;SearchableTextControl&quot; and its search method is used to demonstrate how to highlight keywords using System.Windows.Documents.Run and System.Windows.Documents.Incline.</p>
<h2><span>Demo</span></h2>
<p>Step1. Build this project in VS2010.</p>
<p>Step2. Run VBWPFSearchAndHighlightTextBlockControl.exe.</p>
<p>Step3. Input the source string after the &quot;Source Text&quot; TextBlock.</p>
<p>Step4. Type the keyword string which you want to search in the source string after the &quot;Search&quot; TextBlock.</p>
<p>Step5. You can change the Background/Foreground colors by selecting the specific color in drop-list of combobox.</p>
<p><span style="font-size:medium; font-weight:bold">Code Logic</span></p>
<p>Step 1. Create a Visual Basic WPF Application in Visual Studio 2010 and name it&nbsp;&quot;VBWPFSearchAndHighlightTextBlockControl&quot;.</p>
<p>Step 2. Create a class &quot;SearchableTextControl&quot;. Make sure it inherits from the &quot;Control&quot; class.</p>
<p>Step 3. The &quot;SearchableTextControl&quot; class uses DependencyProperty.Register to implement&nbsp;a render bound to custom user control such as:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">		''' &lt;summary&gt;
		''' SearchText sandbox which is used to get or set the value from  a dependency property,
		''' if it gets a value,it should be forced to bind to a string type.
		''' &lt;/summary&gt;
		Public Property SearchText() As String
			Get
				Return CStr(GetValue(SearchTextProperty))
			End Get
			Set(ByVal value As String)
				SetValue(SearchTextProperty, value)
			End Set
		End Property

		''' &lt;summary&gt;
		''' Real implementation about SearchTextProperty which registers a dependency property 
		''' with the specified property name, property type, owner type, and property metadata. 
		''' &lt;/summary&gt;
		Public Shared ReadOnly SearchTextProperty As DependencyProperty = 
		DependencyProperty.Register(&quot;SearchText&quot;, GetType(String), GetType(SearchableTextControl), 
		New UIPropertyMetadata(String.Empty, AddressOf UpdateControlCallBack))

		''' &lt;summary&gt;
		''' Create a call back function which is used to invalidate the rendering of the element, and force 
		''' a complete new layout pass. One such advanced scenario is if you are creating a PropertyChangedCallback 
		''' for a dependency property that is not on a Freezable or FrameworkElement derived class that 
		''' still influences the layout when it changes.
		''' &lt;/summary&gt;
		Private Shared Sub UpdateControlCallBack(ByVal d As DependencyObject, ByVal e As 
		DependencyPropertyChangedEventArgs)
			Dim obj As SearchableTextControl = TryCast(d, SearchableTextControl)
			obj.InvalidateVisual()
		End Sub</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;SearchText&nbsp;sandbox&nbsp;which&nbsp;is&nbsp;used&nbsp;to&nbsp;get&nbsp;or&nbsp;set&nbsp;the&nbsp;value&nbsp;from&nbsp;&nbsp;a&nbsp;dependency&nbsp;property,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;<span class="js__statement">if</span>&nbsp;it&nbsp;gets&nbsp;a&nbsp;value,it&nbsp;should&nbsp;be&nbsp;forced&nbsp;to&nbsp;bind&nbsp;to&nbsp;a&nbsp;string&nbsp;type.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Property&nbsp;SearchText()&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;CStr(GetValue(SearchTextProperty))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set(ByVal&nbsp;value&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetValue(SearchTextProperty,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Set&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Real&nbsp;implementation&nbsp;about&nbsp;SearchTextProperty&nbsp;which&nbsp;registers&nbsp;a&nbsp;dependency&nbsp;property&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;<span class="js__statement">with</span>&nbsp;the&nbsp;specified&nbsp;property&nbsp;name,&nbsp;property&nbsp;type,&nbsp;owner&nbsp;type,&nbsp;and&nbsp;property&nbsp;metadata.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Shared&nbsp;ReadOnly&nbsp;SearchTextProperty&nbsp;As&nbsp;DependencyProperty&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="js__string">&quot;SearchText&quot;</span>,&nbsp;GetType(<span class="js__object">String</span>),&nbsp;GetType(SearchableTextControl),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;New&nbsp;UIPropertyMetadata(<span class="js__object">String</span>.Empty,&nbsp;AddressOf&nbsp;UpdateControlCallBack))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;Create&nbsp;a&nbsp;call&nbsp;back&nbsp;<span class="js__operator">function</span>&nbsp;which&nbsp;is&nbsp;used&nbsp;to&nbsp;invalidate&nbsp;the&nbsp;rendering&nbsp;of&nbsp;the&nbsp;element,&nbsp;and&nbsp;force&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;a&nbsp;complete&nbsp;<span class="js__operator">new</span>&nbsp;layout&nbsp;pass.&nbsp;One&nbsp;such&nbsp;advanced&nbsp;scenario&nbsp;is&nbsp;<span class="js__statement">if</span>&nbsp;you&nbsp;are&nbsp;creating&nbsp;a&nbsp;PropertyChangedCallback&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;<span class="js__statement">for</span>&nbsp;a&nbsp;dependency&nbsp;property&nbsp;that&nbsp;is&nbsp;not&nbsp;on&nbsp;a&nbsp;Freezable&nbsp;or&nbsp;FrameworkElement&nbsp;derived&nbsp;class&nbsp;that&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;still&nbsp;influences&nbsp;the&nbsp;layout&nbsp;when&nbsp;it&nbsp;changes.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Shared&nbsp;Sub&nbsp;UpdateControlCallBack(ByVal&nbsp;d&nbsp;As&nbsp;DependencyObject,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyPropertyChangedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;obj&nbsp;As&nbsp;SearchableTextControl&nbsp;=&nbsp;TryCast(d,&nbsp;SearchableTextControl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;obj.InvalidateVisual()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Step 4. In SearchableTextControl class, there is a override method &quot;OnRender&quot;, this method uses String.IndexOf and String.Substring methods to match the target string, and we associate those methods with TextBlock.Inlines.Add
 method in this sample. And in order to implement the behavior which looks like capture of regular expression with several times.</span></div>
<p><span>Step 5. The method &quot;GenerateRun&quot; which in class SearchableTextControl is used to alternate the colors of all matched strings. And it add some features by adding the FontStyle property and the FontWeight property.<br>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">         If Not String.IsNullOrEmpty(searchedString) Then
            Dim run_Renamed As New Run(searchedString) With {.Background =
                If(isHighlight, Me.HighlightBackground, Me.Background), .Foreground =
                If(isHighlight, Me.HighlightForeground, Me.Foreground),
                 .FontStyle = If(isHighlight, FontStyles.Italic, FontStyles.Normal
                                 ),
            .FontWeight = If(isHighlight, FontWeights.Bold, FontWeights.Normal
                                 )
                   }


            Return run_Renamed
        End If
        Return Nothing
    End Function</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;Not&nbsp;<span class="js__object">String</span>.IsNullOrEmpty(searchedString)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;run_Renamed&nbsp;As&nbsp;New&nbsp;Run(searchedString)&nbsp;With&nbsp;<span class="js__brace">{</span>.Background&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If(isHighlight,&nbsp;Me.HighlightBackground,&nbsp;Me.Background),&nbsp;.Foreground&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If(isHighlight,&nbsp;Me.HighlightForeground,&nbsp;Me.Foreground),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FontStyle&nbsp;=&nbsp;If(isHighlight,&nbsp;FontStyles.Italic,&nbsp;FontStyles.Normal&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FontWeight&nbsp;=&nbsp;If(isHighlight,&nbsp;FontWeights.Bold,&nbsp;FontWeights.Normal&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;run_Renamed&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<h2>References</h2>
<p>Run Class <br>
<a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.WINDOWS.DOCUMENTS.RUN);k(RUN);k(DevLang-CSHARP)&rd=true">http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&amp;l=EN-US&amp;k=k(SYSTEM.WINDOWS.DOCUMENTS.RUN);k(RUN);k(DevLang-CSHARP)&amp;rd=true</a></p>
<p>DependencyProperty.OverrideMetadata Method<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.overridemetadata.aspx">http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.overridemetadata.aspx</a></p>
<p>DependencyProperty.Register Method <br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.register.aspx">http://msdn.microsoft.com/en-us/library/system.windows.dependencyproperty.register.aspx</a></p>
<p>FrameworkTemplate.FindName Method <br>
<a href="http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&l=EN-US&k=k(SYSTEM.WINDOWS.FRAMEWORKTEMPLATE.FINDNAME);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&rd=true">http://msdn.microsoft.com/query/dev10.query?appId=Dev10IDEF1&amp;l=EN-US&amp;k=k(SYSTEM.WINDOWS.FRAMEWORKTEMPLATE.FINDNAME);k(TargetFrameworkMoniker-%22.NETFRAMEWORK%2cVERSION%3dV4.0%22);k(DevLang-CSHARP)&amp;rd=true</a></p>
<p>UIElement.InvalidateVisual Method <br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.uielement.invalidatevisual.aspx">http://msdn.microsoft.com/en-us/library/system.windows.uielement.invalidatevisual.aspx</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt=""></a></div>
