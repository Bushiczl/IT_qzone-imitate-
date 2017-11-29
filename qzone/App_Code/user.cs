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

    public user()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int addUser(string username,string password)
    {
        int returnBack = sq.getDataId(username, es.STYLE_USERNAME);
        if (returnBack != -1)
        {
            return 1;
        }
        int usernameId = sq.newData(username, es.STYLE_USERNAME);
        int passwordId = sq.newData(password, es.STYLE_PASSWORD);
        sq.link(usernameId, passwordId, es.STYLE_UNTOPWD);
        return 0;
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
            HttpContext.Current.Session[es.SESSION_USER_ID] = cookie[es.COOKIES_USER_ID];
            temp = HttpContext.Current.Session[es.SESSION_USER_ID];
            if (isUserId(temp))
            {
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
        if (sq.getDataStyle(temp) != es.STYLE_USERNAME)
        {
            return false;;
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
}