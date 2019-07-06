<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MeetingsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.Meetings.MeetingsUserControl" %>

<div class="mettings">
    <div class="headlineflex">
        <h4 class="TitleHead">الأجتماعات</h4>

    </div>


    <div class="smallbox">
        <div class="mettingitem">
            <h6>
                <a href="#">الأجتماعات</a>
            </h6>
            <p class="medate ">
                <span class="icon-calendar-alt1"></span>
                15-01-2019
            </p>
            <p class="meclock">
                <span class="icon-time"></span>
                12:00 PM- 02:00 PM
            </p>
        </div>

        <div class="mettingitem">
            <h6>
                <a href="#">محاضرة الدكتور سليم العلي</a>
            </h6>
            <p class="medate ">
                <span class="icon-calendar-alt1"></span>
                15-01-2019
            </p>
            <p class="meclock">
                <span class="icon-time"></span>
                12:00 PM- 02:00 PM
            </p>
        </div>
    </div>
</div>
