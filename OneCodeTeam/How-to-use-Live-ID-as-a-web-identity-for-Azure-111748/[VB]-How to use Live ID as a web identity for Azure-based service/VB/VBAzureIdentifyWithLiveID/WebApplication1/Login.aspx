<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="WebApplication1.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="Stylesheet" href="/Areas/SSOManagement2/Theme/acs.css" type="text/css" />
    <link href="LoginStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <div id="Main" style="display:none">
	    <div id="Banner" class="Banner"><b>Sign in to 6480</b></div>
	    <div id="SignInContent" class="SignInContent">
		    <div id="LeftArea" class="LeftArea" style="display:none;">
			    <div class="Header">Sign in using your account on:</div>   
			    <div id="IdentityProvidersList"></div><br />
			    <div id="MoreOptions" style="display:none;"><a href="#" onclick="ShowDefaultSigninPage(); return false;">Show more options</a></div>
		    </div> 
		    <div id="Divider" class="Divider" style="display:none;">
			    <div class="DividerLine"></div>
			    <div>Or</div>
			    <div class="DividerLine"></div>
		    </div>
		    <div id="RightArea" class="RightArea" style="display:none;">
			    <div class="Header">Sign in using your e-mail address:</div>
			    <form onsubmit="EmailAddressEntered(); return false;">
			        <input type="text" id="EmailAddressTextBox" />
			        <input type="submit" id="EmailAddressSubmitButton" value="Submit"/><br /><br />
			        <label id="EmailAddressError"></label>
			    </form>
		    </div>
	    </div>
	</div>

    <script type="text/javascript">
        var identityProviders = [];
        var cookieName = "ACSChosenIdentityProvider-20053040";
        var cookieExpiration = 30; // days
        var maxImageWidth = 240;
        var maxImageHeight = 40;

        // This function will be called back by the HRD metadata, and is responsible for displaying the sign-in page.
        function ShowSigninPage(json) {
            var cookieName = GetHRDCookieName();
            var numIdentityProviderButtons = 0;
            var showEmailEntry = false;
            var showMoreOptionsLink = false;
            identityProviders = json;

            if (identityProviders.length == 0) {
                var mainDiv = document.getElementById("SignInContent");
                mainDiv.appendChild(document.createElement("br"));
                mainDiv.appendChild(document.createTextNode("Error: No identity providers are associated with this application."));
            }

            // Loop through the identity providers
            for (var i in identityProviders) {
                // Show all sign-in options if no cookie is set
                if (cookieName === null) {
                    if (identityProviders[i].EmailAddressSuffixes.length > 0) {
                        showEmailEntry = true;
                    }
                    else {
                        // Only show a button if there is no email address configured for this identity provider.
                        CreateIdentityProviderButton(identityProviders[i]);
                        numIdentityProviderButtons++;
                    }
                }
                    // Show only the last selected identity provider if a cookie is set
                else {
                    if (cookieName == identityProviders[i].Name) {
                        CreateIdentityProviderButton(identityProviders[i]);
                        numIdentityProviderButtons++;
                    }
                    else {
                        showMoreOptionsLink = true;
                    }
                }
            }
            //If the user had a cookie but it didn't match any current identity providers, show all sign-in options 
            if (cookieName !== null && numIdentityProviderButtons === 0 && !showEmailEntry) {
                ShowDefaultSigninPage();
            }
                //Othewise, render the sign-in page normally
            else {
                ShowSigninControls(numIdentityProviderButtons, showEmailEntry, showMoreOptionsLink);
            }

            document.getElementById("Main").style.display = "";
        }

        // Resets the sign-in page to its original state before the user logged in and received a cookie.
        function ShowDefaultSigninPage() {
            var numIdentityProviderButtons = 0;
            var showEmailEntry = false;
            document.getElementById("IdentityProvidersList").innerHTML = "";
            for (var i in identityProviders) {
                if (identityProviders[i].EmailAddressSuffixes.length > 0) {
                    showEmailEntry = true;
                }
                else {
                    CreateIdentityProviderButton(identityProviders[i]);
                    numIdentityProviderButtons++;
                }
            }
            ShowSigninControls(numIdentityProviderButtons, showEmailEntry, false);
        }

        //Reveals the sign-in controls on the sign-in page, and ensures they are sized correctly
        function ShowSigninControls(numIdentityProviderButtons, showEmailEntry, showMoreOptionsLink) {

            //Display the identity provider links, and size the page accordingly
            if (numIdentityProviderButtons > 0) {
                document.getElementById("LeftArea").style.display = "";
                if (numIdentityProviderButtons > 4) {
                    var height = 325 + ((numIdentityProviderButtons - 4) * 55);
                    document.getElementById("SignInContent").style.height = height + "px";
                }
            }
            //Show an email entry form if email mappings are configured
            if (showEmailEntry) {
                document.getElementById("RightArea").style.display = "";
                if (numIdentityProviderButtons === 0) {
                    document.getElementById("RightArea").style.left = "0px";
                    document.getElementById("LeftArea").style.display = "none";
                }
            }
            //Show a link to redisplay all sign-in options
            if (showMoreOptionsLink) {
                document.getElementById("MoreOptions").style.display = "";
            }
            else {
                document.getElementById("MoreOptions").style.display = "none";
            }
            //Resize the page if multiple sign-in options are present
            if (numIdentityProviderButtons > 0 && showEmailEntry) {
                document.getElementById("SignInContent").style.width = "720px";
                document.getElementById("Banner").style.width = "720px";
                document.getElementById("Divider").style.display = "";
            }

        }

        //Creates a stylized link to an identity provider's login page
        function CreateIdentityProviderButton(identityProvider) {
            var idpList = document.getElementById("IdentityProvidersList");
            var button = document.createElement("button");
            button.setAttribute("name", identityProvider.Name);
            button.setAttribute("id", identityProvider.LoginUrl);
            button.className = "IdentityProvider";
            button.onclick = IdentityProviderButtonClicked;

            // Display an image if an image URL is present
            if (identityProvider.ImageUrl.length > 0) {

                var img = document.createElement("img");
                img.className = "IdentityProviderImage";
                img.setAttribute("src", identityProvider.ImageUrl);
                img.setAttribute("alt", identityProvider.Name);
                img.setAttribute("border", "0");
                img.onLoad = ResizeImage(img);

                button.appendChild(img);
            }
                // Otherwise, display a text link if no image URL is present
            else if (identityProvider.ImageUrl.length === 0) {
                button.appendChild(document.createTextNode(identityProvider.Name));
            }

            idpList.appendChild(button);
        }

        // Gets the name of the remembered identity provider in the cookie, or null if there isn't one.
        function GetHRDCookieName() {
            var cookie = document.cookie;
            if (cookie.length > 0) {
                var cookieStart = cookie.indexOf(cookieName + "=");
                if (cookieStart >= 0) {
                    cookieStart += cookieName.length + 1;
                    var cookieEnd = cookie.indexOf(";", cookieStart);
                    if (cookieEnd == -1) {
                        cookieEnd = cookie.length;
                    }
                    return unescape(cookie.substring(cookieStart, cookieEnd));
                }
            }
            return null;
        }

        // Sets a cookie with a given name
        function SetCookie(name) {
            var expiration = new Date();
            expiration.setDate(expiration.getDate() + cookieExpiration);
            var secure = "";

            // If your application uses SSL, consider setting secure=";secure".

            document.cookie = cookieName + "=" + escape(name) + ";expires=" + expiration.toUTCString() + secure;
        }

        // Sets a cookie to remember the chosen identity provider and navigates to it.
        function IdentityProviderButtonClicked() {
            SetCookie(this.getAttribute("name"));
            window.location = this.getAttribute("id");
            return false;
        }

        function SetEmailError(string) {
            var EmailAddressError = document.getElementById("EmailAddressError");
            if (EmailAddressError.hasChildNodes()) {
                EmailAddressError.replaceChild(document.createTextNode(string), EmailAddressError.firstChild);
            }
            else {
                EmailAddressError.appendChild(document.createTextNode(string));
            }
        }

        function EmailAddressEntered() {
            var enteredEmail = document.getElementById("EmailAddressTextBox").value;
            var identityProvider = null;
            if (enteredEmail.length === 0) {
                SetEmailError("Please enter an e-mail address.");
                return;
            }

            if (enteredEmail.indexOf("@") <= 0) {
                SetEmailError("Please enter a valid e-mail address.");
                return;
            }

            var enteredDomain = enteredEmail.split("@")[1].toLowerCase();
            for (var i in identityProviders) {
                for (var j in identityProviders[i].EmailAddressSuffixes) {
                    if (enteredDomain == identityProviders[i].EmailAddressSuffixes[j].toLowerCase()) {
                        identityProvider = identityProviders[i];
                    }
                }
            }

            if (identityProvider === null) {
                SetEmailError("" + "'" + enteredDomain + "'" + " is not a recognized e-mail domain.");
                return;
            }

            // If we have gotten this far the e-mail address suffix was recognized. Write a cookie and redirect to the login URL.
            SetCookie(identityProvider.Name);
            window.location = identityProvider.LoginUrl;
        }

        // If the image is larger than the button, scale maintaining aspect ratio.
        function ResizeImage(img) {
            if (img.height > maxImageHeight || img.width > maxImageWidth) {
                var resizeRatio = 1;
                if (img.width / img.height > maxImageWidth / maxImageHeight) {
                    // Aspect ratio wider than the button
                    resizeRatio = maxImageWidth / img.width;
                }
                else {
                    // Aspect ratio taller than or equal to the button
                    resizeRatio = maxImageHeight / img.height;
                }

                img.setAttribute("height", img.height * resizeRatio);
                img.setAttribute("width", img.width * resizeRatio);
            }
        }

    </script>
    <!-- This script gets the HRD metadata in JSON and calls the callback function which renders the links -->
    <!--TODO:Replace below URL which ends before ShowSigninPage 
        http://msdn.microsoft.com/en-us/library/windowsazure/gg185963.aspx
    -->
    <%--Example:
    <script src="https://Myappfabric.accesscontrol.windows.net:443/v2/metadata/IdentityProviders.js?protocol=wsfederation&realm=http%3a%2f%2flocalhost%3a64801%2f&reply_to=http%3a%2f%2flocalhost%3a64801%2fcallback.aspx&context=&request_id=&version=1.0&callback=ShowSigninPage" type="text/javascript"></script>--%>
     <script src="[URL]ShowSigninPage" type="text/javascript"></script>
            <br />
            <div class="footer">
                <a id="HyperLink1" href='http://go.microsoft.com/fwlink/?LinkID=131004' target="_blank">Privacy</a>
            </div>   
</body>
</html>
