<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td style="width: 400px">
                    <input id="InputFile" style="width: 399px" type="file" runat="server" /></td>
                <td style="width: 80px">
                    <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClick="UploadButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:Label ID="Lb_Info" runat="server" ForeColor="Red"></asp:Label></td>                
            </tr>
        </table>    
        <asp:Image ID="imgTest" runat="server" ImageUrl="~/images/636472054282759735.jpg" />
    </div>
    </form>
</body>
</html>
