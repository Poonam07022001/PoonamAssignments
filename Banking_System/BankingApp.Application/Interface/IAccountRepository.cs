
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Models;

namespace BankingApp.Domain.Interface
{
   public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountByIdAsync(int id);
        Task<AccountAddModel> AddAccountAsync(AccountAddModel accounts);
        Task<int> UpdateAccountAsync(int id, AccountUpdateModel accounts);
        Task<int> DeleteAccountAsync(int accountId);
    }
}
