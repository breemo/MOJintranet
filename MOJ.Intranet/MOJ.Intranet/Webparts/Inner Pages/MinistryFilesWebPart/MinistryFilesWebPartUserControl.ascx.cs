using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            if (!Page.IsPostBack)
            {
                GetCategory();
                BindData();
            }
        }
        private void GetCategory()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MinistryFilesListUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice CategoryChoice = (SPFieldChoice)lst.Fields["Category"];
                                    ddlCategory.Items.Insert(0, new ListItem(SPUtility.GetLocalizedString("$Resources: ddlSelect", "Resource", SPContext.Current.Web.Language), ""));
                                    for (int i = 0; i < CategoryChoice.Choices.Count; i++)
                                    {
                                        ddlCategory.Items.Add(CategoryChoice.Choices[i].ToString());
                                    }
                                }
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
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
                hdnPage.Value = Convert.ToString(PageNumber + 1);
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
                    PaginUI.Visible = false;
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
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            if (PageNumber != 0)
            {
                PageNumber -= 1;
                BindData();
            }
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            if (PageNumber < rptPaging.Items.Count - 1)
            {
                PageNumber += 1;
                BindData();
            }

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            FillData(txtSearchBookName.Value, txtSearchCreatedby.Value, ddlCategory.SelectedValue.ToString(), txtAuthor.Value);
        }
        private void FillData(string BookName, string Created, string Category, string Author)
        {
            List<MinistryFilesEntity> Books = new MinistryFiles().GetMinistryFilesSearch(BookName, Created, Category, Author);
            if (Books.Count != 0)
            {
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
                    PaginUI.Visible = false;
                }
                grdBookslsts.DataSource = pgitems;
                grdBookslsts.DataBind();
            }
            else
            {
                rptPaging.Visible = false;
                PaginUI.Visible = false;

                DataTable dt = new DataTable();
                grdBookslsts.DataSource = dt;
                grdBookslsts.DataBind();

                Control FooterTemplate = grdBookslsts.Controls[grdBookslsts.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCategory.SelectedIndex = 0;
            txtAuthor.Value = "";
            txtSearchBookName.Value = "";
            txtSearchCreatedby.Value = "";
            BindData();
        }
    }
}
