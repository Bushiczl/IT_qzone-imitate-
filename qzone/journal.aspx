<%@ Page Language="C#" AutoEventWireup="true" CodeFile="journal.aspx.cs" Inherits="journal" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <h1>日志</h1><br />
        <asp:Panel ID="pnlShow" runat="server">
            <asp:Button ID="btnShowNewJournal" runat="server" Text="新日志" OnClick="btnShowNewJournal_Click" /><br />
            <asp:Repeater ID="rptJournals" runat="server" OnItemCommand="rptJournals_ItemCommand">
                <ItemTemplate>
                    <td>
                        <asp:LinkButton runat="server" CommandName="btnJournal" Text='<%# Eval("title") %>' CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="btnDelete" Text="删除" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </td>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:Button ID="btnShowPrePage" runat="server" Text="上一页" OnClick="btnShowPrePage_Click" />
            <asp:Button ID="btnShowNextPage" runat="server" Text="下一页" OnClick="btnShowNextPage_Click" />
            <asp:TextBox ID="txtShowNowPage" runat="server" ></asp:TextBox>/
            <asp:Label ID="lblShowAllPage" runat="server"></asp:Label>
            <asp:Button ID="btnShowJump" runat="server" Text="跳转" OnClick="btnShowJump_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlNewJournal" runat="server" Visible="false">
            <asp:TextBox ID="txtNewJournalTitle" runat="server" MaxLength="30"></asp:TextBox><br />
            <!--这里用来添加富文本编辑器-->

            <asp:Button ID="btnNewSubmit" runat="server" Text="保存" OnClick="btnNewSubmit_Click" />
            <asp:Button ID="btnNewBack" runat="server" Text="返回" OnClick="btnNewBack_Click" />
        </asp:Panel>
    </body>
    </html>
</asp:Content>