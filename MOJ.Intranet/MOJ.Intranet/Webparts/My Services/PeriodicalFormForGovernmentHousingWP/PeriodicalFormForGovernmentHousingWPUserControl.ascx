<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PeriodicalFormForGovernmentHousingWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.PeriodicalFormForGovernmentHousingWP.PeriodicalFormForGovernmentHousingWPUserControl" %>



<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>



<asp:HiddenField ClientIDMode="Static" ID="hdnHusbandORWife" runat="server" />
<asp:HiddenField ClientIDMode="Static" ID="hdnChildren" runat="server" />
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, PeriodicalFormForGovernmentHousing%>" />
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
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Nationality%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="ENationality" disabled runat="server" id="ENationality" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WorkLocation%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EWorkLocation" runat="server" id="EWorkLocation" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>                  
                    </div>
                <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Category%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" name="ECategory" disabled runat="server" id="ECategory" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder="">
                                
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
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, BasicSalary%>" /></label>
								</div>
								<div class="col-md-8 ">
										  <input type="text" disabled name="EBasicSalary" runat="server" id="EBasicSalary" class="form-control" placeholder="">
									
											</div>
								  </div>
					    </div> 
						<div class="col-md-6">											
						</div>						
                    </div>  					
               
               </div>
			<hr />	
	<div id="masterdata">
            <div class="row rt">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ContractNumber%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="ContractNumber" class="form-control" placeholder="">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ContractNumber" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
				<div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ApartmentNumber%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="ApartmentNumber" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server" 
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ApartmentNumber" Display="Dynamic" >
                        </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>                
            </div>
          <div class="row rt">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Owner%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="Owner" class="form-control" placeholder="">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="Owner" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
				<div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, NumberOfRooms%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="NumberOfRooms" class="form-control" placeholder="">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="NumberOfRooms" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                            </div>
                    </div>
                </div>                
            </div>
			<div class="row rt">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ACtype%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="ACtype" class="form-control" placeholder="">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ACtype" Display="Dynamic" >
    </asp:RequiredFieldValidator>     
                            </div>
                    </div>
                </div>
				<div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, LeasingContractEndDate%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="LeasingContractEndDate" class="form-control" placeholder="">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="LeasingContractEndDate" Display="Dynamic" >
    </asp:RequiredFieldValidator> 
                            </div>
                    </div>
                </div>                
            </div>
			<div class="row rt">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Mobile%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="Mobile" class="form-control" placeholder="">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="Mobile" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
				<div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HomePhone %>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="HomePhone" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="HomePhone" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                            </div>
                    </div>
                </div>                
            </div>
			<div class="row rt">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WorkPhone%>" /></label>
                        </div>
                        <div class="col-md-8">
                            <input type="text" runat="server" id="WorkPhone" class="form-control" placeholder="">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
    ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="WorkPhone" Display="Dynamic" >
    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
				<div class="col-md-6">
                   
                </div>                
            </div>
		</div>
			<hr/>
                <div class="row rt">
                <div class="col-md-6 HusbandORWife">
                    <div class="row">
                        <div class="col-md-2">
                            <label> <asp:Literal runat="server" Text="<%$ Resources:Resource, Data%>" /></label>
                        </div>
                        <div class="col-md-9">
                       <asp:RadioButtonList ID="RBHusbandORWife" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                </div>
            </div>
            <hr />     
            <div  id="dynamicInput">
                 <div  id="FirstItemAA" style="display:none" >
                 </div>
               <div  id="FirstItem" >
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-8 DivName">
                                    <input type="text" name="Name" runat="server" id="Name0" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>	
                              <div class="col-md-6">
								<div class="row">
									<div class="col-md-4">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, HiringDate%>" /></label>
									</div>
									<div class="col-md-8">
										<div  class="input-group date DivHiringDate" data-provide="datepicker">
											<input type="text" runat="server" id="HiringDate0" class="form-control">
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
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, WorkSector%>" /></label>
                        </div>
                        <div class="col-md-8 DivWorkSector">
                               <asp:RadioButtonList ID="WorkSector0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
									</div>
                                </div>
                            </div>
                       <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, BasicSalary%>" /></label>
								</div>
								<div  class="col-md-8 DivBasicSalary">
									<input type="text" name="BasicSalary" runat="server" id="BasicSalary0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                </div>
                 <div class="row rt">
							<div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, LastEntryDate%>" /></label>
								</div>
								<div  class="col-md-8 DivLastEntryDate">
									<input type="text" name="LastEntryDate" runat="server" id="LastEntryDate0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>				 
					    <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, LastExitDate%>" /></label>
								</div>
								<div  class="col-md-8 DivLastExitDate">
									<input type="text" name="LastExitDate" runat="server" id="LastExitDate0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>					   
                </div>
               <div class="row rt">
                        
                   <div class="col-md-6">
                            <div class="row">
                        <div class="col-md-7">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HasGovernmentHousingPercentageAllowance%>" /></label>
                        </div>
                        <div  class="col-md-2 DivHasGovernmentHousingPercentageAllowance">
                            <asp:CheckBox ID="HasGovernmentHousingPercentageAllowance0" runat="server" />
                        </div>
						</div>
                       </div>
					    <div class="col-md-6">
                            
                       </div>
                </div>			
				 </div>
			</div>
 <div class="row rt ">
    <div class="col-md-6">
                    <a href="#" id="AddWife" style="display:none" onclick="addInput();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>
    <hr />
