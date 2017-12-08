using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();

    HttpCookie cookie;
    DataTable list;
    object temp;
    int userId,hostId,userLevel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);
        // 空间主人名字
        lblHost.Text = sq.getDataContent(hostId).ToString();

        // 如果不是好友强制跳走
        switch (userLevel)
        {
            case -1:
                Response.Write("<script>alert('未与主人成为好友，无法进入空间');location='host.aspx?id=" + userId + "'</script>");
                return;
            case 0:
                btnLinkMyHost.Visible = false;
                break;
        }

        // 修改密码、显示好友按钮 作为访客时是不需要的
        if (userLevel == 0)
        {
            re.lockRpt(rptFriend);
        }
        else
        {
            btnMyFriend.Visible = false;
            btnChangePwd.Visible = false;
        }

    }

    protected void btnLinkCentre_Click(object sender, EventArgs e)
    {
        Response.Redirect("host.aspx?"+Request.QueryString);
    }

    protected void btnLinkJournal_Click(object sender, EventArgs e)
    {
        Response.Redirect("journal.aspx?" + Request.QueryString);
    }

    protected void btnLinkPhoto_Click(object sender, EventArgs e)
    {
        Response.Redirect("photo.aspx?" + Request.QueryString);
    }

    protected void btnLinkMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("message.aspx?" + Request.QueryString);
    }

    protected void btnLinkPersonal_Click(object sender, EventArgs e)
    {
        Response.Redirect("personal.aspx?" + Request.QueryString);
    }

    protected void btnLinkMyHost_Click(object sender, EventArgs e)
    {
        Response.Redirect("host.aspx?id=" + userId);
    }

    protected void btnOut_Click(object sender, EventArgs e)
    {
        // 只去掉自动登录cookies和session
        cookie = Request.Cookies[es.COOKIES_USER];
        cookie.Values.Remove(es.COOKIES_USER_ID);
        Response.AppendCookie(cookie);
        Session.Remove(es.SESSION_USER_ID);
        Response.Redirect("login.aspx");
    }

    protected void btnAddFriend_Click(object sender, EventArgs e)
    {
        string username = txtFind.Text;
        int result = sq.getDataId(username, es.STYLE_USER_NAME);
        if (result == -1)
        {
            Response.Write("<script>alert('查无此人')</script>");
            return;
        }
        int returnBack = us.addFriend(userId, result);
        switch (returnBack)
        {
            case 0:
                Response.Write("<script>alert('添加成功，你们已经是好友了')</script>");
                break;
            case 1:
                Response.Write("<script>alert('你们已经是好友了，无需重复添加')</script>");
                break;
            default:
                break;
        }
    }

    protected void btnMyfriend_Click(object sender, EventArgs e)
    {
        btnMyFriend.Visible = !(pnlFriendList.Visible = true);
        list = new DataTable();
        sq.getFirstIdLinkAll(hostId, es.STYLE_USER_NAME, list);
        list.Columns["secondId"].ColumnName = "id";
        list.Columns["data"].ColumnName = "name";
        // 若显示好友还要分页则按钮太多，故直接设置成最多显示（只能加）100个好友，将其他页面的repeaterOp配套按钮copy过来也能分页。
        re.init(list, 100);
    }

    protected void rptFriend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("host.aspx?id=" + id);
    }

    protected void btnFriendBack_Click(object sender, EventArgs e)
    {
        btnMyFriend.Visible = !(pnlFriendList.Visible = false);
    }

    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("changePwd.aspx?" + Request.QueryString);
    }
}
