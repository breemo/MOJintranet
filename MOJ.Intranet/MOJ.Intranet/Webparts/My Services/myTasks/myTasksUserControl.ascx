<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myTasksUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.myTasks.myTasksUserControl" %>
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, Tasks%>" />
</h4>
<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">

    <div class="tabs tabs-responsive clearfix fullwidthtabs">

        <ul class="tab-nav clearfix">
            <li><a href="#tab-responsive-1"><asp:Literal runat="server" Text="<%$ Resources:Resource, MyTasks%>" /></a></li>
            <li><a href="#tab-responsive-2"><asp:Literal runat="server" Text="<%$ Resources:Resource, MyAccomplishedTasks%>" /></a></li>
        </ul>

        <div class="tab-container">
            <div class="tab-content clearfix" id="tab-responsive-1">
                <div class="inskdnew inskdnew2">
                     <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered newtableb">
								  <thead>
                                         <th>#</th>                                        
                                        <th><asp:Literal runat="server" Text="<%$ Resources:Resource, RequestNumber%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, ServiceType%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, AssignTo%>" /></th>										
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, TaskDate%>" /></th>									                                                                
                                        <th>
                                            <span class=""><asp:Literal runat="server" Text="<%$ Resources:Resource, Edit%>" /></span>
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
                                  <asp:Label id="MyTasks" runat="server"></asp:Label>
                                      
                                </table>
                            </div>

                        </div>
                    </div>
                </div>


            </div>
            <div class="tab-content clearfix" id="tab-responsive-2">
                <div class="inskdnew">
				  <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered newtableb">
								  <thead>
                                         <th>#</th>                                        
                                        <th><asp:Literal runat="server" Text="<%$ Resources:Resource, RequestNumber%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, ServiceType%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, AssignTo%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, Result%>" /></th>
										<th><asp:Literal runat="server" Text="<%$ Resources:Resource, TaskDate%>" /></th>									                                                                
                                        <th>
                                            <span class=""><asp:Literal runat="server" Text="<%$ Resources:Resource, Edit%>" /></span>
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
                                  <asp:Label id="MyAccomplishedTasks" runat="server"></asp:Label>
                                      
                                </table>
                            </div>

                        </div>
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

