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
        public List<TaskEntity> GetMyTasks()
        {
            return new TaskDataManager().GetMyTasks();
        }
        public bool HavePermission(int TID)
        {
            return new TaskDataManager().TaskPermission(TID);

        }
    }
}
