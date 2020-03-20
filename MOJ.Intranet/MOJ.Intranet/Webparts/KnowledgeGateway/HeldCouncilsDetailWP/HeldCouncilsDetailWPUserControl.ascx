<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeldCouncilsDetailWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilsDetailWP.HeldCouncilsDetailWPUserControl" %>
 <label class="confirmMSG" style="display: none;"><asp:Literal runat="server" Text="<%$ Resources:Resource, confirmMSGexam%>" /></label>
                               
   <section id="content" style="margin-bottom: 0px;">
            <div class="">
                <div class="">
                    <!-- Post Content
                    ============================================= -->
                    <div class="">
                        <div class="">
                            <div class="d-flex justify-content-between">
                                 <span class="resalt"><asp:Literal ID="LBresalt" runat="server"></asp:Literal></span>
                                                     
                                <h4 class="faqhead1">
                                   
                                 <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilsHeld%>" /></label>
                                </h4>
                                <a  "href="#" style="height: 38px;" class="modelexean" data-toggle="modal" data-target=".bs-example-modal-sm">
                                    <span  class="icon-edit2" style="width: 146px;color: white;">
									    <label style="width: 120px;color: white;"><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilExam%>" /></label> 
                                    </span>
                                </a>
                            </div>
                            <div id="Satisfay2" class="modal fade bs-example-modal-sm" tabindex="10" role="dialog"
                                 aria-labelledby="mySmallModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-body">
                                        <div class="modal-content CBOD">
                                            <div class="modal-header poll-popup-head NEPOPD">
                                                <h4 class="modal-title rigle" id="myModalLabel">
                                                    <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilExam%>" /></label>  
                                                </h4>
                                            </div>
                                            <div class="modal-body insdpad poll-popup-body">
                                                <form id="smiley2s">
                                                        <!--Start QUestion and answer -->
                                                        <div  runat="server" id="QUestion" >


                                                        </div>
                                                        <!--End QUestion and answer --> 
                                                  
                                                       <span class="resalt"><asp:Literal ID="LBresalt2" runat="server"></asp:Literal></span>
                                                        <div class="pollBtns-popup" style="margin-bottom: 26px;">
															   <asp:Button Text="<%$ Resources:Resource, Propose%>" CssClass="pollBtna" runat="server" ID="btnsubmitexam" OnClientClick="if ( ! ConfirmationMessage()) return false;" OnClick="btnsubmitexam_Click" />
															   <asp:Button Text="<%$ Resources:Resource, CreateExam%>" CssClass="pollBtna" runat="server" ID="btnCreateExam" OnClick="btnCreateExam_Click" />
															<span id="btnClosePopup" class="pollBtn"><label style="padding-top: 5px;"><asp:Literal runat="server" Text="<%$ Resources:Resource, cancel%>" /></label></span>
                                                          
														</div>
                                                   
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="posts" class="small-thumbs alt">
                                <div class="boxtablesx">
                                    <div class="row finc">
                                        <div class="bxl">
                                            <p> <label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilNo%>" /></label></p>
                                            <span><asp:Literal ID="CouncilNo" runat="server"></asp:Literal></span>
                                        </div>
                                        <div class="bxl">
                                            <p><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilHeldDate%>" /></label></p>
                                            <span><asp:Literal ID="CouncilHeldDate" runat="server"></asp:Literal></span>
                                        </div>
                                        <div class="bxl">
                                            <p><label><asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label></p>
                                            <span><asp:Literal ID="Department" runat="server"></asp:Literal></span>
                                        </div>
                                        <div class="bxl">
                                            <p><label><asp:Literal runat="server" Text="<%$ Resources:Resource, Lecturer%>" /></label></p>
                                            <span><asp:Literal ID="Lecturer" runat="server"></asp:Literal></span>
                                        </div>
                                        <div class="bxl">
                                            <p><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilType%>" /></label></p>
                                            <span><asp:Literal ID="CouncilType" runat="server"></asp:Literal></span>
                                        </div><div class="bxl">
                                            <p><label><asp:Literal runat="server" Text="<%$ Resources:Resource, NumberOfParticipants%>" /></label></p>
                                            <span><asp:Literal ID="NumberOfParticipants" runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                 <asp:Button style="width: 200px;" Text="<%$ Resources:Resource, PrintCertificate%>" CssClass="pollBtna" formnovalidate runat="server" ID="btn_PDFEmail" OnClick="btn_PDFEmail_Click" />
                                  <br />
                                <br />
                                <div class="illsudiv">
                                    <h6 class="nclvf"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, ADetailedExplanationOfTheCouncil%>" /></label></h6>
                                    <p>
                                            <asp:Literal ID="ADetailedExplanationOfTheCouncil" runat="server"></asp:Literal></p>
                                </div>
                                  <div class="illsudiv">
                                    <h6 class="nclvf"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, CouncilGoals%>" /></label></h6>
                                    <p>
                                            <asp:Literal ID="CouncilGoals" runat="server"></asp:Literal></p>
                                </div>
                                	   <asp:Button style="width: 200px;" Text="<%$ Resources:Resource, AddParticipants%>" CssClass="pollBtna" formnovalidate runat="server" ID="AddParticipants" OnClick="AddParticipants_Click" />
                                 	  
                                <br />
                                <br />
                                <asp:Button style="width: 200px;" Text="<%$ Resources:Resource, ModifyCouncil%>" CssClass="pollBtna" formnovalidate runat="server" ID="ModifyCouncil" OnClick="ModifyCouncil_Click" />
                                  <br />
                                <br />
                                <asp:Button style="width: 200px;" Text="<%$ Resources:Resource, AllFeedback%>" CssClass="pollBtna" formnovalidate runat="server" ID="AllFeedback" OnClick="AllFeedback_Click" />
                                <div class="row">
                                    <div class="col-md-9">
                                        <div class="table-responsive"  runat="server" id="tableParticipants" style="display: none;">
                                            <table class="table table-hover table-bordered newtableb newtableb2 ">
                                                <thead>
                                                    <tr>
                                                        <th> <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label></th>
                                                        <th> <label><asp:Literal runat="server" Text="<%$ Resources:Resource, JobTitle%>" /></label></th>
                                                        <th> <label><asp:Literal runat="server" Text="<%$ Resources:Resource, Role%>" /></label></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <div runat="server" id="DivParticipants">


                                                        </div>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>                                   
                                </div>
                                
                                <div class="fileboxs">
                                    <div class="row " id="AttachmentDiv" runat="server">
									
                                       
                                       
                                   
                                      
                                        <div class="clear"></div>
                                    </div>
                                </div>
                                <div id="feedbak" runat="server" class="searchboxne searchboxne2  hedlbg pb-0">
                                    <div  class="row d-flex justify-content-center align-items-center">
                                        <div class="col-md-12 pb-2">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, TheBenefitFromTheCouncil%>" /></label></label>
                                                </div>
                                                <div class="col-md-10">
                                                   

                                                    <asp:DropDownList ID="TheBenefitFromTheCouncil"  runat="server" class="form-control">
									</asp:DropDownList>
                                                </div>                                                
                                            </div>
                                        </div>
                                        <div class="col-md-12 pb-2">
                                            <div class="row">
                                                <div class="col-md-2">
                                                       <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, DevelopmentProposalsForCouncil%>" /></label></label>
                                                
                                                </div>
                                                <div class="col-md-10">
                                                   					
                                                    <textarea  runat="server" class="form-control" id="DevelopmentProposalsForCouncil" rows="4" placeholder=""></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 pb-2">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label class="lbel"><label><asp:Literal runat="server" Text="<%$ Resources:Resource, SubjectCouncilCanBeDone%>" /></label></label>
                                                </div>
                                                <div class="col-md-10">
                                                    <textarea  runat="server" class="form-control" id="SubjectCouncilCanBeDone" rows="4" placeholder=""></textarea>

                                                </div>
											</div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="newfloa">                                             
												         <asp:Button style="margin-top: 15px;" Text="<%$ Resources:Resource, Propose%>" CssClass="pollBtna" runat="server" ID="btnsubmit" formnovalidate OnClick="btnsubmit_Click" />
           												                                                  
                                            </div>                                           
                                        </div>
                                    </div>
                                </div>  
							</div><!-- #posts end -->
                        </div>
                    </div><!-- .postcontent end -->             
            </div>         
        </section>
		<style>
	.pollBtna{
		background-color: #be9136 !important ;
		color: #FFF !important;
		border-radius: 18px ;
		padding: 0px 25px 2px 27px !important ;
		font-weight: bold;
		font-size: 11px ;
		-webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
		transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
		border: 1px solid #bd995d !important;
		text-align: center;
		height: 32px;
		min-width: 120px;
		letter-spacing: 0.9px;
	}
	.pollBtnb{
		border-radius: 18px !important;
		padding: 0px 25px 2px 27px !important; 
		font-weight: bold;
		font-size: 11px ;
		-webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
		transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
		border: 1px solid #bd995d !important;
		text-align: center;
		height: 32px;
		min-width: 120px;
		letter-spacing: 0.9px;
		color: #bd995d !important;
	}
   .radioComponent input {
   margin-top: -6px;
}
    .CBOD .poll-popup-answ input[type="radio"]:checked + .radio-button-click-target .radio-button-circle {   
    right: -19px !important;
    left: -19px;
    
}

    .resalt {
    color: #BD995D;
    font-size: 22px;
    font-weight: bold;
}
    .onefive {
 
    margin-left: 5px;
    margin-right: 5px;
}
     .pollBtns-popup span.pollBtn {
        background: #fff;
        color: #be9136;
        border-radius: 18px;
        padding: 2px 27px 2px 27px;
        font-weight: bold;
        font-size: 10px !important;
        line-height: 14px;
        -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        border: 1px solid #be9136;
        text-align: center;
        height: 30px;
        margin-top: 4px;
        min-width: 120px;
        margin: 0px 1px;
    }

     .boxfoo p {
  

    overflow: hidden;
    position: relative;
    height: 43px;
}
     select.aspNetDisabled {
    width: 100%;
}

.faqhead1 label {
    font-size: inherit !important;
    font-weight: 700 !important;
}
.finc .bxl{

    min-width: 15%!important;
}
	</style>
		<script>
            $(document).ready(function () {

                $('#btnClosePopup').click(function () {

                    $('.bs-example-modal-sm').modal('hide');
                });

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
            function handleChange(ID, radio1) {

                $("#" + ID).val(radio1)
            }

            function ConfirmationMessage() {
                var isempty = "No";
                $("input[name='AnswerIs']").each(function () {
                    if ($(this).val().length === 0) {
                        isempty = "Yes";
                    }
                });
                if (isempty == "No") {
                    var MSG = $(".confirmMSG")[0].innerHTML;
                    return confirm(MSG);
                } else {
                    return true;
                }
            }
</script>
