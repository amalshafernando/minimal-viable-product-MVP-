using Transaction_WebAPI.Data;
using Transaction_WebAPI.Models;
namespace Transaction_WebAPI.Services
{
    public class TransactionService : ITransactionService

    {
        public List<Models.Transaction> GetTransactions()
        {
            return TransactionMockDataService.Transactions;
        }

        public Models.Transaction? GetTransaction(int id)
        {
            return TransactionMockDataService.Transactions.FirstOrDefault(x => x.Id == id);

        }

        public Models.Transaction AddTransaction(Models.Transaction transaction)
        {
            TransactionMockDataService.Transactions.Add(transaction);
            return transaction;
        }





        public Models.Transaction UpdateTransaction(Models.Transaction transaction)
        {
            Models.Transaction selectedTransaction = TransactionMockDataService.Transactions.FirstOrDefault(x => x.Id == transaction.Id);
            if (selectedTransaction != null)
            {
                selectedTransaction.ReceiverAccountNumber = transaction.ReceiverAccountNumber;
                selectedTransaction.ReceiverName = transaction.ReceiverName;
                selectedTransaction.Amount = transaction.Amount;
                return selectedTransaction;
            }
            return selectedTransaction;
        }


        public bool? DeleteTransaction(int id)
        {
            Models.Transaction selectedTransaction = TransactionMockDataService.Transactions.FirstOrDefault(x => x.Id == id);
            if (selectedTransaction != null)
            {
                TransactionMockDataService.Transactions.Remove(selectedTransaction);
                return true;

            }
            return false;

        }


    }
}
