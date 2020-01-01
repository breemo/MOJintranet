using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.HeldCouncilWP
{
    public partial class HeldCouncilWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetLookup();
                BindData();
            }
        }
        public int PageNumber2
        {
            get
            {
                if (ViewState["PageNumber2"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber2"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber2"] = value; }
        }

        private void GetLookup()
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.knowledgeCouncilUrl);
                                if (lst != null)
                                {
                                    List<ListItem> items = new List<ListItem>();
                                    items.Add(new ListItem("", ""));
                                    List<ListItem> items2 = new List<ListItem>();
                                    items2.Add(new ListItem("", ""));
                                    SPQuery qry1 = new SPQuery();
                                        string camlquery1 = "<Where><Eq><FieldRef Name='Status'></FieldRef><Value Type='Text'>Approved</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                        qry1.Query = camlquery1;
                                        SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                        foreach (SPListItem Item in listItemsCollection1)
                                        {                                   
                                        items.Add(new ListItem(Convert.ToString(Item["CouncilNo"]), Convert.ToString(Item["CouncilNo"])));
                                        items2.Add(new ListItem(Convert.ToString(Item["CouncilTopic"]), Convert.ToString(Item["CouncilTopic"])));

                                    }
                                    DropDownCouncilNo.Items.AddRange(items.ToArray());
                                    DropDownCouncilTopic.Items.AddRange(items2.ToArray());
                                }
                                SPList lst2 = oWeb.GetListFromUrl(oSite.Url + SharedConstants.DepartmentsUrl);
                                if (lst2 != null)
                                {
                                    List<ListItem> items = new List<ListItem>();
                                    items.Add(new ListItem("", ""));
                                    
                                    SPQuery qry1 = new SPQuery();
                                    string camlquery1 = "<Where></Where><OrderBy><FieldRef Name='ID' Ascending='true' /></OrderBy>";
                                    qry1.Query = camlquery1;
                                    SPListItemCollection listItemsCollection1 = lst2.GetItems(qry1);
                                    foreach (SPListItem Item in listItemsCollection1)
                                    {
                                        items.Add(new ListItem(Convert.ToString(Item["Title"]), Convert.ToString(Item["Title"])));
                                      
                                    }
                                    DropDownDepartment.Items.AddRange(items.ToArray());
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                PageNumber2 = 0;
                BindData();

            }
        }
        protected void rpt2Paging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
            BindData();


        }

        public void HeaderRowG()
        {
            string CouncilNo = SPUtility.GetLocalizedString("$Resources: CouncilNo", "Resource", SPContext.Current.Web.Language);
            string Department = SPUtility.GetLocalizedString("$Resources: Department", "Resource", SPContext.Current.Web.Language);
            string CouncilTopic = SPUtility.GetLocalizedString("$Resources: CouncilTopic", "Resource", SPContext.Current.Web.Language);
            string CouncilDate = SPUtility.GetLocalizedString("$Resources: CouncilDate", "Resource", SPContext.Current.Web.Language); ;
            string Lecturer = SPUtility.GetLocalizedString("$Resources: Lecturer", "Resource", SPContext.Current.Web.Language);
            string JoiningConditions = SPUtility.GetLocalizedString("$Resources: JoiningConditions", "Resource", SPContext.Current.Web.Language);
            string Details = SPUtility.GetLocalizedString("$Resources: Details", "Resource", SPContext.Current.Web.Language);
            GridViewRow row2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = CouncilNo;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Department;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = CouncilTopic;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = CouncilDate;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Lecturer;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = JoiningConditions;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Details;
            row2.Controls.Add(cell2);           
            row2.CssClass = "firstrow";
            grdHeldCouncil.HeaderRow.Parent.Controls.AddAt(0, row2);
        }

        private void BindData()
        {
            if (!_isRefresh)
            {
                string CouncilTopicvalue = "";
                if (!string.IsNullOrEmpty(DropDownCouncilTopic.SelectedValue))
                {
                    CouncilTopicvalue = Convert.ToString(DropDownCouncilTopic.SelectedValue);
                }
                string CouncilNovalue = "";
                if (!string.IsNullOrEmpty(DropDownCouncilNo.SelectedValue))
                {
                    CouncilNovalue = Convert.ToString(DropDownCouncilNo.SelectedValue);
                }

                string CouncilDatevalue = "";
                if (!string.IsNullOrEmpty(CouncilDate.Value))
                {
                    DateTime sDate = DateTime.ParseExact(CouncilDate.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    CouncilDatevalue = Convert.ToString(sDate.Year) + "-" + Convert.ToString(sDate.Month) + "-" + Convert.ToString(sDate.Day);
                }
                string Departmentvalue = "";
                if (!string.IsNullOrEmpty(DropDownDepartment.SelectedValue))
                {
                    Departmentvalue = Convert.ToString(DropDownDepartment.SelectedValue);
                }
                try
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    List<knowledgeCouncilEntity> Requestsollection = new knowledgeCouncil().GetknowledgeCouncil(0, CouncilTopicvalue, CouncilNovalue, CouncilDatevalue, Departmentvalue);

                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.AllowPaging = true;
                    //Control page size from here 
                    pgitems.PageSize = 10;
                    pgitems.DataSource = Requestsollection;
                    hdnPage.Value = Convert.ToString(PageNumber2 + 1);
                    pgitems.CurrentPageIndex = PageNumber2;

                    if (pgitems.PageCount > 1)
                    {
                        pgng2.Visible = true;
                        rpt2Paging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i <= pgitems.PageCount - 1; i++)
                        {
                            pages.Add((i + 1).ToString());
                        }
                        rpt2Paging.DataSource = pages;
                        rpt2Paging.DataBind();
                    }
                    else
                    {
                        pgng2.Visible = false;
                        rpt2Paging.Visible = false;
                    }
                    grdHeldCouncil.DataSource = pgitems;
                    grdHeldCouncil.DataBind();
                    if (Requestsollection.Count > 0)
                    {
                        HeaderRowG();
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
