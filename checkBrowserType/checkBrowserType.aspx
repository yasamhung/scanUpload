<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="checkBrowserType.aspx.cs" Inherits="checkBrowserType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Language" content="zh-tw" />
    <link rel="stylesheet" type="text/css" href="../UI.css" />

	<script type="text/javascript" src="./DependLib/BrowserLib.js" charset="UTF-8"></script>
    <script type="text/javascript" >
        function Exit() {
            //alert(BrowserLib.browser);
            BrowserExt.SetScreenChange("menuto:allservice");
        }

        function checkMFDbrowserType() {
            //alert(BrowserLib.browser);
            //BrowserExt.SetScreenChange("menuto:allservice");       // Qt  Ant
            //document.getElementById("browserType").value = BrowserLib.browser;
            document.getElementById("browserType").value = BrowserLib.screen;
            document.getElementById("btnA").click();
        }
    </script>
</head>
<body style="background-image: url(./images/backGround.png);  background-repeat:no-repeat;">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnA" runat="server" BackColor="White" BorderColor="White" BorderWidth="0px"
                ForeColor="White"  OnClick="btnA_Click"  />
        <asp:Label ID="Label1" runat="server" ></asp:Label><br />
        <input type="hidden" id="browserType"  runat="server" />
    </div>
        <script type="text/javascript">
                //setTimeout("Exit()", 3000 );
                checkMFDbrowserType();    
        </script>
    </form>
</body>
</html>
