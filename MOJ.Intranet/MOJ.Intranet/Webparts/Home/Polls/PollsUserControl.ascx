﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PollsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.Polls.PollsUserControl" %>

<script language="javascript" type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
<script language="javascript" type="text/javascript">  
    function Poll(PollsURL) {
        //Set options for Modal PopUp  
        var NewPollsURL = PollsURL;
        var options = {
            url: NewPollsURL + '?IsDlg=1', //Set the url of the page  
            allowMaximize: false,
            showClose: true,
            width: 600,
            height: 400
        };
        //Invoke the modal dialog by passing in the options array variable  
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;

    } 
</script>
<div class="polls">
    <div class="headlineflex">
        <h4 class="TitleHead">
            <asp:Literal runat="server" Text="<%$ Resources:Resource, Questionnaire%>" /></h4>

        <a href="<%= SPContext.Current.RootFolderUrl %>/ViewAllQuestionnaire.aspx" class="slide morebuttoncss arrow">
            <asp:Literal runat="server" Text="<%$ Resources:Resource, more%>" /></a>
    </div>


    <div class="boxsec">

        <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>

    </div>
</div>
