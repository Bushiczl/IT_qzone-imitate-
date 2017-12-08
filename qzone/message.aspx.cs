using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class message : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();
    static messageOp me = new messageOp();
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

        re.lockRpt(rptShow);
        if (!Page.IsPostBack)
        {
            list = new DataTable();

            me.fill(hostId, list);

            re.init(list, 10);
            re.jumpFromSession(es.SESSION_RPT_PAGE);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }

        if (userLevel == 0)
        {
            foreach (RepeaterItem ri in rptShow.Items)
            {
                LinkButton btn = (LinkButton)ri.FindControl("btnDelete");
                btn.Visible = true;
            }
        }
    }

    protected void btnNewMessage_Click(object sender, EventArgs e)
    {
        btnNewMessage.Visible = !(pnlEdit.Visible = true);
    }

    protected void rptShow_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());

        string style = sq.getDataStyle(id);
        if (style.Equals(es.STYLE_JOURNAL_REPLY_CONTENT))
        {
            jo.deleteReply(id);
        }
        else if (style.Equals(es.STYLE_MESSAGE_CONTENT))
        {
            me.deleteMessage(id);
        }
        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string input = txtEdit.Text;
        int returnBack = es.checkInputBlack(input, "", 100);
        switch (returnBack)
        {
            case 0:
                break;
            case 1:
                Response.Write("<script>alert('输入不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('不能超过100个字符')</script>");
                return;
            default:
                return;
        }
        me.newMessage(userId, hostId, input);

        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnNewMessage.Visible = !(pnlEdit.Visible = false);
    }

    protected void btnPrePage_Click(object sender, EventArgs e)
    {
        re.prePage();
        lblAllPage.Text = re.pageCount.ToString();
        txtNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        re.nextPage();
        lblAllPage.Text = re.pageCount.ToString();
        txtNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        try
        {
            int index = int.Parse(txtNowPage.Text);
            re.jumpPage(index);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('页数输入不合法')</script>");
        }
    }
}