using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// user 的摘要说明
/// </summary>
public class user
{
    static sqlSever sq = new sqlSever();
    static essential es = new essential();
    static e_mail em = new e_mail();
    static string myQQPwd = "onfcuaydnfzabehj";

    public user()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int addUser(string username,string password, string email)
    {
        int returnBack = sq.getDataId(username, es.STYLE_USER_NAME);
        if (returnBack != -1)
        {
            return 1;
        }
        returnBack = send("", email);
        if (returnBack == 1)
        {
            return 2;
        }
        password = password.GetHashCode().ToString();
        int usernameId = sq.newData(username, es.STYLE_USER_NAME);
        int passwordId = sq.newData(password, es.STYLE_USER_PASSWORD);
        int emailId = sq.newData(email, es.STYLE_USER_EMAIL);

        sq.link(usernameId, passwordId, es.STYLE_UNTOPWD);
        sq.link(usernameId, emailId, es.STYLE_NULL);
        return 0;
    }

    public int send(string input, string email)
    {
        e_mail em = new e_mail();
        em.mailFrom = "1045932460@qq.com";
        em.mailPwd = myQQPwd;
        em.mailSubject = "密码";
        em.mailBody = input;
        em.isbodyHtml = true;    //是否是HTML

        em.host = "smtp.qq.com";//如果是QQ邮箱则：smtp:qq.com,依次类推
        em.mailToArray = new string[] { email };//接收者邮件集合
        em.mailCcArray = null;//抄送者邮件集合
        if (em.Send())
        {
            return 0;//发送成功则提示返回当前页面；

        }
        else
        {
            return 1;
        }
    }

    public bool checkLogin()
    {
        object temp = HttpContext.Current.Session[es.SESSION_USER_ID];
        if (isUserId(temp))
        {
            return true;    
        }
        HttpCookie cookie = HttpContext.Current.Request.Cookies[es.COOKIES_USER];
        if (cookie != null)
        {
            string rStr = cookie[es.COOKIES_USER_ID];
            int strId = sq.getDataId(rStr, es.STYLE_USER_COOKIES);

            if (strId != -1)
            {
                DataTable getUserId = new DataTable();
                sq.getLines(getUserId, -1, strId, es.STYLE_NULL);
                int userId = (int)getUserId.Rows[0][1];

                HttpContext.Current.Session[es.SESSION_USER_ID] = userId;
                return true;
            }
        }
        HttpContext.Current.Response.Write("<script>alert('请先登录');location='login.aspx';</script>");
        return false;
        
    }

    public bool isUserId(object input)
    {
        if (input == null)
        {
            return false;
        }
        if (!es.isInt(input))
        {
            return false;
        }
        int temp = int.Parse(input.ToString());
        if (sq.getDataStyle(temp) != es.STYLE_USER_NAME)
        {
            return false;
        }
        return true;
    }

    public bool foolCheck()
    {
        if (!checkLogin()) return false;
        object temp = HttpContext.Current.Request.QueryString["id"];
        if (!isUserId(temp))
        {
            HttpContext.Current.Response.Write("<script>alert('访问出错');location='login.aspx'</script>");
            return false;
        }
        return true;
    }

    public int getUserLevel(int userId, int hostId)
    {
        if (userId == hostId) return 0;
        DataTable temp = new DataTable();
        sq.getLines(temp, hostId, userId, es.STYLE_NULL);
        if (temp.Rows.Count != 0)
        {
            return 1;
        }
        return -1;
    }

    public int addFriend(int userId, int friendId)
    {
        DataTable temp = new DataTable();
        sq.getLines(temp, userId, friendId, es.STYLE_LINES_FRIEND);
        if (temp.Rows.Count != 0)
        {
            return 1;
        }
        sq.link(userId, friendId, es.STYLE_LINES_FRIEND);
        sq.link(friendId, userId, es.STYLE_LINES_FRIEND);
        return 0;
    }

    public void changeUserCookies(int userId, string rStr)
    {
        DataTable getCookiesId = new DataTable();
        int cookiesId;
        if (sq.getFirstIdLinkSecondId(userId, es.STYLE_USER_COOKIES, getCookiesId) == 0)
        {
            cookiesId = sq.newData(rStr, es.STYLE_USER_COOKIES);
            sq.link(userId, cookiesId, es.STYLE_NULL);
        }
        else
        {
            cookiesId = (int)getCookiesId.Rows[0][0];
            sq.changeDataContent(cookiesId, rStr);
        }
    }
}