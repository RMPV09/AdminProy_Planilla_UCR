using System;

namespace Domain.Agreements.Entities
{
    public class Agreement
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public String ContractType { get; set; }
        public int MountPerHour { get; set; }
        public DateTime? ContractFinishDate { get; set; }
        public int IsEnabled { get; set; }
        public string Justification { get; set; }

        public Agreement(string employeeEmail, string employerEmail, string projectName, DateTime? contractStartDate, string contractType, int mountPerHour, DateTime? contractFinishDate, int isEnabled, string justification)
        {
            this.EmployeeEmail = employeeEmail;
            this.EmployerEmail = employerEmail;
            this.ProjectName = projectName;
            this.ContractStartDate = contractStartDate;
            this.ContractType = contractType;
            this.MountPerHour = mountPerHour;
            this.ContractFinishDate = contractFinishDate;
            this.IsEnabled = isEnabled;
            this.Justification = justification;
        }
    }
}
