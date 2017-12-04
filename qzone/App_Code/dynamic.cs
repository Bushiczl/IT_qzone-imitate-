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

    public void fillDynamic(int hostId, DataTable transport)
    {
        // 筛选空间主人的好友
        DataTable dynamicOwner = new DataTable();
        sq.getLines(dynamicOwner, hostId, -1, es.STYLE_LINES_FRIEND);
        // 空间主人自己也算是自己的好友
        DataRow tempHostAdd = dynamicOwner.NewRow();  
        tempHostAdd[2] = hostId;
        dynamicOwner.Rows.Add(tempHostAdd);

        // 拿到访问者的用户名
        int userId = int.Parse(HttpContext.Current.Session[es.SESSION_USER_ID].ToString());
        string userName= sq.getDataContent(userId).ToString();

        // 初始化transport表
        transport.Columns.Add("secondId", typeof(Int32));  // 动态id，方便sql填充表取用此列名，下面有改
        transport.Columns.Add("data", typeof(String));     // 动态内容，方便sql填充表取用此列名，下面有改
        transport.Columns.Add("dynamicUper", typeof(String));
        transport.Columns.Add("isMine", typeof(Boolean));
        transport.Columns.Add("time", typeof(DateTime));

        // 根据筛选出的动态发布者的列表向transport表中添加动态内容
        for (int i = 0; i < dynamicOwner.Rows.Count; i++)
        {
            int owner = (int)dynamicOwner.Rows[i][2];
            int tempCount = transport.Rows.Count;
            string ownerName = sq.getDataContent(owner).ToString();
            sq.getFirstIdLinkAll(owner, es.STYLE_DYNAMIC_CONTENT, transport);    // 添加动态id和内容
            int nowCount = transport.Rows.Count;

            // 填充新加入表的动态的其他内容
            for (int j = tempCount; j < nowCount; j++)
            {
                transport.Rows[j][2] = ownerName;                   // 向transport中添加动态拥有者
                transport.Rows[j][3] = (ownerName == userName);     // 访问者能否删除这条动态
                int dynamicId = (int)transport.Rows[j][0];
                // 获取该动态发布时间
                DataTable getTime=new DataTable();
                sq.getFirstIdLinkData(dynamicId, es.STYLE_DYNAMIC_EDIT_TIME, getTime);
                transport.Rows[j][4] = getTime.Rows[0][0];
            }
        }
        // 改名
        transport.Columns["secondId"].ColumnName = "dynamicId";
        transport.Columns["data"].ColumnName = "dynamicContent";

        // 按发布时间排序
        DataView dv = transport.DefaultView;
        dv.Sort = "time DESC";//按照time倒序排序
        dv.ToTable();
    }

    public void fillReply(int dynamicId, DataTable transport)
    {
        transport.Columns.Add("secondId", typeof(Int32));  // 回复id，方便sql填充表取用此列名，下面有改
        transport.Columns.Add("data", typeof(String));     // 回复内容，方便sql填充表取用此列名，下面有改
        transport.Columns.Add("time", typeof(DateTime));

        sq.getFirstIdLinkAll(dynamicId, es.STYLE_REPLY_CONTENT, transport);
        for (int i = 0; i < transport.Rows.Count; i++)
        {
            int replyId = (int)transport.Rows[i][0];
            DataTable getTime = new DataTable();
            sq.getFirstIdLinkData(replyId, es.STYLE_REPLY_TIME, getTime);
            transport.Rows[i][2] = getTime.Rows[0][0];
        }

        transport.Columns["secondId"].ColumnName = "replyId";
        transport.Columns["data"].ColumnName = "reply";

        // 按发布时间排序
        DataView dv = transport.DefaultView;
        dv.Sort = "time DESC";//按照time倒序排序
        dv.ToTable();
    }

    public void newDynamic(int userId, string content)
    {
        DateTime dt = DateTime.Now;
        content = es.usefulXssDefendReplace(content);
        int contentId = sq.newData(content, es.STYLE_DYNAMIC_CONTENT);
        sq.link(userId, contentId, es.STYLE_NULL);
        int timeId = sq.newData(dt.ToString("yyyy-MM-dd HH:mm:ss"), es.STYLE_DYNAMIC_EDIT_TIME);
        sq.link(contentId, timeId, es.STYLE_NULL);
    }

    public void newReply(int userId, int replyThingsId, string inputReply)
    {
        DateTime dt = DateTime.Now;
        inputReply = es.usefulXssDefendReplace(inputReply);
        string content = " :" + inputReply;
        string replyOwner = sq.getDataContent(userId).ToString().Trim();
        int dynamicId;
        string replyThingsStyle = sq.getDataStyle(replyThingsId);
        if (replyThingsStyle != es.STYLE_DYNAMIC_CONTENT)
        {
            DataTable temp=new DataTable();
            sq.getFirstIdLinkData(replyThingsId, es.COOKIES_USER_USERNAME, temp);
            string replyThingsOwner = temp.Rows[0][0].ToString().Trim();
            content = " 回复 " + replyThingsOwner + content;

            temp = new DataTable();
            sq.getFirstIdLinkSecondId(replyThingsId, es.STYLE_DYNAMIC_CONTENT, temp);
            dynamicId = int.Parse(temp.Rows[0][0].ToString());
        }
        else
        {
            dynamicId = replyThingsId;
        }
        content = replyOwner + content;

        int timeId = sq.newData(dt.ToString("yyyy-MM-dd HH:mm:ss"), es.STYLE_REPLY_TIME);
        int replyId = sq.newData(content, es.STYLE_REPLY_CONTENT);
        sq.link(replyId, userId, es.STYLE_NULL);
        sq.link(replyId, timeId, es.STYLE_NULL);
        sq.link(dynamicId, replyId, es.STYLE_NULL);
        sq.link(replyId, dynamicId, es.STYLE_NULL);
    }

    public void deleteDynamic(int dynamicId)
    {
        DataTable getReplyId = new DataTable();
        sq.getFirstIdLinkSecondId(dynamicId, es.STYLE_REPLY_CONTENT, getReplyId);
        for (int i = 0; i < getReplyId.Rows.Count; i++)
        {
            int replyId = (int)getReplyId.Rows[i][0];
            deleteReply(replyId);
        }
        DataTable getTimeId = new DataTable();
        sq.getFirstIdLinkSecondId(dynamicId, es.STYLE_DYNAMIC_EDIT_TIME, getTimeId);
        int timeId = (int)getTimeId.Rows[0][0];
        sq.deleteData(timeId);
        sq.deleteData(dynamicId);
    }

    public void deleteReply(int replyId)
    {
        DataTable getTimeId = new DataTable();
        sq.getFirstIdLinkSecondId(replyId, es.STYLE_REPLY_TIME, getTimeId);
        int timeId = (int)getTimeId.Rows[0][0];
        sq.deleteData(timeId);
        sq.deleteData(replyId);
    }
}