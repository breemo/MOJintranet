using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
