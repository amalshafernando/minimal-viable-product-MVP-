using System.Reflection;

namespace TransactionWebAPI.Data
{
    public static class TransactionMockDataService
    {
        public static List<Models.Transaction> Transactions = new List<Models.Transaction>()
        {


            new Models.Transaction{ Id=1, ReceiverAccountNumber =859612, ReceiverName = "Faraz Farooqui", Amount = 1000},
            new Models.Transaction{ Id=2, ReceiverAccountNumber =859615, ReceiverName = "Faysal Qureshi", Amount = 2500},
            new Models.Transaction{ Id=3, ReceiverAccountNumber =859315, ReceiverName = "Fahad Mustafa", Amount = 3500},
            new Models.Transaction{ Id=4, ReceiverAccountNumber =859275, ReceiverName = "Farhan Saeed", Amount = 8500},

        };

    }
}
