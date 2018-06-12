  <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNETCaptchaControl._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
        <asp:Label ID="lbError" runat="server" Font-Bold="True"></asp:Label>
    </div> 
    </form>
</body>
</html>
