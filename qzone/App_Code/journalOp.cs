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

    private int getContentId(int journalId)
    {
        DataTable getContentId = new DataTable();
        sq.getFirstIdLinkSecondId(journalId, es.STYLE_JOURNAL_DATA, getContentId);
        int contentId = (int)getContentId.Rows[0][0];

        return contentId;
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

    public void getJournalAll(int journalId, DataTable transport)
    {
        transport.Clear();

        DataRow tempRow = transport.NewRow();

        tempRow["id"] = journalId;

        tempRow["title"] = sq.getDataContent(journalId).ToString().Trim();

        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(journalId, es.STYLE_JOURNAL_DATA, temp);
        string content = temp.Rows[0][0].ToString().Trim();
        tempRow["content"] = content;

        transport.Rows.Add(tempRow);
    }

    public void deleteJournal(int journalId)
    {
        int contentId = (int)getContentId(journalId);
        sq.deleteData(contentId);
        sq.deleteData(journalId);
    }

    public void changeJournal(int journalId, string title, string content)
    {
        int contentId = (int)getContentId(journalId);
        sq.changeDataContent(journalId, title);
        sq.changeDataContent(contentId, content);
    }
}