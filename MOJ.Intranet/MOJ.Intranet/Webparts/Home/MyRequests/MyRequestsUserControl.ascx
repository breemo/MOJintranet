<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyRequestsUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Home.MyRequests.MyRequestsUserControl" %>



<div class="headlineflex">
    <h4 class="TitleHead">طلـباتــي</h4>

    <a href="ar/MyServices/Pages/MyRequests.aspx" class="slide morebuttoncss arrow">جميع الطلبات</a>
</div>

<div class="blockbox minhe newhri">


    <div class="d-flex ordercontainer">
        <div class="col-sm-4 ">
            <div class="orderbox">
                <div class="topnot">
                    <p>
                        أشعارعودة
                    </p>

                </div>

                <div class="botonot">
                    <a href="#" class="btnstatus btnstatusc1">بأنتظارالموافقة
                    </a>
                </div>
            </div>

        </div>

        <div class="col-sm-4">
            <div class="orderbox">
                <div class="topnot">
                    <p>
                        طلب اشتراك
                                                        في مجلس معرفة

                    </p>

                </div>

                <div class="botonot">
                    <a href="#" class="btnstatus btnstatusc2">تمت الموافقة
                    </a>
                </div>
            </div>

        </div>

        <div class="col-sm-4">
            <div class="orderbox">
                <div class="topnot">
                    <p>
                        أسأل خبير

                    </p>
                </div>

                <div class="botonot">
                    <a href="#" class="btnstatus btnstatusc3">تمت الاجابة
                    </a>
                </div>
            </div>

        </div>

        <div class="col-sm-4">
            <div class="orderbox">
                <div class="topnot">
                    <p>
                        طلب اشتراك
                                                        في مجلس معرفة


                    </p>

                </div>

                <div class="botonot">
                    <a href="#" class="btnstatus btnstatusc2">تمت الموافقة
                    </a>
                </div>
            </div>

        </div>

        <div class="col-sm-4">
            <div class="orderbox">
                <div class="topnot">
                    <p>
                        أسأل خبير

                    </p>


                </div>

                <div class="botonot">
                    <a href="#" class="btnstatus btnstatusc3">تمت الاجابة
                    </a>
                </div>
            </div>

        </div>
    </div>



</div>
