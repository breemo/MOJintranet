<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.Attendance.AttendanceUserControl" %>



<h4 class="TitleHead"><asp:Literal runat="server" Text="<%$ Resources:Resource, Attendees%>" /></h4>
<div class="blockbox minhe bgx">

    <div class="boxline">
    </div>

    <div class="d-flex row">


        <div class="chart" style="-moz-user-select: none;" _echarts_instance_="ec_1562415571646">
            <div style="position: relative; overflow: hidden; width: 254px; height: 250px; padding: 0px; margin: 0px; border-width: 0px; cursor: default;">
                <canvas style="position: absolute; left: 0px; top: 0px; width: 254px; height: 250px; -moz-user-select: none; padding: 0px; margin: 0px; border-width: 0px;" data-zr-dom-id="zr_0" width="317" height="312"></canvas>
            </div>
        </div>

        <div class="chart" style="-moz-user-select: none;" _echarts_instance_="ec_1562415571647">
            <div style="position: relative; overflow: hidden; width: 254px; height: 250px; padding: 0px; margin: 0px; border-width: 0px; cursor: default;">
                <canvas style="position: absolute; left: 0px; top: 0px; width: 254px; height: 250px; -moz-user-select: none; padding: 0px; margin: 0px; border-width: 0px;" data-zr-dom-id="zr_0" width="317" height="312"></canvas>
            </div>
        </div>

        <div class="chart" style="-moz-user-select: none;" _echarts_instance_="ec_1562415571648">
            <div style="position: relative; overflow: hidden; width: 254px; height: 250px; padding: 0px; margin: 0px; border-width: 0px; cursor: default;">
                <canvas style="position: absolute; left: 0px; top: 0px; width: 254px; height: 250px; -moz-user-select: none; padding: 0px; margin: 0px; border-width: 0px;" data-zr-dom-id="zr_0" width="317" height="312"></canvas>
            </div>
        </div>






    </div>



</div>
