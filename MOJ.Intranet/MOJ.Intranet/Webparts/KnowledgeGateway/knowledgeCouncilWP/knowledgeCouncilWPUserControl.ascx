<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="knowledgeCouncilWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.knowledgeCouncilWP.knowledgeCouncilWPUserControl" %>


<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>
  <!-- Post Content
                    ============================================= -->
                    <div class="">
                        <div class="faqhead1">
                            <h4>
							    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AnnounceForaKnowledgeCouncil%>" /></label>
                            </h4>
                            <div id="posts"  runat="server" class="small-thumbs alt"> 
                            <div class="inskdnew askforcon">
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                            </div>
                                            <div class="col-md-9">
                                               <input type="text" name="Ename" disabled runat="server" id="Ename" class="form-control" placeholder="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeNumber%>" /></label>
                                            </div>
                                            <div class="col-md-9">
                                                <input type="text" disabled name="Enumber" runat="server" id="Enumber" class="form-control" placeholder="">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
												    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>     
                                            </div>
                                            <div class="col-md-9">
                                              <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                  <label><asp:Literal runat="server" Text="<%$ Resources:Resource, DirectManager%>" /></label>  
                                            </div>
                                            <div class="col-md-9">
                                                  <input type="text" disabled name="EDirectManager" runat="server" id="EDirectManager" class="form-control" placeholder="">
                                            </div>
											</div>
                                    </div>
                                    </div>
                                    
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ConcernedDepartment%>" /></label>  
                                            </div>

                                            <div class="col-md-9">
                                            <asp:DropDownList ID="EDepartment" runat="server" class="form-control">
																</asp:DropDownList>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="EDepartment" Display="Dynamic" >
								</asp:RequiredFieldValidator>

                                            </div>
                                        </div>
                                    </div>
                               
                                    
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilTopic%>" /></label>  
                                            </div>

                                            <div class="col-md-9">
						<input type="text" runat="server"  id="CouncilTopic" class="form-control" placeholder="">
							   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="CouncilTopic" Display="Dynamic" >
									</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
									</div>
                                
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilTarget%>" /></label>  
                                            </div>
                                            <div class="col-md-9">
											<textarea class="form-control" runat="server" id="CouncilTarget" rows="4"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="CouncilTarget" Display="Dynamic" >
								</asp:RequiredFieldValidator>  
                                             
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, JoiningConditions%>" /></label>  
                                            </div>
                                            <div class="col-md-9">
                                               	<textarea class="form-control" runat="server" id="JoiningConditions" rows="4"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="JoiningConditions" Display="Dynamic" >
								</asp:RequiredFieldValidator>  
                                            </div>
                                        </div>
                                    </div>
                                </div>    
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
                                                
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, TargetGroup%>" /></label>  
                                            </div>
                                            <div class="col-md-9">
											<textarea class="form-control" runat="server" id="TargetGroup" rows="4"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage2" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="TargetGroup" Display="Dynamic" >
								</asp:RequiredFieldValidator>  
                                             
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-3">
											</div>
                                            <div class="col-md-9">
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>                                            
                                    <div class="row rt">                                                    
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-3">
													<label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilDate%>" /></label>  
                                                </div>
                                                <div class="col-md-9">

                                                    <div class="input-group date " data-provide="datepicker">
																<input autocomplete="off"  type="text" runat="server" id="CouncilDate" class="form-control">
																<div class="input-group-addon">
																	<span class="icon-calendar-alt1"></span>
																</div>									
																	</div>
									 <asp:RequiredFieldValidator ID="RequiredCouncilDate" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="CouncilDate" Display="Dynamic" >
								</asp:RequiredFieldValidator>																	
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-3">											
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilType%>" /></label>  
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="DropDownCouncilType" runat="server" class="form-control">
																</asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                                </div>
                                                <div class="row rt  botx">
                                                     <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Submit%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />								
           										</div>
                                            </div>
                            </div><!-- #posts end -->
                        </div>
                    </div><!-- .postcontent end -->
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
#Edata .rt{
     margin-bottom: 1px;
}
.faqhead1 label {
    font-size: inherit !important;
    font-weight: 700 !important;
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
</script>


