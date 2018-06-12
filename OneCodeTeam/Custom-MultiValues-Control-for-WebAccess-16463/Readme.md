# Custom MultiValues Control for WebAccess (CSTFSWebAccessMultiValueControl)
## Requires
* Visual Studio 2010
## License
* MS-LPL
## Technologies
* TFS
## Topics
* Controls
* Work Item
## IsPublished
* True
## ModifiedDate
* 2012-04-20 12:22:41
## Description

<h1>Custom <span class="SpellE"><span style="">MultiValues</span></span><span style="">
</span>work item control of <span style="">TFS2010 <span class="SpellE">WebAccess</span></span> (<span class="SpellE"><span style="">CSTFSWebAccessWorkItemMultiValueControl</span></span>)<span style="">
</span></h1>
<h2>Introduction</h2>
<p class="MsoNormal"><span style="">The <span class="SpellE"><span style="">CSTFSWebAccessWorkItemMultiValueControl
</span></span></span><span style="">sample</span><span style=""> demonstrates how to create a
</span><span style="">custom </span><span class="SpellE"><span style="">MultiValues</span></span><span style="">
</span><span style="">work item control of </span><span style="">TFS2010 WebAccess.
</span></p>
<h2><span style="">Building</span> the Sample<span style=""> </span></h2>
<p class="MsoNormal"><span style="">This sample should be built on TFS2010 AppTier and the target framework is .NET Framework 3.5, because following assemblise are only available in the App Tier.
</span></p>
<p class="MsoListParagraphCxSpFirst" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.WorkItemTracking.Client
</span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.WebAccess.Controls </span>
</p>
<p class="MsoListParagraphCxSpLast" style=""><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">Microsoft.TeamFoundation.WebAccess.WorkItemTracking
</span></p>
<h2>Running the Sample<span style=""> </span></h2>
<p class="MsoListParagraphCxSpFirst" style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Copy following items to <u>C:\Program Files\Microsoft Team Foundation Server 2010\Application Tier\Web Access\Web\<span class="SpellE">App_Data</span>\<span class="SpellE">CustomControls</span></u>.
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span class="SpellE"><span style="">MultiValuesControl.wicc</span></span><span style="">
</span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:72.0pt"><span style="font-family:Wingdings"><span style="">��<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;
</span></span></span><span style="">CSTFSWebAccessWorkItemMultiValueControl.dll </span>
</p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Use <span class="SpellE"><b style="">WitAdmin</b></span>
<span class="SpellE"><b style="">importwitd</b></span> command line to import the
<a name="OLE_LINK1"></a><a name="OLE_LINK2"><span style=""><b style="">WIT </b>
</span></a><span class="SpellE"><b style="">MultiValues</b></span> (WIT MultiValues.xml) WorkItem Type.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style="">See <a href="http://msdn.microsoft.com/en-us/library/dd312129.aspx">
http://msdn.microsoft.com/en-us/library/dd312129.aspx</a>. TFS Power Tools also supplies a more convenient approach.
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Open Team <span class="SpellE">WebAccess</span> in IE, and connect to the Team Project to which you import the
<b style="">WIT <span class="SpellE">MultiValues</span>.</b> </span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Create a new <b style="">WIT Controls </b>work item, and you will see
</span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""><img src="/site/view/file/56208/1/image.png" alt="" width="528" height="309" align="middle">
</span><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style=""><span style=""><span style="">5.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Type the title and select the options, then save the work item.
</span></p>
<p class="MsoListParagraphCxSpLast"><span style=""><img src="/site/view/file/56209/1/image.png" alt="" width="576" height="260" align="middle">
</span><span style=""></span></p>
<p class="MsoNormal"><span style=""></span></p>
<h2>Using the Code<span style=""> </span></h2>
<p class="MsoListParagraph" style="margin-left:54.0pt"><b style=""><span style=""><span style="">1.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">This control inherits <span class="SpellE">
BaseWorkItemWebControl</span> which implements most methods of the <span class="SpellE">
IWorkItemWebControl</span> interface. </span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
public class MultiValuesControl : BaseWorkItemWebControl

