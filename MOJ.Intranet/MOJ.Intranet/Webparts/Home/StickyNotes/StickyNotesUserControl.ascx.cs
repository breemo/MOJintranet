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

namespace MOJ.Intranet.Webparts.Home.StickyNotes
{
    public partial class StickyNotesUserControl : UserControl
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
                        BindData();
                    }
                }
                catch (Exception ex)
                {

                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }

        #endregion

        #region Methods
        private void BindData()
        {
            

            try
            {
                List<StickyNotesEntities> StickyNotesLst = new StickyNote().GetStickyNotes();
                lblDrawItems.Text = "";
                int Count = 0;
                foreach (StickyNotesEntities item in StickyNotesLst)
                {
                    Count++;
                    lblDrawItems.Text +=
                        string.Format(@"
                            <div class='col-sm-4'>
                                <div class='STICKB STCIKEY_C"+ Count + @" alert  fade show' role='alert'>
                                    <p>
                                        {0}:{1} {2}
                                    </p>
                                    <button type = 'button' onclick='updateListItem(" + item.ID + @")' class='close xClose' data-dismiss='alert' aria-label='Close'>
                                        <span aria-hidden='true'>×</span>
                                    </button>
                                </div>
                            </div>", SPUtility.GetLocalizedString("$Resources: remind", "Resource", SPContext.Current.Web.Language), item.TitleAr, Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"));

                }
            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        #endregion
    }
}