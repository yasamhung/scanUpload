<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selectScanParameter.aspx.cs" Inherits="selectScanParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Language" content="zh-tw" />
    <link rel="stylesheet" id="stylesheet" type="text/css" href="./sample.css" />

    <script type="text/javascript" >
        function size_Select() {
            var size_selectedIndex = document.getElementById('size_select').selectedIndex;
            if (size_selectedIndex != 0) {
                document.getElementById('mixed_size_select').selectedIndex = 0;
            }
        }
        function mixed_size_Select() {
            var mixed_size_value = document.getElementById('mixed_size_select').value;
            if (mixed_size_value == "true") {
                document.getElementById('size_select').selectedIndex = 0;
            }
        }
    </script>
</head>
<body id="theBody" runat="server" style="background-image: url(./images_8/backGround_2_2.png); background-repeat:no-repeat;">>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="user_text1" runat="server" ></asp:Label>
        <asp:Label ID="title_text2" Font-Size="Large" ForeColor="White" runat="server" >(FADS)</asp:Label>

        <img alt="color_mode" id="color_mode" src="./images_8/color_mode.png"  />
        <select lang="zh-tw" id="color_mode_select" runat="server" >
	     <option value="Auto" selected="selected">自動</option>
	     <option value="FullColor">全彩</option>
	     <option value="Grayscale">灰階</option>
         <option value="BlackAndWhite">黑白</option>
	    </select> 
        <img alt="duplex" id="duplex" src="./images_8/duplex.png"  />
        <select lang="zh-tw" id="duplex_select" runat="server" >
	     <option value="Simplex" selected="selected">單面</option>
	     <option value="Duplex">雙面(長邊)</option>
	     <option value="Tumble">雙面(短邊)</option>
	    </select>        
        <img alt="imageMode" id="imageMode" src="./images_8/original_quality.png"  />
        <select lang="zh-tw" id="imageMode_select" runat="server" >
	     <option value="Text" selected="selected">文字</option>
	     <option value="Halftone">照片</option>
	     <option value="Mixed">文字/照片</option>
	    </select> 
        <img alt="darkness" id="darkness" src="./images_8/dark.png"  />
        <select lang="zh-tw" id="darkness_select" runat="server" >
	     <option value="-100">淡(+3)</option>
	     <option value="-60">淡(+2)</option>
	     <option value="-30">淡(+1)</option>
         <option value="0"  selected="selected">正常</option>
         <option value="30">濃(+1)</option>
	     <option value="60">濃(+2)</option>
	     <option value="100">濃(+3)</option>
	    </select> 
        <img alt="resolution" id="resolution" src="./images_8/resolution.png"  />
        <select lang="zh-tw" id="resolution_select" runat="server" >
	     <option value="200x200/dpi" selected="selected">200dpi</option>
	     <option value="300x300/dpi">300dpi</option>
	     <option value="400x400/dpi">400dpi</option>
	     <option value="600x600/dpi">600dpi</option>
	    </select>
        <img alt="size" id="size" src="./images_8/size.png"  />
        <select lang="zh-tw" id="size_select" runat="server" onchange="size_Select()">
	     <option value="Auto" selected="selected">自動偵測</option>
         <option value="ISO-A3SEF">A3(橫式)</option>
	     <option value="ISO-A4SEF">A4(橫式)</option>
	     <option value="ISO-A4LEF">A4(直式)</option>
         <option value="ISO-A5SEF">A5(橫式)</option>
	     <option value="ISO-A5LEF">A5(直式)</option>
         <option value="JIS-B4SEF">B4(橫式)</option>
         <option value="JIS-B5SEF">B5(橫式)</option>
	     <option value="JIS-B5LEF">B5(直式)</option>
         <option value="NA-8.5x11SEF">8.5 x 11&quot;(橫式)</option>
	     <option value="NA-8.5x11LEF">8.5 x 11&quot;(直式)</option>
	    </select>
        <img alt="ratio" id="ratio" src="./images_8/ratio.png"  />
        <select lang="zh-tw" id="ratio_select" runat="server" >
	     <option value="100" selected="selected">100%</option>
	     <option value="70">70% A3-&gt;A4, B4-&gt;B5</option>
         <option value="81">81% B4-&gt;A4, B5-&gt;A5</option>
	     <option value="86">86% A3-&gt;B4, A4-&gt;B5</option>
         <option value="115">115% B4-&gt;A3, B5-&gt;A4</option>
	     <option value="122">122% A4-&gt;B4, A5-&gt;B5</option>
         <option value="141">141% A4-&gt;A3, B5-&gt;B4</option>
	    </select>
        <img alt="mixed_size" id="mixed_size" src="./images_8/mixed_size_2.png"  />
        <select lang="zh-tw" id="mixed_size_select" runat="server" onchange="mixed_size_Select()">
	     <option value="false" selected="selected">無</option>
	     <option value="true">有</option>
	    </select>

        <asp:ImageButton ID="back_button_1" runat="server" draggable="false"
            ImageUrl="./images_8/buttonup2.png" onclick="back_button_1_Click" Visible="False"   />
	    <asp:ImageButton ID="start_scan_button_1" runat="server" draggable="false"
            ImageUrl="./images_8/startscan.png" onclick="start_scan_button_1_Click"   />
        <img alt="xerox_logo" id="xerox_logo" src="./images_8/ctb_logo.png" draggable="false" /> 
    </div>
    
    </form>
</body>
</html>
