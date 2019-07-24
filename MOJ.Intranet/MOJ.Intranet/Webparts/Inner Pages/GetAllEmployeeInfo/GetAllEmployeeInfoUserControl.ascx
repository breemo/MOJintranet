<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetAllEmployeeInfoUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.GetAllEmployeeInfo.GetAllEmployeeInfoUserControl" %>

<script language="javascript" type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
<script language="javascript" type="text/javascript">  
    function showModalPopUp() {
        //Set options for Modal PopUp  
        var options = {
            url: '/Ar/Pages/AddEmployeeNumber.aspx?IsDlg=1', //Set the url of the page  
            title: 'Enter Employee Number', //Set the title for the pop up  
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

<div class="ndl">
    <div class="col-md-5 col-sm-12 bgdivindf">

        <div class="titleheadnew">
            <h4>بطاقة الاعمال الالكترونية</h4>
        </div>

        <div class="conentbgdivd">

            <div class="row">
                <div class="col-sm-12 jdivd">

                    <div class="mtopc">
                        <img src="/Style%20Library/MOJTheme/images/imgcircle.png" class="img-fluid">
                    </div>

                </div>

                <div class=" dininfo">

                    <table>

                        <tbody>
                            <tr>

                                <td>
                                    <p class="rmae">
                                        الأسم
                                    </p>
                                </td>
                                <td>

                                    <span class="nnamele">
                                        <asp:Literal ID="lblEmployeeNameAr" runat="server"></asp:Literal>
                                    </span></td>
                            </tr>
                            <tr>

                                <td>
                                    <p class="rmae">
                                        الأدارة
                                    </p>
                                </td>
                                <td>



                                    <span class="nnamele">
                                        <asp:Literal ID="lblDepartmentAr" runat="server"></asp:Literal>
                                    </span>

                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <p class="rmae">
                                        المسمى الوظيفي
                                    </p>
                                </td>
                                <td>

                                    <span class="nnamele">
                                        <asp:Literal ID="lblJobtitle" runat="server"></asp:Literal>
                                    </span>

                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <p class="rmae">
                                        البريد الألكتروني
                                    </p>
                                </td>
                                <td>

                                    <span class="nnamele">
                                        <asp:Literal ID="lblEmail" runat="server"></asp:Literal>
                                    </span>

                                </td>
                            </tr>


                            <tr>

                                <td>
                                    <p class="rmae">
                                        هاتف العمل
                                    </p>
                                </td>
                                <td>

                                    <span class="nnamele">
                                        <asp:Literal ID="lblContactNo" runat="server"></asp:Literal>
                                    </span>

                                </td>
                            </tr>
                        </tbody>
                    </table>



                </div>
            </div>
        </div>
    </div>






</div>
