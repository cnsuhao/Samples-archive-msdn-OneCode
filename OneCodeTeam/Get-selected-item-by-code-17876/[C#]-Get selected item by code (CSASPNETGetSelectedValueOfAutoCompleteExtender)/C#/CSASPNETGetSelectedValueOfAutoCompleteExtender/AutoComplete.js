function pageLoad() {
    //Register for add_itemSelected event
    $find('ACE').add_itemSelected(OnItemSelected);
}

function OnItemSelected(sender, eventArgs) {
    //Assign value to HiddenField
    var hf = $get("hf1");
    hf.value = (eventArgs.get_value());
    //__doPostBack,Operation selected value in the service side code
    __doPostBack('LinkButton1', '');
}