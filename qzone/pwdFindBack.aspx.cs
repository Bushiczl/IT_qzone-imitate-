using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pwdFindBack : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('随机新密码已发送到邮箱')</script>");
        string name = txtUsername.Text;
        int userId = sq.getDataId(name, es.STYLE_USER_NAME);
        if (userId == -1)
        {
            return;
        }

        DataTable getPwdId = new DataTable();
        sq.getFirstIdLinkSecondId(userId, es.STYLE_USER_PASSWORD, getPwdId);
        int pwdId = (int)getPwdId.Rows[0][0];

        DataTable getEmail = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_USER_EMAIL, getEmail);
        string email = getEmail.Rows[0][0].ToString().Trim();

        string newPwd = es.getRandomString(10);
        int returnBack = us.send(newPwd+"这是你在空间的新密码", email);
        if (returnBack == 0)
        {
            sq.changeDataContent(pwdId, newPwd.GetHashCode().ToString());
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}