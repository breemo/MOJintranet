using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MOJ.DataManager;
using MOJ.Entities;

namespace MOJ.Business 
{
    public class Task
    {
        public bool SaveUpdate(TaskEntity obj)
        {
            return new TaskDataManager().AddOrUpdateHostingRequest(obj);
        }
        public TaskEntity GetTask(int id)
        {
            return new TaskDataManager().GetTaskByID(id);
        }
        public List<TaskEntity> GetMyTasks(string isCompleted)
        {
            return new TaskDataManager().GetMyTasks(isCompleted);
        }
        public List<TaskEntity> GetTasksRequest(string ID, string Name ,string All="Yes" )
        {
            return new TaskDataManager().GetTasksRequest(ID , Name,All);
        }
        public bool HavePermission(int TID)
        {
            return new TaskDataManager().TaskPermission(TID);

        }
    }
}
