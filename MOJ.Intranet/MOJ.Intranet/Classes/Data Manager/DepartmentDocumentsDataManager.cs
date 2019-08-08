using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.DataManager
{
    public class DepartmentDocumentsDataManager
    {
        public List<DepartmentDocumentsEntity> GetDepartmentDocuments()
        {
            List<DepartmentDocumentsEntity> DepartmentDocumentslst = new List<DepartmentDocumentsEntity>();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite oSite = new SPSite(SPContext.Current.Web.Url))
                    {
                        using (SPWeb oWeb = oSite.OpenWeb())
                        {
                            if (oWeb != null)
                            {
                                SPDocumentLibrary oDocumentLibrary = (SPDocumentLibrary)oWeb.Lists[SPUtility.GetLocalizedString("$Resources: DepartmentDocumentsListName", "Resource", SPContext.Current.Web.Language)];
                                SPListItemCollection collListItems = oDocumentLibrary.Items;
                                foreach (SPListItem oListItem in collListItems)
                                {
                                    //Label1.Text += SPEncode.HtmlEncode(oListItem.File) + "<BR>";
                                    DepartmentDocumentsEntity Documents = new DepartmentDocumentsEntity();
                                    Documents.Title = oListItem.Name;
                                    Documents.Type = oListItem.ContentType.ToString();
                                    Documents.DepartmentURL = oListItem.File.ToString();

                                    DepartmentDocumentslst.Add(Documents);
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
            return DepartmentDocumentslst;
        }
    }
}
