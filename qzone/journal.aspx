<%@ Page Language="C#" AutoEventWireup="true" CodeFile="journal.aspx.cs" Inherits="journal" MasterPageFile="~/MasterPage.master" ValidateRequest="false" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
        <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.min.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/ueditor/lang/zh-cn/zh-cn.js"></script>
        <link href="/ueditor/themes/default/ueditor.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <%--日志列表--%>
        <h1>日志</h1><br />
        <asp:Panel ID="pnlShow" runat="server">
            <asp:Button ID="btnShowNewJournal" runat="server" Text="新日志" OnClick="btnShowNewJournal_Click" Visible="false" /><br />
            <asp:Repeater ID="rptJournals" runat="server" OnItemCommand="rptJournals_ItemCommand">
                <ItemTemplate>
                    <td>
                        <asp:LinkButton runat="server" CommandName="btnJournal" Text='<%# Eval("title") %>' CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="btnDelete" Text="删除" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
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

            <textarea id="txteditor" name="editor" runat="server">
            </textarea>
            <script type="text/javascript">
                var editor = UE.ui.Editor();
                editor.render("<%=txteditor.ClientID%>");
　　　　    </script>

            <asp:Button ID="btnNewSubmit" runat="server" Text="保存" OnClick="btnNewSubmit_Click" />
            <asp:Button ID="btnNewBack" runat="server" Text="返回" OnClick="btnNewBack_Click" />
        </asp:Panel>

        <%--显示单个日志--%>
        <asp:Panel ID="pnlReadJournal" runat="server" Visible="false">

            <asp:Panel ID="pnlReadShow" runat="server">
                <h1><asp:Label ID="lblJournalTitle" runat="server"></asp:Label></h1>
                <asp:Label ID="lblJournalContent" runat="server"></asp:Label><br />
                <asp:Button ID="btnReadChangeJournal" runat="server" Text="修改" OnClick="btnReadChangeJournal_Click" Visible="false" />
                <asp:Button ID="btnReadBack" runat="server" Text="返回" OnClick="btnReadBack_Click" />

                <asp:Button ID="btnReply" runat="server" Text="回复" OnClick="btnReply_Click" /><br />
                <asp:Panel ID="pnlReplyEdit" runat="server" Visible="false">
                    <asp:TextBox ID="txtReplyEdit" runat="server"></asp:TextBox>
                    <asp:Button ID="btnReplySubmit" runat="server" Text="发送" OnClick="btnReplySubmit_Click" />
                    <asp:Button ID="btnReplyBack" runat="server" Text="返回" OnClick="btnReplyBack_Click" />
                </asp:Panel><br />
                评论：
                <asp:Repeater ID="rptReply" runat="server" OnItemCommand="rptReply_ItemCommand">
                    <ItemTemplate>
                        <%# Eval("reply") %>
                        <asp:LinkButton ID="btnReplyDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="delete" Text="删除" Visible="false"></asp:LinkButton><br />
                    </ItemTemplate>
                </asp:Repeater>

            </asp:Panel>
            <%--修改日志--%>
            <asp:Panel ID="pnlReadChange" runat="server" Visible="false">
                <asp:TextBox ID="txtChangeTitle" runat="server" MaxLength="30"></asp:TextBox><br />
                
                <textarea id="txtChangeEditor" name="editor2" runat="server">
                </textarea>
                <script type="text/javascript">
                    var editor = UE.ui.Editor();
                    editor.render("<%=txtChangeEditor.ClientID%>");
　　　　        </script>

                <asp:Button ID="btnChangeSave" runat="server" Text="保存" OnClick="btnChangeSave_Click" />
                <asp:Button ID="btnChangeBack" runat="server" Text="返回" OnClick="btnChangeBack_Click" />
            </asp:Panel>

        </asp:Panel>
    </body>
        
    </html>
</asp:Content>

    