<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Children%>" /></label>
                       </div>
        

	         <div  id="dynamicInputChildren">
			 <div  id="FirstItemChildrenAA" style="display:none" >
                 </div>
               <div  id="FirstItemChildren" >
                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-8 DivChildrenName">
                                    <input type="text" name="ChildrenName" runat="server" id="ChildrenName0" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
						<div class="col-md-6">
							<div class="row">
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Gender%>" /></label>
                        </div>
                        <div class="col-md-8 DivGender">
                               <asp:RadioButtonList ID="Gender0" name="GenderR0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
									</div>
                                </div>
					</div>							
                        </div>
					
					<div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, age%>" /></label>
								</div>
								<div  class="col-md-8 DivAge">
									<input type="text" name="Age" runat="server" id="Age0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
					   
					 <div class="col-md-6">
							<div class="row">
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Career%>" /></label>
                        </div>
                        <div class="col-md-8 DivCareer">
                               <asp:RadioButtonList ID="Career0" name="Career0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
									</div>
                                </div>
					</div>
					   
                </div>
				
				<div class="row rt">
				 <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, BasicSalary%>" /></label>
								</div>
								<div  class="col-md-8 DivBasicSalary">
									<input type="text" name="SBasicSalary" runat="server" id="SBasicSalary0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                        <div class="col-md-6">
                            <div class="row">
                        <div class="col-md-5">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HousingAllowance%>" /></label>
                        </div>
                        <div  class="col-md-2 DivHousingAllowance">
                            <asp:CheckBox ID="HousingAllowance0" runat="server" />
                        </div>
						</div>
                       </div>
					   
					
					   
                </div>
				
				
				
				    <div class="row rt">
							<div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, LastEntryDate%>" /></label>
								</div>
								<div  class="col-md-8 DivLastEntryDate">
									<input type="text" name="SLastEntryDate" runat="server" id="SLastEntryDate0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>				 
					    <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, LastExitDate%>" /></label>
								</div>
								<div  class="col-md-8 DivLastExitDate">
									<input type="text" name="SLastExitDate" runat="server" id="SLastExitDate0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>					   
                </div>
				
				
				
				
				
				

                   </div>
                 </div>
	

    <div class="row rt ">
    <div class="col-md-6">
                    <a href="#" onclick="addInputChildren();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
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
    margin-top: 1px;
    padding: 1px;
}
#dynamicInputChildren .row table {
       margin-bottom: 1px;
    margin-top: 1px;
    padding: 1px;
}
.HusbandORWife .row table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;

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


