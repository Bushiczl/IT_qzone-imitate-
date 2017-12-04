using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
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
            dy.fillDynamic(hostId,list);
            re.init(list);
            re.jumpFromSession(es.SESSION_RPT_PAGE);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }
    }

    protected void rptRelevantDynamic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Panel pnl;
        LinkButton btn;
        TextBox txt;
        int dynamicId, returnBack;
        string replyContent;
        
        switch (e.CommandName)
        {
            case "delete":
                dynamicId = int.Parse(e.CommandArgument.ToString());
                dy.deleteDynamic(dynamicId);

                Session[es.SESSION_RPT_PAGE] = re.pageIndex;
                Response.Redirect(Request.Url.ToString());
                break;
            case "reply":
                pnl = (Panel)e.Item.FindControl("pnlReplyEdit");
                btn = (LinkButton)e.Item.FindControl("btnReply");
                btn.Visible = !(pnl.Visible = true);
                break;
            case "submit":
                txt = (TextBox)e.Item.FindControl("txtReplyEdit");
                dynamicId = int.Parse(e.CommandArgument.ToString());
                replyContent = txt.Text;
                returnBack = es.checkInputBlack(replyContent, "", 100);
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
                dy.newReply(userId,dynamicId,replyContent);

                Session[es.SESSION_RPT_PAGE] = re.pageIndex;
                Response.Redirect(Request.Url.ToString());
                break;
            case "back":
                pnl = (Panel)e.Item.FindControl("pnlReplyEdit");
                btn = (LinkButton)e.Item.FindControl("btnReply");
                btn.Visible = !(pnl.Visible = false);
                break;
            default:
                break;
        }
    }

    protected void rptRelevantDynamic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //找到外层Repeater的数据项
            DataRowView rowv = (DataRowView)e.Item.DataItem;
            //提取外层Repeater的数据项的ID
            int dynamicId = Convert.ToInt32(rowv["dynamicId"]);
            bool isMine = Convert.ToBoolean(rowv["isMine"]);
            Repeater rept = (Repeater)e.Item.FindControl("RptReply");

            DataTable replyList = new DataTable();
            dy.fillReply(dynamicId, replyList);

            //数据绑定
            rept.DataSource = replyList;
            rept.DataBind();
        }
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
        int returnBack = es.checkInputBlack(content, "", 500);
        switch (returnBack)
        {
            case 0:
                break;
            case 1:
                Response.Write("<script>alert('输入不能为空')</script>");
                break;
            case 2:
                Response.Write("<script>alert('不能超过500个字符')</script>");
                break;
            default:
                return;
        }
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