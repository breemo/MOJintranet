﻿using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.SouqWebPart
{
    public partial class SouqWebPartUserControl : UserControl
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.SouqListUrl);
                                if (lst != null)
                                {
                                    SPFieldMultiChoice CategoryChoice = (SPFieldMultiChoice)lst.Fields["Category"];
                                    for (int i = 0; i < CategoryChoice.Choices.Count; i++)
                                    {
                                        cbCategory.Items.Add(CategoryChoice.Choices[i].ToString());
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
                List<SouqEntity> Souqs = new Souq().GetSouqData();
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = Souqs;
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

                grdSouqlsts.DataSource = pgitems;
                grdSouqlsts.DataBind();
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
        protected void OnCheckBox_Changed(object sender, EventArgs e)
        {
            List<String> Categories = new List<string>();
            foreach (ListItem item in cbCategory.Items)
            {
                if (item.Selected)
                {
                    Categories.Add(item.Text);
                }
                else
                    Categories.Add(" ");
            }

            FillData(Categories[0].ToString(), Categories[1].ToString(), Categories[2].ToString(), Categories[3].ToString());
        }
        private void FillData(string Category1, string Category2, string Category3, string Category4)
        {
            List<SouqEntity> Souqs = new Souq().GetSouqDataFromCategories(Category1, Category2, Category3, Category4);
            if (Souqs.Count != 0)
            {
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = Souqs;
                pgitems.AllowPaging = true;
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
                grdSouqlsts.DataSource = pgitems;
                grdSouqlsts.DataBind();
            }
            else
            {
                rptPaging.Visible = false;
                PaginUI.Visible = false;

                DataTable dt = new DataTable();
                grdSouqlsts.DataSource = dt;
                grdSouqlsts.DataBind();

                Control FooterTemplate = grdSouqlsts.Controls[grdSouqlsts.Controls.Count - 1].Controls[0];
                FooterTemplate.FindControl("trEmpty").Visible = true;
            }
        }
    }
}