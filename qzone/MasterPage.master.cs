using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();

    HttpCookie cookie;
    object temp;
    int userId,hostId,userLevel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);
        lblHost.Text = sq.getDataContent(hostId).ToString();

        switch (userLevel)
        {
            case -1:
                Response.Redirect("host.aspx?" + Request.QueryString);
                return;
            case 0:
                btnLinkMyHost.Visible = false;
                break;
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
        cookie = Request.Cookies[es.COOKIES_USER];
        cookie.Expires=DateTime.Now.AddYears(-1);
        Response.AppendCookie(cookie);
        Session.Remove(es.SESSION_USER_ID);
        Response.Redirect("login.aspx");
    }

    protected void btnAddFriend_Click(object sender, EventArgs e)
    {
        string username = txtFind.Text;
        int result = sq.getDataId(username, es.STYLE_USERNAME);
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
}
