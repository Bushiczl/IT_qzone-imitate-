using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// essential 的摘要说明
/// </summary>
public class Essential
{
    static SqlOp sq = new SqlOp();

    public Essential()
    {
        
    }

    private bool isAlpha(char ch)
    {
        if (ch >= 'a' && ch <= 'z') return true;
        if (ch >= 'A' && ch <= 'Z') return true;
        return false;
    }
    private bool isNumber(char ch)
    {
        if (ch >= '0' && ch <= '9') return true;
        return false;
    }

    private bool isIllegalChar(char ch)
    {
        switch (ch)
        {
            case '"':
            case (char)27:
                return true;
        }
        return false;
    }

    public int checkInput(string input, int maxLen = -1)
    {
        int len = input.Length;
        if (len == 0) return 2;
        if (maxLen != -1)
        {
            if (len > maxLen) return 3;
        }
        for (int i = 0; i < len; i++)
        {
            if (!isAlpha(input[i]) && !isNumber(input[i])) return 1;
        }
        return 0;
    }

    public int checkEmail(string input, int maxLen = -1)
    {
        int len = input.Length;
        int tempAT = 0, tempPoint = 0;
        if (len == 0) return 2;
        if (maxLen != -1)
        {
            if (len > maxLen) return 3;
        }
        for (int i = 0; i < len; i++)
        {
            if (input[i] == '@')
            {
                if (tempPoint > 0 || tempAT > 0) return 1;
                tempAT = tempAT + 1;

            }
            else if (input[i] == '.')
            {
                if (tempPoint > 0) return 1;
                tempPoint = tempPoint + 1;
            }
            else if (!isAlpha(input[i]) && !isNumber(input[i])) return 1;
        }
        if (tempAT != 1 || tempPoint != 1) return 1;
        return 0;
    }
    public int checkInputUTF8(string input, int maxlen = -1)
    {
        int len = input.Length;
        if (len == 0) return 2;
        if (maxlen != -1)
        {
            if (len > maxlen) return 3;
        }
        for (int i = 0; i < len; i++)
        {
            if (isIllegalChar(input[i])) return 1;
        }
        return 0;
    }


    public int nowUserId()
    {
        if (HttpContext.Current.Session["id"] == null) return -2;
        return int.Parse(HttpContext.Current.Session["id"].ToString());
    }

    public bool identifyCheck(string inputWord)
    {
        string realWord = HttpContext.Current.Session["identifying"].ToString();
        if (realWord == inputWord) return true;
        return false;
    }

    public bool isManager(int id)
    {
        string sql = "select id from adminList where userId = " + id;
        System.Data.DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        int count = dt.Rows.Count;
        return count > 0;
    }

    public int objectIsInt(object input,int state = 1)
    {
        if (input == null)
        {
            return 1;
        }
        string temp = input.ToString();
        int len = temp.Length;
        if (len > 8)
        {
            return 2;
        }
        for (int i = 0; i < len; i++)
        {
            if (!isNumber(temp[i])) return 3;
        }
        return 0;
    }

    public int howManyBorrowPeople(int bookId)
    {
        string sql = "select from borrowList where bookId = " + bookId;
        DataTable dt = new DataTable();
        sq.sqlSelect(sql, dt);
        return dt.Rows.Count;
    }
}