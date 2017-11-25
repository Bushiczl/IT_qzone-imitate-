using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// UsersOp 的摘要说明
/// </summary>
public class UsersOp
{
    static SqlOp sq = new SqlOp();
    static Essential es = new Essential();
    static string myQQPwd = "onfcuaydnfzabehj";
    public UsersOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int addUser(string username, string password, string email)
    {
        string sql = "select * from users where username='" + username + "'";
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql,dt);
        if (dt.Rows.Count != 0) return 1;
        sql = "insert into users values('" + username + "','" + password + "','" + email + "');";
        sq.sqlOther(sql);
        return 0;
    }

    public int userLogin(string username, string password)
    {
        string sql = "select * from users where username='" + username + "'";
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        if (dt.Rows.Count == 0) return 1;
        string realPwd = dt.Rows[0][2].ToString();
        realPwd = realPwd.Trim();
        if (password != realPwd) return 2;
        return 0;
    }

    public int ChangePwd(int id, string newPwd)
    {
        string sql = "update users set password = '" + newPwd + "' where id=" + id.ToString();
        sq.sqlOther(sql);
        return 0;
    }

    public int userChangePwd(int id, string oldPwd, string newPwd)
    {
        string realPwd = changeIdToPassword(id);
        if (oldPwd != realPwd) return 1;
        ChangePwd(id, newPwd);
        return 0;
    }

    public int changeNameToId(string username)
    {
        string sql = "select * from users where username='" + username + "'";
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        if (dt.Rows.Count == 0) return -1;
        return int.Parse(dt.Rows[0][0].ToString());
    }

    public string changeIdToName(int id)
    {
        string sql = "select * from users where id=" + id.ToString();
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        if (dt.Rows.Count == 0) return "";
        string temp = dt.Rows[0][1].ToString();
        temp = temp.Trim();
        return temp;
    }

    public string changeIdToPassword(int id)
    {
        string sql = "select * from users where id=" + id.ToString();
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        if (dt.Rows.Count == 0) return "";
        string temp = dt.Rows[0][2].ToString();
        temp = temp.Trim();
        return temp;
    }

    public string changeNameToEmail(string username)
    {
        string sql = "select * from users where username='" + username + "'";
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        if (dt.Rows.Count == 0) return "";
        string temp = dt.Rows[0][3].ToString();
        temp = temp.Trim();
        return temp;
    }
    public int bookBorrow(int userId, int bookId)
    {
        string sql = "select id from borrowList where bookId = " + bookId.ToString() + " and userId = " + userId.ToString();
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        int haveBorrowed = dt.Rows.Count;
        if (haveBorrowed > 0)
        {
            return 2;
        }
        sql = "select leftNum from books where id = " + bookId.ToString();
        System.Data.DataTable dt2 = new DataTable();
        sq.sqlSelect(sql, dt2);
        int left = int.Parse(dt2.Rows[0][0].ToString());
        if (left <= 0)
        {
            return 1;
        }
        DateTime borrowTime = DateTime.Now;
        DateTime returnTime = borrowTime.AddDays(30);
        sql = "insert into borrowList values (" + bookId.ToString() + ", " + userId.ToString() + ", '" + borrowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + returnTime.ToString("yyyy-MM-dd HH:mm:ss") + "')"; 
        sq.sqlOther(sql);
        sql = "update books set leftNum = " + (left - 1).ToString() + " where id = " + bookId.ToString();
        sq.sqlOther(sql);
        return 0;
    }

    public int bookReturn(int borrowId)
    {
        string sql = "select bookId from borrowList where id = " + borrowId;
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        int count = dt.Rows.Count;
        if (count == 0) return 1;
        int bookId = int.Parse(dt.Rows[0][0].ToString());
        sql = "select leftNum from books where id = " + bookId;
        dt = new DataTable();
        sq.sqlSelect(sql, dt);
        string temp = dt.Rows[0][0].ToString();
        int left = int.Parse(dt.Rows[0][0].ToString());
        left=left+1;
        sql = "update books set leftNum = "+left+" where id = "+bookId;
        sq.sqlOther(sql);
        sql="delete from borrowList where id=" +borrowId;
        sq.sqlOther(sql);
        return 0;
    }

    public int borrowDelay(int borrowId, int day = 30)
    {
        string sql = "select endDay from borrowList where id = " + borrowId;
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        int count = dt.Rows.Count;
        if (count == 0) return 1;
        DateTime endDay =Convert.ToDateTime(dt.Rows[0][0].ToString());
        DateTime newEndDay = endDay.AddDays(day);
        sql= "update borrowList set endDay = '" + newEndDay.ToString("yyyy-MM-dd HH:mm:ss") + "' where id = " + borrowId;
        sq.sqlOther(sql);
        return 0;
    }

    public int sendPassword(string password, string email)
    {
        e_mail em = new e_mail();
        em.mailFrom = "1045932460@qq.com";
        em.mailPwd = myQQPwd;
        em.mailSubject = "密码";
        em.mailBody = password;
        em.isbodyHtml = true;    //是否是HTML
        
        em.host = "smtp.qq.com";//如果是QQ邮箱则：smtp:qq.com,依次类推
        em.mailToArray = new string[] { email };//接收者邮件集合
        em.mailCcArray = null;//抄送者邮件集合
        if (em.Send())
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('发送邮件成功！');history.go(-1)</script>");//发送成功则提示返回当前页面；

        }
        else
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('发送失败！');history.go(-1)</script>");
        }
        return 0;
    }
}