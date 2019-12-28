using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class CouncilMembers
    {
        public bool SaveUpdate(CouncilMembersEntity obj)
        {
            return new CouncilMembersDataManager().AddOrUpdate(obj);
        }
                                                      
        public CouncilMembersEntity GetMemberID(int knowledgeCouncilID,  string loginName)
        {
            return new CouncilMembersDataManager().GetMemberID(knowledgeCouncilID, loginName);
        }
 


    }
}
