using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Search.Query;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.GetAllEmployeeInfo
{
    public partial class GetAllEmployeeInfoUserControl : UserControl
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
                try
                {
                    #region Old Code
                    //using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    //{
                    //    using (SPWeb myweb = mySitesCollection.OpenWeb())
                    //    {
                    //        SPUser currentUser = myweb.CurrentUser;
                    //        string currentUserlogin = currentUser.LoginName;
                    //        SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                    //        UserProfileManager profileManager = new UserProfileManager(context);
                    //        UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);

                    //        if (currentProfile.GetProfileValueCollection("Pager").Count != 0)
                    //        {
                    //            ProfileValueCollectionBase EmployeeNumber = currentProfile.GetProfileValueCollection("Pager");
                    //            BindData(EmployeeNumber.ToString());
                    //        }
                    //        else
                    //        {
                    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showModalPopUp();", true);
                    //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "showModalPopUp();", true);
                    //        }


                    //    }
                    //}
                    #endregion
                    BindData();
                }
                catch (Exception ex)
                {

                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
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
        private void BindData()
        {
            try
            {
                List<EmployeeProfileEntity> Employees = new EmployeeProfileBL().GetEmployeeProfile();
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = Employees;
                pgitems.AllowPaging = true;

                //Control page size from here 
                pgitems.PageSize = 9;
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

                grdPoeplelsts.DataSource = pgitems;
                grdPoeplelsts.DataBind();

                #region Old Code
                //private void BindData(string EmployeeNumber)
                //List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().EmployeeMasterDataByEmployeeNumber(EmployeeNumber);
                //foreach (EmployeeMasterDataEntity item in EmployeeValues)
                //{
                //    //lblEmployeeNameAr.Text = item.employeeNameArabicField.ToString();
                //    //lblDepartmentAr.Text = item.departmentNameField_AR.ToString();
                //    //lblContactNo.Text = item.contactNumberField.ToString();
                //    //lblEmail.Text = item.employeeEmailField.ToString();
                //    //lblJobtitle.Text = item.positionNameField_AR.ToString();
                //}
                #endregion
                #region Old Code 2

                //using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                //{

                //    DataTable dtProfile = new DataTable();

                //    dtProfile.Columns.Add("AccountName");
                //    dtProfile.Columns.Add("WorkEmail");
                //    dtProfile.Columns.Add("Department");
                //    dtProfile.Columns.Add("JobTitle");
                //    dtProfile.Columns.Add("OfficeNumber");

                //    SPSite site = new SPSite(SPContext.Current.Site.Url);
                //    SPWeb web = site.RootWeb;
                //    SPServiceContext serverContext = SPServiceContext.GetContext(site);
                //    UserProfileManager profileManager = new UserProfileManager(serverContext);
                //    EmployeeProfileEntity Profile;
                //    DataRow dr;

                //    foreach (UserProfile _Profile in profileManager)
                //    {
                //        Profile = GetShortUserProfile(_Profile);

                //        dr = dtProfile.NewRow();
                //        dr["AccountName"] = Profile.AccountName;
                //        dr["WorkEmail"] = Profile.Email;
                //        dr["Department"] = Profile.Department;
                //        dr["JobTitle"] = Profile.JobTitle;
                //        dr["OfficeNumber"] = Profile.OfficeNumber;

                //        dtProfile.Rows.Add(dr);

                //    }


                //    DataTable dt = dtProfile.DefaultView.ToTable();

                //    grdPoeplelsts.DataSource = dt;
                //    grdPoeplelsts.DataBind();

                //}
                #endregion
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

        protected void btnNameSearch_Click(object sender, EventArgs e)
        {

            //CurrentUserDiv.Visible = false;

            using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
            {

                DataTable dtProfile = new DataTable();

                dtProfile.Columns.Add("AccountName");
                dtProfile.Columns.Add("WorkEmail");
                dtProfile.Columns.Add("Department");
                dtProfile.Columns.Add("JobTitle");
                dtProfile.Columns.Add("OfficeNumber");

                SPSite site = new SPSite(SPContext.Current.Site.Url);
                SPWeb web = site.RootWeb;
                SPServiceContext serverContext = SPServiceContext.GetContext(site);
                UserProfileManager profileManager = new UserProfileManager(serverContext);
                EmployeeProfileEntity Profile;
                DataRow dr;
                EmployeeProfileBL EBL = new EmployeeProfileBL();
                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = EBL.GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.WorkEmail;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;

                    dtProfile.Rows.Add(dr);

                }



                if (txtNameSearch.Value != "")
                    dtProfile.DefaultView.RowFilter = "AccountName Like '%" + txtNameSearch.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                if (dt.Rows.Count < 1)
                {
                    rptPaging.Visible = false;
                    PaginUI.Visible = false;

                    DataTable dtempty = new DataTable();
                    grdPoeplelsts.DataSource = dtempty;
                    grdPoeplelsts.DataBind();

                    Control FooterTemplate = grdPoeplelsts.Controls[grdPoeplelsts.Controls.Count - 1].Controls[0];
                    FooterTemplate.FindControl("trEmpty").Visible = true;
                }
                else
                {
                    if (dt.Rows.Count <= 9)
                    {
                        rptPaging.Visible = false;
                        PaginUI.Visible = false;
                    }


                    grdPoeplelsts.DataSource = dt;
                    grdPoeplelsts.DataBind();
                }
            }
        }

        protected void btnDepartmentSearch_Click(object sender, EventArgs e)
        {
            //CurrentUserDiv.Visible = false;
            using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
            {

                DataTable dtProfile = new DataTable();

                dtProfile.Columns.Add("AccountName");
                dtProfile.Columns.Add("WorkEmail");
                dtProfile.Columns.Add("Department");
                dtProfile.Columns.Add("JobTitle");
                dtProfile.Columns.Add("OfficeNumber");

                SPSite site = new SPSite(SPContext.Current.Site.Url);
                SPWeb web = site.RootWeb;
                SPServiceContext serverContext = SPServiceContext.GetContext(site);
                UserProfileManager profileManager = new UserProfileManager(serverContext);
                EmployeeProfileEntity Profile;
                EmployeeProfileBL EBL = new EmployeeProfileBL();
                DataRow dr;

                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = EBL.GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.WorkEmail;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;

                    dtProfile.Rows.Add(dr);

                }

                if (txtDepartmentSearch.Value != "")
                    dtProfile.DefaultView.RowFilter = "Department Like '%" + txtDepartmentSearch.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                if (dt.Rows.Count < 1)
                {
                    rptPaging.Visible = false;
                    PaginUI.Visible = false;

                    DataTable dtempty = new DataTable();
                    grdPoeplelsts.DataSource = dtempty;
                    grdPoeplelsts.DataBind();

                    Control FooterTemplate = grdPoeplelsts.Controls[grdPoeplelsts.Controls.Count - 1].Controls[0];
                    FooterTemplate.FindControl("trEmpty").Visible = true;
                }
                else
                {
                    if (dt.Rows.Count <= 9)
                    {
                        rptPaging.Visible = false;
                        PaginUI.Visible = false;
                    }

                    grdPoeplelsts.DataSource = dt;
                    grdPoeplelsts.DataBind();
                    //Response.Redirect("#tab-responsive-2");
                }
            }
        }
        protected void btnOfficeLocationSearch_Click(object sender, EventArgs e)
        {
            //CurrentUserDiv.Visible = false;
            using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
            {

                DataTable dtProfile = new DataTable();

                dtProfile.Columns.Add("AccountName");
                dtProfile.Columns.Add("WorkEmail");
                dtProfile.Columns.Add("Department");
                dtProfile.Columns.Add("JobTitle");
                dtProfile.Columns.Add("OfficeNumber");
                dtProfile.Columns.Add("OfficeLocation");

                SPSite site = new SPSite(SPContext.Current.Site.Url);
                SPWeb web = site.RootWeb;
                SPServiceContext serverContext = SPServiceContext.GetContext(site);
                UserProfileManager profileManager = new UserProfileManager(serverContext);
                EmployeeProfileEntity Profile;
                DataRow dr;
                EmployeeProfileBL EBL = new EmployeeProfileBL();

                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = EBL.GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.WorkEmail;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;
                    dr["OfficeLocation"] = Profile.OfficeLocation;

                    dtProfile.Rows.Add(dr);

                }

                if (txtOffileLocation.Value != "")
                    dtProfile.DefaultView.RowFilter = "OfficeLocation Like '%" + txtOffileLocation.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                if (dt.Rows.Count < 1)
                {
                    rptPaging.Visible = false;
                    PaginUI.Visible = false;

                    DataTable dtempty = new DataTable();
                    grdPoeplelsts.DataSource = dtempty;
                    grdPoeplelsts.DataBind();

                    Control FooterTemplate = grdPoeplelsts.Controls[grdPoeplelsts.Controls.Count - 1].Controls[0];
                    FooterTemplate.FindControl("trEmpty").Visible = true;
                }
                else
                {
                    if (dt.Rows.Count <= 9)
                    {
                        rptPaging.Visible = false;
                        PaginUI.Visible = false;
                    }

                    grdPoeplelsts.DataSource = dt;
                    grdPoeplelsts.DataBind();
                }
            }
        }
    }
}


