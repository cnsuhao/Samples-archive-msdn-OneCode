# Customized Intelligent TextBox via ASP.NET (VBASPNETIntelligentTextBox)
## Requires
* Visual Studio 2008
## License
* MS-LPL
## Technologies
* ASP.NET
## Topics
* Controls
* TextBox
## IsPublished
* True
## ModifiedDate
* 2012-04-20 01:14:42
## Description

<h1>Intelligent TextBox control via ASP.NET (VBASPNETIntelligentTextBox)</h1>
<h2>Introduction</h2>
<p class="MsoNormal">The project illustrates how to create a customized intelligent TextBox control via Asp.net, just like
<a href="http://social.msdn.microsoft.com/Search/en-us?query=Asp.net&x=0&y=0">MSDN library's search TextBox</a>. This sample code can check the user's input words with word dictionary, and provides some similar words for select, customers can also add their
 own words in dictionary, this is a very useful function, for example, in your website, you can record the most popular search words or sentences in your dictionary, and these hot words and sentences appears when customers try to search them.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the VBASPNETIntelligentTextBox.sln. Expand the VBASPNETIntelligentTextBox web application and press Ctrl &#43; F5 to show the Default.aspx.
</p>
<p class="MsoNormal">Step 2: We will see a TextBox control on the page. Please input a character or a word in it.
</p>
<p class="MsoNormal">Step 3: When you input a word in TextBox, you can find a word list below the TextBox. The sample compares your word and put the similar words in word list.
</p>
<p class="MsoNormal"><span style="">&lt;u1:shape id=&quot;Picture_x0020_3&quot; u2:spid=&quot;_x0000_i1025&quot; type=&quot;#_x0000_t75&quot; alt=&quot;Description: Description: Description: Description: http://www.codeproject.com/KB/vista-security/UACSelfElevation/UACSelfElevation3.png&quot; style=&quot;width:3in;height:167.25pt;visibility:visible;mso-wrap-style:square&quot;&gt;&lt;u1:imagedata
 src=&quot;http://localhost:10242/Documentation/ReadMe_files/image003.png&quot; u2:title=&quot;UACSelfElevation3&quot;/&gt;&lt;/u1:shape&gt;
<img src="/site/view/file/56444/1/image.png" alt="" width="533" height="286" align="middle">
</span></p>
<p class="MsoNormal">Step 4: If everything is fine, you can edit your word with prompt or you can directly click words in list to update TextBox's value.<span style="">
</span></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/56445/1/image.png" alt="" width="797" height="121" align="middle">
</span></p>
<p class="MsoNormal">Step 5: You can Click the &quot;Click here to add new word&quot; button for adding more custom words in word dictionary. Then you can find them when you try to input the correct word.
</p>
<p class="MsoNormal"><span style="">&lt;u1:shape id=&quot;Picture_x0020_3&quot; u2:spid=&quot;_x0000_i1025&quot; type=&quot;#_x0000_t75&quot; alt=&quot;Description: Description: Description: Description: http://www.codeproject.com/KB/vista-security/UACSelfElevation/UACSelfElevation3.png&quot; style=&quot;width:3in;height:167.25pt;visibility:visible;mso-wrap-style:square&quot;&gt;&lt;u1:imagedata
 src=&quot;http://localhost:10242/Documentation/ReadMe_files/image003.png&quot; u2:title=&quot;UACSelfElevation3&quot;/&gt;&lt;/u1:shape&gt;
<img src="/site/view/file/56446/1/image.png" alt="" width="556" height="319" align="middle">
</span></p>
<p class="MsoNormal">Step 6: Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal">Code Logical: </p>
<p class="MsoNormal">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 2010 or Visual Web Developer 2010. Name it as &quot;CSASPNETIntelligentTextBox&quot;. Add one folder, &quot;Dictionary&quot;. In order to execute this web
 application, please create a dictionary file. You can create a new dictionary file you like, or use the sample's WordList.txt file.
</p>
<p class="MsoNormal">Step 2. Add one web form page in the root directory, &quot;Default.aspx&quot;. Create a TextBox control, a div element and a label on page. Add some JavaScript functions on Default.aspx page and assigned to TextBox's onkeyup event.</p>
<h3>The following code is use to call web method in code behind file via Ajax and attach the result in unordered list.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function CallPageMethod() {
    PageMethods.ReturnHtmlString(document.getElementById(&quot;tbInput&quot;).value, success, failed);
}
function success(result) {
    var info = document.getElementById(&quot;recommandWordList&quot;);
    info.innerHTML = &quot;<ul id="ulCss">&quot; &#43; result &#43; &quot;</ul>&quot;;
}
function failed(error) {
    var info = document.getElementById(&quot;recommandWordList&quot;);
    info.innerHTML = &quot;&quot;;
}

