<%@ Page Language="C#" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="message" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <h1>留言板</h1><br />
        <asp:Button ID="btnNewMessage" runat="server" Text="留言" OnClick="btnNewMessage_Click" />
        <asp:Panel ID="pnlEdit" runat="server" Visible="false">
            <asp:TextBox ID="txtEdit" runat="server" MaxLength="100"></asp:TextBox>
            <asp:Button ID="btnSend" runat="server" Text="发送" OnClick="btnSend_Click" />
            <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />
        </asp:Panel><br />

        <asp:Repeater ID="rptShow" runat="server" OnItemCommand="rptShow_ItemCommand">
            <ItemTemplate>
                <%# Eval("from") %><br />
                <%# Eval("content") %>
                <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("id") %>' Visible="false"></asp:LinkButton> 
                <br />
            </ItemTemplate>
        </asp:Repeater>

        <asp:Button ID="btnPrePage" runat="server" Text="上一页" OnClick="btnPrePage_Click" />
        <asp:Button ID="btnNextPage" runat="server" Text="下一页" OnClick="btnNextPage_Click" />
        <asp:TextBox ID="txtNowPage" runat="server" ></asp:TextBox>/
        <asp:Label ID="lblAllPage" runat="server"></asp:Label>
        <asp:Button ID="btnJump" runat="server" Text="跳转" OnClick="btnJump_Click" />

    </body>
    </html>
</asp:Content>