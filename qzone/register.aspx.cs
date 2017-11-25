using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text, password = txtPassword.Text, passwordConfirm = txtPasswordConfirm.Text, identifying = txtIdentifying.Text;
        string realIdentifying = Session["identifying"].ToString();
        if (identifying != realIdentifying)
        {
            Response.Write("<script>alert('验证码错误')</script>");
            return;
        }
        string whiteChar = es.CHARS_NUM + es.CHARS_ABC_SMALL + es.CHARS_ABC_BIG + "_";
        int returnBack = es.checkInputWhite(username, whiteChar, es.LEN_USERNAME);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('用户名不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('用户名最多含有'+"+es.LEN_USERNAME+"+'个字符')</script>");
                return;
            case 3:
                Response.Write("<script>alert('用户名只能由数字、字母及下划线组成')</script>");
                return;
            default:
                break;
        }
        
        if (password != passwordConfirm)
        {
            Response.Write("<script>alert('两次输入的密码不一致')</script>");
            return;
        }

        returnBack = es.checkInputWhite(password, whiteChar, es.LEN_PASSWORD);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('密码不能为空')</script>");
                return;
            case 2:
                Response.Write("<script>alert('密码最多含有'+" + es.LEN_PASSWORD + "+'个字符')</script>");
                return;
            case 3:
                Response.Write("<script>alert('密码只能由数字、字母及下划线组成')</script>");
                return;
            default:
                break;
        }
        returnBack = us.addUser(username, password);
        switch (returnBack)
        {
            case 1:
                Response.Write("<script>alert('该用户名已被注册')</script>");
                return;
            default:
                break;
        }
        Response.Write("<script>alert('注册成功'); location='Login.aspx';</script>");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}