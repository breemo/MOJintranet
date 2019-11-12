<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HostingRequestWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.HostingRequestWP.HostingRequestWPUserControl" %>
<asp:HiddenField ClientIDMode="Static" ID="hdncounter" runat="server" />

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, headHostingRequest%>" />
</h4>

<h4></h4>

 <div id="posts" runat="server" class="small-thumbs alt">
    <div class="tabs tabs-responsive clearfix fullwidthtabs">

        <ul class="tab-nav clearfix">
            <li><a href="#tab-responsive-1"><asp:Literal runat="server" Text="<%$ Resources:Resource, HotelHosting%>" /></a></li>
            <li><a href="#tab-responsive-2"><asp:Literal runat="server" Text="<%$ Resources:Resource, RoomBooking%>" /></a></li>
        </ul>

        <div class="tab-container">
              <div id="Edata"           style="display: none;">
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
                                <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
                            </div>
                            <div class="col-md-8 ">
                                      <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder="">
                                
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
               </div>
            <div class="tab-content clearfix" id="tab-responsive-1">
                
                <div class="inskdnew inskdnew2">

                     <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Emirate%>" /></label>
                                </div>
                                <div class="col-md-8">
                                   <label><asp:Literal runat="server" id="DDE"/></label>
                        
                                    <asp:DropDownList class="form-control form-control-sm" ID="DropDownEmirates" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>

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
                        <div class="col-md-8 DivName">
                                    <input required type="text" name="PName" runat="server" id="PName0" class="form-control" placeholder="">
                                </div>
                                </div>
					</div>
                       <div class="col-md-6">
                            <div class="row">
								<div  class="col-md-4">
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, Job%>" /></label>
								</div>
								<div  class="col-md-8 DivJob">
									<input required type="text" name="Job" runat="server" id="Job0" class="form-control" placeholder="">
								</div> 
                              </div>
                       </div>
                </div>
				<div class="row rt">
                        <div class="col-md-6">
                           <div class="row">
                                <div class="col-md-4">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, from%>" /></label>
                        </div>
                        <div class="col-md-8">
						
                                 <div class="input-group date Divfrom" data-provide="datepicker">
										<input  autocomplete="off" required type="text" runat="server" id="from0" class="form-control">
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
									<label><asp:Literal runat="server" Text="<%$ Resources:Resource, to%>" /></label>
								</div>
								<div  class="col-md-8">
									<div class="input-group date Divto" data-provide="datepicker">
										<input autocomplete="off" required type="text" runat="server" id="to0" class="form-control">
										<div class="input-group-addon">
											<span class="icon-calendar-alt1"></span>
										</div>
									</div>
								</div> 
                              </div>
                       </div>
                </div>
				<div class="row rt fleb">
                        <div class="col-md-2">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, BookingDetails%>" /></label>
                        </div>
                        <div class="col-md-10 DivpMission ">
                            <textarea required class="form-control" runat="server" id="pMission0" rows="3"></textarea>
                        </div>
                    </div>
				
				
				
				
             </div>
			 
			 
  </div>
	
                     <div class="row rt ">
    <div class="col-md-6">
                    <a href="#" onclick="addInput();" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
        </div>
  <hr />
                     <div class="row rt  botx " style=" font-size: 17px;">
                  <asp:CompareValidator ID="CompareValidatorDateH" runat="server" 
                                    ErrorMessage="<%$ Resources:Resource, ToDateGreaterFromDate%>"
                                    ControlToValidate="isHotelGreaterDate" ValueToCompare="dateerror"
                                    Type="String" Operator="NotEqual" ForeColor="Red"
                                    SetFocusOnError="true"
                                    validationgroup="HotelGroup" Display="Dynamic"
                                    ></asp:CompareValidator>
                         </div>
 <div class="row rt  botx " style=" font-size: 17px;">
                 
	
 <asp:CompareValidator ID="CompareValidator1" runat="server"
									ErrorMessage="<%$ Resources:Resource, DateGreaterCurrentDate%>" 
									ControltoValidate="txHotelCurrentDate" ValueToCompare="dateerror"
									type="String"   Operator="NotEqual" ForeColor="Red"
									SetFocusOnError="true"
                                    validationgroup="HotelGroup" Display="Dynamic"/>
									
	<div  id="HotelisGreaterThanDateTime">
		<input type="text" style="display: none;" runat="server" id="isHotelGreaterDate" class="form-control">
		</div>	
		
