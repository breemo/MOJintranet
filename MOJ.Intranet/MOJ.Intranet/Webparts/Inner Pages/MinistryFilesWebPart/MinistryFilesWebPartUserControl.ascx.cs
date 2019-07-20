using CommonLibrary;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.MinistryFilesWebPart
{
    public partial class MinistryFilesWebPartUserControl : UserControl
    {
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
                BindData();
        }
        private void BindData()
        {
            try
            {
                List<MinistryFilesEntity> Books = new MinistryFiles().GetMinistryFilesData();
                
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = Books;
                pgitems.AllowPaging = true;

                //Control page size from here 
                pgitems.PageSize = 12;
                pgitems.CurrentPageIndex = PageNumber;

                if (pgitems.PageCount > 1)
                {
                    rptPaging.Visible = true;
                    ArrayList pages = new ArrayList();
                    for (int i = 0; i <= pgitems.PageCount - 1; i++)
                    {
                        pages.Add((i + 1).ToString());
                    }
                    rptPaging.DataSource = pages;
                    rptPaging.DataBind();
                }
                else
                {
                    rptPaging.Visible = false;
                }

                grdBookslsts.DataSource = pgitems;
                grdBookslsts.DataBind();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindData();
        }
    }
}
