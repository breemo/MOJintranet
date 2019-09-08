<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeGalaryUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.HomeGalary.HomeGalaryUserControl" %>

<div class="headlineflex">
    <h4 class="TitleHead">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadGallery%>" />
    </h4>
    <a href="#" class="slide morebuttoncss arrow">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, MorePictures%>" />
    </a>
</div>

<div class="boxgallery" style="width:1125px">
    <div class="boxcd">
        <div id="content-6" class="content horizontal-images clearfix  mCustomScrollbar _mCS_1">
            <div id="mCSB_1" class="mCustomScrollBox mCS-light-3 mCSB_horizontal mCSB_inside" style="max-height: none;" tabindex="0">
                <div id="mCSB_1_container" class="mCSB_container" style="position: relative; top: 0px; left: -5px; width: 1544px; min-width: 100%; overflow-x: inherit;" dir="rtl">
                    <ul class="" data-lightbox="gallery">
                        <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div id="mCSB_1_scrollbar_horizontal" class="mCSB_scrollTools mCSB_1_scrollbar mCS-light-3 mCSB_scrollTools_horizontal" style="display: block;">
                </div>
            </div>
        </div>
    </div>
</div>
