<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskAnExpertWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.AskAnExpertWP.AskAnExpertWPUserControl" %>
        <section id="content" style="margin-bottom: 0px;">
            <div class="content-wrap">
                <div class="">
                    <!-- Post Content
                ============================================= -->
                    <div class="">
                        <div class="askexlf">
                        <div class="faqhead">
                            <h3><label><asp:Literal runat="server" Text="<%$ Resources:Resource, AskAnExpert%>" /></label></h3>
                            <a href="AskAnExpertQuestion.aspx" class="btnclasscdd radix ndcf" >
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AskAnExpert%>" /></label>
                                <span class="icon-plus1 pad"></span>
                            </a>
                        </div>
                        <div class="">
                            <div class="">
                                <div class="searchboxne">
                        <h5 class="searchtitle">  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Search%>" /></label></h5>
                                    <div class="row d-flex justify-content-center align-items-center">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-1">
                                                    <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                                                </div>
                                                <div class="col-md-5">
                                                       <asp:DropDownList ID="DropDownDepartment" runat="server" class="form-control">
																</asp:DropDownList>
                                                </div>
                                                <div class="col-md-1">
                                                    <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, Topic%>" /></label></label>
                                                </div>
                                                <div class="col-md-5">
                                                    	<input type="text" name="Topic" runat="server" id="Topic" class="form-control" placeholder="">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                             <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Search%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />								
                                        </div>
                                    </div>
                                </div>
                                <section id="faqs" class="freqa">
                                    <div runat="server"  class="questions" id="questions">
                                      
                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                    </div><!-- .postcontent end -->
                    <!-- Sidebar
                ============================================= -->
                    
            </div>
            
        </section>

<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>
<style>
.evenRow{
background-color: #f5e9b6;
}
.row.rt {
    margin-bottom: 1px;
    margin-top: 1px;
    padding: 1px;
}
#dynamicInput .row table {
    margin-bottom: 1px;
}
#dynamicInputChildren .row table {
    margin-bottom: 1px;
}
.HusbandORWife .row table {
    margin-bottom: 1px;
}

.HeaderRow{
    color: #ffffff;
}

.active {
   
    background-color: #e9ecef;
   
}
.table-responsive tr:nth-child(even) {
    padding: 0.8em 0.75rem;
    vertical-align: middle;
    text-align: center;
    font-size: 1.2em;
}
.table-responsive tr td {
    border-right: 1px solid #dee2e6;
        border-left: 1px solid #dee2e6;
        text-align: center;
        font-size: 1em;
}
.table-responsive tr {
    border: 1px solid #dee2e6;
}
.table-responsive tr:nth-child(even) td {
    padding: 15px;
}

tr.firstrow th {
      text-align: center;
    font-size: 1.2em;
    vertical-align: middle !important;
    background-color: #be9136;
    color: #fff;
    border: 0px;
    padding: 25px;
}
.faqhead label {
    font-size: inherit !important;
    font-weight: 700 !important;
}
</style>
<script>
    $("#faqs dt:first-child").addClass("active");
    $("#faqs dt:first-child").next().slideDown().siblings('dd').slideUp();

    $('#faqs dt').click(function () {


        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).next().slideUp();
        } else {

            $(this).siblings('dt').removeClass('active');
            $(this).addClass('active');
            $(this).next().slideDown().siblings('dd').slideUp();
        }
    });

    $(document).ready(function () {
        $(".RadiB label").addClass("radio-button-click-target");
        $(".RadiB input").addClass("radio-button");
    });
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


