<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemDetailsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.ItemDetails.ItemDetailsUserControl" %>

<link rel="stylesheet" href="/Style%20Library/MOJ-Theme/css/bootstrap.css" type="text/css" />
<link rel="stylesheet" href="/Style%20Library/MOJ-Theme/css/font-icons.css" type="text/css" />
<link rel="stylesheet" href="/Style%20Library/MOJ-Theme/css/animate.css" type="text/css" />
<link rel="stylesheet" href="/Style%20Library/MOJ-Theme/css/magnific-popup.css" type="text/css" />
<link rel="stylesheet" href="/Style%20Library/MOJ-Theme/css/responsive.css" type="text/css" />

<!-- External JavaScripts
    ============================================= -->
<script src="/Style%20Library/MOJ-Theme/js/jquery.js"></script>
<script src="/Style%20Library/MOJ-Theme/js/plugins.js"></script>

<div class="topbarprint">
    <h4>الاخبار
    </h4>
    <a href="" id="printpagebutton" onclick="printpage()">
        <span class="icon-line2-printer"></span>
    </a>
</div>

<asp:Literal ID="lblDetails" runat="server"></asp:Literal>



<%--<div class="newdetailnewdiv">
    <div class="newitemtitlediv">
        <span class="datenewitem">الأربعاء, 13 مارس 2019
        </span>
        <h5>رئيس الدولة يصدر مرسوما اتحادياً بتعيين 13 وكيل نيابة من أبناء الدولة
        </h5>
    </div>

    <section id="newdetailnew">
        <div class="row">
            <div id="newsdtailsim" class="carousel slide col-md-9 col-sm-12" data-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <div class="row">
                            <div class="col-sm-12 ">
                                <img src="http://moj-dev:2019/Lists/News/Attachments/3/img03.png" class="img-fluid  d-block " alt="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div id="posts" class="small-thumbs alt">
    <div class="newsdetailsi">
    </div>
</div>--%>
<!-- #posts end -->

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
