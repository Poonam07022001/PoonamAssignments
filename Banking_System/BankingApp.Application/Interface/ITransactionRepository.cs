using BankingApp.Application.ViewModels.TransactionViewModel;
using BankingApp.Domain.Models;

namespace BankingApp.Domain.Interface
{
   public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<IEnumerable<Transaction>> GetTransactionByAccountIdAsync(int accountId);
        Task<TransactionAddModel> AddTransactionAsync(int accountId, TransactionAddModel transactions);

        Task<int> TransferToAnotherAccountToAccountNumber(int accountId, TransactionTransferModel transferModel);

    }
}
