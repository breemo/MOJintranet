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
            if (!Page.IsPostBack)
                FillDetails();
        }

        public void FillDetails()
        {
            string ID = Request.QueryString["Id"].ToString();
            string Type = Request.QueryString["Type"].ToString();

            try
            {
                lblDetails.Text = "<ul class='list_item2'>";

                switch (Type.ToLower())
                {
                    case "circular":
                        {
                            MemosEntity memoItem = new Memos().GetMemos(Convert.ToInt32(ID));

                            lblDetails.Text +=
                                string.Format(@"<li>
                                                    <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                        <span >{2}</span>
                                                        <p style='text-align: justify; font-weight:normal'>
                                                            </br>{1} 
                                                        </p>  
                                                </li>", memoItem.MemoNumber, memoItem.Body, Convert.ToDateTime(memoItem.Date).ToString("dd-MMM-yyyy"));
                            break;
                        }
                    case "news":
                        {
                            NewsEntity NewsItem = new News().GetNews(Convert.ToInt32(ID));
                            string imgUrl = "";

                            lblDetails.Text +=
                                string.Format(@"<li>
                                                    <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                        <span >{3}</span>
                                                        <p style='text-align: justify; font-weight:normal'>
                                                            </br>{2}{1} 
                                                        </p>  
                                                </li>", NewsItem.Title, NewsItem.Body, setImg(imgUrl, "news"), Convert.ToDateTime(NewsItem.Date).ToString("dd-MMM-yyyy"));
                            break;
                        }
                    case "occasion":
                        {
                            OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(ID));

                            lblDetails.Text +=
                                string.Format(@"<li>
                                                    <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                        <span >{2}</span>
                                                        <p style='text-align: justify; font-weight:normal'>
                                                            </br>{1} 
                                                        </p>  
                                                </li>", occasionItem.Title, occasionItem.Description, Convert.ToDateTime(occasionItem.Created).ToString("dd-MMM-yyyy"));
                            break;
                        }
                        //case "announcement":
                        //    {
                        //        AnnouncementEntity AnnouncementItem = new Announcements().GetAnnounces(Convert.ToInt32(ID));

                        //        string imgUrl = "";
                        //        //try
                        //        //{
                        //        //    imgUrl = webMain.Url + "/" + Convert.ToString(GetGlobalResourceObject("SZM", "CurrentSimbol")) + "/" + item.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[item.ID.ToString()].Files[0].Url;
                        //        //}
                        //        //catch { imgUrl = ""; }

                        //        //Date
                        //        lblDetails.Text +=
                        //            string.Format(@"<li>
                        //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                        //                                            <span >{3}</span>
                        //                                            <p style='text-align: justify; font-weight:normal'>
                        //                                              </br>{2}{1} 
                        //                                            </p>  
                        //                                    </li>", AnnouncementItem.Title, AnnouncementItem.Body, setImg(imgUrl, "announcement"), Convert.ToDateTime(AnnouncementItem.Date).ToString("dd-MMM-yyyy"));
                        //        break;
                        //    }
                        //case "calendar":
                        //    {
                        //        EventsEntity EventItem = new EventsCalendar().GetEvents(Convert.ToInt32(ID));

                        //        //Date
                        //        lblDetails.Text +=
                        //            string.Format(@"<li>
                        //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                        //                                            <span >{2}</span>
                        //                                            <p style='text-align: justify; font-weight:normal'>
                        //                                              </br>{1} 
                        //                                            </p>  
                        //                                    </li>", EventItem.Title, EventItem.Description, Convert.ToDateTime(EventItem.EventDate).ToString("dd-MMM-yyyy"));
                        //        break;
                        //    }
                        //case "p-calendar":
                        //    {
                        //        MyCalendarEntity EventItem = new MyCalendar().GetEvents(Convert.ToInt32(ID));

                        //        //Date
                        //        lblDetails.Text +=
                        //            string.Format(@"<li>
                        //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                        //                                            <span >{2}</span>
                        //                                            <p style='text-align: justify; font-weight:normal'>
                        //                                              </br>{1} 
                        //                                            </p>  
                        //                                    </li>", EventItem.Title, EventItem.Description, Convert.ToDateTime(EventItem.EventDate).ToString("dd-MMM-yyyy"));
                        //        break;
                        //    }

                        //case "press":
                        //    {
                        //        PressReleaseEntity PressReleaseItem = new PressRelease().GetPressRelease(Convert.ToInt32(ID));

                        //        //Date
                        //        lblDetails.Text +=
                        //            string.Format(@"<li>
                        //                                        <h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                        //                                            <span >{2}</span>
                        //                                            <p style='text-align: justify; font-weight:normal'>
                        //                                              </br>{1} 
                        //                                            </p>  
                        //                                    </li>", PressReleaseItem.PressReleaseTitle, PressReleaseItem.PressReleaseSummary, Convert.ToDateTime(PressReleaseItem.PressReleaseDate).ToString("dd-MMM-yyyy"));
                        //        break;
                        //    }
                }

                lblDetails.Text += "</ul>";
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
