<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OccasionsDetailsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.OccasionsDetails.OccasionsDetailsUserControl" %>

<h3>المناسبات</h3>






<div class="comment">

    <div class="commentnewhead">



        <div class="comment-header">
            <div class="comment-header-img-box"
                style="background-image: url(images/OccUSer.jpg);">
            </div>
            <div class="comment-header-username">
                <asp:Literal runat="server" ID="lblTitle"></asp:Literal>
            </div>
            <div class="comment-header-meta">
                <p>
                    تاريخ النشر

                </p>
                <span>10 ديسمبر 2012</span>
            </div>
            <div class="comment-header-meta">

                <p>
                    نشرت من قبل

                </p>
                <span>10 ديسمبر 2012</span>
            </div>
        </div>
        <div class="comment-body">
            <asp:Literal runat="server" ID="lblBody"></asp:Literal>
          <%--  <div class="comment-body-text">
                <p>
                    مع جنوب غضون فقامت جهة, عل ونتج لإعادة الشّعبين أسر. كل معارضة العالمية وصل, مكّن ا التّحول جُل تم, جعل أن جمعت الدمج حاملات. جمعت ومضى كل بعد. دفّة لإعلان الأوروبيّون بعد ان, التي السادس الصينية أضف أي. كل به، سياسة الشرقية اليابانية.
            </div>

            <div class="commentnews">

                <div class="rimfcomme">
                    <img src="images/newx.jpg" class="img-fluid" />
                </div>

                <div class="leftfcomme">
                    <h6>سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني

                    </h6>
                    <p>
                        تقدم معالي سلطان سعيد البادي وزير العدل المشاركين في مسيرة اليوم الرياضي الوطني والتي أقيمت حول مباني وزارة العدل والمحاكم الاتحادية بمدينة خليفة في أبو ظبي، بناء على توجيهات

                    </p>
                </div>

            </div>--%>


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

