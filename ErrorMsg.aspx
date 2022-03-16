<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorMsg.aspx.cs" Inherits="ErrorMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Language" content="zh-tw" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:Label ID="errorMessage" runat="server" Text="Label"></asp:Label><br /><br />
          <asp:Label ID="admin" runat="server" Text="如錯誤不能排除，請通知系統管理員!"></asp:Label><br /><br />
          <asp:Button ID="errorPage_2" runat="server" Text="回首頁" 
              onclick="errorPage_Click"  />
    </div>
    </form>
</body>
</html>
