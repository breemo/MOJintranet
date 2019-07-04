<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllNewsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.AllNews.AllNewsUserControl" %>


<asp:TextBox ID="txtSrch" runat="server" Width="200px"></asp:TextBox>
<asp:Button ID="btnSrch" runat="server" Text='Search' onclick="btnSrch_Click" />

<asp:GridView ID="grdNewsLst" CssClass="inner_cnt" GridLines="None" EmptyDataText="No Archives Found"
    BorderColor="#e5e5e5" Width="100%" runat="server" AutoGenerateColumns="False"
    EnableModelValidation="True" AllowPaging="true" OnPageIndexChanging="grdNewsLst_PageIndexChanging"
    OnRowDataBound="grdNewsLst_RowDataBound" PageSize="5">
    <%--<PagerStyle CssClass="Gridpagination" HorizontalAlign="Left" />--%>
    <PagerSettings FirstPageText="<<" LastPageText=">>" NextPageText=">" PreviousPageText="<"
        Mode="NumericFirstLast" PageButtonCount="5" />
    <PagerStyle HorizontalAlign="Center" CssClass="Gridpagination" />
    <EmptyDataRowStyle Font-Bold="true" ForeColor="#333" Font-Size="40" />
    <Columns>
        <asp:TemplateField ItemStyle-Width="40px">
            <ItemTemplate>
                <img width="30" src='<%# Eval("Picture") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a class='fancybox fancybox.iframe' style='text-decoration: underline; color: #0072BC; font-weight: bold; font-size: 14px' href='#'>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'
                        Style='text-decoration: underline; color: #0072BC; font-weight: bold; font-size: 14px'></asp:Label></a>

                <span>
                    <%#  Convert.ToDateTime(Eval("Date")).ToString("dd-MMM-yyyy")%></span>
                <asp:Label ID="lblBody" runat="server" Text='<%# Bind("Body") %>'
                        Style='text-decoration: underline; color: #0072BC; font-weight: bold; font-size: 14px'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
