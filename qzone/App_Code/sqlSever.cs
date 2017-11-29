using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// sqlSever 的摘要说明
/// </summary>
public class sqlSever
{
    static essential es = new essential();

    static string address = @"server=LAPTOP-BM1B2KDI;Integrated Security=SSPI;database=qzone;";

    public sqlSever()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int sqlOther(string sql,params string[] parameter)
    {
        SqlConnection conn = new SqlConnection(address);
        SqlCommand cmd = new SqlCommand(sql, conn);
        for (int i = 0; i < parameter.Count(); i++)
        {
            cmd.Parameters.AddWithValue("@value"+i.ToString(),parameter[i]);
        }
        conn.Open();
        int returnNum = cmd.ExecuteNonQuery();
        conn.Close();
        return returnNum;
    }

    public int sqlSelect(string sql, DataTable transport, params string[] parameter)
    {
        SqlConnection conn = new SqlConnection(address);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        for (int i = 0; i < parameter.Count(); i++)
        {
            da.SelectCommand.Parameters.AddWithValue("@value" + i.ToString(), parameter[i]);
        }
        conn.Open();
        da.Fill(transport);
        conn.Close();
        return 0;
    }

    public struct styleIdAndTable
    {
        public int styleId;
        public string tableName;
    }

    public styleIdAndTable getStyleIdAndTable(string style)
    {
        string sql = "select distinct id,tableName from style where styleName = @value0";
        DataTable temp = new DataTable();
        sqlSelect(sql, temp, style);
        styleIdAndTable siat = new styleIdAndTable();
        siat.tableName = temp.Rows[0][1].ToString().Trim();
        siat.styleId = int.Parse(temp.Rows[0][0].ToString());
        return siat;
    }

    public int getDataId(object input, string style)
    {
        styleIdAndTable siat = getStyleIdAndTable(style);
        string sql = "select distinct data.id from data, "+siat.tableName+" where data.style = " + siat.styleId + " and " + siat.tableName + ".id = data.tableId and " + siat.tableName + ".data = @value0";
        DataTable temp = new DataTable();
        sqlSelect(sql, temp, input.ToString());
        if (temp.Rows.Count != 0)
        {
            int dataId = int.Parse(temp.Rows[0][0].ToString()) ;
            return dataId;
        }
        return -1;
    }

    public object getDataContent(int id)
    {
        string sql = "select distinct tableName,tableId from data,style where data.id = " + id + " and style.id = data.style";
        DataTable temp = new DataTable();
        sqlSelect(sql, temp);
        string tableName = temp.Rows[0][0].ToString().Trim();
        int tableId = int.Parse(temp.Rows[0][1].ToString());
        sql = "select distinct data from " + tableName + " where id = " + tableId;
        temp = new DataTable();
        sqlSelect(sql, temp);
        string test = temp.Rows[0][0].ToString();
        object DataContent = temp.Rows[0][0];
        return DataContent;
    }

    public string getDataStyle(int id)
    {
        string sql = "select distinct style.styleName from style,data where data.id=" + id + " and data.style=style.id";
        DataTable temp = new DataTable();
        sqlSelect(sql, temp);
        if (temp.Rows[0][0] == null) return "";
        string styleName = temp.Rows[0][0].ToString().Trim();
        return styleName;
    }

    public int getFirstIdLinkData(int id, string dataStyle, DataTable transport)
    {
        styleIdAndTable siat = getStyleIdAndTable(dataStyle);
        string sql = "select distinct " + siat.tableName + ".data from " + siat.tableName + ",data,lines where lines.firstId = " + id + " and data.style = " + siat.styleId + " and data.id = lines.secondId and data.tableId = " + siat.tableName + ".id";
        sqlSelect(sql, transport);
        return transport.Rows.Count;
    }

    public int getFirstIdLinkSecondId(int id, string dataStyle, DataTable transport)
    {
        styleIdAndTable siat = getStyleIdAndTable(dataStyle);
        string sql = "select distinct secondId from data,lines,style where firstId = " + id + " and data.style = " + siat.styleId + " and secondId = data.id";
        sqlSelect(sql, transport);
        return transport.Rows.Count;
    }

    public int getFirstIdLinkAll(int id, string dataStyle, DataTable transport)
    {
        styleIdAndTable siat = getStyleIdAndTable(dataStyle);
        string sql= "select distinct secondId, " + siat.tableName + ".data from " + siat.tableName + ",data,lines,style where firstId = " + id + " and data.style = " + siat.styleId + " and secondId = data.id and data.tableId = " + siat.tableName + ".id";
        sqlSelect(sql, transport);
        return transport.Rows.Count;
    }

    public void getLines(DataTable transport, int firstId, int secondId, string style)
    {
        styleIdAndTable siat = getStyleIdAndTable(style);
        string sql = "select distinct * from lines where '1'='1'";
        if (firstId != -1)
        {
            sql = sql + " and firstId =" + firstId;
        }
        if (secondId != -1)
        {
            sql = sql + " and secondId = " + secondId;
        }
        if (style != es.STYLE_NULL)
        {
            sql = sql + " and style = " + siat.styleId;
        }
        sqlSelect(sql, transport);
    }

    public void changeDataContent(int id, object input)
    {
        string dataStyle = getDataStyle(id);
        styleIdAndTable siat = getStyleIdAndTable(dataStyle);
        string sql;
        if (siat.tableName == "int" || siat.tableName == "bit")
        {
            sql = "update " + siat.tableName + " set " + siat.tableName + ".data = " + int.Parse(input.ToString()) + " where " + siat.tableName + ".id in (select distinct tableId from data where id = " + id + ")";
            sqlOther(sql);
        }
        else
        {
            sql = "update " + siat.tableName + " set " + siat.tableName + ".data = @value0 where " + siat.tableName + ".id in (select distinct tableId from data where id = " + id + ")";
            sqlOther(sql, input.ToString());
        }
    }

    public int newData(object input, string style)
    {
        styleIdAndTable siat = getStyleIdAndTable(style);
        DataTable temp = new DataTable();
        string sql;
        if (siat.tableName=="int" || siat.tableName == "bit")
        {
            sql = "insert into " + siat.tableName + " values ("+int.Parse(input.ToString())+"); select scope_identity();";
            sqlSelect(sql, temp);
        }
        else
        {
            sql = "insert into " + siat.tableName + " values (@value0); select scope_identity();";
            sqlSelect(sql, temp, input.ToString());
        }
        int newDataTableId = int.Parse(temp.Rows[0][0].ToString());
        sql = "insert into data values (" + newDataTableId + ", "+siat.styleId+ "); select scope_identity();";
        temp = new DataTable();
        sqlSelect(sql, temp);
        int newDataId = int.Parse(temp.Rows[0][0].ToString());
        return newDataId;
    }

    public void deleteData(int dataId)
    {
        string style = getDataStyle(dataId);
        styleIdAndTable siat = getStyleIdAndTable(style);
        string sql;
        sql = "delete from lines where firstId = " + dataId + " or secondId = " + dataId + ";";
        sql = sql + " delete from " + siat.tableName + " where id in (select tableId from data where id = " + dataId + ");";
        sql = sql + " delete from data where id = " + dataId;
        sqlOther(sql);
    }

    public void link(int firstId,int secondId, string style)
    {
        styleIdAndTable siat = getStyleIdAndTable(style);
        string sql="insert into lines values ("+firstId+", "+secondId+", "+siat.styleId+")";
        sqlOther(sql);
    }
}