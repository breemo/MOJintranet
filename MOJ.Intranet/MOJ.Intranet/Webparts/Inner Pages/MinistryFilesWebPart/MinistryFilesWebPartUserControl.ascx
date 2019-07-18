<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinistryFilesWebPartUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.MinistryFilesWebPart.MinistryFilesWebPartUserControl" %>

<style>
    #header-wrap {
        z-index: 8;
    }

    .modal-backdrop {
        position: fixed;
        top: 0;
        left: 0;
        z-index: 30;
        width: 100vw;
        height: 100vh;
        background-color: #000;
    }

    #Satisfay {
        z-index: 999999999;
    }


    #smileys {
        padding-left: 2em;
        padding-right: 2em;
    }

    #Satisfay form#smileys input[type=radio]::-ms-check {
        visibility: hidden;
        -webkit-filter: grayscale(100%);
        filter: grayscale(100%);
    }

    #Satisfay form#smileys input[type="radio"] {
        -webkit-appearance: none;
        width: 90px;
        height: 90px;
        border: none;
        cursor: pointer;
        transition: border .2s ease;
        margin: 0 5px;
        transition: all .2s ease;
    }

        #Satisfay form#smileys input[type="radio"]:hover, form#smileys input[type="radio"]:checked {
        }

        #Satisfay form#smileys input[type="radio"]:focus {
            outline: 0;
        }

        #Satisfay form#smileys input[type="radio"].happy {
            background: url("images/01.png") center;
            background-size: cover;
            fill: #b08727;
        }

            #Satisfay form#smileys input[type="radio"].happy path {
                fill: #b08727;
            }

        #Satisfay form#smileys input[type="radio"].neutral {
            background: url("images/02.png") center;
            background-size: cover;
            fill: #b08727;
        }

        #Satisfay form#smileys input[type="radio"].sad {
            background: url("images/03.png") center;
            background-size: cover;
            fill: #b08727;
        }

    #Satisfay .mtt {
        position: fixed;
        bottom: 10px;
        right: 20px;
        color: #999;
        text-decoration: none;
    }

        #Satisfay .mtt span {
            color: #b08727;
        }

        #Satisfay .mtt:hover {
            color: #b08727;
        }

            #Satisfay .mtt:hover span {
                color: #b08727;
            }

    .rv {
        display: block;
        width: 100% !important;
    }

    .modal-title.rigle {
        float: right;
    }

    .blef {
        float: left;
    }

    .insdpad {
        padding: 3em;
    }

    .formby {
        padding: 0.5em 1.3em 0.7em 2em;
    }

        .formby input {
            height: calc(1.75rem + 2px);
        }

        .formby .labelri {
            line-height: 16px;
            font-weight: 600;
            font-family: 'Cairo', sans-serif !important;
            letter-spacing: 0px;
            color: #707070;
            font-size: 0.90em;
        }

        .formby .row {
            height: 40px;
        }

            .formby .row input {
                border-radius: 5px;
            }

        .formby select {
            font-size: 0.75em;
            height: calc(1.75rem + 3px);
        }

        .formby ::-webkit-input-placeholder {
            font-size: 0.70em;
        }


        .formby :-moz-placeholder {
            font-size: 0.70em;
        }


        .formby ::-moz-placeholder {
            font-size: 0.70em;
        }

        .formby :-ms-input-placeholder {
            font-size: 0.70em;
        }


        .formby ::-ms-input-placeholder {
            font-size: 0.75em;
        }


        .formby .radix {
            border-radius: 14px !important;
            margin: 4px 8px;
            padding: 0px 32px 0px 33px;
        }

    .boxsearchbook {
        border: 1px solid #e1e1e1;
        height: 360px;
        margin-bottom: 10px;
        margin-left: 4px;
    }

    .titlebook h4 {
        text-align: center;
        margin-bottom: 0px;
        color: #646464;
        font-size: 1.1em;
    }

    span.desco {
        text-align: center;
        padding: 0.3em 3em;
        display: block;
        /* width: 70%; */
        justify-content: center;
        align-items: center;
        display: flex;
        height: 49px;
        overflow: hidden;
        color: #646464;
    }

    .uploadediv p {
        margin-bottom: 0px;
    }

        .uploadediv p span {
            font-weight: bold;
            display: block;
        }

    .uploadediv {
        background: #bd995d;
        padding: 0.5em 1em;
        color: #fff;
        text-align: center;
        display: flex;
        align-content: center;
        justify-content: center;
        font-size: 1.08em;
    }

    .imgboxbook img {
        display: block;
        margin: 10px auto;
        height: 150px;
    }

    .uploadediv p {
        margin-bottom: 0px;
        line-height: 1.46 !important;
    }

    .pagi {
        display: flex;
        justify-content: center;
        margin-top: 17px;
    }

    .booksearchitems .col-md-4 {
        padding-right: 5px;
        padding-left: 5px;
    }

    .fullwidthtabs {
        width: 100%;
    }

        .fullwidthtabs .tab-nav li {
            width: 50%;
        }

        .fullwidthtabs .tab-nav li {
            height: 91px;
            line-height: 91px;
        }

            .fullwidthtabs .tab-nav li a {
                height: 91px !important;
                line-height: 91px !important;
            }

            .fullwidthtabs .tab-nav li:first-child {
                margin-right: 0px !important;
                margin-left: 0px !important;
            }

        .fullwidthtabs ul.tab-nav:not(.tab-nav-lg) li {
            height: 91px;
        }

            .fullwidthtabs ul.tab-nav:not(.tab-nav-lg) li.ui-tabs-active a {
                position: relative;
                top: 1px;
                background-color: #f5f5f5 !important;
                border: 1px dotted #555;
            }

            .fullwidthtabs ul.tab-nav:not(.tab-nav-lg) li.ui-tabs-tab a {
                position: relative;
                top: 1px;
                background-color: #fff;
            }

        .fullwidthtabs .tab-container {
            border: 1px solid #dedddd;
        }

    .inskdnew {
        padding: 1em 2em;
        padding-left: 5em;
    }

        .inskdnew label {
            font-size: 1.1em;
            font-weight: normal;
        }

        .inskdnew .form-control {
            font-size: 0.75em;
            border-radius: 4px !important;
            height: calc(2.0rem + 2px) !important;
        }

    .rt {
        margin-bottom: 20px;
        align-items: center;
    }

    label.form-check-label {
        font-size: 1.1em;
    }

    .fullwidthtabs ul.tab-nav:not(.tab-nav-lg) li.ui-tabs-active a {
        position: relative;
        top: 1px;
        background-color: #fff !important;
        border: 0px;
        color: #666;
    }

    .inskdnew .form-control {
        color: #aba8a8;
    }

    .inskdnew textarea.form-control {
        height: 140px !important;
    }

    .rt div {
        align-items: center;
    }

    .inskdnew label {
        font-size: 1.05em;
        font-weight: 400;
    }

    .fleb {
        display: flex;
        align-items: flex-start;
    }

    .inskdnew textarea.form-control {
        height: 140px !important;
        width: 98%;
    }

    .newrowtime [class*='col-md'] {
        padding-right: 5px;
        padding-left: 5px;
    }

    .morebutovn {
        border: 1px solid #bd995d;
        background: #fff;
        color: #bd995d;
        border-radius: 18px;
        padding: 3px 9px 3px 11px;
        font-weight: bold;
        font-size: 0.65rem;
        box-shadow: -3px 0px 9px rgba(13,13,13,0.07);
        line-height: 14px;
        -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        margin-right: 1em;
    }

    .morebutovn2 {
        border: 1px solid #bd995d;
        background: #fff;
        color: #bd995d;
        border-radius: 18px;
        padding: 5px 20px 5px 20px;
        font-weight: bold;
        font-size: 0.75rem;
        box-shadow: -3px 0px 9px rgba(13,13,13,0.07);
        line-height: 14px;
        -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        margin-right: 1em;
    }

        .morebutovn2:hover {
            border: 1px solid #bd995d;
            background: #bd995d;
            color: #fff;
            border-radius: 18px;
            padding: 5px 20px 5px 20px;
            font-weight: bold;
            font-size: 0.75rem;
            box-shadow: -3px 0px 9px rgba(13,13,13,0.07);
            line-height: 14px;
            -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
            transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
            margin-right: 1em;
        }

    .inskdnew .form-control:hover, .inskdnew .form-control:focus {
        box-shadow: 0 0 5px rgba(189, 153, 93, 1);
        border: 1px solid rgba(189, 153, 93, 1);
    }

    .botx {
        display: flex;
        justify-content: center;
    }

    .fullwidthtabs ul.tab-nav:not(.tab-nav-lg) li a {
        position: relative;
        top: 1px;
        background-color: #f5f5f5 !important;
        border: 0px;
        border-right: 2px dashed #e7e7e7;
        border-bottom: 2px dashed #e7e7e7;
        color: #b1b1b1;
    }

    .tables-page-section .table {
        text-align: center;
        margin-bottom: 40px;
    }

        .tables-page-section .table th {
            border-bottom: 1px solid #ffffff;
            border-right: 1px solid #ffffff;
            font-family: 'Montserrat', sans-serif;
            font-size: 15px;
            font-weight: 700;
            padding: 10px 20px;
            text-align: center;
        }

    .inskdnew2 {
        padding-left: 1.6em;
    }

    .newtableb {
        margin-top: 20px;
        width: 99%;
        margin-right: 0.5%;
    }

        .newtableb thead th {
            background-color: #bd995d;
            color: #fff;
            border: 0px;
        }

        .newtableb tfoot {
            background-color: #f5f5f5;
            padding: 0px !important;
            margin: 0px !important;
        }

            .newtableb tfoot .pagi, .newtableb tfoot .pagination {
                padding: 0px !important;
                margin: 0px !important;
            }

                .newtableb tfoot .pagi .pagination li a {
                    background-color: #f5f5f5;
                    border-color: #f5f5f5;
                }

            .newtableb tfoot .page-item.active .page-link, .newtableb tfoot .page-link:focus, .newtableb tfoot .page-link:hover {
                color: #fff !important;
                background-color: #ae8b51 !important;
                border-color: #ae8b51 !important;
            }

            .newtableb tfoot .pagi .pagination a.pageright, .newtableb tfoot .pagi .pagination a.pageleft {
                color: #fff !important;
                border: 2px solid #bd995d;
                border-radius: 8px;
                font-size: 22px;
            }

            .newtableb tfoot .pageright, .newtableb tfoot .pageleft {
                background: #bd995d !IMPORTANT;
                border-radius: 8px;
                color: #fff;
            }

            .newtableb tfoot .pagi .pagination li a.activepage {
                border: 2px solid #bcbcbc;
                color: #000;
            }

        .newtableb thead TH {
            text-align: center;
        }

    .table.newtableb thead TH {
        text-align: center;
        font-size: 0.9em;
        vertical-align: middle !important;
    }

    .newtableb thead TH span.fsiz {
        font-size: 1.5em;
    }

    .table.newtableb td {
        border: 0px;
    }

    .table-responsive > .table-bordered {
        border: 1px solid #e1e1e1;
    }

    .table.newtableb td {
        padding: 1.1em 0.75rem;
        vertical-align: top;
        border-top: 1px solid #dee2e6;
    }

    .newtableb tfoot .pagi .pagination li a {
        margin: 0px;
    }


    .searchboxne2 select.form-control {
        display: block;
        width: 100%;
        height: calc(1.95rem + 2px);
        padding: 0.375rem 0.75rem;
        font-size: 0.70rem;
        font-weight: 400;
        line-height: 2.15;
        color: #495057;
        background-color: #fff;
        background-clip: padding-box;
        border: 1px solid #ced4da;
        border-radius: 0.25rem;
        transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
    }

    .searchboxne2 .lbel {
        font-weight: 600;
        font-family: 'Cairo', sans-serif !important;
        letter-spacing: 0px;
        color: #707070;
        line-height: 2.0;
    }

    .newsitemxlist .bgeb img {
        margin-top: 45px;
    }

    .newsitemxlist {
        padding: 1em 1em;
    }

        .newsitemxlist .entryitemx h6 a {
            color: #646464;
            font-size: 0.87em;
        }

        .newsitemxlist .small-thumbs.alt .entry-image {
            margin: 0 0 0 14px;
        }

        .newsitemxlist .entryitemx p {
            padding-left: 14px;
        }

    @media (max-width: 767.98px) {
        .pagi .pagination li a {
            margin: 0px;
        }

        .pagi .pagination li {
            margin-left: 2px;
            border: 0px;
        }

        .page-link {
            padding: 0.21rem 0.45rem;
        }
    }



    #newslidertop {
        padding-top: 25px;
        padding-bottom: 29px;
        font-family: 'Rubik', sans-serif;
    }

    .review-author {
        font-size: 22px;
        font-weight: 500;
        margin-top: 30px;
        text-transform: uppercase;
    }

    #newslidertop .carousel-indicators {
        bottom: -96px;
    }

        #newslidertop .carousel-indicators li {
            border-radius: 50% !important;
            width: 11px;
            height: 12px;
        }

        #newslidertop .carousel-indicators li {
            background-color: rgba(0, 0, 0, .5);
        }

        #newslidertop .carousel-indicators .active {
            background-color: #bd995d;
        }


    #newslidertop .carousel-control-next-icon,
    #newslidertop .carousel-control-prev-icon {
        width: 35px;
        height: 35px;
    }

    #newslidertop .carousel-control-prev-icon {
        background-image: url("data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='%23000' viewBox='0 0 8 8'%3E%3Cpath d='M5.25 0l-4 4 4 4 1.5-1.5-2.5-2.5 2.5-2.5-1.5-1.5z'/%3E%3C/svg%3E");
    }

    #newslidertop .carousel-control-next-icon {
        background-image: url("data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='%23000' viewBox='0 0 8 8'%3E%3Cpath d='M2.75 0l-1.5 1.5 2.5 2.5-2.5 2.5 1.5 1.5 4-4-4-4z'/%3E%3C/svg%3E");
    }

    @media (max-width: 575px) {
        #newslidertop {
            padding-left: 40px;
            padding-right: 20px;
        }
    }

    #newslidertop .carousel-control-next-icon, #newslidertop .carousel-control-prev-icon {
        width: 35px;
        height: 35px;
        display: none;
    }

    #newslidertop {
        border: 1px solid #e1e1e1;
        margin-bottom: 40px;
    }

    .newsitemxlist .entry-image img {
        border-radius: 8px;
    }

    .newboxirwm {
    }

        .newboxirwm h4 {
            font-weight: 900;
            font-size: 0.95em;
            margin-bottom: 0px;
        }

    .searchboxne2 {
        margin-top: 56px;
    }

    #sidebarmenubox .uk-nav > li.uk-active {
        background: #bd995d;
        color: #fff;
    }

        #sidebarmenubox .uk-nav > li.uk-active > a::before,
        #sidebarmenubox .uk-nav > li.uk-active * {
            color: #fff;
        }

    .fullwidthtabs2 .tab-nav li {
        width: 33.3%;
    }

    .insidebox2 {
        border: 0PX !important;
    }

    li.ui-tab span.nameicon {
        background-image: url('images/tab01.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }

    li.ui-tab span.depicon {
        background-image: url('images/tab02.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }

    li.ui-tab span.woho {
        background-image: url('images/tab03.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }


    li.ui-tabs-active span.nameicon {
        background-image: url('images/tab01a.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }

    li.ui-tabs-active span.depicon {
        background-image: url('images/tab02a.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }

    li.ui-tabs-active span.woho {
        background-image: url('images/tab03a.png');
        background-repeat: no-repeat;
        background-position: right 18px;
        height: 70px;
        padding-right: 50px;
        display: inline-block;
    }

    .bgdivindf {
        background-color: #f4f4f4;
        border: 1px solid #e1e1e1;
        height: 350px;
        background-image: url('images/bgdvnew.png');
        background-repeat: no-repeat;
        background-position: top left;
    }

    .ndl {
        display: flex;
        justify-content: center;
    }

    .titleheadnew h4 {
        height: 70px;
        color: #bd995d;
        line-height: 70px;
        text-align: center;
    }

    .conentbgdivd {
        background: rgba(255,255,255,.7);
        height: 280px;
        width: 100%;
    }

    .conentbgdivd {
        background: rgba(255,255,255,.65);
        height: 280px;
        width: 100%;
        padding: 0px;
        /* margin: -15px; */
    }

    .titleheadnew h4 {
        height: 70px;
        color: #bd995d;
        line-height: 70px;
        text-align: center;
        margin-bottom: 0px;
    }

    .topbarprint {
        display: flex;
        justify-content: space-between;
    }

    .newitemtitlediv {
        color: #646464;
    }

        .newitemtitlediv h5 {
            font-size: 1.1em;
            color: #646464;
            padding-top: 5px;
        }

        .newitemtitlediv .datenewitem {
            font-size: 0.9em;
            color: #646464;
        }

    #newsdtailsim img {
        border-radius: 5px;
    }

    #newsdtailsim .carousel-indicators li {
        border-radius: 50% !important;
        width: 11px;
        height: 12px;
    }

    #newsdtailsim .carousel-indicators li {
        background-color: rgba(0, 0, 0, .5);
    }

    #newsdtailsim .carousel-indicators .active {
        background-color: #bd995d;
    }

    #newsdtailsim .carousel-control-prev, .carousel-control-next {
        opacity: 1;
    }

    #newsdtailsim .carousel-control-next-icon {
        background-image: url(data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgdmlld0JveD0iMCAwIDEyOSAxMjkiIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiBlbmFibGUtYmFja2dyb3VuZD0ibmV3IDAgMCAxMjkgMTI5IiB3aWR0aD0iNTEyIiBoZWlnaHQ9IjUxMiIgY2xhc3M9IiI+PGc+PGc+CiAgICA8cGF0aCBkPSJtNDAuNCwxMjEuM2MtMC44LDAuOC0xLjgsMS4yLTIuOSwxLjJzLTIuMS0wLjQtMi45LTEuMmMtMS42LTEuNi0xLjYtNC4yIDAtNS44bDUxLTUxLTUxLTUxYy0xLjYtMS42LTEuNi00LjIgMC01LjggMS42LTEuNiA0LjItMS42IDUuOCwwbDUzLjksNTMuOWMxLjYsMS42IDEuNiw0LjIgMCw1LjhsLTUzLjksNTMuOXoiIGRhdGEtb3JpZ2luYWw9IiMwMDAwMDAiIGNsYXNzPSJhY3RpdmUtcGF0aCIgc3R5bGU9ImZpbGw6I0ZGRkZGRiIgZGF0YS1vbGRfY29sb3I9IiMwMDAwMDAiPjwvcGF0aD4KICA8L2c+PC9nPiA8L3N2Zz4=);
        width: 50px;
        height: 50px;
    }

    #newsdtailsim .carousel-control-prev-icon {
        background-image: url(data:image/svg+xml;base64,PHN2ZyB2ZXJzaW9uPSIxLjEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgdmlld0JveD0iMCAwIDEyOSAxMjkiIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiBlbmFibGUtYmFja2dyb3VuZD0ibmV3IDAgMCAxMjkgMTI5IiB3aWR0aD0iNTEyIiBoZWlnaHQ9IjUxMiIgY2xhc3M9IiI+PGcgdHJhbnNmb3JtPSJtYXRyaXgoLTEsIC0xLjIyNDY1ZS0xNiwgMS4yMjQ2NWUtMTYsIC0xLCAxMjksIDEyOSkiPjxnPgogICAgPHBhdGggZD0ibTQwLjQsMTIxLjNjLTAuOCwwLjgtMS44LDEuMi0yLjksMS4ycy0yLjEtMC40LTIuOS0xLjJjLTEuNi0xLjYtMS42LTQuMiAwLTUuOGw1MS01MS01MS01MWMtMS42LTEuNi0xLjYtNC4yIDAtNS44IDEuNi0xLjYgNC4yLTEuNiA1LjgsMGw1My45LDUzLjljMS42LDEuNiAxLjYsNC4yIDAsNS44bC01My45LDUzLjl6IiBkYXRhLW9yaWdpbmFsPSIjMDAwMDAwIiBjbGFzcz0iYWN0aXZlLXBhdGgiIHN0eWxlPSJmaWxsOiNGRkZGRkYiIGRhdGEtb2xkX2NvbG9yPSIjMDAwMDAwIj48L3BhdGg+CiAgPC9nPjwvZz4gPC9zdmc+);
        width: 50px;
        height: 50px;
    }

    .newsdetailsi {
        font-size: 0.9em;
        color: #646464;
        text-align: justify;
        padding: 1em 0.5em 1em 1.2em;
    }

        .newsdetailsi p {
            font-size: 1em;
            font-weight: 500;
            margin-bottom: 10px;
        }

    #oc-events {
        direction: ltr;
    }

    .newdscroll {
        background: #fff !important;
        border: 1px solid #e1e1e1;
        width: 99%;
        height: 130px;
    }

        .newdscroll .entry-title h2 a {
            color: #646464;
            font-size: 0.70em;
            letter-spacing: 0px;
            line-height: 20px;
            display: block;
            font-weight: bold;
        }

    .endate {
        font-size: 0.8em;
    }

    .relatednewsico {
    }

    .relatednewsico {
        font-weight: bold;
        border-top: 1px solid #e1e1e1;
        padding: 0em 1em;
    }

        .relatednewsico h2 {
            font-weight: bold;
            letter-spacing: 0px;
            margin-top: 22px;
            margin-bottom: 14px;
            font-size: 1.6em;
        }

    .reladinfobox .owl-nav {
        position: absolute;
        top: 0px;
    }

    .reladinfobox .owl-carousel:hover .owl-nav .owl-next {
        left: 48px;
    }

    .reladinfobox .owl-carousel:hover .owl-nav .owl-prev {
        left: 0px;
    }

    .reladinfobox .owl-carousel .owl-nav [class*=owl-] {
        opacity: 1 !important;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-prev {
        left: 0px;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-next {
        left: 48px;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-prev {
        left: 0px;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-next {
        left: 48px;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-prev:hover {
        left: 0px;
    }

    .reladinfobox .owl-carousel .owl-nav .owl-next:hover {
        left: 48px;
    }

    .reladinfobox .owl-carousel .owl-nav .disabled {
        display: block !important;
    }

    .reladinfobox .ievent .entry-image {
        width: 35%;
    }

        .reladinfobox .ievent .entry-image img {
            border-radius: 6px;
        }

    .reladinfobox .owl-carousel .owl-nav [class*=owl-] {
        margin-top: -43px;
    }
</style>
<div class="container-fullwidth clearfix">

    <!-- Post Content
                    ============================================= -->
    <div class="postcontent nobottommargin col_last clearfix">
        <div class="boxleftbor">
            <h4>مكتبة الوزارة
            </h4>



            <div id="posts" class="small-thumbs alt">

                <div class="booksearchitems">



                    <div class="row">

                        <!--Item book-->
                        <%--<div class="col-md-4 col-sm-6">

                            <div class="boxsearchbook">

                                <div class="imgboxbook">
                                    <img src="http://moj-dev:2019/Style%20Library/MOJ-Theme/images/filebbok.png" />
                                </div>
                                <div class="titlebook">
                                    <h4>اسم الكتاب


                                    </h4>
                                    <span class="desco">هذا هو وصف قصير للكتاب
                                                        والكاتب
                                    </span>
                                </div>

                                <div class="uploadediv">
                                    <p>
                                        تم الرفع بواسطة
                                                        <span>محمد أكمل</span>

                                    </p>


                                </div>
                                <div class="dowmloadbook">
                                    <div class="row d-flex justify-content-center mt-3">


                                        <input type="button" class="btnclass radix" value="تحميل">
                                    </div>
                                </div>



                            </div>

                        </div>--%>

                        <asp:Repeater ID="grdBookslsts" runat="server"> 
                            <HeaderTemplate>
                             </HeaderTemplate>
                            <ItemTemplate>

                            
                                        <div class="col-md-4 col-sm-6">

                                            <div class="boxsearchbook">

                                                <div class="imgboxbook">
                                                    <img src="/Style%20Library/MOJ-Theme/images/filebbok.png" />
                                                </div>
                                                <div class="titlebook">
                                                    <h4>
                                                        <%# Eval("BookTitle") %>
                                                    </h4>
                                                    <span class="desco">
                                                        <%# Eval("BookDescAr") %>
                                                    </span>
                                                </div>

                                                <div class="uploadediv">
                                                    <p>
                                                        تم الرفع بواسطة
                                                        <span></span>

                                                    </p>


                                                </div>
                                                <div class="dowmloadbook">
                                                    <div class="row d-flex justify-content-center mt-3">


                                                        
                                                            <a runat="server" id="link" href='<%# Eval("AttachmentsInfo") %>'>
                                                            
                                                            <input type="button" class="btnclass radix" value="تحميل">
                                                        </a>
                                                    </div>
                                                </div>



                                            </div>

                                        </div>
                                    </ItemTemplate>
                               </asp:Repeater>

                    </div>

                </div>
            </div>
            <!-- #posts end -->


            <%--                            <div class="pagi">
                                <ul class="pagination">
                                    <li class="page-item">
                                        <a class="page-link pageright" href="#">
                                            <i class="icon-angle-right"></i>
                                        </a>
                                    </li>
                                    <li class="page-item"><a class="page-link activepage" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">4</a></li>
                                    <li class="page-item"><a class="page-link" href="#">5</a></li>
                                    <li class="page-item"><a class="page-link" href="#">6</a></li>
                                    <li class="page-item"><a class="page-link" href="#">7</a></li>
                                    <li class="page-item"><a class="page-link" href="#">8</a></li>
                                    <li class="page-item"><a class="page-link" href="#">9</a></li>
                                    <li class="page-item"><a class="page-link" href="#">10</a></li>
                                    <li class="page-item">
                                        <a class="page-link pageleft" href="#">
                                            <i class="icon-angle-left"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>--%>
        </div>


    </div>
    <!-- .postcontent end -->
    <!-- Sidebar
                    ============================================= -->
    <div class="sidebar nobottommargin clearfix">
        <div class="sidebar-widgets-wrap">

            <div id="sidebarmenubox" class="sidebarmenubox">
                <div class="searchboxinside">

                    <div class="formdiv formby">
                        <h5>البحث بواسطة
                        </h5>


                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    الفئة
                                </label>


                            </div>
                            <div class="col-md-9">
                                <select class="form-control">
                                    <option>اختر</option>
                                    <option>2</option>
                                    <option>3</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    اسم الكتاب
                                </label>

                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder="">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    كاتب
                                </label>

                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder="">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label class="labelri">
                                    تم الرفع بواسطة
                                </label>


                            </div>
                            <div class="col-md-9">
                                <input type="text" class="form-control" placeholder=" ">
                            </div>
                        </div>

                        <div class="row d-flex justify-content-center mt-3">


                            <input type="button" class="btnclass radix" value="بحث">
                            <input type="button" class="btnclass radix" value="واضح">
                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>
    <!-- .sidebar end -->

</div>
