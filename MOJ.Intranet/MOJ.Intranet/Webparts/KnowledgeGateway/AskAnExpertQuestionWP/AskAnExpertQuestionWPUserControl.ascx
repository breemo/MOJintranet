<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AskAnExpertQuestionWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.AskAnExpertQuestionWP.AskAnExpertQuestionWPUserControl" %>
<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>
  <!-- Post Content
                    ============================================= -->
                    <div class="">
                        <div class="">
                            <h4>
							    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AskAnExpert%>" /></label>
                            </h4>
                            <div id="posts"  runat="server" class="small-thumbs alt"> 
                            <div class="inskdnew askforcon">
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                                            </div>
                                            <div class="col-md-9">
                                             <asp:DropDownList ID="DropDownDepartment" AutoPostBack="true" OnSelectedIndexChanged="myListDropDown_Change" runat="server" class="form-control">
																</asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="DropDownDepartment" Display="Dynamic" >
								</asp:RequiredFieldValidator>
											</div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ExpertName%>" /></label>
                                            </div>
                                            <div class="col-md-9">
                                            <asp:DropDownList ID="DropDownExpertName" runat="server" class="form-control">
																</asp:DropDownList>
																	<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="DropDownExpertName" Display="Dynamic" >
								</asp:RequiredFieldValidator> 
											</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row rt">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-md-2">
												    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, QuestionTitle%>" /></label>     
                                            </div>
                                            <div class="col-md-9">
                                              <input type="text"  name="QuestionTitle" runat="server" id="QuestionTitle" class="form-control" placeholder="">
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="QuestionTitle" Display="Dynamic" >
								</asp:RequiredFieldValidator>                                           
										   </div>
                                        </div>
                                    </div>
                                    
                                </div>
                               
                                <div class="row rt">
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-1">
                                                
												<label><asp:Literal runat="server" Text="<%$ Resources:Resource, QuestionDetails%>" /></label>  
                                            </div>
                                            <div class="col-md-11">
											<textarea class="form-control" runat="server" id="QuestionDetails" rows="4"></textarea>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
								ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="QuestionDetails" Display="Dynamic" >
								</asp:RequiredFieldValidator>  
                                             
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
</style>
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


