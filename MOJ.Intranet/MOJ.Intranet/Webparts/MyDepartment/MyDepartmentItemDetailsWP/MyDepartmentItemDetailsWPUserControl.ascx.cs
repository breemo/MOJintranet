using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.MyDepartment.MyDepartmentItemDetailsWP
{
    public partial class MyDepartmentItemDetailsWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillDetails();
        }
        public void FillDetails()
        {
            string ID = Request.QueryString["Sid"].ToString();
            string Type = Request.QueryString["Type"].ToString();

            try
            {
                lblDetails.Text = "";
                switch (Type.ToLower())
                {
                    case "circular":
                        {
                            lblHead.Text = SPUtility.GetLocalizedString("$Resources: HeadCirculars", "Resource", SPContext.Current.Web.Language);
                            DepartmentCircularsEntity DepartmentItemsLst = new DepartmentCirculars().GetDepartmentCircularsByID(Convert.ToInt32(ID));
                            lblDetails.Text +=
                                 string.Format(@"<h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                <span >{2}</span>
                                                <p style='text-align: justify; font-weight:normal'>
                                                    </br>{1} 
                                                </p>", DepartmentItemsLst.CircularTitle, DepartmentItemsLst.CircularBody, Convert.ToDateTime(DepartmentItemsLst.CircularDate).ToString("dd-MMM-yyyy"));


                            break;
                        }
                    case "procedures":
                        {
                            lblHead.Text = SPUtility.GetLocalizedString("$Resources: HeadProcedure", "Resource", SPContext.Current.Web.Language);
                            DepartmentProceduresEntity DepartmentProceduresItemsLst = new DepartmentProcedures().GetDepartmentProceduresByID(Convert.ToInt32(ID));
                            lblDetails.Text +=
                                string.Format(@"<h2 style='font-size: 22px; line-height: 25px;'>{0}</h2>
                                                <span >{2}</span>
                                                <p style='text-align: justify; font-weight:normal'>
                                                    </br>{1} 
                                                </p>", DepartmentProceduresItemsLst.ProcedureTitle, DepartmentProceduresItemsLst.ProcedureBody, Convert.ToDateTime(DepartmentProceduresItemsLst.ProcedureDate).ToString("dd-MMM-yyyy"));
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("My Departments Details web part :", ex.Message);
            }
        }
    }
}
