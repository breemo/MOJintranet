<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyRequestsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.MyRequests.MyRequestsUserControl" %>



<div class="headlineflex">
    <h4 class="TitleHead"><asp:Literal runat="server" Text="<%$ Resources:Resource, MyRequests%>" /></h4>

    <a href="ar/MyServices/Pages/MyRequests.aspx" class="slide morebuttoncss arrow"><asp:Literal runat="server" Text="<%$ Resources:Resource, AllRequests%>" /></a>
</div>

<div class="blockbox minhe newhri">


    <div class="d-flex ordercontainer">
        <asp:Label id="lbMyRequests" runat="server" style="width: 100%;"></asp:Label>
                                      
       
    </div>



</div>
