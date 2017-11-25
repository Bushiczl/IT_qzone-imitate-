<%@ Page Language="C#" AutoEventWireup="true" CodeFile="journal.aspx.cs" Inherits="journal" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
        <script src="kindeditor/lang/zh_CN.js" type="text/javascript"></script>
        <script src="kindeditor/kindeditor.js" type="text/javascript"></script>
        <script src="kindeditor/plugins/code/prettify.js" type="text/javascript"></script>  
        <script type="text/javascript">
            KindEditor.ready(function (K) {
                var editor = K.create('#content', {
                    //上传管理
                    uploadJson: 'kindeditor/asp.net/upload_json.ashx',
                    //文件管理
                    fileManagerJson: 'kindeditor/asp.net/file_manager_json.ashx',
                    allowFileManager: true,
                    //设置编辑器创建后执行的回调函数
                    afterCreate: function () {
                        var self = this;
                        K.ctrl(document, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                        K.ctrl(self.edit.doc, 13, function () {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                    },
                    //上传文件后执行的回调函数,获取上传图片的路径
                    afterUpload : function(url) {
                            alert(url);
                    },
                    //编辑器高度
                    width: '700px',
                    //编辑器宽度
                    height: '450px;',
                    //配置编辑器的工具栏
                    items: [
                    'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                    'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                    'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                    'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                    'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                    'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                    'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                    'anchor', 'link', 'unlink', '|', 'about'
                    ]
                });
                prettyPrint();
            });
        </script>
        <title></title>
    </head>
    <body>
        <h1>日志</h1><br />
        <asp:Panel ID="pnlShow" runat="server">
            <asp:Button ID="btnShowNewJournal" runat="server" Text="新日志" OnClick="btnShowNewJournal_Click" /><br />
            <asp:Repeater ID="rptJournals" runat="server" OnItemCommand="rptJournals_ItemCommand">
                <ItemTemplate>
                    <td>
                        <asp:LinkButton runat="server" CommandName="journal" Text='<%# Eval("title") %>' CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="delete" Text="删除" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </td>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
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