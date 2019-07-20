using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.NewsList
{
    public partial class NewsListUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillRelatedNewsCarousel();
                FillRelatedNewsCarouselInner();
            }
        }

        public void FillRelatedNewsCarousel()
        {
            List<NewsEntity> NewsItem = new News().GetLast4News();
            string relatedNews = "";


                relatedNews = "<ol class='carousel-indicators'>";
                int itemIndex = 0;

                foreach (NewsEntity lstItem in NewsItem)
                {
                    if(itemIndex == 0)
                    relatedNews +="<li data-target='#carouselReviews' data-slide-to='0' class='active'></li>"; 

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
                    Convert.ToDateTime(lstItem.Date).ToString("dd MMM"),
                    Convert.ToDateTime(lstItem.Date).ToString("yyyy"),
                    lstItem.Title,
                    LimitCharacters.Limit(lstItem.Body, 120),
                    itemIndex == 0 ? " active" : "");

                itemIndex++;
            }
            relatedNews += "</div>";

            lblPopularNewsCarouselInner.Text = relatedNews;
        }

        protected void btnSrch_Click(object sender, EventArgs e)
        {
            int year = int.Parse(slctYear.Value);

            if (!string.IsNullOrEmpty(slctMonth.Value))
            {
                int month = int.Parse(slctMonth.Value);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                FillData(year.ToString(), month.ToString(), month.ToString(), "1", daysInMonth.ToString());
            }
            else
            {
                FillData(year.ToString(), "1", "12", "1", "31");
            }
        }

        private void FillData(string srchYear, string sMonth, string eMonth, string sDay,string eDay)
        {
            List<NewsEntity> NewsLst = new News().GetSrchNews(srchYear, sMonth,eMonth,sDay,eDay);

            //grdMemosLst.DataSource = NewsLst;
            //grdMemosLst.DataBind();
        }
    }
}
