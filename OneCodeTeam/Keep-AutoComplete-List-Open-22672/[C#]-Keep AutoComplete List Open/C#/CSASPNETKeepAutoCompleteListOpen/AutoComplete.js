function hideOptionList() {
    $find('ACE').hidePopup();
    $get('tbMovies').value = "";
}

function resetListBox() {
    var list = $get("ListBox1");
    list.options.length = 0;
}

//These two functions are copied from the original design code of the AutoCompleteBehavior.  
//We modify them to insert the selected value and keep the CompletionList shown.  

//Note that we need to place the script tag under the ScriptManager and the AutoCompleteExtender  
// to ensure we can use the AjaxControlToolkit namespace.  

Sys.Extended.UI.AutoCompleteBehavior.prototype._setText = function(item) {
    //Rewrite the _setText function to insert the newText into the ListBox.  
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
    var list = $get("ListBox1");
    list.options.add(new Option(newText, newText));
    //********End****************************************//  

    $common.tryFireEvent(element, "change");

    this.raiseItemSelected(new Sys.Extended.UI.AutoCompleteItemEventArgs(item, text, item ? item._value : null));

    this._currentPrefix = this._currentCompletionWord();
    this._hideCompletionList();
};
Sys.Extended.UI.AutoCompleteBehavior.prototype._hideCompletionList = function() {
    //Rewrite the _hideCompletionList function to keep the list shown all the time  
    var eventArgs = new Sys.CancelEventArgs();
    this.raiseHiding(eventArgs);
    if (eventArgs.get_cancel()) {
        return;
    }
    //The hidePopup function is to close the CompletionList, so we need to   
    //  comment this line to ensure the CompletionList is visible.  
    //this.hidePopup();  
};  