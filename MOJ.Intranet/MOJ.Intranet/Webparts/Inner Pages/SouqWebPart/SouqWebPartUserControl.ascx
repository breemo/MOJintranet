<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SouqWebPartUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.SouqWebPart.SouqWebPartUserControl" %>

<meta name="viewport" content="width=device-width, initial-scale=1" />

<div class="container-fullwidth clearfix">

    <!-- Post Content
                    ============================================= -->
    <div class="postcontent nobottommargin col_last clearfix">



        <div class="nflexc">


            <a href="#" class="btnclasscdd radix" data-toggle="modal" data-target=".bs-example-modal-lg">
                <asp:Literal runat="server" Text="<%$ Resources:Resource, AddAdvertisment%>" />
                <span class="icon-plus1 pad"></span>
            </a>




            <div id="MyPopup" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-body">
                        <div class="modal-content adsmodalx">
                            <div class="modal-header">
                                <h4 class="modal-title" id="myModalLabel">
                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, AddNewAdvertisment%>" /></h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="inskdnew modalpordc">
                                        <div class="row rt">

                                            <div class="col-md-12">

                                                <div class="row">

                                                    <div class="col-md-2">
                                                        <label>
                                                            <asp:Literal runat="server" Text="<%$ Resources:Resource, MaterialName%>" /></label>
                                                    </div>

                                                    <div class="col-md-7">
                                                        <input runat="server" id="txtTitle" type="text" class="form-control" placeholder="">
                                                    </div>
                                                </div>


                                            </div>

                                        </div>

                                        <div class="row rt ">

                                            <div class="col-md-2">

                                                <label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, Descreption%>" /></label>


                                            </div>
                                            <div class="col-md-10">

                                                <textarea runat="server" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>






                                            </div>
                                        </div>


                                        <div class="row rt">

                                            <div class="col-md-12">

                                                <div class="row">

                                                    <div class="col-md-2">
                                                        <label>
                                                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Category%>" /></label>
                                                    </div>

                                                    <div class="col-md-7">
                                                        <%--   <select class="form-control">
                                                            <option>الفئة</option>
                                                            <option>الاماره </option>
                                                            <option>الاماره</option>
                                                        </select>--%>
                                                        <asp:DropDownList runat="server" ID="ddlCategorySubmit" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>


                                            </div>

                                        </div>



                                        <div class="row rt ">

                                            <div class="col-md-2">

                                                <label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, Price%>" /></label>


                                            </div>
                                            <div class="col-md-7">


                                                <input runat="server" id="txtprice" type="text" class="form-control" placeholder="">
                                            </div>
                                        </div>


                                        <div class="row rt ">

                                            <div class="col-md-2">

                                                <label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, Picture%>" /></label>


                                            </div>
                                            <div class="col-md-7">

                                                <%--  <div class="input-group file-upload">
                                                    <span class="wpcf7-form-control-wrap file-801 file-input">
                                                        <input type="file" name="file-801" size="40" class="wpcf7-form-control wpcf7-file wpcf7-validates-as-required form-control-file" id="cv_file" accept=".jpg,.jpeg,.png,.gif,.pdf,.doc,.docx,.ppt,.pptx,.odt,.avi,.ogg,.m4a,.mov,.mp3,.mp4,.mpg,.wav,.wmv" aria-required="true" aria-invalid="false">
                                                    </span>
                                                    <label></label>

                                                </div>--%>
                                                <asp:FileUpload ID="fu" runat="server" CssClass="wpcf7-form-control wpcf7-file wpcf7-validates-as-required form-control-file" />
                                            </div>
                                            <%--<div class="col-md-3">
                                                <a href="#" class="uploadbtindiv">تحميل الصورة
                                                                    <span class="icon-upload-alt icpad"></span>
                                                </a>
                                            </div>--%>
                                        </div>



                                        <div class="row rt ">

                                            <div class="col-md-2">

                                                <label>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, ContactPhone%>" /></label>


                                            </div>
                                            <div class="col-md-7">


                                                <input type="text" runat="server" id="txtContactNum" class="form-control" placeholder="">
                                            </div>
                                        </div>








                                        <div class="row rt mt-5 botx">

                                            <%--<a href="#" class="wicnewdiv">تقديم</a>--%>
                                            <asp:Button ID="btnSubmitNewItem" runat="server" CssClass="wicnewdiv" Text="<%$ Resources:Resource, Submit%>" OnClick="btnSubmitNewItem_Click" />




                                            <%--  <a href="#" data-dismiss="modal"
                                                aria-hidden="true" class="wicnewdiv">الغاء

                                            </a>--%>
                                            <asp:Button ID="btnCancel" runat="server" data-dismiss="modal" aria-hidden="true" CssClass="wicnewdiv" Text="<%$ Resources:Resource, cancel%>" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="boxleftbor">
            <h4>
                <asp:Literal runat="server" Text="<%$ Resources:Resource, Souqtitle%>" />
            </h4>



            <div id="posts" class="small-thumbs alt">

                <div class="booksearchitems">



                    <div class="row">

                        <!--Item book-->
                        <%--<div class="col-md-4 col-sm-6">

                            <div class="boxsearchsouq">

                                <div class="imgboxbook">
                                    <img src="images/souq/01.jpg" />
                                </div>
                                <div class="titlebook">
                                    <h4>اسم المنتج


                                    </h4>
                                    <span class="desco">هذا وصف موجز للمنتج لمساعدة العملاء

                                    </span>
                                </div>

                                <div class="uploadebox">
                                    <p>
                                        السعر
                                                        <span>149 درهم </span>

                                    </p>


                                </div>
                                <div class="infoboxbottomnew">
                                    <ul class="ulisit">

                                        <li>البائع<span>: أحمد علي</span></li>
                                        <li>هاتف<span>: 0568888888</span></li>

                                    </ul>
                                </div>



                            </div>

                        </div>--%>

                        <!--Item book-->
                        <!--Item book-->

                        <asp:Repeater ID="grdSouqlsts" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="col-md-4 col-sm-6">

                                    <div class="boxsearchsouq">

                                        <div class="imgboxbook">
                                            <img src="<%# Eval("AttachmentsInfo") %>" />
                                        </div>
                                        <div class="titlebook">
                                            <h4>
                                                <%# Eval("Title") %>
                                            </h4>
                                            <span class="desco"><%# Eval("Description") %>

                                            </span>
                                        </div>

                                        <div class="uploadebox">
                                            <p>
                                                <asp:Literal runat="server" Text="<%$ Resources:Resource, Price%>" />
                                                <span><%# Eval("Price") %></span>

                                            </p>


                                        </div>
                                        <div class="infoboxbottomnew">
                                            <ul class="ulisit">

                                                <li>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, BuyerName%>" /><span>: <%# Eval("CreatedBy") %></span></li>
                                                <li>
                                                    <asp:Literal runat="server" Text="<%$ Resources:Resource, Phone%>" /><span>: <%# Eval("ContactNumber") %></span></li>

                                            </ul>
                                        </div>



                                    </div>

                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr id="trEmpty" runat="server" visible="false">
                                    <td>
                                        <br />
                                    </td>
                                    <td colspan="3" align="center">
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, EmptyData%>" />
                                    </td>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>






                    </div>

                </div>
            </div>
            <!-- #posts end -->


            <div class="pagi">
                <ul class="pagination" id="PaginUI" runat="server">
                    <li class="page-item">
                        <%--<a class="page-link pageright" href="#">--%>
                        <asp:LinkButton ID="lbPrevious" CssClass="page-link pageright" runat="server" OnClick="lbPrevious_Click">
                            <i class="icon-angle-right"></i>
                        </asp:LinkButton>
                        <%--</a>--%>
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
                         <%--<a class="page-link pageleft" href="#">--%>
                            <asp:LinkButton ID="lbNext" CssClass="page-link pageleft" runat="server" OnClick="lbNext_Click">
                                <i class="icon-angle-left"></i>
                            </asp:LinkButton>
                            <%--</a>--%>
                    </li>
                </ul>
            </div>


        </div>


    </div>
    <!-- .postcontent end -->
    <!-- Sidebar
                    ============================================= -->
    <div class="sidebar nobottommargin clearfix">
        <div class="sidebar-widgets-wrap">

            <div id="sidebarmenubox" class="sidebarmenubox filterboxinten">
                <div class="searchboxinside">

                    <div class="formdiv formby">
                        <h5>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Filter%>" />
                        </h5>
                        <div class="row rt">


                            <div class="col-md-12">


                                <%--<ul>

                                    <li>
                                        <input type="checkbox"
                                            class="checkbox"
                                            id="checkbox-1" />
                                        <label for="checkbox-1"
                                            class="checkbox-click-target">
                                            <span class="checkbox-box"></span>سيارات
                                        </label>
                                    </li>
                                    <li>
                                        <input type="checkbox"
                                            class="checkbox"
                                            id="checkbox-2" />
                                        <label for="checkbox-2"
                                            class="checkbox-click-target">
                                            <span class="checkbox-box"></span>أثاث المنزل
                                        </label>

                                    </li>

                                    <li>
                                        <input type="checkbox"
                                            class="checkbox"
                                            id="checkbox-3" />
                                        <label for="checkbox-3"
                                            class="checkbox-click-target">
                                            <span class="checkbox-box"></span>وجبات رئيسية
                                        </label>
                                    </li>

                                    <li>
                                        <input type="checkbox"
                                            class="checkbox"
                                            id="checkbox-3" />
                                        <label for="checkbox-3"
                                            class="checkbox-click-target">
                                            <span class="checkbox-box"></span>الآخرين
                                        </label>
                                    </li>
                                </ul>--%>
                                <asp:CheckBoxList ID="cbCategory" CssClass="checkbox-click-target" OnSelectedIndexChanged="OnCheckBox_Changed" AutoPostBack="true" RepeatDirection="Vertical" runat="server" Width="100%">
                                </asp:CheckBoxList>



                            </div>
                        </div>




                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- .sidebar end -->

</div>

<script>
    $(document).ready(function () {
        $('.file-upload label').on('click', function (event) {
            event.preventDefault();
            /* Act on the event */
            $(this).parents('.file-upload').find('.form-control-file').trigger('click');
        });
        $('.form-control-file').on('change', function (event) {
            event.preventDefault();
            /* Act on the event */
            var fileName = event.target.files[0].name;
            $('.file-upload label').text(fileName);
        });
    });
</script>
