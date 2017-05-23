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
    public void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //if (e.Item is GridCommandItem)
        //{
        //    GridCommandItem commandItem = (e.Item as GridCommandItem);
        //    PlaceHolder container = (PlaceHolder)commandItem.FindControl("PlaceHolder1");
        //    Label label = new Label();
        //    label.Text = "&nbsp;&nbsp;";

        //    container.Controls.Add(label);

        //    for (int i = 65; i <= 65 + 25; i++)
        //    {
        //        LinkButton linkButton1 = new LinkButton();

        //        LiteralControl lc = new LiteralControl("&nbsp;&nbsp;");

        //        linkButton1.Text = "" + (char)i;

        //        linkButton1.CommandName = "alpha";
        //        linkButton1.CommandArgument = "" + (char)i;

        //        container.Controls.Add(linkButton1);
        //        container.Controls.Add(lc);
        //    }

        //    LiteralControl lcLast = new LiteralControl("&nbsp;");
        //    container.Controls.Add(lcLast);

        //    LinkButton linkButtonAll = new LinkButton();
        //    linkButtonAll.Text = "Tất cả";
        //    linkButtonAll.CommandName = "NoFilter";
        //    container.Controls.Add(linkButtonAll);
        //}
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        //if (e.CommandName == "alpha" || e.CommandName == "NoFilter")
        //{
        //    String value = null;
        //    switch (e.CommandName)
        //    {
        //        case ("alpha"):
        //            {
        //                value = string.Format("{0}%", e.CommandArgument);
        //                break;
        //            }
        //        case ("NoFilter"):
        //            {
        //                value = "%";
        //                break;
        //            }
        //    }
        //    ObjectDataSource1.SelectParameters["NewsletterName"].DefaultValue = value;
        //    ObjectDataSource1.DataBind();
        //    RadGrid1.Rebind();
        //}
        //else if (e.CommandName == "QuickUpdate")
        //{
        //    string NewsletterID, Priority, IsAvailable;
        //    var oNewsletter = new Newsletter();

        //    foreach (GridDataItem item in RadGrid1.Items)
        //    {
        //        NewsletterID = item.GetDataKeyValue("NewsletterID").ToString();
        //        Priority = ((RadNumericTextBox)item.FindControl("txtPriority")).Text.Trim();
        //        IsAvailable = ((CheckBox)item.FindControl("chkIsAvailable")).Checked.ToString();

        //        oNewsletter.NewsletterQuickUpdate(
        //            NewsletterID,
        //            IsAvailable,
        //            Priority
        //        );
        //    }
        //}
        //else if (e.CommandName == "DeleteSelected")
        //{
        //    var oNewsletter = new Newsletter();

        //    foreach (GridDataItem item in RadGrid1.SelectedItems)
        //    {
        //        string strNewsletterImage = ((HiddenField)item.FindControl("hdnNewsletterImage")).Value;

        //        if (!string.IsNullOrEmpty(strNewsletterImage))
        //        {
        //            string strSavePath = Server.MapPath("~/res/partner/" + strNewsletterImage);
        //            if (File.Exists(strSavePath))
        //                File.Delete(strSavePath);
        //        }
        //    }
        //}
        if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            var command = e.CommandName;
            var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
            //var FileNewsletterImage = (RadUpload)row.FindControl("FileNewsletterImage");

            string strEmail1 = ((TextBox)row.FindControl("txtEmail")).Text.Trim();
            string strDiaChi = ((TextBox)row.FindControl("txtDiaChi")).Text.Trim();
            string strContent = ((TextBox)row.FindControl("txtContent")).Text.Trim();
            string strNewsletterCategory = ((RadComboBox)row.FindControl("ddlGroupMail")).SelectedValue;
            var oNewsletter = new Newsletter();
            if (e.CommandName == "PerformInsert")
            {
                //oNewsletter.NewsletterInsert(
                //        strEmail1,
                //        strDiaChi,
                //        strContent,
                //        strNewsletterCategory
                //        );
                //RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strEmail = row.GetDataKeyValue("Email").ToString();
                //var strOldNewsletterImage = ((HiddenField)row.FindControl("hdnNewsletterImage")).Value;
                //var strOldImagePath = Server.MapPath("~/res/partner/" + strOldNewsletterImage);

                dsUpdateParam["Email"].DefaultValue = strEmail;
                dsUpdateParam["DiaChi"].DefaultValue = strDiaChi;
                dsUpdateParam["Content"].DefaultValue = strContent;
                dsUpdateParam["NewsletterCategoryID"].DefaultValue = strNewsletterCategory;
                //dsUpdateParam["ConvertedNewsletterName"].DefaultValue = strConvertedNewsletterName;
                //dsUpdateParam["NewsletterImage"].DefaultValue = strNewsletterImage;
                //dsUpdateParam["IsAvailable"].DefaultValue = strIsAvailable;
            }
        }
        //if (e.CommandName == "DeleteImage")
        //{
        //    var oNewsletter = new Newsletter();
        //    var lnkDeleteImage = (LinkButton)e.CommandSource;
        //    var s = lnkDeleteImage.Attributes["rel"].ToString().Split('#');
        //    var strNewsletterID = s[0];
        //    var strNewsletterImage = s[1];

        //    oNewsletter.NewsletterImageDelete(strNewsletterID);
        //    DeleteImage(strNewsletterImage);
        //    RadGrid1.Rebind();
        //}
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            var itemtype = e.Item.ItemType;
            var row = itemtype == GridItemType.EditFormItem ? (GridEditFormItem)e.Item : (GridEditFormInsertItem)e.Item;

            var Email = ((HiddenField)row.FindControl("hdnEmail")).Value;
            var ddlGroupMail = (RadComboBox)row.FindControl("ddlGroupMail");

            if (!string.IsNullOrEmpty(Email))
            {
                var dv = new Newsletter().NewsletterSelectOne(Email).DefaultView;
                //dv.RowFilter = "Email = " + Email.ToString();

                if (!string.IsNullOrEmpty(dv[0]["NewsletterCategoryID"].ToString()))
                    ddlGroupMail.SelectedValue = dv[0]["NewsletterCategoryID"].ToString();
            }


            //RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileNewsletterImage.ClientID));
        }
        //if (e.Item is GridDataItem)
        //{
        //    var dsSelectParam = ObjectDataSource1.SelectParameters;
        //    //var ddlGroupMail = (RadComboBox)e.Item.FindControl("ddlGroupMail");
        //    string list = "";
        //    if (ddlGroupMail.CheckedItems.Count > 0)
        //    {
        //        foreach (var item in ddlGroupMail.CheckedItems)
        //        {
        //            list += item.Value + ",";
        //        }
        //        dsSelectParam["NewsletterCategoryID"].DefaultValue = list;
        //    }
        //}
    }
    #endregion

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        if (RadGrid1.SelectedItems.Count > 0)
        {
            foreach (GridDataItem item in RadGrid1.SelectedItems)
            {
                if (item.Selected == true)
                {
                    lblSucess.Text = "";

                    var dvEmail = (ObjectDataSource1.Select() as DataView);
                    //string strHost = "mail.vkq.com.vn";
                    //int iPort = 587;
                    //string strMailFrom = "info@vkq.com.vn";
                    //string strPassword = "Vietkhuequan020";
                    string strHost = "smtp.gmail.com";
                    int iPort = 587;
                    string strMailFrom = "noreply@betterlifejp.com";
                    string strPassword = "12345678";

                    string strMailTo = item["Email"].Text.ToString();
                    string strCC = "";
                    string strSubject = txtSubject.Text.Trim();
                    string strBody = FCKEditorFix.Fix(txtBody.Content.Trim());
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
                        bEnableSsl
                    );

                    lblSucess.Text = "Email đã được gửi đi.";
                    lblSucess.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
        else
        {
            lblSucess.Text = "Vui lòng chọn email.";
            lblSucess.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        var dsSelectParam = ObjectDataSource1.SelectParameters;
        string list = "";
        if (ddlGroupMail.CheckedItems.Count > 0)
        {
            foreach (var item in ddlGroupMail.CheckedItems)
            {
                list += item.Value + ",";
            }
            list = list.Substring(0, list.LastIndexOf(","));
            dsSelectParam["NewsletterCategoryID"].DefaultValue = list;
        }
    }
}