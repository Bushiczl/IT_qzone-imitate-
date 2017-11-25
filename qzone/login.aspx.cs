using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();

    int userId;
    string username, password;
    HttpCookie cookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        cookie = Request.Cookies[es.COOKIES_USER];
        if (!Page.IsPostBack) {
            if (cookie != null)
            {
                if (cookie[es.COOKIES_USER_ID] != null)
                {
                    userId = int.Parse(cookie[es.COOKIES_USER_ID].ToString());
                }
                else
                {
                    userId = -1;
                }
                if (userId != -1)
                {
                    Session[es.SESSION_USER_ID] = userId;
                    Response.Redirect("host.aspx?id=" + userId);
                }
                if (cookie[es.COOKIES_USER_USERNAME] != null)
                {
                    username = cookie[es.COOKIES_USER_USERNAME].ToString();
                    if (cookie[es.COOKIES_USER_PASSWORD] != null)
                    {
                        password = cookie[es.COOKIES_USER_PASSWORD].ToString();
                    }
                    else
                    {
                        password = "";
                    }
                    txtUsername.Text = username;
                    txtPassword.Attributes.Add("value", password);
                    cbxRememberPassword.Checked = (password != "");
                }
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        username = txtUsername.Text; password = txtPassword.Text;
        userId = sq.getDataId(username,es.STYLE_USERNAME);
        string identify = txtIdentifying.Text;
        if(identify != Session["Identifying"].ToString())
        {
            Response.Write("<script>alert('验证码错误')</script>");
            return;
        }
        if (userId != -1)
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkData(userId, es.STYLE_PASSWORD, temp);
            string realPassword = temp.Rows[0][0].ToString().Trim();
            if (password == realPassword)
            {
                cookie = new HttpCookie(es.COOKIES_USER);
                cookie.Expires = System.DateTime.Now.AddDays(7);
                cookie.Values.Add(es.COOKIES_USER_USERNAME, username);
                if (cbxRememberPassword.Checked)
                {
                    cookie.Values.Add(es.COOKIES_USER_PASSWORD, password);
                }
                if (cbxAutoLogin.Checked)
                {
                    cookie.Values.Add(es.COOKIES_USER_ID,userId.ToString());
                }
                Session[es.SESSION_USER_ID] = userId;
                Response.AppendCookie(cookie);
                Response.Redirect("host.aspx?id=" + userId);
            }
        }
        Response.Write("<script>alert('用户名或密码错误')</script>");
    }
}