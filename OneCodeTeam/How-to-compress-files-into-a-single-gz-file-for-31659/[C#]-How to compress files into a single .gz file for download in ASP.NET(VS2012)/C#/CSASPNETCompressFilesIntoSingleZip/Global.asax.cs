using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CSASPNETCompressFilesIntoSingleZip
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_EndRequest(object sender, EventArgs e)
        {
           
            try
            {
                //Deleting once the zip file is flushed to the client.
                if (HttpContext.Current.Response.Headers["TempfileName"] != null)
                {
                    string tempZipFilePath = HttpContext.Current.Response.Headers["TempfileName"];
                    File.Delete(tempZipFilePath);
                }
            }
            catch
            {
                // Add aditional code to log the deletion failure
            }
            finally
            {
                if(HttpContext.Current.Response.Headers["TempfileName"] != null)
                    HttpContext.Current.Response.Headers.Remove("TempfileName");     
            }
        }
    }
}