</pre>
<pre id="codePreview" class="csharp">
public class MultiValuesControl : BaseWorkItemWebControl

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><b style=""><span style=""><span style="">2.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">The server side code is used to initialize the controls and flush the value to data source.<span style="">
</span></span></b></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">The value of the field is stored as<span style="">&nbsp;
</span>string which use ��;�� to split the selected options. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// This char is used to split the options.
const char splitCharactor = ';';


// A list of CheckBoxes which represent the options.
private CheckBoxList lstOptions;


#region IWorkItemWebControl


/// &lt;summary&gt;
/// Clear the value in the checkboxes.
/// &lt;/summary&gt;
public override void Clear()
{
    this.EnsureChildControls();
    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        this.lstOptions.Items[i].Selected = false;
    }
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Combine the selected options to a string, and then set it as the 
/// field value.
/// &lt;/summary&gt;
public override void FlushToDatasource()
{
    this.EnsureChildControls();


    StringBuilder value = new StringBuilder();
    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        if (this.lstOptions.Items[i].Selected)
        {
            value.AppendFormat(&quot;{0}{1}&quot;, this.lstOptions.Items[i],
                splitCharactor);
        }
    }
    this.SetFieldValue(value.ToString());
}


///&lt;summary&gt;
/// Asks control to invalidate the contents and redraw.
/// &lt;/summary&gt;
public override void InvalidateDatasource()
{
    this.EnsureChildControls();
    this.Clear();


    this.lstOptions.BackColor = Color.White;


    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        bool checkedState = (this.Field.Value as string).Contains(
            string.Format(&quot;{0}{1}&quot;, this.lstOptions.Items[i].Text, splitCharactor));
        this.lstOptions.Items[i].Selected = checkedState;
    }
}

</pre>
<pre id="codePreview" class="csharp">
// This char is used to split the options.
const char splitCharactor = ';';


// A list of CheckBoxes which represent the options.
private CheckBoxList lstOptions;


#region IWorkItemWebControl


/// &lt;summary&gt;
/// Clear the value in the checkboxes.
/// &lt;/summary&gt;
public override void Clear()
{
    this.EnsureChildControls();
    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        this.lstOptions.Items[i].Selected = false;
    }
}


/// &lt;summary&gt;
/// Control is requested to flush any data to workitem object. 
/// Combine the selected options to a string, and then set it as the 
/// field value.
/// &lt;/summary&gt;
public override void FlushToDatasource()
{
    this.EnsureChildControls();


    StringBuilder value = new StringBuilder();
    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        if (this.lstOptions.Items[i].Selected)
        {
            value.AppendFormat(&quot;{0}{1}&quot;, this.lstOptions.Items[i],
                splitCharactor);
        }
    }
    this.SetFieldValue(value.ToString());
}


