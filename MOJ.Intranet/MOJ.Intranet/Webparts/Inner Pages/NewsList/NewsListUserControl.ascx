<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.NewsList.NewsListUserControl" %>

<style>
    .pagi .pagination li a {
        color: #9b9a9a !important;
    }

    .page-link:focus {
        border-color: #bd995d !important;
    }
     .active {
        background-color: #e9ecef;
    }
     .col-md-1 {
        top: 5px;
    }
     .col-md-10 {
        top: 5px;
    }
     .col-md-2 {
        top: 5px;
    }
     img.img-fluid.d-block {
        min-height: 219px;
    }
</style>

<asp:HiddenField ClientIDMode="Static" ID="hdnPage" runat="server" />

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadPopularNews%>" />
</h4>

<div class="newslidertopdiv">
    <section id="newslidertop">
        <div class="container">
            <div id="carouselReviews" class="carousel slide" data-ride="carousel">
                <asp:Literal ID="lblPopularNewsCarousel" runat="server" Text="" />
                <asp:Literal ID="lblPopularNewsCarouselInner" runat="server" Text="" />

                <a class="carousel-control-prev" href="#carouselReviews" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Previous%>" /></span>
                </a>
                <a class="carousel-control-next" href="#carouselReviews" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource, Next%>" /></span>
                </a>
            </div>
        </div>
    </section>
</div>

<div class="searchboxne searchboxne2 ">
    <h4>
        <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadSrchNews%>" />
    </h4>
    <div class="row d-flex justify-content-center align-items-center">
        <div class="col-md-10">
            <div class="row">
                <div class="col-md-1">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, year%>" />
                </div>
                <div class="col-md-5">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlYear">
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, month%>" />
                </div>
                <div class="col-md-5">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMonth">
                        <asp:ListItem Text="<%$ Resources:Resource, select%>" Value="0"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month1%>" Value="1"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month2%>" Value="2"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month3%>" Value="3"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month4%>" Value="4"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month5%>" Value="5"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month6%>" Value="6"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month7%>" Value="7"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month8%>" Value="8"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month9%>" Value="9"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month10%>" Value="10"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month11%>" Value="11"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Resource, Month12%>" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
         <div class="col-md-2">
                <asp:Button ID="btnSrch" runat="server" Text='<%$ Resources:Resource, btnSearch%>' class="btnclass" OnClick="btnSrch_Click" />
            </div>
    </div>
</div>

<h4>
    <asp:Literal runat="server" Text="<%$ Resources:Resource, HeadNews%>" />
</h4>
<div id="posts" class="small-thumbs alt">


    <asp:GridView ID="grdNewsLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="<%$ Resources:Resource, EmptyData%>"
        BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
        EnableModelValidation="True">
        <PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
            Mode="NumericFirstLast" PageButtonCount="5" />
        <PagerStyle HorizontalAlign="Center" CssClass="gridview" />
        <%--<EmptyDataRowStyle Font-Bold="true" ForeColor="#333" Font-Size="40" />--%>
        <EmptyDataRowStyle Font-Bold="true" ForeColor="#646464" Font-Size="1.5em" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="entry entryitem clearfix newsitemxlist">
                        <div class="entry-image ">
                            <img src="<%# Eval("Picture") %>" />
                        </div>
                        <div class="entry-c entryitemx">

                            <span class="dateut">
                                <%#  Convert.ToDateTime(Eval("Created")).ToString("dddd")%>, <%#  Convert.ToDateTime(Eval("Created")).ToString("dd")%> <%#  Convert.ToDateTime(Eval("Created")).ToString("MMM")%>  <%#  Convert.ToDateTime(Eval("Created")).ToString("yyyy")%> </span>
                            <h6>
                                <a href="<%= SPContext.Current.RootFolderUrl %>/Details.aspx?sid=<%# Eval("ID") %>&type=news"><%# Eval("Title") %>
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

<script>

var valuepage=  document.getElementById('hdnPage').value;
 $(".pagination a").each(function(){
if($(this).text()== valuepage) 
  $(this).addClass("active");
    });

</script>

<%--<script src="/Style%20Library/MOJ-Theme/js/functions.js"></script>--%>
