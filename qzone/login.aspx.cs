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
            // 检查自动登录 查cookies
            if (cookie != null)
            {
                if (cookie[es.COOKIES_USER_ID] != null)
                {
                    // 获得分配给自动登录用户的随机字符串 并查找相应的用户
                    string rStr = cookie[es.COOKIES_USER_ID];
                    int strId = sq.getDataId(rStr, es.STYLE_USER_COOKIES);
                    if (strId != -1)
                    {
                        DataTable getUserId = new DataTable();
                        sq.getLines(getUserId, -1, strId, es.STYLE_NULL);
                        userId = (int)getUserId.Rows[0][1];
                    }
                    else
                    {
                        userId = -1;
                    }
                }
                else
                {
                    userId = -1;
                }
                // 找到用户则直接跳转
                if (userId != -1)
                {
                    Session[es.SESSION_USER_ID] = userId;
                    Response.Redirect("host.aspx?id=" + userId);
                }
                // 记住密码
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
        // 各种检测登录
        username = txtUsername.Text; password = txtPassword.Text;
        userId = sq.getDataId(username,es.STYLE_USER_NAME);
        // 先判验证码
        string identify = txtIdentifying.Text;
        if(identify != Session["Identifying"].ToString())
        {
            Response.Write("<script>alert('验证码错误')</script>");
            return;
        }

        // 若用户名被注册过
        if (userId != -1)
        {
            // 获取该用户名的密码，数据库中储存的是密码的哈希值，原密码不可见
            DataTable temp = new DataTable();
            sq.getFirstIdLinkData(userId, es.STYLE_USER_PASSWORD, temp);
            string realPassword = temp.Rows[0][0].ToString().Trim();
            string tempPwd = password;  // 记住密码按钮用到的语句
            password = password.GetHashCode().ToString();  // 输入的密码取哈希

            // 登录成功
            if (password == realPassword)
            {
                // 默认会记住用户名
                cookie = new HttpCookie(es.COOKIES_USER);
                cookie.Expires = System.DateTime.Now.AddDays(7);
                cookie.Values.Add(es.COOKIES_USER_USERNAME, username);

                if (cbxRememberPassword.Checked)
                {
                    cookie.Values.Add(es.COOKIES_USER_PASSWORD, tempPwd);
                }

                if (cbxAutoLogin.Checked)
                {
                    string rStr = es.getRandomString(30);
                    us.changeUserCookies(userId, rStr);
                    cookie.Values.Add(es.COOKIES_USER_ID,rStr);
                }

                // 跳转
                Session[es.SESSION_USER_ID] = userId;
                Response.AppendCookie(cookie);
                Response.Redirect("host.aspx?id=" + userId);
            }
        }
        Response.Write("<script>alert('用户名或密码错误')</script>");
    }

    protected void btnPwdFindBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("pwdFindBack.aspx");
    }
}