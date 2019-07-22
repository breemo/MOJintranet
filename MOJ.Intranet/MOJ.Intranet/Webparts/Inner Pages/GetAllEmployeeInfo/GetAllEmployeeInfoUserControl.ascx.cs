using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
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
                    if (!IsPostBack)
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
                                ProfileValueCollectionBase EmployeeNumber = currentProfile.GetProfileValueCollection("Pager");
                                BindData(EmployeeNumber.ToString());
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
                    lblEmployeeNameAr.Text= item.employeeNameArabicField.ToString();
                }
                    
            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
