namespace TransactionWebAPI.Services
{
    public interface ITransactionService
    {
        List<Models.Transaction> GetTransactions();
        Models.Transaction? GetTransaction(int id);
        Models.Transaction AddTransaction(Models.Transaction transaction);

        Models.Transaction UpdateTransaction(Models.Transaction transaction);

        bool? DeleteTransaction(int id);
    }
}
