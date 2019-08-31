<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpOccasionDetailsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpOccasionDetails.wpOccasionDetailsUserControl" %>


<h3><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadEvents%>" /></h3>

<div class="comment">
    <div class="commentnewhead">
        <div class="comment-header">
            <div class="comment-header-img-box"
                style="background-image: url(images/OccUSer.jpg);">
            </div>
            <div class="comment-header-username">
                <asp:Literal runat="server" ID="lblPublishedBy"></asp:Literal>
            </div>
            <div class="comment-header-meta">
                <p>
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedDate%>" />
                </p>
                <span><asp:Literal runat="server" ID="lblPublishDate"></asp:Literal></span>
            </div>
<%--            <div class="comment-header-meta">
                <p><asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedBy%>" /></p>
                <span></span>
            </div>--%>
        </div>
        <div class="comment-body">
            <asp:Literal runat="server" ID="lblOccasionBody"></asp:Literal>
        </div>
        <div class="commentsfooter">
            <div class="commentfooterinside">
            <asp:Repeater ID="rptrComments" runat="server">
                <HeaderTemplate>
                    <h5><asp:Literal runat="server" Text="<%$ Resources:Resource, comments%>" /></h5>
                    <div class="commentitself">
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="Commentitemlist">
                        <div class="cmmeninfbix">
                            <img src="images/newx1.jpg" class="img-circle img-fluid" />
                        </div>
                        <div class="ricom">
                            <p class="urnamex"><%# Eval("CreatedBy") %></p>
                            <p class="dateurx">أمس الساعة 8:03</p>
                            <p class="ricomdesc">
                                <%# Eval("Description") %>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    <div class="cmmeninfbix">
                        <img src="images/commentuser.jpg" class="img-circle img-fluid" />
                    </div>
                    <div class="ricom">
                        <asp:TextBox runat="server" class="form-control" id="txtComments" rows="3"></asp:TextBox>
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
