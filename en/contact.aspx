<%@ Page Title="" Language="C#" MasterPageFile="~/en/site.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Việt Khuê Quân</title>
    <meta name="description" content="Việt Khuê Quân" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="wrap-contact">
        <div class="pull-left">
            <h1>VIET KHUE QUAN Co.,Ltd</h1>
            <div class="item">
                <p>Representative Office</p>
                <ul>
                    <li class="lc">67 Lê Trung Nghĩa, P.12, Q. Tân Bình, TP. HCM</li>
                    <li class="ph">08-73-012-247</li>
                </ul>
            </div>
            <div class="item">
                <p>Headquarters</p>
                <ul>
                    <li class="lc">Số 08 Hai Bà Trưng, P. Phước Hiệp, Tỉnh Bà Rịa - Vũng Tàu</li>
                    <li class="ph">08-73-012-247</li>
                </ul>
            </div>
            <div class="form-contact">
                <h3>Contact</h3>
                <div class="form-group">
                    <label>Company Name <span>*</span></label>
                    <div class="form-input">
                        <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="lb-error" ID="RequiredFieldValidator2" runat="server"
                            ValidationGroup="SendContact" ControlToValidate="txtCompany" ErrorMessage="Thông tin bắt buộc!"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label>Position <span>*</span></label>
                    <div class="form-input">
                        <asp:TextBox ID="txtChucVu" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="lb-error" ID="RequiredFieldValidator4" runat="server"
                            ValidationGroup="SendContact" ControlToValidate="txtChucVu" ErrorMessage="Thông tin bắt buộc!"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label>Full Name <span>*</span></label>
                    <div class="form-input">
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="lb-error" ID="RequiredFieldValidator5" runat="server"
                            ValidationGroup="SendContact" ControlToValidate="txtFullName" ErrorMessage="Thông tin bắt buộc!"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label>Email <span>*</span></label>
                    <div class="form-input">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="lb-error" ID="RegularExpressionValidator1"
                            runat="server" ValidationGroup="SendContact" ControlToValidate="txtEmail" ErrorMessage="Email không đúng!"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator CssClass="lb-error" ID="RequiredFieldValidator3" runat="server"
                            ValidationGroup="SendContact" ControlToValidate="txtEmail" ErrorMessage="Thông tin bắt buộc!"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label>Message</label>
                    <div class="form-input">
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="lb-error" ID="RequiredFieldValidator1" runat="server"
                            ValidationGroup="SendContact" ControlToValidate="txtContent" ErrorMessage="Thông tin bắt buộc!"
                            Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button ID="btnGui" runat="server" Text="SEND" ValidationGroup="SendContact" OnClick="btnGui_Click" />
                <span><i>*</i> Thông tin bắt buộc</span>
            </div>
        </div>
        <div class="pull-right">
            <img src="../assets/images/contact.jpg" alt="" />
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d979.7856057573516!2d106.65264542922424!3d10.800402016867514!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752937d11f18df%3A0xe6df04f468c64899!2zTMOqIFRydW5nIE5naMSpYSwgUGjGsOG7nW5nIDEyLCBUw6JuIELDrG5oLCBI4buTIENow60gTWluaCwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1491988637898" width="100%" height="300" frameborder="0" style="border: 0" allowfullscreen></iframe>
        </div>
    </div>
    <div class="clr"></div>
</asp:Content>

