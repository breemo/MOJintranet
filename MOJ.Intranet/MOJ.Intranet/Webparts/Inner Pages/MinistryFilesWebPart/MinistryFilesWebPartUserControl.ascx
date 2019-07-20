<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinistryFilesWebPartUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.MinistryFilesWebPart.MinistryFilesWebPartUserControl" %>

<div class="container-fullwidth clearfix">

    <!-- Post Content
                    ============================================= -->
    <div class="postcontent nobottommargin col_last clearfix">
        <div class="boxleftbor">
            <h4>مكتبة الوزارة
            </h4>



            <div id="posts" class="small-thumbs alt">

                <div class="booksearchitems">



                    <div class="row">

                        <!--Item book-->
                        <%--<div class="col-md-4 col-sm-6">

                            <div class="boxsearchbook">

                                <div class="imgboxbook">
                                    <img src="http://moj-dev:2019/Style%20Library/MOJTheme/images/filebbok.png" />
                                </div>
                                <div class="titlebook">
                                    <h4>اسم الكتاب


                                    </h4>
                                    <span class="desco">هذا هو وصف قصير للكتاب
                                                        والكاتب
                                    </span>
                                </div>

                                <div class="uploadediv">
                                    <p>
                                        تم الرفع بواسطة
                                                        <span>محمد أكمل</span>

                                    </p>


                                </div>
                                <div class="dowmloadbook">
                                    <div class="row d-flex justify-content-center mt-3">


                                        <input type="button" class="btnclass radix" value="تحميل">
                                    </div>
                                </div>



                            </div>

                        </div>--%>

                        <asp:Repeater ID="grdBookslsts" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>


                                <div class="col-md-4 col-sm-6">

                                    <div class="boxsearchbook">

                                        <div class="imgboxbook">
                                            <img src='<%# Eval("BookImage") %>' />
                                        </div>
                                        <div class="titlebook">
                                            <h4>
                                                <%# Eval("BookTitle") %>
                                            </h4>
                                            <span class="desco">
                                                <%# Eval("BookDescAr") %>
                                            </span>
                                        </div>

                                        <div class="uploadediv">
                                            <p>
                                                تم الرفع بواسطة
                                                        <span><%# Eval("CreatedBy") %></span>

                                            </p>


                                        </div>
                                        <div class="dowmloadbook">
                                            <div class="row d-flex justify-content-center mt-3">



                                                <a runat="server" id="link" href='<%# Eval("AttachmentsInfo") %>'>

                                                    <input type="button" class="btnclass radix" value="تحميل">
                                                </a>
                                            </div>
                                        </div>



                                    </div>

                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>

                </div>
                <div class="pagi">
                    <ul class="pagination">
                        <li class="page-item">
                            <a class="page-link pageright" href="#">
                                <i class="icon-angle-right"></i>
                            </a>
                        </li>

                      

                            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                                <ItemTemplate>

                                    <li class="page-item">

                                        <asp:LinkButton ID="btnPage"
                                             CssClass="page-link"
                                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                            runat="server" ForeColor="White" Font-Bold="True">
                                         <%# Container.DataItem %> </asp:LinkButton>

                                    </li>





                                </ItemTemplate>
                            </asp:Repeater>

                    
                        <li class="page-item">
                            <a class="page-link pageleft" href="#">
                                <i class="icon-angle-left"></i>
                            </a>
                        </li>
                    </ul>
                </div>

            </div>
            <!-- #posts end -->


            <%--                            <div class="pagi">
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
                            </div>--%>
        </div>


    </div>
    <!-- .postcontent end -->
    <!-- Sidebar
                    ============================================= -->
    <div class="sidebar nobottommargin clearfix">
        <div class="sidebar-widgets-wrap">

            <div id="sidebarmenubox" class="sidebarmenubox">
                <div class="searchboxinside">

                    <div class="formdiv formby">
                        <h5>البحث بواسطة
                        </h5>


                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    الفئة
                                </label>


                            </div>
                            <div class="col-md-9">
                                <select class="form-control">
                                    <option>اختر</option>
                                    <option>2</option>
                                    <option>3</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    اسم الكتاب
                                </label>

                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder="">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    كاتب
                                </label>

                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder="">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    تم الرفع بواسطة
                                </label>


                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder=" ">
                            </div>
                        </div>

                        <div class="row d-flex justify-content-center mt-3">


                            <input type="button" class="btnclass radix" value="بحث">
                            <input type="button" class="btnclass radix" value="واضح">
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- .sidebar end -->

</div>
