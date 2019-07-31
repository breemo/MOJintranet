<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarOrderServiceWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.CarOrderServiceWP.CarOrderServiceWPUserControl" %>


<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>

<h4>طلب أستضافة
</h4>
<div id="posts" class="small-thumbs alt">
    <div class="tabs tabs-responsive clearfix fullwidthtabs ui-tabs ui-corner-all ui-widget ui-widget-content">
        <div class="inskdnew">
            <div class="row rt">


                <div class="col-md-12">

                    <h5>يلزم بتأمين سيارة
                    </h5>
                    <div>
                        <%--                <input type="checkbox"
                    class="checkbox"
                    id="checkbox-1" />
                <label for="checkbox-1"
                    class="checkbox-click-target">
                    <span class="checkbox-box"></span>سائق
                </label>
                <input type="checkbox"
                    class="checkbox"
                    id="checkbox-2" />
                <label for="checkbox-2"
                    class="checkbox-click-target">
                    <span class="checkbox-box"></span>بدون سائق
                </label>
                <input type="checkbox"
                    class="checkbox"
                    id="checkbox-3" />
                <label for="checkbox-3"
                    class="checkbox-click-target">
                    <span class="checkbox-box"></span>داخل ابوظبي
                </label>

                <input type="checkbox"
                    class="checkbox"
                    id="checkbox-4" />
                <label for="checkbox-4"
                    class="checkbox-click-target">
                    <span class="checkbox-box"></span>خارج ابوظبي
                </label>--%>
                        <asp:CheckBoxList ID="cbTravelNeeds" CssClass="checkbox-click-target" runat="server">
                            <asp:ListItem Text="سائق" Value="WithDriver" />
                            <asp:ListItem Text="بدون سائق" Value="WithoutDriver" />
                            <asp:ListItem Text="داخل ابوظبي" Value="InsideAbuDhabi" />
                            <asp:ListItem Text="خارج ابوظبي" Value="OutSideAbuDhabi" />
                        </asp:CheckBoxList>
                    </div>
                </div>
            </div>
            <div class="row rt">

                <div class="col-md-6">

                    <div class="row">

                        <div class="col-md-2">
                            <label>الذهاب الى</label>
                        </div>

                        <div class="col-md-9">
                            <input type="text" runat="server" id="txtTravelTo" class="form-control" placeholder="">
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
                            <label>لنقل السادة</label>
                        </div>

                        <div class="col-md-9">
                            <input type="text" runat="server" id="txtPassengerName" class="form-control" placeholder="">
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
                            <label>لغرض</label>
                        </div>

                        <div class="col-md-9">
                            <input type="text" runat="server" id="txtTravelReson" class="form-control" placeholder="">
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
                            <label>على ان تتواجد السيارة أمام</label>
                        </div>

                        <div class="col-md-9">
                            <input type="text" id="txtCarPlace" runat="server" class="form-control" placeholder="">
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
                            <label>الموافق</label>
                        </div>

                        <div class="col-md-9">

                            <div class="input-group date" data-provide="datepicker">
                                <input type="text" runat="server" id="txtTravelDate" class="form-control">
                                <div class="input-group-addon">
                                    <span class="icon-calendar-alt1"></span>
                                </div>
                            </div>

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
                            <label>مدة المهمة</label>
                        </div>

                        <div class="col-md-9">
                            <input type="text" runat="server" id="txtduration" class="form-control" placeholder="">
                        </div>
                    </div>


                </div>
                <div class="col-md-6">
                </div>
            </div>
            <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>
        </div>
    </div>
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
