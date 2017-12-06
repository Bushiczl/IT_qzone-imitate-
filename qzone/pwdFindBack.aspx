<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pwdFindBack.aspx.cs" Inherits="pwdFindBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtUsername" runat="server" MaxLength="30"></asp:TextBox>
    <asp:Button ID="btnFind" runat="server" Text="找回密码" OnClick="btnFind_Click" />
    <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
