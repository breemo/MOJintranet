using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Methods
    {
        #region Files and Attachments
        public static string ReturnAttachmentFile(SPWeb oWeb, SPListItem lstItem)
        {
            string FileUrl = "";
            try
            {
                FileUrl = oWeb.Url + "/" + lstItem.ParentList.RootFolder.SubFolders["Attachments"].SubFolders[lstItem.ID.ToString()].Files[0].Url;
            }
            catch { FileUrl = "#"; }

            return FileUrl;
        }

        public static string CheckFileType(string ext)
        {
            switch (ext.ToLower())
            {
                case "pdf":
                    return "/_layouts/images/pdf.jpeg";
                //break;

                case "xlsx":
                    return "/_layouts/images/xcl.jpeg";
                //break;

                case "xls":
                    return "/_layouts/images/xcl.jpeg";
                //break;

                case "doc":
                    return "/_layouts/images/word.jpeg";
                //break;

                case "docx":
                    return "/_layouts/images/word.jpeg";
                //break;

                case "ppt":
                    return "/_layouts/images/ppt.jpeg";
                //break;

                case "pptx":
                    return "/_layouts/images/ppt.jpeg";
                //break;

                default:
                    return "/_layouts/images/default.jpeg";
                    //break;
            }
        }


        #endregion

        public static string GetNextRequestNumber(string listName)
        {
            int itemCount = 1;
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + "/Lists/" + listName + "/AllItems.aspx");
                                if (lst != null)
                                {
                                    SPQuery oQuery = new SPQuery();
                                    oQuery.Query = @"<Where>
                                                        <Eq>
                                                          <FieldRef Name='Created' />
                                                          <Value Type='DateTime'><Today /></Value>
                                                        </Eq>
                                                    </Where>";

                                    SPListItemCollection lstItems = lst.GetItems(oQuery);
                                    itemCount = lstItems.Count;
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
            //return itemCount++;
            return (itemCount + 1).ToString().PadLeft(5, '0');
        }
    }
}
