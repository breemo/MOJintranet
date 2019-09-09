<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpAlbumsListUserControl.ascx.cs" Inherits="MOJ.Intranet.Webparts.Inner_Pages.wpAlbumsList.wpAlbumsListUserControl" %>

                        <h3>معرض الصور</h3>


                        


                        


                        <div class="insidebox newinsldeni ndivdr">



                            <div class="livelastmotny ">
                                <div class="bo row">

                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">


                                                <a href="#">
                                                <img class="image_fade" src="images/videos/vide1.jpg" alt="Gallery Thumb 1"></a>

                                                <div class="hoveroverlaynew">
                                                    <div class="insidehovwrbew">

                                                        <span class="icon-line-stack-2"></span>

                                                    </div>
                                                </div>

                                                </a>
                                                <a data-toggle="modal" class="newpos" data-target="#myModal2">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">أفضل تغطية 401k</a>
                                                </h6>

                                            </div>

                                        </div>




                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">
                                                <a href="#" data-lightbox="gallery-item">
                                                
                                                <img class="image_fade" src="images/videos/vide2.jpg" alt="Gallery Thumb 1">
                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                
                                                </a>


                                                <a data-toggle="modal" class="newpos" data-target="#myModal3">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">كل الأيام رائعة</a>
                                                </h6>
                                            </div>

                                            <!-- Modal -->


                                        </div>


                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">

                                                <a href="#" data-lightbox="gallery-item">
                                                <img class="image_fade" src="images/videos/vide3.jpg" alt="Gallery Thumb 1">
                                                
                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                </a>
                                            


                                                <a data-toggle="modal" class="newpos" data-target="#myModal8">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">اكراميات وفوائد</a>
                                                </h6>
                                            </div>

                                        </div>
                                        <!-- Modal -->


                                    </div>

                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">
                                                <a href="#" data-lightbox="image">
                                                    <img class="image_fade" src="images/videos/vide4.jpg"
                                                         alt="عنوان الصورة">

                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                </a>

                                                <a data-toggle="modal" class="newpos" data-target="#myModal9">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">عنوان الصورة</a>
                                                </h6>
                                            </div>

                                        </div>


                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">


                                                <a href="#">
                                                    <img class="image_fade" src="images/videos/vide1.jpg" alt="Gallery Thumb 1">
                                                </a>

                                                <div class="hoveroverlaynew">
                                                    <div class="insidehovwrbew">

                                                        <span class="icon-line-stack-2"></span>

                                                    </div>
                                                </div>

                                                </a>
                                                <a data-toggle="modal" class="newpos" data-target="#myModal2">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">أفضل تغطية 401k</a>
                                                </h6>

                                            </div>

                                        </div>




                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">
                                                <a href="#" data-lightbox="gallery-item">

                                                    <img class="image_fade" src="images/videos/vide2.jpg" alt="Gallery Thumb 1">
                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>

                                                </a>


                                                <a data-toggle="modal" class="newpos" data-target="#myModal3">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">كل الأيام رائعة</a>
                                                </h6>
                                            </div>

                                            <!-- Modal -->


                                        </div>


                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">

                                                <a href="#" data-lightbox="gallery-item">
                                                    <img class="image_fade" src="images/videos/vide3.jpg" alt="Gallery Thumb 1">

                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                </a>



                                                <a data-toggle="modal" class="newpos" data-target="#myModal8">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">اكراميات وفوائد</a>
                                                </h6>
                                            </div>

                                        </div>
                                        <!-- Modal -->


                                    </div>

                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">
                                                <a href="#" data-lightbox="image">
                                                    <img class="image_fade" src="images/videos/vide4.jpg"
                                                         alt="عنوان الصورة">

                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                </a>

                                                <a data-toggle="modal" class="newpos" data-target="#myModal9">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">عنوان الصورة</a>
                                                </h6>
                                            </div>

                                        </div>


                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">


                                                <a href="#">
                                                    <img class="image_fade" src="images/videos/vide1.jpg" alt="Gallery Thumb 1">
                                                </a>

                                                <div class="hoveroverlaynew">
                                                    <div class="insidehovwrbew">

                                                        <span class="icon-line-stack-2"></span>

                                                    </div>
                                                </div>

                                                </a>
                                                <a data-toggle="modal" class="newpos" data-target="#myModal2">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">أفضل تغطية 401k</a>
                                                </h6>

                                            </div>

                                        </div>




                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">
                                                <a href="#" data-lightbox="gallery-item">

                                                    <img class="image_fade" src="images/videos/vide2.jpg" alt="Gallery Thumb 1">
                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>

                                                </a>


                                                <a data-toggle="modal" class="newpos" data-target="#myModal3">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">كل الأيام رائعة</a>
                                                </h6>
                                            </div>

                                            <!-- Modal -->


                                        </div>


                                    </div>


                                    <div class="col-md-3 col-sm-6">

                                        <div class="videlivebox" data-lightbox="gallery">
                                            <div class="entry-image">

                                                <a href="#" data-lightbox="gallery-item">
                                                    <img class="image_fade" src="images/videos/vide3.jpg" alt="Gallery Thumb 1">

                                                    <div class="hoveroverlaynew">
                                                        <div class="insidehovwrbew">

                                                            <span class="icon-line-stack-2"></span>

                                                        </div>
                                                    </div>
                                                </a>



                                                <a data-toggle="modal" class="newpos" data-target="#myModal8">
                                                </a>
                                            </div>
                                            <div class="entry-title">
                                                <h6>
                                                    <a href="#">اكراميات وفوائد</a>
                                                </h6>
                                            </div>

                                        </div>
                                        <!-- Modal -->


                                    </div>

                                    

                                </div>

                            </div>


                        </div>