<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater ID="rpt" runat="server" OnItemCommand="rpt_ItemCommand1">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>书名</th>
                    <th>作者名</th>
                    <th>类别</th>
                    <th>出版社</th>
                    <th>简介</th>
                    <th>可借数量</th>
                    <th>馆藏数量</th>
                    <th>借阅</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
                <tr>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><br />
    </div>
    </form>
</body>
</html>
