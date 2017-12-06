using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changePwd : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();
    
    object temp;
    int userId, hostId, userLevel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);

        if (userLevel != 0)
        {
            Response.Redirect("host.aspx?id=" + userId);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string pwdOld = txtPwdOld.Text, pwdNew = txtPwdNew.Text, pwdConfirm = txtPwdConfirm.Text;

        int returnBack = es.checkInputWhite(pwdNew, es.CHARS_ABC_BIG + es.CHARS_ABC_SMALL + es.CHARS_NUM, 30);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('新密码不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('新密码过长')</script>");
                return;
            case 3:
                Response.Write("<script>alert('新密码不能包含非法字符')</script>");
                return;
            default:
                break;
        }

        DataTable getPwd = new DataTable();
        sq.getFirstIdLinkAll(hostId, es.STYLE_USER_PASSWORD, getPwd);
        string pwdTrue = getPwd.Rows[0][1].ToString().Trim();
        string pwdOldHash = pwdOld.GetHashCode().ToString();
        int pwdId = (int)getPwd.Rows[0][0];
        if (pwdOldHash == pwdTrue)
        {
            if (pwdNew != pwdConfirm)
            {
                Response.Write("<script>alert('确认密码与新密码要一致')</script>");
                return;
            }
            string pwdNewHash = pwdNew.GetHashCode().ToString();
            sq.changeDataContent(pwdId, pwdNewHash);
            Response.Write("<script>alert('修改成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('原密码错误')</script>");
            return;
        }
    }
}