<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePwd.aspx.cs" Inherits="changePwd" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        原密码：<asp:TextBox ID="txtPwdOld" runat="server" MaxLength="40"></asp:TextBox><br />
        新密码：<asp:TextBox ID="txtPwdNew" runat="server" MaxLength="40"></asp:TextBox><br />
        确认新密码：<asp:TextBox ID="txtPwdConfirm" runat="server" MaxLength="40"></asp:TextBox><br />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
    </body>
    </html>
</asp:Content>