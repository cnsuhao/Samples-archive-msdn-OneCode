/// <reference name="MicrosoftAjax.js" />
/// <reference path="Utils.js" />
/// <reference path="EditWorkItem.js" />


// The constructor of the dataGridControl.
function dataGridControl(id,
                      workItemEditorObjectId,
                      fieldName,
                      controlId,
                      innerControlId,
                      hiddenFieldControlId,
                      columns,
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

    // The id of the pnlContainer.
    this.m_innerControlId = innerControlId;

    // The client html element of pnlContainer.
    this.m_control = null;

    // The id of hfValue.
    this.m_hiddenFieldControlId = hiddenFieldControlId;

    // The client html element of hfValue.
    this.m_hiddenFieldControl = null;

    // Use RegExp to parse to columns.
    // The attribute should like Column A(FieldA);Column B(FieldB);
    this.m_columns = new Array();

    var re = new RegExp("(.+?)\\((.+?)\\);", "g");
    var arr;
    while ((arr = re.exec(columns)) != null) {
        var col = { display: arr[1], field: arr[2] };
        this.m_columns.push(col);
    }

    this.m_readOnly = readOnly;

    // The table to display the data.
    this.m_table = null;
    this.m_tbody = null;

    // A button to add a new record.
    this.m_btnAdd = null;

    // Use Microsoft.XMLDOM to parse the field value.
    this.m_xmlDoc = null;
}

// This method will be called by m_workItemEditor.
dataGridControl.prototype.init = function dataGridControl$init() {
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
    this.m_hiddenFieldControl = $get(this.m_hiddenFieldControlId);
}

// Initialize the control.
dataGridControl.prototype.onEditorReady = function accountControl$onEditorReady() {
    this.reinitdataGridControl();
}

// Initialize the control.
dataGridControl.prototype.reinitdataGridControl = function dataGridControl$reinitdataGridControl() {

    // Get the field object.
    var field = this.m_workItemEditor.getField(this.m_fieldName);

    if (field) {

        // Determine whether the field is readonly/enabled.
        var fieldReadOnly = !field.IsEditable || field.IsComputed;
        var controlReadOnly = this.m_readOnly || fieldReadOnly;
        var enabled = !(this.m_workItemEditor.ReadOnly || controlReadOnly);
        var required = enabled ? field.IsRequired : false;

        // Delete the existing table.
        if (this.m_table) {
            this.m_control.removeChild(this.m_table);
        }

        // Generate the table. 
        this.drawTable(enabled);

        // Delete the existing button.
        if (this.m_btnAdd) {
            this.m_control.removeChild(this.m_btnAdd);
        }

        if (enabled) {
            this.drawAddButton();
        }
        this.m_xmlDoc = this.parseXml(this.m_hiddenFieldControl.value);

        // Draw the rows using the xmldoc.
        // If enabled == true, then generate the delete buttons.
        this.drawDataRows(enabled);
    }

}

// Draw the table with header row.
dataGridControl.prototype.drawTable = function accountControl$drawTable(enabled) {

    this.m_table = document.createElement("table");
    this.m_tbody = document.createElement("tbody");

    // Create Header Row
    var headerRow = document.createElement("tr");
    for (var i = 0; i < this.m_columns.length; i++) {
        var cell = document.createElement("th");
        cell.innerHTML = this.m_columns[i].display;
        headerRow.appendChild(cell);
    }
    if (enabled == true) {
        var deletecell = document.createElement("th");
        deletecell.innerHTML = "Delete";
        headerRow.appendChild(deletecell);
    }

    this.m_tbody.appendChild(headerRow);
    this.m_table.appendChild(this.m_tbody);

    // Set the style of the table.
    this.m_table.rules = "all";
    this.m_table.style.borderWidth = "1";
    this.m_table.style.borderCollapse = "collapse";

    // Add table to the container.
    this.m_control.appendChild(this.m_table);
}

// Draw datarows in the table.
dataGridControl.prototype.drawDataRows = function accountControl$drawDataRows(enabled) {

    // Get data from the xmldoc.
    var datarows = this.m_xmlDoc.getElementsByTagName("DataTable");

    for (var i = 0; i < datarows.length; i++) {

        // Generate new row.
        var newRow = document.createElement("tr");
        for (var j = 0; j < this.m_columns.length; j++) {
            
            // Get cell value from the datarow.
            var cellNodes = datarows[i].getElementsByTagName(this.m_columns[j].field);
            var cellValue = "";
            if (cellNodes.length > 0) {
                cellValue = cellNodes[0].text;
            }

            // Generate new cell.
            var cell = document.createElement("td");

            // If this control is disabled, then use cell.innerHTML to display the data.
            if (enabled == false) {
                cell.innerHTML = cellValue;
            }

            // Use TextBox to display the data.
            else {
                var textbox = document.createElement("input");
                textbox.type = "text";
                textbox.value = cellValue;
                textbox.dataRow = datarows[i];
                textbox.attributes["title"].value = this.m_columns[j].field;

                // Attach event handler to the change event.
                JsUtility.attachEvent(textbox, "change", Function.createDelegate(this, this.onCellChange));

                cell.appendChild(textbox);
            }
            newRow.appendChild(cell);
        }

        // Draw the delete button.
        if (enabled == true) {
            var deleteCell = document.createElement("td");
            var btnDelete = document.createElement("input");
            btnDelete.type = "button";
            btnDelete.value = "Delete";
            btnDelete.dataRow = datarows[i];
            btnDelete.tableRow = newRow;
            JsUtility.attachEvent(btnDelete, "click", Function.createDelegate(this, this.onbtnDeleteClick));
            deleteCell.appendChild(btnDelete);
            newRow.appendChild(deleteCell);
        }
        this.m_tbody.appendChild(newRow);
    }
}

