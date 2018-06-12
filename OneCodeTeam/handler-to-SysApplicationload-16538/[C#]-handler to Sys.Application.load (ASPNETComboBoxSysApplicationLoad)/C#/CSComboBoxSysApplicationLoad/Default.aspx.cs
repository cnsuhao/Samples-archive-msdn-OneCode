using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CSComboBoxSysApplicationLoad
{
    public partial class Default: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComboBox1.Items.Add("Added at code behind");
        }
    }
}