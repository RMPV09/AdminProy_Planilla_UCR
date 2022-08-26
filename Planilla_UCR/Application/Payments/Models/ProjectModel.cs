using Application.Payments.Models;
using System;
using System.Collections.Generic;

namespace Presentation.Payments.Models
{
    public class ProjectModel
    {
        public string ProjectName { get; set; }
        public string EmployerEmail { get; set; }
        public string PaymentInterval { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public int DayInterval { get; set; }
        public double MountToPay { get; set; }
        public IList<EmployeeAgreement> EmployeeList { get; set; }

        public ProjectModel()
        {
            ProjectName = "";
            EmployerEmail = "";
            PaymentInterval = "";
            LastPaymentDate = DateTime.Now;
            DayInterval = 0;
            MountToPay = 0.0;
            EmployeeList = null;
        }

        public ProjectModel(string projectName, string employerName,
            string paymentInterval, DateTime lastPaymentDate, int dayInterval,
            double mountToPay, IList<EmployeeAgreement> _employeeList)
        {
            ProjectName = projectName;
            EmployerEmail = employerName;
            PaymentInterval = paymentInterval;
            LastPaymentDate = lastPaymentDate;
            DayInterval = dayInterval;
            MountToPay = mountToPay;
            EmployeeList = _employeeList;
        }
    }
}
