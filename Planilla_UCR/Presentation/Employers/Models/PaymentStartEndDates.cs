using System;

namespace Presentation.Employers.Models
{
    internal class PaymentStartEndDates
    {

        public String? StartDate { get; set; }
        public String? EndDate { get; set; }

        public PaymentStartEndDates()
        {
            this.StartDate = String.Empty;
            this.EndDate = String.Empty;
        }

        public PaymentStartEndDates(String StartDate, String EndDate)
        {
            this.StartDate=StartDate;
            this.EndDate=EndDate;
        }
    }
}