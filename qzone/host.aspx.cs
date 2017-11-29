using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class host : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();
    static dynamic dy = new dynamic();

    HttpCookie cookie;
    int userId,hostId,userLevel;
    DataTable list;
    object temp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);

        switch (userLevel)
        {
            case 0:
                pnlShow.Visible = true;
                break;
            case -1:
                break;
            case 1:
                break;
            default:
                break;
        }

        re.lockRpt(rptRelevantDynamic);
        if (!Page.IsPostBack)
        {
            list = new DataTable();
            dy.fill(hostId,list);
            re.init(list);
            re.jumpFromSession(es.SESSION_RPT_PAGE);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }
    }

    protected void rptRelevantDynamic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }

    protected void rptReply_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnNewDynamic_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlEdit.Visible = true);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string content = es.usefulXssDefendReplace(txtEditor.Text);
        dy.newDynamic(hostId, content);

        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlShow.Visible = !(pnlEdit.Visible = false);
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
            Response.Write("<script>alert('emmmmmm为什么这个地方都要测')</script>");
        }
    }



}