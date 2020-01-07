using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.SharePoint.Utilities;
using System.Globalization;
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.DataManager
{
    public class ImplicitKnowledgeDataManager
    {

        public List<VoluntaryWorkEntity> GetVoluntaryWork(string title)
        {
            List<VoluntaryWorkEntity> ItemsCollection = new List<VoluntaryWorkEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.VoluntaryWorkUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    VoluntaryWorkEntity itemis = new VoluntaryWorkEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.ActivityName = Convert.ToString(Item["ActivityName"]);
                                    itemis.ToDate = Convert.ToDateTime(Item["ToDate"]);
                                    itemis.FromDate = Convert.ToDateTime(Item["FromDate"]);
                                    itemis.LocationID = Convert.ToString(Item["LocationID"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public bool AddOrUpdateVoluntaryWork(List<VoluntaryWorkEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.VoluntaryWorkUrl);
                        SPListItem item = null;
                        foreach (VoluntaryWorkEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;

                            item["ActivityName"] = Item.ActivityName;
                            item["LocationID"] = Item.LocationID;
                            if (Item.FromDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["FromDate"] = Item.FromDate;
                            }
                            if (Item.ToDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {

                                item["ToDate"] = Item.ToDate;
                            }


                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }

        public List<HopisEntity> GetHopis(string title)
        {
            List<HopisEntity> ItemsCollection = new List<HopisEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.HopisUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    HopisEntity itemis = new HopisEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.Hoppy = Convert.ToString(Item["Hoppy"]);

                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public bool AddOrUpdateHopis(List<HopisEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.HopisUrl);
                        SPListItem item = null;
                        foreach (HopisEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;


                            item["Notes"] = Item.Notes;
                            item["Hoppy"] = Item.Hoppy;


                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }

        public List<MembershipEntity> GetMembership(string title)
        {
            List<MembershipEntity> ItemsCollection = new List<MembershipEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.MembershipUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    MembershipEntity itemis = new MembershipEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.Membership = Convert.ToString(Item["Membership"]);
                                    itemis.Location = Convert.ToString(Item["Location"]);
                                    itemis.Field = Convert.ToString(Item["Field"]);
                                    itemis.FromDate = Convert.ToDateTime(Item["FromDate"]);
                                    itemis.ToDate = Convert.ToDateTime(Item["ToDate"]);
                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public bool AddOrUpdateMembership(List<MembershipEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.MembershipUrl);
                        SPListItem item = null;
                        foreach (MembershipEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;


                            item["Membership"] = Item.Membership;
                            item["Location"] = Item.Location;
                            item["Field"] = Item.Field;
                            if (Item.FromDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["FromDate"] = Item.FromDate;
                            }
                            if (Item.ToDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["ToDate"] = Item.ToDate;
                            }
                            item["Notes"] = Item.Notes;


                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }

        public List<ParticipationsEntity> GetParticipations(string title)
        {
            List<ParticipationsEntity> ItemsCollection = new List<ParticipationsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ParticipationsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    ParticipationsEntity itemis = new ParticipationsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.CountryID = Convert.ToString(Item["CountryID"]);
                                    itemis.ActivityName = Convert.ToString(Item["ActivityName"]);
                                    itemis.NatureOfTheParticipation = Convert.ToString(Item["NatureOfTheParticipation"]);
                                    itemis.Sponsor = Convert.ToString(Item["Sponsor"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public bool AddOrUpdateParticipations(List<ParticipationsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ParticipationsUrl);
                        SPListItem item = null;
                        foreach (ParticipationsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["CountryID"] = Item.CountryID;
                            item["ActivityName"] = Item.ActivityName;
                            item["NatureOfTheParticipation"] = Item.NatureOfTheParticipation;
                            item["Sponsor"] = Item.Sponsor;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public int AddOrUpdateRequest(ImplicitKnowledgeEntity RequestItem)
        {
            int PID = 0;
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        SPUser currentUser = web.CurrentUser;
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ImplicitKnowledgeUrl);
                        SPListItem item = null;
                        if (RequestItem.ID > 0)
                        {
                            item = list.GetItemById(RequestItem.ID);
                            PID = RequestItem.ID;
                        }
                        else
                        {
                            item = list.AddItem();
                        }
                        item["Title"] = RequestItem.Name;
                        item["EmployeeNumber"] = RequestItem.EmployeeNumber;
                        item["DateOfBirth"] = RequestItem.DateOfBirth;
                        item["Designation"] = RequestItem.Designation;
                        item["MaritalStatus"] = RequestItem.MaritalStatus;
                        item["Nationality"] = RequestItem.Nationality;
                        item["UserName"] = RequestItem.UserName;
                        item.Update();
                        PID = item.ID;
                    }
                    catch (Exception ex)
                    {
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return PID;
        }

        public bool AddOrUpdateEmploymentHistory(List<EmploymentHistoryEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.EmploymentHistoryUrl);
                        SPListItem item = null;
                        foreach (EmploymentHistoryEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["Designation"] = Item.Designation;
                            item["OrganizationalUnit"] = Item.OrganizationalUnit;
                            if (Item.DateFrom.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["DateFrom"] = Item.DateFrom;
                            }
                            if (Item.DateTo.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                               
                                   item["DateTo"] = Item.DateTo;
                            }
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdatePublications(List<PublicationsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.PublicationsUrl);
                        SPListItem item = null;
                        foreach (PublicationsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["BookPublicationTitle"] = Item.BookPublicationTitle;
                            item["Notes"] = Item.Notes;
                            if (Item.PublishDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["PublishDate"] = Item.PublishDate;
                            }
                            item["Topic"] = Item.Topic;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateTrainingCourses(List<TrainingCoursesEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.TrainingCoursesUrl);
                        SPListItem item = null;
                        foreach (TrainingCoursesEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["CourseLocation"] = Item.CourseLocation;
                            item["CourseName"] = Item.CourseName;
                            if (Item.FromDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["FromDate"] = Item.FromDate;
                            }
                            if (Item.ToDate.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["ToDate"] = Item.ToDate;
                            }
                            item["TrainingHours"] = Item.TrainingHours;
                            item["WithinThePlan"] = Item.WithinThePlan;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateExpertise(List<ExpertiseEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.ExpertiseUrl);
                        SPListItem item = null;
                        foreach (ExpertiseEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;

                            item["CountryID"] = Item.CountryID;
                            item["NatureOfTheJob"] = Item.NatureOfTheJob;
                            item["Notes"] = Item.Notes;
                            item["OrganizationName"] = Item.OrganizationName;
                            item["YearsOfExperience"] = Item.YearsOfExperience;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateTravelInformations(List<TravelInformationsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.TravelInformationsUrl);
                        SPListItem item = null;
                        foreach (TravelInformationsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;

                            item["CountryResidentForMoreThan3Month"] = Item.CountryResidentForMoreThan3Month;
                            if (Item.TimeperiodTo.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["TimeperiodTo"] = Item.TimeperiodTo;
                            }
                            if (Item.TimePeriodFrom.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["TimePeriodFrom"] = Item.TimePeriodFrom;
                            }
                            item["VisitReasons"] = Item.VisitReasons;


                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateQualifications(List<QualificationsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.QualificationsUrl);
                        SPListItem item = null;
                        foreach (QualificationsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["Qualification"] = Item.Qualification;
                            item["Major"] = Item.Major;
                            item["Institution"] = Item.Institution;
                            if (Item.GraduationYear.ToString("MM/dd/yyyy") != "01/01/0001")
                            {
                                item["GraduationYear"] = Item.GraduationYear;
                            }
                            item["CountryID"] = Item.CountryID;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateLanguageSkills(List<LanguageSkillsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.LanguageSkillsUrl);
                        SPListItem item = null;
                        foreach (LanguageSkillsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["ReadinglevelID"] = Item.ReadinglevelID;
                            item["WritinglevelID"] = Item.WritinglevelID;
                            item["ConversationlevelID"] = Item.ConversationlevelID;
                            item["Language"] = Item.Language;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateOtherSkills(List<OtherSkillsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.OtherSkillsUrl);
                        SPListItem item = null;
                        foreach (OtherSkillsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["SkillTheEmployeeHave"] = Item.SkillTheEmployeeHave;
                            item["Notes"] = Item.Notes;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public bool AddOrUpdateTechnicalSkills(List<TechnicalSkillsEntity> Items)
        {
            bool isFormSaved = false;
            bool isUpdate = false;
            //SPSecurity.RunWithElevatedPrivileges(delegate ()
            //{
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.RootWeb)
                {
                    try
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.GetListFromUrl(web.Url + SharedConstants.TechnicalSkillsUrl);
                        SPListItem item = null;
                        foreach (TechnicalSkillsEntity Item in Items)
                        {
                            if (Item.ID > 0)
                            {
                                item = list.GetItemById(Item.ID);
                                isUpdate = true;
                            }
                            else
                            {
                                item = list.AddItem();
                            }
                            item["Title"] = Item.Title;
                            item["SkillType"] = Item.SkillType;
                            item["SkilllevelID"] = Item.SkilllevelID;
                            item["AreaOfApplication"] = Item.AreaOfApplication;
                            item["Notes"] = Item.Notes;
                            item["PID"] = Item.PID;
                            item.Update();
                        }
                        isFormSaved = true;
                    }
                    catch (Exception ex)
                    {
                        isFormSaved = false;
                        LoggingService.LogError("WebParts", ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        web.AllowUnsafeUpdates = false;
                    }
                }
            }
            //});
            return isFormSaved;
        }
        public List<EmploymentHistoryEntity> GeteEmploymentHistory(string title)
        {
            List<EmploymentHistoryEntity> ItemsCollection = new List<EmploymentHistoryEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.EmploymentHistoryUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    EmploymentHistoryEntity itemis = new EmploymentHistoryEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.OrganizationalUnit = Convert.ToString(Item["OrganizationalUnit"]);
                                    itemis.DateFrom = Convert.ToDateTime(Item["DateFrom"]);
                                    itemis.DateTo = Convert.ToDateTime(Item["DateTo"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public List<TrainingCoursesEntity> GetTrainingCourses(string title)
        {
            List<TrainingCoursesEntity> ItemsCollection = new List<TrainingCoursesEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.TrainingCoursesUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    TrainingCoursesEntity itemis = new TrainingCoursesEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.CourseLocation = Convert.ToString(Item["CourseLocation"]);
                                    itemis.CourseName = Convert.ToString(Item["CourseName"]);
                                    itemis.FromDate = Convert.ToDateTime(Item["FromDate"]);
                                    itemis.ToDate = Convert.ToDateTime(Item["ToDate"]);
                                    itemis.TrainingHours = Convert.ToString(Item["TrainingHours"]);
                                    itemis.WithinThePlan = Convert.ToString(Item["WithinThePlan"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public List<ExpertiseEntity> GetExpertise(string title)
        {
            List<ExpertiseEntity> ItemsCollection = new List<ExpertiseEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ExpertiseUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    ExpertiseEntity itemis = new ExpertiseEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.OrganizationName = Convert.ToString(Item["OrganizationName"]);
                                    itemis.NatureOfTheJob = Convert.ToString(Item["NatureOfTheJob"]);
                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.CountryID = Convert.ToString(Item["CountryID"]);
                                    itemis.YearsOfExperience = Convert.ToString(Item["YearsOfExperience"]);

                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public List<PublicationsEntity> GetPublications(string title)
        {
            List<PublicationsEntity> ItemsCollection = new List<PublicationsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.PublicationsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    PublicationsEntity itemis = new PublicationsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.BookPublicationTitle = Convert.ToString(Item["BookPublicationTitle"]);
                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.PublishDate = Convert.ToDateTime(Item["PublishDate"]);
                                    itemis.Topic = Convert.ToString(Item["Topic"]);

                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public List<TravelInformationsEntity> GetTravelInformations(string title)
        {
            List<TravelInformationsEntity> ItemsCollection = new List<TravelInformationsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.TravelInformationsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    TravelInformationsEntity itemis = new TravelInformationsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);

                                    itemis.CountryResidentForMoreThan3Month = Convert.ToString(Item["CountryResidentForMoreThan3Month"]);
                                    itemis.TimePeriodFrom = Convert.ToDateTime(Item["TimePeriodFrom"]);
                                    itemis.TimeperiodTo = Convert.ToDateTime(Item["TimeperiodTo"]);
                                    itemis.VisitReasons = Convert.ToString(Item["VisitReasons"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public List<QualificationsEntity> GeteQualifications(string title)
        {
            List<QualificationsEntity> ItemsCollection = new List<QualificationsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.QualificationsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    QualificationsEntity itemis = new QualificationsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.Qualification = Convert.ToString(Item["Qualification"]);
                                    itemis.Major = Convert.ToString(Item["Major"]);
                                    itemis.Institution = Convert.ToString(Item["Institution"]);
                                    itemis.CountryID = Convert.ToString(Item["CountryID"]);

                                    itemis.GraduationYear = Convert.ToDateTime(Item["GraduationYear"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public List<LanguageSkillsEntity> GeteLanguageSkills(string title)
        {
            List<LanguageSkillsEntity> ItemsCollection = new List<LanguageSkillsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.LanguageSkillsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    LanguageSkillsEntity itemis = new LanguageSkillsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.ConversationlevelID = Convert.ToString(Item["ConversationlevelID"]);
                                    itemis.Language = Convert.ToString(Item["Language"]);
                                    itemis.ReadinglevelID = Convert.ToString(Item["ReadinglevelID"]);
                                    itemis.WritinglevelID = Convert.ToString(Item["WritinglevelID"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public List<OtherSkillsEntity> GetOtherSkills(string title)
        {
            List<OtherSkillsEntity> ItemsCollection = new List<OtherSkillsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.OtherSkillsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    OtherSkillsEntity itemis = new OtherSkillsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.SkillTheEmployeeHave = Convert.ToString(Item["SkillTheEmployeeHave"]); ;
                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }
        public List<TechnicalSkillsEntity> GetTechnicalSkills(string title)
        {
            List<TechnicalSkillsEntity> ItemsCollection = new List<TechnicalSkillsEntity>();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.TechnicalSkillsUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='Title'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    TechnicalSkillsEntity itemis = new TechnicalSkillsEntity();
                                    itemis.Title = Convert.ToString(Item["Title"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.SkillType = Convert.ToString(Item["SkillType"]);
                                    itemis.SkilllevelID = Convert.ToString(Item["SkilllevelID"]);
                                    itemis.AreaOfApplication = Convert.ToString(Item["AreaOfApplication"]);
                                    itemis.Notes = Convert.ToString(Item["Notes"]);
                                    itemis.PID = Convert.ToInt32(Item["PID"]);
                                    ItemsCollection.Add(itemis);
                                }

                            }
                        }

                    }
                }
            });
            return ItemsCollection;
        }

        public ImplicitKnowledgeEntity GetImplicitKnowledge(string title)
        {
            ImplicitKnowledgeEntity itemis = new ImplicitKnowledgeEntity();
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        if (oWeb != null)
                        {
                            SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.ImplicitKnowledgeUrl);
                            if (lst != null)
                            {
                                SPQuery qry1 = new SPQuery();
                                string camlquery1 = "<Where><Eq><FieldRef Name='UserName'  /> <Value Type='Text'>" + title + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='true'' /></OrderBy>";
                                qry1.Query = camlquery1;
                                SPListItemCollection listItemsCollection1 = lst.GetItems(qry1);
                                foreach (SPListItem Item in listItemsCollection1)
                                {
                                    itemis.DateOfBirth = Convert.ToString(Item["DateOfBirth"]);
                                    itemis.Designation = Convert.ToString(Item["Designation"]);
                                    itemis.EmployeeNumber = Convert.ToString(Item["EmployeeNumber"]);
                                    itemis.ID = Convert.ToInt32(Item["ID"]);
                                    itemis.MaritalStatus = Convert.ToString(Item["MaritalStatus"]);
                                    itemis.Name = Convert.ToString(Item["Title"]);
                                    itemis.Nationality = Convert.ToString(Item["Nationality"]);
                                    itemis.UserName = Convert.ToString(Item["UserName"]);

                                }

                            }
                        }

                    }
                }
            });
            return itemis;
        }
        public bool DeleteitemsFromSublist(string listname, List<int> listsid)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList lst = oWeb.GetListFromUrl(oSite.Url + "/Lists/" + listname + "/AllItems.aspx");
                        foreach (int listItemId in listsid)
                        {
                            SPListItem itemToDelete = lst.GetItemById(listItemId);
                            itemToDelete.Delete();
                        }
                        oWeb.AllowUnsafeUpdates = false;
                    }
                }
            });
            return true;
        }

    }
}
