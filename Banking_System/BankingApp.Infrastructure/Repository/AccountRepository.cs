
using BankApp.Identity.Models;
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Models;
using BankingApp.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Domain.Interface
{
    public class AccountRepository : IAccountRepository
    {
        readonly BankingDbContext _bankingDbContext;
        readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(BankingDbContext bankingDbContext, UserManager<ApplicationUser> userManager)
        {
            _bankingDbContext = bankingDbContext;
            _userManager = userManager;
        }

        public async Task<AccountAddModel> AddAccountAsync(string UId,AccountAddModel accounts)
        {
            var addAccount = new Account
            {
                UserId = UId,
                AccountNumber = accounts.AccountNumber,
                Balance = accounts.Balance,
                AccountType = accounts.AccountTypes,
                CreatedDate = DateTime.Now

            };
            await _bankingDbContext.Account.AddAsync(addAccount);
            await _bankingDbContext.SaveChangesAsync();
            return accounts;
        }

        public async Task<int> DeleteAccountAsync(int accountId)
        {
            var account1 = await GetAccountByIdAsync(accountId);
            if (account1 != null)
            {
                _bankingDbContext.Account.Remove(account1);
                return await _bankingDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _bankingDbContext.Account.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Account>> GetAccountByUserIdAsync(string id)
        {
            var list = await _bankingDbContext.Account.Where(s => s.UserId == id).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _bankingDbContext.Account.ToListAsync();
        }

        public async Task<int> UpdateAccountAsync(int id, AccountUpdateModel accounts)
        {
            var updateaccount = await GetAccountByIdAsync(id);
            if (updateaccount == null)
            {
                throw new DllNotFoundException($"Account id {id} not found!!");
            }
            updateaccount.Balance = accounts.Balance;
            updateaccount.AccountType = accounts.AccountTypes;
            _bankingDbContext.Account.Update(updateaccount);
            return await _bankingDbContext.SaveChangesAsync();
        }
    }
}
