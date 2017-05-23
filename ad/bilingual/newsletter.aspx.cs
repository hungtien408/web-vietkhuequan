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

    #endregion

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void RadGrid1_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        
    }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "PerformInsert" || e.CommandName == "Update")
        {
            var command = e.CommandName;
            var row = command == "PerformInsert" ? (GridEditFormInsertItem)e.Item : (GridEditFormItem)e.Item;
            //var FileNewsletterImage = (RadUpload)row.FindControl("FileNewsletterImage");

            string strEmail1 = ((TextBox)row.FindControl("txtEmail")).Text.Trim();
            string strFullName = ((TextBox)row.FindControl("txtFullName")).Text.Trim();
            string strDiaChi = ((TextBox)row.FindControl("txtDiaChi")).Text.Trim();
            string strPhone = ((TextBox)row.FindControl("txtPhone")).Text.Trim();
            string strContent = ((TextBox)row.FindControl("txtContent")).Text.Trim();
            //string strNewsletterCategory = ((RadComboBox)row.FindControl("ddlGroupMail")).SelectedValue;
            var oNewsletter = new Newsletter();
            if (e.CommandName == "PerformInsert")
            {
                oNewsletter.NewsletterInsert(
                        strEmail1,
                        strFullName,
                        strDiaChi,
                        strPhone,
                        strContent,
                        Request.QueryString["PI"].ToString()
                        );
                RadGrid1.Rebind();
            }
            else
            {
                var dsUpdateParam = ObjectDataSource1.UpdateParameters;
                var strEmail = row.GetDataKeyValue("Email").ToString();

                dsUpdateParam["Email"].DefaultValue = strEmail;
                dsUpdateParam["FullName"].DefaultValue = strFullName;
                dsUpdateParam["DiaChi"].DefaultValue = strDiaChi;
                dsUpdateParam["Phone"].DefaultValue = strPhone;
                dsUpdateParam["Content"].DefaultValue = strContent;
                dsUpdateParam["NewsletterCategoryID"].DefaultValue = Request.QueryString["PI"].ToString();
            }
        }
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
    }
    #endregion
}