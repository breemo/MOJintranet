using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.wpInnovationGate
{
    public partial class wpInnovationGateUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            switch (ddlInnovationTypes.SelectedValue)
            {
                case "2":
                    {
                        this.Response.Redirect(SPUtility.GetLocalizedString("$Resources: urlInnovationPlatform", "Resource", SPContext.Current.Web.Language));
                        break;
                    }
                case "3":
                    {
                        this.Response.Redirect(SPUtility.GetLocalizedString("$Resources: urlInnovationTools", "Resource", SPContext.Current.Web.Language));
                        break;
                    }
                case "4":
                    {
                        this.Response.Redirect(SPUtility.GetLocalizedString("$Resources: urlMinistryInnovationStrategy", "Resource", SPContext.Current.Web.Language));
                        break;
                    }
                case "5":
                    {
                        this.Response.Redirect(SPUtility.GetLocalizedString("$Resources: urlGovernmentInnovationFramework", "Resource", SPContext.Current.Web.Language));
                        break;
                    }
            }
        }
    }
}
