<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckEmployeeBirthdayDateHandlerUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.CheckEmployeeBirthdayDateHandler.CheckEmployeeBirthdayDateHandlerUserControl" %>

<script language="javascript" type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
<script language="javascript" type="text/javascript">  
    function EmployeeBirthdayPopUp() {
        var EmployeeIDPage = '';
        var lcid = _spPageContextInfo.currentLanguage;
        //alert(lcid);
        if (lcid == 1025)
            EmployeeIDPage = '/Ar/Pages/EmployeeBirthday.aspx?IsDlg=1';
        else
            EmployeeIDPage = '/En/Pages/EmployeeBirthday.aspx?IsDlg=1';
        //Set options for Modal PopUp  
        var options = {
            url: EmployeeIDPage, //Set the url of the page  
            //title: 'Enter Employee Number', //Set the title for the pop up  
            allowMaximize: false,
            showClose: false,
            width: 600,
            height: 400
        };
        //Invoke the modal dialog by passing in the options array variable  
        SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;
    
    } 
</script>