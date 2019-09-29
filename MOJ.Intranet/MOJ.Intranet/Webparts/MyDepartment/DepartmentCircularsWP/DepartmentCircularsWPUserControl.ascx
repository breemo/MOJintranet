<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentCircularsWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.MyDepartment.DepartmentCircularsWP.DepartmentCircularsWPUserControl" %>

<h3><asp:Literal runat="server" Text="<%$ Resources:Resource, MyDepartmentTitle%>" /></h3>

<div class="insidebox">
    <h4 class="ta3m">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, DepartmentCirculars%>" /></h4>


    <div class="boxscroll demo-rtl os-host os-theme-dark os-host-overflow os-host-overflow-y os-host-rtl os-host-resize-disabled os-host-scrollbar-horizontal-hidden os-host-transition" data-simplebar="init" data-simplebar-auto-hide="false">
        <div class="os-resize-observer-host">
            <div class="os-resize-observer observed" style="left: auto; right: 0px;"></div>
        </div>
        <div class="os-size-auto-observer" style="height: calc(100% + 1px); float: right;">
            <div class="os-resize-observer observed"></div>
        </div>
        <div class="os-content-glue" style="margin: -14px -28px;"></div>
        <div class="os-padding" style="top: 14px; right: 28px; bottom: 14px; left: 28px;">
            <div class="os-viewport os-viewport-native-scrollbars-invisible" >
                <div class="os-content" style="height: 100%; width: 100%;">

                    <div class="clearfix">

                         <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>

                    </div>
                </div>
            </div>
        </div>
        <div class="os-scrollbar os-scrollbar-horizontal os-scrollbar-unusable">
            <div class="os-scrollbar-track">
                <div class="os-scrollbar-handle" style="width: 100%; transform: translate(0px, 0px);"></div>
            </div>
        </div>
        <div class="os-scrollbar os-scrollbar-vertical">
            <div class="os-scrollbar-track">
                <div class="os-scrollbar-handle" style="height: 63.6364%; transform: translate(0px, 0px);"></div>
            </div>
        </div>
        <div class="os-scrollbar-corner"></div>
    </div>



</div>
