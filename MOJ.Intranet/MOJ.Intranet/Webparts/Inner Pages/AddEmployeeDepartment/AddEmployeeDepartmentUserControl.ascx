<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeDepartmentUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AddEmployeeDepartment.AddEmployeeDepartmentUserControl" %>

<script type="text/javascript">
    function DelayRedirect(URL) {
        var seconds = 40;
        var dvCountDown = document.getElementById("dvCountDown");
        var lblCount = document.getElementById("lblCount");
        dvCountDown.style.display = "block";
        lblCount.innerHTML = seconds;
        setInterval(function () {
            seconds--;
            lblCount.innerHTML = seconds;
            if (seconds == 0) {
                dvCountDown.style.display = "none";
                window.location = URL;
            }
        }, 1000);
    }
</script>

<div class="tab-container" data-active="">
    <div class="row rt">

        <div class="col-md-6">

            <div class="row">
                <div class="col-md-12">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, Greetings%>" />
                </div>
            </div>
            <br>
            <div class="row">
                <div class="col-md-12">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, PleaseSelectDepartment%>" />
                </div>
            </div>
            <br>
            <div class="row">

                <div class="col-md-2">
                    <label>
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, SelectDepartment%>" /></label>
                </div>
                <br>
                <div class="col-md-9">

                    <asp:DropDownList ID="ddlDepartments" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>

            </div>
            <br>
            <br>
            <div class="row botx">
                <asp:Button Text="<%$ Resources:Resource, Submit%>" CssClass="slide morebuttoncss arrow" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
            </div>

            <br />
            <br />
            <div class="row">
                <div ClientIDMode="Static" id="dvCountDown" style="display: none">
                   <asp:Literal runat="server" Text="<%$ Resources:Resource, redirected%>" /><span ClientIDMode="Static" id="lblCount"></span>&nbsp;<asp:Literal runat="server" Text="<%$ Resources:Resource, seconds%>" />
                </div>
            </div>
        </div>
    </div>
</div>
