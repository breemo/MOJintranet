using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using MOJ.Business;
using MOJ.Entities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.EmployeeBirthdayWP
{
    public partial class EmployeeBirthdayWPUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            OccasionsEntity itemSumbit = new OccasionsEntity();
            itemSumbit.Title = "عيد ميلاد سعيد";
            itemSumbit.TitleEn = "Happy Birthday";
            itemSumbit.Description = "اليوم هو عيد ميلادي";
            itemSumbit.DescriptionEn = "Today is my birthday";

            bool UpdateOccations = new Occasions().AddOccasion(itemSumbit);

            if (UpdateOccations == true)
            {
                Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>");
                Context.Response.Write("<script type='text/javascript'>window.opener.location.reload();</script>");
                Context.Response.Write("<script type='text/javascript'>window.location.reload();</script>");
                Context.Response.Flush();
                Context.Response.End();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Context.Response.Write("<script type='text/javascript'>window.frameElement.commitPopup();</script>");
            Context.Response.Write("<script type='text/javascript'>window.opener.location.reload();</script>");
            Context.Response.Write("<script type='text/javascript'>window.location.reload();</script>");
            Context.Response.Flush();
            Context.Response.End();
        }
    }
}
