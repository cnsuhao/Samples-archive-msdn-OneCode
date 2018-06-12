# How to use DropDownList with ASP.NET MVC
## Requires
* Visual Studio 2013
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
* ASP.NET MVC 4
## Topics
* DropDownList
## IsPublished
* True
## ModifiedDate
* 2014-02-25 03:16:35
## Description

<hr>
<div><a href="http://blogs.msdn.com/b/onecode" style="margin-top:3px"><img src="http://bit.ly/onecodesampletopbanner" alt="">
</a></div>
<h1>Cascading <span class="SpellE">DropDown</span> List with ASP.NET MVC 4</h1>
<h2>Introduction</h2>
<p class="MsoNormal"><a href="http://www.asp.net/mvc/mvc4">ASP.NET MVC 4</a> is a framework for building scalable, standards-based web applications using well-established design patterns and the power of ASP.NET and the .NET Framework. This article and the
 attached code samples demonstrate demonstrates how to use cascading dropdown list with ASP.NET MVC 4.<span>&nbsp;
</span>You can find the answers for all the following questions in the code sample:</p>
<p class="MsoListParagraphCxSpFirst" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to create a simple dropdown list</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to post data to server when dropdown list selected item changed</p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to implement cascaded <span class="SpellE">DropDownList</span></p>
<p class="MsoListParagraphCxSpMiddle" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to update the local section <span class="SpellE">accroding</span> to the item selected</p>
<p class="MsoListParagraphCxSpLast" style="text-indent:-.25in"><span style="font-family:Symbol"><span>&bull;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>How to dynamically generate options for dropdown list</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">You must run this code sample on Visual Studio 2012 or newer versions.</p>
<p class="MsoNormal">After you successfully build the sample project in Visual Studio 2012, you will get the &quot;<span class="SpellE">CascadingDropDown</span> Demonstration in ASP.NET MVC 4&quot; web-page.</p>
<p class="MsoNormal"><span><img src="/site/view/file/109384/1/image.png" alt="" width="559" height="268" align="middle">
</span></p>
<p class="MsoNormal">Select any <span class="GramE"><strong>Make</strong></span> from the available options. This will make a server call to get the models</p>
<p class="MsoNormal"><span><img src="/site/view/file/109385/1/image.png" alt="" width="557" height="308" align="middle">
</span></p>
<p class="MsoNormal">Select <strong>Model </strong>from the available options. This will make a server call to get the colors</p>
<p class="MsoNormal"><span><img src="/site/view/file/109386/1/image.png" alt="" width="549" height="271" align="middle">
</span></p>
<h2>Using the Code</h2>
<h3>How to use controller?</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Namespace VBDropdownListMVC4.Controllers
    ''' &lt;summary&gt;
    ''' Controller class for sample
    ''' &lt;/summary&gt;
    Public Class CascadingDropDownSampleController
        Inherits Controller
#Region &quot;Public Actions&quot;

        ''' &lt;summary&gt;
        ''' Default Action for the web-page handling HTTP GET requests
        ''' &lt;/summary&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        &lt;HttpGet&gt; _
        Public Function Index() As ActionResult
           Dim viewModel As New CascadingDropDownSampleModel()

            viewModel.Makes = GetSampleMakes()

            Return View(viewModel)
        End Function

        ''' &lt;summary&gt;
        ''' AJAX Action to send sample Models in JSON format based on the selected make
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;selectedMake&quot;&gt;&lt;/param&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Public Function GetSampleModels(selectedMake As String) As ActionResult
            Dim models As IDictionary(Of String, String) = GetSampleModelsFromSelectedMake(selectedMake)
            Return Json(models)
        End Function

        ''' &lt;summary&gt;
        ''' AJAX Action to send sample colors in JSON format based on the selected model
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;selectedModel&quot;&gt;&lt;/param&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Public Function GetSampleColors(selectedModel As String) As ActionResult
            Dim colors As IDictionary(Of String, String) = GetSampleColorsFromSelectedModel(selectedModel)
            Return Json(colors)
        End Function

#End Region

