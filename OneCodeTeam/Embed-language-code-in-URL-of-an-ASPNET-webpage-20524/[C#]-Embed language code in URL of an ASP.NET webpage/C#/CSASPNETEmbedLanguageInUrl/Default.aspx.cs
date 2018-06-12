using System;

namespace CSASPNETEmbedLanguageInUrl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("en-us/ShowMe.aspx");
        }
    }
}