<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpAlbumsListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpAlbumsList.wpAlbumsListUserControl" %>

<h3>
    <asp:Literal runat="server" ID="lblHead" Text="<%$ Resources:Resource, HeadGallery%>" />
</h3>

<div class="insidebox newinsldeni ndivdr">
    <div class="livelastmotny ">
        <div class="bo row">
            <asp:Literal runat="server" ID="lblDrawItems"/>

            <%--<asp:GridView ID="grdMemosLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
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
                    <div class="col-md-3 col-sm-6">
                        <div class="videlivebox" data-lightbox="gallery">
                            <div class="entry-image">
                                <a href="#">
                                <img class="image_fade" src="<%# Eval("PictureURL") %>" alt="<%# Eval("Title") %>"></a>
                                <div class="hoveroverlaynew">
                                    <div class="insidehovwrbew">
                                        <span class="icon-line-stack-2"></span>
                                    </div>
                                </div>
                                </a>
                                <a data-toggle="modal" class="newpos" data-target="#myModal2">
                                </a>
                            </div>
                            <div class="entry-title">
                                <h6>
                                    <a href="<%# Eval("URL") %>"><%# Eval("Title") %></a>
                                </h6>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
        </div>
    </div>
</div>

<%--<div class="pagi" runat="server" id="pgng">
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
</div>--%>