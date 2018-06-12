/****************************** Module Header ******************************\
* Module Name: Default.aspx.cs
* Project:     CSASPNETCaptchaControl
* Copyright (c) Microsoft Corporation
*
* The project illustrates how to add a captcha control to the CreateUserWizard
* control. As we know, we can use customize the contents of the CreateUserWizard
* control using the CreateUserWizardStep and CompleteWizardStep template.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/



using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;

namespace CSASPNETCaptchaControl
{
    public partial class Default : System.Web.UI.Page
    {
        private bool IsCreateSuc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string captchaCode = GenerateRandomCode();
                this.Session["CaptchaImageText"] = captchaCode;
            }
        }

        // Used to create numbers randomly 
        private string GenerateRandomCode()
        {
            string allChar = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            int codeCount = 6;
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * Convert.ToInt32(DateTime.Now.Ticks.ToString().Substring(0, 7)));
                }
                int t = rand.Next(allCharArray.Length);
                if (temp == t)
                {
                    return GenerateRandomCode();
                }
                temp = t;
                randomCode += allCharArray[t];

                Bitmap bmp = new Bitmap(120, 30);
                Graphics graphics = Graphics.FromImage(bmp);
                Random random = new Random();
                Font font = new Font(FontFamily.GenericSerif, 24, FontStyle.Italic, GraphicsUnit.Pixel);
                graphics.DrawString(randomCode, font, new SolidBrush(Color.Green), new PointF(random.Next(0, 18), random.Next(0, 1)));
                Pen pen = new Pen(new SolidBrush(Color.Blue), 2);
                graphics.DrawLine(pen, new Point(random.Next(0, 119), random.Next(0, 29)), new Point(random.Next(0, 119), random.Next(0, 29)));
                bmp.Save(Server.MapPath("~") + "/captcha.bmp");

                // Get label from CreateUserWizard control.
                Control ctrlControl = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("imgCaptcha");
                System.Web.UI.WebControls.Image imgCaptcha = new System.Web.UI.WebControls.Image();
                imgCaptcha.Visible = true;
            }
            
            // Set value to session variable when the function is called. 
            Session["CaptchaImageText"] = randomCode;
            return randomCode;
        }

        /// <summary>
        /// After create a user account, display user's basic information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUserWizardName_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (IsCreateSuc)
            {
                // Display an informational message
                lbError.Text = "Create a new user success!!";
                // Display your information
                Control ctrlName = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
                string strUserName = ((TextBox)ctrlName).Text;
                Control ctrlPassword = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("Password");
                string strPassword = ((TextBox)ctrlPassword).Text;
                Control ctrlLbUsername = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbUserName");
                Control ctrlLbEmail = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbEmail");
                Control ctrlLbQuestion = CreateUserWizardName.CompleteStep.ContentTemplateContainer.FindControl("lbQuestion");
                MembershipUser userInfo;
                if (Membership.ValidateUser(strUserName, strPassword) == true)
                {
                    userInfo = Membership.GetUser(strUserName);
                    ((Label)ctrlLbUsername).Text = userInfo.UserName;
                    ((Label)ctrlLbQuestion).Text = userInfo.PasswordQuestion;
                    ((Label)ctrlLbEmail).Text = userInfo.Email;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Check the captcha code is matched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUserWizardName_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            Control ctrl = CreateUserWizardName.CreateUserStep.ContentTemplateContainer.FindControl("codeNumberTextBox");
            TextBox txb = (TextBox)ctrl;
            // You can check the user input like this: 
            if (txb.Text == this.Session["CaptchaImageText"].ToString())
            {
                this.IsCreateSuc = true;          
            }
            else
            {
                this.IsCreateSuc = false;
                lbError.Text = "ERROR: Captcha code incorrect, please try again.";
                txb.Text = "";
                e.Cancel = true;
            }
        } 
    }
}