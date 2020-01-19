<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParticipantsCouncilWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.ParticipantsCouncilWP.ParticipantsCouncilWPUserControl" %>

<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>
<asp:HiddenField ClientIDMode="Static" id="hdnsuperDIV1" runat="server" />
<asp:HiddenField ClientIDMode="Static" id="RetrevehdnsuperDIV1" runat="server" />
             
			<div id="posts" runat="server" class="small-thumbs alt content-wrap">
                <div class="">
				<div class="boxsh">
                        <div class="faqhead">
                            <h3>
                              <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Participants%>" /></label>
                            </h3>
                        </div>
                        <div class="">
                            <div class="">
							 <!--          ==============     Edata=============================== -->
                                <section id="Implcit">
                                    <section id="faqs" class="">
                                        <div class="Participants">  </div>
										 <div class="col-md-12">
                                        <div class="row" style=" font-size: 9px;">
                                            <div class="col-md-2">
                                             <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ArabicName%>" /></label>
											</div>
                                           <div class="col-md-2 ">
										   <label><asp:Literal runat="server" Text="<%$ Resources:Resource, EnglishName%>" /></label>
										</div>
											<div class="col-md-2 ">
											 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ArabicJobTitle%>" /></label>
											 </div>
											<div class="col-md-2 ">
											<label><asp:Literal runat="server" Text="<%$ Resources:Resource, EnglishJobTitle%>" /></label>
											</div>											
											<div class="col-md-2 ">
											 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, ArabicRole%>" /></label>
											 </div>
											<div class="col-md-2 ">
											<label><asp:Literal runat="server" Text="<%$ Resources:Resource, EnglishRole%>" /></label>
											</div>
                                        </div>
                                    </div>
							<div runat="server"  id="superDIV2" class="superDIV2">
												  <div  id="FirstItemAA2" style="display:none" >
													 </div>
												   <div  id="FirstItem2" class="cnrtnheadbox2" >
													<div class="row rt">
								 <div class="col-md-12">
                                        <div class="row"> 
											<div  class="col-md-1 DiveDelete ">																			
											</div>																					
                                        </div>
                                    </div>                                   
                                     <div class="col-md-12">
                                        <div class="row">
												<div  class="DivSID" style=" display: none;" >
												<input type="text"  name="SID" runat="server" id="SID0" class="form-control"  placeholder="">
												</div> 										
                                           <div class="col-md-2 DivArabicName">
										<input type="text" required name="ArabicName" runat="server" id="ArabicName_0" class="form-control" placeholder="">
										</div>
											<div class="col-md-2 DivEnglishName">
											<input type="text" name="EnglishName" runat="server" id="EnglishName_0" class="form-control" placeholder="">
											</div>
											<div class="col-md-2 DivArabicJobTitle">
											<input type="text" name="ArabicJobTitle" runat="server" id="ArabicJobTitle_0" class="form-control" placeholder="">
											</div>
											<div class="col-md-2 DivEnglishJobTitle" >
											<input type="text" name="EnglishJobTitle" runat="server" id="EnglishJobTitle_0" class="form-control" placeholder="">
											</div>
											<div class="col-md-2 DivArabicRole" >
											<input type="text" name="ArabicRole" runat="server" id="ArabicRole_0" class="form-control" placeholder="">
											</div>
											<div class="col-md-2 DivEnglishRole" >
											<input type="text" name="EnglishRole" runat="server" id="EnglishRole_0" class="form-control" placeholder="">
											</div>																						
                                        </div>
                                    </div>									
									</div>
									</div>
									 </div>										
									<div>
									<a  onclick="addParticipants();" class="addmorebtn"><span class="icon-plus-circle" style="font-size: 12px;padding: 0px 0px 0px 5px;"></span><asp:Literal runat="server" Text="<%$ Resources:Resource, Add%>" /></a>
									</div>
                                        <br>                                       																					
                                            <div class="row cf">                                            
												     <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Save%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
           									
                                            </div>
                                    </section>
                                </section>
                            </div>
					</div>
                    </div>
                </div>
				</div>	  
