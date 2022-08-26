using System;

namespace Application.Payments.Models
{
    public class EmployeeAgreement
    {
        public string ProjectName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName1 { get; set; }
        public string EmployeeLastName2 { get; set; }
        public string FullName { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public int MountPerHour { get; set; }
        public double MountToPay { get; set; }

        public EmployeeAgreement()
        {
            ProjectName = "";
            EmployeeEmail = "";
            EmployeeName = "";
            EmployeeLastName1 = "";
            EmployeeLastName2 = "";
            ContractType = "";
            ContractStartDate = DateTime.Now;
            ContractFinishDate = DateTime.Now;
            MountPerHour = 0;
            MountToPay = 0.0;
        }

        public EmployeeAgreement(string projectName, string employeeEmail, string employeeName,
            string employeeLastName1, string employerLastName2, string contractType,
            DateTime contractStartDate, DateTime contractFinishDate, int mountPerHour, 
            double mountToPay)
        {
            ProjectName = projectName;
            EmployeeName = employeeName;
            EmployeeLastName1 = employeeLastName1;
            EmployeeLastName2 = employerLastName2;
            ContractType = contractType;
            ContractStartDate = contractStartDate;
            ContractFinishDate = contractFinishDate;
            MountPerHour = mountPerHour;
            MountToPay = mountToPay;
        }
    }
}