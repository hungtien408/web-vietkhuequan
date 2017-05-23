<%@ Page Title="" Language="C#" MasterPageFile="~/ad/template/adminEn.master" AutoEventWireup="true"
    CodeFile="importemail.aspx.cs" Inherits="ad_single_partner" %>

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
        //On insert and update buttons click temporarily disables ajax to perform upload actions
        function conditionalPostback(sender, eventArgs) {
            var theRegexp = new RegExp("\.lnkUpdate$|\.lnkUpdateTop$|\.PerformInsertButton$", "ig");
            if (eventArgs.get_eventTarget().match(theRegexp)) {
                var upload = $find(window['UploadId']);

                //AJAX is disabled only if file is selected for upload
                if (upload.getFileInputs()[0].value != "") {
                    eventArgs.set_enableAjax(false);
                }
            }
            else if (eventArgs.get_eventTarget().indexOf("ExportToExcelButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToWordButton") >= 0 || eventArgs.get_eventTarget().indexOf("ExportToPdfButton") >= 0)
                eventArgs.set_enableAjax(false);
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
        Import Email</h3>
    <%--<asp:RadAjaxPanel ID="RadAjaxPanel1" runat="server" ClientEvents-OnRequestStart="conditionalPostback">

        
    </asp:RadAjaxPanel>--%>
    <asp:Panel ID="Panel2" runat="server">
            <h4>Import Email
            </h4>
            <hr />
            <table class="search">
                <tr>
                    <td class="left">File Excel</td>
                    <td>
                        <%--<asp:RadUpload ID="FileImport" runat="server" ControlObjectsVisibility="None" Culture="vi-VN"
                            Language="vi-VN" InputSize="69" AllowedFileExtensions=".xls,.xlsx" />--%>
                        <asp:RadAsyncUpload ID="FileImport" MultipleFileSelection="Disabled" runat="server" TargetFolder="~/Temp" TemporaryFolder="~/Temp" InputSize="69" AllowedFileExtensions=".xls,.xlsx"></asp:RadAsyncUpload>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Sai định dạng (*.xls, *.xlsx)"
                            ClientValidationFunction="validateRadUpload" Display="Dynamic"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:RadButton ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click">
                        </asp:RadButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <br />

        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>

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
