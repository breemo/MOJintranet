﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReturnNoticeFromLeaveWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.ReturnNoticeFromLeaveWP.ReturnNoticeFromLeaveWPUserControl" %>

<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>



<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, ReturnFromLeave%>" />
</h4>
  

  
   <div id="posts" runat="server" class="small-thumbs alt">


    	 <div id="Edata">
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="Ename" disabled runat="server" id="Ename" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeNumber%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="Enumber" runat="server" id="Enumber" class="form-control" placeholder="">
									    </div>
                              </div>
					    </div>                  
                    </div>
						<div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="Edepartment" disabled runat="server" id="Edepartment" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">                              
					    </div>                  
                    </div>
               </div>

                   <hr />
         <div class="row rt">
                <div class="col-md-12 ">
                  <div class="row">
								<div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ApprovedVacation%>" /></label>
                                </div>
                                <div class="col-md-4">                                                        
                                    <asp:DropDownList ID="DropDownApprovedVacation" runat="server" class="form-control">
									</asp:DropDownList>
																		<asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="DropDownApprovedVacation" Display="Dynamic" >
									</asp:RequiredFieldValidator>   
                                </div>						
                        
                </div>
				</div> 
				</div> 
				   
				<div class="row rt">
                <div class="col-md-12 ">
                  <div class="row">
								<div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, StartDateVacation%>" /></label>
                                </div>
                                <div class="col-md-4">                                                        
                                   <input type="text" name="StartDateVacation" disabled runat="server" id="StartDateVacation" class="form-control" placeholder="">  
                                </div>
                               								  							
                 </div>
                </div>
				</div> 
				   <div class="row rt">
                <div class="col-md-12 ">
                  <div class="row">
								<div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EndDateVacation%>" /></label>
                                </div>
                                <div class="col-md-4">                                                        
                                   <input type="text" name="EndDateVacation" disabled runat="server" id="EndDateVacation" class="form-control" placeholder="">  
                                </div>
                               								  							
                 </div>
                </div>
				</div> 
				 <div class="row rt">
                <div class="col-md-12 ">
                  <div class="row">								
                                <div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ReturnDateFromVacation%>" /></label>
                                </div>
                                <div class="col-md-4">                                                     
                                  <div class="input-group date DivReturnDateFromVacation" data-provide="datepicker">
										<input  autocomplete="off" type="text" runat="server" id="ReturnDateFromVacation" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ReturnDateFromVacation" Display="Dynamic" >
            </asp:RequiredFieldValidator>                               
							  </div>								  							
                 </div>
                </div>
				</div>    
				   
                <div class="row rt">
                <div class="col-md-12 ">
                  <div class="row">								
                                <div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, RreasonForTheDelay%>" /></label>
                                </div>
                                <div class="col-md-4">                                                     
                                  <input type="text"  name="RreasonForTheDelay" runat="server" id="RreasonForTheDelay" class="form-control" placeholder="">    
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="RreasonForTheDelay" Display="Dynamic" >
									</asp:RequiredFieldValidator>                               
							  </div>								  							
                 </div>
                </div>
				</div>       
         
		 	
			
			
            <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>
        </div>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<div id="SuccessMsgDiv" runat="server" style="display:none">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<style>
.RadioButto table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;

}

</style>

<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>



