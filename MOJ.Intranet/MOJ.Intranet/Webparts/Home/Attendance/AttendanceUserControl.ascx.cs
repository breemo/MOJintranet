using MOJ.Business;
using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MOJ.Intranet.Webparts.Home.Attendance
{
    public partial class AttendanceUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                currentUserData();
            }
        }
        private void currentUserData()
        {
            try
            {
                List<EmployeeMasterDataEntity> EmployeeValues = new EmployeeMasterData().GetCurrentEmployeeMasterDataByEmployeeNumber();
                foreach (EmployeeMasterDataEntity item in EmployeeValues)
                {
                    string EmployeeNumber = item.employeeNumberField.ToString();
                    LeaveBalanceDataManager LeaveB = new LeaveBalanceDataManager();
                    string LeaveBalance = LeaveB.LeaveBalance(EmployeeNumber);
                    if (LeaveBalance != "")
                    {
                        float NumberOfLeave = float.Parse(LeaveBalance);
                        float BalanceNumber = NumberOfLeave / 100;
                        LeaveBalanceValue.Value = BalanceNumber.ToString();
                    }
                    else
                        LeaveBalanceValue.Value = "0.0";


                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
