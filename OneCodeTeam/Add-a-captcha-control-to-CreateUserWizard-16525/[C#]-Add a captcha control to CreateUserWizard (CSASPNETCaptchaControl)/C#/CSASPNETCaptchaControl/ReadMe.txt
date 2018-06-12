========================================================================
                CSASPNETCaptchaControl Overview
========================================================================

/////////////////////////////////////////////////////////////////////////////
Use:

The project illustrates how to add a captcha control to the CreateUserWizard
control. As we know, we can use customize the contents of the CreateUserWizard
control using the CreateUserWizardStep and CompleteWizardStep template.

/////////////////////////////////////////////////////////////////////////////
Demo the Sample. 

Please follow these demonstration steps below.

Step 1: Open the CSASPNETCaptchaControl.sln.

Step 2: Expand the CSASPNETCaptchaControl web application and press 
        Ctrl + F5 to show the Default.aspx.

Step 3: You will see a CreateUserWizard control on the page, please input your 
        basic information in specifically TextBox controls.

Step 4: Perhaps you have notice there is a captcha control in CreateUserWizard 
        control, please input the string variable as you see it. After sign in
		success, you can find your information shown on page.

Step 5: Validation finished.

/////////////////////////////////////////////////////////////////////////////
Code Logical:

Step 1. Create a C# "ASP.NET Empty Web Application" in Visual Studio 2010 or
        Visual Web Developer 2010. Name it as "CSASPNETCaptchaControl".

Step 2. Add a web form in the root directory of web application, and name it
        as "Default.aspx". This page use to show CreateUserWizard control and 
		captcha control. 

Step 3. This sample will use a Default database, "ASPNETDB.MDF". It requires 
        developers install SqlServer.
		If you have not set up this database, please refer to this links for 
		downloading it(Express):
		http://www.microsoft.com/downloads/en/details.aspx?FamilyID=8b3695d9-415e-41f0-a079-25ab0412424b&displaylang=en 

Step 4. Add a CreateWizardUser control in Default.aspx page, we can specifying 
        our own custom user interface(UI) that includes captcha control to gather
		information of new users, the HTML code as shown below: 
		[code]
        <asp:CreateUserWizard ID="CreateUserWizardName" runat="server"  
            onnextbuttonclick="CreateUserWizardName_NextButtonClick" 
            oncreatinguser="CreateUserWizardName_CreatingUser"> 
            <WizardSteps> 
                <asp:CreateUserWizardStep ID="CreateUserWizardNameStep" runat="server"> 
                    <ContentTemplate> 
                        <table border="0" style="font-size: 100%; font-family: Verdana"> 
                            <tr> 
                                <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d"> 
                                    Sign Up for Your New Account 
                                </td> 
                            </tr>                
                            <tr> 
                                <td align="right" class="style2">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"> 
                        User Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"> 
                        Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword"> 
                        Confirm Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmPassword" 
                                        ErrorMessage="Confirm Password is required." 
                                        ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email"> 
                        E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                        ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question"> 
                        Security Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                        ControlToValidate="Question" ErrorMessage="Security question is required." 
                                        ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer"> 
                        Security Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                        ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                        ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr> 
                                <td align="right" class="style2"> 
                                    <asp:Label ID="lblCaptcha" runat="server" AssociatedControlID="codeNumberTextBox"> 
                        Code Number:</asp:Label> 
                                </td> 
                                <td> 
                                    <asp:TextBox ID="codeNumberTextBox" runat="server"></asp:TextBox>
                                    
                                    <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/captcha.bmp"  />
                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" 
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator> 
                                </td> 
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                        Display="Dynamic" 
                                        ErrorMessage="The Password and Confirmation Password must match." 
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table> 
                    </ContentTemplate> 
                </asp:CreateUserWizardStep> 
                <asp:CompleteWizardStep ID="CreateUserWizardComplete" runat="server">
                <ContentTemplate>
                <center><asp:Label ID="lbTitle" runat="server" Text="Personal Information"></asp:Label></center><br />
                User Name:  <asp:Label ID="lbUserName" runat="server"></asp:Label><br />
                E-mail:  <asp:Label ID="lbEmail" runat="server"></asp:Label><br />
                Question:  <asp:Label ID="lbQuestion" runat="server"></asp:Label><br />
                </ContentTemplate>
                </asp:CompleteWizardStep> 
            </WizardSteps> 
        </asp:CreateUserWizard> 
		[/code]

Step 5. We will store captcha code with a session variable and check it as user's 
        input code in Page_Load event:
		[code]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string captchaCode = GenerateRandomCode();
                this.Session["CaptchaImageText"] = captchaCode;
            }
        }
		[/code]

		We can also generate code number randomly, in this sample, we create
		GenerateRandomCode method in Default.aspx.cs page.
		[code]
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
		[/code]

Step 6. Build the application and you can debug it.
/////////////////////////////////////////////////////////////////////////////
References:

MSDN: CreateUserWizard Class
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.createuserwizard.aspx

MSDN: CreateUserWizardStep Class 
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.createuserwizardstep.aspx

MSDN: CompleteWizardStep Class
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.completewizardstep.aspx

MSDN: RequiredFieldValidator Class
http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.requiredfieldvalidator.aspx
/////////////////////////////////////////////////////////////////////////////