using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpAlbumFiles
{
    public partial class wpAlbumFilesUserControl : UserControl
    {
        PagedDataSource adsource;
        int pos;
        string category;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.ViewState["vs"] = 0;
                    pos = (int)this.ViewState["vs"];

                    if (Request.QueryString.HasKeys() && !String.IsNullOrEmpty(Convert.ToString(Request.QueryString["cat"])))
                    {
                        category = Convert.ToString(Request.QueryString["cat"]);
                        this.ViewState["category"] = category;

                        BindPhotoGallery(category);

                        //lblTitle.Text = category.Split('/')[1].ToUpper();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void BindPhotoGallery(string category)
        {
            lblHead.Visible = true;

            try
            {
                List<GalleryAlbumEntity> AlbumsLst = new PhotoGallery().GetAllPhotoGalleryAlbums();
                lblDrawItems.Text = "";

                foreach (GalleryAlbumEntity item in AlbumsLst) //check all items
                {
                    lblDrawItems.Text +=
                    string.Format(@"
                                    <div class='col-md-3'>
                                        <div class='boxitemdivco'>
                                            <a href='{0}' data-lightbox='gallery-item'>
                                                <img src='{0}' alt='Gallery Image'>
                                                <div class='hoveroverlay'>
                                                    <div class='insidehovwr'>
                                                        <span class='icon-line-image'></span>
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>", item.PictureURL);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
