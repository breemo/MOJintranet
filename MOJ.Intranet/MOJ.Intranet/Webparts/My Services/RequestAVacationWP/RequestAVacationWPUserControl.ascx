<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequestAVacationWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.RequestAVacationWP.RequestAVacationWPUserControl" %>

<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>



<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, RequestAVacation%>" />
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
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, VacationsTypes%>" /></label>
                                </div>
                                <div class="col-md-4">  				


								
                                    <asp:DropDownList ID="DropDownVacationsTypes" AutoPostBack="true" OnSelectedIndexChanged="VacationsTypes_Change"  runat="server" class="form-control">
									</asp:DropDownList>
																		<asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="DropDownVacationsTypes" Display="Dynamic" >
									</asp:RequiredFieldValidator>   
                                </div>
								
                                <div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, AlternateEmployee%>" /></label>
                                </div>
                                <div class="col-md-4">                                                     
                                  <input type="text"  name="AlternateEmployee" runat="server" id="AlternateEmployee" class="form-control" placeholder="">    
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="AlternateEmployee" Display="Dynamic" >
									</asp:RequiredFieldValidator>                               
							  </div>
								  							
                 </div>
                </div>
				</div>       
         
              <div class="row rt">
                <div class="col-md-12">
                     <div class="row">
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, from%>" /></label>
								</div>
								<div class="col-md-4  " >
									<div id="toFrom"  class="input-group date DivDateApportionmentDate" data-provide="datepicker">
										<input autocomplete="off"  type="text" runat="server" id="from" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="from" Display="Dynamic" >
									</asp:RequiredFieldValidator> 
								</div>								
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, to%>" /></label>
								</div>
								<div class="col-md-4  ">
									<div id="toDate" class="input-group date DivDateApportionmentDate" data-provide="datepicker">
										<input autocomplete="off"  type="text" runat="server" id="to" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="to" Display="Dynamic" >
									</asp:RequiredFieldValidator> 
								</div>
                           </div>
                </div>   
				
            </div>   
       			<div class="row rt">
                <div class="col-md-12">
                     <div class="row">															
								<div class="col-md-2">
									<div  id="isGreaterThanDateTime">
                                        <input type="text" style="display: none;" runat="server" id="isGreaterDateTo" class="form-control">
										</div>	
								</div>
								<div class="col-md-4  ">
									  <asp:CompareValidator ID="CompareValidatorDateofbirth" runat="server" 
                                    ErrorMessage="<%$ Resources:Resource, ToDateGreaterFromDate%>"
                                    ControlToValidate="isGreaterDateTo" ValueToCompare="dateerror"
                                    Type="String" Operator="NotEqual" ForeColor="Red"
                                    SetFocusOnError="true"
                                    Display="Dynamic">
									</asp:CompareValidator>
									
								</div>							
                           </div>
					</div> 				
            </div> 

 <div class="row rt" runat="server" id="Father" style="display: none;">
                <div class="col-md-12">
                     <div class="row">
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, DateOfBirthOfTheChild%>" /></label>
								</div>
								<div class="col-md-4  " >
									<div id="DateBirthOfTheChild"  class="input-group date" data-provide="datepicker">
										<input autocomplete="off"  type="text" runat="server" id="DateOfBirthOfTheChild" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
								
								</div>								
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, PlaceOfBirthOfTheChild%>" /></label>
								</div>
								<div class="col-md-4  ">
									  <input type="text"  name="PlaceOfBirthOfTheChild" runat="server" id="PlaceOfBirthOfTheChild" class="form-control" placeholder="">    
								
								</div>
                           </div>
                </div>  
                </div>  
				
				
				 <div class="row rt" runat="server" id="permission" style="display: none;">
                <div class="col-md-12 ">
                  <div class="row">
				  <div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, StartTime%>" /></label>
                                </div>
                                <div class="col-md-4">                                                     
                                  <input type="text"  name="StartTime" runat="server" id="StartTime" class="form-control" placeholder="11:00">    
									                          
							  </div>
							  <div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EndTime%>" /></label>
                                </div>
                                <div class="col-md-4">                                                     
                                  <input type="text"  name="EndTime" runat="server" id="EndTime" class="form-control" placeholder="13:00">    
									                          
							  </div>
                                
								  							
                 </div>
				  <div class="row">			
								<div class="col-md-2">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TypeofPermission%>" /></label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DropDownTypeofPermission"   runat="server" class="form-control">
									</asp:DropDownList>
                                </div>	  							
                 </div>
                </div>
				</div>   
				
				 <div class="row rt" runat="server" id="sick" style="display: none;">
                <div class="col-md-12 ">
                  <div class="row">
				  <div class="col-md-2">
                          <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TheGrantingOfTheSickLeaveCertificate%>" /></label>
                     </div>
                       <div class="col-md-4">                                                     
                        <input type="text"  name="IssuingAuthority" runat="server" id="IssuingAuthority" class="form-control" placeholder="">    
					        
					 </div>							
                 </div>
                </div>
				</div>
			   <div class="row rt">
                <div class="col-md-12">
                     <div class="row">
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
								</div>
								<div class="col-md-9  ">
									     <textarea class="form-control" runat="server" id="Notes" rows="3"></textarea>                               
									<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
									ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="from" Display="Dynamic" >
									</asp:RequiredFieldValidator> 
								</div>						
                           </div>
                </div>   			
            </div>  
			   <div class="row rt">
                <div class="col-md-12">
                     <div class="row">
								<div class="col-md-2">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Attachments%>" /></label>
								</div>
								<div class="col-md-9  ">
									     
                                    <asp:FileUpload ID="FileUploadControl" runat="server" />
								</div>						
                           </div>
                </div>   			
            </div> 
			   <div class="row rt">
                <div class="col-md-12">
                     <div class="row">
								<div class="col-md-2">
								</div>
								<div class="col-md-9  ">
									     
                                   <div runat="server" style="color:red;" class="MSG" id="MSG"> </div>
								</div>						
                           </div>
                </div>   			
            </div>   	
			
			
            <div class="row rt  botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" OnClientClick="isGreaterThanDateTime()"  CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
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


<script>

    function isGreaterThanDateTime() {
        if (new Date($("#toDate input").val()) >= new Date($("#toFrom input").val())) {
            $('#isGreaterThanDateTime input').val("Done");
        } else {

            $('#isGreaterThanDateTime input').val("dateerror");
        }
    } 
</script>