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

namespace MOJ.Intranet.Webparts.Home.EventsCorner
{
    public partial class EventsCornerUserControl : UserControl
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
                List<OccasionsEntity> OccasionsLst = new Occasions().GetOccasionsHome();

                lblDrawItems.Text = "";

                foreach (OccasionsEntity item in OccasionsLst) //check all items
                {
                    string title =LimitCharacters.Limit(item.Title, 35);
                    string des = LimitCharacters.Limit(item.Description, 40);

                    lblDrawItems.Text +=
                    string.Format(@"<div class='col-md-4 col-sm-12'>
                                        <div class='eventbox'>
                                            <div class='eventopbox'>
                                                <div class='Evbetdatebox'>
                                                    <span>{0}<font>{1}</font></span>
                                                </div>
                                                <div class='EventboxTitle'>{2}</div>
                                            </div>
                                            <div class='eventmorebutton'>
                                                <div class='morebtn2'>
                                                    <a href='Details.aspx?id={3}&type=occasion' class='slide newmorebuttoncss arrow'>{4}</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>", Convert.ToDateTime(item.Created).ToString("MMMM"), Convert.ToDateTime(item.Created).Month, title,item.ID, SPUtility.GetLocalizedString("$Resources: more", "Resource", SPContext.Current.Web.Language));
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
