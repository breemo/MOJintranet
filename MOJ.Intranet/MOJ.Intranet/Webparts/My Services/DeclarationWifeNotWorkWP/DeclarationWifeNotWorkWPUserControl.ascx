<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeclarationWifeNotWorkWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.My_Services.DeclarationWifeNotWorkWP.DeclarationWifeNotWorkWPUserControl" %>




<link rel="stylesheet" href="/Style%20Library/MOJTheme/css/responsive.css" type="text/css" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>
<script src="/Style%20Library/MOJTheme/s/plugins.js"></script>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, DeclarationWifeNotWork%>" />
</h4>
<div id="posts" runat="server" class="small-thumbs alt">
    <div id="Edata">
        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <h4>
                            <label>
                                <asp:Literal runat="server" Text="<%$ Resources:Resource, Undersigned%>" /></label></h4>
                    </div>
                </div>
            </div>
        </div>

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

        <br />

        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-2">
                        <label>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, MyWife%>" /></label>
                    </div>
                    <div class="col-md-8">
                        <input type="text" name="txtMyWifeName" runat="server" id="txtMyWifeName" class="form-control" placeholder="">
                    </div>
                </div>
            </div>

        </div>

        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <h3>
                            <label>
                                <asp:Literal runat="server" Text="<%$ Resources:Resource, DoNotWork%>" /></label></h3>
                    </div>
                </div>
            </div>
        </div>

        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                    </div>
                </div>
            </div>
        </div>
        <div class="row rt">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-12">
                        <h2>
                            <label>
                                <asp:Literal runat="server" Text="<%$ Resources:Resource, Acknowledgment%>" /></label></h2>
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
