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
                List<DepartmentDocumentsEntity> DepartmentDocumentsEntityLst = new DepartmentDocumentsBL().GetAllDocuments();
                lblDrawItems.Text = "";
                string siteURL = SPContext.Current.Web.Url;
                foreach (DepartmentDocumentsEntity item in DepartmentDocumentsEntityLst)
                {
                    string[] FileNameAndFileType = item.Title.ToString().Split('.');
                    string FileType = FileNameAndFileType[1].ToString();
                    string classname = "";

                    switch (FileType)
                    {
                        case "doc":
                        case "docx":
                            classname = "wfnew";
                            break;

                        case "xlsx":
                            classname = "ef";
                            break;

                        case "pdf":
                            classname = "pf";
                            break;

                        default:
                            break;
                    }

                    lblDrawItems.Text +=
                                      string.Format(@"
                                            <div class='col-md-2 col-sm-4'>

                                                <div class='filuo'>
                                                    <a href='" + siteURL + @"/InnovationFiles/" + item.Title + @"'>
                                                    <div class='" + classname + @"'>
                                                        <p>
                                                           " + FileNameAndFileType[0].ToString() + @"
                                                        </p>
                                                    </div>
                                                    </a>
                                                </div>
                                            </div>
                                    ");
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
    }
}
