<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImplicitKnowledgeWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.ImplicitKnowledgeWP.ImplicitKnowledgeWPUserControl" %>
<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV1" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV1" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV2" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV2" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV3" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV3" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV4" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV4" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV5" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV5" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV6" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV6" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV7" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV7" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV8" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV8" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV9" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV9" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV10" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV10" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV11" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV11" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV12" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV12" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV13" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV13" runat="server" />
<div id="posts" runat="server" class="small-thumbs alt">
     <div id="Edata">
         <div class=" DivPID" style=" display: none;">
								 	<input type="text" name="TOPID" runat="server" id="TOPID" class="form-control" placeholder="">									
										</div>
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
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, DateOfBirth%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EDateOfBirth" runat="server" id="EDateOfBirth" class="form-control" placeholder="">                                
									    </div>
                              </div>
					    </div>                  
                    </div>   
               </div>
    <hr />
	  <%--////--------------  1    -------------- ///--%>
	<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Employmenthistory%>" /></label>
                       </div>        
							<div class="row rt">
							   <div class="row rt col-md-12">							
								<div  class="col-md-3" style="text-align: center;" >
								<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Designation%>" /></label>
								</div>							
									<div  class="col-md-3" style="text-align: center;" >
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Organizationalunit%>" /></label>
									</div>								
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom%>" /></label>
									</div>							
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto%>" /></label>
									</div>							
								</div>  
						   </div>              
	        <div runat="server"  id="superDIV1" class="superDIV1">
			  <div  id="FirstItemEmploymenthistoryAA" style="display:none" >
                 </div>
               <div  id="FirstItemEmploymenthistory" >
					<div class="row rt">	
						<div  class="DivSID" style=" display: none;" >
						<input type="text"  name="SID" runat="server" id="SID0" class="form-control" placeholder="">
						</div>                       
						<div class="col-md-3 DivDesignation">
						<input type="text" name="Designation" runat="server" id="Designation0" class="form-control" placeholder="">
						</div>
						<div  class="col-md-3 DivOrganizationalunit">
							<input type="text" name="Organizationalunit" runat="server" id="Organizationalunit0" class="form-control" placeholder="">
						</div>
						<div  class="col-md-3 ">
							<div class="input-group date DivDatefrom" data-provide="datepicker">
							<input autocomplete="off"  type="text" runat="server" id="Datefrom0" class="form-control">
							<div class="input-group-addon">
								<span class="icon-calendar-alt1"></span>
							</div>									
								</div>
						</div>						
						<div  class="col-md-3 ">
							<div class="input-group date DivDateto" data-provide="datepicker">
							<input autocomplete="off"  type="text" runat="server" id="Dateto0" class="form-control">
							<div class="input-group-addon">
								<span class="icon-calendar-alt1"></span>
							</div>
						</div>
						</div>			 						   
					</div>
                </div>
            </div>
			<div class="row rt ">
    <div class="col-md-6">
                    <a  onclick="addEmploymenthistory();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>
    <hr />
	  <%--////--------------  2    -------------- ///--%>
	<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Qualifications%>" /></label>
                       </div>        
							<div class="row rt">
							   <div class="row rt col-md-12">							
								<div  class="col-md-3" style="text-align: center;" >
								<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Qualification%>" /></label>
								</div>							
									<div  class="col-md-2" style="text-align: center;" >
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Major%>" /></label>
									</div>								
									<div  class="col-md-2" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Institution%>" /></label>
									</div>							
									<div  class="col-md-2" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Country%>" /></label>
									</div>	
										<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, GraduationYear%>" /></label>
									</div>										
								</div>  
						   </div>              
	        <div runat="server"  id="superDIV2" class="superDIV2">
			  <div  id="FirstItemAA2" style="display:none" >
                 </div>
               <div  id="FirstItem2" >
					<div class="row rt">	
						<div  class="DivSID2" style=" display: none;" >
						<input type="text"  name="SID2" runat="server" id="SID02" class="form-control" placeholder="">
						</div>                       
						<div class="col-md-3 DivQualification">
						<input type="text" name="Qualification" runat="server" id="Qualification0" class="form-control" placeholder="">
						</div>
						<div  class="col-md-2 DivMajor">
							<input type="text" name="Major" runat="server" id="Major0" class="form-control" placeholder="">
						</div>
						<div  class="col-md-2 DivInstitution">
							<input type="text" name="Institution" runat="server" id="Institution0" class="form-control" placeholder="">
						</div>
						
						<div class="col-md-2 DivCountry ">
                                   <label><asp:Literal runat="server" id="DDCountry"/></label>                        
                                    <asp:DropDownList ID="DropDownCountry" runat="server" class="form-control">
									</asp:DropDownList>
                                </div>					
						<div  class="col-md-3 ">
							<div class="input-group date DivGraduationYear" data-provide="datepicker">
							<input autocomplete="off"  type="text" runat="server" id="GraduationYear0" class="form-control">
							<div class="input-group-addon">
								<span class="icon-calendar-alt1"></span>
							</div>									
								</div>
						</div>							 						   
					</div>
                </div>
            </div>
    <div class="row rt ">
    <div class="col-md-6">
                    <a onclick="addQualifications();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>


 <%--////--------------  3    -------------- ///--%>
	<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, LanguageSkills%>" /></label>
                       </div>        
							<div class="row rt">
							   <div class="row rt col-md-12">							
								<div  class="col-md-3" style="text-align: center;" >
								<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Language %>" /></label>
								</div>							
									<div  class="col-md-3" style="text-align: center;" >
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, ReadingLevel%>" /></label>
									</div>								
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, WritingLevel%>" /></label>
									</div>							
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, ConversationLevel%>" /></label>
									</div>	
																			
								</div>  
						   </div>              
	        <div runat="server"  id="superDIV3" class="superDIV3">
			  <div  id="FirstItemAA3" style="display:none" >
                 </div>
               <div  id="FirstItem3" >
					<div class="row rt">	
						<div  class="DivSID3" style=" display: none;" >
						<input type="text"  name="SID3" runat="server" id="SID03" class="form-control" placeholder="">
						</div>                       
						<div class="col-md-3 DivLanguage">
						<input type="text" name="Language" runat="server" id="Language0" class="form-control" placeholder="">
						</div>						
						<div class="col-md-3 DivReadingLevel ">
                                   <label><asp:Literal runat="server" id="DDReadingLevel"/></label>                        
                                    <asp:DropDownList ID="DropDownReadingLevel" runat="server" class="form-control">
									</asp:DropDownList>
                                </div>	
						<div class="col-md-3 DivWritingLevel ">
							   <label><asp:Literal runat="server" id="DDWritingLevel"/></label>                        
								<asp:DropDownList ID="DropDownWritingLevel" runat="server" class="form-control">
								</asp:DropDownList>
							</div>		
							<div class="col-md-3 DivConversationLevel ">
							   <label><asp:Literal runat="server" id="DDConversationLevel"/></label>                        
								<asp:DropDownList ID="DropDownConversationLevel" runat="server" class="form-control">
								</asp:DropDownList>
							</div>								 						   
					</div>
                </div>
            </div>
			<div class="row rt ">
    <div class="col-md-6">
                    <a  onclick="addLanguageSkills();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>

 <%--////--------------  4    -------------- ///--%>
	<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TechnicalSkills%>" /></label>
                       </div>        
							<div class="row rt">
							   <div class="row rt col-md-12">							
								<div  class="col-md-3" style="text-align: center;" >
								<label><asp:Literal runat="server" Text="<%$ Resources:Resource, SkillType %>" /></label>
								</div>							
									<div  class="col-md-3" style="text-align: center;" >
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, SkillLevel%>" /></label>
									</div>								
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, AreaOfApplication%>" /></label>
									</div>							
									<div  class="col-md-3" style="text-align: center;">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Notes%>" /></label>
									</div>	
																			
								</div>  
						   </div>              
	        <div runat="server"  id="superDIV4" class="superDIV4">
			  <div  id="FirstItemAA4" style="display:none" >
                 </div>
               <div  id="FirstItem4" >
					<div class="row rt">	
						<div  class="DivSID4" style=" display: none;" >
						<input type="text"  name="SID4" runat="server" id="SID04" class="form-control" placeholder="">
						</div>                       
						<div class="col-md-3 DivSkillType">
						<input type="text" name="SkillType" runat="server" id="SkillType0" class="form-control" placeholder="">
						</div>						
						<div class="col-md-3 DivSkillLevel ">
                                   <label><asp:Literal runat="server" id="DDSkillLevel"/></label>                        
                                    <asp:DropDownList ID="DropDownSkillLevell" runat="server" class="form-control">
									</asp:DropDownList>
                                </div>	
						<div class="col-md-3 DivAreaOfApplication">
						<input type="text" name="AreaOfApplication" runat="server" id="AreaOfApplication0" class="form-control" placeholder="">
						</div>	
						<div class="col-md-3 DivNotes4">
						<input type="text" name="Notes4" runat="server" id="Notes04" class="form-control" placeholder="">
						</div>	


						
					</div>
                </div>
            </div>
			<div class="row rt ">
    <div class="col-md-6">
                    <a  onclick="addTechnicalSkills();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>









		
            <div class="row rt  botx">
                <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
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
.new:nth-child(odd) {background-color: #f5e9b6;}
.row.rt {
    margin-bottom: 1px;
    margin-top: 1px;
    padding: 1px;
}
#dynamicInput .row table {
    margin-bottom: 1px;
}
.superDIV1 .row table {
    margin-bottom: 1px;
}
.HusbandORWife .row table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;
}
.rowI {
    padding-bottom: 10px;
}
.DivCountry label ,.DivReadingLevel label ,.DivWritingLevel label ,.DivConversationLevel label  {
    display: none;
}