<script>
    var counter = 1;
    var limit = 3;
    function addInput() {
        $("#FirstItemAA")[0].innerHTML = $("#FirstItem")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA");

        Itemhtml.find(".DivName")[0].innerHTML = "<input name='Name' type=text' id='Name" + counter + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivHiringDate")[0].innerHTML = "<input name='HiringDate' type='text' id='HiringDate" + counter + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";

        var radio1 = Itemhtml.find(".DivWorkSector label")[0].innerHTML;
        var radio2 = Itemhtml.find(".DivWorkSector label")[1].innerHTML;
        var WorkSectorhtm = "<input name='WorkSector' type='text' id='worksectorvalue" + counter + "' style='display:none' placeholder=''>";
        WorkSectorhtm += "<table id='WorkSector" + counter + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td>";
        WorkSectorhtm += "<input  onchange=\"handleChange('worksectorvalue" + counter + "','" + radio1 + "');\"  id='WorkSector" + counter + "_0' type='radio' name='WorkSectorR" + counter + "' value='" + radio1 + "'><label >" + radio1 + "</label></td><td>"
        WorkSectorhtm += "<input onchange=\"handleChange('worksectorvalue" + counter + "','" + radio2 + "');\" id='WorkSector" + counter + "_1' type='radio' name='WorkSectorR" + counter + "' value='" + radio2 + "'><label>" + radio2 + "</label></td>";
        WorkSectorhtm += "</tr></tbody></table>";
        Itemhtml.find(".DivWorkSector")[0].innerHTML = WorkSectorhtm;
        Itemhtml.find(".DivBasicSalary")[0].innerHTML = "<input name='BasicSalary' type=text' id='BasicSalary" + counter + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLastEntryDate")[0].innerHTML = "<input name='LastEntryDate' type=text' id='LastEntryDate" + counter + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLastExitDate")[0].innerHTML = "<input name='LastExitDate' type=text' id='LastExitDate" + counter + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivHasGovernmentHousingPercentageAllowance")[0].innerHTML = "<input id='HasGovernmentHousingPercentageAllowance" + counter + "' type='checkbox' name='HasGovernmentHousingPercentageAllowance" + counter + "'>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "MoreThanOneWife";
        newdiv.setAttributeNode(att);
        var classis = "";
        if (counter % 2 === 0) {
            classis = "oddRow";
        } else { classis = "evenRow"; }
        var allhtml = "<div class='" + classis + "'> <hr>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementById('dynamicInput').appendChild(newdiv);
        counter++;
        document.getElementById('hdnHusbandORWife').value = counter;
        $("#FirstItemAA")[0].innerHTML = "";
    }

    var counter2 = 1;

    function addInputChildren() {
        $("#FirstItemChildrenAA")[0].innerHTML = $("#FirstItemChildren")[0].innerHTML;
        var Itemhtml = $("#FirstItemChildrenAA");
        Itemhtml.find(".DivChildrenName")[0].innerHTML = "<input name='ChildrenName' type=text' id='ChildrenName" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivAge")[0].innerHTML = "<input name='Age' type=text' id='Age" + counter2 + "' class='form-control' placeholder=''>";

        var radio1 = Itemhtml.find(".DivGender label")[0].innerHTML;
        var radio2 = Itemhtml.find(".DivGender label")[1].innerHTML;
        var GenderhtmlR = "<input name='Gender' type='text' id='genderaa" + counter2 + "' style='display:none' placeholder=''>";
        GenderhtmlR += "<table id='Gender" + counter2 + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td> ";
        GenderhtmlR += "<input onchange=\"handleChange('genderaa" + counter2 + "','" + radio1 + "');\" id='Gender" + counter2 + "_0' type='radio' name='GenderR" + counter2 + "' value='" + radio1 + "'> ";
        GenderhtmlR += "<label >" + radio1 + "</label></td><td>";
        GenderhtmlR += "<input onchange=\"handleChange('genderaa" + counter2 + "','" + radio2 + "');\" id='Gender" + counter2 + "_1' type='radio' name='GenderR" + counter2 + "' value='" + radio2 + "'>";
        GenderhtmlR += "<label>" + radio2 + "</label></td></tr></tbody></table>";
        Itemhtml.find(".DivGender ")[0].innerHTML = GenderhtmlR;
        var radioa = Itemhtml.find(".DivCareer label")[0].innerHTML;
        var radiob = Itemhtml.find(".DivCareer label")[1].innerHTML;
        var CareerhtmlR = "<input name='Career' type='text' id='Careerr" + counter2 + "' style='display:none' placeholder=''>";
        CareerhtmlR += "<table id='Career" + counter2 + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td> ";
        CareerhtmlR += "<input onchange=\"handleChange('Careerr" + counter2 + "','" + radioa + "');\" id='Career" + counter2 + "_0' type='radio' name='Careers" + counter2 + "' value='" + radioa + "'> ";
        CareerhtmlR += "<label >" + radioa + "</label></td><td>";
        CareerhtmlR += "<input onchange=\"handleChange('Careerr" + counter2 + "','" + radiob + "');\" id='Career" + counter2 + "_1' type='radio' name='Careers" + counter2 + "' value='" + radiob + "'>";
        CareerhtmlR += "<label>" + radiob + "</label></td></tr></tbody></table>";
        Itemhtml.find(".DivCareer")[0].innerHTML = CareerhtmlR;
        Itemhtml.find(".DivBasicSalary")[0].innerHTML = "<input name='SBasicSalary' type=text' id='SBasicSalary" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLastEntryDate")[0].innerHTML = "<input name='SLastEntryDate' type=text' id='SLastEntryDate" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLastExitDate")[0].innerHTML = "<input name='SLastExitDate' type=text' id='SLastExitDate" + counter2 + "' class='form-control' placeholder=''>";



        Itemhtml.find(".DivHousingAllowance")[0].innerHTML = "<input id='HousingAllowance" + counter2 + "' type='checkbox' name='HousingAllowance" + counter2 + "'>";




        var newdiv = document.createElement('div');
        var classis = "";
        if (counter2 % 2 === 0) {
            classis = "oddRow";
        } else { classis = "evenRow"; }
        var allhtml = "<div class='" + classis + "'> <hr>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementById('dynamicInputChildren').appendChild(newdiv);
        counter2++;
        document.getElementById('hdnChildren').value = counter2;
        $("#FirstItemChildrenAA")[0].innerHTML = "";
    }

    function handleChange(ID, radio1) {
        $("#" + ID).val(radio1)
    }
    $('.HusbandORWife input').change(function () {
        if (this.value == "الزوجة") {
            $('#AddWife').show();
        }
        else {
            document.getElementById('hdnHusbandORWife').value = "";
            counter = 1;
            $(".MoreThanOneWife").remove();
            $('#AddWife').hide();
        }
    });


</script>