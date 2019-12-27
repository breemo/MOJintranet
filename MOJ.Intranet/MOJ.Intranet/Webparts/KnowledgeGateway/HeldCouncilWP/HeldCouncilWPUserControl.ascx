<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeldCouncilWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilWP.HeldCouncilWPUserControl" %>
<asp:HiddenField ClientIDMode="Static" ID="hdnPage" runat="server" />
     <!-- Post Content
                    ============================================= -->
                    <div class="">
                        <div class="">
                            <h4>
							    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilsHeld%>" /></label>
                            </h4>
                            <div id="posts" class="small-thumbs alt">
                                <div class="searchboxne searchboxne2  hedlbg pb-0"> 
                                    <div class="row d-flex justify-content-center align-items-center">
									<div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-1">
                                                    <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilTopic%>" /></label></label>
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="DropDownCouncilTopic" runat="server" class="form-control">
																</asp:DropDownList>
                                                </div>
                                                <div class="col-md-1">
													     <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilNo%>" /></label></label>
                                               
                                                </div>
                                                <div class="col-md-5">
                                                   <asp:DropDownList ID="DropDownCouncilNo" runat="server" class="form-control">
																</asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-1">
                                                
														     <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilDate1%>" /></label></label>
                                               
                                                
                                                </div>
                                                <div class="col-md-5">
                                                       <div class="input-group date " data-provide="datepicker">
																<input autocomplete="off"  type="text" runat="server" id="CouncilDate" class="form-control">
																<div class="input-group-addon">
																	<span class="icon-calendar-alt1"></span>
																</div>									
																	</div>
                                                </div>
                                                <div class="col-md-1">
                                                     <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label></label>
                                               
                                                </div>
                                                <div class="col-md-5">
                                                     <asp:DropDownList ID="DropDownDepartment" runat="server" class="form-control">
																</asp:DropDownList>
                                                </div>
                                            </div>
											</div>
                                        <div class="col-md-12">
                                            
											       <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Search%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />								
											       <%--<asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, SearchAll%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnSearchAll"  />--%>								
           										
                                           
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <table class="table table-hover table-bordered newtableb newtableb2 ">
                                           
						<asp:GridView ID="grdHeldCouncil" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
										BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
										EnableModelValidation="True" 
										>
										<PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
											Mode="NumericFirstLast" PageButtonCount="5" />
										<PagerStyle HorizontalAlign="Center" CssClass="gridview" />
										<EmptyDataRowStyle Font-Bold="true" ForeColor="#646464" Font-Size="1.5em" />
										<Columns>
											<asp:TemplateField>											
											 <HeaderTemplate>
											</HeaderTemplate>											
												<ItemTemplate>
													<tr>
													 <td><a href="<%# Eval("RequestURL") %>"><%# Eval("CouncilNo") %> </a></td>							
													<td><%# Eval("Department") %></td> 											
													<td><%# Eval("CouncilTopic") %></td> 
													<td><%#  Convert.ToDateTime(Eval("CouncilDate")).ToString("dd/MM/yyyy")%></td> 
													<td><%# Eval("Lecturer") %></td> 
													<td><%# Eval("JoiningConditions") %></td> 													                                       
													<td><a href="<%# Eval("RequestURL") %>"><span class='icon-eye'> </span></a></td>
													</tr>     
												</ItemTemplate>
												
											</asp:TemplateField>
										</Columns>
									</asp:GridView> 											
                                           
                                        </table>
                                    </div>
                                </div>
                            </div> 
							<div class="pagi" runat="server" id="pgng2">
					<ul class="pagination">
						<li class="page-item">
							<a class="page-link pageright" href="#">
								<i class="icon-angle-right"></i>
							</a>
						</li>
						<asp:Repeater ID="rpt2Paging" runat="server" OnItemCommand="rpt2Paging_ItemCommand">
							<ItemTemplate>
								<li class="page-item">
									<asp:LinkButton ID="btn2Page"
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
                            </div><!-- #posts end -->
                        </div>
                    <!-- Sidebar
                    ============================================= -->
					<div id="SuccessMsgDiv" runat="server" style="display:none">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<div id="Div1" runat="server" >
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></h4>
</div>
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
</style>
<script>
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
    var valuepage = document.getElementById('hdnPage').value;
    $(".pagination a").each(function () {
        if ($(this).text() == valuepage)
            $(this).addClass("active");
    });
</script>



