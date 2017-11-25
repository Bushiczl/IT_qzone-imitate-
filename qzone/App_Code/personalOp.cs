using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// personal 的摘要说明
/// </summary>
public class personalOp
{
    static sqlSever sq = new sqlSever();
    static essential es = new essential();

    public personalOp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
   
    public object getNickName(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_NICK_NAME, temp);
        if (temp.Rows.Count > 0)
        {
            string nickName = temp.Rows[0][0].ToString();
            return nickName;
        }
        return null;
    }

    public int getSex(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_SEX, temp);
        if (temp.Rows.Count > 0)
        {
            bool sex = (bool)temp.Rows[0][0];
            if (sex) return 1; else return 0;
        }
        return -1;
    }

    public object getBirthday(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_BIRTHDAY, temp);
        if (temp.Rows.Count > 0)
        {
            string birthday = temp.Rows[0][0].ToString();
            return birthday;
        }
        return null;
    }

    public int getBloodType(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_BLOOD_TYPE, temp);
        if (temp.Rows.Count > 0)
        {
            int bloodType = int.Parse(temp.Rows[0][0].ToString());
            return bloodType;
        }
        return -1;
    }

    public object getJob(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_JOB, temp);
        if (temp.Rows.Count > 0)
        {
            string job = temp.Rows[0][0].ToString();
            return job;
        }
        return null;
    }

    public object getIntroduction(int userId)
    {
        DataTable temp = new DataTable();
        sq.getFirstIdLinkData(userId, es.STYLE_PERSONAL_INTRODUCTION, temp);
        if (temp.Rows.Count > 0)
        {
            string introduction = temp.Rows[0][0].ToString();
            return introduction;
        }
        return null;
    }

    public void changeNickName(int userId,string nickName)
    {
        if (getNickName(userId) == null)
        {
            int newdataId = sq.newData(nickName, es.STYLE_PERSONAL_NICK_NAME);
            sq.link(userId, newdataId,es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_NICK_NAME, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, nickName);
        }
    }

    public void changeSex(int userId,int sex)
    {
        if (getSex(userId) == -1)
        {
            int newdataId = sq.newData(sex, es.STYLE_PERSONAL_SEX);
            sq.link(userId, newdataId, es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_SEX, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, sex);
        }
    }

    public void changeBirthday(int userId, string birthday)
    {
        if (getBirthday(userId) == null)
        {
            int newdataId = sq.newData(birthday, es.STYLE_PERSONAL_BIRTHDAY);
            sq.link(userId, newdataId, es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_BIRTHDAY, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, birthday);
        }
    }

    public void changeBloodType(int userId, int bloodType)
    {
        if (getBloodType(userId) == -1)
        {
            int newdataId = sq.newData(bloodType, es.STYLE_PERSONAL_BLOOD_TYPE);
            sq.link(userId, newdataId, es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_BLOOD_TYPE, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, bloodType);
        }
    }

    public void changeJob(int userId, string job)
    {
        if (getJob(userId) == null)
        {
            int newdataId = sq.newData(job, es.STYLE_PERSONAL_JOB);
            sq.link(userId, newdataId, es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_JOB, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, job);
        }
    }

    public void changeIntroduction(int userId, string introduction)
    {
        if (getIntroduction(userId) == null)
        {
            int newdataId = sq.newData(introduction, es.STYLE_PERSONAL_INTRODUCTION);
            sq.link(userId, newdataId, es.STYLE_NULL);
        }
        else
        {
            DataTable temp = new DataTable();
            sq.getFirstIdLinkSecondId(userId, es.STYLE_PERSONAL_INTRODUCTION, temp);
            int linkId = int.Parse(temp.Rows[0][0].ToString());
            sq.changeDataContent(linkId, introduction);
        }
    }

    public int checkBirthday(string input)
    {
        if (input.Length != 10) return 1;
        if (input[4]!='-'&& input[7] != '-')
        {
            return 1;
        }
        string temp = input;
        temp=temp.Replace("-", "0");
        int returnBack = es.checkInputWhite(temp, es.CHARS_NUM);
        if (returnBack != 0) return 1;
        int year = 0, month = 0, day = 0;
        int[] md = { 100, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        for (int i = 0; i < 4; i++)
        {
            year = year * 10 + temp[i]- '0';
        }
        for (int i = 5; i <= 6; i++)
        {
            month = month * 10 + temp[i] - '0';
        }
        for (int i = 8; i <= 9; i++)
        {
            day = day * 10 + temp[i] - '0';
        }
        if (year > int.Parse(System.DateTime.Now.Year.ToString())-1) return 1;
        if (month > 12) return 1;
        md[2] += es.isLeapYear(year);
        if (day > md[month]) return 1;
        return 0;
    }
}