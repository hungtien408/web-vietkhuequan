<%@ Page Title="" Language="C#" MasterPageFile="~/en/site.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Việt Khuê Quân</title>
    <meta name="description" content="Việt Khuê Quân" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrap-product">
        <div class="head">
            <img src="../assets/images/img-pro.jpg" alt="" />
            <div class="container">
                <div class="content-head">
                    <h1>sản phẩm - dịch vụ</h1>
                    <p>Nắm rõ thị trường Việt Nam và hiểu rõ nhu cầu của Khách Hàng Nhật Bản đã và đang thâm nhập thị trường Việt. Chúng tôi đang có các Giải pháp về kinh doanh, công nghệ giải quyết bài toán nhân lực và giảm chi phí sau:</p>
                </div>
            </div>
        </div>
        <div class="content container">
            <section>
                <div class="head">
                    <span>01</span>
                    <div class="intro">
                        <h1>giải pháp <b>kinh doanh</b></h1>
                        <p>Tuỳ mô hình của Khách hàng, chúng tôi sẽ xây dựng kế hoạch marketing, call center.. để đưa sản phậm/ dịch vụ thâm nhập hiệu quả nhất.</p>
                    </div>
                </div>
                <div class="item-cate">
                    <div class="item">
                        <a href="products-detail.aspx"><img src="../assets/images/item-1.jpg" alt="" /></a>
                        <div class="content">
                            <a href="products-detail.aspx"><h3>Marketing</h3></a>
                            <ul>
                                <li>Xây dựng và thực hiện kế hoạch quảng bá</li>
                                <li>Xây dựng và thực hiện kế hoạch quảng cáo</li>
                            </ul>
                        </div>
                    </div>
                    <div class="item">
                        <a href="products-detail.aspx"><img src="../assets/images/item-2.jpg" alt="" /></a>
                        <div class="content">
                            <a href="products-detail.aspx"><h3>Call Center</h3></a>
                            <ul>
                                <li>Xây dựng quy trình nghiệp vụ chăm sóc khách hàng</li>
                                <li>Cung cấp nhân sự</li>
                                <li>Cung cấp thiết bị và hệ thống vận hành</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </section>
            <section>
                <div class="head">
                    <span>02</span>
                    <div class="intro">
                        <h1>giải pháp <b>công nghệ thông tin</b></h1>
                        <p>Lắng nghe nhu cầu và nghiệp vụ của Khách hàng, chúng tôi sẽ lập qui trình và xây dựng các giải pháp IT phù hợp.</p>
                    </div>
                </div>
                <div class="item-cate">
                    <div class="item">
                        <a href="products-detail.aspx"><img src="../assets/images/item-3.jpg" alt="" /></a>
                        <div class="content">
                            <a href="products-detail.aspx"><h3>Ecommerce</h3></a>
                            <ul>
                                <li>Xây dựng giải pháp cho gian hàng điện tử</li>
                                <li>Xây dựng qui trình nghiệp vụ, quản lý</li>
                                <li>Xây dựng giải pháp thanh toán, báo cáo kinh doanh</li>
                            </ul>
                        </div>
                    </div>
                    <div class="item">
                        <a href="products-detail.aspx"><img src="../assets/images/item-4.jpg" alt="" /></a>
                        <div class="content">
                            <a href="products-detail.aspx"><h3>Data Input</h3></a>
                            <ul>
                                <li>Xây dựng hệ thống đáng ứng nhu cầu nhập liệu</li>
                                <li>Xây dựng hệ thống báo cáo</li>
                                <li>Cung cấp nhân sự</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