<div id="SuccessMsgDiv" runat="server" style="display:none; background-color: white;">
    <h4 class="ta3m" style="text-align: center;"><asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>	
	 <div class="row cf">
	 <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Back%>" CssClass="btnclass bgicb nwckss" runat="server" ID="btnBack2" OnClick="btnBack_Click" />
           										
                                            </div>
	
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
.nwckss {
    margin-top: 20px;
    margin-left: 5px;
}

.btnclass {
    background: #fff !important;
    color: #be9136 !important;
    border-radius: 18px !important;
    padding: 0px 27px 0px 27px !important;
    font-weight: bold!important;
    font-size: 0.69rem !important;
    line-height: 14px !important;
    -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    border: 1px solid #be9136 !important;
    text-align: center !important;
    height: 30px !important;
    margin-top: 0px !important;
}
.bgicb {
    background: #be9136 !important;
    color: #fff !important;
    border-radius: 18px; !important
    padding: 0px 40px 0px 40px !important;
    font-weight: bold !important;
    font-size: 0.69rem !important;
    line-height: 14px !important;
    -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1) !important;
    border: 1px solid #be9136 !important;
    text-align: center !important;
    height: 30px !important;
    margin-top: 8px !important;
    margin-bottom: 30px !important;
}
.boxleftbor {
    padding: 0;
    box-shadow: none;
    background: none;
}


.cnrtnheadbox2 {
    width: 100%;
    overflow: hidden;
    border: 1px solid #cdcfd2;
    justify-content: space-between;
    padding: 8px 10px;
    align-items: center;
    align-items: center;
}
.bgdivindfx {
    background-color: whitesmoke;
}
.conentbgdivd {
    border-right: 1px solid #e1e1e1;
    border-left: 1px solid #e1e1e1;
}
</style>

<script>
    /////////////////////////////////////2----------------------------------------------------
    var counter2 = 0;
    if (document.getElementById('hdnsuperDIV1').value != "") {
        counter2 = Number(document.getElementById('hdnsuperDIV1').value);
    }
    function addParticipants() {
        counter2++;
        $("#FirstItemAA2")[0].innerHTML = $("#FirstItem2")[0].innerHTML;
        var Itemhtml = $("#FirstItemAA2");
        Itemhtml.find(".DivSID")[0].innerHTML = "<input name='SID' type=text' id='SID" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivArabicName")[0].innerHTML = "<input required name='ArabicName' type=text' id='ArabicName" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivEnglishName")[0].innerHTML = "<input required  name='EnglishName' type=text' id='EnglishName" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivArabicJobTitle")[0].innerHTML = "<input name='ArabicJobTitle' type=text' id='ArabicJobTitle" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivEnglishJobTitle")[0].innerHTML = "<input name='EnglishJobTitle' type=text' id='EnglishJobTitle" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivArabicRole")[0].innerHTML = "<input name='ArabicRole' type=text' id='ArabicRole" + counter2 + "' class='form-control' placeholder=''>";
        Itemhtml.find(".DivEnglishRole")[0].innerHTML = "<input required name='EnglishRole' type=text' id='EnglishRole" + counter2 + "' class='form-control' placeholder=''>";

        Itemhtml.find(".DiveDelete")[0].innerHTML = "<span style='padding-right: 25px;margin-top: -15px;' onclick='removeParticipants(this);'><span class='icon-remove' style='color: red;font-size: 15px;'></span></span>";

        var newdiv = document.createElement('div');
        var att = document.createAttribute("class");
        att.value = "cnrtnheadbox2";
        newdiv.setAttributeNode(att);
        var allhtml = "<div class='rowI '>" + Itemhtml[0].innerHTML + "</div>";
        newdiv.innerHTML = allhtml;
        document.getElementsByClassName("superDIV2")[0].appendChild(newdiv);
        document.getElementById('hdnsuperDIV1').value = counter2;
        $("#FirstItemAA2")[0].innerHTML = "";
    }
    function removeParticipants(thi) {
        counter2--;
        document.getElementById('hdnsuperDIV1').value = counter2;
        thi.closest('.cnrtnheadbox2').remove();
    }

</script>