namespace TransactionWebAPI.Models
{
    public class Transaction
    {

        public int Id { get; set; }

        public int ReceiverAccountNumber { get; set; }
        public string? ReceiverName { get; set; }
        public int Amount { get; set; }

        //public DateTime SendDate { get; set; }

        //public int CurrentBalance { get; set; }
        // public int NewCurrentBalance { get; set; }
    }
}
