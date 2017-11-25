using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    HttpCookie cookie;
    object temp;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string sql = "select 1,2,3";
        sq.sqlSelect(sql, dt);
        
        Repeater abc = rpt;
        abc.DataSource = dt;
        abc.DataBind();
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        
    }

    protected void rpt_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {

    }
}