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
<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">
    
                <div class="inskdnew inskdnew2">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-hover table-bordered newtableb">
                                    <thead>
                                        <th>اسم الطلب</th>
                                        <th>اسم المهمة</th>
                                        <th>الحالة</th>
                                        <th>النتيجة</th>
                                        <th>تاريخ المهمة</th>                                                                   
                                        <th>
                                            <span class=""></span>
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
                                  <asp:Label id="tasks" runat="server"></asp:Label>
                                      
                                </table>
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