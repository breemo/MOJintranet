using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public struct SharedConstants
    {
        #region MOJ Lists Columns

        #region Common
        public const string ID = "ID";
        public const string Title = "Title";
        public const string Title_En = "TitleEn";
        public const string Created = "Created";
        public const string ISActive = "isActive";
        public const string Body = "Body";
        public const string BodyEn = "BodyEn";
        public const string Date = "Date";
        public const string Description = "Description";
        public const string DescriptionEn = "DescriptionEn";
        public const string Name = "Name";
        public const string PageName = "PageName";
        public const string OccasionID = "OccasionID";

        #endregion

        #region News
        #endregion

        #region Memos
        public const string MemoNumber = "MemoNumber";
        #endregion

        #region StickyNotes
        public const string TitleAr = "Title Ar";
        public const string TitleEn = "Title En";
        #endregion

        //public const string Description = "Description";
        //public const string EventDate = "EventDate";
        //public const string EndDate = "EndDate";
        //public const string Active = "Active";
        //public const string Question = "Question";
        //public const string Answer = "Answer";
        //public const string FIELD_INTERNALNAME_IMAGE_OR_VIDEO_ID = "ImageOrVideoId";
        //public const string Details = "Details";
        //public const string Summary = "Summary";
        //public const string PressReleaseDocumentType = "PressReleaseDocumentType";

        #endregion

        #region Url
        //"../../../_layouts/YSA.SP.Portal/en/images/No-attachment-1.png";
        public const string URL_NO_IMAGE = "_layouts/15/images/NoImage.png";

        #endregion

        #region Lists
        //by ibrahim
        public const string NewsListUrl = "/Lists/News/AllItems.aspx";
        public const string MemosListUrl = "/Lists/Circulars/AllItems.aspx";
        public const string PhotoGalleryListUrl = "MOJGallery/Forms/Thumbnails.aspx";
        public const string OccasionsListUrl = "/Lists/MinistryOccasions/AllItems.aspx";
        public const string OccasionCommentsListUrl = "/Lists/OccasionComments/AllItems.aspx";

        //updated by samir...Sticky Notes List
        public const string SouqListUrl = "/Lists/Souq/AllItems.aspx";

        public const string CarOrderServiceName = "CarOrderService";

        public const string StickyNotesListUrl = "/Lists/Sticky%20Notes/AllItems.aspx";

        public const string MeetingsListUrl = "/Lists/Meetings/calendar.aspx";

        public const string MinistryFilesListUrl = "/Lists/MinistryFiles/AllItems.aspx";

        public const string DepartmentsListUrl = "/Lists/Departments/AllItems.aspx";

        public const string ServicesListUrl = "/Lists/Services/AllItems.aspx";
        public const string ExternalLinksListUrl = "/Lists/ExternalLinks/AllItems.aspx";

        public const string HostingRequestUrl = "/Lists/HostingRequest/AllItems.aspx";
        public const string DepartmentsUrl = "/Lists/Departments/AllItems.aspx";
        public const string ExpertsUrl = "/Lists/Experts/AllItems.aspx";
        public const string RoomBookingUrl = "/Lists/RoomBooking/AllItems.aspx";
        public const string AffirmationSocialSituationUrl = "/Lists/AffirmationSocialSituation/AllItems.aspx";
        public const string ImplicitKnowledgeUrl = "/Lists/ImplicitKnowledge/AllItems.aspx";
        public const string EmploymentHistoryUrl = "/Lists/EmploymentHistory/AllItems.aspx";
        public const string QualificationsUrl = "/Lists/Qualifications/AllItems.aspx";
        public const string TravelInformationsUrl = "/Lists/TravelInformations/AllItems.aspx";
        public const string ParticipationsUrl = "/Lists/Participations/AllItems.aspx";
        public const string MembershipUrl = "/Lists/Membership/AllItems.aspx";
        public const string HopisUrl = "/Lists/Hopis/AllItems.aspx";
        public const string VoluntaryWorkUrl = "/Lists/VoluntaryWork/AllItems.aspx";
        public const string PublicationsUrl = "/Lists/Publications/AllItems.aspx";
        public const string ExpertiseUrl = "/Lists/Expertise/AllItems.aspx";
        public const string TrainingCoursesUrl = "/Lists/TrainingCourses/AllItems.aspx";
        public const string LanguageSkillsUrl = "/Lists/LanguageSkills/AllItems.aspx";
        public const string TechnicalSkillsUrl = "/Lists/TechnicalSkills/AllItems.aspx";
        public const string OtherSkillsUrl = "/Lists/OtherSkills/AllItems.aspx";
        public const string HusbandORWifeUrl = "/Lists/HusbandORWife/AllItems.aspx";
        public const string ParticipantsCouncilUrl = "/Lists/ParticipantsCouncil/AllItems.aspx";
        public const string SiteAssetsUrl = "/SiteAssets/Forms/AllItems.aspx";
        public const string HappinessHotlineUrl = "/Lists/HappinessHotline/AllItems.aspx";
        public const string SonsUrl = "/Lists/Sons/AllItems.aspx";
        public const string WorkflowTasksUrl = "/WorkflowTasks/AllItems.aspx";
        public const string MyRequestsUrl = "/Lists/AllRequest/AllItems.aspx";
        public const string CarOrderServiceUrl = "/Lists/CarOrderService/AllItems.aspx";
        public const string FazaaCardRequestUrl = "/Lists/FazaaCardRequest/AllItems.aspx";
        public const string ContactWithHRUrl = "/Lists/ContactWithHR/AllItems.aspx";
        public const string GovernmentHousingUrl = "/Lists/AffirmationReceiptGovernmentHousing/AllItems.aspx";
        public const string EmiratesUrl = "/Lists/Emirates/AllItems.aspx";
        public const string ReserveHotelUrl = "/Lists/ReserveHotel/AllItems.aspx";
        public const string ReserveHotelPeopleUrl = "/Lists/ReserveHotelPeople/AllItems.aspx";
        public const string AffirmationReceiptGovernmentHousingUrl = "/Lists/AffirmationReceiptGovernmentHousing/AllItems.aspx";
        public const string ReturnFromLeaveUrl = "/Lists/ReturnFromLeave/AllItems.aspx";
        public const string DaysUrl = "/Lists/Days/AllItems.aspx";
        public const string VacationsTypesUrl = "/Lists/VacationsTypes/AllItems.aspx";
        public const string BenefitFromTheCouncilFeedbackUrl = "/Lists/BenefitFromTheCouncilFeedback/AllItems.aspx";
        public const string ExitPermitReasonUrl = "/Lists/ExitPermitReason/AllItems.aspx";
        public const string CountrysUrl = "/Lists/Countrys/AllItems.aspx";
        public const string levelsUrl = "/Lists/level/AllItems.aspx";
        public const string ReturnToDutyNoticeMembersOfTheJudiciaryUrl = "/Lists/ReturnToDutyNoticeMembersOfTheJudiciary/AllItems.aspx";
        public const string PeriodicalFormForGovernmentHousingUrl = "/Lists/PeriodicalFormForGovernmentHousing/AllItems.aspx";
        public const string EmployeeUrl = "/Lists/EmployeesProfile/AllItems.aspx";
        public const string knowledgeCouncilUrl = "/Lists/knowledgeCouncil/AllItems.aspx";
        public const string CouncilExamUrl = "/Lists/CouncilExam/AllItems.aspx";
        public const string CouncilFeedbackUrl = "/Lists/CouncilFeedback/AllItems.aspx";
        public const string CouncilMembersUrl = "/Lists/CouncilMembers/AllItems.aspx";
        public const string CouncilTypeUrl = "/Lists/CouncilType/AllItems.aspx";
        public const string StatusAskAnExpertUrl = "/Lists/StatusAskAnExpert/AllItems.aspx";
        public const string AskAnExpertUrl = "/Lists/AskAnExpert/AllItems.aspx";
        public const string DepartmentsDescriptionUrl = "/Lists/DepartmentsDescription/AllItems.aspx";
        public const string AskAnExpertAnswerUrl = "/Lists/AskAnExpertAnswer/AllItems.aspx";
        public const string CouncilExamAnswerUrl = "/Lists/CouncilExamAnswer/AllItems.aspx";
        public const string CouncilExaminersUrl = "/Lists/CouncilExaminers/AllItems.aspx";
        public const string RequestAVacationUrl = "/Lists/RequestAVacation/AllItems.aspx";
        public const string SpeechTypeUrl = "/Lists/SpeechType/AllItems.aspx";
        public const string CertificateToWhomItMayConcernUrl = "/Lists/CertificateToWhomItMayConcern/AllItems.aspx";
        public const string SpeechLanguageUrl = "/Lists/SpeechLanguage/AllItems.aspx";
        public const string RequestTypeUrl = "/Lists/RequestType/AllItems.aspx";
        public const string OrganizationTypeUrl = "/Lists/OrganizationType/AllItems.aspx";

        #endregion

        #region Query

        public const string DepartmentsQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        public const string Departmentsfields = "<FieldRef Name='Title'/><FieldRef Name='ID'/>";

        public const string DepartmentProceduresQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        public const string DepartmentProceduresfields = "<FieldRef Name='Title'/><FieldRef Name='ProcedureDate'/><FieldRef Name='ProcedureBody'/><FieldRef Name='ID'/>";

        public const string DepartmentCircularsQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        public const string DepartmentCircularsfields = "<FieldRef Name='Title'/><FieldRef Name='CircularDate'/><FieldRef Name='CircularBody'/><FieldRef Name='ID'/>";

        public const string NewsQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string NewsViewfields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Date'/><FieldRef Name='Body'/><FieldRef Name='TitleEn'/><FieldRef Name='Date'/><FieldRef Name='BodyEn'/><FieldRef Name='Created' LinkToItem='true'/>";

        public const string MemosQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        public const string MemosViewfields = "<FieldRef Name='Title'/><FieldRef Name='TitleEn'/><FieldRef Name='MemoNumber'/><FieldRef Name='Date'/><FieldRef Name='ID'/><FieldRef Name='Body'/><FieldRef Name='BodyEn'/>";

        public const string SouqQuery = @"<Where>
                                                      <Eq>
                                                         <FieldRef Name='SouqAppr'/>
                                                         <Value Type='WorkflowStatus'>16</Value>
                                                      </Eq>
                                                   </Where>
                                                    <OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";

        //public const string MinistryFilesQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        public const string MinistryFilesQuery = @"<Where>
                                                      <Eq>
                                                         <FieldRef Name='Ministry'/>
                                                         <Value Type='WorkflowStatus'>16</Value>
                                                      </Eq>
                                                   </Where>
                                                    <OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";




        public const string MinistryFilesViewfields = "<FieldRef Name='Title'/><FieldRef Name='Book_x0020_Title_x0020_En'/><FieldRef Name='Book_x0020_Desc_x0020_Ar'/><FieldRef Name='Book_x0020_Desc_x0020_En'/><FieldRef Name='Book_x0020_Image'/><FieldRef Name='Author'/><FieldRef Name='ID'/><FieldRef Name='Category'/><FieldRef Name='Author0'/>";

        //updated by samir...StickyNotes...Query
        public const string StickyNotesQuery = @"<Query>
                                                   <Where>
                                                      <Eq>
                                                         <FieldRef Name = 'IsDeleted' />
                                                         < Value Type='Bool'>FALSE</Value>
                                                      </Eq>
                                                   </Where>
                                                   <OrderBy>
                                                      <FieldRef Name = 'Created' Ascending='False' />
                                                   </OrderBy>
                                                </Query>";

        //<FieldRef Name='Title_x0020_En'/>
        public const string StickyNotesViewfields = "<FieldRef Name='Title'/><FieldRef Name='Author'/><FieldRef Name='IsDeleted'/><FieldRef Name='Date'/><FieldRef Name='ID'/>";

        public const string MeetingsQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string MeetingsViewfields = "<FieldRef Name='Title'/><FieldRef Name='EventDate'/><FieldRef Name='Author'/>";

        public const string GalleryQuery = @"<Where>" +
                                                    "<Eq><FieldRef Name='isActive'/><Value Type='Integer'>1</Value></Eq>" +
                                                "</Where>" +
                                            "<OrderBy><FieldRef Name='Created' Ascending='False'/></OrderBy>";

        public const string GalleryViewfields = "<FieldRef Name='Title'/><FieldRef Name='Created'/><FieldRef Name='isActive'/>";

        public const string OccasionsQuery = @"<Where>
                                                  <Eq>
                                                     <FieldRef Name='Approval' />
                                                     <Value Type='WorkflowStatus'>16</Value>
                                                  </Eq>
                                               </Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
        //public const string OccasionCommentsQuery = @"<Where>
                                                  //     <Eq>
	                                              //         <FieldRef Name='OccasionId' />
	                                              //         <Value Type='Boolean'>1</Value>
                                                  //     </Eq>
                                                  // </Where><OrderBy><FieldRef Name='Order0' Ascending='True' /></OrderBy>";

        public const string OccasionsViewfields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Description'/><FieldRef Name='TitleEn'/><FieldRef Name='DescriptionEn'/><FieldRef Name='Created' LinkToItem='true'/>";

        public const string LiveEventsQuery = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";

        public const string ServicesQuery = @"<Where>
                                                <Eq>
	                                                <FieldRef Name='isActive' />
	                                                <Value Type='Boolean'>1</Value>
                                                </Eq>
                                            </Where><OrderBy><FieldRef Name='Order0' Ascending='True' /></OrderBy>";
        #endregion


        #region CssClass
        //public const string CSS_CLASS_BOX_IMG = "box_img";
        //public const string CSS_CLASS_PEOPLE_IMG = "people-img";
        //public const string CSS_CLASS_BOX_PAGE_CONTENT = "box_page_content";
        //public const string CSS_CLASS_OTHER_SERVICE_IMG = "otherServiceImg";
        //public const string CSS_CLASS_OTR_SRV = "otr_srv";
        //public const string CSS_CLASS_PHOTO_GALLERY_IMG = "photoGallery-img";
        //public const string CSS_CLASS_PHOTO_DIV = "photo_div";
        //public const string CSS_CLASS_ = "";
        #endregion

        #region List Internal Name
        public const string LIST_INTERNAL_NAME_EMPLOYEE_OF_THE_MONTH = "EmployeeOfTheMonth";
        public const string LIST_INTERNAL_NAME_OTHER_SERVICES = "OtherServices";
        public const string LIST_INTERNAL_NAME_EMPLOYMENT_UPDATES = "EmploymentUpdates";
        public const string LIST_INTERNAL_NAME_PHOTO_GALLERY = "PhotoGallery";
        public const string LIST_INTERNALNAME_POLLS = "Polls";
        public const string LIST_INTERNAL_NAME_ = "";
        public const string LIST_INTERNAL_NAME_HDSupportRequest = "SupportRequest";
        #endregion

        #region List Display Name
        public const string LIST_DISPLAY_NAME_EMPLOYEE_OF_THE_MONTH = "Employee Of The Month";
        public const string LIST_DISPLAY_NAME_OTHER_SERVICES = "Other Services";
        public const string LIST_DISPLAY_NAME_EMPLOYMENT_UPDATES = "Employment Updates";
        public const string LIST_DISPLAY_NAME_PHOTO_GALLERY = "Photo Gallery";
        public const string LIST_DISPLAY_NAME_ = "";
        #endregion

        #region Field Internal Name
        public const string FIELD_INTERNAL_NAME_MONTH = "Month";
        public const string FIELD_INTERNAL_NAME_CREATED = "Created";
        public const string FIELD_INTERNAL_NAME_YEAR = "Year";
        public const string FIELD_INTERNAL_NAME_IMAGE_URL = "ImageUrl";
        public const string FIELD_INTERNAL_NAME_LINK_URL = "LinkUrl";
        public const string FIELD_INTERNAL_NAME_TITLE = "Title";
        public const string FIELD_INTERNAL_NAME_COMMENT = "Comment";
        public const string FIELD_INTERNAL_NAME_EMPLOYEE = "Employee";
        public const string FIELD_INTERNAL_NAME_EMPLOYEENAME = "EmployeeName";
        public const string FIELD_INTERNAL_NAME_ALLOW_TO_DISPLAY = "AllowToDisplay";
        public const string FIELD_INTERNAL_NAME_NAME = "Name";
        public const string FIELD_INTERNAL_NAME_SERVER_URL = "ServerUrl";
        public const string FIELD_INTERNAL_NAME_LINK_FILE_NAME = "LinkFilename";
        public const string FIELD_INTERNAL_NAME_ENCODED_ABS_WEB_IMG_URL = "EncodedAbsWebImgUrl";
        public const string FIELD_INTERNAL_NAME_ENCODED_ABS_THUMBNAIL_URL = "EncodedAbsThumbnailUrl";

        public const string FIELD_INTERNALNAME_ID = "ID";
        public const string FIELD_INTERNALNAME_TITLE = "Title";
        public const string FIELD_INTERNALNAME_ANS1 = "PollAns1";
        public const string FIELD_INTERNALNAME_ANS2 = "PollAns2";
        public const string FIELD_INTERNALNAME_ANS3 = "PollAns3";
        public const string FIELD_INTERNALNAME_ANS4 = "PollAns4";
        public const string FIELD_INTERNALNAME_ANS1TOTAL = "Ans1Total";
        public const string FIELD_INTERNALNAME_ANS2TOTAL = "Ans2Total";
        public const string FIELD_INTERNALNAME_ANS3TOTAL = "Ans3Total";
        public const string FIELD_INTERNALNAME_ANS4TOTAL = "Ans4Total";
        public const string FIELD_INTERNAL_NAME_ = "";

        public const string PreferredName = "PreferredName";
        public const string PictureURL = "PictureURL";
        public const string UserPictureURL = "SPS-JobTitle";



        #region YSA Lists URLs
        public const string EventsCalendarListUrl = "/Lists/EventsCalendar/calendar.aspx";
        public const string AnnouncementListUrl = "/Lists/Announcements/AllItems.aspx";

        public const string MyCalendarListUrl = "/Lists/MyCalendar/calendar.aspx";
        public const string QAsListUrl = "/Lists/QA/AllItems.aspx";
        public const string QAsCategoriesListUrl = "/Lists/FAQsCategories/AllItems.aspx";
        public const string PressReleaseListUrl = "/Lists/PressRelease/AllItems.aspx";
        public const string PressReleaseDocument = "PressReleaseDocument";

        #endregion

        #region YSA Query
        public const string AnnouncementQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string AnnouncementViewfields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Date'/><FieldRef Name='Body'/><FieldRef Name='Created' LinkToItem='true'/>";


        public const string EventsCalendarQuery = "<OrderBy><FieldRef Name='ID' Ascending='True' /></OrderBy>";
        public const string EventsCalendarfields = "<FieldRef Name='Title'/><FieldRef Name='Active'/><FieldRef Name='EventDate'/><FieldRef Name='EndDate'/><FieldRef Name='Description'/><FieldRef Name='ID'/>";


        public const string MyCalendarQuery = "<OrderBy><FieldRef Name='ID' Ascending='True' /></OrderBy>";
        public const string MyCalendarfields = "<FieldRef Name='Title'/><FieldRef Name='Active'/><FieldRef Name='EventDate'/><FieldRef Name='Description'/><FieldRef Name='ID'/>";

        public const string QAsQuery = "<OrderBy><FieldRef Name='Question' Ascending='True' /></OrderBy>";
        public const string QAsfields = "<FieldRef Name='Question'/><FieldRef Name='Category_x003a_ID'/><FieldRef Name='Active'/><FieldRef Name='Answer'/><FieldRef Name='ID'/>";

        public const string QAsCatQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string QAsCatfields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Created' LinkToItem='true'/>";

        public const string PressReleaseQuery = "<OrderBy><FieldRef Name='ID' Ascending='True' /></OrderBy>";
        public const string PressReleasefields = "<FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='Summary' /><FieldRef Name='Date' /><FieldRef Name='Details' /><FieldRef Name='ImageOrVideoId' /><FieldRef Name='PressReleaseDocumentType' /><FieldRef Name='Year' />";

        public const string HDSupportrequestSubmittedQuery = "<Where><Eq><FieldRef Name='Status'></FieldRef><Value Type='Text'>Submitted</Value></Eq></Where>";
        public const string HDSupportrequestSubmittedQueryViewfields = "<FieldRef Name='Created' /><FieldRef Name='Author' /><FieldRef Name='Department' /><FieldRef Name='Description' /><FieldRef Name='ID' /><FieldRef Name='Office' /><FieldRef Name='RequestDate' /><FieldRef Name='Status'/>";


        #endregion

        public const string Location = "Location";
        public const string StartTime = "Start Time";
        public const string EndTime = "End Time";
        public const string Category = "Category";
        public const string fAllDayEvent = "fAllDayEvent";
        public const string fRecurrence = "fRecurrence";
        public const string WorkspaceLink = "WorkspaceLink";

        public const string Ceosubsite = "Posts";
        public const string CeoImage = "<img id=\"imgLiteral\" src=\"/PublicImages/chairman.jpg\" width=\"240px\" height=\"164px\" class=\"box_img\" />";

        public const string CalendarNext = "<img src='/_layouts/Images/DragonOil/CalendarNext.png'/>";
        public const string CalendarPrevious = "<img src='/_layouts/Images/DragonOil/CalendarPrevious.png'/>";
        public const string CalendarListUrl = "/_layouts/Calendarevents.aspx";

        public const string AnnouncementRowStyle = "border-top-style:none; height:auto; margin:0px 10px 10px; border-bottom:#CCC dotted 1px; padding-bottom:15px; border-left-style:none; border-right-style:none;";

        public const string ArchiveStartdate = "-01-01T14:48:52Z";
        public const string ArchiveEnddate = "-12-31T14:49:51Z";

        public const string ExportEvent = "myFunction()";

        public const string ExportTurkEvent = "ExportTurkData()";

        public const string ExportAshgEvent = "ExportAshgData()";

        public const string ContactRowStyle = "border-top-style:none; height:auto; margin:0px 10px 10px; border-bottom:#CCC dotted 1px; padding-bottom:15px; border-left-style:none; border-right-style:none;";

        public const string Mission_Internalname = "Mission";

        public const string RSSTitle = "./title";
        public const string RSSLink = "./link";
        public const string RSSDesc = "./description";
        public const string RSSPubDate = "./pubDate";

        public const string FirstName = "FirstName";
        public const string FullName = "FullName";
        public const string Email = "Email";
        public const string Extension = "Extension";
        public const string JobTitle = "JobTitle";
        public const string WorkPhone = "WorkPhone";
        public const string CellPhone = "CellPhone";

        #endregion



        #region ListUrl

        public const string CeoBlogUrl = "/Posts/default.aspx";
        public const string DirectoryListUrl = "/Lists/Directory/AllItems.aspx";
        //public const string EventListUrl = "/Lists/Events/AllItems.aspx";
        public const string FieldNewsListUrl = "/Lists/FieldNews/AllItems.aspx";
        public const string HSEAnnouncementListUrl = "/Lists/HSEAnnouncements/AllItems.aspx";
        public const string MissionListUrl = "/Lists/Mission/AllItems.aspx";
        public const string EmployeeUpdate = "/Lists/EmploymentUpdates/AllItems.aspx";
        public const string EmployeeOfTheMonth = "/Lists/EmployeeOfTheMonth/AllItems.aspx";
        public const string PAGE_URL_DEFAULT = "/Pages/default.aspx";

        #endregion

        #region Caml Query

        public const string HSEAnnouncementQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string HSEAnnouncementViewfields = "<FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Body'/><FieldRef Name='Created' LinkToItem='true'/>";

        public const string FieldnewsQuery = "<OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy>";
        public const string FieldnewsViewfields = "<FieldRef Name='Title'/><FieldRef Name='Body'/><FieldRef Name='Created' LinkToItem='true'/>";

        public const string MissionQuery = "<OrderBy><FieldRef Name='Mission' Ascending='False' /></OrderBy>";
        public const string MissionViewfields = "<FieldRef Name='Mission'/>";

        // public const string DirectoryQuery = "<Query><Where><IsNotNull><FieldRef Name='ID' /></IsNotNull></Where></Query>";
        // public const string DirectoryViewfields = "<FieldRef Name='FirstName'/><FieldRef Name='LinkTitle'/><FieldRef Name='JobTitle'/><FieldRef Name='Extension'/>" +
        //                                "<FieldRef Name='CellPhone'/><FieldRef Name='Email'/>";

        #endregion



        #region isteyaq
        public const string CAMAL_QUERY_EN_STRATEGY = "<Query><OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy></Query>";
        //public const string CAMAL_QUERY_EN_ADVERTISEMENT = "<Query><OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy></Query>";
        //public const string CAMAL_QUERY_EN_ADVERTISEMENT = "<Query><Where><Eq><FieldRef Name='Active' /><Value Type='Choice'>Yes</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='False' /></OrderBy></Query>"; 
        public const string CAMAL_QUERY_EN_ADVERTISEMENT = "<Query><Where><Eq><FieldRef Name='Active' /><Value Type='Choice'>Yes</Value></Eq></Where></Query>";


        #region Content type name
        public const string CONTENTTYPE_NAME_VIDEO = "Video";
        public const string CONTENTTYPE_NAME_PICTURE = "Picture";
        public const string CONTENTTYPE_NAME_ = "";
        #endregion

        #region querystring name
        public const string QUERYSTRING_NAME_V = "v";
        public const string QUERYSTRING_NAME_I = "i";
        #endregion

        #region gallaryType
        public const string GALLARY_TYPE_IMAGE = "Image";
        public const string GALLARY_TYPE_VIDEO = "Video";
        #endregion

        public const string DirectoryQuery = "<Query><Where><IsNotNull><FieldRef Name='ID' /></IsNotNull></Where></Query>";
        public const string DirectoryViewfields = "<FieldRef Name='FirstName'/><FieldRef Name='LinkTitle'/><FieldRef Name='JobTitle'/><FieldRef Name='Extension'/>" +
                                        "<FieldRef Name='CellPhone'/><FieldRef Name='Email'/>";

        public const string FIELD_INTERNALNAME_DESCRIPTION = "Description";
        public const string FIELD_INTERNALNAME_IMAGECREATEDATE = "ImageCreateDate";

        public const string LIST_INTERNAL_NAME_STRATEGY = "Strategy";
        public const string LIST_INTERNAL_NAME_ADVERTISEMENTS = "Advertisements";
        public const string LIST_INTERNALNAME_IMAGEGALLERY = "ImageGallery";
        public const string LIST_INTERNALNAME_VIDEOGALLERY = "VideoGallery";

        public const string CSS_CLASS_ROUNDED_CORNERS_TL = "roundedCornersTL";
        public const string CSS_CLASS_ROUNDED_CORNERS_TR = "roundedCornersTR";
        public const string CSS_CLASS_SELECTED = "selected";
        public const string CSS_CLASS_VIDEOTHUMNIL = "videoThumnil";
        public const string CSS_CLASS_IMAGE01 = "image01";
        public const string CSS_CLASS_IMAGE0 = "image0";
        public const string CSS_CLASS_AD_ACTIVE = "ad-active";


        public const string PAGE_URL_GALLERY = "/Pages/Gallery.aspx";
        public const string PAGE_URL_VIEO_GALLERY = "/Pages/videoGallery.aspx";






        #endregion

        /* Madeswaran */

        public const string StrategyListUrl = "/Strategy/Forms/AllItems.aspx";
        public const string StrategyQuery = "<Query><Where><IsNotNull><FieldRef Name='ID' /></IsNotNull></Where></Query>";
        public const string StrategyURLFieldName = "FileRef";

        public const string AdvertisementListUrl = "/Advertisements/Forms/AllItems.aspx";
        public const string AdvertisementQuery = "<Query><Where><IsNotNull><FieldRef Name='ID' /></IsNotNull></Where></Query>";
        public const string AdvertisementURLFieldName = "FileRef";


        /* Madeswaran */
    }
}
