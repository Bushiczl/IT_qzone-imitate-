using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// message 的摘要说明
/// </summary>
public class messageOp
{
    static sqlSever sq = new sqlSever();
    static essential es = new essential();
    public messageOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public void newMessage(int userId, int hostId, string content)
    {
        content = es.usefulXssDefendReplace(content);
        string username = sq.getDataContent(userId).ToString();
        content = username + "：" + content;
           
        string time = es.datetimeToString(DateTime.Now);
        int contentId = sq.newData(content, es.STYLE_MESSAGE_CONTENT);
        int timeId = sq.newData(time, es.STYLE_MESSAGE_TIME);

        sq.link(hostId, contentId, es.STYLE_NULL);
        sq.link(contentId, timeId, es.STYLE_NULL);
    }

    public void fill(int hostId,DataTable transport)
    {
        transport.Columns.Add("secondId", typeof(Int32));
        transport.Columns.Add("data", typeof(String));
        transport.Columns.Add("time", typeof(DateTime));
        transport.Columns.Add("from", typeof(String));

        DataTable getJournalAll = new DataTable();
        sq.getFirstIdLinkAll(hostId, es.STYLE_JOURNAL_TITLE, getJournalAll);

        for (int i = 0; i < getJournalAll.Rows.Count; i++)
        {
            int journalId = (int)getJournalAll.Rows[i][0];
            string journalTitle = getJournalAll.Rows[i][1].ToString().Trim();
            int temp = transport.Rows.Count;
            sq.getFirstIdLinkAll(journalId, es.STYLE_JOURNAL_REPLY_CONTENT, transport);
            for (int j = temp; j < transport.Rows.Count; j++)
            {
                int replyId = (int)transport.Rows[j][0];
                DataTable getTime = new DataTable();
                sq.getFirstIdLinkData(replyId, es.STYLE_JOURNAL_REPLY_TIME, getTime);
                transport.Rows[j][2] = getTime.Rows[0][0].ToString().Trim();
                transport.Rows[j][3] = "日志《" + journalTitle + "》下的评论";
            }
        }

        int temp2 = transport.Rows.Count;
        sq.getFirstIdLinkAll(hostId, es.STYLE_MESSAGE_CONTENT, transport);
        for (int i = temp2; i < transport.Rows.Count; i++)
        {
            int messageId = (int)transport.Rows[i][0];
            DataTable getTime = new DataTable();
            sq.getFirstIdLinkData(messageId, es.STYLE_MESSAGE_TIME, getTime);
            transport.Rows[i][2] = getTime.Rows[0][0];

            transport.Rows[i][3] = "留言板留言";
        }

        transport.Columns["secondId"].ColumnName = "id";
        transport.Columns["data"].ColumnName = "content";

        DataView dv = transport.DefaultView;
        dv.Sort = "time DESC";//按照time倒序排序
        dv.ToTable();
    }

    public void deleteMessage(int messageId)
    {
        DataTable getTimeId = new DataTable();
        sq.getFirstIdLinkSecondId(messageId, es.STYLE_MESSAGE_TIME, getTimeId);
        int timeId = (int)getTimeId.Rows[0][0];
        sq.deleteData(timeId);
        sq.deleteData(messageId);
    }
}