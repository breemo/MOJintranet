using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Search.Query;
using MOJ.Business;
using MOJ.Entities;
using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb myweb = mySitesCollection.OpenWeb())
                        {
                            SPUser currentUser = myweb.CurrentUser;
                            string currentUserlogin = currentUser.LoginName;
                            SPServiceContext context = SPServiceContext.GetContext(mySitesCollection);
                            UserProfileManager profileManager = new UserProfileManager(context);
                            UserProfile currentProfile = profileManager.GetUserProfile(currentUserlogin);

                            if (currentProfile.GetProfileValueCollection("Pager").Count != 0)
                            {
                                ProfileValueCollectionBase EmployeeNumber = currentProfile.GetProfileValueCollection("Pager");
                                BindData(EmployeeNumber.ToString());
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "showModalPopUp();", true);
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "showModalPopUp();", true);
                            }


                        }
                    }
                }
                catch (Exception ex)
                {

                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
        private void BindData(string EmployeeNumber)
        {
            try
            {
                List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().EmployeeMasterDataByEmployeeNumber(EmployeeNumber);
                foreach (EmployeeMasterDataEntity item in EmployeeValues)
                {
                    lblEmployeeNameAr.Text = item.employeeNameArabicField.ToString();
                    lblDepartmentAr.Text = item.departmentNameField_AR.ToString();
                    lblContactNo.Text = item.contactNumberField.ToString();
                    lblEmail.Text = item.employeeEmailField.ToString();
                    lblJobtitle.Text = item.positionNameField_AR.ToString();
                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        protected void btnNameSearch_Click(object sender, EventArgs e)
        {
            CurrentUserDiv.Visible = false;

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

                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.Email;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;

                    dtProfile.Rows.Add(dr);

                }

                if (txtNameSearch.Value != "")
                    dtProfile.DefaultView.RowFilter = "AccountName Like '%" + txtNameSearch.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                grdPoeplelsts.DataSource = dt;
                grdPoeplelsts.DataBind();

            }
        }
        private EmployeeProfileEntity GetShortUserProfile(UserProfile profile)
        {
            try
            {
                EmployeeProfileEntity currEmployee = new EmployeeProfileEntity();

                //currEmployee.EmployeeID = profile["employeeID"].Value.ToSafeString();
                currEmployee.AccountName = Convert.ToString(profile[PropertyConstants.AccountName].Value);
                currEmployee.Email = Convert.ToString(profile[PropertyConstants.WorkEmail].Value);
                //currEmployee.OfficeNumber = Convert.ToString(profile[PropertyConstants.WorkPhone].Value);
                //currEmployee.PhoneNumber = Convert.ToString(profile[PropertyConstants.CellPhone].Value);
                currEmployee.Department = Convert.ToString(profile[PropertyConstants.Department].Value);
                currEmployee.JobTitle = Convert.ToString(profile[PropertyConstants.JobTitle].Value);
                currEmployee.OfficeNumber = Convert.ToString(profile[PropertyConstants.WorkPhone].Value);
                currEmployee.OfficeLocation = Convert.ToString(profile[PropertyConstants.Location].Value);


                return currEmployee;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        protected void btnDepartmentSearch_Click(object sender, EventArgs e)
        {
            CurrentUserDiv.Visible = false;
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

                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.Email;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;

                    dtProfile.Rows.Add(dr);

                }

                if (txtDepartmentSearch.Value != "")
                    dtProfile.DefaultView.RowFilter = "Department Like '%" + txtDepartmentSearch.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                grdPoeplelsts.DataSource = dt;
                grdPoeplelsts.DataBind();

            }
        }

        protected void btnOfficeLocationSearch_Click(object sender, EventArgs e)
        {
            CurrentUserDiv.Visible = false;
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

                foreach (UserProfile _Profile in profileManager)
                {
                    Profile = GetShortUserProfile(_Profile);

                    dr = dtProfile.NewRow();
                    dr["AccountName"] = Profile.AccountName;
                    dr["WorkEmail"] = Profile.Email;
                    dr["Department"] = Profile.Department;
                    dr["JobTitle"] = Profile.JobTitle;
                    dr["OfficeNumber"] = Profile.OfficeNumber;
                    dr["OfficeLocation"] = Profile.OfficeLocation;

                    dtProfile.Rows.Add(dr);

                }

                if (txtOffileLocation.Value != "")
                    dtProfile.DefaultView.RowFilter = "OfficeLocation Like '%" + txtOffileLocation.Value + "%'";

                DataTable dt = dtProfile.DefaultView.ToTable();

                grdPoeplelsts.DataSource = dt;
                grdPoeplelsts.DataBind();

            }
        }
    }
}

