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
    string nowJournalContent, nowJournalTitle;
    DataTable list;
    static DataTable journalAll;
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

            journalAll = new DataTable();
            journalAll.Columns.Add("id", typeof(Int32));
            journalAll.Columns.Add("title", typeof(String));
            journalAll.Columns.Add("content", typeof(String));
        }

        // 添上所有删除按钮
        if (userLevel == 0)
        {
            btnShowNewJournal.Visible = btnReadChangeJournal.Visible = true;
            foreach (RepeaterItem ri in rptJournals.Items)
            {
                LinkButton btn = (LinkButton)ri.FindControl("btnDelete");
                btn.Visible = true;
            }
        }
    }

    protected void rptJournals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int journalId = int.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "btnDelete":
                jo.deleteJournal(journalId);

                Session[es.SESSION_RPT_PAGE] = re.pageIndex;
                Response.Redirect(Request.Url.ToString());
                break;
            case "btnJournal":
                jo.getJournalAll(journalId, journalAll);
                lblJournalTitle.Text = journalAll.Rows[0][1].ToString();
                lblJournalContent.Text = journalAll.Rows[0][2].ToString();
                getReplyAndBind(journalId);
                if (userLevel == 0)
                {
                    foreach (RepeaterItem ri in rptReply.Items)
                    {
                        LinkButton btn = (LinkButton)ri.FindControl("btnReplyDelete");
                        btn.Visible = true;
                    }
                }

                pnlReadJournal.Visible = !(pnlShow.Visible = false);
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
        string contentBackstage = Server.HtmlDecode(txteditor.InnerHtml);

        if (contentBackstage == null)
        {
            
            Response.Write("<script>alert('日志内容不能为空')</script>");
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

    protected void btnReadChangeJournal_Click(object sender, EventArgs e)
    {
        string title = journalAll.Rows[0]["title"].ToString();
        string content = journalAll.Rows[0]["content"].ToString();
        txtChangeTitle.Text = title;
        txtChangeEditor.InnerHtml = content;

        pnlReadShow.Visible = !(pnlReadChange.Visible = true);
    }

    protected void btnReadBack_Click(object sender, EventArgs e)
    {
        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnChangeSave_Click(object sender, EventArgs e)
    {
        string content = Server.HtmlDecode(txtChangeEditor.InnerHtml);

        if (content == null)
        {
            Response.Write("<script>alert('日志内容不能为空')</script>");
            return;
        }
        string title = txtChangeTitle.Text;
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

        int id = (int)journalAll.Rows[0]["id"];

        jo.changeJournal(id, title, content);

        journalAll.Rows[0][1] = title;
        journalAll.Rows[0][2] = content;
        lblJournalTitle.Text = journalAll.Rows[0][1].ToString();
        lblJournalContent.Text = journalAll.Rows[0][2].ToString();

        pnlReadShow.Visible = !(pnlReadChange.Visible = false);
    }

    protected void btnChangeBack_Click(object sender, EventArgs e)
    {
        pnlReadShow.Visible = !(pnlReadChange.Visible = false);
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
            Response.Write("<script>alert('页数输入不合法')</script>");
        }
    }

    private void getReplyAndBind(int journalId)
    {
        DataTable reply = new DataTable();
        jo.getReply(journalId, reply);
        rptReply.DataSource = reply;
        rptReply.DataBind();
    }

    protected void rptReply_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int replyId = int.Parse(e.CommandArgument.ToString());
        jo.deleteReply(replyId);
        int journalId = (int)journalAll.Rows[0]["id"];
        getReplyAndBind(journalId);
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        pnlReplyEdit.Visible = !(btnReply.Visible = false);
    }

    protected void btnReplySubmit_Click(object sender, EventArgs e)
    {
        int journalId = (int)journalAll.Rows[0]["id"];
        string input = txtReplyEdit.Text;
        int returnBack = es.checkInputBlack(input, "", 100);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('回复不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('回复不能超过100个字')</script>");
                return;
            default:
                break;
        }

        jo.newJournalReply(journalId, userId, input);
        getReplyAndBind(journalId);
        txtReplyEdit.Text = "";
        pnlReplyEdit.Visible = !(btnReply.Visible = true);
    }

    protected void btnReplyBack_Click(object sender, EventArgs e)
    {
        pnlReplyEdit.Visible = !(btnReply.Visible = true);
    }
}