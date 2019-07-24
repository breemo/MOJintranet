﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeNumberUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AddEmployeeNumber.AddEmployeeNumberUserControl" %>

<style>
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

        <div class="col-md-6">

            <%--   <div class="row">

                <div class="col-md-2">
                    <label>يرجى ادخال بريدك الإلكتروني</label>
                </div>

                <div class="col-md-9">
                    <input type="text" runat="server" id="Text1" class="form-control" placeholder="">
                </div>
            </div>--%>

            <div class="row">

                <div class="col-md-2">
                    <label>يرجى ادخال بريدك الإلكتروني</label>
                </div>

                <div class="col-md-9">
                    <input type="text" runat="server" id="txtEmail" class="form-control" placeholder="">
                </div>
            </div>

            <div class="row">

                <div class="col-md-2">
                    <label>يرجى ادخال رقمك الوظيفي</label>
                </div>

                <div class="col-md-9">
                    <input type="text" runat="server" id="txtEmployeeNumber" class="form-control" placeholder="">
                </div>
            </div>

            <div class="row">

                <div class="col-md-2">
                    <label>اعادة إدخال رقم الوظيفي</label>
                </div>

                <div class="col-md-9">
                    <input type="text" runat="server" id="txtEmployeeNumberMatch" class="form-control" placeholder="">
                </div>
            </div>

            <div id="errormsg" runat="server" style="display:none">
                <div class="row">

                    <div class="col-md-2">
                        
                    </div>

                    <div class="col-md-9">
                        <label style="color:red">الرقم الوظيفي المدخل غير مطابق أو البريد الإلكتروني غير صحيح</label>
                    </div>
                </div>
            </div>


        </div>

        <div class="row rt  botx" style="padding: 40px;">
            <asp:Button Text="ارسال" CssClass="morebutovn2" runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" />
        </div>
        <div class="col-md-6">
        </div>
    </div>
</div>
