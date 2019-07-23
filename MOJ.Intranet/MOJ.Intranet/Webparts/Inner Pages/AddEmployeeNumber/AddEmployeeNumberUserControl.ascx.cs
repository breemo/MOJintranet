using CommonLibrary;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;
using MOJ.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.AddEmployeeNumber
{
    public partial class AddEmployeeNumberUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {
                using (SPSite mySitesCollection = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb myweb = mySitesCollection.OpenWeb())
                    {
                        SPUser currentUser = myweb.CurrentUser;
                        if (txtEmployeeNumber.Value !="")
                        {
                            bool UpdateUserProfile = new AddEmployeeNumberBL().AddEmployeeEnumber(currentUser, txtEmployeeNumber.Value);
                            if (UpdateUserProfile == true)
                            {
                                Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>");
                                Context.Response.Flush();
                                Context.Response.End();
                            }
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
}
