<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllMemosUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AllMemos.AllMemosUserControl" %>

<style>
    .gridview {
        background-color: #fff;
        padding: 2px;
        margin: 2% auto;
    }
    /*.gridview a {
        margin: auto 1%;
        border-radius: 50%;
        background-color: #ae8b51 !important;
        padding: 5px 10px 5px 10px;
        color: #fff;
        text-decoration: none;
        -o-box-shadow: 1px 1px 1px #111;
        -moz-box-shadow: 1px 1px 1px #111;
        -webkit-box-shadow: 1px 1px 1px #111;
        box-shadow: 1px 1px 1px #111;
    }*/

    .pagi .pagination a.pageright, .pagi .pagination a.pageleft {
        color: #fff !important;
        border: 2px solid #bd995d;
        border-radius: 8px;
        font-size: 22px;
    }


    .gridview a, .gridview a:focus, .gridview a:hover {
        color: #fff !important;
        background-color: #ae8b51 !important;
        border-color: #ae8b51 !important;
    }

    .gridview a, .gridview.span {
        margin: 2px;
        border: 0px;
        color: #9b9a9a;
        border-radius: 7px;
        border: 2px solid #fff;
        font-size: 13px;
        height: 28px;
    }


    .gridview a:hover {
            background-color: #1e8d12;
            color: #fff;
        }
    .gridview span {
        background-color: #ae2676;
        color: #fff;
        -o-box-shadow: 1px 1px 1px #111;
        -moz-box-shadow: 1px 1px 1px #111;
        -webkit-box-shadow: 1px 1px 1px #111;
        box-shadow: 1px 1px 1px #111;
        border-radius: 50%;
        padding: 5px 10px 5px 10px;
    }
</style>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCirculars%>" />
</h4>

<div class="searchboxne">
    <div class="row d-flex justify-content-center align-items-center">
        <div class="col-md-9">
            <div class="row">
                <div class="col-md-1">
                    <label class="lbel"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCircularTitle%>" /></label>
                </div>
                <div class="col-md-5">
                    <input runat="server" type="text" ID="txtSrch" class="form-control"/>
                </div>
                <div class="col-md-1">
                    <label class="lbel"><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCircularNumber%>" /></label>

                </div>
                <div class="col-md-5">
                    <input runat="server" type="text" ID="txtNumber" class="form-control"/>
                </div>
            </div>
        </div>
        <div class="col-md-3">
             <asp:Button ID="btnSrch" runat="server" Text='<%$ Resources:Resource, btnSearch%>' class="btnclass" OnClick="btnSrch_Click" />
            <asp:Button ID="bntClear" runat="server" Text='<%$ Resources:Resource, btnClear%>' class="btnclass" OnClick="btnClear_Click" />
        </div>

    </div>
</div>


<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, innerHeadCirculars%>" />
</h4>
<div id="posts" class="small-thumbs alt">

    <asp:GridView ID="grdMemosLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="No Archives Found"
    BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
    EnableModelValidation="True" AllowPaging="true" OnPageIndexChanging="grdMemosLst_PageIndexChanging"
    OnRowDataBound="grdMemosLst_RowDataBound" PageSize="5">
    <%--<PagerStyle CssClass="Gridpagination" HorizontalAlign="Left" />--%>
    <PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
        Mode="NumericFirstLast" PageButtonCount="5" />
    <PagerStyle HorizontalAlign="Center" CssClass="gridview" />
    <EmptyDataRowStyle Font-Bold="true" ForeColor="#333" Font-Size="40" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div class="entry entryitem clearfix">
                    <div class="entry-image bgeb">
                        <p>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, innerCircularsLstItemHead%>" />
                        </p>
                        <span>
                            <%# Eval("MemoNumber") %>
                        </span>
                    </div>
                    <div class="entry-c entryitemx">

                        <span class="dateut"><%#  Convert.ToDateTime(Eval("Date")).ToString("dd-MMM-yyyy")%></span>
                        <h6>
                            <a href="<%# Eval("AttachmentsInfo") %>"><%# Eval("Title") %>
                            </a>
                        </h6>
                        <p>
                            <%# Eval("Body") %>
                        </p>

                    </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</div>
<!-- #posts end -->


<%--<div class="pagi">
    <ul class="pagination">
        <li class="page-item"><a class="page-link pageright" href="#"><i class="icon-angle-right"></i>
        </a></li>
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
        <li class="page-item"><a class="page-link pageleft" href="#">
            <i class="icon-angle-left"></i></a></li>
    </ul>
</div>--%>












