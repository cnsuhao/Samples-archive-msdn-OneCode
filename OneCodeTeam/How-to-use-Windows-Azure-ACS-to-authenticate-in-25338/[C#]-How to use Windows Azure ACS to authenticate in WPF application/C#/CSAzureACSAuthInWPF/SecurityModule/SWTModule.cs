using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecurityModule
{
    class SWTModule : IHttpModule
    {
        //USE CONFIGURATION FILE, WEB.CONFIG, TO MANAGE THIS DATA
        string serviceNamespace = "your namespace"; //Access Control Namespaces
        string acsHostName = "accesscontrol.windows.net";
        string trustedTokenPolicyKey = "your signing key";//You generated this key in read me Running the Sample step 1.7.
        string trustedAudience = "your realm";//In this example it should be http://localhost:12526/RESTUserService.svc


        void IHttpModule.Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            // HANDLE SWT TOKEN VALIDATION
            // get the authorization header
            string headerValue = HttpContext.Current.Request.Headers.Get("Authorization");

            // Check that a value is there
            if (string.IsNullOrEmpty(headerValue))
            {
                throw new ApplicationException("unauthorized");
            }

            // Check that it starts with 'WRAP'
            if (!headerValue.StartsWith("WRAP "))
            {
                throw new ApplicationException("unauthorized");
            }

            string[] nameValuePair = headerValue.Substring("WRAP ".Length).Split(new char[] { '=' }, 2);

            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != "access_token" ||
                !nameValuePair[1].StartsWith("\"") ||
                !nameValuePair[1].EndsWith("\""))
            {
                throw new ApplicationException("unauthorized");
            }

            // Trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);

            // Create a token validator
            TokenValidator validator = new TokenValidator(
                this.acsHostName,
                this.serviceNamespace,
                this.trustedAudience,
                this.trustedTokenPolicyKey);

            // Validate the token
            if (!validator.Validate(token))
            {
                throw new ApplicationException("unauthorized");
            }

        }
    }
}