</pre>
<pre id="codePreview" class="js">
function CallPageMethod() {
    PageMethods.ReturnHtmlString(document.getElementById(&quot;tbInput&quot;).value, success, failed);
}
function success(result) {
    var info = document.getElementById(&quot;recommandWordList&quot;);
    info.innerHTML = &quot;<ul id="ulCss">&quot; &#43; result &#43; &quot;</ul>&quot;;
}
function failed(error) {
    var info = document.getElementById(&quot;recommandWordList&quot;);
    info.innerHTML = &quot;&quot;;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 3. After adding JavaScript function to TextBox, note this function is invoke a page method, it will call a public static method(ReturnHtmlString(string key)) in Default.aspx.cs file. This method provides a Dictionary instance to
 store the high similar level words with user's input, and the dictionary sorted by similar level.
</p>
<h3>The following code is use to compare dictionary with search key word, find and show them to customers.
</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' This method is used to call check user's input word and returns some recommended words.
''' A JavsScript function will invoke this method to execute server-side code,
''' This will bring many benefits, such as when user input words and the application will
''' update recommended word list without page refresh, it can provide more responsive.
''' &lt;/summary&gt;
''' &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;System.Web.Services.WebMethod()&gt; _
Public Shared Function ReturnHtmlString(ByVal key As String) As String


    ' Define an ArrayList to retrieve word list, 
    ' the Dictionary use to record similar words.
    Dim list As ArrayList = LineList
    Dim matchEntity As New Dictionary(Of Integer, String())()
    Dim sortID As Integer = 0
    Dim highLevel As Integer = 0
    ' Loop the word dictionary, compare with source word. 
    For i As Integer = 0 To list.Count - 1
        ' Confirm the word length, calculate word's similar level and 
        ' move the cursor to next character.
        Dim source As String = list(i).ToString()
        Dim sourceLength As Integer = list(i).ToString().Length
        Dim keyLength As Integer = key.Length
        Dim matchLength As Integer = (If((sourceLength &gt; keyLength), keyLength, sourceLength))
        Dim matchLevel As Integer = 0
        Dim cursor As Integer = 0
        While cursor &lt; matchLength
            If source(cursor) = key(cursor) Then
                matchLevel &#43;= 1
                cursor &#43;= 1
            ElseIf matchLevel &gt;= 1 Then
                cursor &#43;= 1
            Else
                matchLevel = 0
                Exit While
            End If
        End While
        If matchLevel &gt;= 1 Then
            Dim entity As String() = New String(3) {}
            entity(0) = matchLevel.ToString()
            entity(1) = source
            entity(2) = sourceLength.ToString()
            matchEntity.Add(sortID, entity)
            If matchLevel &gt; highLevel Then
                highLevel = matchLevel
            End If
            sortID &#43;= 1
        End If
    Next
    Dim highLevelList = From d In matchEntity
                        Where d.Value(0) = highLevel.ToString()
    Select d




    ' Sort the result with the highest similar level and characters' length.
    ' And we must make sure the recommended word list must include 10 words.
    If highLevelList.ToList().Count &lt;= 10 Then
        Dim listNumber As Integer = highLevelList.ToList().Count
        Dim returnHtml As String = String.Empty
        Dim sortMatchList = From d In highLevelList
                            Order By Convert.ToInt32(d.Value(2))
                            Select d
        For Each s In sortMatchList
            returnHtml &#43;= &quot;<li>&quot; &#43; s.Value(1) & &quot;&quot;
            matchEntity.Remove(s.Key)
            listNumber &#43;= 1
        Next
        Dim lowLevelList = matchEntity.OrderByDescending(Function(d) d.Value(0))
        Dim number As Integer = 0
        For Each s In lowLevelList
            If number &lt; (10 - listNumber) Then
                returnHtml &#43;= &quot;</li><li>&quot; &#43; s.Value(1) & &quot;&quot;
                number &#43;= 1
            Else
                Exit For
            End If
        Next
        Return returnHtml
    Else
        Dim listNumber As Integer = 0
        Dim returnHtml As String = String.Empty
        Dim sortMatchList = From d In highLevelList
                            Order By Convert.ToInt32(d.Value(2))
                            Select d
        For i As Integer = 0 To sortMatchList.ToList().Count - 1
            If listNumber &lt; 10 Then
                returnHtml &#43;= &quot;</li><li>&quot; &#43; sortMatchList.ToList()(i).Value(1) & &quot;&quot;
                listNumber &#43;= 1
            Else
                Exit For
                End If
        Next
        Return returnHtml
    End If
End Function

</li></pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' This method is used to call check user's input word and returns some recommended words.
''' A JavsScript function will invoke this method to execute server-side code,
''' This will bring many benefits, such as when user input words and the application will
''' update recommended word list without page refresh, it can provide more responsive.
''' &lt;/summary&gt;
''' &lt;param name=&quot;key&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
&lt;System.Web.Services.WebMethod()&gt; _
Public Shared Function ReturnHtmlString(ByVal key As String) As String


    ' Define an ArrayList to retrieve word list, 
    ' the Dictionary use to record similar words.
    Dim list As ArrayList = LineList
    Dim matchEntity As New Dictionary(Of Integer, String())()
    Dim sortID As Integer = 0
    Dim highLevel As Integer = 0
    ' Loop the word dictionary, compare with source word. 
    For i As Integer = 0 To list.Count - 1
        ' Confirm the word length, calculate word's similar level and 
        ' move the cursor to next character.
        Dim source As String = list(i).ToString()
        Dim sourceLength As Integer = list(i).ToString().Length
        Dim keyLength As Integer = key.Length
        Dim matchLength As Integer = (If((sourceLength &gt; keyLength), keyLength, sourceLength))
        Dim matchLevel As Integer = 0
        Dim cursor As Integer = 0
        While cursor &lt; matchLength
            If source(cursor) = key(cursor) Then
                matchLevel &#43;= 1
                cursor &#43;= 1
            ElseIf matchLevel &gt;= 1 Then
                cursor &#43;= 1
            Else
                matchLevel = 0
                Exit While
            End If
        End While
        If matchLevel &gt;= 1 Then
            Dim entity As String() = New String(3) {}
            entity(0) = matchLevel.ToString()
            entity(1) = source
            entity(2) = sourceLength.ToString()
            matchEntity.Add(sortID, entity)
            If matchLevel &gt; highLevel Then
                highLevel = matchLevel
            End If
            sortID &#43;= 1
        End If
    Next
    Dim highLevelList = From d In matchEntity
                        Where d.Value(0) = highLevel.ToString()
    Select d




    ' Sort the result with the highest similar level and characters' length.
    ' And we must make sure the recommended word list must include 10 words.
    If highLevelList.ToList().Count &lt;= 10 Then
        Dim listNumber As Integer = highLevelList.ToList().Count
        Dim returnHtml As String = String.Empty
        Dim sortMatchList = From d In highLevelList
                            Order By Convert.ToInt32(d.Value(2))
                            Select d
        For Each s In sortMatchList
            returnHtml &#43;= &quot;<li>&quot; &#43; s.Value(1) & &quot;&quot;
            matchEntity.Remove(s.Key)
            listNumber &#43;= 1
        Next
        Dim lowLevelList = matchEntity.OrderByDescending(Function(d) d.Value(0))
        Dim number As Integer = 0
        For Each s In lowLevelList
            If number &lt; (10 - listNumber) Then
                returnHtml &#43;= &quot;</li><li>&quot; &#43; s.Value(1) & &quot;&quot;
                number &#43;= 1
            Else
                Exit For
            End If
        Next
        Return returnHtml
    Else
        Dim listNumber As Integer = 0
        Dim returnHtml As String = String.Empty
        Dim sortMatchList = From d In highLevelList
                            Order By Convert.ToInt32(d.Value(2))
                            Select d
        For i As Integer = 0 To sortMatchList.ToList().Count - 1
            If listNumber &lt; 10 Then
                returnHtml &#43;= &quot;</li><li>&quot; &#43; sortMatchList.ToList()(i).Value(1) & &quot;&quot;
                listNumber &#43;= 1
            Else
                Exit For
                End If
        Next
        Return returnHtml
    End If
End Function

</li></pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 4. Create a JavaScript function to get the value from word list. The function will help customers that copy the word from recommended word list to TextBox, customers can choose what they want.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function getValue(li) {
    var textBox = document.getElementById(&quot;tbInput&quot;);
    var value = li.innerText;
    textBox.value = value;
}

</pre>
<pre id="codePreview" class="js">
function getValue(li) {
    var textBox = document.getElementById(&quot;tbInput&quot;);
    var value = li.innerText;
    textBox.value = value;
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 5. Add a web form page for adding new custom words in word dictionary file, name it as &quot;WordAddPage.aspx&quot;. This page use to add new words in word dictionary, if you like, you can create a more convenient and intelligent
 methods that add most popular words timely<span style="">&nbsp; </span>for keeping your words prompt function more efficient.</p>
<h3>The following code shows how to add new words in txt file.</h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>VB</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">vb</span>
<pre class="hidden">
''' &lt;summary&gt;
''' Add new words
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    Dim validateResult As String = StringValidate(tbNewWords.Text)
    If String.IsNullOrEmpty(validateResult) Then
        Dim words As String() = tbNewWords.Text.Trim().Split(&quot;,&quot;c)
        Using writer As New StreamWriter(Server.MapPath(&quot;~/Dictionary/WordList.txt&quot;), True)
            For Each str As String In words
                writer.WriteLine(str)
            Next
            lbMessage.Text = &quot;Congratulations, the new word has been added in Word dictionary.&quot;
        End Using
    Else
        lbMessage.Text = validateResult
    End If
End Sub


Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
    Response.Redirect(&quot;~/Default.aspx&quot;)
End Sub
''' &lt;summary&gt;
''' String variables validation.
''' &lt;/summary&gt;
''' &lt;param name=&quot;strWords&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Shared Function StringValidate(ByVal strWords As String) As String
    Dim words As String = strWords.Trim()
    If String.IsNullOrEmpty(words) Then
        Return &quot;Words can not be null.&quot;
    ElseIf StringIncludeNumberic(words) Then
        Return &quot;Words can not include numeral and special characters.&quot;
    Else
        Return String.Empty
    End If
End Function


Protected Shared Function StringIncludeNumberic(ByVal strWords As String) As Boolean
    Dim strRegex As String = &quot;[^a-zA-z,']&quot;
    Return Regex.IsMatch(strWords, strRegex)
End Function

</pre>
<pre id="codePreview" class="vb">
''' &lt;summary&gt;
''' Add new words
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    Dim validateResult As String = StringValidate(tbNewWords.Text)
    If String.IsNullOrEmpty(validateResult) Then
        Dim words As String() = tbNewWords.Text.Trim().Split(&quot;,&quot;c)
        Using writer As New StreamWriter(Server.MapPath(&quot;~/Dictionary/WordList.txt&quot;), True)
            For Each str As String In words
                writer.WriteLine(str)
            Next
            lbMessage.Text = &quot;Congratulations, the new word has been added in Word dictionary.&quot;
        End Using
    Else
        lbMessage.Text = validateResult
    End If
End Sub


Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
    Response.Redirect(&quot;~/Default.aspx&quot;)
End Sub
''' &lt;summary&gt;
''' String variables validation.
''' &lt;/summary&gt;
''' &lt;param name=&quot;strWords&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;&lt;/returns&gt;
''' &lt;remarks&gt;&lt;/remarks&gt;
Protected Shared Function StringValidate(ByVal strWords As String) As String
    Dim words As String = strWords.Trim()
    If String.IsNullOrEmpty(words) Then
        Return &quot;Words can not be null.&quot;
    ElseIf StringIncludeNumberic(words) Then
        Return &quot;Words can not include numeral and special characters.&quot;
    Else
        Return String.Empty
    End If
End Function


Protected Shared Function StringIncludeNumberic(ByVal strWords As String) As Boolean
    Dim strRegex As String = &quot;[^a-zA-z,']&quot;
    Return Regex.IsMatch(strWords, strRegex)
End Function

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"></p>
<p class="MsoNormal">Step 6. Build the application and you can debug it.</p>
<p class="MsoNormal"></p>
<h2>More Information</h2>
<p class="MsoListParagraph" style=""><span style="font-family:Symbol"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.page_methods(VS.85).aspx">MSDN:<span style="">&nbsp;
</span>PageMethods</a></p>
<p class="MsoNormal"></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
