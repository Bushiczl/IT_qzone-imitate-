using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personal : System.Web.UI.Page
{
    static essential es = new essential();
    static user us = new user();
    static sqlSever sq = new sqlSever();
    static personalOp pe = new personalOp();
    
    HttpCookie cookie;
    int userId, hostId, userLevel;
    object nickName, birthday, job, introduction;
    int sex, bloodType;
    object temp;

    string NOSET = "未设置", LAZY = "这个人很懒，什么都没留下";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!us.foolCheck()) return;
        userId = int.Parse(Session[es.SESSION_USER_ID].ToString());
        hostId = int.Parse(Request.QueryString["id"]);
        userLevel = us.getUserLevel(userId, hostId);

        if (userLevel != 0) btnChange.Visible = false;

        
            nickName = pe.getNickName(hostId);
            sex = pe.getSex(hostId);
            birthday = pe.getBirthday(hostId);
            bloodType = pe.getBloodType(hostId);
            job = pe.getJob(hostId);
            introduction = pe.getIntroduction(hostId);
        

        if (nickName != null)
        {
            lblNickName.Text = es.usefulXssDefendReplace(nickName.ToString().Trim());
        }
        else
        {
            lblNickName.Text = NOSET;
        }
        switch (sex)
        {
            case -1:
                lblSex.Text = NOSET;
                break;
            case 1:
                lblSex.Text = "男";
                break;
            case 0:
                lblSex.Text = "女";
                break;
            default:
                break;
        }
        if (birthday != null)
        {
            lblBirthday.Text = es.usefulXssDefendReplace(birthday.ToString().Trim());
        }
        else
        {
            lblBirthday.Text = NOSET;
        }
        switch (bloodType)
        {
            case -1:
                lblBloodType.Text = NOSET;
                break;
            case 0:
                lblBloodType.Text = "A型";
                break;
            case 1:
                lblBloodType.Text = "B型";
                break;
            case 2:
                lblBloodType.Text = "AB型";
                break;
            case 3:
                lblBloodType.Text = "O型";
                break;
            case 4:
                lblBloodType.Text = "其他";
                break;
        }
        if (job != null)
        {
            lblJob.Text = es.usefulXssDefendReplace(job.ToString().Trim());
        }
        else
        {
            lblJob.Text = NOSET;
        }
        if (introduction != null)
        {
            txtIntroduction_Show.Text = introduction.ToString().Trim();
        }
        else
        {
            txtIntroduction_Show.Text = NOSET;
        }
    }


    protected void btnChange_Click(object sender, EventArgs e)
    {
        pnlChange.Visible = !(pnlShow.Visible = false);
        if (nickName != null)
        {
            txtNickName.Text = nickName.ToString().Trim();
        }
        else
        {
            txtNickName.Text = "";
        }
        switch (sex)
        {
            case -1:
                rdbMan.Checked = rdbWoman.Checked = false;
                break;
            case 1:
                rdbMan.Checked = !(rdbWoman.Checked = false);
                break;
            case 0:
                rdbWoman.Checked = !(rdbMan.Checked = false);
                break;
            default:
                break;
        }
        if (birthday != null)
        {
            txtBirthday.Text = birthday.ToString().Trim();
        }
        else
        {
            txtBirthday.Text = "";
        }
        if (bloodType != -1)
        {
            ddlBloodType.SelectedIndex = bloodType;
        }
        if (job != null)
        {
            txtJob.Text = job.ToString().Trim();
        }
        else
        {
            txtJob.Text = "";
        }
        if (introduction != null)
        {
            txtIntroduction.Text = introduction.ToString().Trim();
        }
        else
        {
            txtIntroduction.Text = "";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string nickName = txtNickName.Text;
        int returnBack;
        if (nickName != "")
        {
            returnBack = es.checkInputBlack(nickName, "", 30);
            switch (returnBack)
            {
                case 0:
                    break;
                case 2:
                    Response.Write("<script>alert('昵称最多包含30个字符')</script>");
                    return;
                default:
                    break;
            }
        }
        int sex = -1;
        if (rdbMan.Checked) sex = 1;
        if (rdbWoman.Checked) sex = 0;
        string birthday=txtBirthday.Text;
        if (birthday != "")
        {
            returnBack = pe.checkBirthday(birthday);
            switch (returnBack)
            {
                case 1:
                    Response.Write("<script>alert('请按0000-00-00的格式输入')</script>");
                    return;
                default:
                    break;
            }
        }
        int bloodType = ddlBloodType.SelectedIndex;
        string job=txtJob.Text;
        if (job != "")
        {
            returnBack = es.checkInputBlack(job, "", 10);
            switch (returnBack)
            {
                case 0:
                    break;
                case 2:
                    Response.Write("<script>alert('职业最多包含10个字符')</script>");
                    return;
                default:
                    break;
            }
        }
        string introduction = txtIntroduction.Text;
        if (introduction != "")
        {
            returnBack = es.checkInputBlack(introduction, "", 500);
            switch (returnBack)
            {
                case 0:
                    break;
                case 2:
                    Response.Write("<script>alert('简介最多包含500个字符')</script>");
                    return;
                default:
                    break;
            }
        }

        if (nickName != "")
        {
            pe.changeNickName(hostId, nickName);
        }
        if (sex != -1)
        {
            pe.changeSex(hostId, sex);
        }
        if (birthday != "")
        {
            pe.changeBirthday(hostId, birthday);
        }
        if (bloodType != -1)
        {
            pe.changeBloodType(hostId, bloodType);
        }
        if (job != "")
        {
            pe.changeJob(hostId, job);
        }
        if (introduction != "")
        {
            pe.changeIntroduction(hostId, introduction);
        }
        Response.Redirect(Request.Url.ToString());
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlChange.Visible = !(pnlShow.Visible = true);
    }
}