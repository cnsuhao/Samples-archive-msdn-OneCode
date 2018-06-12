using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace CSASPNETCompressFilesIntoSingleZip
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        ///  Deleting the temp zip file. This will work only with IIS, so make sure you have IIS in the machine that is used to run this sample. i.e. use local IIS Web Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {              
            try
            {
                //Deleting once the zip file is flushed to the client.
                if (HttpContext.Current.Response.Headers["TempfileName"] != null)
                {
                    string tempZipFilePath = HttpContext.Current.Response.Headers["TempfileName"];
                    File.Delete(tempZipFilePath);
                    HttpContext.Current.Response.Headers.Remove("TempfileName");
                }
            }
            catch
            {
                // Add aditional code to log the deletion failure
            }           
        }       
      
    }
}