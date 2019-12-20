using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class LeaveBalanceBL
    {
        public string GetLeaveBalance(string EmployeeId)
        {
            return new LeaveBalanceDataManager().LeaveBalance(EmployeeId);
        }
    }
}
