using CommonLibrary;
using Microsoft.SharePoint;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.AffirmationSocialSituation
{
    public partial class AffirmationSocialSituationUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetChoices();
                
            }
        }
        private void GetChoices()
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HusbandORWifeUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice Choice0 = (SPFieldChoice)lst.Fields["HusbandORWife"];
                                    for (int i = 0; i < Choice0.Choices.Count; i++)
                                    {
                                        RBHusbandORWife.Items.Add(Choice0.Choices[i].ToString());
                                    }
                                    SPFieldChoice Choice1 = (SPFieldChoice)lst.Fields["workSector"];
                                    for (int i = 0; i < Choice1.Choices.Count; i++)
                                    {
                                        WorkSector0.Items.Add(Choice1.Choices[i].ToString());
                                    }
                                }
                                //Employer0
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

    }
}
