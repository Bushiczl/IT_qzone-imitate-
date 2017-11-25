<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personal.aspx.cs" Inherits="personal" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <h1>基本资料</h1><br />
        <asp:Panel ID="pnlShow" runat="server">
            昵称：<asp:Label ID="lblNickName" runat="server"></asp:Label><br />
            性别：<asp:Label ID="lblSex" runat="server"></asp:Label><br />
            生日：<asp:Label ID="lblBirthday" runat="server"></asp:Label><br />
            血型：<asp:Label ID="lblBloodType" runat="server"></asp:Label><br />
            职业：<asp:Label ID="lblJob" runat="server"></asp:Label><br />
            简介：<asp:TextBox ID="txtIntroduction_Show" ReadOnly="true" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btnChange" runat="server" Text="修改" OnClick="btnChange_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlChange" runat="server" Visible="false">
            昵称：<asp:TextBox ID="txtNickName" runat="server" MaxLength="30"></asp:TextBox><br />
            性别：<asp:RadioButton ID="rdbMan" Text="男" runat="server" GroupName="sex" /><asp:RadioButton ID="rdbWoman" Text="女" runat="server" GroupName="sex" /><br />
            生日：<asp:TextBox ID="txtBirthday" runat="server" MaxLength="10"></asp:TextBox><br />
            血型：<asp:DropDownList ID="ddlBloodType" runat="server">
                    <asp:ListItem Value="0">A型</asp:ListItem>
                    <asp:ListItem Value="1">B型</asp:ListItem>
                    <asp:ListItem Value="2">AB型</asp:ListItem>
                    <asp:ListItem Value="3">O型</asp:ListItem>
                    <asp:ListItem Value="4">其他</asp:ListItem>
               </asp:DropDownList><br />
            职业：<asp:TextBox ID="txtJob" runat="server" MaxLength="10"></asp:TextBox><br />
            简介：<asp:TextBox ID="txtIntroduction" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" text="提交" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnBack" runat="server" Text="取消" OnClick="btnBack_Click" />
        </asp:Panel>
    </body>
    </html>
</asp:Content>
