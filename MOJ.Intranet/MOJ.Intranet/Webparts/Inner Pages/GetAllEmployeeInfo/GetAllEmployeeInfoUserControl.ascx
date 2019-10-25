<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetAllEmployeeInfoUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.GetAllEmployeeInfo.GetAllEmployeeInfoUserControl" %>

<%-- -<script language="javascript" type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>-%>
<%--<script language="javascript" type="text/javascript">  
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
</script>--%>


<style>
    .active {
        background-color: #e9ecef;
    }
</style>

<asp:HiddenField ClientIDMode="Static" ID="hdnPage" runat="server" />

<div class="boxsh">
    <h3><asp:Literal runat="server" Text="<%$ Resources:Resource, OrgSubject%>" /></h3>


    <div class="insidebox insidebox2">


        <div class="tabs tabs-responsive clearfix fullwidthtabs fullwidthtabs2">

            <ul class="tab-nav  clearfix">
                <li>
                    <a href="#tab-responsive-1" aria-controls="tab-responsive-1">
                        <span class="nameicon"><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchByName%>" />
                        </span>

                    </a>
                </li>
                <li>
                    <a href="#tab-responsive-2" aria-controls="tab-responsive-2">
                        <span class="depicon"><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchByDept%>" />
                        </span>


                    </a>
                </li>
                <li>
                    <a href="#tab-responsive-3" aria-controls="tab-responsive-3">
                        <span class="woho"><asp:Literal runat="server" Text="<%$ Resources:Resource, SearchByPlace%>" />
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

                                            <input type="text" class="form-control" value="" runat="server" id="txtNameSearch" placeholder="<%$ Resources:Resource, PrimaryWords%>">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnNameSearch" CssClass="detailbtn" Text="<%$ Resources:Resource, Search%>" runat="server" placeholder="<%$ Resources:Resource, PrimaryWords%>" OnClick="btnNameSearch_Click" />
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
                    <div class="inskdnew inskdnew2">
                        <div class="inskdnew">

                            <div class="row rt">

                                <div class="col-md-10 col-sm-12">

                                    <div class="row">



                                        <div class="col-md-6 col-sm-12">

                                            <input type="text" class="form-control" value="" runat="server" id="txtDepartmentSearch" placeholder="<%$ Resources:Resource, PrimaryWords%>">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnDepartmentSearch" CssClass="detailbtn" Text="<%$ Resources:Resource, Search%>" runat="server" placeholder="<%$ Resources:Resource, PrimaryWords%>" OnClick="btnDepartmentSearch_Click" />
                                        </div>

                                    </div>




                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>
                        </div>


                    </div>


                </div>
                <div class="tab-content clearfix" id="tab-responsive-3">
                    <div class="inskdnew inskdnew2">
                        <div class="inskdnew">

                            <div class="row rt">

                                <div class="col-md-10 col-sm-12">

                                    <div class="row">



                                        <div class="col-md-6 col-sm-12">
                                            <input type="text" class="form-control" value="" runat="server" id="txtOffileLocation" placeholder="<%$ Resources:Resource, PrimaryWords%>">
                                        </div>

                                        <div class="col-md-2">
                                            <%--<button class="detailbtn">بحث</button>--%>
                                            <asp:Button ID="btnOfficeLocationSearch" CssClass="detailbtn" Text="<%$ Resources:Resource, Search%>" runat="server" placeholder="<%$ Resources:Resource, PrimaryWords%>" OnClick="btnOfficeLocationSearch_Click" />
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

        </div>



        <div class="ndl row">

            <asp:Repeater ID="grdPoeplelsts" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-4 col-sm-12 ">

                        <div class="bgdivindf">

                            <div class="titleheadnew">
                                <h4><asp:Literal runat="server" Text="<%$ Resources:Resource, BusinessECard%>" /></h4>
                            </div>

                            <div class="conentbgdivd">

                                <div class="row">
                                    <div class="col-sm-12 jdivd">

                                        <div class="mtopc">
                                            <img src="/Style%20Library/MOJTheme/images/icons/avatar.jpg" class="img-fluid" />
                                        </div>

                                    </div>

                                    <div class="dininfo">

                                        <table>

                                            <tr>

                                                <td>
                                                    <p class="rmae">
                                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Name%>" />
                                                    </p>
                                                </td>
                                                <td>

                                                    <span class="nnamele">
                                                        <%# Eval("AccountName") %>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td>
                                                    <p class="rmae">
                                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Department%>" />
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
                                                       <asp:Literal runat="server" Text="<%$ Resources:Resource, JobTitle%>" />
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
                                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Email%>" />
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
                                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, WorkPhone%>" />
                                                    </p>
                                                </td>
                                                <td>

                                                    <span class="nnamele">
                                                        <%# Eval("OfficeNumber") %>
                                                    </span>

                                                </td>
                                            </tr>
                                        </table>



                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <tr id="trEmpty" runat="server" visible="false">
                        <td>
                            <br />
                        </td>
                        <td colspan="3" align="center">
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, EmptyData%>" />
                        </td>
                    </tr>
                </FooterTemplate>
            </asp:Repeater>

            


        </div>
        <div class="pagi">
                <ul class="pagination" id="PaginUI" runat="server">
                    <li class="page-item">
                        <%--<a class="page-link pageright" href="#">--%>
                            <asp:LinkButton ID="lbPrevious" CssClass="page-link pageright" runat="server" OnClick="lbPrevious_Click">
                                <i class="icon-angle-right"></i>
                            </asp:LinkButton>
                            <%--</a>--%>
                    </li>



                    <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                        <ItemTemplate>

                            <li class="page-item">

                                <asp:LinkButton ID="btnPage"
                                    CssClass="page-link"
                                    CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                    runat="server" ForeColor="White" Font-Bold="True">
                                         <%# Container.DataItem %> </asp:LinkButton>

                            </li>





                        </ItemTemplate>
                    </asp:Repeater>


                    <li class="page-item">
                         <%--<a class="page-link pageleft" href="#">--%>
                            <asp:LinkButton ID="lbNext" CssClass="page-link pageleft" runat="server" OnClick="lbNext_Click">
                                <i class="icon-angle-left"></i>
                            </asp:LinkButton>
                            <%--</a>--%>
                    </li>
                </ul>
            </div>






    </div>



</div>


<script>

var valuepage=  document.getElementById('hdnPage').value;
 $(".pagination a").each(function(){
if($(this).text()== valuepage) 
  $(this).addClass("active");
    });

</script>




