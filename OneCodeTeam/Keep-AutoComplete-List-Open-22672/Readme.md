# Keep AutoComplete List Open
## Requires
* Visual Studio 2012
## License
* Apache License, Version 2.0
## Technologies
* ASP.NET
## Topics
* AutoComplete
* ASPNET
## IsPublished
* True
## ModifiedDate
* 2013-06-13 10:51:41
## Description

<h1>Keep AutoComplete List Open, and select multiple options. (<span class="SpellE">CSASPNETKeepAutoCompleteListOpen</span>)</h1>
<h2>Introduction </h2>
<p class="MsoNormal">This project demonstrates how to keep AutoComplete List Open, and select multiple options. This feature can be used in many scenarios.
<a name="OLE_LINK7"></a><a name="OLE_LINK6"><span style="">Such as </span></a>when user wants to select multiple products based on
<a name="OLE_LINK3"></a><a name="OLE_LINK2"><span style="">fuzzy search</span></a>.
</p>
<h2>Running the Sample</h2>
<p class="MsoNormal">Please follow these demonstration steps below.</p>
<p class="MsoNormal">Step 1:&nbsp;Open the <span style="">CSASPNETKeepAutoCompleteListOpen</span>.sln. Expand the
<a name="OLE_LINK1"><span style="">CSASPNETKeepAutoCompleteListOpen</span> </a>
web application and press Ctrl &#43; F5 to show the Default.aspx. </p>
<p class="MsoNormal"><b style="">[Note]</b> <b style="">You may need to install the AjaxControlToolkit,</b>
<b style="">You can download it here: <a href="http://ajaxcontroltoolkit.codeplex.com/">
http://ajaxcontroltoolkit.codeplex.com/</a> </b></p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84724/1/image.png" alt="" width="737" height="214" align="middle">
</span><span style="">&nbsp;</span><br clear="all" style="">
</p>
<p class="MsoNormal">Step 2: Enter part or complete name of the movie.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84725/1/image.png" alt="" width="735" height="319" align="middle">
</span></p>
<p class="MsoNormal">Select some options.</p>
<p class="MsoNormal"><span style=""><img src="/site/view/file/84726/1/image.png" alt="" width="749" height="338" align="middle">
</span></p>
<p class="MsoNormal">Step 3: Click &quot;Close the Popup&quot; or &quot;Reset the ListBox&quot;.<br>
<span style=""><img src="/site/view/file/84727/1/image.png" alt="" width="765" height="223" align="middle">
</span></p>
<p class="MsoNormal">Step 4:<span style="">&nbsp;&nbsp; </span>Validation finished.</p>
<h2>Using the Code</h2>
<p class="MsoNormal" style="">Code Logical: <span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></p>
<p class="MsoNormal">Step 1. Create a C# &quot;ASP.NET Empty Web Application&quot; in Visual Studio 20<span style="">12</span>. Name it as &quot;<span style="">CSASPNETKeepAutoCompleteListOpen</span>&quot;.
</p>
<p class="MsoNormal">Step 2.<span style="">&nbsp; </span>Add a WebService and rename it to &quot;<span style="">AutoComplete</span>&quot;. This WebService is used to search for movies
<a name="OLE_LINK5"></a><a name="OLE_LINK4"><span style="">under the conditions</span></a>. Move code file to the
<span class="SpellE">App_Code</span> folder.<span style=""> </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
&lt;%@ WebService Language=&quot;C#&quot; CodeBehind=&quot;~/App_Code/AutoComplete.cs&quot; Class=&quot;AutoComplete&quot; %&gt;

