namespace GoldLoanWebAPI.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string?  Gross_Weight {get; set;}
        public int Amount_Payble { get; set; }
    }
}
