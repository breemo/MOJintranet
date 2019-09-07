using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MOJ.Entities;
using CommonLibrary;

namespace MOJ.DataManager
{
    public class PhotoGalleryDataManager
    {

        #region PhotoGallery
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
                                //SPList lstPhotos = oWeb.GetListFromUrl(oSite.Url + SharedConstants.PhotoGalleryListUrl);
                                
                                //Get Picture Libray albums
                                SPList lstPhotos = oWeb.Lists.TryGetList("MOJGallery");
                                //SPList lstPhotos = oWeb.Lists["MOJGallery"];
                                if (lstPhotos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.GalleryQuery;

                                    foreach (SPListItem galeryFolder in lstPhotos.Folders)
                                    {
                                        foreach (SPFile folderFile in galeryFolder.Folder.Files)
                                        {
                                            //if (folderFile.Item["isActive"] == "true")
                                            //{
                                                PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                                photo.ID = Convert.ToInt16(folderFile.Item[SharedConstants.ID]);
                                                photo.Title = Convert.ToString(folderFile.Item[SharedConstants.Name]);
                                                photo.Description = Convert.ToString(folderFile.Item[SharedConstants.Description]);
                                                photo.Created = Convert.ToDateTime(folderFile.Item[SharedConstants.Created]);
                                                photo.PictureThumbnailURL = Convert.ToString(folderFile.Item["Thumbnail URL"]);
                                                photo.PictureURL = Convert.ToString(folderFile.Item["EncodedAbsUrl"]);

                                                galleryLst.Add(photo);
                                            //}
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

        # endregion
    }
}