///&lt;summary&gt;
/// Asks control to invalidate the contents and redraw.
/// &lt;/summary&gt;
public override void InvalidateDatasource()
{
    this.EnsureChildControls();
    this.Clear();


    this.lstOptions.BackColor = Color.White;


    for (int i = 0; i &lt; this.lstOptions.Items.Count; i&#43;&#43;)
    {
        bool checkedState = (this.Field.Value as string).Contains(
            string.Format(&quot;{0}{1}&quot;, this.lstOptions.Items[i].Text, splitCharactor));
        this.lstOptions.Items[i].Selected = checkedState;
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Register the client side script. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">csharp</span>
<pre class="hidden">
// Defines the metadata attribute that enables an embedded resource in an assembly.
[assembly: WebResource(&quot;CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js&quot;,
    &quot;application/x-javascript&quot;)]

</pre>
<pre id="codePreview" class="csharp">
// Defines the metadata attribute that enables an embedded resource in an assembly.
[assembly: WebResource(&quot;CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js&quot;,
    &quot;application/x-javascript&quot;)]

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
/// &lt;summary&gt;
/// Register the client script.
/// 1. CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
/// 2. Use multiValuesControl method in CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
///    to generate a client object.
/// &lt;/summary&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
protected override void OnPreRender(EventArgs e)
{
    base.OnPreRender(e);
    ScriptManager.RegisterClientScriptResource(
        this, typeof(MultiValuesControl),
        &quot;CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js&quot;);


    string clientID = this.lstOptions.ClientID;


    ScriptHelper.RegisterObjectScript(
        this,
        &quot;multiValuesControl&quot;,
        new object[] {
            base.ClientEditorObjectId, 
            base.WorkItemFieldName,                   
            base.ControlId, 
            clientID,
            base.ReadOnly
        });
}

</pre>
<pre id="codePreview" class="csharp">
/// &lt;summary&gt;
/// Register the client script.
/// 1. CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
/// 2. Use multiValuesControl method in CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js
///    to generate a client object.
/// &lt;/summary&gt;
/// &lt;param name=&quot;e&quot;&gt;&lt;/param&gt;
protected override void OnPreRender(EventArgs e)
{
    base.OnPreRender(e);
    ScriptManager.RegisterClientScriptResource(
        this, typeof(MultiValuesControl),
        &quot;CSTFSWebAccessWorkItemMultiValueControl.MultiValuesControl.js&quot;);


    string clientID = this.lstOptions.ClientID;


    ScriptHelper.RegisterObjectScript(
        this,
        &quot;multiValuesControl&quot;,
        new object[] {
            base.ClientEditorObjectId, 
            base.WorkItemFieldName,                   
            base.ControlId, 
            clientID,
            base.ReadOnly
        });
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""><span style="">3.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">The client side Javascript is used to display the data in browser and handle the client event.
</span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">a.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Define the contrstructor of the client object.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
function multiValuesControl(id,
                      workItemEditorObjectId,
                      fieldName,
                      controlId,
                      innerControlId,
                      readOnly) {


    // The m_workItemEditor represents the workItemEditor object in client side.
    // It supply methods to 
    //     1. Get field value.
    //     2. Update field value.
    //     3. Refresh all field.
    //     4. Other services. 
    // We can use $getObject(m_workItemEditorObjectId) to get it later.
    this.m_workItemEditorObjectId = workItemEditorObjectId;
    this.m_workItemEditor = null;


    // The field name.
    this.m_fieldName = fieldName;


    // The ID of this control.
    // We can use $getObject(controlId) to get this object.
    this.m_controlId = controlId;


    // The id of the lstOptions.
    this.m_innerControlId = innerControlId;


    // The client html element of pnlContainer.
    this.m_control = null;
    this.m_readOnly = readOnly;


    // Array of checkboxes
    this.m_options = null;


}

</pre>
<pre id="codePreview" class="js">
function multiValuesControl(id,
                      workItemEditorObjectId,
                      fieldName,
                      controlId,
                      innerControlId,
                      readOnly) {


    // The m_workItemEditor represents the workItemEditor object in client side.
    // It supply methods to 
    //     1. Get field value.
    //     2. Update field value.
    //     3. Refresh all field.
    //     4. Other services. 
    // We can use $getObject(m_workItemEditorObjectId) to get it later.
    this.m_workItemEditorObjectId = workItemEditorObjectId;
    this.m_workItemEditor = null;


    // The field name.
    this.m_fieldName = fieldName;


    // The ID of this control.
    // We can use $getObject(controlId) to get this object.
    this.m_controlId = controlId;


    // The id of the lstOptions.
    this.m_innerControlId = innerControlId;


    // The client html element of pnlContainer.
    this.m_control = null;
    this.m_readOnly = readOnly;


    // Array of checkboxes
    this.m_options = null;


}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">b.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Initialize or reinitialize the client controls.
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
// This method will be called by m_workItemEditor.
multiValuesControl.prototype.init = function multiValuesControl$init() {
    this.m_workItemEditor = $getObject(this.m_workItemEditorObjectId);


    // Attach a event handler to the editorReady event of the workItemEditor.
    // The workItemEditor has other event like 
    //     1. synchronize.
    //     2. serverRoundtripStart.
    //     3. fieldChange.
    //     4. updateField-complete.
    //     5. beforeSave.
    //     6. serverRoundtripEnd.
    //     7. add-link.
    // You can find all the definition in EditWorkItem.js
    this.m_workItemEditor.attachEvent(&quot;editorReady&quot;, Function.createDelegate(this, this.onEditorReady));


    this.m_control = $getObject(this.m_innerControlId);
    this.m_options = JsUtility.getElementsByTagName(this.m_control, &quot;input&quot;);
    for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
        JsUtility.attachEvent(this.m_options[i], &quot;change&quot;,
            Function.createDelegate(this, this.onCheckboxChanged), true);
    }


}


// Initialize the control.
multiValuesControl.prototype.onEditorReady = function multiValuesControl$onEditorReady() {
    this.reinitCheckboxList();
}


// Initialize the control.
multiValuesControl.prototype.reinitCheckboxList = function multiValuesControl$reinitCheckboxList() {


    // Get the field object.
    var _field = this.m_workItemEditor.getField(this.m_fieldName);


    if (_field) {
        // Determine whether the field is readonly/enabled.
        var _fieldReadOnly = !_field.IsEditable || _field.IsComputed;
        var _controlReadOnly = this.m_readOnly || _fieldReadOnly;
        var _enabled = !(this.m_workItemEditor.ReadOnly || _controlReadOnly);
        var _required = _enabled ? _field.IsRequired : false;


        for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
            if (_enabled == true) {
                this.m_options[i].removeAttribute(&quot;disabled&quot;);
            }
            else {
                this.m_options[i].setAttribute(&quot;disabled&quot;, &quot;disabled&quot;);
            }


            if (_field.Value != null && _field.Value.indexOf(this.m_options[i].parentElement.title &#43; &quot;;&quot;) &gt;= 0) {
                this.m_options[i].checked = true;
            }
            else {
                this.m_options[i].checked = false;
            }
        }
    }
}

</pre>
<pre id="codePreview" class="js">
// This method will be called by m_workItemEditor.
multiValuesControl.prototype.init = function multiValuesControl$init() {
    this.m_workItemEditor = $getObject(this.m_workItemEditorObjectId);


    // Attach a event handler to the editorReady event of the workItemEditor.
    // The workItemEditor has other event like 
    //     1. synchronize.
    //     2. serverRoundtripStart.
    //     3. fieldChange.
    //     4. updateField-complete.
    //     5. beforeSave.
    //     6. serverRoundtripEnd.
    //     7. add-link.
    // You can find all the definition in EditWorkItem.js
    this.m_workItemEditor.attachEvent(&quot;editorReady&quot;, Function.createDelegate(this, this.onEditorReady));


    this.m_control = $getObject(this.m_innerControlId);
    this.m_options = JsUtility.getElementsByTagName(this.m_control, &quot;input&quot;);
    for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
        JsUtility.attachEvent(this.m_options[i], &quot;change&quot;,
            Function.createDelegate(this, this.onCheckboxChanged), true);
    }


}


// Initialize the control.
multiValuesControl.prototype.onEditorReady = function multiValuesControl$onEditorReady() {
    this.reinitCheckboxList();
}


// Initialize the control.
multiValuesControl.prototype.reinitCheckboxList = function multiValuesControl$reinitCheckboxList() {


    // Get the field object.
    var _field = this.m_workItemEditor.getField(this.m_fieldName);


    if (_field) {
        // Determine whether the field is readonly/enabled.
        var _fieldReadOnly = !_field.IsEditable || _field.IsComputed;
        var _controlReadOnly = this.m_readOnly || _fieldReadOnly;
        var _enabled = !(this.m_workItemEditor.ReadOnly || _controlReadOnly);
        var _required = _enabled ? _field.IsRequired : false;


        for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
            if (_enabled == true) {
                this.m_options[i].removeAttribute(&quot;disabled&quot;);
            }
            else {
                this.m_options[i].setAttribute(&quot;disabled&quot;, &quot;disabled&quot;);
            }


            if (_field.Value != null && _field.Value.indexOf(this.m_options[i].parentElement.title &#43; &quot;;&quot;) &gt;= 0) {
                this.m_options[i].checked = true;
            }
            else {
                this.m_options[i].checked = false;
            }
        }
    }
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:90.0pt"><span style=""><span style="">c.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><span style="">Handle the client side event. </span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">js</span>
<pre class="hidden">
// Handle the change event of the checkbox, and then update the field.
multiValuesControl.prototype.onCheckboxChanged = function multiValuesControl$onCheckboxChanged(e) {


    var _value = new Sys.StringBuilder();


    var _completedFieldValue = 1;


    for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
        if (this.m_options[i].checked == true) {
            _value.append(this.m_options[i].parentElement.title &#43; &quot;;&quot;);
        }
        else {
            _completedFieldValue = 0;
        }
    }


    var _isValid = true;
    var _lastError = &quot;&quot;;


    this.m_workItemEditor.updateField(this, this.m_fieldName, _value.toString(), _isValid, _lastError, this.m_controlId);
}

</pre>
<pre id="codePreview" class="js">
// Handle the change event of the checkbox, and then update the field.
multiValuesControl.prototype.onCheckboxChanged = function multiValuesControl$onCheckboxChanged(e) {


    var _value = new Sys.StringBuilder();


    var _completedFieldValue = 1;


    for (i = 0; i &lt; this.m_options.length; i&#43;&#43;) {
        if (this.m_options[i].checked == true) {
            _value.append(this.m_options[i].parentElement.title &#43; &quot;;&quot;);
        }
        else {
            _completedFieldValue = 0;
        }
    }


    var _isValid = true;
    var _lastError = &quot;&quot;;


    this.m_workItemEditor.updateField(this, this.m_fieldName, _value.toString(), _isValid, _lastError, this.m_controlId);
}

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoListParagraphCxSpFirst" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:90.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpMiddle" style="margin-left:54.0pt"><span style=""></span></p>
<p class="MsoListParagraphCxSpLast" style="margin-left:54.0pt"><b style=""><span style=""><span style="">4.<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span></b><b style=""><span style="">Define a new WorkItem Type to use this control</span></b><b style=""><span style="">
</span></b></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span>
</div>
<span class="hidden">xml</span>
<pre class="hidden">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;witd:WITD application=&quot;Work item type editor&quot; version=&quot;1.0&quot; xmlns:witd=&quot;http://schemas.microsoft.com/VisualStudio/2008/workitemtracking/typedef&quot;&gt;
  &lt;WORKITEMTYPE name=&quot;WIT MultiValues&quot;&gt;
    &lt;DESCRIPTION&gt;&lt;/DESCRIPTION&gt;
    &lt;FIELDS&gt;
      ...
    &lt;FIELD name=&quot;MultiValueField&quot; refname=&quot;Demo.MultiValueField&quot; type=&quot;String&quot;&gt;


        &lt;SUGGESTEDVALUES&gt;


            &lt;LISTITEM value=&quot;Option1&quot; /&gt;


            &lt;LISTITEM value=&quot;Option2&quot; /&gt;


            &lt;LISTITEM value=&quot;Option3&quot; /&gt;


            &lt;LISTITEM value=&quot;Option4&quot; /&gt;


            &lt;LISTITEM value=&quot;Option5&quot; /&gt;


        &lt;/SUGGESTEDVALUES&gt;


    &lt;/FIELD&gt;


      ...
    &lt;/FIELDS&gt;
    &lt;WORKFLOW&gt;
      ...
    &lt;/WORKFLOW&gt;
    &lt;FORM&gt;
      ...


          
&lt;Control FieldName=&quot;Demo.MultiValueField&quot; Type=&quot;MultiValuesControl&quot; Label=&quot;&quot; LabelPosition=&quot;Top&quot;&gt;


                 &lt;CustomControlOptions /&gt;


           &lt;/Control&gt;


     ...
    &lt;/FORM&gt;
  &lt;/WORKITEMTYPE&gt;
&lt;/witd:WITD&gt;

</pre>
<pre id="codePreview" class="xml">
&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
&lt;witd:WITD application=&quot;Work item type editor&quot; version=&quot;1.0&quot; xmlns:witd=&quot;http://schemas.microsoft.com/VisualStudio/2008/workitemtracking/typedef&quot;&gt;
  &lt;WORKITEMTYPE name=&quot;WIT MultiValues&quot;&gt;
    &lt;DESCRIPTION&gt;&lt;/DESCRIPTION&gt;
    &lt;FIELDS&gt;
      ...
    &lt;FIELD name=&quot;MultiValueField&quot; refname=&quot;Demo.MultiValueField&quot; type=&quot;String&quot;&gt;


        &lt;SUGGESTEDVALUES&gt;


            &lt;LISTITEM value=&quot;Option1&quot; /&gt;


            &lt;LISTITEM value=&quot;Option2&quot; /&gt;


            &lt;LISTITEM value=&quot;Option3&quot; /&gt;


            &lt;LISTITEM value=&quot;Option4&quot; /&gt;


            &lt;LISTITEM value=&quot;Option5&quot; /&gt;


        &lt;/SUGGESTEDVALUES&gt;


    &lt;/FIELD&gt;


      ...
    &lt;/FIELDS&gt;
    &lt;WORKFLOW&gt;
      ...
    &lt;/WORKFLOW&gt;
    &lt;FORM&gt;
      ...


          
&lt;Control FieldName=&quot;Demo.MultiValueField&quot; Type=&quot;MultiValuesControl&quot; Label=&quot;&quot; LabelPosition=&quot;Top&quot;&gt;


                 &lt;CustomControlOptions /&gt;


           &lt;/Control&gt;


     ...
    &lt;/FORM&gt;
  &lt;/WORKITEMTYPE&gt;
&lt;/witd:WITD&gt;

</pre>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">SUGGESTEDVALUES</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">LISTITEM</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">value</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Option1</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">LISTITEM</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">value</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Option2</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">LISTITEM</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">value</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Option3</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">LISTITEM</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">value</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Option4</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">LISTITEM</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">value</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Option5</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">SUGGESTEDVALUES</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&lt;/</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">FIELD</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue"><span style="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&lt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">Control</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">FieldName</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Demo.MultiValueField</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">Type</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">MultiValuesControl</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">Label</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:red">LabelPosition</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">=</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">Top</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">&quot;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;</span><span class="SpellE"><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">CustomControlOptions</span></span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;/&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<p class="MsoNormal" style="margin-bottom:0cm; margin-bottom:.0001pt; line-height:normal; background:white">
<span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:#A31515">Control</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:blue">&gt;</span><span style="font-size:10.0pt; font-family:&quot;Courier New&quot;; color:black">
</span></p>
<h2>More Information<span style=""> </span></h2>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/bb286959(VS.90).aspx">Work Item Tracking Custom Controls</a>
</span></p>
<p class="MsoNormal"><span style=""><a href="http://msdn.microsoft.com/en-us/library/microsoft.teamfoundation.workitemtracking.controls.iworkitemcontrol(VS.90).aspx"><span class="SpellE">IWorkItemControl</span> Interface</a>
</span></p>
<hr>
<div><a href="http://go.microsoft.com/?linkid=9759640" style="margin-top:3px"><img alt="" src="http://bit.ly/onecodelogo">
</a></div>
