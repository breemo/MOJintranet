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

namespace MOJ.Intranet.Webparts.My_Services.MyRequestsWP
{
    public partial class MyRequestsWPUserControl : SiteUI
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetStatus();
                BindData();
                
               

            }
        }

        private void GetStatus()
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb oWeb = oSite.RootWeb)
                        {
                            if (oWeb != null)
                            {
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MyRequestsUrl);
                                if (lst != null)
                                {
                                    List<ListItem> items = new List<ListItem>();
                                    items.Add(new ListItem("",""));

                                    if (languageCode == "ar")
                                    {
                                        SPFieldChoice PlaceChoice = (SPFieldChoice)lst.Fields["StatusAr"]; 
                                        for (int i = 0; i < PlaceChoice.Choices.Count; i++)
                                        {
                                            items.Add(new ListItem(PlaceChoice.Choices[i].ToString(), PlaceChoice.Choices[i].ToString()));
                                          
                                        }
                                    }
                                    else
                                    {
                                        SPFieldChoice PlaceChoice = (SPFieldChoice)lst.Fields["StatusEn"];
                                        for (int i = 0; i < PlaceChoice.Choices.Count; i++)
                                        {
                                            items.Add(new ListItem(PlaceChoice.Choices[i].ToString(), PlaceChoice.Choices[i].ToString()));

                                        }
                                    }
                                    DDResult.Items.AddRange(items.ToArray());


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



            public void HeaderRowG()
        {
            string RequestNumber = SPUtility.GetLocalizedString("$Resources: RequestNumber", "Resource", SPContext.Current.Web.Language);
            string ServiceType = SPUtility.GetLocalizedString("$Resources: ServiceType", "Resource", SPContext.Current.Web.Language);
            string AssignTo = SPUtility.GetLocalizedString("$Resources: AssignTo", "Resource", SPContext.Current.Web.Language);
            string Result = SPUtility.GetLocalizedString("$Resources: Result", "Resource", SPContext.Current.Web.Language); ;
            string TaskDate = SPUtility.GetLocalizedString("$Resources: RequestDate", "Resource", SPContext.Current.Web.Language);
            string Show = SPUtility.GetLocalizedString("$Resources: Show", "Resource", SPContext.Current.Web.Language);
                       GridViewRow row2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = RequestNumber;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = ServiceType;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Result;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = TaskDate;
            row2.Controls.Add(cell2);
            cell2 = new TableHeaderCell();
            cell2.Text = Show;
            row2.Controls.Add(cell2);
            row2.BackColor = ColorTranslator.FromHtml("#bd995d");
            grdMyAccomplishedTasks.HeaderRow.Parent.Controls.AddAt(0, row2);
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


        protected void rpt2Paging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            PageNumber2 = Convert.ToInt32(e.CommandArgument) - 1;
            BindData();
           
         
        }
        private void BindData()
        {
            if (!_isRefresh)
            {
                string RequestNumbervalue = "";
                if (!string.IsNullOrEmpty(RequestNumber.Value))
                {
                    RequestNumbervalue = Convert.ToString(RequestNumber.Value);
                }
                string Resultvalue = "";
                if (!string.IsNullOrEmpty(DDResult.SelectedValue))
                {
                     Resultvalue = Convert.ToString(DDResult.SelectedValue);
                }
               
                string fromvalue = "";
                string tovalue = "";
                if (!string.IsNullOrEmpty(from0.Value))
                {
                    DateTime sDate = DateTime.ParseExact(from0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    fromvalue = Convert.ToString(sDate.Year)+"-"+ Convert.ToString(sDate.Month)+"-"+ Convert.ToString(sDate.Day);
                }
                if (!string.IsNullOrEmpty(to0.Value))
                {
                    DateTime sDate = DateTime.ParseExact(to0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    tovalue = Convert.ToString(sDate.Year) + "-" + Convert.ToString(sDate.Month) + "-" + Convert.ToString(sDate.Day);
                }

                try
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    List<MyRequestsEntity> Requestsollection = new MyRequestsB().GetMyRequests(0, languageCode, RequestNumbervalue, Resultvalue, fromvalue, tovalue);
                    
                    PagedDataSource pgitems = new PagedDataSource();
                    pgitems.AllowPaging = true;
                    //Control page size from here 
                    pgitems.PageSize = 3;
                    pgitems.DataSource = Requestsollection;

                    hdnPage.Value = Convert.ToString(PageNumber2+1);
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
                    grdMyAccomplishedTasks.DataSource = pgitems;
                    grdMyAccomplishedTasks.DataBind();
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
