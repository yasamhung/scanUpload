<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Language" content="zh-tw" />
    <link rel="stylesheet" type="text/css" href="./sample.css" />
    <script type="text/javascript" >

        //function level_01_click() {
        //    //alert('test...');
        //    document.getElementById('level_01_select').click();
        //}
        //function level_02_click() {
        //    //alert('test_2...');
        //    document.getElementById('level_02_select').click();
        //}
        //function level_03_click() {
        //    //alert('test_3...');
        //    document.getElementById('level_03_select').click();
        //}
        //function level_04_click() {
        //    //alert('test_4...');
        //    document.getElementById('level_04_select').click();
        //}
        //function level_05_click() {
        //    //alert('test_5...');
        //    document.getElementById('level_05_select').click();
        //}
        //function level_06_click() {
        //    //alert('test_6...');
        //    document.getElementById('level_06_select').click();
        //}
    </script> 
</head>
<body style="background-image: url(./images_8/backGround_2_2.png);  background-repeat:no-repeat;">
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="title_text2" Font-Size="Large" ForeColor="White" runat="server" ></asp:Label>


<!--        <img alt="Level_img_0" id="Level_img_0" src="./images_8/Mgm_Level1.png" runat="server" draggable="false"  />
        <select lang="zh-tw" id="Level_Select_0" runat="server"  style="width: 650px; height: 40px;" onchange="level_01_click()">
	    </select>     -->
        <img alt="Level_img_1" id="Level_img_1" src="./images_8/department.png" runat="server" draggable="false" />
        <select lang="zh-tw" id="Level_Select_1" runat="server" style="width: 650px; height: 40px;" >
	    </select>    
        <img alt="Level_img_2" id="Level_img_2" src="./images_8/docCat.png" runat="server" draggable="false"  />
        <select lang="zh-tw" id="Level_Select_2" runat="server" style="width: 650px; height: 40px;" >
	    </select>
        <img alt="Level_img_3" id="Level_img_3" src="./images_8/year.png" runat="server"  draggable="false" />
        <select lang="zh-tw" id="Level_Select_3" runat="server"  style="width: 150px; height: 40px;"  >
	    </select> 
        <img alt="Level_img_4" id="Level_img_4" src="./images_8/month.png"  runat="server" draggable="false" />
        <select lang="zh-tw" id="Level_Select_4" runat="server"  style="width: 150px; height: 40px;" >
	    </select> 
        <img alt="Level_img_5" id="Level_img_5" src="./images_8/splitPage.jpg"  runat="server" draggable="false" />
        <select lang="zh-tw" id="Level_Select_5" runat="server"  style="width: 650px; height: 40px;">
	        <option value="0">不拆檔(預設)</option>
            <option value="1">每一頁拆檔</option>
            <option value="2">每二頁拆檔</option>
            <option value="3">每三頁拆檔</option>
            <option value="4">每四頁拆檔</option>
            <option value="5">每五頁拆檔</option>
        </select>
        <img alt="Level_filename" id="Level_filename" src="./images_8/docName_2.png"  runat="server"  draggable="false"  />
        <asp:TextBox ID="TextBox_filename" style="width: 635px; height: 30px; font-size:larger" runat="server"></asp:TextBox>    
        <div><span id="errorMsg_Level_3"  style="color:Red; width: 348px;" runat="server"></span></div>
<!--        <asp:ImageButton ID="back_button_1" runat="server" draggable="false"
            ImageUrl="./images_8/buttonup2.png" OnClick="back_button_1_Click"     />     -->
        <asp:ImageButton  id="start_scan_button_1" ImageUrl="./images_8/next_step.png"  draggable="false" 
            runat="server" OnClick="start_scan_button_1_Click"      /> 
        <img alt="xerox_logo" id="xerox_logo" src="./images_8/xeroxlogo_130.png" draggable="false"  />
    </div>
    </form>
</body>
</html>
