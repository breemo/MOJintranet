<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AffirmationSocialSituationUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.AffirmationSocialSituation.AffirmationSocialSituationUserControl" %>


<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>



<asp:HiddenField ClientIDMode="Static" ID="hdnHusbandORWife" runat="server" />
<asp:HiddenField ClientIDMode="Static" ID="hdnChildren" runat="server" />
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, AffirmationSocialSituation%>" />
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
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HiringDate%>" /></label>
                                </div>
                                <div  class="col-md-8">
                                    <input type="text" disabled name="EHiringDate" runat="server" id="EHiringDate" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Degree%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EDegree" runat="server" id="EDegree" class="form-control" placeholder="">
                                
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
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, BasicSalary%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EBasicSalary" runat="server" id="EBasicSalary" class="form-control" placeholder="">
                                
									    </div>
                              </div>
					    </div>                  
                    </div>    
               
               </div>

               <hr />
                <div class="row rt">

                <div class="col-md-6 HusbandORWife">

                    <div class="row">

                        <div class="col-md-2">
                            <label> <asp:Literal runat="server" Text="<%$ Resources:Resource, Data%>" /></label>
                        </div>

                        <div class="col-md-9 RadiB">
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
								<div class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, DateMarriage%>" /></label>
								</div>
								<div class="col-md-8">
									<div class="input-group date DivDateMarriage" data-provide="datepicker">
										<input  type="text" runat="server" id="DateMarriage0" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
								</div>
                           </div>
					</div>
                       <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Employer%>" /></label>
								</div>
								<div  class="col-md-8 DivEmployer">
									<input type="text" name="Employer" runat="server" id="Employer0" class="form-control" placeholder="">
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
                        <div class="col-md-8 DivWorkSector RadiB">
                               <asp:RadioButtonList ID="WorkSector0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
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
                                <div class="col-md-7">
                    
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HasGovernmentHousingAllowance%>" /></label>
                        </div>
                        <div    class="col-md-2 DivHasGovernmentHousingAllowance">
                              <asp:CheckBox ID="HasGovernmentHousingAllowance0" runat="server" />
                            <label for="HasGovernmentHousingAllowance0" class="checkbox-click-target">
                                <span class="checkbox-box"></span></label>
                        </div>
                                    </div>
                                </div>
                   <div class="col-md-6">
                            <div class="row">
                        <div class="col-md-7">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, HasGovernmentHousingPercentageAllowance%>" /></label>
                        </div>
                        <div  class="col-md-2 DivHasGovernmentHousingPercentageAllowance">
                            <asp:CheckBox ID="HasGovernmentHousingPercentageAllowance0" runat="server" />
                            <label for="HasGovernmentHousingPercentageAllowance0" class="checkbox-click-target">
                                <span class="checkbox-box"></span></label>
                        </div>
						</div>
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
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-2">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                                </div>
                                <div  class="col-md-4 DivChildrenName">
                                    <input type="text" name="ChildrenName" runat="server" id="ChildrenName0" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>							
                        </div>
					<div class="row rt">
                        <div class="col-md-6">
                           <div class="row">
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Gender%>" /></label>
                        </div>
                        <div class="col-md-8 DivGender RadiB ">
                               <asp:RadioButtonList ID="Gender0" name="GenderR0" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
									</div>
                                </div>
					</div>
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
                </div>

                   </div>
                 </div>
	

    <div class="row rt ">
    <div class="col-md-6">
                    <a href="#" onclick="addInputChildren();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>

    <hr />
    <div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ChangeSocialStatus%>" /></label>
                       </div>
       

        
            <div class="row rt">

                <div class="col-md-6">

                    <div class="row">

                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                        </div>

                        <div class="col-md-8">
                            <input type="text" runat="server"  id="txtName" class="form-control" placeholder="">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtName" Display="Dynamic" >
            </asp:RequiredFieldValidator>
                            </div>
                    </div>


                </div>
                
            </div>
            <div class="row rt">

                <div class="col-md-6">

                    <div class="row">

                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, RelationshipType%>" /></label>
                        </div>

                        <div class="col-md-8">
                            <input type="text" id="RelationshipType"  runat="server" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="RelationshipType" Display="Dynamic" >
            </asp:RequiredFieldValidator>
                        </div>
                    </div>


                </div>
               
            </div>
              <div class="row rt">

                <div class="col-md-6">

                    <div class="row">

                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ChangeReason%>" /></label>
                        </div>

                        <div class="col-md-8">
                            <input type="text" id="ChangeReason"  runat="server" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ChangeReason" Display="Dynamic" >
            </asp:RequiredFieldValidator> 
                        </div>
                    </div>


                </div>
               
            </div>
            
    
    <div class="row rt">

                <div class="col-md-6">

                    <div class="row">

                        <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ChangeDate%>" /></label>
                        </div>

                        <div class="col-md-8">

                            <div class="input-group date" data-provide="datepicker">
                                <input type="text"  runat="server" id="ChangeDate" class="form-control">
                                <div class="input-group-addon">
                                    <span class="icon-calendar-alt1"></span>
                                </div>
                            </div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorChangeDate" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ChangeDate" Display="Dynamic" >
            </asp:RequiredFieldValidator> 

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
        Itemhtml.find(".DivDateMarriage")[0].innerHTML = "<input name='DateMarriage' type='text' id='DateMarriage" + counter + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivEmployer")[0].innerHTML = "<input name='Employer' type=text' id='Employer" + counter + "' class='form-control' placeholder=''>";
        var radio1 = Itemhtml.find(".DivWorkSector label")[0].innerText;
        var radio2 = Itemhtml.find(".DivWorkSector label")[1].innerText;
        var WorkSectorhtm = "<input name='WorkSector' type='text' id='worksectorvalue" + counter + "' style='display:none' placeholder=''>";
        WorkSectorhtm += "<table id='WorkSector" + counter + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td>";
        WorkSectorhtm += "<input class='radio-button'  onchange=\"handleChange('worksectorvalue" + counter + "','" + radio1 + "');\"  id='WorkSector" + counter + "_0' type='radio' name='WorkSectorR" + counter + "' value='" + radio1 + "'><label for='WorkSector" + counter + "_0' class='radio-button-click-target'> <span class='radio-button-circle'></span>" + radio1 + "</label></td><td>"
        WorkSectorhtm += "<input  class='radio-button' onchange=\"handleChange('worksectorvalue" + counter + "','" + radio2 + "');\" id='WorkSector" + counter + "_1' type='radio' name='WorkSectorR" + counter + "' value='" + radio2 + "'><label for='WorkSector" + counter + "_1'  class='radio-button-click-target'><span class='radio-button-circle'></span>" + radio2 + "</label></td>";
        WorkSectorhtm += "</tr></tbody></table>";
        Itemhtml.find(".DivWorkSector")[0].innerHTML = WorkSectorhtm;
        Itemhtml.find(".DivHiringDate")[0].innerHTML = "<input name='HiringDate' type='text' id='HiringDate" + counter + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";

        Itemhtml.find(".DivHasGovernmentHousingAllowance")[0].innerHTML = "<input class='checkbox' id='HasGovernmentHousingAllowance" + counter + "' type='checkbox' name='HasGovernmentHousingAllowance" + counter + "'><label for='HasGovernmentHousingAllowance" + counter + "' class='checkbox-click-target'><span class='checkbox-box'></span></label >";
        Itemhtml.find(".DivHasGovernmentHousingPercentageAllowance")[0].innerHTML = "<input class='checkbox' id='HasGovernmentHousingPercentageAllowance" + counter + "' type='checkbox' name='HasGovernmentHousingPercentageAllowance" + counter + "'><label for='HasGovernmentHousingPercentageAllowance" + counter + "' class='checkbox-click-target'><span class='checkbox-box'></span></label >";
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
        var radio1 = Itemhtml.find(".DivGender label")[0].innerText;
        var radio2 = Itemhtml.find(".DivGender label")[1].innerText;

        var GenderhtmlR = "<input name='Gender' type='text' id='genderaa" + counter2 + "' style='display:none' placeholder=''>";
        GenderhtmlR += "<table id='Gender" + counter2 + "' class='checkbox-click-target' style='width:100%;'><tbody><tr><td> ";
        GenderhtmlR += "<input class='radio-button' onchange=\"handleChange('genderaa" + counter2 + "','" + radio1 + "');\" id='Gender" + counter2 + "_0' type='radio' name='GenderR" + counter2 + "' value='" + radio1 + "'> ";
        GenderhtmlR += "<label for='Gender" + counter2 + "_0' class='radio-button-click-target' ><span class='radio-button-circle'></span>" + radio1 + "</label></td><td>";
        GenderhtmlR += "<input class='radio-button' onchange=\"handleChange('genderaa" + counter2 + "','" + radio2 + "');\" id='Gender" + counter2 + "_1' type='radio' name='GenderR" + counter2 + "' value='" + radio2 + "'>";
        GenderhtmlR += "<label for='Gender" + counter2 + "_1' class='radio-button-click-target'><span class='radio-button-circle'></span>" + radio2 + "</label></td></tr></tbody></table>";
        Itemhtml.find(".DivGender ")[0].innerHTML = GenderhtmlR;
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
        if (this.value == "wife") {
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