using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MOJ.Entities;
using CommonLibrary;
using System.Data;

namespace MOJ.DataManager
{
    public class PhotoGalleryDataManager
    {

        #region PhotoGallery
        private string getDate(string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                return dt.ToShortDateString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public List<PhotoGalleryEntity> GetAllActivePhotoGalleryHomeItems()
        {
            List<PhotoGalleryEntity> galleryLst = new List<PhotoGalleryEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                //Get Picture Libray albums
                                SPList lstPhotos = oWeb.Lists.TryGetList("MOJGallery");
                                if (lstPhotos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.GalleryQuery;

                                    foreach (SPListItem galeryFolder in lstPhotos.Folders)
                                    {
                                        foreach (SPFile folderFile in galeryFolder.Folder.Files)
                                        {
                                            if (folderFile.Item["isActive"].ToString() == "True")
                                            {
                                                PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                                photo.ID = Convert.ToInt16(folderFile.Item[SharedConstants.ID]);
                                                photo.Title = Convert.ToString(folderFile.Item[SharedConstants.Name]);
                                                photo.Description = Convert.ToString(folderFile.Item[SharedConstants.Description]);
                                                photo.Created = Convert.ToDateTime(folderFile.Item[SharedConstants.Created]);
                                                photo.PictureThumbnailURL = Convert.ToString(folderFile.Item["Thumbnail URL"]);
                                                photo.PictureURL = Convert.ToString(folderFile.Item["EncodedAbsUrl"]);

                                                galleryLst.Add(photo);
                                            }
                                        }
                                    }



                                    //SPFolder albumfolder = oWeb.GetFolder(category);
                                    //SPQuery query = new SPQuery();
                                    //SPFolder _Folder = lstPhotos.Folders;//.RootFolder;
                                    //oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    //OLD code
                                    //SPListItemCollection lstItems = lstPhotos.GetItems(oQuery);
                                    //foreach (SPListItem lstItem in lstItems)
                                    //{
                                    //    PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                    //    photo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                    //    photo.Title = Convert.ToString(lstItem[SharedConstants.Name]);
                                    //    photo.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                    //    photo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                    //    photo.PictureThumbnailURL = Convert.ToString(lstItem["Thumbnail URL"]);
                                    //    photo.PictureURL = Convert.ToString(lstItem["EncodedAbsUrl"]);
                                    //    //test git by spadmin2
                                    //    //string ImageName = Convert.ToString(lstItem["Name"]);
                                    //    //test git by spadmin
                                    //    galleryLst.Add(photo);
                                    //}
                                }
                            }
                        }
                    }
                });

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return galleryLst;
        }

        public List<PhotoGalleryEntity> GetAlbumFiles(string category)
        {
            List<PhotoGalleryEntity> galleryLst = new List<PhotoGalleryEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                //Get Picture Libray albums
                                SPList lstPhotos = oWeb.Lists.TryGetList("MOJGallery");

                                if (lstPhotos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    SPFolder albumfolder = oWeb.GetFolder(category);
                                    SPFolder _Folder = lstPhotos.RootFolder;
                                    oQuery.Folder = albumfolder;

                                    SPListItemCollection lstPhotoItems = lstPhotos.GetItems(oQuery);

                                    foreach (SPListItem img in lstPhotoItems)
                                    {
                                        PhotoGalleryEntity photo = new PhotoGalleryEntity();

                                        object EncodedAbsWebImgUrl = img["FileRef"];
                                        if (EncodedAbsWebImgUrl != null)
                                        {

                                            photo.PictureURL = Convert.ToString(img["FileRef"]);
                                        }

                                        object EncodedAbsThumbnailUrl = img["EncodedAbsThumbnailUrl"];
                                        if (EncodedAbsThumbnailUrl != null)
                                        {

                                            photo.PictureThumbnailURL = Convert.ToString(img["EncodedAbsThumbnailUrl"]);
                                        }

                                        object Title = img["Title"];
                                        if (Title != null)
                                        {
                                            photo.Title = Convert.ToString(img["Title"]);
                                        }

                                        galleryLst.Add(photo);
                                    }


                                    //    //oQuery.Query = SharedConstants.GalleryQuery;

                                    //    foreach (SPListItem galeryFolder in lstPhotos.Folders)
                                    //{
                                    //    foreach (SPFile folderFile in galeryFolder.Folder.Files)
                                    //    {
                                    //        if (folderFile.Item["isActive"].ToString() == "True")
                                    //        {
                                    //            PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                    //            photo.ID = Convert.ToInt16(folderFile.Item[SharedConstants.ID]);
                                    //            photo.Title = Convert.ToString(folderFile.Item[SharedConstants.Name]);
                                    //            photo.Description = Convert.ToString(folderFile.Item[SharedConstants.Description]);
                                    //            photo.Created = Convert.ToDateTime(folderFile.Item[SharedConstants.Created]);
                                    //            photo.PictureThumbnailURL = Convert.ToString(folderFile.Item["Thumbnail URL"]);
                                    //            photo.PictureURL = Convert.ToString(folderFile.Item["EncodedAbsUrl"]);

                                    //            galleryLst.Add(photo);
                                    //        }
                                    //    }
                                    //}



                                    //SPFolder albumfolder = oWeb.GetFolder(category);
                                    //SPQuery query = new SPQuery();
                                    //SPFolder _Folder = lstPhotos.Folders;//.RootFolder;
                                    //oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    //OLD code
                                    //SPListItemCollection lstItems = lstPhotos.GetItems(oQuery);
                                    //foreach (SPListItem lstItem in lstItems)
                                    //{
                                    //    PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                    //    photo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                    //    photo.Title = Convert.ToString(lstItem[SharedConstants.Name]);
                                    //    photo.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                    //    photo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                    //    photo.PictureThumbnailURL = Convert.ToString(lstItem["Thumbnail URL"]);
                                    //    photo.PictureURL = Convert.ToString(lstItem["EncodedAbsUrl"]);
                                    //    //test git by spadmin2
                                    //    //string ImageName = Convert.ToString(lstItem["Name"]);
                                    //    //test git by spadmin
                                    //    galleryLst.Add(photo);
                                    //}
                                }
                            }
                        }
                    }
                });

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return galleryLst;
        }

        public List<GalleryAlbumEntity> GetAllPhotoGalleryAlbums()
        {
            List<GalleryAlbumEntity> albumLst = new List<GalleryAlbumEntity>();

            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                //Get Picture Libray albums
                                SPList lstPhotos = oWeb.Lists.TryGetList("MOJGallery");
                                if (lstPhotos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.GalleryQuery;

                                    foreach (SPListItem galeryFolder in lstPhotos.Folders)
                                    {
                                        GalleryAlbumEntity photoAlbum = new GalleryAlbumEntity();
                                        SPFolder album = oWeb.GetFolder(galeryFolder.Url);

                                        photoAlbum.Title = album.Name;
                                        //photoAlbum.Created = Convert.ToDateTime(album.Item["FolderDate"]);
                                        photoAlbum.URL = SPContext.Current.Web.ServerRelativeUrl + "/Pages/Gallery.aspx?cat=" + album.Url;

                                        if (album.Files.Count > 0)
                                            photoAlbum.PictureURL = oWeb.Url + "/" + album.Files[0].Url;
                                        else                
                                            photoAlbum.PictureURL = SharedConstants.URL_NO_IMAGE;

                                        albumLst.Add(photoAlbum);
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
            return albumLst;
        }
        # endregion
    }
}
