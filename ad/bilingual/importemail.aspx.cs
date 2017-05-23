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
using Excel;

public partial class ad_single_partner : System.Web.UI.Page
{
    private Common cmd = new Common();

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    protected void btnImport_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (FileImport.UploadedFiles.Count > 0)
        {
            string FileName = Path.GetFileName(FileImport.UploadedFiles[0].FileName);
            //string FolderPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
            var strFullPath = Server.MapPath("~/Temp/" + FileName);

            //FileImport.UploadedFiles[0].SaveAs(strFullPath);
            var oNewletter = new Newsletter();
            var oNewletterCategory = new NewsletterCategory();
            var dvExc = ExelDataSelectAll(strFullPath).DefaultView;

            int i = 1;
            foreach (DataRowView drv in dvExc)
            {
                i++;
                try
                {
                    string strGroupName, strFullName, strEmail, strPhone, strNote;

                    if (drv["GroupName"] != null)
                    {
                        strGroupName = drv["GroupName"].ToString().Trim();
                    }
                    else
                    {
                        continue;
                    }

                    if (drv["FullName"] != null)
                    {
                        strFullName = drv["FullName"].ToString().Trim();
                    }
                    else
                    {
                        continue;
                    }

                    if (drv["Email"] != null)
                    {
                        strEmail = drv["Email"].ToString().Trim();
                    }
                    else
                    {
                        continue;
                    }

                    if (drv["Phone"] != null)
                    {
                        strPhone = drv["Phone"].ToString().Trim();
                    }
                    else
                    {
                        continue;
                    }

                    if (drv["Note"] != null)
                    {
                        strNote = drv["Note"].ToString().Trim();
                    }
                    else
                    {
                        continue;
                    }

                    oNewletterCategory.NewsletterCategoryInsert(strGroupName);
                    oNewletter.NewsletterInsertImport(strEmail, strFullName, "", strPhone, strNote, strGroupName);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "File excel không đúng template. ";
                }
            }
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Import thành công. ";
            if (File.Exists(strFullPath))
                File.Delete(strFullPath);
        }
        else
        {
            lblMessage.Text = "Chọn file để import.";
        }
    }
    public DataTable ExelDataSelectAll(string sFileName)
    {
        FileStream stream = File.Open(sFileName, FileMode.Open, FileAccess.Read);
        IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        reader.IsFirstRowAsColumnNames = true;
        DataSet dataset = reader.AsDataSet();

        DataTable tbTemplate = dataset.Tables[0];

        if (!tbTemplate.Columns.Contains("KEYWORD") && !tbTemplate.Columns.Contains("CLICK"))
        {
            lblMessage.Text = "File excel không đúng template.";
        }

        return tbTemplate;
    }
}