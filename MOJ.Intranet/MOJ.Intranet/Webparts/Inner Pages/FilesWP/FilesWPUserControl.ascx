<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilesWPUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.FilesWP.FilesWPUserControl" %>

<style>
#content p {
text-align:center;

}
.filesinsde.row {
min-height:200px !important;
}
</style>

<div class="boxsh">
    <div class="insidebox">
        <h4 class="ta3m"><asp:Literal runat="server" Text="<%$ Resources:Resource, FilesTitle%>" /></h4>
        <div class="boxscroll demo-rtl" style="height: 100% !important;" data-simplebar="init" data-simplebar-auto-hide="false">
            <div class="filesinsde row" style="height: 100%">

                 <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
                <!-- <div class="col-md-2 col-sm-4">

                    <div class="filuo">
                        <div class="wfnew">
                            <p>
                                اسم الملف
                            </p>
                        </div>

                    </div>

                </div> -->
            </div>
        </div>
    </div>
</div>
