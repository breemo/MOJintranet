using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class PhotoGallery
    {
        public List<PhotoGalleryEntity> GetAllActivePhotos()
        {
            return new PhotoGalleryDataManager().GetAllActivePhotoGalleryHomeItems();
        }
        public List<GalleryAlbumEntity> GetAllPhotoGalleryAlbums()
        {
            return new PhotoGalleryDataManager().GetAllPhotoGalleryAlbums();
        }
    }
}
