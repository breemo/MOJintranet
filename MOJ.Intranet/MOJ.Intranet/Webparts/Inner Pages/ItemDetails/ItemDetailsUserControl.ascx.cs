using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.ItemDetails
{
    public partial class ItemDetailsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //    FillDetails();
        }

        //public void FillDetails()
        //{
        //    string ID = Request.QueryString["Id"].ToString();
        //    string Type = Request.QueryString["Type"].ToString();

        //    try
        //    {
        //        //lblDetails.Text = "<ul class='list_item2'>";
        //        lblDetails.Text = "";

        //        switch (Type.ToLower())
        //        {
        //            case "circular":
        //                {
        //                    MemosEntity memoItem = new Memos().GetMemos(Convert.ToInt32(ID));

        //                    lblDetails.Text +=
        //                        string.Format(@"<li>
        //                                            <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                                                <span >{2}</span>
        //                                                <p style='text-align: justify; font-weight:normal'>
        //                                                    </br>{1} 
        //                                                </p>  
        //                                        </li>", memoItem.MemoNumber, memoItem.Body, Convert.ToDateTime(memoItem.Date).ToString("dd-MMM-yyyy"));
        //                    break;
        //                }
        //            case "news":
        //                {
        //                    NewsEntity NewsItem = new News().GetNews(Convert.ToInt32(ID));

        //                    lblDetails.Text +=
        //                        string.Format(@"
        //                        <div class='newdetailnewdiv'>
        //                            <div class='newitemtitlediv'>
        //                                <span class='datenewitem'>{4}, {3}
        //                                </span>
        //                                <h5>{0}
        //                                </h5>
        //                            </div>

        //                            <section id='newdetailnew'>
        //                                <div class='row'>
        //                                    <div id='newsdtailsim' class='carousel slide col-md-9 col-sm-12' data-ride='carousel'>
        //                                        <div class='carousel-inner'>
        //                                            <div class='carousel-item active'>
        //                                                <div class='row'>
        //                                                    <div class='col-sm-12 '>
        //                                                        <img src='{2}' class='img-fluid  d-block ' alt='' width='100%'>
        //                                                    </div>
        //                                                </div>
        //                                            </div>
        //                                        </div>
        //                                    </div>
        //                                </div>
        //                            </section>
        //                        </div>
        //                        <div id='posts' class='small-thumbs alt'>
        //                            <div class='newsdetailsi'>
        //                            {1}
        //                            </div>

        //                        <div class='reladinfobox'>
        //                            <div class='relatednewsico'>
        //                                <h2>الأخبار متعلقة</h2>
        //                            </div>
        //                            <div id='oc-events'
        //                                 class='owl-carousel events-carousel carousel-widget'
        //                                 data-margin='20' data-nav='true' data-pagi='false'
        //                                 data-items-md='1' data-items-lg='2' data-items-xl='2'>
        //                                <div class='oc-item'>
        //                                    <div class='ievent clearfix newdscroll'>
        //                                        <div class='entry-image'>
        //                                            <a href='#'>
        //                                                <img src='images/news/01.jpg' alt='دعوة وزير العدل لحضور توقيع المعاهدة الدولية لاتفاقات التسوية للوساطة بسنغافورة'>
        //                                            </a>
        //                                        </div>
        //                                        <div class='entry-c'>
        //                                            <div class='entry-title'>
        //                                                <span class='endate'>الثلاثاء, 26 مارس 2019</span>
        //                                                <h2><a href='#'> دعوة وزير العدل لحضور توقيع المعاهدة الدولية لاتفاقات التسوية للوساطة بسنغافورة</a></h2>
        //                                            </div>
        //                                        </div>
        //                                    </div>
        //                                </div>
        //                                <div class='oc-item'>
        //                                    <div class='ievent clearfix newdscroll'>
        //                                        <div class='entry-image'>
        //                                            <a href='#' >
        //                                                <img src='images/news/04.jpg' alt='سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني'>
        //                                            </a>
        //                                        </div>
        //                                        <div class='entry-c'>
        //                                            <div class='entry-title'>
        //                                                <span class='endate'>الثلاثاء, 26 مارس 2019</span>
        //                                                <h2>
        //                                                    <a href='#'>
        //                                                        سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني
        //                                                    </a>
        //                                                </h2>
        //                                            </div>
        //                                        </div>
        //                                    </div>
        //                                </div>
        //                                <div class='oc-item'>
        //                                    <div class='ievent clearfix newdscroll'>
        //                                        <div class='entry-image'>
        //                                            <a href='#'>
        //                                                <img src='images/news/03.jpg' alt='دعوة وزير العدل لحضور توقيع المعاهدة الدولية لاتفاقات التسوية للوساطة بسنغافورة'>
        //                                            </a>
        //                                        </div>
        //                                        <div class='entry-c'>
        //                                            <div class='entry-title'>
        //                                                <span class='endate'>الثلاثاء, 26 مارس 2019</span>
        //                                                <h2><a href='#'> دعوة وزير العدل لحضور توقيع المعاهدة الدولية لاتفاقات التسوية للوساطة بسنغافورة</a></h2>
        //                                            </div>
        //                                        </div>
        //                                    </div>
        //                                </div>
        //                                <div class='oc-item'>
        //                                    <div class='ievent clearfix newdscroll'>
        //                                        <div class='entry-image'>
        //                                            <a href='#'>
        //                                                <img src='images/news/02.jpg' alt='سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني'>
        //                                            </a>
        //                                        </div>
        //                                        <div class='entry-c'>
        //                                            <div class='entry-title'>
        //                                                <span class='endate'>الثلاثاء, 26 مارس 2019</span>
        //                                                <h2>
        //                                                    <a href='#'>
        //                                                        سلطان البادي يتقدم المشاركين بمسيرة وزارة العدل في اليوم الرياضي الوطني
        //                                                    </a>
        //                                                </h2>
        //                                            </div>
        //                                        </div>
        //                                    </div>
        //                                </div>
        //                            </div>
        //                        </div>

        //                        </div>", NewsItem.Title, NewsItem.Body,NewsItem.Picture,Convert.ToDateTime(NewsItem.Date).ToString("dd MMM yyyy"), Convert.ToDateTime(NewsItem.Date).ToString("dddd"));

        //                    //lblDetails.Text += string.Format(@"
        //                    //                    <li>
        //                    //                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                    //                            <span >{3}</span>
        //                    //                            <p style='text-align: justify; font-weight:normal'>
        //                    //                                </br>{2}{1} 
        //                    //                            </p>  
        //                    //                    </li>", NewsItem.Title, NewsItem.Body,
        //                    //                    setImg(NewsItem.Picture, "news"), 
        //                    //                    Convert.ToDateTime(NewsItem.Date).ToString("dd-MMM-yyyy"));
        //                    break;
        //                }
        //            case "occasion":
        //                {
        //                    OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(ID));

        //                    lblDetails.Text +=
        //                        string.Format(@"<li>
        //                                            <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                                                <span >{2}</span>
        //                                                <p style='text-align: justify; font-weight:normal'>
        //                                                    </br>{1} 
        //                                                </p>  
        //                                        </li>", occasionItem.Title, occasionItem.Description, Convert.ToDateTime(occasionItem.Created).ToString("dd-MMM-yyyy"));
        //                    break;
        //                }
        //                //case "announcement":
        //                //    {
        //                //        AnnouncementEntity AnnouncementItem = new Announcements().GetAnnounces(Convert.ToInt32(ID));

        //                //        string imgUrl = "";
        //                //        //try
        //                //        //{
        //                //        //    imgUrl = webMain.Url + "/" + Convert.ToString(GetGlobalResourceObject("SZM", "CurrentSimbol")) + "/" + item.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[item.ID.ToString()].Files[0].Url;
        //                //        //}
        //                //        //catch { imgUrl = ""; }

        //                //        //Date
        //                //        lblDetails.Text +=
        //                //            string.Format(@"<li>
        //                //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                //                                            <span >{3}</span>
        //                //                                            <p style='text-align: justify; font-weight:normal'>
        //                //                                              </br>{2}{1} 
        //                //                                            </p>  
        //                //                                    </li>", AnnouncementItem.Title, AnnouncementItem.Body, setImg(imgUrl, "announcement"), Convert.ToDateTime(AnnouncementItem.Date).ToString("dd-MMM-yyyy"));
        //                //        break;
        //                //    }
        //                //case "calendar":
        //                //    {
        //                //        EventsEntity EventItem = new EventsCalendar().GetEvents(Convert.ToInt32(ID));

        //                //        //Date
        //                //        lblDetails.Text +=
        //                //            string.Format(@"<li>
        //                //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                //                                            <span >{2}</span>
        //                //                                            <p style='text-align: justify; font-weight:normal'>
        //                //                                              </br>{1} 
        //                //                                            </p>  
        //                //                                    </li>", EventItem.Title, EventItem.Description, Convert.ToDateTime(EventItem.EventDate).ToString("dd-MMM-yyyy"));
        //                //        break;
        //                //    }
        //                //case "p-calendar":
        //                //    {
        //                //        MyCalendarEntity EventItem = new MyCalendar().GetEvents(Convert.ToInt32(ID));

        //                //        //Date
        //                //        lblDetails.Text +=
        //                //            string.Format(@"<li>
        //                //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                //                                            <span >{2}</span>
        //                //                                            <p style='text-align: justify; font-weight:normal'>
        //                //                                              </br>{1} 
        //                //                                            </p>  
        //                //                                    </li>", EventItem.Title, EventItem.Description, Convert.ToDateTime(EventItem.EventDate).ToString("dd-MMM-yyyy"));
        //                //        break;
        //                //    }

        //                //case "press":
        //                //    {
        //                //        PressReleaseEntity PressReleaseItem = new PressRelease().GetPressRelease(Convert.ToInt32(ID));

        //                //        //Date
        //                //        lblDetails.Text +=
        //                //            string.Format(@"<li>
        //                //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
        //                //                                            <span >{2}</span>
        //                //                                            <p style='text-align: justify; font-weight:normal'>
        //                //                                              </br>{1} 
        //                //                                            </p>  
        //                //                                    </li>", PressReleaseItem.PressReleaseTitle, PressReleaseItem.PressReleaseSummary, Convert.ToDateTime(PressReleaseItem.PressReleaseDate).ToString("dd-MMM-yyyy"));
        //                //        break;
        //                //    }
        //        }

        //        //lblDetails.Text += "</ul>";
        //        lblDetails.Text += "";
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
        //    }
        //}

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