// Draw the add button.
dataGridControl.prototype.drawAddButton = function accountControl$drawAddButton() {
    this.m_btnAdd = document.createElement("input");
    this.m_btnAdd.type = "button";
    this.m_btnAdd.value = "Add new record";
    JsUtility.attachEvent(this.m_btnAdd, "click", Function.createDelegate(this, this.onbtnAddClick));
    this.m_control.appendChild(this.m_btnAdd);
}

// Create new row if btnAdd is clicked. 
// This method will draw a new row in the table, and update the xmldoc and field.
// The control should be enabled because btnAdd is enabled.
dataGridControl.prototype.onbtnAddClick = function dataGridControl$onbtnAddClick() {
    var dataRow = this.m_xmlDoc.createElement("DataTable");
    var newRow = document.createElement("tr");

    // Draw textboxes to represent the data.
    for (var i = 0; i < this.m_columns.length; i++) {
        var cell = document.createElement("th");
        
        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.dataRow = dataRow;
        textbox.attributes["title"].value = this.m_columns[i].field;
        JsUtility.attachEvent(textbox, "change", Function.createDelegate(this, this.onCellChange));

        cell.appendChild(textbox);
        newRow.appendChild(cell);

        var dataCell = this.m_xmlDoc.createElement(this.m_columns[i].field);
        dataRow.appendChild(dataCell);
    }

    // Draw delete button.
    var deleteCell = document.createElement("td");
    var btnDelete = document.createElement("input");
    btnDelete.type = "button";
    btnDelete.value = "Delete";
    btnDelete.dataRow = dataRow;
    btnDelete.tableRow = newRow;
    JsUtility.attachEvent(btnDelete, "click", Function.createDelegate(this, this.onbtnDeleteClick));

    deleteCell.appendChild(btnDelete);
    newRow.appendChild(deleteCell);

    // Update xmldoc, table and field.
    this.m_xmlDoc.firstChild.appendChild(dataRow);
    this.m_tbody.appendChild(newRow);
    this.UpdateField();
}

// Delete a row in the table, and then update the xmldoc and field.
dataGridControl.prototype.onbtnDeleteClick = function dataGridControl$onbtnDeleteClick() {
    var btnDelete = event.srcElement;
    var dataRow = btnDelete.dataRow;
    var tableRow = btnDelete.tableRow;

    this.m_xmlDoc.firstChild.removeChild(dataRow);
    this.m_tbody.removeChild(tableRow);

    this.UpdateField();
}

// update the xmldoc and field.
dataGridControl.prototype.onCellChange = function accountControl$onCellChange() {
    var textbox = event.srcElement;
    
    // A node in the xmldoc which is displayed in the current table row.
    var datarow = textbox.dataRow;

    var field = textbox.attributes["title"].value;
    var datacells = datarow.getElementsByTagName(field);

    if (datacells.length > 0) {

        var datacell = datacells[0];

        // Update the node in xmldoc.
        datacell.text = textbox.value;

        // Update the field.
        this.UpdateField();
    }

}

// Update the value of the hfValue, and then update the value of current field.
dataGridControl.prototype.UpdateField = function accountControl$UpdateField() {
    this.m_hiddenFieldControl.value = this.m_xmlDoc.xml;
    this.m_workItemEditor.updateField(this, this.m_fieldName, this.m_xmlDoc.xml, true, "", this.m_controlId);
}

// Parse xmldoc from the input data.
// NOTE: this control uses Microsoft.XMLDOM to parse the xml, and it only works for IE.
dataGridControl.prototype.parseXml = function accountControl$parseXml(data) {
    var xml, tmp;
    try {
        xml = new ActiveXObject("Microsoft.XMLDOM");
        xml.async = "false";
        xml.loadXML(data);
    } catch (e) {
        xml = null;
    }

    if (!xml || !xml.documentElement || xml.getElementsByTagName("parsererror").length) {
        return null;
    }
    return xml;
}




