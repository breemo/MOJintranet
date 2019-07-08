using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.HomeGalary
{
    public partial class HomeGalaryUserControl : UserControl
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        //lnkDetails.HRef = "/" + Convert.ToString(GetGlobalResourceObject("MOJ", "Simpol")) + "/Pages/NewsDetails.aspx";
                        BindData();
                    }

                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }

        #endregion Events

        #region Methods
        private void BindData()
        {
            try
            {
                List<PhotoGalleryEntity> PhotosLst = new PhotoGallery().GetAllActivePhotos();

                lblDrawItems.Text = "";

                foreach (PhotoGalleryEntity item in PhotosLst) //check all items
                {
                    //string title =SP.Common.LimitCharacters.Limit(item.Title, 35);
                    //string des = LimitCharacters.Limit(item.Description, 120);

                    lblDrawItems.Text +=
                    string.Format(@"<li>
                                        <a href='{2}' data-lightbox='gallery-item'>
                                            <img src='{0}' alt='{1}' class='mCS_img_loaded'>
                                            <div class='overlay'>
                                                <div class='overlay-wrap'><i class='icon-line-plus'></i></div>
                                            </div>
                                        </a>
                                    </li>", item.PictureThumbnailURL, item.Title,item.PictureURL);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        #endregion Methods
    }
}
