﻿using MOJ.Business;
using MOJ.Entities;
using SP.Common;
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
                    string des = SP.Common.LimitCharacters.Limit(item.Body, 40);

                    lblDrawItems.Text +=
                    string.Format(@"
                                    <div class='itemboxc'>
                                        < div class='itenewfo'>
                                            <h5>
                                                <a href='{0}'>{1}
                                                </a>
                                            </h5>
                                            <span class='newdatefo'>{2}
                                            </span>
                                        </div>
                                    </div>","#", des, Convert.ToDateTime(item.Date).ToString("dd-MMM-yyyy"));
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
