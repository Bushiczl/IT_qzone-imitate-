using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// ManagerOp 的摘要说明
/// </summary>
public class ManagerOp
{
    static SqlOp sq = new SqlOp();
    static Essential es = new Essential();
    public ManagerOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int addBooks(string name,string author,string kind, int num, string press, string summary) 
    {
        SqlOp.easySql sql = new SqlOp.easySql();
        sq.sqlInit(ref sql);
        sql.how = "insert";
        sql.tableName = "books";
        sql.rowName.Add("name");
        sql.values.Add("N'" + name + " '");
        sql.rowName.Add("author");
        sql.values.Add("N'" + author + " '");
        sql.rowName.Add("kind");
        sql.values.Add("N'" + kind + " '");
        sql.rowName.Add("leftNum");
        sql.values.Add(num);
        sql.rowName.Add("allNum");
        sql.values.Add(num);
        sql.rowName.Add("press");
        sql.values.Add("N'" + press + " '");
        sql.rowName.Add("summary");
        sql.values.Add("N'" + summary + " '");
        sq.sqlQuick(sql);
        return 0;
    }
    public int changeBooks(string name, string author, string kind, int num, string press, string summary, int bookId)
    {
        SqlOp.easySql sql = new SqlOp.easySql();
        sq.sqlInit(ref sql);
        sql.how = "update";
        sql.tableName = "books";
        sql.condition.Add("id = " + bookId);
        sql.rowName.Add("name");
        sql.values.Add("N'" + name + " '");
        sql.rowName.Add("author");
        sql.values.Add("N'" + author + " '");
        sql.rowName.Add("kind");
        sql.values.Add("N'" + kind + " '");
        string sql2 = "select leftNum from books where id=" + bookId;
        DataTable dt = new DataTable();
        sq.sqlSelect(sql2, dt);
        int leftNum =int.Parse(dt.Rows[0][0].ToString());
        leftNum = leftNum + num;
        if (leftNum < 0)
        {
            return 1;
        }
        sql.rowName.Add("leftNum");
        sql.values.Add(leftNum);
        sql2 = "select allNum from books where id=" + bookId;
        DataTable dt2 = new DataTable();
        sq.sqlSelect(sql2, dt2);
        int allNum = int.Parse(dt2.Rows[0][0].ToString());
        allNum = allNum + num;
        sql.rowName.Add("allNum");
        sql.values.Add(allNum);
        sql.rowName.Add("press");
        sql.values.Add("N'" + press + " '");
        sql.rowName.Add("summary");
        sql.values.Add("N'" + summary + " '");
        sq.sqlQuick(sql);
        return 0;
    }

    public int deleteBooks(int bookId)
    {
        string sql = "delete from books where id=" + bookId;
        sq.sqlOther(sql);
        return 0;
    }
    public int deleteUser(int userId)
    {
        string sql = "delete from users where id=" + userId;
        sq.sqlOther(sql);
        return 0;
    }
}