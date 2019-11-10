using CommonLibrary;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using MOJ.Intranet.Classes.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.My_Services.HostingRequestWP
{
    public partial class HostingRequestWPUserControl : SiteUI
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
              
                currentUserData();
                GetPlaces();
                GetResources();
                GetEmirates();
            }
        }
        public string mangerName
        {
            get
            {
                if (ViewState["mangerName"] != null)
                {
                    return Convert.ToString(ViewState["mangerName"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerName"] = value; }
        }
        public string mangerID
        {
            get
            {
                if (ViewState["mangerID"] != null)
                {
                    return Convert.ToString(ViewState["mangerID"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerID"] = value; }
        }
        public string mangerEmail
        {
            get
            {
                if (ViewState["mangerEmail"] != null)
                {
                    return Convert.ToString(ViewState["mangerEmail"]);
                }
                else
                {
                    return "";
                }
            }
            set { ViewState["mangerEmail"] = value; }
        }
       
        private void currentUserData()
        {
            try
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
                foreach (EmployeeMasterDataEntity item in EmployeeValues)
                {
                    Enumber.Value = item.employeeNumberField.ToString();
                   
                    if (languageCode == "ar")
                    {
                        Ename.Value = item.employeeNameArabicField.ToString();
                       
                        EPosition.Value = item.positionNameField_AR.ToString();
                       
                    }
                    else
                    {
                        Ename.Value = item.employeeNameEnglishField.ToString();
                       
                        EPosition.Value = item.positionNameField_US.ToString();
                        
                        
                    }
                    mangerName= item.ManagerName_DirectManager.ToString();
                    mangerID= item.ManagerID_DirectManager.ToString();
                    mangerEmail = item.ManagerEmail_DirectManager;
                    EDegree.Value = "";// item.employementDateField.ToString(); 

                   
                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }
          private void savecurrentUserData()
        {
            try
            {              
                EmployeeEntity EmployeeValues = new EmployeeEntity();
                EmployeeValues.mangerName = mangerName;
                Literal1.Text = mangerName;
                EmployeeValues.mangerID = mangerID;
                EmployeeValues.mangerEmail = mangerEmail;
                EmployeeValues.AccountName = SPContext.Current.Web.CurrentUser.LoginName ;
                if (mangerName!=null&& mangerName!="") {
                    bool Emp = new Employee().SaveUpdate(EmployeeValues);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        private void GetEmirates()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
            DataTable ReserveHoteldata = new ReserveHotel().GetEmirates();
            DropDownEmirates.DataSource = ReserveHoteldata;
            DropDownEmirates.DataValueField = "ID";
            DropDownEmirates2.DataSource = ReserveHoteldata;
            DropDownEmirates2.DataValueField = "ID";
            if (languageCode == "ar")
            {
                DropDownEmirates.DataTextField = "TitleAr";
                DropDownEmirates2.DataTextField = "TitleAr";
            }
            else
            {
                DropDownEmirates.DataTextField = "Title";
                DropDownEmirates2.DataTextField = "Title";
            }
            DropDownEmirates.DataBind();
            DropDownEmirates2.DataBind(); 
         }
        private void GetPlaces()
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.RoomBookingUrl);
                                if (lst != null)
                                {
                                    SPFieldChoice PlaceChoice = (SPFieldChoice)lst.Fields["Place"];
                                    for (int i = 0; i < PlaceChoice.Choices.Count; i++)
                                    {
                                        string text = PlaceChoice.Choices[i].ToString();
                                        string Choicetrim = text.Replace(" ", "");
                                        var placetext = SPUtility.GetLocalizedString("$Resources: "+ Choicetrim, "Resource", SPContext.Current.Web.Language);
                                        //cbPlace.Items.Add(PlaceChoice.Choices[i].ToString());
                                        placetext = "<span class='radio-button-circle'></span>" + placetext;
                                        cbPlace.Items.Add(new ListItem(placetext, PlaceChoice.Choices[i].ToString()));
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

        private void GetResources()
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
                                SPList lst = oWeb.GetListFromUrl(oSite.Url + SharedConstants.RoomBookingUrl);
                                if (lst != null)
                                {
                                    SPFieldMultiChoice ResourcesChoice = (SPFieldMultiChoice)lst.Fields["ResourcesNeeded"];
                                    for (int i = 0; i < ResourcesChoice.Choices.Count; i++)
                                    {


                                        string text = ResourcesChoice.Choices[i].ToString();
                                        string Choicetrim = text.Replace(" ", "");
                                        var placetext = SPUtility.GetLocalizedString("$Resources: " + Choicetrim, "Resource", SPContext.Current.Web.Language);
                                        placetext = "<span class='checkbox-box'></span>" + placetext;
                                        cbResources.Items.Add(new ListItem(placetext, ResourcesChoice.Choices[i].ToString()));
                                        
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
       
        protected void btnSaveReserveHotel_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                savecurrentUserData();
                string RecordPrfix = "";
                RecordPrfix = "Hotel-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("ReserveHotel");
                ReserveHotelEntity itemSumbit = new ReserveHotelEntity();
                itemSumbit.RequestNumber = RecordPrfix;
                itemSumbit.EmirateID = DropDownEmirates.SelectedValue.ToString();
                ReserveHotel rb = new ReserveHotel();
                bool isSaved = rb.SaveUpdate(itemSumbit);
                /////////////////////////////////////////////////////////////////////
                List<ReserveHotelPeopleEntity> listReserveHotelPeople = new List<ReserveHotelPeopleEntity>();
                if (!string.IsNullOrEmpty(PName0.Value))
                {
                    ReserveHotelPeopleEntity itemPeople = new ReserveHotelPeopleEntity();
                    itemPeople.RequestNumber = RecordPrfix;
                    itemPeople.Name = PName0.Value;
                    itemPeople.Job = Job0.Value;
                    itemPeople.from = from0.Value;
                    itemPeople.to = to0.Value;
                    itemPeople.Task = pMission0.Value;

                    listReserveHotelPeople.Add(itemPeople);
                }
                if (hdncounter.Value != "" && hdncounter.Value!="1")
                {
                    string[] Name = Request.Form.GetValues("PName");
                    string[] Job = Request.Form.GetValues("Job");
                    string[] from = Request.Form.GetValues("from");
                    string[] to = Request.Form.GetValues("to");
                    string[] pMission = Request.Form.GetValues("pMission");
                    for (int x = 0; x < Convert.ToInt32(Name.Length); x++)
                    {
                        if (!string.IsNullOrEmpty(Name[x]))
                        {
                            ReserveHotelPeopleEntity itemPeople = new ReserveHotelPeopleEntity();
                            itemPeople.RequestNumber = RecordPrfix;
                            itemPeople.Name = Name[x];
                            itemPeople.Job = Job[x];

                            itemPeople.from = from[x];

                            itemPeople.to = to[x];
                            itemPeople.Task = pMission[x];


                            listReserveHotelPeople.Add(itemPeople);
                        }
                    }
                }

                rb.SaveUpdateReserveHotelPeople(listReserveHotelPeople);
                if (isSaved == true)
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                   posts.Style.Add("display", "none");
               
                    SuccessMsgDiv.Style.Add("display", "block");
                }
            }
        }

        protected void btnSaveRoomBooking_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                savecurrentUserData();
                DateTime sDate = DateTime.ParseExact(txtBookingDateFrom.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string[] pmSdate = txtBookingTimeFrom.Value.Split(' ');
                TimeSpan tsSdate = TimeSpan.Parse(pmSdate[0]);
                sDate = (pmSdate[1] == "PM") ? (sDate.Date + tsSdate).AddHours(12) : sDate.Date + tsSdate;
              



                DateTime tDate = DateTime.ParseExact(txtBookingDateTo.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string[] pmTdate = txtBookingTimeTo.Value.Split(' ');
                TimeSpan tsTdate = TimeSpan.Parse(pmTdate[0]);
                tDate = (pmTdate[1] == "PM") ? (tDate.Date + tsTdate).AddHours(12) : tDate.Date + tsTdate;
               

               
                    string RecordPrfix = "";
                RecordPrfix = "Room-" + DateTime.Now.ToString("yyMMdd") + "-" + CommonLibrary.Methods.GetNextRequestNumber("RoomBooking");
                RoomBookingEntity itemSumbit = new RoomBookingEntity();

                itemSumbit.DateFrom = Convert.ToString(sDate);
                 itemSumbit.DateTo = Convert.ToString(tDate);
                

                itemSumbit.AttendeesNumber = txtAttendeesNumber.Value;
                itemSumbit.Mission = txtMission.Value;
                itemSumbit.Place = cbPlace.SelectedValue;
                itemSumbit.Department = "1";
                itemSumbit.RequestNumber = RecordPrfix;
                itemSumbit.EmirateID = DropDownEmirates2.SelectedValue.ToString();
                SPFieldMultiChoiceValue multiValue = new SPFieldMultiChoiceValue();
                foreach (ListItem item in cbResources.Items)
                {
                    if (item.Selected)
                        multiValue.Add(item.Value);
                }
                itemSumbit.ResourcesNeeded = multiValue;
                //itemSumbit.Status = "Submitted";

                RoomBooking rb = new RoomBooking();
                bool isSaved = rb.SaveUpdate(itemSumbit);

                if (isSaved == true)
                {
                    lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />" + SPUtility.GetLocalizedString("$Resources: YourRequestNumber", "Resource", SPContext.Current.Web.Language) + "<br />" + RecordPrfix;
                    posts.Style.Add("display", "none");
                  
                    SuccessMsgDiv.Style.Add("display", "block");
                }





              
                
               
                ///////////////
            }
        }


       







    }
}