</pre>
<pre id="codePreview" class="csharp">
&lt;%@ WebService Language=&quot;C#&quot; CodeBehind=&quot;~/App_Code/AutoComplete.cs&quot; Class=&quot;AutoComplete&quot; %&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
The code of the WebService as shown below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{
    private List&lt;string&gt; _movies = new List&lt;string&gt;();


    public AutoComplete()
    {
        _movies.Add(&quot;a1&quot;);
        _movies.Add(&quot;a2&quot;);
        _movies.Add(&quot;b1&quot;);
        _movies.Add(&quot;China&quot;);
        _movies.Add(&quot;c21&quot;);
        _movies.Add(&quot;Dr. Seuss' The Lorax &quot;);
        _movies.Add(&quot;Dear Channing Tatum, We Heart You. &quot;);
        _movies.Add(&quot;Dream&quot;);
        _movies.Add(&quot;Empty&quot;);
        _movies.Add(&quot;Egg&quot;);
        _movies.Add(&quot;Flower&quot;);
        _movies.Add(&quot;Floor&quot;);
        _movies.Add(&quot;Great&quot;);
        _movies.Add(&quot;g&quot;);
        _movies.Add(&quot;h1&quot;);
        _movies.Add(&quot;h2&quot;);
        _movies.Add(&quot;i1&quot;);
        _movies.Add(&quot;jeep&quot;);
        _movies.Add(&quot;k&quot;);
        _movies.Add(&quot;Loop&quot;);
        _movies.Add(&quot;Man&quot;);
        _movies.Add(&quot;Nice&quot;);
        _movies.Add(&quot;O1&quot;);
        _movies.Add(&quot;Pear&quot;);
        _movies.Add(&quot;Queen&quot;);
        _movies.Add(&quot;Rest&quot;);
        _movies.Add(&quot;Super Man&quot;);
        _movies.Add(&quot;Safe House &quot;);
        _movies.Add(&quot;This Means War &quot;);
        _movies.Add(&quot;The Secret World of Arrietty &quot;);
        _movies.Add(&quot;US&quot;);
        _movies.Add(&quot;UK&quot;);
        _movies.Add(&quot;V&quot;);
        _movies.Add(&quot;W&quot;);
        _movies.Add(&quot;X&quot;);
        _movies.Add(&quot;Y&quot;);
        _movies.Add(&quot;Z&quot;);
    }


    [WebMethod]
    public string[] GetMovies(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }


        var matches = (from m in _movies
                       where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)
                       select m).Take(count);
        return matches.ToArray();
    }
}

