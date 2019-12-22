using CommonLibrary;
using Microsoft.SharePoint;
using MOJ.Entities;
using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MOJ.DataManager;
using MOJ.Business;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;
using System.Threading;
using MOJ.Intranet.Classes.Common;
using MOJ.Entities.ImplicitKnowledge;

namespace MOJ.Intranet.Webparts.KnowledgeGateway.ImplicitKnowledgeWP
{
    public partial class ImplicitKnowledgeWPUserControl : SiteUI
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
                EmploymentHistoryData();
            }
        }
        private void EmploymentHistoryData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                List<EmploymentHistoryEntity> EmploymentHistory = objIK.GeteEmploymentHistory(currentUserlogin);
                int x = 0;
                foreach (EmploymentHistoryEntity item in EmploymentHistory)
                {
                    if (x == 0) {
                         SID0.Value = item.ID.ToString();
                        RetrevehdnsuperDIV1.Value=item.ID.ToString()+ "#" ;
                         Organizationalunit0.Value = item.OrganizationalUnit.ToString();
                         Designation0.Value = item.Designation.ToString();
                         Datefrom0.Value = item.DateFrom.ToString("MM/dd/yyyy");
                         Dateto0.Value = item.DateTo.ToString("MM/dd/yyyy");                        
                    }
                    else
                    {
                        hdnsuperDIV1.Value =Convert.ToString(x);
                        
                        RetrevehdnsuperDIV1.Value += item.ID.ToString() + "#";
                        var htmlrow1 = "<div class='rowI'> <hr><div class='row rt'>" +
                            "<span style='padding-right: 25px; margin-top: -15px; ' onclick='removerowEmploymenthistory(this); '>" +
                            "<span class='icon-remove'></span></span></div>" +
                    "<div class='row rt'>" +
                                   "<div class=' DivSID' style=' display: none;'>" +
                                     "<input name='SID' type='text' value='" + item.ID.ToString() + "' id='SID" + x + "' class='form-control' placeholder=''>" +
                                    "</div>" +
                            "<div class='col-md-3 DivDesignation'><input name='Designation' value='" + item.Designation.ToString() + "' type='text'' id='Designation" + x + "' class='form-control' placeholder=''>" +
                            "</div>" +
                                "<div class='col-md-3 DivOrganizationalunit'><input name='Organizationalunit' value='" + item.OrganizationalUnit.ToString() + "' type='text'' id='Organizationalunit" + x + "' class='form-control' placeholder=''>" +
                                "</div> " +
                                    "<div class='col-md-3 '>" +
                                    "	<div class='input-group date DivDatefrom' data-provide='datepicker'><input autocomplete='off' value='" + item.DateFrom.ToString("MM/dd/yyyy") + "' name='Datefrom' type='text' id='Datefrom" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                                     "</div>" +
                                    "<div class='col-md-3 '>" +
                                    "<div class='input-group date DivDateto' data-provide='datepicker'><input value='" + item.DateTo.ToString("MM/dd/yyyy") + "' autocomplete='off' name='Dateto' type='text' id='Dateto" + x + "' class='form-control'>" +
                                    "<div class='input-group-addon'><span class='icon-calendar-alt1'></span></div></div>" +
                         " </div></div></div>";

                        // document.getElementById('dynamicInputChildren').appendChild(newdiv);
                        System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
     new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newDiv.Attributes.Add("class", "new");
                        newDiv.InnerHtml = htmlrow1;
                        superDIV1.Controls.Add(newDiv);

                    }
                    x++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError("WebParts", ex.Message);
            }
        }
        private void currentUserData()
        {
            try
            {
                string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                ImplicitKnowledgeEntity Employment = objIK.GetImplicitKnowledge(currentUserlogin);
                if (Employment.ID > 0)
                {
                    TOPID.Value = Employment.ID.ToString();
                    Enumber.Value = Employment.EmployeeNumber.ToString();
                    EDateOfBirth.Value = Employment.DateOfBirth.ToString();
                    Ename.Value = Employment.Name.ToString();
                    ENationality.Value = Employment.Nationality.ToString();
                    EPosition.Value = Employment.Designation.ToString();
                    EMaritalStatus.Value = Employment.MaritalStatus.ToString();
                }
                else
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    string languageCode = currentCulture.TwoLetterISOLanguageName.ToLowerInvariant();
                    List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
                    foreach (EmployeeMasterDataEntity item in EmployeeValues)
                    {
                        Enumber.Value = item.employeeNumberField.ToString();
                        EDateOfBirth.Value = item.dateOfBirthField.ToString();

                        if (languageCode == "ar")
                        {
                            Ename.Value = item.employeeNameArabicField.ToString();
                            ENationality.Value = item.nationality_ARField.ToString();
                            EPosition.Value = item.positionNameField_AR.ToString();
                            EMaritalStatus.Value = item.maritalStatus_ARField.ToString();
                        }
                        else
                        {
                            Ename.Value = item.employeeNameEnglishField.ToString();
                            ENationality.Value = item.nationality_USField.ToString();
                            EPosition.Value = item.positionNameField_US.ToString();
                            EMaritalStatus.Value = item.maritalStatus_USField.ToString();
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                LoggingService.LogError("WebParts", ex.Message);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!_isRefresh)
            {
                ImplicitKnowledge objIK = new ImplicitKnowledge();
                try
                {
                    string currentUserlogin = SPContext.Current.Web.CurrentUser.LoginName;
                    //////////////////////////////////1///////////////////////
                    int PID = 0;
                    if (string.IsNullOrEmpty(TOPID.Value))
                    {
                        ImplicitKnowledgeEntity itemSumbit = new ImplicitKnowledgeEntity();
                        itemSumbit.UserName = currentUserlogin;
                        itemSumbit.Name = Ename.Value;
                        itemSumbit.DateOfBirth = EDateOfBirth.Value;
                        itemSumbit.Designation = EPosition.Value;
                        itemSumbit.EmployeeNumber = Enumber.Value;
                        itemSumbit.MaritalStatus = EMaritalStatus.Value;
                        itemSumbit.Nationality = ENationality.Value;
                        PID = objIK.SaveUpdate(itemSumbit);
                    }
                    else
                    {
                        PID = Convert.ToInt32(TOPID.Value);
                    }
                    //////////////////////////////////2///////////////////////
                    List<EmploymentHistoryEntity> list1 = new List<EmploymentHistoryEntity>();
                    EmploymentHistoryEntity Entit1 = new EmploymentHistoryEntity();
                    if (!string.IsNullOrEmpty(Designation0.Value))
                    {
                        DateTime Datefrom = new DateTime();
                        if (!string.IsNullOrEmpty(Datefrom0.Value))
                        {
                            DateTime sDate = DateTime.ParseExact(Datefrom0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Datefrom = sDate;
                        }
                        DateTime Dateto = new DateTime();
                        if (!string.IsNullOrEmpty(Dateto0.Value))
                        {
                            DateTime sDate2 = DateTime.ParseExact(Dateto0.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                            Dateto = sDate2;
                        }
                        Entit1.DateFrom = Datefrom;
                        Entit1.DateTo = Dateto;
                        Entit1.Designation = Designation0.Value;
                        Entit1.OrganizationalUnit = Organizationalunit0.Value;
                        Entit1.PID = PID;
                        if (!string.IsNullOrEmpty(SID0.Value))
                        {
                            Entit1.ID = Convert.ToInt32(SID0.Value);
                            RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(Entit1.ID + "#", "");
                        }
                        Entit1.Title = currentUserlogin;
                        list1.Add(Entit1);
                    }
                    if (hdnsuperDIV1.Value != "")
                    {
                        string[] SID = Request.Form.GetValues("SID");
                        string[] Designation = Request.Form.GetValues("Designation");
                        string[] Organizationalunit = Request.Form.GetValues("Organizationalunit");
                        string[] Datefrom = Request.Form.GetValues("Datefrom");
                        string[] Dateto = Request.Form.GetValues("Dateto");
                        for (int x = 0; x < Convert.ToInt32(Designation.Length); x++)
                        {
                            if (!string.IsNullOrEmpty(Designation[x]))
                            {
                                EmploymentHistoryEntity ob = new EmploymentHistoryEntity();
                                ob.PID = PID;
                                ob.Title = currentUserlogin;
                                DateTime Datefroma = new DateTime();
                                if (!string.IsNullOrEmpty(Datefrom0.Value))
                                {
                                    DateTime sDate = DateTime.ParseExact(Datefrom[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Datefroma = sDate;
                                }
                                DateTime Datetoa = new DateTime();
                                if (!string.IsNullOrEmpty(Dateto0.Value))
                                {
                                    DateTime sDate2 = DateTime.ParseExact(Dateto[x], "MM/dd/yyyy", CultureInfo.InvariantCulture);
                                    Datetoa = sDate2;
                                }
                                ob.DateFrom = Datefroma;
                                ob.DateTo = Datetoa;
                                ob.Designation = Designation[x];
                                ob.OrganizationalUnit = Organizationalunit[x];
                                if (!string.IsNullOrEmpty(SID[x]))
                                {
                                    ob.ID = Convert.ToInt32(SID[x]);
                                    RetrevehdnsuperDIV1.Value = RetrevehdnsuperDIV1.Value.Replace(ob.ID + "#", "");
                                 }
                                list1.Add(ob);
                            }
                        }
                    }
                    objIK.SaveUpdateEmploymentHistory(list1);
                    if (!string.IsNullOrEmpty(RetrevehdnsuperDIV1.Value))
                    {
                        string[] SIDES = RetrevehdnsuperDIV1.Value.Split('#');
                        List<int> ListSID1 = new List<int>();
                        foreach (string sid in SIDES)
                        {
                            if(Int32.TryParse(sid, out int numValue)){
                                ListSID1.Add(Int32.Parse(sid));
                            }                    
                        }
                        if (ListSID1.Count > 0)
                        {
                            objIK.DeleteitemsFromSublist("EmploymentHistory", ListSID1);
                        }
                    }

                    //////////////////////////////////3///////////////////////

                    if (PID>0)
                    {
                        lblSuccessMsg.Text = SPUtility.GetLocalizedString("$Resources: successfullyMsg", "Resource", SPContext.Current.Web.Language) + "<br />";
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
}
