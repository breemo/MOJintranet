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
                                SPList lstPhotos = oWeb.Lists["MOJGallery"];
                                if (lstPhotos != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = SharedConstants.GalleryQuery;
                                    //oQuery.ViewFields = SharedConstants.NewsViewfields;

                                    SPListItemCollection lstItems = lstPhotos.GetItems(oQuery);
                                    foreach (SPListItem lstItem in lstItems)
                                    {
                                        PhotoGalleryEntity photo = new PhotoGalleryEntity();
                                        photo.ID = Convert.ToInt16(lstItem[SharedConstants.ID]);
                                        photo.Title = Convert.ToString(lstItem[SharedConstants.Name]);
                                        photo.Description = Convert.ToString(lstItem[SharedConstants.Description]);
                                        photo.Created = Convert.ToDateTime(lstItem[SharedConstants.Created]);
                                        photo.PictureThumbnailURL = Convert.ToString(lstItem["Thumbnail URL"]);
                                        photo.PictureURL = Convert.ToString(lstItem["EncodedAbsUrl"]);
                                        //test git by spadmin2
                                        //string ImageName = Convert.ToString(lstItem["Name"]);
                                        //test git by spadmin
                                        galleryLst.Add(photo);
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
            return galleryLst;
        }

        # endregion
    }
}