</pre>
<pre id="codePreview" class="csharp">
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{
    private List&lt;string&gt; _movies = new List&lt;string&gt;();


    public AutoComplete()
    {
        _movies.Add(&quot;a1&quot;);
        _movies.Add(&quot;a2&quot;);
        _movies.Add(&quot;b1&quot;);
        _movies.Add(&quot;China&quot;);
        _movies.Add(&quot;c21&quot;);
        _movies.Add(&quot;Dr. Seuss' The Lorax &quot;);
        _movies.Add(&quot;Dear Channing Tatum, We Heart You. &quot;);
        _movies.Add(&quot;Dream&quot;);
        _movies.Add(&quot;Empty&quot;);
        _movies.Add(&quot;Egg&quot;);
        _movies.Add(&quot;Flower&quot;);
        _movies.Add(&quot;Floor&quot;);
        _movies.Add(&quot;Great&quot;);
        _movies.Add(&quot;g&quot;);
        _movies.Add(&quot;h1&quot;);
        _movies.Add(&quot;h2&quot;);
        _movies.Add(&quot;i1&quot;);
        _movies.Add(&quot;jeep&quot;);
        _movies.Add(&quot;k&quot;);
        _movies.Add(&quot;Loop&quot;);
        _movies.Add(&quot;Man&quot;);
        _movies.Add(&quot;Nice&quot;);
        _movies.Add(&quot;O1&quot;);
        _movies.Add(&quot;Pear&quot;);
        _movies.Add(&quot;Queen&quot;);
        _movies.Add(&quot;Rest&quot;);
        _movies.Add(&quot;Super Man&quot;);
        _movies.Add(&quot;Safe House &quot;);
        _movies.Add(&quot;This Means War &quot;);
        _movies.Add(&quot;The Secret World of Arrietty &quot;);
        _movies.Add(&quot;US&quot;);
        _movies.Add(&quot;UK&quot;);
        _movies.Add(&quot;V&quot;);
        _movies.Add(&quot;W&quot;);
        _movies.Add(&quot;X&quot;);
        _movies.Add(&quot;Y&quot;);
        _movies.Add(&quot;Z&quot;);
    }


    [WebMethod]
    public string[] GetMovies(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }


        var matches = (from m in _movies
                       where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase)
                       select m).Take(count);
        return matches.ToArray();
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 3.<span style="">&nbsp; </span>Add an <span class="SpellE">AutoCompleteExtender</span> Control, a
<span class="SpellE">TextBox</span> Control and a <span class="SpellE">ListBox</span> control in the Default.aspx.
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">html</span>
<pre class="hidden">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
&lt;/AjaxControlToolkit:ToolkitScriptManager&gt;
<div>
    <table border="1"><caption>
            Personal information settings
        </caption><tbody><tr><td colspan="4">You
 can search favorite movies, and then you may select multiple items. </td></tr><tr><td>MovieName: &lt;asp:TextBox ID=&quot;tbMovies&quot; runat=&quot;server&quot; Text=''&gt;&lt;/asp:TextBox&gt; </td><td>&lt;input type=&quot;button&quot; name=&quot;close&quot; value=&quot;Close the Popup&quot; onclick=&quot;hideOptionList();&quot;
 /&gt; &lt;AjaxControlToolkit:AutoCompleteExtender ID=&quot;AutoCompleteExtender1&quot; BehaviorID=&quot;ACE&quot; runat=&quot;server&quot; TargetControlID=&quot;tbMovies&quot; ServicePath=&quot;AutoComplete.asmx&quot; ServiceMethod=&quot;GetMovies&quot; MinimumPrefixLength=&quot;1&quot; CompletionInterval=&quot;10&quot; CompletionSetCount=&quot;10&quot;
 EnableCaching=&quot;true&quot; /&gt; </td><td>&lt;asp:ListBox ID=&quot;ListBox1&quot; runat=&quot;server&quot;&gt;&lt;/asp:ListBox&gt; </td><td>&lt;input type=&quot;button&quot; name=&quot;reset&quot; value=&quot;Reset the ListBox&quot; onclick=&quot;resetListBox();&quot; /&gt; </td></tr></tbody></table>
</div>
&lt;script src=&quot;AutoComplete.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

</pre>
<pre id="codePreview" class="html">
&lt;AjaxControlToolkit:ToolkitScriptManager CombineScripts=&quot;false&quot; runat=&quot;server&quot; EnablePartialRendering=&quot;true&quot;&gt;
&lt;/AjaxControlToolkit:ToolkitScriptManager&gt;
<div>
    <table border="1"><caption>
            Personal information settings
        </caption><tbody><tr><td colspan="4">You
 can search favorite movies, and then you may select multiple items. </td></tr><tr><td>MovieName: &lt;asp:TextBox ID=&quot;tbMovies&quot; runat=&quot;server&quot; Text=''&gt;&lt;/asp:TextBox&gt; </td><td>&lt;input type=&quot;button&quot; name=&quot;close&quot; value=&quot;Close the Popup&quot; onclick=&quot;hideOptionList();&quot;
 /&gt; &lt;AjaxControlToolkit:AutoCompleteExtender ID=&quot;AutoCompleteExtender1&quot; BehaviorID=&quot;ACE&quot; runat=&quot;server&quot; TargetControlID=&quot;tbMovies&quot; ServicePath=&quot;AutoComplete.asmx&quot; ServiceMethod=&quot;GetMovies&quot; MinimumPrefixLength=&quot;1&quot; CompletionInterval=&quot;10&quot; CompletionSetCount=&quot;10&quot;
 EnableCaching=&quot;true&quot; /&gt; </td><td>&lt;asp:ListBox ID=&quot;ListBox1&quot; runat=&quot;server&quot;&gt;&lt;/asp:ListBox&gt; </td><td>&lt;input type=&quot;button&quot; name=&quot;reset&quot; value=&quot;Reset the ListBox&quot; onclick=&quot;resetListBox();&quot; /&gt; </td></tr></tbody></table>
</div>
&lt;script src=&quot;AutoComplete.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal">Step 4. Write the JavaScript file for the feature.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function hideOptionList() {
    $find('ACE').hidePopup();
    $get('tbMovies').value = &quot;&quot;;
}


function resetListBox() {
    var list = $get(&quot;ListBox1&quot;);
    list.options.length = 0;
}


// These two functions are copied from the original design code of the AutoCompleteBehavior.  
// We modify them to insert the selected value and keep the CompletionList shown.  


