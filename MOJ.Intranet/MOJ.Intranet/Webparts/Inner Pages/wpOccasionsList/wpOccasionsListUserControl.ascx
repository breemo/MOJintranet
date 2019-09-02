<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpOccasionsListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpOccasionsList.wpOccasionsListUserControl" %>

<asp:Repeater ID="rptrOccasions" runat="server">
                <HeaderTemplate>
                    <h3><asp:Literal runat="server" Text="<%$ Resources:Resource, HeadEvents%>" /></h3>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="comment">
                        <div class="commentnewhead">
                            <div class="comment-header">
                                <div class="comment-header-img-box"
                                    style="background-image: url(images/OccUSer.jpg);">
                                </div>
                                <div class="comment-header-username">
                                    <a href="<%# SPContext.Current.RootFolderUrl %>/OccasionDetails.aspx?OccasionId=<%# Eval("ID") %>"><%# Eval("Title") %></a>
                                <%# Eval("CreatedBy") %>
                                </div>
                                <div class="comment-header-meta">
                                    <p>
                                        <asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedDate%>" />
                                    </p>
                                    <span>
                                        <%# Convert.ToDateTime(Eval("Created")).ToString("dd MMM yyyy") %>
                                    </span>
                                </div>
                            </div>
                            <div class="comment-body">
                                <%# Eval("Description") %>
                            </div>
                        </div>
                    </div>
<%--                    <div class="Commentitemlist">
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
                    </div>--%>
                </ItemTemplate>
            </asp:Repeater>





