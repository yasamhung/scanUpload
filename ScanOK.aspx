<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScanOK.aspx.cs" Inherits="ScanOK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ScanOK</title>
    <meta http-equiv="Content-Language" content="zh-tw" />

<%--    <script type="text/javascript" src="./ToolsLib/XML.js" charset="UTF-8"></script>
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
	<script type="text/javascript" src="./ContentsLib/ContentsLib.js" charset="UTF-8"></script>--%>

    <link rel="stylesheet" id="stylesheet" type="text/css" href="./sample.css" />
    
    <script type="text/javascript" >
        function end_function() {
            ContentsLib.init("localhost");	
            // 認証コンテンツ終了.
            //BrowserExt.SetScreenChange("closePopup:AUTH");    // gary change
            //BrowserExt.SetScreenChange("menuto:copy");
            BrowserExt.SetScreenChange("menuto:allservice");
        }
    </script>      
</head>
<body id="theBody" runat="server" style="background-image: url(./images_8/backGround_2_2.png); background-repeat:no-repeat;">
    <form id="form1" runat="server">
    <div>

        <img alt="xerox_logo" id="xerox_logo" src="./images_8/xeroxlogo_130.png"  />   
 <!--       <asp:ImageButton ID="scan_button" runat="server" ImageUrl="./images_2/Scan.png"  />      -->
<!--        <asp:ImageButton ID="next_scan_new" runat="server" ImageUrl="./images/next_scan_ORIX.png"   />   --> 
        <asp:ImageButton ID="home" runat="server" draggable="false"  ImageUrl="./images_8/back_home_ORIX.png" OnClick="home_scan_Click"  />  
<!--        <asp:ImageButton ID="next" runat="server" draggable="false" ImageUrl="./images_8/next_scan_ORIX.png" OnClick="next_scan_Click" />   -->
<!--        <img alt="next"  src="./images_8/next_scan_ORIX.png"  id="next_2"  />  -->
    </div> 
    </form>
</body>
</html>
