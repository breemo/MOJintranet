<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LiveEventsWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.LiveEventsWP.LiveEventsWPUserControl" %>

<style>
    .videlivebox {
        min-height: 204px;
    }
    /*@media {
        .videlivebox {
            min-height: 204px;
        }
    }*/
</style>
    <!-- External JavaScripts
    ============================================= -->
<script src="/Style%20Library/MOJTheme/js/jquery.js"></script>

<h3>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadLiveEvents%>" />
</h3>
<div class="insidebox insidebox2">
    <asp:Literal runat="server" ID="lblLiveEvents" />
</div>

<h3 class="primcolor">
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadLiveLastMonth%>" />
</h3>
<div class="livelastmotny">
    <div class="bo row">
        <asp:Literal runat="server" ID="lblbLiveEventsCurrentMonth" />
    </div>
</div>

<h3 class="primcolor">
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadLiveArchive%>" />
</h3>

<div class="livelastmotny">
    <div class="bo row">
        <asp:Literal runat="server" ID="lblArchive" />
    </div>
</div>
<script src="/Style%20Library/MOJTheme/js/functions.js"></script>
<script src="/Style%20Library/MOJTheme/js/jquery.overlayScrollbars.min.js"></script>

<link href="/Style%20Library/MOJTheme/css/OverlayScrollbars.min.css" rel="stylesheet" />


<script>
    $(function () {
        //The passed argument has to be at least a empty object or a object with your desired options
        $(".boxscroll").overlayScrollbars({

            className: "os-theme-dark",
            sizeAutoCapable: true,
            paddingAbsolute: true,
            scrollbars: {
                clickScrolling: true
            }
        });
    });

    var myVideo = document.getElementById("myVideo");

    function playPause() {
        if (myVideo.paused)
            myVideo.play();
        else
            myVideo.pause();
    }

    $(document).ready(function () {
        var icon = $('.play');
        icon.click(function () {
            icon.toggleClass('active');
            return false;
        });
    });
</script>