<div  id="HotelisGreaterThanCurrentDate">
		<input type="text" style="display: none;" runat="server" id="txHotelCurrentDate" class="form-control">
		</div>	       



                    </div>
    <hr />
 <div class="row rt  botx">
                        <asp:Button OnClientClick="HotelmandatoryFields()" validationgroup="HotelGroup"  Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="Button1" OnClick="btnSaveReserveHotel_Click" />
                        <%--<a href="#" class="morebutovn2">تقديم
                        </a>--%>
                    </div>


                </div>


           
            </div>
            <div class="tab-content clearfix" id="tab-responsive-2">
               
                <div class="inskdnew">

                      <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                      <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Emirate%>" /></label>
                                </div>
                                <div class="col-md-8">
                                   <label><asp:Literal runat="server" id="DDE2"/></label>
                        
                                    <asp:DropDownList class="form-control form-control-sm" ID="DropDownEmirates2" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row rt">

                      

                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12  RadiB ">
                                    <asp:RadioButtonList ID="cbPlace" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    </asp:RadioButtonList>
                                     
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12">
                                   
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red"  validationgroup="RoomGroup" ControlToValidate="cbPlace" Display="Dynamic" >
            </asp:RequiredFieldValidator>  </div>
                            </div>
                        </div>
                    </div>
                        </div>
                    </div>
                    

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, AttendeesNumber%>" /></label>
                                </div>
                                <div class="col-md-8">
                                    <input type="text" runat="server" id="txtAttendeesNumber" class="form-control only-numeric" placeholder="">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRBContactReason" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtAttendeesNumber"  validationgroup="RoomGroup" Display="Dynamic" >
            </asp:RequiredFieldValidator> 
                                    </div>
                               
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, fromDate%>" /></label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group date"  id="toFrom" data-provide="datepicker">
                                        <input autocomplete="off" type="text" runat="server" id="txtBookingDateFrom" class="form-control">
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                        
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red"  validationgroup="RoomGroup" ControlToValidate="txtBookingDateFrom" Display="Dynamic" >
            </asp:RequiredFieldValidator> 
                                     <asp:CompareValidator ID="CompareTodayValidator" 
                                        Operator="NotEqual"
                                        ForeColor="Red" validationgroup="RoomGroup"
                              type="String" ControltoValidate="txCurrentDate"
                                       ValueToCompare="dateerror"
                              ErrorMessage="<%$ Resources:Resource, DateGreaterCurrentDate%>" 
                                        SetFocusOnError="true"
                                        Display="Dynamic"
                                        runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row newrowtime">
                                <div class="col-md-2">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, time%>" /></label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group timenew" id="toFromT">
                                        <input autocomplete="off" runat="server" id="txtBookingTimeFrom" class="timepicker form-control" />
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
                                    <label>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, toDate%>" /></label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group date" id="toDate" data-provide="datepicker">
                                        <input type="text" autocomplete="off" runat="server" id="txtBookingDateTo" class="form-control">
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                         ErrorMessage="<%$ Resources:Resource, Mandatory%>"                     
                                          ForeColor="Red" validationgroup="RoomGroup" 
                                          ControlToValidate="txtBookingDateTo" Display="Dynamic" >
                                        </asp:RequiredFieldValidator> 
                          
                                   

                                   
                                    <div  id="isGreaterThanCurrentDate">
                                       <input type="text" style="display: none;" runat="server" id="txCurrentDate" class="form-control">
                                    </div>	
                                    
                                       
                                    
                                     
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row newrowtime">
                                <div class="col-md-2">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, time%>" /></label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group timenew"  id="toDateT">
                                        <input autocomplete="off"  runat="server" id="txtBookingTimeTo" class="timepicker form-control" />
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                         
                                    </div>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                   
										<div  id="isGreaterThanDateTime">
                                        <input type="text" style="display: none;" runat="server" id="isGreaterDateTo" class="form-control">
										</div>										
										
					  <div class="row rt">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                               </div>
                                <div class="col-md-8">


                                            <asp:CompareValidator ID="CompareValidatorDateofbirth" runat="server" 
                                    ErrorMessage="<%$ Resources:Resource, ToDateGreaterFromDate%>"
                                    ControlToValidate="isGreaterDateTo" ValueToCompare="dateerror"
                                    Type="String" Operator="NotEqual" ForeColor="Red"
                                    SetFocusOnError="true"
                                    validationgroup="RoomGroup" Display="Dynamic"
                                    ></asp:CompareValidator>





                                   
                                    </div>
                               
                            </div>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div>









					
                                                
                    <div class="row rt fleb">
                        <div class="col-md-2">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, BookingDetails%>" /></label>
                        </div>
                        <div class="col-md-9">
                            <textarea class="form-control" runat="server" id="txtMission" rows="3"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtMission"  validationgroup="RoomGroup" Display="Dynamic" >
            </asp:RequiredFieldValidator> 
                        </div>
                    </div>

                    <div class="row rt">
                        <div class="col-md-12">
                            <h5><asp:Literal runat="server" Text="<%$ Resources:Resource, resources%>" />
                            </h5>
                            <div class="CheckBoxresources" >
                               
                                <asp:CheckBoxList ID="cbResources" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>

                    <div class="row rt  botx">
                        <asp:Button formnovalidate="formnovalidate" Text="<%$ Resources:Resource, Submit%>" OnClientClick="isGreaterThanDateTime()" CssClass="morebutovn2" runat="server" validationgroup="RoomGroup" ID="btnsubmit" OnClick="btnSaveRoomBooking_Click" />
                       
                    </div>
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

