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

namespace MOJ.Intranet.Webparts.MyDepartment.DepartmentProceduresWP
{
    public partial class DepartmentProceduresWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("WebParts", ex.Message);
                }
            }
        }
        private void BindData()
        {
            try
            {
                List<DepartmentProceduresEntity> DepartmentProceduresLst = new DepartmentProcedures().GetDepartmentProcedures();
                lblDrawItems.Text = "";
                string siteURL = SPContext.Current.Web.Url;
                foreach (DepartmentProceduresEntity item in DepartmentProceduresLst)
                {
                    string des = LimitCharacters.Limit(item.ProcedureBody, 400);
                    lblDrawItems.Text +=
                        string.Format(@"
                        <div class='enteyitemnew'>
                            <span class='dateut'>{0}</span>
                            <h6>
                                {1}
                            </h6>
                            <p>
                            {2}
                            </p>
                            <a href = '{3}/Pages/Details.aspx?id={4}&type=Procedures' class='detailbtn'>" + SPUtility.GetLocalizedString("$Resources: ReadMore", "Resource", SPContext.Current.Web.Language) + @"</a>
                        </div>", Convert.ToDateTime(item.ProcedureDate).ToString("dd-MMM-yyyy"),item.ProcedureTitle, des, siteURL, item.ID);

                }

            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
