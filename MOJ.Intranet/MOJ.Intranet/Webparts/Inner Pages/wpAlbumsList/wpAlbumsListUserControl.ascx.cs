using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpAlbumsList
{
    public partial class wpAlbumsListUserControl : UserControl
    {
        //public int PageNumber
        //{
        //    get
        //    {
        //        if (ViewState["PageNumber"] != null)
        //        {
        //            return Convert.ToInt32(ViewState["PageNumber"]);
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    set { ViewState["PageNumber"] = value; }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindData();
        }
        //protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        //{
        //    PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        //    BindData();
        //}

        private void BindData()
        {
            lblHead.Visible = true;

            try
            {
                List<GalleryAlbumEntity> AlbumsLst = new PhotoGallery().GetAllPhotoGalleryAlbums();
                lblDrawItems.Text = "";

                foreach (GalleryAlbumEntity item in AlbumsLst) //check all items
                {
                    lblDrawItems.Text +=
                    string.Format(@"<div class='col-md-3 col-sm-6'>
                                        <div class='videlivebox' data-lightbox='gallery'>
                                            <div class='entry-image'>
                                                <a href='#'>
                                                    <img class='image_fade' src='{2}'
                                                         alt='{1}'>
                                                    <div class='hoveroverlaynew'>
                                                        <div class='insidehovwrbew'>
                                                            <span class='icon-line-stack-2'></span>
                                                        </div>
                                                    </div>
                                                </a>
                                                <a data-toggle='modal' class='newpos' data-target='#myModal9'>
                                                </a>
                                            </div>
                                            <div class='entry-title'>
                                                <h6>
                                                    <a href='{0}'>{1}</a>
                                                </h6>
                                            </div>
                                        </div>
                                    </div>", item.URL, item.Title, item.PictureURL);
                }

                //PagedDataSource pgitems = new PagedDataSource();
                //pgitems.DataSource = AlbumsLst;
                //pgitems.AllowPaging = true;

                ////Control page size from here 
                //pgitems.PageSize = 8;
                //pgitems.CurrentPageIndex = PageNumber;

                //if (pgitems.PageCount > 1)
                //{
                //    rptPaging.Visible = true;
                //    ArrayList pages = new ArrayList();
                //    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                //    {
                //        pages.Add((i + 1).ToString());
                //    }
                //    rptPaging.DataSource = pages;
                //    rptPaging.DataBind();
                //}
                //else
                //{
                //    pgng.Visible = false;
                //    rptPaging.Visible = false;
                //    lblHead.Visible = false;
                //}

                //grdMemosLst.DataSource = pgitems;
                //grdMemosLst.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
