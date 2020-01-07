using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.StickyNotes
{
    public partial class StickyNotesUserControl : SiteUI
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
                        //SPWeb theSite = SPControl.GetContextWeb(Context);
                        //SPUser theUser = theSite.CurrentUser;
                        //string strUserName = theUser.LoginName;
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
                                <div class='STICKB STCIKEY_C" + Count + @" alert  fade show' role='alert'>
                                    <p>
                                        {0}:{1} {2}
                                    </p>
                                    <button type = 'button' onclick='updateListItem(" + item.ID + @")' class='close xClose' data-dismiss='alert' aria-label='Close'>
                                        <span aria-hidden='true'>×</span>
                                    </button>
                                </div>
                            </div>", SPUtility.GetLocalizedString("$Resources: remind", "Resource", SPContext.Current.Web.Language), item.Title, Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"));

                }
            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        #endregion

        protected void btnSubmitNewItem_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                try
                {
                    StickyNotesEntities itemSumbit = new StickyNotesEntities();
                    itemSumbit.Title = txtTitleAr.Value;
                    //itemSumbit.TitleEn = txtTitleEn.Value;
                    DateTime sDate = DateTime.ParseExact(txtDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    itemSumbit.Date = sDate;

                    StickyNote SN = new StickyNote();
                    bool isSaved = SN.SaveUpdate(itemSumbit);

                    if (isSaved == true)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#MyPopup').modal('hide')", true);
                        BindData();
                        txtTitleAr.Value = "";
                        txtDate.Value = "";
                    }


                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
    }
}
