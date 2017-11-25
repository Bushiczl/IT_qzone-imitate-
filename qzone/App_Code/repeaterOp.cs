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
    Repeater rptNow=null;
    DataTable dt=null;
    PagedDataSource pds;
    int pageCount, pageIndex;
    public repeaterOp()
    {
        
    }

    private void bind()
    {
        rptNow.DataSource = pds;
        rptNow.DataBind();
    }

    public int init(Repeater rptInput, DataTable dtInput, int pageSize = 5)
    {
        rptNow = rptInput;
        if (rptNow == null) return 1;
        dt = dtInput;
        if (dt == null) return 2;
        pds = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = pageSize; //单页显示项数
        pds.DataSource = dt.DefaultView; //获取或设置数据源
        pds.CurrentPageIndex = 0;
        pageIndex = 1;
        pageCount = pds.Count;
        bind();
        return 0;
    }

    public int nextPage()
    {
        if (pageIndex == pds.PageCount) return 1;
        pageIndex = pageIndex + 1;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }
    public int prePage()
    {
        if (pageIndex == 1) return 2;
        pageIndex = pageIndex - 1;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }

    public int jumpPage(int index)
    {
        int realIndex=index-1;
        if (realIndex < 0) return 1;
        if (realIndex > pds.PageCount - 1) return 2;
        pageIndex = index;
        pds.CurrentPageIndex = pageIndex - 1;
        bind();
        return 0;
    }
}