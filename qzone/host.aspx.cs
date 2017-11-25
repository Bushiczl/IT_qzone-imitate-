using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class host : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();

    HttpCookie cookie;
    int userId,hostId;
    object temp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
    }
}