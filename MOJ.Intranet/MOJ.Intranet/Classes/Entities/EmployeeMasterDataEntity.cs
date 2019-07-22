using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Entities
{
    public class EmployeeMasterDataEntity
    {
        public string employeeNumberField { get; set; }
        public string employeeNameArabicField { get; set; }
        public string employeeNameEnglishField { get; set; }
        public string departmentIDField { get; set; }
        public string departmentNameField_US { get; set; }
        public string departmentNameField_AR { get; set; }
        public string positionIDField { get; set; }
        public string positionNameField_US { get; set; }
        public string positionNameField_AR { get; set; }
        public string employementDateField { get; set; }
        public string ManagerID_DirectManager { get; set; }
        public string ManagerName_DirectManager { get; set; }
        public string ManagerEmail_DirectManager { get; set; }
        public string ManagerID_HigherManager { get; set; }
        public string ManagerName_HigherManager { get; set; }
        public string ManagerEmail_HigherManager { get; set; }
        public string nationality_ARField { get; set; }
        public string nationality_USField { get; set; }
        public string dateOfBirthField { get; set; }
        public string maritalStatus_USField { get; set; }
        public string maritalStatus_ARField { get; set; }
        public string employeeEmailField { get; set; }
        public string contactNumberField { get; set; }
        public string statusField { get; set; }
    }
}
