<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllMemosUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AllMemos.AllMemosUserControl" %>

<style>
    .entryitemx {
    min-height: 125px;
    height: auto !important;
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
                    <label class="lbel">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCircularTitle%>" /></label>
                </div>
                <div class="col-md-5">
                    <input runat="server" type="text" id="txtSrch" class="form-control" />
                </div>
                <div class="col-md-1">
                    <label class="lbel">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadCircularNumber%>" /></label>

                </div>
                <div class="col-md-5">
                    <input runat="server" type="text" id="txtNumber" class="form-control" />
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
    <asp:Literal runat="server" id="lblHead" Text="<%$ Resources:Resource, innerHeadCirculars%>" />
</h4>
<div id="posts" class="small-thumbs alt">
    <asp:GridView ID="grdMemosLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
        BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
        EnableModelValidation="True" 
        >
        <PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
            Mode="NumericFirstLast" PageButtonCount="5" />
        <PagerStyle HorizontalAlign="Center" CssClass="gridview" />
        <EmptyDataRowStyle Font-Bold="true" ForeColor="#646464" Font-Size="1.5em" />
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

                            <span class="dateut">
                                <%#  Convert.ToDateTime(Eval("Date")).ToString("dddd")%>, <%#  Convert.ToDateTime(Eval("Date")).ToString("dd MMM yyyy")%>
                            </span>
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

<div class="pagi" runat="server" id="pgng">
    <ul class="pagination">
        <li class="page-item">
            <a class="page-link pageright" href="#">
                <i class="icon-angle-right"></i>
            </a>
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
            <a class="page-link pageleft" href="#">
                <i class="icon-angle-left"></i>
            </a>
        </li>
    </ul>
</div>