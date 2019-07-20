﻿using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.LiveEventsWP
{
    public partial class LiveEventsWPUserControl : UserControl
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
                        GetLatestLiveEvent();
                        //GetCurrentMonthLiveEvent();
                        //GetArchiveLiveEvent();
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
        private void GetLatestLiveEvent()
        {
            try
            {
                List<liveEventsEntity> liveEventsLst = new liveEvents().GetLatestHomeliveVideosItems();

                lblLiveEvents.Text = "";

                foreach (liveEventsEntity item in liveEventsLst)
                {
                    //string title =LimitCharacters.Limit(item., 35);
                    //string des = LimitCharacters.Limit(item.Body, 40);
                    string siteURL = SPContext.Current.RootFolderUrl;

                    lblLiveEvents.Text +=
                    string.Format(@"
                        <div class='row'>
                            <div class='col-md-7'>
                                <div class='vidcs'>
                                    <video poster='{0}' height='400' id='myVideo'>
                                        <source src='{1}' type='video/mp4'>
                                        Your browser does not support HTML5 video.
                                    </video>
                                </div>
                                <div class='positbtns'>
                                    <a href='#' onclick='playPause()' title='Play video'
                                        class='play'></a>
                                    <a class='btnpl plbut' style='display: none;'>
                                        <span class='icon-play-circle2'></span>
                                    </a>
                                </div>
                            </div>
                            <div class='col-md-5'>
                                <div class='evenlifesection'>
                                    <h4 class='primcolor'>
                                        {2}
                                    </h4>
                                    <div class='detaiks'>
                                        {3}
                                    </div>
                                </div>
                            </div>
                        </div>", item.VideoThumbnailURL.Split(',')[0], item.VideoURL, item.Name,item.Description);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void GetCurrentMonthLiveEvent()
        {
            try
            {
                List<liveEventsEntity> liveEventsLst = new liveEvents().GetLatestHomeliveVideosItems();

                lblbLiveEventsCurrentMonth.Text = "";

                foreach (liveEventsEntity item in liveEventsLst)
                {
                    string des = LimitCharacters.Limit(item.Description, 25);
                    //string siteURL = SPContext.Current.RootFolderUrl;

                    lblbLiveEventsCurrentMonth.Text +=
                    string.Format(@"
                    <div class='col-md-3 col-sm-6'>
                        <div class='videlivebox'>
                            <div class='entry-image'>
                                <a href='{0}'>
                                    <img class='image_fade' src='{0}'
                                        alt='{1}'>
                                </a>
                                <a data-toggle='modal' class='newpos' data-target='#myModal'>
                                    <i class='icon-play1'></i>
                                </a>
                            </div>
                            <div class='entry-title'>
                                <h6>
                                    <a href='#'>{1}</a>
                                    <span class='descnesc'><a href='#'>{2}</a></span>
                                </h6>
                            </div>
                        </div>
                        <!-- Modal -->
                        <div class='modal fade bd-example-modal-lg fade' id='myModal' tabindex='-1' role='dialog'
                            aria-labelledby='exampleModalLabel' aria-hidden='true'>
                            <div class='modal-dialog modal-lg' role='document'>
                                <div class='modal-content'>
                                    <div class='modal-header'>
                                        <h5 class='modal-title' id='exampleModalLabel'>{1}</h5>
                                        <a class='close' data-dismiss='modal' aria-label='Close'>
                                            <span aria-hidden='true'>&times;</span>
                                        </a>
                                    </div>
                                    <div class='modal-body'>
                                        <div class='newvidoeo'>
                                            <video controls>
                                                <source src='{3}' type='video/mp4'>
                                                <p>Your browser does not support H.264/MP4.</p>
                                            </video>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>", item.VideoThumbnailURL, item.Name, item.Description, item.VideoURL);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void GetArchiveLiveEvent()
        {
            try
            {
                List<liveEventsEntity> liveEventsLst = new liveEvents().GetLatestHomeliveVideosItems();

                lblArchive.Text = "";

                foreach (liveEventsEntity item in liveEventsLst)
                {
                    string des = LimitCharacters.Limit(item.Description, 25);
                    //string siteURL = SPContext.Current.RootFolderUrl;

                    lblbLiveEventsCurrentMonth.Text +=
                    string.Format(@"
                    <div class='col-md-3 col-sm-6'>
                        <div class='videlivebox'>
                            <div class='entry-image'>
                                <a href='{0}' data-lightbox='image'>
                                    < img class='image_fade' src='{0}'
                                        alt='{1}'>
                                </a>
                                <a data-toggle='modal' class='newpos' data-target='#myModal'>
                                    <i class='icon-play1'></i>
                                </a>
                            </div>
                            <div class='entry-title'>
                                <h6>
                                    <a href='#'>{1}</a>
                                    <span class='descnesc'><a href='#'>{2}</a></span>
                                </h6>
                            </div>
                        </div>
                        <!-- Modal -->
                        <div class='modal fade bd-example-modal-lg fade' id='myModal' tabindex='-1' role='dialog'
                            aria-labelledby='exampleModalLabel' aria-hidden='true'>
                            <div class='modal-dialog modal-lg' role='document'>
                                <div class='modal-content'>
                                    <div class='modal-header'>
                                        <h5 class='modal-title' id='exampleModalLabel'>{1}</h5>
                                        <a class='close' data-dismiss='modal' aria-label='Close'>
                                            <span aria-hidden='true'>&times;</span>
                                        </a>
                                    </div>
                                    <div class='modal-body'>
                                        <div class='newvidoeo'>
                                            <video controls>
                                                <source src='{3}' type='video/mp4'>
                                                <p>Your browser does not support H.264/MP4.</p>
                                            </video>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>", item.VideoThumbnailURL, item.Name, item.Description, item.VideoURL);
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