#Region &quot;Private Methods&quot;

        ''' &lt;summary&gt;
        ''' Method to generate sample makes
        ''' &lt;/summary&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Private Function GetSampleMakes() As IDictionary(Of String, String)
            Dim makes As IDictionary(Of String, String) = New Dictionary(Of String, String)()

            makes.Add(&quot;1&quot;, &quot;Acura&quot;)
            makes.Add(&quot;2&quot;, &quot;Audi&quot;)
            makes.Add(&quot;3&quot;, &quot;BMW&quot;)

            Return makes
        End Function

        ''' &lt;summary&gt;
        ''' Method to generate sample models based on selected make
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;selectedMake&quot;&gt;&lt;/param&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Private Function GetSampleModelsFromSelectedMake(selectedMake As String) As IDictionary(Of String, String)
            Dim models As IDictionary(Of String, String) = New Dictionary(Of String, String)()

            Select Case selectedMake
                Case &quot;1&quot;
                    models.Add(&quot;1&quot;, &quot;Integra&quot;)
                    models.Add(&quot;2&quot;, &quot;RL&quot;)
                    models.Add(&quot;3&quot;, &quot;TL&quot;)
                    Exit Select
                Case &quot;2&quot;
                    models.Add(&quot;4&quot;, &quot;A4&quot;)
                    models.Add(&quot;5&quot;, &quot;S4&quot;)
                    models.Add(&quot;6&quot;, &quot;A6&quot;)
                    Exit Select
                Case &quot;3&quot;
                    models.Add(&quot;7&quot;, &quot;3 series&quot;)
                    models.Add(&quot;8&quot;, &quot;5 series&quot;)
                    models.Add(&quot;9&quot;, &quot;7 series&quot;)
                    Exit Select
                Case Else
                    Throw New NotImplementedException()

            End Select

            Return models
        End Function

        ''' &lt;summary&gt;
        ''' Method to generate sample colors based on selected model
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;selectedModel&quot;&gt;&lt;/param&gt;
        ''' &lt;returns&gt;&lt;/returns&gt;
        Private Function GetSampleColorsFromSelectedModel(selectedModel As String) As IDictionary(Of String, String)
            Dim colors As IDictionary(Of String, String) = New Dictionary(Of String, String)()

            Select Case selectedModel
                Case &quot;1&quot;
                    colors.Add(&quot;1&quot;, &quot;Green&quot;)
                    colors.Add(&quot;2&quot;, &quot;Sea Green&quot;)
                    colors.Add(&quot;3&quot;, &quot;Pale Green&quot;)
                    Exit Select
                Case &quot;2&quot;
                    colors.Add(&quot;4&quot;, &quot;Red&quot;)
                    colors.Add(&quot;5&quot;, &quot;Bright Red&quot;)
                    Exit Select
                Case &quot;3&quot;
                    colors.Add(&quot;6&quot;, &quot;Teal&quot;)
                    colors.Add(&quot;7&quot;, &quot;Dark Teal&quot;)
                    Exit Select
                Case &quot;4&quot;
                    colors.Add(&quot;8&quot;, &quot;Azure&quot;)
                    colors.Add(&quot;9&quot;, &quot;Light Azure&quot;)
                    colors.Add(&quot;10&quot;, &quot;Dark Azure&quot;)
                    Exit Select
                Case &quot;5&quot;
                    colors.Add(&quot;11&quot;, &quot;Silver&quot;)
                    colors.Add(&quot;12&quot;, &quot;Metallic&quot;)
                    Exit Select
                Case &quot;6&quot;
                    colors.Add(&quot;13&quot;, &quot;Cyan&quot;)
                    Exit Select
                Case &quot;7&quot;
                    colors.Add(&quot;14&quot;, &quot;Blue&quot;)
                    colors.Add(&quot;15&quot;, &quot;Sky Blue&quot;)
                    colors.Add(&quot;16&quot;, &quot;Racing Blue&quot;)
                    Exit Select
                Case &quot;8&quot;
                    colors.Add(&quot;17&quot;, &quot;Yellow&quot;)
                    colors.Add(&quot;18&quot;, &quot;Red&quot;)
                    Exit Select
                Case &quot;9&quot;
                    colors.Add(&quot;17&quot;, &quot;Brown&quot;)
                    Exit Select
                Case Else
                    Throw New NotImplementedException()

            End Select

            Return colors
        End Function

#End Region

    End Class
