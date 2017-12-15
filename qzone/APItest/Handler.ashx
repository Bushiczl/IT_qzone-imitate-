<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

// Handler.ashx

public class Handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        Random r = new Random();
        context.Response.Write(r.Next());

        // context.Response.ContentType = "text/plain";
        // context.Response.Write("Hello World");

        try
        {
            int t = 0;
            int a = 1 / t;
        }
        catch (Exception ex)
        {
            context.AddError(ex);
            context.ClearError();
        }
        // context.Response.Write(" 方法是：" + context.Request.RequestType);
        // context.Response.Write(" " + context.Request.Headers);

        // context.Response.Write(" " + context.Items.Keys);

        //context.Response.ContentType = "text/xml";
        //context.Response.Write("<now>");
        //context.Response.Write(DateTime.Now.ToString());
        //context.Response.Write("</now>");
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}