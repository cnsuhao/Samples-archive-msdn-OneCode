/// <reference name="MicrosoftAjax.js" />
/// <reference path="Utils.js" />
/// <reference path="EditWorkItem.js" />


// The constructor of the multiValuesControl.

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
    this.m_workItemEditor.attachEvent("editorReady", Function.createDelegate(this, this.onEditorReady));

    this.m_control = $getObject(this.m_innerControlId);
    this.m_options = JsUtility.getElementsByTagName(this.m_control, "input");
    for (i = 0; i < this.m_options.length; i++) {
        JsUtility.attachEvent(this.m_options[i], "change",
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

        for (i = 0; i < this.m_options.length; i++) {
            if (_enabled == true) {
                this.m_options[i].removeAttribute("disabled");
            }
            else {
                this.m_options[i].setAttribute("disabled", "disabled");
            }

            if (_field.Value != null && _field.Value.indexOf(this.m_options[i].parentElement.title + ";") >= 0) {
                this.m_options[i].checked = true;
            }
            else {
                this.m_options[i].checked = false;
            }
        }
    }
}

// Handle the change event of the checkbox, and then update the field.
multiValuesControl.prototype.onCheckboxChanged = function multiValuesControl$onCheckboxChanged(e) {

    var _value = new Sys.StringBuilder();

    var _completedFieldValue = 1;

    for (i = 0; i < this.m_options.length; i++) {
        if (this.m_options[i].checked == true) {
            _value.append(this.m_options[i].parentElement.title + ";");
        }
        else {
            _completedFieldValue = 0;
        }
    }

    var _isValid = true;
    var _lastError = "";

    this.m_workItemEditor.updateField(this, this.m_fieldName, _value.toString(), _isValid, _lastError, this.m_controlId);
}