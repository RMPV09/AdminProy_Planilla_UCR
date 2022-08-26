using System;

namespace Application.Employees.Models
{
    public class EmployeeList
    {
        public string ProjectName { get; set; }
        public string EmployerName { get; set; }
        public string EmployerLastName1 { get; set; }
        public string EmployerLastName2 { get; set; }
        public string EmployerEmail { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public int MountPerHour { get; set; }

        public EmployeeList()
        {
            this.ProjectName = "";
            this.EmployerName = "";
            this.EmployerLastName1 = "";
            this.EmployerLastName2 = "";
            this.EmployerEmail = "";
            this.ContractType = "";
            this.ContractStartDate = DateTime.Now;
            this.ContractFinishDate = DateTime.Now;
            this.MountPerHour = 0;
        }

        public EmployeeList(string projectName, string employerName, string employerLastName1, string employerEmail,
            string employerLastName2, string contractType, DateTime contractStartDate, 
            DateTime contractFinishDate, int mountPerHour)
        {
            this.ProjectName = projectName;
            this.EmployerName = employerName;
            this.EmployerLastName1 = employerLastName1;
            this.EmployerLastName2 = employerLastName2;
            this.EmployerEmail = employerEmail;
            this.ContractType = contractType;
            this.ContractStartDate = contractStartDate;
            this.ContractFinishDate = contractFinishDate;
            this.MountPerHour = mountPerHour;
        }
    }
}