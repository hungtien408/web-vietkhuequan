using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    private Common cmd = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            sendEmail();
        }
    }
    private void sendEmail()
    {
        string msg = "<h3>VKQ: Liên Hệ</h3><br/>";
        msg += "<b>Tên công ty: </b>" + txtCompany.Text.Trim().ToString() + "<br />";
        msg += "<b>Chức vụ: </b>" + txtChucVu.Text.Trim().ToString() + "<br />";
        msg += "<b>Họ tên: </b>" + txtFullName.Text.Trim().ToString() + "<br />";
        msg += "<b>Email: </b>" + txtEmail.Text.Trim().ToString() + "<br />";
        msg += "<b>Nội dung: </b>" + txtContent.Text.Trim().ToString();
        cmd.SendMail("mail.vkq.com.vn", 587, "info@vkq.com.vn", "Vietkhuequan020", "info@vkq.com.vn", "", "Liên Hệ VKQ", msg, false);
        //cmd.SendMail("mail.japanex.net", 587, "contact@japanex.net", "Betterlife020", "contact@japanex.net", "", "Liên Hệ VKQ", msg, false);
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "runtime", " $(document).ready(function () {alert('Cám ơn bạn đã liên lạc với VKQ !')});", true);

        txtCompany.Text = "";
        txtChucVu.Text = "";
        txtFullName.Text = "";
        txtEmail.Text = "";
        txtContent.Text = "";
    }
}