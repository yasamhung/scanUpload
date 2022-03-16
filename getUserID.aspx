<%@ Page Language="C#" AutoEventWireup="true" CodeFile="getUserID.aspx.cs" Inherits="getUserID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>getAuthUserID</title>
    <meta http-equiv="Content-Language" content="zh-tw" />
    
    <script type="text/javascript" src="./ToolsLib/XML.js" charset="UTF-8"></script>
    <script type="text/javascript" src="./ToolsLib/Base64.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./ToolsLib/LogLib.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./DependLib/BrowserLib.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./DependLib/BrowserExt.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./DependLib/DependFunc.js" charset="UTF-8"></script>
    <script type="text/javascript" src="./WSLib/WebServiceLib.js" charset="UTF-8"></script>  
    
	<script type="text/javascript" src="./SSMILib/SSMILib.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./SSMILib/GetAccountConfig.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./SSMILib/GetUser.js" charset="UTF-8"></script>
    <script type="text/javascript" src="./SSMILib/GetUserInfo.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./WidgetLib/WidgetLib.js" charset="UTF-8"></script>
	<script type="text/javascript" src="./ContentsLib/ContentsLib.js" charset="UTF-8"></script>
	
    <link rel="stylesheet" type="text/css" href="./ORIX.css" />
    
    <script type="text/javascript">

        var gUser = "";
        var gUseInfo = "";

function onLoadBody()
{
    //debugger;
    document.getElementById("welcome_text1").style.visibility = "hidden";
    
    ContentsLib.init("localhost");	
	startWaitingPage();
}
/************************************************************
 * "Please wait" page
 *************************************************************/
function startWaitingPage()
{
	ContentsLib.setListener(onWaitingPageEvent);
	SSMILib.GetAccountConfig();
}
/************************************************************
 * Events for "Please wait" page
 ************************************************************/
function onWaitingPageEvent(eventType)
{
	switch (eventType) {
	case "GetAccountConfig":
		/* Get accounting information */
		if (arguments[1] == true) { 
			/* If user is authenticated, get info on user currently logged in */
			/* Otherwise, go to "Welcome" page */
			accountConfig = arguments[2];
			if (SSMILib.isDeviceAuth(accountConfig) == true) {
				SSMILib.GetUser();
				return;
			} else {
				startWelcomePage();
				return;
			}
		} else {
			/* Error if accountinfo retrieval fails */
			//ContentsLib.writeLog("GetAccountConfig returns false")
			//startAlertPopup("System Error", "Please consult your system administrator.");
                        startWelcomePage(); 
			return;
			
		}
		break;
		
	case "GetUser":
		/* Get user */
		if (arguments[1] == true) {
			/* List of users is retrieved. User currently logged in is always at index 0 */
			/* Go to "Welcome" page */
			var users = arguments[2];
			if (arguments[2][0]) {
			    gUser = users[0];
			    //alert(gUser.UserID);

			    SSMILib.GetUserInfo(gUser.UserID, "", 1, 0);
			}
			//startWelcomePage();
			return;
		} else {
			/* If get user fails, error occurs.*/
			//startAlertPopup("Unauthenticated", "User is not logged in.");
                        startWelcomePage();
                        return;
		}
        break;

    case "GetUserInfo":
        if (arguments[1] == true) {
            var userInfos = arguments[2];
            if (arguments[2][0]) {
                gUseInfo = userInfos[0];
                //alert(gUseInfo.MailAddress);
            }
            startWelcomePage();
            return;
        } else {
            startWelcomePage();
            return;
        }
        
        break;

	case "onhardkeydown":
		/* All hardware keys are invalid */
		//BrowserExt.Beep(1);
		break;
	}
}

/************************************************************
 * "Welcome" page
 *************************************************************/
function startWelcomePage()
{
      var userID = getUserName();
      //alert(userID);
      //if(userID == ""){
          //alert("請檢查機器是否開啟認證模式？");
          //document.getElementById("welcome_text1").style.visibility = "visible";
      //}else{
          var redirectURL = document.getElementById("Hidden1").value;
          //location.href = "http://13.188.84.97/getAuthUserID/scan.aspx?uid=" + userID;
          //location.href = redirectURL + "?uid=" + userID;
          //alert(gUseInfo.MailAddress);
          document.getElementById("Hidden3").value = gUseInfo.MailAddress; 
          document.getElementById("Hidden2").value = userID;
          document.getElementById("btnA").click();
      //}
}

/******************************
 * Retrieiving user name
 *******************************/
function getUserName()
{
	if (gUser == null || gUser == "") {
	    //alert("no user");
		return "";
	} else {
		if (gUser.Index == -1) {
			return "Admin";
		}
		
		      
		if(gUser.RelatedUserID){
		       //alert(gUser.RelatedUserID);
		       return gUser.RelatedUserID;
		   } else if (gUser.UserID) {
		       //alert(gUser.UserID);
		       var uid = gUser.UserID.toString();
		       //alert(uid);
		       return uid;
		   }
            //else if (gUser.DisplayName) {
	         //uid = gUser.DisplayName	
		     // return uid;
		   //}
		   //return uid;
		   //return gUser.DisplayName + '-' + gUser.UserID; // gUser.DisplayName;
		//}   
	}
	return "";
}
</script>

</head>
<body>
    <form id="form1" runat="server">   
    <div>
        <input id="Hidden1" type="hidden" runat="server" />
        <input id="Hidden2" runat="server" type="hidden" />
        <input id="Hidden3" runat="server" type="hidden" />
        <h1 id="welcome_text1">請檢查機器是否開啟認證模式？</h1>
        <p>
            <asp:Button ID="btnA" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px"
                ForeColor="White" Height="22px" OnClick="btnA_Click" Width="48px" />&nbsp;</p>
    </div>
    
    <script type="text/javascript">
             onLoadBody();
    </script>     
    </form>
</body>
</html>
