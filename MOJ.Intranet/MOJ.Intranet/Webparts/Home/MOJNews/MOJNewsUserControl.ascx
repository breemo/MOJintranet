<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MOJNewsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.MOJNews.MOJNewsUserControl" %>



<!--start news-->
<div class="col-xl-8 col-md-12 col-sm-12 bounceInLeft animated delay-7" data-animate="bounceInLeft">
    <div class="headlineflex">
        <h4 class="TitleHead">الاخبار</h4>
        <a href="#" class="slide morebuttoncss arrow">المزيد من الاخبار</a>

    </div>

    <div class="blockbox minhe">
        <div class="newsdivbox">
            <asp:Label ID="lblDrawItems" runat="server" Text=""></asp:Label>
<%--            <div class="newsitem">
                <div class="newsbox">
                    <p class="date">
                        مارس 20
                    </p>
                    <div class="imgdi">
                        <img src="images/img01.png" class="img-fluid" />

                    </div>
                    <div class="descipt">
                        رئيس الدولة يصدر مرسوماً اتحادياً بتعيين قاضيتين في القضاء الاتحادي أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة "حفظه الله" المرسوم الاتحادي رقم 27 لسنة 2019 بتعيين القاضي خديجة
                    </div>
                    <div class="morebtn">

                        <a href="#" class="slide newmorebuttoncss arrow">المزيد
                        </a>

                    </div>
                </div>

            </div>

            <div class="newsitem">
                <div class="newsbox">

                    <p class="date">
                        مارس 20
                    </p>
                    <div class="imgdi">
                        <img src="images/img02.png" class="img-fluid" />

                    </div>
                    <div class="descipt">
                        رئيس الدولة يصدر مرسوماً اتحادياً بتعيين قاضيتين في القضاء الاتحادي أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة "حفظه الله" المرسوم الاتحادي رقم 27 لسنة 2019 بتعيين القاضي خديجة
                    </div>
                    <div class="morebtn">

                        <a href="#" class="slide newmorebuttoncss arrow">المزيد
                        </a>

                    </div>
                </div>

            </div>

            <div class="newsitem">
                <div class="newsbox">

                    <p class="date">
                        مارس 20
                    </p>
                    <div class="imgdi">
                        <img src="images/img03.png" class="img-fluid" />

                    </div>
                    <div class="descipt">
                        رئيس الدولة يصدر مرسوماً اتحادياً بتعيين قاضيتين في القضاء الاتحادي أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة "حفظه الله" المرسوم الاتحادي رقم 27 لسنة 2019 بتعيين القاضي خديجة
                    </div>
                    <div class="morebtn">

                        <a href="#" class="slide newmorebuttoncss arrow">المزيد
                        </a>

                    </div>
                </div>

            </div>

            <div class="newsitem">
                <div class="newsbox">

                    <p class="date">
                        مارس 20
                    </p>
                    <div class="imgdi">
                        <img src="images/img04.png" class="img-fluid" />

                    </div>
                    <div class="descipt">
                        رئيس الدولة يصدر مرسوماً اتحادياً بتعيين قاضيتين في القضاء الاتحادي أصدر صاحب السمو الشيخ خليفة بن زايد آل نهيان رئيس الدولة "حفظه الله" المرسوم الاتحادي رقم 27 لسنة 2019 بتعيين القاضي خديجة
                    </div>
                    <div class="morebtn">

                        <a href="#" class="slide newmorebuttoncss arrow">المزيد
                        </a>

                    </div>
                </div>

            </div>--%>
        </div>

    </div>

</div>


<!--end news-->
