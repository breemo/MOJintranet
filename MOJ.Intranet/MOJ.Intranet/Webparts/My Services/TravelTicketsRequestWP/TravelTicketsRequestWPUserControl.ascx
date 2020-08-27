<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TravelTicketsRequestWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.TravelTicketsRequestWP.TravelTicketsRequestWPUserControl" %>

<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, RequestTravelTicketsFees%>" />
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
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Position%>" /></label>
                    </div>
                    <div class="col-md-8 ">
                        <input type="text" disabled name="EPosition" runat="server" id="EPosition" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="EDepartment" disabled runat="server" id="EDepartment" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, Date%>" /></label>
                    </div>
                    <div class="col-md-8 ">
                        <input type="text" disabled name="Date" runat="server" id="txtDate" class="form-control" placeholder="">
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
        <br />
        <h4>
            <asp:Literal runat="server" Text="<%$ Resources:Resource, TravelDetails%>" />
        </h4>
        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <asp:RadioButtonList ID="rbType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="checkbox-click-target" 
                        OnSelectedIndexChanged="rbType_SelectedIndexChanged">
                        <asp:ListItem Value="WorkMission" Text="<%$ Resources:Resource, WorkMission%>"></asp:ListItem>
                        <asp:ListItem Value="TicketsAllowance" Text="<%$ Resources:Resource, TicketsAllowance%>" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMessage" runat="server"
                        ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="rbType" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, TravelFrom%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="txtTravelFrom" runat="server" id="txtTravelFrom" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtTravelFrom" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, TravelTo%>" /></label>
                    </div>
                    <div class="col-md-8 ">
                        <input type="text" name="txtTravelTo" runat="server" id="txtTravelTo" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtTravelTo" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, ReturnTo%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <input type="text" name="txtTravelFrom" runat="server" id="txtReturnTo" class="form-control" placeholder="">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtReturnTo" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row rt"  id="dvTicketFor" runat="server">
            <div class="col-md-12">
                <div class="row">
                    <asp:RadioButtonList ID="rblTicketFor" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" 
                        CssClass="checkbox-click-target"  OnSelectedIndexChanged="rblTicketFor_SelectedIndexChanged">
                        <asp:ListItem Value="TicketForEmployee" Text="<%$ Resources:Resource, TicketForEmployee%>" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="TicketForEmployeeAndFamily" Text="<%$ Resources:Resource, TicketForEmployeeAndFamily%>"></asp:ListItem>
                        <asp:ListItem Value="TicketForFamily" Text="<%$ Resources:Resource, TicketForFamily%>"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, RequestDescription%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <textarea name="txtDescription" rows="5" runat="server" class="form-control" id="txtDescription"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="<%$ Resources:Resource, Mandatory%>" ForeColor="Red" ControlToValidate="txtDescription" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row rt" id="dvwifefld" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, wifefld%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <input type="text" name="txtwifefld" runat="server" id="txtwifefld" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row rt" id="dvson1" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, son1%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <input type="text" name="txtSon1" runat="server" id="txtSon1" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <br />

        <div class="row rt" id="dvson2" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, son2%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <input type="text" name="Son2" runat="server" id="Son2" class="form-control" placeholder="">
                    </div>
                </div>
            </div>
        </div>
        <br />

        <div class="row rt" id="dvson3" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, son3%>" /></label>
                    </div>
                    <div class="col-md-10">
                        <input type="text" name="Son3" runat="server" id="Son3" class="form-control" placeholder="">
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
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>



<style>
    #Edata .rt {
        margin-bottom: 1px;
    }

    div#dynamicInput div {
        margin-top: 14px;
    }

    .RadiB table {
        margin-bottom: 0px;
    }
</style>
