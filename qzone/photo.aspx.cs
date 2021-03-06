﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class photo : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();

    HttpCookie cookie;
    int userId, hostId, userLevel;
    DataTable list;
    object temp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);
        
        re.lockRpt(rptPhoto);
        if (!Page.IsPostBack)
        {
            list = new DataTable();
            // 个性化填充绑定源
            sq.getFirstIdLinkAll(hostId, es.STYLE_IMAGESURL, list);
            list.Columns["secondId"].ColumnName = "id";
            list.Columns["data"].ColumnName = "url";

            re.init(list);
            re.jumpFromSession(es.SESSION_RPT_PAGE);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }

        if (userLevel == 0)
        {
            pnlHost.Visible = true;
            foreach (RepeaterItem ri in rptPhoto.Items)
            {
                LinkButton btn = (LinkButton)ri.FindControl("btnDelete");
                btn.Visible = true;
            }
        }
    }

    protected void rptPhoto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int imgId = int.Parse(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "btnDelete":
                object imgName = sq.getDataContent(imgId);
                string path = Server.MapPath(es.PATH_IMAGES + imgName.ToString());
                File.Delete(path);
                sq.deleteData(imgId);
                break;
            default:
                break;
        }
        Session[es.SESSION_RPT_PAGE] = re.pageIndex;
        Response.Redirect(Request.Url.ToString());
    }

    // 上传文件部分
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string uploadName = InputFile.PostedFile.FileName;//获取待上传图片的完整路径，包括文件名

        // 上传前检测文件大小，但不知道为什么这部分完全没有任何卵用
        int length = InputFile.PostedFile.ContentLength;   //得到上传文件大小
        if (length > 1048576) //1024*1024=1M,控制大小
        {
            Response.Write("<script>alert('文件不能超过1M !')</script>");
            return;
        }
        
        string pictureName = "";
        string suffix="";
        if (InputFile.FileName != "")
        {
            int idx = uploadName.LastIndexOf(".");
            suffix = uploadName.Substring(idx);//获得上传的图片的后缀名
            pictureName = DateTime.Now.Ticks.ToString() + suffix;//上传后的图片名，以当前时间为文件名，确保文件名没有重复
        }
        switch (suffix)
        {
            case ".png":
            case ".jpg":
            case ".img":
                break;
            default:
                Response.Write("<script>alert('不是图片')</script>");
                return;
        }
        try
        {
            if (uploadName != "")
            {
                string path = Server.MapPath(es.PATH_IMAGES);
                InputFile.PostedFile.SaveAs(path + pictureName);
            }
            int pictureId = sq.newData(pictureName, es.STYLE_IMAGESURL);
            sq.link(hostId, pictureId, es.STYLE_NULL);

            Session[es.SESSION_RPT_PAGE] = re.pageIndex;
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    // 杂按钮的函数块
    protected void btnPrePage_Click(object sender, EventArgs e)
    {
        re.prePage();
        lblAllPage.Text = re.pageCount.ToString();
        txtNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        re.nextPage();
        lblAllPage.Text = re.pageCount.ToString();
        txtNowPage.Text = re.pageIndex.ToString();
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        try
        {
            int index = int.Parse(txtNowPage.Text);
            re.jumpPage(index);
            lblAllPage.Text = re.pageCount.ToString();
            txtNowPage.Text = re.pageIndex.ToString();
        }
        catch (Exception)
        {
            Response.Write("<script>alert('页数输入不合法')</script>");
        }
    }
    // 结束
}