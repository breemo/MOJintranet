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

<div class="boxsh">
    <h3>الهيكل التنظيمي - البطاقة التعريفية للموظف</h3>


    <div class="insidebox insidebox2">


        <div class="tabs tabs-responsive clearfix fullwidthtabs fullwidthtabs2">

            <ul class="tab-nav  clearfix">
                <li>
                    <a href="#tab-responsive-1">
                        <span class="nameicon">البحث عن الاسم
                        </span>

                    </a>
                </li>
                <li>
                    <a href="#tab-responsive-2">
                        <span class="depicon">البحث عن الادارة
                        </span>


                    </a>
                </li>
                <li>
                    <a href="#tab-responsive-3">
                        <span class="woho">البحث عن مكان العمل
                        </span>


                    </a>
                </li>
            </ul>

            <div class="tab-container">

                <div class="tab-content clearfix" id="tab-responsive-1">

                    <div class="inskdnew inskdnew2">
                        <div class="inskdnew">

                            <div class="row rt">

                                <div class="col-md-10 col-sm-12">

                                    <div class="row">



                                        <div class="col-md-6 col-sm-12">

                                            <input type="text" class="form-control" value="" runat="server" id="txtNameSearch" placeholder="الكلمات الرئيسية">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnNameSearch" CssClass="detailbtn" Text="بحث" runat="server" placeholder="الكلمات الرئيسية" OnClick="btnNameSearch_Click" />
                                        </div>

                                    </div>




                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                        </div>


                    </div>


                </div>
                <div class="tab-content clearfix" id="tab-responsive-2">
                    <div class="inskdnew">
                                 <div class="row rt">

                                <div class="col-md-10 col-sm-12">

                                    <div class="row">



                                        <div class="col-md-6 col-sm-12">

                                            <input type="text" class="form-control" value="" runat="server" id="txtDepartmentSearch" placeholder="الكلمات الرئيسية">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnDepartmentSearch" CssClass="detailbtn" Text="بحث" runat="server" placeholder="الكلمات الرئيسية" OnClick="btnDepartmentSearch_Click"  />
                                        </div>

                                    </div>




                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                    </div>
                </div>
                <div class="tab-content clearfix" id="tab-responsive-3">
                     <div class="inskdnew">
                                 <div class="row rt">

                                <div class="col-md-10 col-sm-12">

                                    <div class="row">



                                        <div class="col-md-6 col-sm-12">

                                            <input type="text" class="form-control" value="" runat="server" id="txtOffileLocation" placeholder="الكلمات الرئيسية">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnOfficeLocationSearch" CssClass="detailbtn" Text="بحث" runat="server" placeholder="الكلمات الرئيسية" OnClick="btnOfficeLocationSearch_Click"  />
                                        </div>

                                    </div>




                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                    </div>
                </div>

            </div>

        </div>




        <div class="ndl" id="CurrentUserDiv" runat="server">
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


        <asp:Repeater ID="grdPoeplelsts" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>


                <div class="ndl" id="CurrentUserDivDynamic" runat="server">
                    <div class="col-md-5 col-sm-12 bgdivindf">

                        <div class="titleheadnew">
                            <h4>بطاقة الاعمال الالكترونية</h4>
                        </div>

                        <div class="conentbgdivd">

                            <div class="row">
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
                                                         <%# Eval("AccountName") %>
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
                                                        <%# Eval("Department") %>
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
                                                        <%# Eval("JobTitle") %>
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
                                                        <%# Eval("WorkEmail") %>
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
                                                        <%# Eval("OfficeNumber") %>
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
            </ItemTemplate>
        </asp:Repeater>





    </div>



</div>




