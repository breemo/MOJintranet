<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainingProgramNominationWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.TrainingProgramNominationWP.TrainingProgramNominationWPUserControl" %>



<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<link id="bsdp-css" href="https://unpkg.com/bootstrap-datepicker@1.9.0/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet">
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>


<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, NominationForm%>" />
</h4>
<div id="posts" runat="server" class="small-thumbs alt">
    <div id="Edata">
        <div class="row rt">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="Ename" disabled runat="server" id="Ename" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, EmployeeNumber%>" /></label>
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
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="Edepartment" disabled runat="server" id="Edepartment" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
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
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, HiringDate%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" disabled name="EHiringDate" runat="server" id="EHiringDate" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Nationality%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="ENationality" disabled runat="server" id="ENationality" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Qualification%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="txtQualification" runat="server" id="txtQualification" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, MobileNumber%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" disabled name="txtMobileNumber" runat="server" id="txtMobileNumber" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, ExtNo%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="txtExtNo" runat="server" id="txtExtNo" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Email%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" disabled name="EEmail" runat="server" id="EEmail" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <h3>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, ProgramInformation%>" />
    </h3>

    <div class="row rt">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, ProgramName%>" /></label>
                </div>
                <div class="col-md-8">
                    <input type="text" name="txtProgramName" runat="server" id="txtProgramName" class="form-control" placeholder="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server"
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtProgramName" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, ProgramLocation%>" /></label>
                </div>
                <div class="col-md-8 ">
                    <input type="text" name="txtProgramLocation" runat="server" id="txtProgramLocation" class="form-control" placeholder="">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtProgramLocation" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
    <h2>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, ProgramDate%>" />
    </h2>
    <div class="row rt">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, fromDate%>" />
                    </label>
                </div>
                <div class="col-md-8">
                    <div class="input-group date DivDateApportionmentDate" data-provide="datepicker">
                        <input autocomplete="off" type="text" runat="server" id="ProgramDateFrom" class="form-control">
                        <div class="input-group-addon">
                            <span class="icon-calendar-alt1"></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ProgramDateFrom" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, toDate%>" />
                    </label>
                </div>
                <div class="col-md-8">
                    <div class="input-group date DivDateApportionmentDate" data-provide="datepicker">
                        <input autocomplete="off" type="text" runat="server" id="ProgramDateTo" class="form-control">
                        <div class="input-group-addon">
                            <span class="icon-calendar-alt1"></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="ProgramDateTo" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>



    <h2>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, ProgramTime%>" />
    </h2>
    <div class="row rt">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, FromTime%>" />
                    </label>
                </div>
                <div class="col-md-8">
                    <div class="input-group timenew  " id="toFromT">
                        <input autocomplete="off" runat="server" id="txtProgramTimeFrom" class="timepicker form-control" />
                        <div class="input-group-addon">
                            <span class="icon-calendar-alt1"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, ToTime%>" />
                    </label>
                </div>
                <div class="col-md-8">
                    <div class="input-group timenew  " id="toT">
                        <input autocomplete="off" runat="server" id="txtProgramTimeTo" class="timepicker form-control" />
                        <div class="input-group-addon">
                            <span class="icon-calendar-alt1"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row rt  botx">
        <asp:Button Style="margin-top: 15px;" Text="<%$ Resources:Resource, Submit%>" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
    </div>
</div>

<div id="SuccessMsgDiv" runat="server" style="display: none">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="lblSuccessMsg" runat="server"></asp:Literal></h4>
</div>
<div id="Div1" runat="server">
    <h4 class="ta3m" style="text-align: center;">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></h4>
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
        if (new Date($("#toT input").val() + " " + $("#toFromT input").val()) > new Date()) {
            $('#isGreaterThanCurrentDate input').val("Done");
        } else {
            $('#isGreaterThanCurrentDate input').val("dateerror");
        }

    }
</script>

<style>
    .evenRow {
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

    #Edata .rt {
        margin-bottom: 1px;
    }
</style>


<script>

    $(document).ready(function () {

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

</script>
