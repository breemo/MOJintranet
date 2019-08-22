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
                                    <asp:GridView ID="grdMyTasks" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
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
												<tbody>
													<tr>
													 <td><a href="<%# Eval("TaskURL") %>"><%# Eval("RequestName") %> </a></td>
													
													<td><%# Eval("ServiceNameLG") %></td>
													<td><%# Eval("TitleLG") %></td> 
													<td><%#  Convert.ToDateTime(Eval("Created")).ToString("dd MMM yyyy hh:mm tt")%></td>                                        
													<td><a href="<%# Eval("TaskURL") %>"><span class='icon-edit'> </span></a></td>
													</tr>  
                                                    </tbody>
												</ItemTemplate>
											
											</asp:TemplateField>
										</Columns>
									</asp:GridView> 								
                            </div>							
						 </div>
                    </div>                    
				</div>                    

<div class="pagi" runat="server" id="pgng">
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
		   <div class="tab-content clearfix" id="tab-responsive-2">
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
													 <td><a href="<%# Eval("TaskURL") %>"><%# Eval("RequestName") %> </a></td>							
														<td><%# Eval("ServiceNameLG") %></td> 											
													<td><%# Eval("TitleLG") %></td> 
													<td><%# Eval("WorkflowOutcomeLG") %></td> 
													<td><%#  Convert.ToDateTime(Eval("Created")).ToString("dd MMM yyyy hh:mm tt")%></td>                                        
													<td><a href="<%# Eval("TaskURL") %>"><span class='icon-edit'> </span></a></td>
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
</div>

<!-- #posts end -->
<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<style>
.pagi .pagination li a {
 
    background: #bd995d;
}
.HeaderRow{
    color: #ffffff;
}
#tab-responsive-2 tr:nth-child(even) {
    border-bottom: 1px solid #d0a659;
}

#tab-responsive-1 tbody:nth-child(even) {
    border-bottom: 1px solid #d0a659;
}

</style>
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

