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
                <asp:Literal runat="server" ID="lblOccasionTitle"></asp:Literal>
            </div>
            <div class="comment-header-meta">
                <p>
                    <asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedDate%>" />
                </p>
                <span><asp:Literal runat="server" ID="lblPublishDate"></asp:Literal></span>
            </div>
            <div class="comment-header-meta">
                <p><asp:Literal runat="server" Text="<%$ Resources:Resource, PublishedBy%>" /></p>
                <span><asp:Literal runat="server" ID="lblPublishedBy"></asp:Literal></span>
            </div>
        </div>
        <div class="comment-body">
            <asp:Literal runat="server" ID="lblOccasionBody"></asp:Literal>
        </div>
        <div class="commentsfooter">
            <h5>تعليق</h5>
            <div class="commentfooterinside">
                <div class="commentitself">
                    <div class="Commentitemlist">
                        <div class="cmmeninfbix">
                            <img src="images/newx1.jpg" class="img-circle img-fluid" />
                        </div>
                        <div class="ricom">
                            <p class="urnamex">محمد عبير عابد</p>
                            <p class="dateurx">أمس الساعة 8:03</p>
                            <p class="ricomdesc">
                                تقدم معالي سلطان سعيد البادي وزير العدل المشاركين في مسيرة اليوم الرياضي الوطني
                            </p>
                        </div>
                    </div>
                    <div class="Commentitemlist">
                        <div class="cmmeninfbix">
                            <img src="images/newx2.jpg" class="img-circle img-fluid" />
                        </div>
                        <div class="ricom">
                            <p class="urnamex">فاطمة حسن</p>
                            <p class="dateurx">أمس الساعة 8:03</p>
                            <p class="ricomdesc">
                                وفد قضائي سعودي يطلع على أفضل الممارسات بوزارة العدل: استقبل المستشار سلطان راشد المطروشي
                            </p>
                        </div>
                    </div>
                </div>
                <div class="cmmeninfbix">
                    <img src="images/commentuser.jpg" class="img-circle img-fluid" />
                </div>
                <div class="ricom">
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                </div>
            </div>
        </div>
    </div>
</div>
