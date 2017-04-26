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
        //if (!HttpContext.Current.User.IsInRole("Quản Lý Kết Nối IEI_Email Letter"))
        //{
        //    Response.Redirect("access-denied.aspx");
        //}
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

            string strNewsletterCategoryName = ((TextBox)row.FindControl("txtNewsletterCategoryName")).Text.Trim();
            var oNewsletter = new NewsletterCategory();
            if (e.CommandName == "PerformInsert")
            {
                oNewsletter.NewsletterCategoryInsert(strNewsletterCategoryName);
                RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strNewsletterCategoryID = row.GetDataKeyValue("NewsletterCategoryID").ToString();
                //var strOldNewsletterImage = ((HiddenField)row.FindControl("hdnNewsletterImage")).Value;
                //var strOldImagePath = Server.MapPath("~/res/partner/" + strOldNewsletterImage);

                dsUpdateParam["NewsletterCategoryName"].DefaultValue = strNewsletterCategoryName;
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
        //if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        //{
        //    var itemtype = e.Item.ItemType;
        //    var row = itemtype == GridItemType.EditFormItem ? (GridEditFormItem)e.Item : (GridEditFormInsertItem)e.Item;
        //    var FileNewsletterImage = (RadUpload)row.FindControl("FileNewsletterImage");

        //    RadAjaxPanel1.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", FileNewsletterImage.ClientID));
        //}
    }
    #endregion

}