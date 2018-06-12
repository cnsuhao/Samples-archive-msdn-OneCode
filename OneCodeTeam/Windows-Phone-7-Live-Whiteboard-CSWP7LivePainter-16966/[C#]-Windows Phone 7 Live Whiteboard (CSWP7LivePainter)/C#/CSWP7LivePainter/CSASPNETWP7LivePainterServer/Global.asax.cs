using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CSASPNETWP7LivePainterServer
{
    public class Global : System.Web.HttpApplication
    {
        Dictionary<Guid, Uri> channelsDict = null;
        void Application_Start(object sender, EventArgs e)
        {
            channelsDict = new Dictionary<Guid, Uri>();
            this.Application.Add("channelsDict", channelsDict);
        }
    }
}
