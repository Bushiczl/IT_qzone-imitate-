<%@ Page Language="C#" AutoEventWireup="true" CodeFile="host.aspx.cs" Inherits="host" MasterPageFile="~/MasterPage.master" %>


<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <asp:Panel ID="pnlShow" runat="server" Visible="false">
            <asp:Button ID="btnNewDynamic" runat="server" Text="写新动态" OnClick="btnNewDynamic_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlEdit" runat="server" Visible="false">
            <asp:TextBox ID="txtEditor" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnBack" runat="server" Text="取消" OnClick="btnBack_Click" />
        </asp:Panel> 

        <asp:Repeater ID="rptRelevantDynamic" runat="server" OnItemCommand="rptRelevantDynamic_ItemCommand">
            <ItemTemplate>
                <%--<%# Eval("dynamicUper") %>--%>的动态<asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("dynamicId") %>' Visible="false"></asp:LinkButton><br />
                <%# Eval("dynamicContent") %><br /><br />
                <asp:LinkButton ID="btnReply" runat="server" Text="回复" CommandName="reply" CommandArgument='<%# Eval("dynamicId") %>'></asp:LinkButton>
                <asp:TextBox ID="txtReplyEdit" runat="server"  Visible="false"></asp:TextBox>
                评论：<br />
                <asp:Repeater ID="rptReply" runat="server" OnItemCommand="rptReply_ItemCommand">
                    <ItemTemplate>
                        <%# Eval("reply") %>
                        <asp:LinkButton ID="btnReplyReply" runat="server" Text="回复此人" CommandName="reply" CommandArgument='<%# Eval("replyId") %>'></asp:LinkButton>
                        <asp:TextBox ID="txtReplyReplyEdit" runat="server"  Visible="false"></asp:TextBox>
                        <asp:LinkButton ID="btnReplyDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("replyId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
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

 <%--'<%# Eval(&quot;isMine&quot;) %>'--%>