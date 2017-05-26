using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using TLLib;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Threading;

public partial class ad_single_partner : System.Web.UI.Page
{
    private Common cmd = new Common();
    #region Common Method

    protected void DropDownList_DataBound(object sender, EventArgs e)
    {
        var cbo = (RadComboBox)sender;
        cbo.Items.Insert(0, new RadComboBoxItem(""));
    }

    //void DeleteImage(string strNewsletterImage)
    //{
    //    if (!string.IsNullOrEmpty(strNewsletterImage))
    //    {
    //        string strOldImagePath = Server.MapPath("~/res/partner/" + strNewsletterImage);
    //        if (File.Exists(strOldImagePath))
    //            File.Delete(strOldImagePath);
    //    }
    //}

    #endregion

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        List<string> value = new List<string>();
        foreach (var item in rabGroupMail.Entries)
        {
            value.Add(((AutoCompleteBoxEntry)item).Value);
        }

        Newsletter a = new Newsletter();
        var data = a.NewsletterSelectAllByGroup(string.Join(",", value.ToArray())).DefaultView;
        List<string> email = new List<string>();
        foreach (var item in data)
        {
            email.Add(((DataRowView)item)["Email"].ToString());
        }

        foreach (var item in rabEmail.Entries)
        {
            email.Add(((AutoCompleteBoxEntry)item).Text);
        }

        if (email.Count == 0)
        {
            lblSucess.ForeColor = System.Drawing.Color.Red;
            lblSucess.Text = "Vui lòng chọn email.";
        }
        else
        {
            string strSubject = txtSubject.Text.Trim();
            string strBody = FCKEditorFix.Fix(txtBody.Content.Trim());
            foreach (var item in email)
            {
                Thread threadEmail = new Thread(delegate ()
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        SendEmail(item, strSubject, strBody);
                    }
                });
                Thread.Sleep(100);
                threadEmail.Start();
            }

            lblSucess.ForeColor = System.Drawing.Color.Green;
            lblSucess.Text = "Email đã được gửi đi.";

            rabEmail.Entries.Clear();
            rabGroupMail.Entries.Clear();
            txtSubject.Text = "";
            txtBody.Content = "";
        }
    }

    private void SendEmail(string mailTo, string subject, string body)
    {
        try
        {
            string strHost = "smtp.gmail.com";
            int iPort = 587;
            string strMailFrom = "noreply@betterlifejp.com";
            string strPassword = "12345678";

            string strMailTo = mailTo;
            string strCC = "";
            string strSubject = subject;
            string strBody = body;
            bool bEnableSsl = true;

            cmd.SendMail(
                strHost,
                iPort,
                strMailFrom,
                strPassword,
                strMailTo,
                strCC,
                strSubject,
                strBody,
                bEnableSsl);
        }
        catch (Exception e)
        {

        }

    }
}