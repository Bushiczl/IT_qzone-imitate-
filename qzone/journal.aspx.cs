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

        re.lockRpt(rptJournals); 
        if (!Page.IsPostBack)
        {
            list = new DataTable();
            jo.getAllIdAndTitle(hostId, list);
            re.init(list);
            re.jumpFromSession(es.SESSION_RPT_PAGE);
            lblShowAllPage.Text = re.pageCount.ToString();
            txtShowNowPage.Text = re.pageIndex.ToString();
        }
        else
        {
            
        }
    }

    protected void rptJournals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int journalId = int.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "btnDelete":
                Session[es.SESSION_RPT_PAGE] = re.pageIndex;
                Response.Redirect(Request.Url.ToString());
                break;
            case "btnJournal":
                break;
            default:
                break;
        }
    }

    protected void btnShowNewJournal_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlNewJournal.Visible = true);
    }

    protected void btnNewSubmit_Click(object sender, EventArgs e)
    {
        string contentBackstage = Context.Request.Form["content"];

        if (contentBackstage == null)
        {
            
            Response.Write("<script>alert('emmm')</script>");
            return;
        }
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
        jo.newJournal(userId, title, contentBackstage);
        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnNewBack_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlNewJournal.Visible = false);
    }


    protected void btnShowPrePage_Click(object sender, EventArgs e)
    {
        re.prePage();
        lblShowAllPage.Text = re.pageCount.ToString();
        txtShowNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnShowNextPage_Click(object sender, EventArgs e)
    {
        re.nextPage();
        lblShowAllPage.Text = re.pageCount.ToString();
        txtShowNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnShowJump_Click(object sender, EventArgs e)
    {
        try
        {
            int index = int.Parse(txtShowNowPage.Text);
            re.jumpPage(index);
            lblShowAllPage.Text = re.pageCount.ToString();
            txtShowNowPage.Text = re.pageIndex.ToString();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('emmmmmm为什么这个地方都要测')</script>");
        }
    }
}