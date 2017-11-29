<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photo.aspx.cs" Inherits="photo" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" >
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
    </head>
    <body>
        <h1>相册</h1>
        <asp:Repeater ID="rptPhoto" runat="server" OnItemCommand="rptPhoto_ItemCommand">
        <ItemTemplate>
            <asp:Image runat="server" ImageUrl='<%# "~/images/"+Eval("url") %>' />
            <asp:LinkButton runat="server" Text="删除" CommandName="btnDelete" CommandArgument='<%#  Eval("id")%>'></asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>
        <br />

        <asp:Button ID="btnPrePage" runat="server" Text="上一页" OnClick="btnPrePage_Click" />
        <asp:Button ID="btnNextPage" runat="server" Text="下一页" OnClick="btnNextPage_Click" />
        <asp:TextBox ID="txtNowPage" runat="server" ></asp:TextBox>/
        <asp:Label ID="lblAllPage" runat="server"></asp:Label>
        <asp:Button ID="btnJump" runat="server" Text="跳转" OnClick="btnJump_Click" />

        <table>
            <tr>
                <td style="width: 400px">
                    <asp:FileUpload  ID="InputFile" runat="server" /></td>
                <td style="width: 80px">
                    <asp:Button ID="UploadButton" runat="server" Text="上传图片" OnClick="UploadButton_Click" /></td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:Label ID="Lb_Info" runat="server" ForeColor="Red"></asp:Label></td>                
            </tr>
        </table>    

    </body>
    </html>
    
</asp:Content>