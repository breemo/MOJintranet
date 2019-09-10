<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyRequestsWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.MyRequestsWP.MyRequestsWPUserControl" %>
<style>
.pagi .pagination li a {
 
    background: #bd995d;
}
.HeaderRow{
    color: #ffffff;
}
.table-responsive tr:nth-child(even) {
    border-bottom: 1px solid #d0a659;
}


</style>
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, MyRequests%>" />
</h4>

<hr />
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, Search%>" />
</h4>
<div class="row rt" style="margin-bottom: 0px;">
                <div class="col-md-4 ">
                  <div class="row">
                                <div class="col-md-4">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, RequestNumber%>" /></label>
                                </div>
                                <div class="col-md-8">                    
                                   	<input type="text" name="RequestNumber" runat="server" id="RequestNumber" class="form-control" placeholder="">

                                </div>
                            </div>
                </div>
    <div class="col-md-4 ">
                  <div class="row">
                                <div class="col-md-4">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Result%>" /></label>
                                </div>
                                <div class="col-md-8">
                                   <label><asp:Literal runat="server" id="DDRe"/></label>                        
                                    <asp:DropDownList style="height: 38px;margin-top: -20px;" class="form-control form-control-sm" ID="DDResult" runat="server">
									</asp:DropDownList>

                                </div>
                            </div>
                </div>
				</div>  


<label><asp:Literal runat="server" Text="<%$ Resources:Resource, TaskDate%>" /></label>
									
         <div class="row rt">
                        <div class="col-md-4">
                           <div class="row">
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, from%>" /></label>
                        </div>
                        <div class="col-md-8">
						
                                 <div class="input-group date Divfrom" data-provide="datepicker">
										<input  type="text" runat="server" id="from0" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
                                </div>
                                </div>
					</div>
                       <div class="col-md-4">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, to%>" /></label>
								</div>
								<div  class="col-md-8">
									<div class="input-group date Divto" data-provide="datepicker">
										<input  type="text" runat="server" id="to0" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
								</div> 
                              </div>
                       </div>
                </div>




        <div class="row rt">
                        <div class="col-md-4">
                           <div class="row">
                                <div class="col-md-4">
                        </div>
                        <div class="col-md-8">
						 <asp:Button Text="<%$ Resources:Resource, Search%>"  CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnSearch_Click" />
         
                             
                                </div>
                                </div>
					</div>
                       <div class="col-md-4">
                            <div class="row">
								<div  class="col-md-4">
								</div>
								<div  class="col-md-8">
									
								</div> 
                              </div>
                       </div>
                </div>
      
<h4></h4>
 	
<div id="posts" runat="server" class="small-thumbs alt">
      <div class="tab-container">        
		   <div class="" id="tab-">
                <div class="inskdnew">
				  <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">                            
							 <asp:GridView ID="grdMyAccomplishedTasks" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
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
													 <td><a href="<%# Eval("RequestURL") %>"><%# Eval("RequestNumber") %> </a></td>							
														<td><%# Eval("ServiceNameLG") %></td> 											
													<td><%# Eval("StatusLG") %></td> 
													<td><%#  Convert.ToDateTime(Eval("Created")).ToString("dd MMM yyyy hh:mm tt")%></td>                                        
													<td><a href="<%# Eval("RequestURL") %>"><span class='icon-edit'> </span></a></td>
													</tr>     
												</ItemTemplate>
												
											</asp:TemplateField>
										</Columns>
									</asp:GridView>                              
                            </div>
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
			</div>
    </div>
   
</div>
<!-- #posts end -->
<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>

<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>

