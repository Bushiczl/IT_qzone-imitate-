using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// repeaterOp 的摘要说明
/// </summary>
public class repeaterOp
{
    static essential es = new essential();

    Repeater rptNow=null;
    DataTable dt=null;
    PagedDataSource pds;
    public int pageCount, pageIndex;
    public repeaterOp()
    {
        
    }

    private void bind()
    {
        rptNow.DataSource = pds;
        rptNow.DataBind();
    }

    public void lockRpt(Repeater rptInput)
    {
        rptNow = rptInput;
    }

    public int init(DataTable dtInput, int pageSize = 5)
    {
        if (rptNow == null) return 1;
        dt = dtInput;
        if (dt == null) return 2;
        pds = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = pageSize; //单页显示项数
        pds.DataSource = dt.DefaultView; //获取或设置数据源
        pds.CurrentPageIndex = 0;
        pageIndex = 1;
        pageCount = pds.PageCount;
        bind();
        return 0;
    }

    public int nextPage()
    {
        if (pageIndex == pds.PageCount)
        {
            HttpContext.Current.Response.Write("<script>alert('已经是最后一页')</script>");
            return 1;
        }
        pageIndex = pageIndex + 1;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }
    public int prePage()
    {
        if (pageIndex == 1)
        {
            HttpContext.Current.Response.Write("<script>alert('已经是第一页')</script>");
            return 2;
        }
        pageIndex = pageIndex - 1;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }

    public int jumpPage(int index)
    {
        int realIndex=index-1;
        if (realIndex < 0)
        {
            HttpContext.Current.Response.Write("<script>alert('页数非法')</script>");
            return 1;
        }
        if (realIndex > pds.PageCount - 1)
        {
            HttpContext.Current.Response.Write("<script>alert('页数非法')</script>");
            return 2;
        }
        pageIndex = index;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }

    public int jumpFromSession(string sessionFlag)
    {
        if (HttpContext.Current.Session["page"] != null)
        {
            int page = int.Parse(HttpContext.Current.Session["page"].ToString());
            if (page > pageCount) page = pageCount;
            jumpPage(page);
            HttpContext.Current.Session.Remove("page");
            return 0;
        }
        return 1;
    }
}