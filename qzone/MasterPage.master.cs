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
    int userId,hostId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        lblHost.Text = sq.getDataContent(hostId).ToString();
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

    }
}
