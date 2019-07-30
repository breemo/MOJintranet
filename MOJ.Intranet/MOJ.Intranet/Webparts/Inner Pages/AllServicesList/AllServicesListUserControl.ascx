<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllServicesListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.AllServicesList.AllServicesListUserControl" %>


<h4>خدماتي
</h4>

<div id="posts" class="small-thumbs alt">

    <div class="row">
        <div class="d-flex ordercontainerServices">
            <asp:Literal ID="lblDrawItems" runat="server"></asp:Literal>
            <%-- 
                        <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/01.png" />
                                </p>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">أشعارعودة
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/02.png" />

                                </p>

                            </div>

                            <div class="botonot">
                                <a href="#" class="">طلب استضافة
                                </a>
                            </div>
                        </div>

                    </div>

                   <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>

                                    <img src="../../../../_layouts/15/images/servicesicon/03.png" />

                                </p>

                                <span class="icon-star3"></span>

                            </div>

                            <div class="botonot">
                                <a href="#" class="">أقرار بالحالة الأجتماعية
                                </a>
                            </div>
                        </div>

                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/04.png" />

                                </p>
                                <span class="icon-star-empty"></span>
                            </div>

                            <div class="botonot">
                                <a href="#" class="">التواصل مع الموارد البشرية

                                </a>
                            </div>
                        </div>

                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/05.png" />


                                </p>

                                <span class="icon-star-empty"></span>
                            </div>

                            <div class="botonot">
                                <a href="#" class="">الخط الساخن للسعادة

                                </a>
                            </div>
                        </div>

                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/06.png" />
                                </p>
                                <span class="icon-star3"></span>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">أقرار بالحالة الأجتماعية
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/07.png" />
                                </p>
                                <span class="icon-star3"></span>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">أمر مهمة مركبة
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/08.png" />
                                </p>
                                <span class="icon-star-empty"></span>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">أقرار استلام سكن حكومي
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/09.png" />
                                </p>
                                <span class="icon-star3"></span>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">استمارة دورية خاصة بالسكن الحكومي
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-3">
                        <div class="orderbox">
                            <div class="topnot">
                                <p>
                                    <img src="../../../../_layouts/15/images/servicesicon/010.png" />
                                </p>
                                <span class="icon-star-empty"></span>
                            </div>
                            <div class="botonot">
                                <a href="#" class="">طلب صلاحيات - نظام الأمانات
                                </a>
                            </div>
                        </div>
                    </div>--%>
        </div>

    </div>


</div>
<!-- #posts end -->