<div id="Div1" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></h4>
</div>
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


	<style>
#dynamicInput >div:nth-child(odd) {
    background-color: #f5e9b6;
}
.row.rt {
    margin-bottom: 4px;
    margin-top: 1px;
    padding: 1px;
}
#dynamicInput .row table {
    margin-bottom: 1px;
}
#Edata .rt{
     margin-bottom: 1px;
}
span.removerow {
    padding-right: 25px;
    margin-top: -15px;
}
span.evenRow {
    padding-right: 5px;
    padding-left: 5px;
}
span.oddRow {
    padding-right: 5px;
    padding-left: 5px;
}
.RadiB table {
    padding: 0;
    margin: 0;
        top: 20px;
}

.inskdnew textarea.form-control {
   
    width: 100%;
}

</style>
<script>

    $(document).ready(function () {
        $(".RadiB label").addClass("radio-button-click-target");
        $(".RadiB input").addClass("radio-button");
        $(".CheckBoxresources label").addClass("checkbox-click-target");
        $(".CheckBoxresources input").addClass("checkbox");
        $(".only-numeric").bind("keypress", function (e) {
            var keyCode = e.which ? e.which : e.keyCode

            if (!(keyCode >= 48 && keyCode <= 57)) {
                $(".error").css("display", "inline");
                return false;
            } else {
                $(".error").css("display", "none");
            }
        });
    });
    var counter = 1;
    function addInput() {
        $("#FirstItemAA")[0].innerHTML = $("#FirstItem")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA");
        Itemhtml.find(".DivName")[0].innerHTML = "<input required name='PName' type=text' id='PName" + counter + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivJob")[0].innerHTML = "<input required name='Job' type='text' id='Job" + counter + "' class='form-control'></div>";
        Itemhtml.find(".Divfrom")[0].innerHTML = "<input  autocomplete='off' required name='from' type='text' id='from" + counter + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".Divto")[0].innerHTML = "<input  autocomplete='off' required name='to' type='text' id='to" + counter + "' class='form-control'><div class='input-group-addon'><span class='icon-calendar-alt1'></span></div>";
        Itemhtml.find(".DivpMission")[0].innerHTML = "<textarea required name='pMission' rows='3' id='pMission" + counter + "' class='form-control' ></textarea>";
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "new";
        newdiv.setAttributeNode(att);
        var classis = "";
        if (counter % 2 === 0) {
            classis = "oddRow";
        } else { classis = "evenRow"; }
        var allhtml = "<div class='" + classis + "'> <hr><div class='row rt'><span style='padding-right: 25px;margin-top: -15px;' onclick='removerow(this);'><span class='icon-remove'></span></span></div>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementById('dynamicInput').appendChild(newdiv);
        counter++;
        document.getElementById('hdncounter').value = counter;
        $("#FirstItemAA")[0].innerHTML = "";
    }

    function removerow(thi) {
        counter--;
        document.getElementById('hdncounter').value = counter;
        thi.closest('.new').remove();
    }

    function isGreaterThanDateTime() {
        if (new Date($("#toDate input").val() + " " + $("#toDateT input").val()) > new Date($("#toFrom input").val() + " " + $("#toFromT input").val())) {

            $('#isGreaterThanDateTime input').val("Done");
            isGreaterThanCurrentDate();
        } else {

            $('#isGreaterThanDateTime input').val("dateerror");
        }

    }


    function isGreaterThanCurrentDate() {
        if (new Date($("#toFrom input").val() + " " + $("#toFromT input").val()) > new Date()) {
            
            $('#isGreaterThanCurrentDate input').val("Done");
        } else {
            
            $('#isGreaterThanCurrentDate input').val("dateerror");
        }

    }

    function HotelmandatoryFields() {
        $('#HotelisGreaterThanCurrentDate input').val("Done");
        $('#HotelisGreaterThanDateTime input').val("Done");
        $(".Divfrom input").each(function (index) {
            var to = $(".Divto input").get(index).value;
            if ($(this).val() != null && $(this).val() != "") {
                if (new Date($(this).val()).format('MM/dd/yyyy') >= new Date().format('MM/dd/yyyy')) {
                    if (new Date(to) >= new Date($(this).val())) {
                    } else {
                        $('#HotelisGreaterThanDateTime input').val("dateerror");
                    }
                } else {
                    $('#HotelisGreaterThanCurrentDate input').val("dateerror");
                }

            }
        });
    }



</script>