</style>
<script>
    $(document).ready(function () {
        $(".RadiB label").addClass("radio-button-click-target");
        $(".RadiB input").addClass("radio-button");
        var idis = $(".DivHasGovernmentHousingAllowance input").attr('id');
        $(".DivHasGovernmentHousingAllowance label").attr('for', idis);
        var idis2 = $(".DivHasGovernmentHousingPercentageAllowance input").attr('id');
        $(".DivHasGovernmentHousingPercentageAllowance label").attr('for', idis2);

        $(".DivHasGovernmentHousingAllowance input").addClass("checkbox");
        $(".DivHasGovernmentHousingPercentageAllowance input").addClass("checkbox");

        //$('.CheckBoxThim label').each(function () {
        //    var valuex = "<span class='checkbox-box'></span>" + this.innerHTML;
        //    this.innerHTML = valuex;
    });

    $('.datepicker').datepicker({
        dateFormat: 'dd/mm/yyyy',
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
    var counter1 = 1;
    if (document.getElementById('hdnsuperDIV1').value != "") {
        counter1 = Number(document.getElementById('hdnsuperDIV1').value) + 1;
    }
    function addEmploymenthistory() {
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = $("#FirstItemEmploymenthistory")[0].innerHTML;
        var Itemhtml = $("#FirstItemEmploymenthistoryAA");
        Itemhtml.find(".DivSID")[0].innerHTML = "<input name='SID' type=text' id='SID" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDesignation")[0].innerHTML = "<input name='Designation' type=text' id='Designation" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivOrganizationalunit")[0].innerHTML = "<input name='Organizationalunit' type=text' id='Organizationalunit" + counter1 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDatefrom")[0].innerHTML = "<input autocomplete='off' name='Datefrom' type='text' id='Datefrom" + counter1 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivDateto")[0].innerHTML = "<input autocomplete='off' name='Dateto' type='text' id='Dateto" + counter1 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerowEmploymenthistory(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV1")[0].appendChild(newdiv);
        counter1++;
        document.getElementById('hdnsuperDIV1').value = counter1;
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = "";
    }
    function removerowEmploymenthistory(thi) {
        counter1--;
        document.getElementById('hdnsuperDIV1').value = counter1;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////2----------------------------------------------------
    var counter2 = 1;
    if (document.getElementById('hdnsuperDIV2').value != "") {
        counter2 = Number(document.getElementById('hdnsuperDIV2').value) + 1;
    }
    function addQualifications() {
        $("#FirstItemAA2")[0].innerHTML = $("#FirstItem2")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA2");
        Itemhtml.find(".DivSID2")[0].innerHTML = "<input name='SID2' type=text' id='SID2" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivQualification")[0].innerHTML = "<input name='Qualification' type=text' id='Qualification" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivMajor")[0].innerHTML = "<input name='Major' type=text' id='Major" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivInstitution")[0].innerHTML = "<input name='Institution' type=text' id='Institution" + counter2 + "' class='form-control' placeholder=''>";


        Itemhtml.find(".DivCountry select")[0].setAttribute("name", "DropDownCountry");
        Itemhtml.find(".DivCountry select")[0].setAttribute("id", "DropDownCountry" + counter2 + "");

        Itemhtml.find(".DivGraduationYear")[0].innerHTML = "<input autocomplete='off' name='GraduationYear' type='text' id='GraduationYear" + counter2 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerowQualifications(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV2")[0].appendChild(newdiv);
        counter2++;
        document.getElementById('hdnsuperDIV2').value = counter2;
        $("#FirstItemAA2")[0].innerHTML = "";
    }
    function removerowQualifications(thi) {
        counter2--;
        document.getElementById('hdnsuperDIV2').value = counter2;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////3----------------------------------------------------
    var counter3 = 1;
    if (document.getElementById('hdnsuperDIV3').value != "") {
        counter3 = Number(document.getElementById('hdnsuperDIV3').value) + 1;
    }
    function addLanguageSkills() {
        $("#FirstItemAA3")[0].innerHTML = $("#FirstItem3")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA3");
        Itemhtml.find(".DivSID3")[0].innerHTML = "<input name='SID3' type=text' id='SID3" + counter3 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivLanguage")[0].innerHTML = "<input name='Language' type=text' id='Language" + counter3 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivReadingLevel select")[0].setAttribute("name", "DropDownReadingLevel");
        Itemhtml.find(".DivReadingLevel select")[0].setAttribute("id", "DropDownReadingLevel" + counter3 + "");
        Itemhtml.find(".DivWritingLevel select")[0].setAttribute("name", "DropDownWritingLevel");
        Itemhtml.find(".DivWritingLevel select")[0].setAttribute("id", "DropDownWritingLevel" + counter3 + "");
        Itemhtml.find(".DivConversationLevel select")[0].setAttribute("name", "DropDownConversationLevel");
        Itemhtml.find(".DivConversationLevel select")[0].setAttribute("id", "DropDownConversationLevel" + counter3 + "");

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerowLanguageSkills(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV3")[0].appendChild(newdiv);
        counter3++;
        document.getElementById('hdnsuperDIV3').value = counter3;
        $("#FirstItemAA3")[0].innerHTML = "";
    }
    function removerowLanguageSkills(thi) {
        counter3--;
        document.getElementById('hdnsuperDIV3').value = counter3;
        thi.closest('.new').remove();
    }
    ////////////////////////////////////////4----------------------------------------------------
    var counter4 = 1;
    if (document.getElementById('hdnsuperDIV4').value != "") {
        counter4 = Number(document.getElementById('hdnsuperDIV4').value) + 1;
    }
    function addTechnicalSkills() {
        $("#FirstItemAA4")[0].innerHTML = $("#FirstItem4")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA4");
        Itemhtml.find(".DivSID4")[0].innerHTML = "<input name='SID4' type=text' id='SID4" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSkillType")[0].innerHTML = "<input name='SkillType' type=text' id='SkillType" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivSkillLevel select")[0].setAttribute("name", "DropDownSkillLevell");
        Itemhtml.find(".DivSkillLevel select")[0].setAttribute("id", "DropDownSkillLevell" + counter4 + "");
        Itemhtml.find(".DivAreaOfApplication")[0].innerHTML = "<input name='AreaOfApplication' type=text' id='AreaOfApplication" + counter4 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivNotes4")[0].innerHTML = "<input name='Notes4' type=text' id='Notes4" + counter4 + "' class='form-control' placeholder=''>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerowTechnicalSkills(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV4")[0].appendChild(newdiv);
        counter4++;
        document.getElementById('hdnsuperDIV4').value = counter4;
        $("#FirstItemAA4")[0].innerHTML = "";
    }
    function removerowTechnicalSkills(thi) {
        counter4--;
        document.getElementById('hdnsuperDIV4').value = counter4;
        thi.closest('.new').remove();
    }
</script>