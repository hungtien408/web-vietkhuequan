using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool SendMail(string strHost, int iPort, string strMailFrom, string strPassword, string strMailTo, string strCC, string strSubject, string strBody, bool bEnableSsl)
    {
        bool SendSuccess = false;
        try
        {
            var lstMailTo = strMailTo.Replace(';', ',').Split(',');
            var lstCC = strCC.Replace(';', ',').Split(',');

            NetworkCredential loginInfo = new NetworkCredential(strMailFrom, strPassword);
            SmtpClient client = new SmtpClient(strHost, iPort);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.EnableSsl = bEnableSsl;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(strMailFrom);

                foreach (string strTo in lstMailTo)
                    if (!string.IsNullOrEmpty(strTo.Trim()))
                        msg.To.Add(new MailAddress(strTo));

                foreach (string strCC1 in lstCC)
                    if (!string.IsNullOrEmpty(strCC1.Trim()))
                        msg.CC.Add(new MailAddress(strCC1));

                msg.Subject = strSubject;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            SendSuccess = true;
        }
        catch
        {
            SendSuccess = false;
        }
        return SendSuccess;
    }

    public bool SendMail(string strHost, int iPort, string strMailFrom, string strUserName, string strPassword, string strMailTo, string strCC, string strSubject, string strBody, bool bEnableSsl)
    {
        bool SendSuccess = false;
        try
        {
            var lstMailTo = strMailTo.Replace(';', ',').Split(',');
            var lstCC = strCC.Replace(';', ',').Split(',');

            NetworkCredential loginInfo = new NetworkCredential(strUserName, strPassword);
            SmtpClient client = new SmtpClient(strHost, iPort);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.EnableSsl = bEnableSsl;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(strMailFrom);

                foreach (string strTo in lstMailTo)
                    if (!string.IsNullOrEmpty(strTo.Trim()))
                        msg.To.Add(new MailAddress(strTo));

                foreach (string strCC1 in lstCC)
                    if (!string.IsNullOrEmpty(strCC1.Trim()))
                        msg.CC.Add(new MailAddress(strCC1));

                msg.Subject = strSubject;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            SendSuccess = true;
        }
        catch
        {
            SendSuccess = false;
        }
        return SendSuccess;
    }

    public bool SendMail(string strHost, int iPort, string strMailFrom, string strDisplayName, string strUserName, string strPassword, string strMailTo, string strCC, string strSubject, string strBody, bool bEnableSsl)
    {
        bool SendSuccess = false;
        try
        {
            var lstMailTo = strMailTo.Replace(';', ',').Split(',');
            var lstCC = strCC.Replace(';', ',').Split(',');

            NetworkCredential loginInfo = new NetworkCredential(strUserName, strPassword);
            SmtpClient client = new SmtpClient(strHost, iPort);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.EnableSsl = bEnableSsl;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(strMailFrom, strDisplayName);

                foreach (string strTo in lstMailTo)
                    if (!string.IsNullOrEmpty(strTo.Trim()))
                        msg.To.Add(new MailAddress(strTo));

                foreach (string strCC1 in lstCC)
                    if (!string.IsNullOrEmpty(strCC1.Trim()))
                        msg.CC.Add(new MailAddress(strCC1));

                msg.Subject = strSubject;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            SendSuccess = true;
        }
        catch
        {
            SendSuccess = false;
        }
        return SendSuccess;
    }

    public bool SendMail(string strHost, int iPort, string strMailFrom, string strUserName, string strPassword, List<string> lstMailTo, List<string> lstCC, List<string> lstAttachment, string strSubject, string strBody, bool bEnableSsl)
    {
        bool SendSuccess = false;
        try
        {
            var loginInfo = new NetworkCredential(strUserName, strPassword);
            var client = new SmtpClient(strHost, iPort);
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.EnableSsl = bEnableSsl;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(strMailFrom);

                foreach (string strMailTo in lstMailTo)
                    msg.To.Add(new MailAddress(strMailTo.Trim()));

                if (lstCC != null)
                    foreach (string strCC in lstCC)
                        msg.CC.Add(new MailAddress(strCC));

                if (lstAttachment != null)
                {
                    if (lstAttachment.Count > 0)
                        foreach (string strFileName in lstAttachment)
                            msg.Attachments.Add(new Attachment(strFileName));
                }
                msg.Subject = strSubject;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            SendSuccess = true;
        }
        catch (Exception ex)
        {
            SendSuccess = false;
        }
        return SendSuccess;
    }

    public bool SendMail(string strHost, int iPort, string strMailFrom, string strDisplayName, string strUserName, string strPassword, List<string> lstMailTo, List<string> lstCC, List<string> lstAttachment, string strSubject, string strBody, bool bEnableSsl)
    {
        bool SendSuccess = false;
        try
        {
            var loginInfo = new NetworkCredential(strUserName, strPassword);
            var client = new SmtpClient(strHost, iPort);
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.EnableSsl = bEnableSsl;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(strMailFrom, strDisplayName);

                foreach (string strMailTo in lstMailTo)
                    msg.To.Add(new MailAddress(strMailTo.Trim()));

                if (lstCC != null)
                    foreach (string strCC in lstCC)
                        msg.CC.Add(new MailAddress(strCC));

                if (lstAttachment != null)
                {
                    if (lstAttachment.Count > 0)
                        foreach (string strFileName in lstAttachment)
                            msg.Attachments.Add(new Attachment(strFileName));
                }
                msg.Subject = strSubject;
                msg.Body = strBody;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
            SendSuccess = true;
        }
        catch (Exception ex)
        {
            SendSuccess = false;
        }
        return SendSuccess;
    }
}