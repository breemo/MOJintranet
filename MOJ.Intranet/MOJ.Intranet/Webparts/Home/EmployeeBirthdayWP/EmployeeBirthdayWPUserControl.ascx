<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeBirthdayWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.EmployeeBirthdayWP.EmployeeBirthdayWPUserControl" %>
<style>
    .ms-cui-topBar2 {
        display: none !important;
    }

    .stickMenu {
        display: none !important;
    }

    .sticky-style-2 {
        display: none !important;
    }

    #s4-titlerow {
        background-color: transparent !important;
    }
</style>

<div class="tab-container" data-active="">
    <div class="row rt">
        <h2>
            <asp:Label Text="<%$ Resources:Resource, EmployeeBirthdayParagraph%>" runat="server" />
        </h2>
    </div>
    <div class="row rt  botx" style="padding: 40px;">
        <asp:Button Text="<%$ Resources:Resource, publish%>" ID="btnPublish" runat="server" OnClick="btnPublish_Click" />
        <asp:Button Text="<%$ Resources:Resource, cancel%>" ID="btnCancel" runat="server" OnClick="btnCancel_Click" />
    </div>
</div>

