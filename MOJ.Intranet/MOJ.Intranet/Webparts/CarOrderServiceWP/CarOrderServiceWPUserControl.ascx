<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarOrderServiceWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.CarOrderServiceWP.CarOrderServiceWPUserControl" %>


<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>

<script>
    var counter = 1;
    var limit = 3;
    function addInput(divName) {
        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "New";
        newdiv.setAttributeNode(att);
        newdiv.innerHTML = "<div><div><span  onclick='removerow(this);'><span class='icon-remove'></span></span><input type='text' required name='Passenger' class='form-control' id='txtPassengerName" + counter + "'></div></div>";

        document.getElementById(divName).appendChild(newdiv);
        counter++;
        document.getElementById('hdnPassenger').value = counter;
    }
    function removerow(thi) {
        counter--;
        document.getElementById('hdnPassenger').value = counter;
        thi.closest('.New').remove();
    }

</script>

<asp:HiddenField ClientIDMode="Static" ID="hdnPassenger" runat="server" />
<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, CarRequestService%>" />
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
                                    <input type="text" name="EDepartment" disabled runat="server" id="EDepartment" class="form-control" placeholder="">
                                </div>                       
                            </div>
                            </div>
                        <div class="col-md-6">
                               <div class="row">
                                    <div class="col-md-4">
                            </div>
                            <div class="col-md-8 ">
                                      </div>
                              </div>
					    </div>                  
                    </div>
                     
               
               </div>

                   <hr />


    <div class="tabs tabs-responsive clearfix fullwidthtabs ui-tabs ui-corner-all ui-widget ui-widget-content">
        <div class="inskdnew">
            <div class="row rt">
                <div class="col-md-12">
                    <h5>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Carwith%>" />
                    </h5>
                    <div class="RadiB">                    
                      
                        <asp:RadioButtonList required ID="cbTravelNeedsR" CssClass="checkbox-click-target" RepeatDirection="Horizontal" runat="server" Width="100%">
                                    
                         
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div class="row rt">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-5">
                            <label> <asp:Literal runat="server" Text="<%$ Resources:Resource, GoingTo%>" /></label>
                        </div>

                        <div class="col-md-6">
                            <input required type="text" runat="server" id="txtTravelTo" class="form-control" placeholder="">
                        </div>
                    </div>


                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row rt">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-5">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, PassengerName%>" /></label>
                        </div>

                        <div id="dynamicInput" class="col-md-6">
                            <input  required type="text" name="Passenger" runat="server" id="txtPassengerName0" class="form-control" placeholder="">
                        </div>

                    </div>


                </div>
                <div class="col-md-2">
                    <a href="#" onclick="addInput('dynamicInput');" class="morebutovn"><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
                </div>
            </div>
            <div class="row rt">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-5">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TravelReason%>" /></label>
                        </div>

                        <div class="col-md-6">
                            <input required type="text" runat="server" id="txtTravelReson" class="form-control" placeholder="">
                        </div>
                    </div>


                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row rt">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-5">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CarPlace%>" /></label>
                        </div>

                        <div class="col-md-6">
                            <input required type="text" id="txtCarPlace" runat="server" class="form-control" placeholder="">
                        </div>
                    </div>


                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row rt">
		<div class="col-md-8">
			<div class="row">
				<div class="col-md-5">
					<label><asp:Literal runat="server" Text="<%$ Resources:Resource, TravelDate%>" /></label>
				</div>
				<div class="col-md-6">
					<div class="input-group date" id="toFrom"  data-provide="datepicker">
						<input autocomplete="off" required type="text" runat="server" id="txtTravelDate" class="form-control">
						<div class="input-group-addon">
							<span class="icon-calendar-alt1"></span>
						</div>
					</div>
				</div>		
			</div>
	

                 <asp:CompareValidator ID="CompareTodayValidator" 
                                        Operator="NotEqual"
                                        ForeColor="Red" 
                              type="String" ControltoValidate="txCurrentDate"
                                       ValueToCompare="dateerror"
                              ErrorMessage="<%$ Resources:Resource, DateGreaterCurrentDate%>" 
                                        SetFocusOnError="true"
                                        Display="Dynamic"
                                        runat="server" />


                <div  id="isGreaterThanCurrentDate">
                                       <input type="text" style="display: none;" runat="server" id="txCurrentDate" class="form-control">
                                    </div>	
	</div>
	<div class="col-md-4">
			<div class="row">			
			 <div class="col-md-4">
                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, time%>" /></label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group timenew  " id="toFromT">
                                        <input autocomplete="off"  runat="server" id="txtBookingTimeFrom" class="timepicker form-control" />
                                        <div class="input-group-addon">
                                            <span class="icon-calendar-alt1"></span>
                                        </div>
                                    </div>
                                </div>	
				</div>
			</div>               
  </div>
            <div class="row rt">

                <div class="col-md-8">

                    <div class="row">

                        <div class="col-md-5">
                            <label><asp:Literal runat="server" Text="<%$ Resources:Resource, TravelDuration%>" /></label>
                        </div>

                        <div class="col-md-6">
                            <input required type="text" runat="server" id="txtduration" class="form-control" placeholder="">
                        </div>
                    </div>


                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row rt  botx">
                <asp:Button OnClientClick = "isGreaterThanCurrentDate()" Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>
        </div>
    </div>
</div>
<div id="SuccessMsgDiv" runat="server" style="display:none">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/js/bootstrap-datepicker.min.js"></script>
<script src="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/locales/bootstrap-datepicker.ar.min.js" charset="UTF-8"></script>
<script>
    $(document).ready(function () {
       

            $(".RadiB label").addClass("radio-button-click-target");
            $(".RadiB input").addClass("radio-button");

        $(".CheckBoxThim label").addClass("checkbox-click-target");
        $(".CheckBoxThim input").addClass("checkbox");
        $('.CheckBoxThim label').each(function () {
            var valuex = "<span class='checkbox-box'></span>" + this.innerHTML;
            this.innerHTML = valuex;
        });
    });
    var counter = 1;
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
    function isGreaterThanCurrentDate() {
        if (new Date($("#toFrom input").val() + " " + $("#toFromT input").val()) > new Date()) {
            $('#isGreaterThanCurrentDate input').val("Done");
        } else {
            $('#isGreaterThanCurrentDate input').val("dateerror");
        }

    }
</script>
<style>

#Edata .rt{
     margin-bottom: 1px;

}
.rt .checkbox-click-target {
  padding-bottom: 0px;

}
.CheckBoxThim table {
     margin-bottom: -20px;

}
.CheckBoxThim  {
        margin-top: -30px;

}
div#dynamicInput div {
    margin-top: 14px;
}
.RadiB table {
    margin-bottom: 0px;
}
</style>