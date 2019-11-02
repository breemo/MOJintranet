<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeGalaryUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.HomeGalary.HomeGalaryUserControl" %>

<style>
.boxgallery
{
max-width: 870px;
}
</style>

<div class="headlineflex">
    <h4 class="TitleHead">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadGallery%>" />
    </h4>
    <a href="<%= SPContext.Current.RootFolderUrl %>/AlbumGallery.aspx" class="slide morebuttoncss arrow">
        <asp:Literal runat="server" Text="<%$ Resources:Resource, MorePictures%>" />
    </a>
</div>

<div class="boxgallery">
    <div class="boxcd">
      
            <div id="content-6" class="content horizontal-images clearfix ">   
                        <ul class="" data-lightbox="gallery">
                            <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
                        </ul>
            </div>
    </div>
</div>
