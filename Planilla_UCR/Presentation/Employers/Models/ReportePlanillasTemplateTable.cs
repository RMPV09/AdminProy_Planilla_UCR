using System;

namespace Presentation.Employers.Models
{
    internal class ReportePlanillasTemplateTable
    {

        public string Name { get; set; }
        public double Amount { get; set; }


        public ReportePlanillasTemplateTable()
        {
            this.Name = String.Empty;
            this.Amount = 0.0;

        }

        public ReportePlanillasTemplateTable(string Name, double Amount)
        {
            this.Name = Name;
            this.Amount = Amount;
        }
        public string ToMyString() {
            string returnedString = this.Name + this.Amount.ToString();
            return returnedString;
        }
    }
}