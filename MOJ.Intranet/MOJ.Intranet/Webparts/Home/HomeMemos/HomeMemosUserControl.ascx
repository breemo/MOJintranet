﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeMemosUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.HomeMemos.HomeMemosUserControl" %>

<div class="Desciosion">
    <div class="headlineflex">
        <h4 class="TitleHead"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCirculars%>" /></h4>
        <a href="../Ar/decsioncircular" class="slide morebuttoncss arrow"><asp:Literal runat="server" Text="<%$ Resources:Resource, more%>" /></a>
    </div>
    <div class="boxsec">
        <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
    </div>
</div>