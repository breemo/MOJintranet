<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HostingRequestWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.HostingRequestWP.HostingRequestWPUserControl" %>


<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, headHostingRequest%>" />
</h4>

<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">

    <div class="tabs tabs-responsive clearfix fullwidthtabs">

        <ul class="tab-nav clearfix">
            <li><a href="#tab-responsive-1">أستضافة فندقية</a></li>
            <li><a href="#tab-responsive-2">حجز قاعة</a></li>
        </ul>

        <div class="tab-container">

            <div class="tab-content clearfix" id="tab-responsive-1">

                <div class="inskdnew inskdnew2">

                    <div class="row rt">

                        <div class="col-md-6">

                            <div class="row">

                                <div class="col-md-2">
                                    <label>الاماره</label>
                                </div>

                                <div class="col-md-9">
                                    <select class="form-control">
                                        <option>اختر</option>
                                        <option>الاماره </option>
                                        <option>الاماره</option>
                                    </select>
                                </div>
                            </div>


                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>



                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered newtableb">
                                    <thead>
                                        <th>اسم الموظف</th>
                                        <th>المسمي الوظيفي</th>
                                        <th>الدرجة الوظيفبة</th>
                                        <th>الفترة من </th>
                                        <th>الفترة الي</th>
                                        <th>المهمة</th>
                                        <th>
                                            <span class="fsiz  icon-plus-sign"></span>
                                        </th>
                                    </thead>

                                    <tfoot>
                                        <tr>
                                            <td class="foot" colspan="7">


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
                                            </td>

                                        </tr>
                                    </tfoot>
                                    <tr>
                                        <td>محمد اكمل بت</td>
                                        <td>الفريق المتصدر</td>
                                        <td>A++</td>
                                        <td>24/12/2006</td>
                                        <td>24/12/2009</td>
                                        <td>فصل كانتا شموليةً كل</td>
                                        <td>

                                            <span class="icon-trash-alt"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>محمد اكمل بت</td>
                                        <td>الفريق المتصدر</td>
                                        <td>A++</td>
                                        <td>24/12/2006</td>
                                        <td>24/12/2009</td>
                                        <td>فصل كانتا شموليةً كل</td>
                                        <td>

                                            <span class="icon-trash-alt"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>محمد اكمل بت</td>
                                        <td>الفريق المتصدر</td>
                                        <td>A++</td>
                                        <td>24/12/2006</td>
                                        <td>24/12/2009</td>
                                        <td>فصل كانتا شموليةً كل</td>
                                        <td>

                                            <span class="icon-trash-alt"></span>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>محمد اكمل بت</td>
                                        <td>الفريق المتصدر</td>
                                        <td>A++</td>
                                        <td>24/12/2006</td>
                                        <td>24/12/2009</td>
                                        <td>فصل كانتا شموليةً كل</td>
                                        <td>

                                            <span class="icon-trash-alt"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>محمد اكمل بت</td>
                                        <td>الفريق المتصدر</td>
                                        <td>A++</td>
                                        <td>24/12/2006</td>
                                        <td>24/12/2009</td>
                                        <td>فصل كانتا شموليةً كل</td>
                                        <td>

                                            <span class="icon-trash-alt"></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                    </div>



                </div>


            </div>
            <div class="tab-content clearfix" id="tab-responsive-2">
                <div class="inskdnew">
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:RadioButtonList ID="cbPlace" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, AttendeesNumber%>" /></label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" runat="server" id="txtAttendeesNumber" class="form-control" placeholder="">
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-2">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Day%>" /></label>
                                </div>
                                <div class="col-md-9">
                                    <div class="input-group date" data-provide="datepicker">
                                        <input type="text" runat="server" id="txtBookingDateFrom" class="form-control">
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row newrowtime">
                                <div class="col-md-2">
                                    <label>الوقت</label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group timenew">
                                        <input  runat="server" id="txtBookingTimeFrom" class="timepicker form-control" />
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3">

                                    <div class="input-group timenew">
                                        <input id="timepicker" class="timepicker form-control" />
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-4">

                                    <a href="#" class="morebutovn">اضافة ايام
                                                                    <span class="icon-plus-sign"></span>
                                    </a>

                                </div>

                            </div>


                        </div>
                    </div>



                    <div class="row rt fleb">

                        <div class="col-md-1">

                            <label>المهمة</label>


                        </div>
                        <div class="col-md-11">

                            <textarea class="form-control" runat="server" id="txtMission" rows="3"></textarea>






                        </div>
                    </div>



                    <div class="row rt">


                        <div class="col-md-12">
                            <h5>المطلوب توفيره
                            </h5>
                            <div>
                                <%--<input type="checkbox"
                                    class="checkbox"
                                    id="checkbox-1" />
                                <label for="checkbox-1"
                                    class="checkbox-click-target">
                                    <span class="checkbox-box"></span>عصائر
                                </label>
                                <input type="checkbox"
                                    class="checkbox"
                                    id="checkbox-2" />
                                <label for="checkbox-2"
                                    class="checkbox-click-target">
                                    <span class="checkbox-box"></span>وجبات خفيفة
                                </label>
                                <input type="checkbox"
                                    class="checkbox"
                                    id="checkbox-3" />
                                <label for="checkbox-3"
                                    class="checkbox-click-target">
                                    <span class="checkbox-box"></span>وجبات رئيسية
                                </label>--%>
                                <asp:CheckBoxList ID="cbResources" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>


                    <div class="row rt  botx">
                        <asp:Button Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnSaveRoomBooking_Click" />

                        <%--<a href="#" class="morebutovn2">تقديم



                        </a>--%>
                    </div>

                </div>
            </div>


        </div>

    </div>

</div>
<!-- #posts end -->
<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>
<script>
    $('.datepicker').datepicker({
        language: 'ar',
        rtl: true,
    });

    $('.timepicker').timepicker({
        timeFormat: 'h:mm p',
        interval: 60,
        minTime: '10',
        maxTime: '6:00pm',
        defaultTime: '11',
        startTime: '10:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });
</script>

