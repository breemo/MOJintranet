using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.HomeMemos
{
    public partial class HomeMemosUserControl : UserControl
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
                List<MemosEntity> MemosLst = new Memos().GetMemosHome();

                lblDrawItems.Text = "";

                foreach (MemosEntity item in MemosLst) //check all items
                {
                    //string title =SP.Common.LimitCharacters.Limit(item.Title, 35);
                    string des = LimitCharacters.Limit(item.Body, 120);

                    lblDrawItems.Text +=
                    string.Format(@"
                                    <div class='itemboxc'>
                                        <div class='itenewfo'>
                                            <h5>
                                                <a href='Details.aspx?id={0}&type=circular'>{1}
                                                </a>
                                            </h5>
                                            <span class='newdatefo'>{2}
                                            </span>
                                        </div>
                                    </div>", item.ID, des, Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"));
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