// Note that we need to place the script tag under the ScriptManager and the AutoCompleteExtender  
// to ensure we can use the AjaxControlToolkit namespace.  


Sys.Extended.UI.AutoCompleteBehavior.prototype._setText = function(item) {
    // Rewrite the _setText function to insert the newText into the ListBox.  
    var text = (item && item.firstChild) ? item.firstChild.nodeValue : null;
    this._timer.set_enabled(false);


    var element = this.get_element();
    var control = element.control;


    var newText = this._showOnlyCurrentWordInCompletionListItem ? this._getTextWithInsertedWord(text) : text;
    if (control && control.set_text) {
        control.set_text(newText);
    } else {
        element.value = newText;
    }


    //********Add the selection into the ListBox1********//  
    var list = $get(&quot;ListBox1&quot;);
    list.options.add(new Option(newText, newText));
    //********End****************************************//  


    $common.tryFireEvent(element, &quot;change&quot;);


    this.raiseItemSelected(new Sys.Extended.UI.AutoCompleteItemEventArgs(item, text, item ? item._value : null));


    this._currentPrefix = this._currentCompletionWord();
    this._hideCompletionList();
};
Sys.Extended.UI.AutoCompleteBehavior.prototype._hideCompletionList = function() {
    // Rewrite the _hideCompletionList function to keep the list shown all the time  
    var eventArgs = new Sys.CancelEventArgs();
    this.raiseHiding(eventArgs);
    if (eventArgs.get_cancel()) {
        return;
    }
    // The hidePopup function is to close the CompletionList, so we need to   
    //  comment this line to ensure the CompletionList is visible.  
    // this.hidePopup();  
};  

</pre>
<pre id="codePreview" class="js">
function hideOptionList() {
    $find('ACE').hidePopup();
    $get('tbMovies').value = &quot;&quot;;
}


function resetListBox() {
    var list = $get(&quot;ListBox1&quot;);
    list.options.length = 0;
}


// These two functions are copied from the original design code of the AutoCompleteBehavior.  
// We modify them to insert the selected value and keep the CompletionList shown.  


// Note that we need to place the script tag under the ScriptManager and the AutoCompleteExtender  
// to ensure we can use the AjaxControlToolkit namespace.  


Sys.Extended.UI.AutoCompleteBehavior.prototype._setText = function(item) {
    // Rewrite the _setText function to insert the newText into the ListBox.  
    var text = (item && item.firstChild) ? item.firstChild.nodeValue : null;
    this._timer.set_enabled(false);


    var element = this.get_element();
    var control = element.control;


    var newText = this._showOnlyCurrentWordInCompletionListItem ? this._getTextWithInsertedWord(text) : text;
    if (control && control.set_text) {
        control.set_text(newText);
    } else {
        element.value = newText;
    }


    //********Add the selection into the ListBox1********//  
    var list = $get(&quot;ListBox1&quot;);
    list.options.add(new Option(newText, newText));
    //********End****************************************//  


    $common.tryFireEvent(element, &quot;change&quot;);


    this.raiseItemSelected(new Sys.Extended.UI.AutoCompleteItemEventArgs(item, text, item ? item._value : null));


    this._currentPrefix = this._currentCompletionWord();
    this._hideCompletionList();
};
Sys.Extended.UI.AutoCompleteBehavior.prototype._hideCompletionList = function() {
    // Rewrite the _hideCompletionList function to keep the list shown all the time  
    var eventArgs = new Sys.CancelEventArgs();
    this.raiseHiding(eventArgs);
    if (eventArgs.get_cancel()) {
        return;
    }
    // The hidePopup function is to close the CompletionList, so we need to   
    //  comment this line to ensure the CompletionList is visible.  
    // this.hidePopup();  
};  

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal"><br>
Step 5. Build the application and you can debug it.</p>
<h2>More Information</h2>
<p class="MsoNormal"><span class="SpellE">AjaxControlToolkitSampleSite</span><span style=""><br>
<a href="http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/Rating/Rating.aspx">http://www.asp.net/ajaxLibrary/AjaxControlToolkitSampleSite/Rating/Rating.aspx</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
