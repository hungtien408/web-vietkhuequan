<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/adminEn.master" AutoEventWireup="true"
    CodeFile="sendmail.aspx.cs" Inherits="ad_single_partner" %>

<%@ Register TagPrefix="asp" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <link href="../assets/styles/sreenshort.css" rel="stylesheet" type="text/css" />
    <script src="../assets/js/sreenshort.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tableView = null;
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }

        function RowMouseOver(sender, eventArgs) {
            var selectedRows = sender.get_masterTableView().get_selectedItems();
            var elem = $get(eventArgs.get_id());
            if (selectedRows.length > 0)
                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedID = selectedRows[i].get_id();

                    if (selectedID != eventArgs.get_id())
                        elem.className += (" rgSelectedRow");
                }
            else
                elem.className += (" rgSelectedRow");
        }

        function RowMouseOut(sender, eventArgs) {
            var className = "rgSelectedRow";
            var elem = $get(eventArgs.get_id());

            var selectedRows = sender.get_masterTableView().get_selectedItems();

            if (selectedRows.length > 0)
                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedID = selectedRows[i].get_id();
                    if (selectedID != eventArgs.get_id())
                        removeCssClass(className, elem);
                }
            else
                removeCssClass(className, elem);
        }

        function removeCssClass(className, element) {
            element.className = element.className.replace(className, "").replace(/^\s+/, '').replace(/\s+$/, '');
        }

        function RadComboBox1_SelectedIndexChanged(sender, args) {
            tableView.set_pageSize(sender.get_value());
        }

        function changePage(argument) {
            tableView.page(argument);
        }

        function RadNumericTextBox1_ValueChanged(sender, args) {
            tableView.page(sender.get_value());
        }

        function conditionalPostback(sender, eventArgs) {
            if (eventArgs.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToWordButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToPdfButton") >= 0)
                eventArgs.set_enableAjax(false);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">

    <h3 class="mainTitle">
        <img alt="" src="../assets/images/partner.png" class="vam" />
        Kết Nối VKQ</h3>
    <asp:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">
        <asp:Label ID="lblSucess" runat="server" ForeColor="Green"></asp:Label>
        <asp:Panel ID="Panel2" runat="server">
            <h4>Kết Nối VKQ
            </h4>
            <hr />
            <table class="search">
                <tr>
                    <td class="left">Group Mail</td>
                    <td>
                        <asp:RadAutoCompleteBox RenderMode="Lightweight" runat="server" ID="rabGroupMail"
                            EmptyMessage="Nhập tên group"
                            DataSourceID="ObjectDataSource2" DataTextField="NewsletterCategoryName" DataValueField="NewsletterCategoryID" InputType="Token" Width="500"
                            DropDownWidth="150px" >
                        </asp:RadAutoCompleteBox>
                    </td>
                </tr>
                <tr>
                    <td class="left">Email</td>
                    <td>
                        <asp:RadAutoCompleteBox RenderMode="Lightweight" runat="server" ID="rabEmail"
                            EmptyMessage="Nhập email"
                            DataSourceID="ObjectDataSource1" DataTextField="Email" InputType="Token" Width="500"
                            DropDownWidth="150px" AllowCustomEntry="true">
                        </asp:RadAutoCompleteBox>
                    </td>
                </tr>
                <tr>
                    <td class="left">Tiêu đề E-Mail
                    </td>
                    <td>
                        <asp:RadTextBox ID="txtSubject" runat="server" Width="500px" EmptyMessage="Subject..." ValidationGroup="SendEmailVKQ">
                        </asp:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Thông tin bắt buộc" ValidationGroup="SendEmailVKQ" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="left">Nội dung
                    </td>
                    <td>
                        <asp:RadEditor ID="txtBody" runat="server" Skin="Office2007">
                            <ImageManager DeletePaths="~/Uploads/Image/" MaxUploadFileSize="5000000" UploadPaths="~/Uploads/Image/" ViewPaths="~/Uploads/Image/" />
                            <FlashManager DeletePaths="~/Uploads/Video/" UploadPaths="~/Uploads/Video/" ViewPaths="~/Uploads/Video/" />
                            <DocumentManager DeletePaths="~/Uploads/File/" MaxUploadFileSize="10000000" UploadPaths="~/Uploads/File/" ViewPaths="~/Uploads/File/" SearchPatterns="*.doc, *.txt, *.docx, *.xls, *.xlsx, *.pdf,*.zip,*.rar" />
                            <MediaManager DeletePaths="~/Uploads/Media/" UploadPaths="~/Uploads/Media/" ViewPaths="~/Uploads/Media/" />
                            <TemplateManager DeletePaths="~/Uploads/Template/" UploadPaths="~/Uploads/Template/"
                                ViewPaths="~/Uploads/Template/" />
                        </asp:RadEditor>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:RadButton ID="btnSendEmail" runat="server" Text="Gởi Email" OnClick="btnSendEmail_Click" ValidationGroup="SendEmailVKQ">
                        </asp:RadButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <br />

        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
    </asp:RadAjaxPanel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="NewsletterSelectAll" TypeName="TLLib.Newsletter">
        <SelectParameters>
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="NewsletterCategoryID" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="NewsletterCategorySelectAll" TypeName="TLLib.NewsletterCategory"></asp:ObjectDataSource>
    <asp:RadProgressManager ID="RadProgressManager1" runat="server" />
    <asp:RadProgressArea ID="ProgressArea1" runat="server" Culture="vi-VN" DisplayCancelButton="True"
        HeaderText="Đang tải" Skin="Office2007" Style="position: fixed; top: 50% !important; left: 50% !important; margin: -93px 0 0 -188px;" />
</asp:Content>
