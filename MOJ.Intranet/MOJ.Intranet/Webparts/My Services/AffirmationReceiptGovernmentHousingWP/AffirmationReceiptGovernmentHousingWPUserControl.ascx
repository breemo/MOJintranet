﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AffirmationReceiptGovernmentHousingWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.AffirmationReceiptGovernmentHousingWP.AffirmationReceiptGovernmentHousingWPUserControl" %>


<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>


<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, AffirmationReceiptGovernmentHousing%>" />
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
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, department%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="Edepartment" disabled runat="server" id="Edepartment" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, FinancialNumber%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EFinancialNumber" runat="server" id="EFinancialNumber" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>                  
                    </div>
                   <div class="row rt">
				     <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, category%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="Ecategory" runat="server" id="Ecategory" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>  
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HiringDate%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EHiringDate" runat="server" id="EHiringDate" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                                      
                    </div>
          
                <div class="row rt">				
				 <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Worklocation%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EWorklocation" runat="server" id="EWorklocation" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div> 
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Nationality%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="ENationality" disabled runat="server" id="ENationality" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                                        
                    </div>
					
                   <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, MaritalStatus%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EMaritalStatus" runat="server" id="EMaritalStatus" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WorkPhoneEx%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EWorkPhoneEx" runat="server" id="EBWorkPhoneEx" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>                  
                    </div>     
					<div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Email%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EEmail" runat="server" id="EEmail" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                           
					    </div>                  
                    </div>    
               
               </div>

               <hr />     
                  
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-2">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-4 DivName">
                                    <input type="text" name="Name" runat="server" id="Name0" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>							
                        </div>
					<div class="row rt">
					  <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, MobileNumber%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="MobileNumber" runat="server" id="MobileNumber" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                        <div class="col-md-6">
                            <div class="row">
								<div class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, ApportionmentDate%>" /></label>
								</div>
								<div class="col-md-8">
									<div class="input-group date DivDateApportionmentDate" data-provide="datepicker">
										<input  type="text" runat="server" id="ApportionmentDate" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
								</div>
                           </div>
					</div>                    
                </div>
               	<div class="row rt">
					  <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, HomeAddress%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="HomeAddress" runat="server" id="HomeAddress" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                      <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, VilaApartmentNumber%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="VilaApartmentNumber" runat="server" id="VilaApartmentNumber" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>                   
                </div>
                	<div class="row rt">
					  <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, NumberOfRooms%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="NumberOfRooms" runat="server" id="NumberOfRooms" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                      <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Owner%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="Owner" runat="server" id="Owner" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>                   
                </div>
                	<div class="row rt">
					  <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, agent%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="agent" runat="server" id="agent" class="form-control" placeholder="">
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
</style>