End Namespace
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Namespace</span>&nbsp;VBDropdownListMVC4.Controllers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Controller&nbsp;class&nbsp;for&nbsp;sample</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;CascadingDropDownSampleController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Controller<span class="visualBasic__preproc">&nbsp;
#Region&nbsp;&quot;Public&nbsp;Actions</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Default&nbsp;Action&nbsp;for&nbsp;the&nbsp;web-page&nbsp;handling&nbsp;HTTP&nbsp;GET&nbsp;requests</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;HttpGet&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Index()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;viewModel&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CascadingDropDownSampleModel()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewModel.Makes&nbsp;=&nbsp;GetSampleMakes()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;View(viewModel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;AJAX&nbsp;Action&nbsp;to&nbsp;send&nbsp;sample&nbsp;Models&nbsp;in&nbsp;JSON&nbsp;format&nbsp;based&nbsp;on&nbsp;the&nbsp;selected&nbsp;make</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;selectedMake&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSampleModels(selectedMake&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;models&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;GetSampleModelsFromSelectedMake(selectedMake)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Json(models)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;AJAX&nbsp;Action&nbsp;to&nbsp;send&nbsp;sample&nbsp;colors&nbsp;in&nbsp;JSON&nbsp;format&nbsp;based&nbsp;on&nbsp;the&nbsp;selected&nbsp;model</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;selectedModel&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSampleColors(selectedModel&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ActionResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;colors&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;GetSampleColorsFromSelectedModel(selectedModel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Json(colors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
#End&nbsp;Region</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
#Region&nbsp;&quot;Private&nbsp;Methods</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Method&nbsp;to&nbsp;generate&nbsp;sample&nbsp;makes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSampleMakes()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;makes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;makes.Add(<span class="visualBasic__string">&quot;1&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Acura&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;makes.Add(<span class="visualBasic__string">&quot;2&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Audi&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;makes.Add(<span class="visualBasic__string">&quot;3&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;BMW&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;makes&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Method&nbsp;to&nbsp;generate&nbsp;sample&nbsp;models&nbsp;based&nbsp;on&nbsp;selected&nbsp;make</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;selectedMake&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSampleModelsFromSelectedMake(selectedMake&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;models&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;selectedMake&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;1&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Integra&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;2&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;RL&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;3&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;TL&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;4&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;A4&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;5&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;S4&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;6&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;A6&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;7&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;3&nbsp;series&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;8&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;5&nbsp;series&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;models.Add(<span class="visualBasic__string">&quot;9&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;7&nbsp;series&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;models&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Method&nbsp;to&nbsp;generate&nbsp;sample&nbsp;colors&nbsp;based&nbsp;on&nbsp;selected&nbsp;model</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;selectedModel&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetSampleColorsFromSelectedModel(selectedModel&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;colors&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">String</span>)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;selectedModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;1&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Green&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;2&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Sea&nbsp;Green&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;3&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Pale&nbsp;Green&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;4&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Red&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;5&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Bright&nbsp;Red&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;6&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Teal&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;7&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Dark&nbsp;Teal&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;4&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;8&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Azure&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;9&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Light&nbsp;Azure&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;10&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Dark&nbsp;Azure&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;5&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;11&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Silver&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;12&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Metallic&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;6&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;13&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Cyan&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;7&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;14&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Blue&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;15&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Sky&nbsp;Blue&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;16&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Racing&nbsp;Blue&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;8&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;17&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Yellow&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;18&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Red&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;9&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colors.Add(<span class="visualBasic__string">&quot;17&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Brown&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NotImplementedException()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;colors&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
#End&nbsp;Region</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span>&nbsp;</pre>
</div>
</div>
</div>
<h3>How to use <span class="SpellE">Javascript</span>?</h3>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$(function () {
    var cascadingDropDownSample = new CascadingDropDownSample();

    //binding change event of the &quot;make&quot; select HTML control
    $('#make').on('change', function () {
        var selectedMake = $(this).val();

        //if selected other than default option, make a AJAX call to server
        if (selectedMake !== &quot;-1&quot;) {
            $.post('/CascadingDropDownSample/GetSampleModels',
                { selectedMake: selectedMake },
                function (data) {
                    cascadingDropDownSample.resetCascadingDropDowns();
                    cascadingDropDownSample.getSampleModelsSuccess(data);
                });
        }
        else {
            //reset the cascading dropdown
            cascadingDropDownSample.resetCascadingDropDowns();
        }
    });

    //binding change event of the &quot;model&quot; select HTML control
    $('#model').on('change', function () {
        var selectedModel = $(this).val();

        //if selected other than default option, make a AJAX call to server
        if (selectedModel !== &quot;-1&quot;) {
            $.post('/CascadingDropDownSample/GetSampleColors',
                { selectedModel: selectedModel },
                function (data) {
                    cascadingDropDownSample.resetColors();
                    cascadingDropDownSample.getSampleColorsSuccess(data);
                });
        }
        else {
            //reset the colors dropdown
            cascadingDropDownSample.resetColors();
        }
    });
});

