<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        注册<br />
        用户名：<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        密码：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        确认密码： <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox><br />
        输入邮箱： <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox><br />
        输入验证码：<asp:TextBox ID="txtIdentifying" runat="server"></asp:TextBox>
        <img alt="看不清，换一张" title="看不清，换一张" src="/identifying/Identifying.aspx" style="cursor:pointer" onclick="this.src=this.src+'?r='+Math.random()" /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />
    </div>
    </form>
</body>
</html>
