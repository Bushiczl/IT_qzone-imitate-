using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// SqlOp 的摘要说明
/// </summary>
public class SqlOp
{

    static string str = @"server=LAPTOP-BM1B2KDI;Integrated Security=SSPI;database=qzone;";
    public SqlOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public struct easySql
    {
        public ArrayList rowName, values, condition;
        public string how,tableName;
    }

    public void sqlInit(ref easySql easy)
    {
        easy.rowName = new ArrayList();
        easy.values = new ArrayList();
        easy.condition = new ArrayList();
    }

    public int sqlOther(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        int returnNum = cmd.ExecuteNonQuery();
        conn.Close();
        return returnNum;
    }

    public int sqlSelect(string sql,DataTable transport)
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(transport);
        conn.Close();
        return 0;
    }

    public int sqlQuick(easySql easy,DataTable transport = null)
    {
        string sql;
        int count;
        switch (easy.how)
        {
            case "select":
                break;
            case "update":
                sql = "update " + easy.tableName + " set ";
                count = easy.rowName.Count;
                for (int i = 0; i < count; i++)
                {
                    if (i != 0)
                    {
                        sql = sql + ", ";
                    }
                    sql = sql + easy.rowName[i].ToString() + " = " + easy.values[i].ToString();
                }
                count = easy.condition.Count;
                if (count != 0)
                {
                    sql = sql + " where ";
                    for (int i = 0; i < count; i++)
                    {
                        sql = sql + easy.condition[i].ToString();
                    }
                }
                return this.sqlOther(sql);
                break;
            case "delete":
                break;
            case "insert":
                sql = "insert into " + easy.tableName + " (";
                count = easy.rowName.Count;
                for (int i = 0; i < count; i++)
                {
                    if (i != 0)
                    {
                        sql = sql + ", ";
                    }
                    sql = sql + easy.rowName[i].ToString();
                }
                sql = sql + ") values (";
                count = easy.values.Count;
                for (int i = 0; i < count; i++)
                {
                    if (i != 0)
                    {
                        sql = sql + ", ";
                    }
                    sql = sql + easy.values[i].ToString();
                }
                sql = sql + ")";
                return this.sqlOther(sql);
                break;
            default:
                return 1;
        }
        return 0;
    }
}