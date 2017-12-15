<%@ WebHandler Language="C#" Class="getit" %>

using System;
using System.Web;

public class getit : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        string username = context.Request.QueryString["username"].ToString();
        string pwd = context.Request.QueryString["pwd"].ToString();

        context.Response.ContentType = "text/plain";
        context.Response.Write("Get successful! server return:"+username+"__"+pwd);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}