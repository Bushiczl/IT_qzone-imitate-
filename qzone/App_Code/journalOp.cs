using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// journalOp 的摘要说明
/// </summary>
public class journalOp
{
    static sqlSever sq = new sqlSever();
    static essential es = new essential();

    public journalOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public void newJournal(int userId, string title, string content)
    {
        int titleId = sq.newData(title, es.STYLE_JOURNAL_TITLE);
        int contentId = sq.newData(content, es.STYLE_JOURNAL_DATA);
        sq.link(userId, titleId, es.STYLE_NULL);
        sq.link(titleId, contentId, es.STYLE_NULL);
    }

    public void getAllIdAndTitle(int userId,DataTable transport)
    {
        sq.getFirstIdLinkAll(userId, es.STYLE_JOURNAL_TITLE, transport);
        transport.Columns["secondId"].ColumnName = "id";
        transport.Columns["data"].ColumnName = "title";
        for (int i = 0; i < transport.Rows.Count; i++)
        {
            transport.Rows[i][1] = es.usefulXssDefendReplace(transport.Rows[i][1].ToString().Trim());
        }
    }
}