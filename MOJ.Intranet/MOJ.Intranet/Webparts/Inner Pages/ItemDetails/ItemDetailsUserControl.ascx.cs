using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.ItemDetails
{
    public partial class ItemDetailsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillDetails();
        }

        public string FillRelatedNews(string title)
        {
            List<NewsEntity> NewsItem = new News().GetNews(title);
            string relatedNews = "";

            if (NewsItem.Count > 0)
            {
                relatedNews +=
               string.Format(@"
                                <div class='reladinfobox'>
                                    <div class='relatednewsico'>
                                        <h2>{0}</h2>
                                    </div>
                                    <div id='oc-events'
                                         class='owl-carousel events-carousel carousel-widget'
                                         data-margin='20' data-nav='true' data-pagi='false'
                                         data-items-md='1' data-items-lg='2' data-items-xl='2'>", 
                                         SPUtility.GetLocalizedString("$Resources: HeadRelatedNews", "Resource", SPContext.Current.Web.Language));

                foreach (NewsEntity lstItem in NewsItem)
                {
                    if (lstItem.ID.ToString() != Request.QueryString["Id"].ToString())
                    {
                        string des = LimitCharacters.Limit(lstItem.Body, 40);
                        string siteURL = SPContext.Current.RootFolderUrl;

                        relatedNews +=
                        string.Format(@"
                    <div class='oc-item'>
                        <div class='ievent clearfix newdscroll'>
                            <div class='entry-image'>
                                <a href='#'>
                                    <img src='{0}' alt='{1}'>
                                </a>
                            </div>
                            <div class='entry-c'>
                                <div class='entry-title'>
                                    <span class='endate'>{3}, {2}</span>
                                    <h2><a href='{5}/Details.aspx?id={4}&type=news'>{1}</a></h2>
                                </div>
                            </div>
                        </div>
                    </div>",
                         lstItem.Picture,
                         LimitCharacters.Limit(lstItem.Title, 40),
                         Convert.ToDateTime(lstItem.Date).ToString("dd MMM yyyy"),
                         Convert.ToDateTime(lstItem.Date).ToString("dddd"),
                         lstItem.ID, siteURL);
                    }
                }
                relatedNews += "</div></div>";
            }

            return relatedNews;
        }
        public void FillDetails()
        {
            string ID = Request.QueryString["Sid"].ToString();
            string Type = Request.QueryString["Type"].ToString();

            try
            {
                lblDetails.Text = "";

                switch (Type.ToLower())
                {
                    case "circular":
                        {
                            lblHead.Text = SPUtility.GetLocalizedString("$Resources: HeadCirculars", "Resource", SPContext.Current.Web.Language);
                            MemosEntity memoItem = new Memos().GetMemos(Convert.ToInt32(ID));

                            lblDetails.Text +=
                                string.Format(@"<h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                <span >{2}</span>
                                                <p style='text-align: justify; font-weight:normal'>
                                                    </br>{1} 
                                                </p>", memoItem.MemoNumber, memoItem.Body, Convert.ToDateTime(memoItem.Date).ToString("dd-MMM-yyyy"));

                            if (memoItem.AttachmentsInfo != "#")
                            {
                                lblDetails.Text +=
                                        string.Format(@"<a href='{0}' target='_blank'>
                                                            <img src='{1}' width='7%'/>
                                                        </a>", memoItem.AttachmentsInfo, memoItem.AttachmentPicture);
                            }

                            break;
                        }
                    case "news":
                        {
                            lblHead.Text = SPUtility.GetLocalizedString("$Resources: HeadNews", "Resource", SPContext.Current.Web.Language);
                            NewsEntity NewsItem = new News().GetNews(Convert.ToInt32(ID));

                            lblDetails.Text +=
                                string.Format(@"
                                <div class='newdetailnewdiv'>
                                    <div class='newitemtitlediv'>
                                        <span class='datenewitem'>{4}, {3}
                                        </span>
                                        <h5>{0}
                                        </h5>
                                    </div>

                                    <section id='newdetailnew'>
                                        <div class='row'>
                                            <div id='newsdtailsim' class='carousel slide col-md-9 col-sm-12' data-ride='carousel'>
                                                <div class='carousel-inner'>
                                                    <div class='carousel-item active'>
                                                        <div class='row'>
                                                            <div class='col-sm-12 '>
                                                                <img src='{2}' class='img-fluid  d-block ' alt='' width='100%'>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                                <div id='posts' class='small-thumbs alt'>
                                    <div class='newsdetailsi'>
                                    {1}
                                    </div>
                                    {5}
                                </div>", 
                                NewsItem.Title, 
                                NewsItem.Body, 
                                NewsItem.Picture, 
                                Convert.ToDateTime(NewsItem.Date).ToString("dd MMM yyyy"), 
                                Convert.ToDateTime(NewsItem.Date).ToString("dddd"),
                                FillRelatedNews(NewsItem.Title));

                            break;
                        }
                    //case "occasion":
                    //    {
                    //        lblHead.Text = SPUtility.GetLocalizedString("$Resources: HeadEvents", "Resource", SPContext.Current.Web.Language);
                    //        OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(ID));

                    //        lblDetails.Text +=
                    //            string.Format(@"<h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                    //                            <span >{2}</span>
                    //                            <p style='text-align: justify; font-weight:normal'>
                    //                                </br>{1} 
                    //                            </p>", occasionItem.Title, occasionItem.Description, Convert.ToDateTime(occasionItem.Created).ToString("dd-MMM-yyyy"));
                    //        break;
                    //    }
                }

                //lblDetails.Text += "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }

        private string setImg(string imgURL, string picSize)
        {
            if (!string.IsNullOrEmpty(imgURL))
            {
                if (picSize.ToLower() == "news")
                    return "<img src=" + imgURL + " alt='' width='350' height='250' class='img_brd right' />";
                else
                    return "<img src=" + imgURL + " alt='' width='350' height='250' class='img_brd right' />";
            }
            else
                return "";
        }
    }
}
