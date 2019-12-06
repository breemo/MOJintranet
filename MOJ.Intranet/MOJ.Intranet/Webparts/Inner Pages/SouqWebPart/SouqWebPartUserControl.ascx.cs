using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.SouqWebPart
{
    public partial class SouqWebPartUserControl : SiteUI
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
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            if (PageNumber < rptPaging.Items.Count - 1)
            {
                if (PageNumber != 0)
                {
                    PageNumber -= 1;
                    BindData();
                }
            }
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            PageNumber += 1;
            BindData();
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
                                    //ddlCategorySubmit
                                    SPFieldMultiChoice CategoryChoice = (SPFieldMultiChoice)lst.Fields["Category"];
                                    ddlCategorySubmit.Items.Insert(0, new ListItem(SPUtility.GetLocalizedString("$Resources: ddlSelect", "Resource", SPContext.Current.Web.Language), ""));
                                    for (int i = 0; i < CategoryChoice.Choices.Count; i++)
                                    {
                                        string[] CatValue = CategoryChoice.Choices[i].ToString().Split('\\');

                                        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                                        string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                                        if (languageCode == "ar")
                                        {
                                            cbCategory.Items.Add(CatValue[1].ToString());
                                            ddlCategorySubmit.Items.Add(CategoryChoice.Choices[i].ToString());
                                        }
                                        else
                                        {
                                            cbCategory.Items.Add(CatValue[0].ToString());
                                            ddlCategorySubmit.Items.Add(CategoryChoice.Choices[i].ToString());
                                        }

                                    }
                                }
                            }
                            //item.Attributes.Add("class", "checkbox-box");
                            //item.Text = "<span class=\"checkbox-box\">" + item.Value + "</span>";
                            //chklstFSOptions.Items.Add(item);
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
            if (cbCategory.SelectedIndex == -1)
            {
                BindData();
            }
            else
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

        protected void btnSubmitNewItem_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                SouqEntity itemSumbit = new SouqEntity();

                itemSumbit.Title = txtTitle.Value;
                itemSumbit.Category = ddlCategorySubmit.SelectedValue.ToString();
                itemSumbit.Price = Convert.ToInt32(txtprice.Value);
                itemSumbit.Description = exampleFormControlTextarea1.Value;
                itemSumbit.ContactNumber = txtContactNum.Value;
                Stream fs;
                if (fu.HasFile)
                {
                    fs = fu.PostedFile.InputStream;
                    itemSumbit.Photo = fs;
                    itemSumbit.PhotoPath = fu.PostedFile.FileName;
                }
                else
                    fs = null;

                Souq souq = new Souq();
                bool isSaved = souq.SaveUpdate(itemSumbit);
                if (isSaved == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "HidePopup", "$('#MyPopup').modal('hide')", true);
                }
            }
        }
    }
}
