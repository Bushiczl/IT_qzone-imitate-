<%@ WebHandler Language="C#" Class="HeHeHe" %>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Web;
using System.Web.SessionState;

public class HeHeHe : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/gif";
        // 建立Bitmap对象，绘图
        Bitmap basemap = new Bitmap(200, 60);
        Graphics graph = Graphics.FromImage(basemap);
        Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
        Pen linePen = new Pen(new SolidBrush(Color.White), 2);
        Random r = new Random();

        for (int i = 0; i < 6; i++)
           graph.DrawLine(linePen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));

        basemap.Save(context.Response.OutputStream, ImageFormat.Gif);
        // context.Session["CheckCode"] = s.ToString();   //如果没有实现IRequiresSessionState，则这里会出错，也无法生成图片
        context.Response.End();      
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}