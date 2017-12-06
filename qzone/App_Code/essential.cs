using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// essential 的摘要说明
/// </summary>
public class essential
{
    static sqlSever sq = new sqlSever();

    public essential()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public int LEN_USERNAME = 20;
    public int LEN_PASSWORD = 30;

    public string CHARS_NUM = "0123456789";
    public string CHARS_ABC_SMALL = "abcdefghijklmnopqrstuvwxyz";
    public string CHARS_ABC_BIG = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string COOKIES_USER = "user";
    public string COOKIES_USER_ID = "userId";
    public string COOKIES_USER_USERNAME = "userUsername";
    public string COOKIES_USER_PASSWORD = "userPassword";

    public string SESSION_USER_ID = "userId";
    public string SESSION_RPT_PAGE = "page";

    public string STYLE_NULL = "null";
    public string STYLE_USER_NAME = "username";
    public string STYLE_USER_PASSWORD = "password";
    public string STYLE_USER_EMAIL = "email";
    public string STYLE_USER_COOKIES = "userIdInCookies";
    public string STYLE_UNTOPWD = "UnToPwd";
    public string STYLE_PERSONAL_NICK_NAME = "nickName";
    public string STYLE_PERSONAL_SEX = "sex";
    public string STYLE_PERSONAL_BIRTHDAY = "birthday";
    public string STYLE_PERSONAL_BLOOD_TYPE = "bloodType";
    public string STYLE_PERSONAL_JOB = "job";
    public string STYLE_PERSONAL_INTRODUCTION = "introduction";
    public string STYLE_JOURNAL_TITLE = "journalTitle";
    public string STYLE_JOURNAL_DATA = "journalData";
    public string STYLE_JOURNAL_REPLY_CONTENT = "journalReplyContent";
    public string STYLE_JOURNAL_REPLY_TIME = "journalReplyTime";
    public string STYLE_IMAGESURL = "imagesUrl";
    public string STYLE_DYNAMIC_CONTENT = "dynamicContent";
    public string STYLE_DYNAMIC_EDIT_TIME = "dynamicEditTime";
    public string STYLE_REPLY_CONTENT = "replyContent";
    public string STYLE_REPLY_TIME = "replyEditTime";
    public string STYLE_MESSAGE_CONTENT = "messageContent";
    public string STYLE_MESSAGE_TIME = "messageTime";

    public string STYLE_LINES_FRIEND = "linesFriend";

    public string PATH_IMAGES = "~/images/";

    public string ETC_DATETIME_CHANGE_METHOD = "yyyy-MM-dd HH:mm:ss";

    HttpCookie cookie;

    public int isLeapYear(int input)
    {
        if (input % 400 == 0) return 1;
        if (input % 100 == 0) return 0;
        if (input % 4 == 0) return 1;
        return 0;
    }

    public bool isInt(object input)
    {
        if (input == null) return false;
        string temp = input.ToString();
        return checkInputWhite(temp, CHARS_NUM, 8) == 0;
    }

    public int checkInputWhite(string input, string whiteChars, int maxLen = -1)
    {
        int len = input.Length;
        if (len == 0) return 1; // 空字符串
        if (maxLen != -1 && len > maxLen) return 2; // 超长
        for (int i = 0; i < len; i++)
        {
            if (!whiteChars.Contains(input[i])) return 3; // 出现白名单外字符
        }

        return 0;
    }
    public int checkInputBlack(string input, string blackChars, int maxLen = -1)
    {
        int len = input.Length;
        if (len == 0) return 1; // 空字符串
        if (maxLen != -1 && len > maxLen) return 2; // 超长
        for (int i = 0; i < len; i++)
        {
            if (blackChars.Contains(input[i])) return 3; // 出现黑名单内字符
        }
        return 0;
    }

    public string usefulXssDefendReplace(string input)
    {
        string output=input;
        output = output.Replace("<", "&#60;");
        output = output.Replace(">", "&#62;");
        return output;
    }

    public string datetimeToString(DateTime input)
    {
        return input.ToString(ETC_DATETIME_CHANGE_METHOD);
    }

    public string getRandomString(int int_NumberLength)
    {
        Random random = new Random();
        char[] chars = (CHARS_ABC_BIG + CHARS_ABC_SMALL + CHARS_NUM).ToArray();
        string validateCode = string.Empty;
        for (int i = 0; i < int_NumberLength; i++)
            validateCode += chars[random.Next(0, chars.Length)].ToString();
        return validateCode;
    }
}