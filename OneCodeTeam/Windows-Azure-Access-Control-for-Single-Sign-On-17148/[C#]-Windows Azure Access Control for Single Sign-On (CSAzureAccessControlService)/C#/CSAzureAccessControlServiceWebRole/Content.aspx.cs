using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace CSAzureAccessControlServiceWebRole
{
    public partial class Content : System.Web.UI.Page
    {
        public string userName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Thread.CurrentPrincipal.Identity.Name;
        }
    }
}