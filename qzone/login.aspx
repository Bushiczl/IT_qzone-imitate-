<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    登录<br />
    用户名：<asp:TextBox ID="txtUsername" runat="server" MaxLength="30"></asp:TextBox><br />
    密码：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox><br />
    输入验证码：<asp:TextBox ID="txtIdentifying" runat="server"></asp:TextBox>
    <img alt="看不清，换一张" title="看不清，换一张" src="/identifying/Identifying.aspx" style="cursor:pointer" onclick="this.src=this.src+'?r='+Math.random()" /><br />
    <asp:CheckBox ID="cbxRememberPassword" runat="server" />记住密码<asp:CheckBox ID="cbxAutoLogin" runat="server" />自动登录<br />
    <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
    <asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" />
    <asp:Button ID="btnPwdFindBack" runat="server" Text="忘记密码" OnClick="btnPwdFindBack_Click" />
    </div>
    </form>
</body>
</html>
