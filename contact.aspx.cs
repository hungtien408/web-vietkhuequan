﻿using System;
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
            System.Threading.Thread threadEmail = new System.Threading.Thread(delegate ()
            {
                sendEmail();
            });
            threadEmail.Start();

            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "runtime", " $(document).ready(function () {alert('Cám ơn bạn đã liên lạc với VKQ !')});", true);

            txtCompany.Text = "";
            txtChucVu.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtContent.Text = "";
            txtPhone.Text = "";
            txtTitle.Text = "";
        }
    }
    private void sendEmail()
    {
        string msgKH = "The information sent from the customer reached the VKQ server in this mail. It is an automatic delivery mail that is sent at the time.";
        msgKH += "<br/>-------------------------------------------------------<br />";
        msgKH += "VKQ Co., Ltd <br />";
        msgKH += "67 Lê Trung Nghĩa, Phường 12, Quận Tân Bình, Thành phố Hồ Chí Minh, Viet Nam <br />";
        msgKH += "Tel : +84 08 73 012 247 <br />";
        msgKH += "-------------------------------------------------------<br />";
        msgKH += "The following contents have arrived. <br />";
        msgKH += "<b>Company name: </b>" + txtCompany.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Department name: </b>" + txtChucVu.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Title name: </b>" + txtTitle.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Mail address: </b>" + txtEmail.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Phone number: </b>" + txtPhone.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Customer's full name: </b>" + txtFullName.Text.Trim().ToString() + "<br />";
        msgKH += "<b>Content: </b>" + txtContent.Text.Trim().ToString();

        string msg = "The following contents have arrived. <br />";
        msg += "-------------------------------------------------------<br />";
        msg += "<b>Company name: </b>" + txtCompany.Text.Trim().ToString() + "<br />";
        msg += "<b>Department name: </b>" + txtChucVu.Text.Trim().ToString() + "<br />";
        msg += "<b>Title name: </b>" + txtTitle.Text.Trim().ToString() + "<br />";
        msg += "<b>Mail address: </b>" + txtEmail.Text.Trim().ToString() + "<br />";
        msg += "<b>Phone number: </b>" + txtPhone.Text.Trim().ToString() + "<br />";
        msg += "<b>Customer's full name: </b>" + txtFullName.Text.Trim().ToString() + "<br />";
        msg += "<b>Content: </b>" + txtContent.Text.Trim().ToString();

        cmd.SendMail("mail.vkq.com.vn", 587, "info@vkq.com.vn", "Vietkhuequan020", txtEmail.Text.Trim().ToString(), "", "[vkq.com.vn web] Inquiry content confirmation (automatic delivery mail)", msgKH, false);
        cmd.SendMail("mail.vkq.com.vn", 587, "info@vkq.com.vn", "Vietkhuequan020", "info@vkq.com.vn", "badang@vkq.com.vn,s.haku@betterlifejp.com", "[vkq.com.vn web] Inquiry content confirmation", msg, false);

        //cmd.SendMail("mail.japanex.net", 587, "contact@japanex.net", "Betterlife020", "contact@japanex.net", "", "Liên Hệ VKQ", msg, false);

    }
}