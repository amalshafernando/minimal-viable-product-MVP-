namespace Customer_PensionWebAPI.Models
{
    public class Customer
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Date_Of_Birth { get; set; }
            public string? Account_Open_Date { get; set; }
            public int Expected_Retirement_Age { get; set; }
            public string? Payment_Frequency { get; set; }
            public string? Contribution { get; set; }
            public string? Interested_Rate { get; set; }
            public int Retirement_Benefits_Period { get; set; }
            public string? Retirement_Benefits_Interest { get; set; }

    }
}
