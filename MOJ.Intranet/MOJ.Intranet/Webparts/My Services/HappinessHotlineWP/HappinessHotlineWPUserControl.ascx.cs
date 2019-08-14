using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.HappinessHotlineWP
{
    public partial class HappinessHotlineWPUserControl : UserControl
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HappinessHotlineUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice Choice0 = (SPFieldChoice)lst.Fields["ContactReason"];
                                    for (int i = 0; i < Choice0.Choices.Count; i++)
                                    {
                                        RBContactReason.Items.Add(Choice0.Choices[i].ToString());
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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string RecordPrfix = "";
                RecordPrfix = "Happiness-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("HappinessHotline");
                HappinessHotlineEntity itemSumbit = new HappinessHotlineEntity();
                itemSumbit.Message = Message.Value;
                itemSumbit.ContactReason = RBContactReason.SelectedValue;
                itemSumbit.RequestNumber = RecordPrfix;
                HappinessHotline HappinessHot = new HappinessHotline();
                bool isSaved = HappinessHot.SaveUpdate(itemSumbit);
                if (isSaved == true)
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                    posts.Style.Add("display", "none");
                    SuccessMsgDiv.Style.Add("display", "block");
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }

        }
    }
}
