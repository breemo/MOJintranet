using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.NewsList
{
    public partial class NewsListUserControl : UserControl
    {
        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pgng.Visible = false;
                FillRelatedNewsCarousel();
                FillRelatedNewsCarouselInner();

                for (int startYear = 2019; startYear >= 2015; startYear--)
                {
                    ddlYear.Items.Add(new ListItem(startYear.ToString(), startYear.ToString()));
                }
            }
        }
        protected void btnSrch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(ddlYear.SelectedValue);

            if (ddlMonth.SelectedValue != "0")
            {
                int month = int.Parse(ddlMonth.SelectedValue);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                FillData(year.ToString(), month.ToString(), month.ToString(), "1", daysInMonth.ToString());
            }
            else
            {
                FillData(year.ToString(), "1", "12", "1", "31");
            }
        }

        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;

            int year = int.Parse(ddlYear.SelectedValue);
            if (ddlMonth.SelectedValue != "0")
            {
                int month = int.Parse(ddlMonth.SelectedValue);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                FillData(year.ToString(), month.ToString(), month.ToString(), "1", daysInMonth.ToString());
            }
            else
            {
                FillData(year.ToString(), "1", "12", "1", "31");
            }
        }
        #endregion

        #region methods
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }
        public void FillRelatedNewsCarousel()
        {
            List<NewsEntity> NewsItem = new News().GetLast4News();
            string relatedNews = "";

            relatedNews = "<ol class='carousel-indicators'>";
            int itemIndex = 0;

            foreach (NewsEntity lstItem in NewsItem)
            {
                if (itemIndex == 0)
                    relatedNews += "<li data-target='#carouselReviews' data-slide-to='0' class='active'></li>";
                else
                    relatedNews += "<li data-target='#carouselReviews' data-slide-to='" + itemIndex + "'></li>";

                itemIndex++;
            }
            relatedNews += "</ol>";

            lblPopularNewsCarousel.Text = relatedNews;
        }
        public void FillRelatedNewsCarouselInner()
        {
            List<NewsEntity> NewsItem = new News().GetLast4News();
            string siteURL = SPContext.Current.RootFolderUrl;
            string relatedNews = "";

            relatedNews = "<div class='carousel-inner'>";
            int itemIndex = 0;

            foreach (NewsEntity lstItem in NewsItem)
            {
                relatedNews += string.Format(@"
                    <div class='carousel-item{5}'>
                        <div class='row'>
                            <div class='col-sm-6 col-md-6'>
                                <img src='{0}' class='img-fluid  d-block ' alt=''>
                            </div>
                            <div class='col-md-6 col-sm-6'>
                                <div class='newboxirwm'>
                                    <span class='datenewx'>
                                        {1}, {2}
                                    </span>
                                    <h4>
                                        {3}
                                    </h4>
                                    <p>
                                       {4}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>",
                    lstItem.Picture,
                    Convert.ToDateTime(lstItem.Created).ToString("dd MMM"),
                    Convert.ToDateTime(lstItem.Created).ToString("yyyy"),
                    lstItem.Title,
                    LimitCharacters.Limit(lstItem.Body, 120),
                    itemIndex == 0 ? " active" : "");

                itemIndex++;
            }
            relatedNews += "</div>";

            lblPopularNewsCarouselInner.Text = relatedNews;
        }
        private void FillData(string srchYear, string sMonth, string eMonth, string sDay, string eDay)
        {
            List<NewsEntity> NewsLst = new News().GetSrchNews(srchYear, sMonth, eMonth, sDay, eDay);

            if (NewsLst.Count > 0)
            {
                pgng.Visible = true;

                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = NewsLst;
                pgitems.AllowPaging = true;

                //Control page size from here 
                pgitems.PageSize = 8;
                pgitems.CurrentPageIndex = PageNumber;

                if (pgitems.PageCount > 1)
                {
                    rptPaging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                    rptPaging.DataSource = pages;
                    rptPaging.DataBind();
                }
                else
                {
                    rptPaging.Visible = false;
                }

                grdNewsLst.DataSource = pgitems;
                grdNewsLst.DataBind();
            }
            else
            {
                pgng.Visible = false;
                grdNewsLst.DataSource = NewsLst;
                grdNewsLst.DataBind();
            }
        }
        #endregion
    }
}
