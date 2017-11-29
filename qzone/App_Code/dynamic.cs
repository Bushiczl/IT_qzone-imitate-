using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// dynamic 的摘要说明
/// </summary>
public class dynamic
{
    static sqlSever sq = new sqlSever();
    static essential es = new essential();

    public dynamic()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public void newDynamic(int userId, string content)
    {
        DateTime dt = DateTime.Now;
        int contentId = sq.newData(content, es.STYLE_DYNAMIC_CONTENT);
        sq.link(userId, contentId, es.STYLE_NULL);
        int timeId = sq.newData(dt.ToString("ddMMyyyy"), es.STYLE_DYNAMIC_EDIT_TIME);
        sq.link(contentId, timeId, es.STYLE_NULL);
    }

    public void fill(int hostId, DataTable transport)
    {
        // 筛选空间主人的好友
        DataTable dynamicOwner = new DataTable();
        sq.getLines(dynamicOwner, hostId, -1, es.STYLE_LINES_FRIEND);
        // 空间主人自己也算是自己的好友
        DataRow tempHostAdd = dynamicOwner.NewRow();  
        tempHostAdd[2] = hostId;
        dynamicOwner.Rows.Add(tempHostAdd);

        // 根据筛选出的动态发布者的列表向transport表中添加动态内容
        for (int i = 0; i < dynamicOwner.Rows.Count; i++)
        {
            int owner = (int)dynamicOwner.Rows[i][2];
            sq.getFirstIdLinkAll(owner, es.STYLE_DYNAMIC_CONTENT, transport);
        }
        transport.Columns["secondId"].ColumnName = "dynamicId";
        transport.Columns["data"].ColumnName = "dynamicContent";
    }
}