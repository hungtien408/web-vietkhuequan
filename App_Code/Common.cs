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
}