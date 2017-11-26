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
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        
    }

    protected void rpt_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string uploadName = InputFile.Value;//获取待上传图片的完整路径，包括文件名
        //string uploadName = InputFile.PostedFile.FileName;
        string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复
        if (InputFile.Value != "")
        {
            int idx = uploadName.LastIndexOf(".");
            string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名
            pictureName = DateTime.Now.Ticks.ToString() + suffix;
        }
        try
        {
            if (uploadName != "")
            {
                string path = Server.MapPath(es.PATH_IMAGES);
                InputFile.PostedFile.SaveAs(path + pictureName);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
}