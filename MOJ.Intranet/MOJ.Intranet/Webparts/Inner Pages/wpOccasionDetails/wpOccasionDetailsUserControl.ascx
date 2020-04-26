<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpOccasionDetailsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpOccasionDetails.wpOccasionDetailsUserControl" %>

<h3>
    <%--<asp:Literal runat="server" Text="<%$ Resources:Resource, HeadEvents%>" />--%>
    <asp:Literal ID="lblTitle" runat="server"/>
</h3>

<style>
    .col-md-3 {
        position: unset !important;
    }
</style>

<div class="comment">
    <div class="commentnewhead">
        <div class="comment-header">
            <div class="comment-header-img-box"
                style="background-image: url(/Style%20Library/MOJTheme/images/icons/avatar.jpg);">
            </div>
            <div class="comment-header-username">
                <asp:Literal runat="server" ID="lblPublishedBy"></asp:Literal>
            </div>
            <div class="comment-header-meta">
                <p>
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedDate%>" />
                </p>
                <span>
                    <asp:Literal runat="server" ID="lblPublishDate"></asp:Literal></span>
            </div>
        </div>
        <div class="comment-body">
            <asp:Literal runat="server" ID="lblOccasionBody"></asp:Literal>
        </div>
        <div class="commentsfooter">
            <div class="commentfooterinside">
                <asp:Repeater ID="rptrComments" runat="server">
                    <HeaderTemplate>
                        <h5>
                            <asp:Literal runat="server" Text="<%$ Resources:Resource, comments%>" /></h5>
                        <div class="commentitself">
                    </HeaderTemplate>

                    <ItemTemplate>
                        <div class="Commentitemlist">
                            <div class="cmmeninfbix">
                                <img src="/Style%20Library/MOJTheme/images/icons/avatar.jpg" class="img-circle img-fluid" />
                            </div>
                            <div class="ricom">
                                <p class="urnamex"><%# Eval("CreatedBy").ToString().Split('#')[1] %></p>
                                <p class="dateurx"><%# Convert.ToDateTime(Eval("Created")).ToString("dddd, dd MMMM yyyy HH:mm") %></p>
                                <p class="ricomdesc">
                                    <%# Eval("Description") %>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    <div class="cmmeninfbix">
                        <img src="/Style%20Library/MOJTheme/images/icons/avatar.jpg" class="img-circle img-fluid" />
                    </div>
                        <div class="ricom">
                            <asp:TextBox runat="server" class="form-control" ID="txtComments" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvComments" runat="server" ErrorMessage="*" ControlToValidate="txtComments"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="bntSubmit" runat="server" Text='<%$ Resources:Resource, btnSubmit%>' class="btnclass" OnClick="btnSubmit_Click" />
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
</div>
