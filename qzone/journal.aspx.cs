using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class journal : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();
    static journalOp jo = new journalOp();

    HttpCookie cookie;
    int userId, hostId, userLevel;
    DataTable list;
    object temp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);
        if (!Page.IsPostBack)
        {
            list = new DataTable();
            jo.getAllIdAndTitle(userId, list);
            re.init(rptJournals, list);
        }
    }

    protected void rptJournals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnShowNewJournal_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlNewJournal.Visible = true);
    }

    protected void btnNewSubmit_Click(object sender, EventArgs e)
    {
        string content = "";
        string title = txtNewJournalTitle.Text;
        int returnBack = es.checkInputBlack(title, "", 30);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('标题不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('标题过长（我很好奇你是怎么办到的）')</script>");
                return;
            default:
                break;
        }
        jo.newJournal(userId, title, content);
    }

    protected void btnNewBack_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlNewJournal.Visible = false);
    }

}