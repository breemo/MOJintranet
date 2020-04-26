<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemDetailsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.ItemDetails.ItemDetailsUserControl" %>

<style>
    .ms-webpart-zone {
        display: block !important;
    }

    .ms-webpart-cell-vertical {
        display: block !important;
    }

    .ms-webpart-chrome-vertical {
        display: block !important;
    }

    input[type=button], input[type=reset], input[type=submit], button {
        min-width: 0em !important;
    }
    .img-fluid{
        /*max-height:287px !important;*/
    } 
</style>

<div class="topbarprint">
    <h4>
        <asp:Literal ID="lblHead" runat="server" Text="" />
    </h4>
    <a href="" id="printpagebutton" onclick="printpage()">
        <span class="icon-line2-printer"></span>
    </a>
</div>

<asp:Literal ID="lblDetails" runat="server"></asp:Literal>


<%--<div class="bottomdiv">
    <div class="container-fullwidth">
        <div class="insfo">
            <a class="arrow" href="#">الذهاب الى الوراء
                        </a>
        </div>
    </div>
</div>--%>

<script src="/Style%20Library/MOJ-Theme/js/functions.js"></script>

<script type="text/javascript">
    function printpage() {
        //Get the print button and put it into a variable
        var printButton = document.getElementById("printpagebutton");
        //Set the print button visibility to 'hidden'
        printButton.style.visibility = 'hidden';
        //Print the page content
        window.print()
        //Set the print button to 'visible' again
        //[Delete this line if you want it to stay hidden after printing]
        printButton.style.visibility = 'visible';
    }
</script>
