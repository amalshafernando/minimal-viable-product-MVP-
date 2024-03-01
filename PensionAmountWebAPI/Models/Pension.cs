using System.Security.Cryptography;

namespace PensionAmountWebAPI.Models
{
    public class Pension
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Total_Contribution_Period { get; set; }
        public string? Total_Accumulated_Amount { get; set; }
        public string? Expected_Monthly_Retirement_Benefits { get; set; }

    }
}