// Module for CascadingDropDownSample containing JS helper functions
function CascadingDropDownSample() {
    this.resetCascadingDropDowns = function () {
        this.resetModels();
        this.resetColors();
    };

    this.getSampleModelsSuccess = function (data) {
        //binding JSON data received to HTML select control
        $.each(data, function (key, textValue) {
            $('#model').append($('&lt;option /&gt;', { value: key, text: textValue }));
        });
        $('#model').attr('disabled', false);
    };

    this.getSampleColorsSuccess = function (data) {
        //binding JSON data received to HTML select control
        $.each(data, function (key, textValue) {
            $('#color').append($('&lt;option /&gt;', { value: key, text: textValue }));
        });
        $('#color').attr('disabled', false);
    };

    this.resetModels = function () {
        $('#model option').remove();
        $('#model').append($('&lt;option /&gt;', { value: '-1', text: 'Please select a model' }));
        $('#model').attr('disabled', 'disabled');
    };

    this.resetColors = function () {
        $('#color option').remove();
        $('#color').append($('&lt;option /&gt;', { value: '-1', text: 'Please select a color' }));
        $('#color').attr('disabled', 'disabled');
    };
}
</pre>
<div class="preview">
<pre class="js">$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cascadingDropDownSample&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;CascadingDropDownSample();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//binding&nbsp;change&nbsp;event&nbsp;of&nbsp;the&nbsp;&quot;make&quot;&nbsp;select&nbsp;HTML&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#make'</span>).on(<span class="js__string">'change'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;selectedMake&nbsp;=&nbsp;$(<span class="js__operator">this</span>).val();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//if&nbsp;selected&nbsp;other&nbsp;than&nbsp;default&nbsp;option,&nbsp;make&nbsp;a&nbsp;AJAX&nbsp;call&nbsp;to&nbsp;server</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(selectedMake&nbsp;!==&nbsp;<span class="js__string">&quot;-1&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.post(<span class="js__string">'/CascadingDropDownSample/GetSampleModels'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;selectedMake:&nbsp;selectedMake&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.resetCascadingDropDowns();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.getSampleModelsSuccess(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//reset&nbsp;the&nbsp;cascading&nbsp;dropdown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.resetCascadingDropDowns();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//binding&nbsp;change&nbsp;event&nbsp;of&nbsp;the&nbsp;&quot;model&quot;&nbsp;select&nbsp;HTML&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model'</span>).on(<span class="js__string">'change'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;selectedModel&nbsp;=&nbsp;$(<span class="js__operator">this</span>).val();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//if&nbsp;selected&nbsp;other&nbsp;than&nbsp;default&nbsp;option,&nbsp;make&nbsp;a&nbsp;AJAX&nbsp;call&nbsp;to&nbsp;server</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(selectedModel&nbsp;!==&nbsp;<span class="js__string">&quot;-1&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.post(<span class="js__string">'/CascadingDropDownSample/GetSampleColors'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;selectedModel:&nbsp;selectedModel&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.resetColors();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.getSampleColorsSuccess(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//reset&nbsp;the&nbsp;colors&nbsp;dropdown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cascadingDropDownSample.resetColors();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Module&nbsp;for&nbsp;CascadingDropDownSample&nbsp;containing&nbsp;JS&nbsp;helper&nbsp;functions</span>&nbsp;
<span class="js__operator">function</span>&nbsp;CascadingDropDownSample()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.resetCascadingDropDowns&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.resetModels();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.resetColors();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.getSampleModelsSuccess&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//binding&nbsp;JSON&nbsp;data&nbsp;received&nbsp;to&nbsp;HTML&nbsp;select&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(data,&nbsp;<span class="js__operator">function</span>&nbsp;(key,&nbsp;textValue)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model'</span>).append($(<span class="js__string">'&lt;option&nbsp;/&gt;'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;value:&nbsp;key,&nbsp;text:&nbsp;textValue&nbsp;<span class="js__brace">}</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model'</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.getSampleColorsSuccess&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//binding&nbsp;JSON&nbsp;data&nbsp;received&nbsp;to&nbsp;HTML&nbsp;select&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(data,&nbsp;<span class="js__operator">function</span>&nbsp;(key,&nbsp;textValue)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#color'</span>).append($(<span class="js__string">'&lt;option&nbsp;/&gt;'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;value:&nbsp;key,&nbsp;text:&nbsp;textValue&nbsp;<span class="js__brace">}</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#color'</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.resetModels&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model&nbsp;option'</span>).remove();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model'</span>).append($(<span class="js__string">'&lt;option&nbsp;/&gt;'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;value:&nbsp;<span class="js__string">'-1'</span>,&nbsp;text:&nbsp;<span class="js__string">'Please&nbsp;select&nbsp;a&nbsp;model'</span>&nbsp;<span class="js__brace">}</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#model'</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.resetColors&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#color&nbsp;option'</span>).remove();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#color'</span>).append($(<span class="js__string">'&lt;option&nbsp;/&gt;'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;value:&nbsp;<span class="js__string">'-1'</span>,&nbsp;text:&nbsp;<span class="js__string">'Please&nbsp;select&nbsp;a&nbsp;color'</span>&nbsp;<span class="js__brace">}</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#color'</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2 class="endscriptcode">More Information</h2>
<p>&nbsp;ASP.NET MVC</p>
<p>&nbsp;<a href="http://www.asp.net/mvc/mvc4">http://www.asp.net/mvc/mvc4</a></p>
&nbsp;
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img src="http://bit.ly/onecodelogo" alt="">
</a></div>
