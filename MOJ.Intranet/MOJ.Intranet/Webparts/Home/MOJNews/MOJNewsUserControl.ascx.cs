using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using SP.Common;

namespace MOJ.Intranet.Webparts.Home.MOJNews
{
    public partial class MOJNewsUserControl : UserControl
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
                SPSite oSite = new SPSite(SPContext.Current.Site.Url);
                SPWeb oWeb = oSite.OpenWeb(SPContext.Current.Web.ServerRelativeUrl);

                List<NewsEntity> NewsLst = new News().GetLast4News();

                lblDrawItems.Text = "";

                foreach (NewsEntity item in NewsLst) //check all items
                {
                    string title = Limit(item.Title, 35);
                    string des = Limit(item.Body, 70);

                    lblDrawItems.Text +=
                    string.Format(@"
                    <div class='newsitem'>
                        <div class='newsbox'>
                            <p class='date'>
                                {0}
                            </p>
                            <div class='imgdi'>
                                <img src='{1}' class='img-fluid'/>
                            </div>
                            <div class='descipt'>
                                {2}
                            </div>
                            <div class='morebtn'>
                                <a href = '#' class='slide newmorebuttoncss arrow'>{3}
                                  </a>
                            </div>
                        </div>
                    </div>", Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"), item.Picture, des, "المزيد");


               //     lblDrawItems.Text +=
               //         string.Format(@"<div class='news2'>
               //                           <div class='news_img'><img src='{0}' align='Youth' style='width:95px; height:65px' /></div>
               //                             <div class='news_content' style='width:75%; max-width:75%; font-family:Tahoma !important'>
               //                             <a onclick='ShowNewsDetail(" + item.ID + @")' href='#'><h2>{1}</h2></a>
											    //<p style='font-family:Tahoma !important'><span> {3} | </span>{2}</p>
               //                             </div><!-- end news_content -->
               //                             <div class='clear'></div>
               //                         </div><!-- end news -->"
               //                                     , item.Picture, title, des, Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"));
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        public static string Limit(object Desc, int length)
        {
            return SP.Common.LimitCharacters.Limit(Desc, length);
        }
        #endregion Methods
    }
}
