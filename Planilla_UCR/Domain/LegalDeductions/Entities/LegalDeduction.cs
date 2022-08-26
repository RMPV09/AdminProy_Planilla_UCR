namespace Domain.LegalDeductions.Entities
{
    public class LegalDeduction
    {
        public string DeductionName { get; set; }
        public double Cost { get; set; }

        public LegalDeduction(string name, double cost)
        {
            DeductionName = name;
            Cost = cost;
        }
        public LegalDeduction()
        {
        }
    }
}
