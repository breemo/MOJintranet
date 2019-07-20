<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.NewsList.NewsListUserControl" %>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadPopularNews%>" />
</h4>

<div class="newslidertopdiv">
    <section id="newslidertop">
        <div class="container">
            <div id="carouselReviews" class="carousel slide" data-ride="carousel">
                <asp:Literal ID="lblPopularNewsCarousel" runat="server" Text="" />
                <asp:Literal ID="lblPopularNewsCarouselInner" runat="server" Text="" />

                <a class="carousel-control-prev" href="#carouselReviews" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Previous%>" /></span>
                </a>
                <a class="carousel-control-next" href="#carouselReviews" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Next%>" /></span>
                </a>
            </div>
        </div>
    </section>
</div>

<div class="searchboxne searchboxne2 ">
    <h4>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadSrchNews%>" />
    </h4>
    <div class="row d-flex justify-content-center align-items-center">
        <div class="col-md-10">
            <div class="row">
                <div class="col-md-1">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, year%>" />
                </div>
                <div class="col-md-5">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlYear">
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, month%>" />
                </div>
                <div class="col-md-5">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMonth">
                        <asp:ListItem Text="<%$ Resources:Resource, select%>" Value="0"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month1%>" Value="1"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month2%>" Value="2"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month3%>" Value="3"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month4%>" Value="4"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month5%>" Value="5"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month6%>" Value="6"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month7%>" Value="7"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month8%>" Value="8"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month9%>" Value="9"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month10%>" Value="10"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month11%>" Value="11"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month12%>" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnSrch" runat="server" Text='<%$ Resources:Resource, btnSearch%>' class="btnclass" OnClick="btnSrch_Click" />
            </div>
        </div>
    </div>

    <h4>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadNews%>" />
    </h4>
    <div id="posts" class="small-thumbs alt">


        <asp:GridView ID="grdNewsLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="No Archives Found"
            BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
            EnableModelValidation="True" AllowPaging="true" OnPageIndexChanging="grdNewsLst_PageIndexChanging"
            OnRowDataBound="grdNewsLst_RowDataBound" PageSize="2">
            <PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
                Mode="NumericFirstLast" PageButtonCount="5" />
            <PagerStyle HorizontalAlign="Center" CssClass="gridview" />
            <EmptyDataRowStyle Font-Bold="true" ForeColor="#333" Font-Size="40" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="entry entryitem clearfix newsitemxlist">
                            <div class="entry-image ">
                                <img src="<%# Eval("Picture") %>" />
                            </div>
                            <div class="entry-c entryitemx">

                                <span class="dateut">
                                    <%#  Convert.ToDateTime(Eval("Date")).ToString("dddd")%>, <%#  Convert.ToDateTime(Eval("Date")).ToString("dd")%> <%#  Convert.ToDateTime(Eval("Date")).ToString("MMM")%>  <%#  Convert.ToDateTime(Eval("Date")).ToString("yyyy")%> </span>
                                <h6>
                                    <a href="<%= SPContext.Current.RootFolderUrl %>/Details.aspx?id=<%# Eval("ID") %>&type=news"><%# Eval("Title") %>
                                    </a>
                                </h6>
                                <p>
                                    <%# Eval("Body") %>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--        <div class="entry entryitem clearfix newsitemxlist">
            <div class="entry-image ">

                <img src="http://moj-dev:2019/MOJGallery/_t/3_jpg.jpg" />
            </div>
            <div class="entry-c entryitemx">

                <span class="dateut">الإثنين, 10 ديسمبر  2012 </span>
                <h6>
                    <a href="#">دعوة وزير العدل لحضور توقيع المعاهدة الدولية لاتفاقات التسوية للوساطة بسنغافورة
                    </a>
                </h6>
                <p>
                    أستقبل معالي سلطان بن سعيد البادي وزير العدل في مكتبه بالوزارة في أبو ظبي صباح اليوم سعادة صامويل تان سفير سنغافورة لدى الدولة
                </p>

            </div>
        </div>--%>

        <%--                                <div class="entry entryitem clearfix newsitemxlist">
                                    <div class="entry-image ">

                                        <img src="http://moj-dev:2019/MOJGallery/dubai_eid.jpg" />
                                    </div>
                                    <div class="entry-c entryitemx">

                                        <span class="dateut"> الإثنين, 10 ديسمبر  2012 </span>
                                        <h6>
                                            <a href="#">
                                                رئيس الدولة يصدر مرسوماً اتحادياً بتعيين قاضيتين في القضاء الاتحادي

                                            </a>
                                        </h6>
                                        <p>
                                            أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة "حفظه الله" المرسوم الاتحادي رقم 27 لسنة 2019 بتعيين القاضي خديجة خميس خليفة الملص، والقاضي سلامة راشد سالم الكتبي في القضاء
                                        </p>

                                    </div>
                                </div>


                                <div class="entry entryitem clearfix newsitemxlist">
                                    <div class="entry-image ">
                                        <img src="http://moj-dev:2019/MOJGallery/_t/2_jpg.jpg" />

                                    </div>
                                    <div class="entry-c entryitemx">

                                        <span class="dateut"> الإثنين, 10 ديسمبر  2012 </span>
                                        <h6>
                                            <a href="#">
                                                رئيس الدولة يصدر مرسوما اتحادياً بتعيين 13 وكيل نيابة من أبناء الدولة
                                            </a>
                                        </h6>
                                        <p>
                                            أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة - حفظه الله – المرسوم الاتحادي رقم 26 لسنة 2019م، بتعيين وكلاء نيابة عامة بالنيابة الاتحادية، ويبلغ عددهم 13 وكيل نيابة
                                        </p>

                                    </div>
                                </div>


                                <div class="entry entryitem clearfix newsitemxlist">
                                    <div class="entry-image ">

                                        <img src="http://moj-dev:2019/MOJGallery/_t/4_jpg.jpg" />
                                    </div>
                                    <div class="entry-c entryitemx">

                                        <span class="dateut"> الإثنين, 10 ديسمبر  2012 </span>
                                        <h6>
                                            <a href="#">
                                                سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني
                                            </a>
                                        </h6>
                                        <p>
                                            تقدم معالي سلطان سعيد البادي وزير العدل المشاركين في مسيرة اليوم الرياضي الوطني والتي أقيمت حول مباني وزارة العدل والمحاكم الاتحادية بمدينة خليفة في أبو ظبي، بناء على توجيهات
                                        </p>

                                    </div>
                                </div>


                                <div class="entry entryitem clearfix newsitemxlist">
                                    <div class="entry-image ">

                                        <img src="http://moj-dev:2019/MOJGallery/_t/4_jpg.jpg" />
                                    </div>
                                    <div class="entry-c entryitemx">

                                        <span class="dateut"> الإثنين, 10 ديسمبر  2012 </span>
                                        <h6>
                                            <a href="#">
                                                مجلس الوزراء يعتمد تعديلات غير مسبوقة للارتقاء بالبنية التشريعية والقضائية في الدولة
                                            </a>
                                        </h6>
                                        <p>
                                            اعتمد مجلس الوزراء قراراً بشأن اللائحة التنظيمية لقانون الإجراءات المدنية يتضمن تعديلات هامة تواكب التوجهات الحكومية وتساهم في تحقيق رؤية الإمارات 2021
                                        </p>

                                    </div>
                                </div>--%>
    </div>
    <!-- #posts end -->


    <div class="pagi">
        <ul class="pagination">
            <li class="page-item">
                <a class="page-link pageright" href="#">
                    <i class="icon-angle-right"></i>
                </a>
            </li>
            <li class="page-item"><a class="page-link activepage" href="#">1</a></li>
            <li class="page-item"><a class="page-link" href="#">2</a></li>
            <li class="page-item"><a class="page-link" href="#">3</a></li>
            <li class="page-item"><a class="page-link" href="#">4</a></li>
            <li class="page-item"><a class="page-link" href="#">5</a></li>
            <li class="page-item"><a class="page-link" href="#">6</a></li>
            <li class="page-item"><a class="page-link" href="#">7</a></li>
            <li class="page-item"><a class="page-link" href="#">8</a></li>
            <li class="page-item"><a class="page-link" href="#">9</a></li>
            <li class="page-item"><a class="page-link" href="#">10</a></li>
            <li class="page-item">
                <a class="page-link pageleft" href="#">
                    <i class="icon-angle-left"></i>
                </a>
            </li>
        </ul>
    </div>



    <script src="/Style%20Library/MOJ-Theme/js/functions.js"></script>
