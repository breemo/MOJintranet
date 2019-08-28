﻿using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Inner_Pages.OccasionsDetails
{
    public partial class OccasionsDetailsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillDetails();
        }
        public void FillDetails()
        {
            try
            {
                string ID = Request.QueryString["Id"].ToString();
                //string Type = Request.QueryString["Type"].ToString();
                OccasionsEntity occasionItem = new Occasions().GetOccasionById(Convert.ToInt32(ID));

                lblTitle.Text = occasionItem.Title;
                lblBody.Text = occasionItem.Description;

                //Convert.ToDateTime(occasionItem.Created).ToString("dd-MMM-yyyy")
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("New Joiners web part :", ex.Message);
            }
        }
    }
}
