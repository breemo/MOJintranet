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




<asp:HiddenField ClientIDMode="Static" ID="hdnChildren" runat="server" />

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
	<div class="row rt  botx">
                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Employmenthistory%>" /></label>
                       </div>
        

	         <div  id="dynamicInputChildren">
			 <div  id="FirstItemEmploymenthistoryAA" style="display:none" >
                 </div>
               <div  id="FirstItemEmploymenthistory" >
					<div class="row rt">
							<div class="col-md-3">
							   <div class="row">
									<div class="col-md-4">
                                        <div class=" DivSID" style=" display: none;">
								 	<input type="text" name="SID" runat="server" id="SID0" class="form-control" placeholder="">
									
										</div>

								<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Designation%>" /></label>
							</div>
							<div class="col-md-8 DivDesignation">
								 	<input type="text" name="Designation" runat="server" id="Designation0" class="form-control" placeholder="">
									
										</div>
									</div>
							</div>
						   <div class="col-md-3">
								<div class="row">
									<div  class="col-md-4">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Organizationalunit%>" /></label>
									</div>
									<div  class="col-md-8 DivOrganizationalunit">
										<input type="text" name="Organizationalunit" runat="server" id="Organizationalunit0" class="form-control" placeholder="">
									</div> 
								  </div>
						   </div>
							<div class="col-md-3">
								<div class="row">
									<div  class="col-md-4">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Datefrom%>" /></label>
									</div>
									<div  class="col-md-8 ">
										<div class="input-group date DivDatefrom" data-provide="datepicker">
										<input autocomplete="off"  type="text" runat="server" id="Datefrom0" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
									</div> 
								  </div>
						   </div> 
							<div class="col-md-3">
								<div class="row">
									<div  class="col-md-4">
										<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Dateto%>" /></label>
									</div>
									<div  class="col-md-8 ">
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

                   </div>
                 </div>
	

    <div class="row rt ">
    <div class="col-md-6">
                    <a href="#" onclick="addEmploymenthistory();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
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


#dynamicInputChildren .new:nth-child(odd) {background-color: #f5e9b6;}
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
    var counter2 = 1;
    function addEmploymenthistory() {
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = $("#FirstItemEmploymenthistory")[0].innerHTML;
        var Itemhtml = $("#FirstItemEmploymenthistoryAA");
        Itemhtml.find(".DivDesignation")[0].innerHTML = "<input name='Designation' type=text' id='Designation" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivOrganizationalunit")[0].innerHTML = "<input name='Organizationalunit' type=text' id='Organizationalunit" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivDatefrom")[0].innerHTML = "<input autocomplete='off' name='Datefrom' type='text' id='Datefrom" + counter2 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivDateto")[0].innerHTML = "<input autocomplete='off' name='Dateto' type='text' id='Dateto" + counter2 + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerowEmploymenthistory(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementById('dynamicInputChildren').appendChild(newdiv);
        counter2++;
        document.getElementById('hdnChildren').value = counter2;
        $("#FirstItemEmploymenthistoryAA")[0].innerHTML = "";
    }
    function removerowEmploymenthistory(thi) {
        counter2--;
        document.getElementById('hdnChildren').value = counter2;
        thi.closest('.new').remove();
    }
</script>