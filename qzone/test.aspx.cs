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
    static repeaterOp re = new repeaterOp();
    static dynamic dy = new dynamic();

    HttpCookie cookie;
    int hostId;
    DataTable list;
    object temp;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}