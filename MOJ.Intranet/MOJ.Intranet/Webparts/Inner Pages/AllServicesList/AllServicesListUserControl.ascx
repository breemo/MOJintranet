<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllServicesListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AllServicesList.AllServicesListUserControl" %>

<style>
    .fullwidthtabs .tab-nav li{
        width:25% !important;
    }
</style>

<%--<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadMyServices%>" />
</h4>

<div id="posts" class="small-thumbs alt">
    <div class="row">
        <div class="d-flex ordercontainerServices">
            <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
        </div>
    </div>
</div>--%>
<!-- #posts end -->



<h4></h4>
<div id="posts" runat="server" class="small-thumbs alt">

    <div class="tabs tabs-responsive clearfix fullwidthtabs">

        <ul class="tab-nav clearfix">
            <li><a href="#tab-responsive-1"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadMyServices%>" /></a></li>
            <li><a href="#tab-responsive-2"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCoartServices%>" /></a></li>
            <li><a href="#tab-responsive-3"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadEmployeesServices%>" /></a></li>
            <li><a href="#tab-responsive-4"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadEServices%>" /></a></li>
        </ul>

        <div class="tab-container">
            <div class="tab-content clearfix" id="tab-responsive-1">
                <div class="row">
                    <div class="d-flex ordercontainerServices">
                        <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="tab-content clearfix" id="tab-responsive-2">
                <div class="row">
                    <div class="d-flex ordercontainerServices">
                        <asp:Literal ID="lblDrawCoartServices" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="tab-content clearfix" id="tab-responsive-3">
                <div class="row">
                    <div class="d-flex ordercontainerServices">
                        <asp:Literal ID="lblDrawEmployeesServices" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="tab-content clearfix" id="tab-responsive-4">
                <div class="row">
                    <div class="d-flex ordercontainerServices">
                        <asp:Literal ID="lblDrawEServices" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- #posts end -->


