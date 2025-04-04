
using BankingApp.Application.Exceptions;
using BankingApp.Application.ViewModels.TransactionViewModel;
using BankingApp.Domain.Enum;
using BankingApp.Domain.Models;
using BankingApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Domain.Interface
{
  public  class TransactionRepository : ITransactionRepository
    {
        readonly BankingDbContext _bankingDbContext;

        public TransactionRepository(BankingDbContext bankingDbContext)
        {
            _bankingDbContext = bankingDbContext;
        }

        public async Task<TransactionAddModel> AddTransactionAsync(int accountId, TransactionAddModel transactions)
        {
            {
                var transaction = new Transaction
                {
                    AccountId = accountId,
                    TransactionType = transactions.TransactionType,
                    Amount = transactions.Amount,
                    Description = transactions.Description,
                    Date = DateTime.Now


                };
                var account = await _bankingDbContext.Account.FirstOrDefaultAsync(x => x.Id == accountId);
                if (account == null)
                {
                    throw new NotFoundException($"Account Of id={accountId} not found!!!");
                }
                if (account.Balance < transaction.Amount)
                {
                   throw new InsufficientBalance("Insufficient Balance!!!!");
                   

                }
                account.Balance -= transaction.Amount;

                await _bankingDbContext.AddAsync(transaction);
                await _bankingDbContext.SaveChangesAsync();
                return transactions;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _bankingDbContext.Transaction.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionByAccountIdAsync(int accountId)
        {
            var transactions = await _bankingDbContext.Transaction.Include(e => e.Account).Where(x => x.AccountId == accountId).ToListAsync();
            if (transactions.Count == 0)
            {
                throw new NotFoundException("Add some Transactions First");
            }
            return transactions;
        }

        public async Task<int> TransferToAnotherAccountToAccountNumber(int accountId, TransactionTransferModel transferModel)
        {
            var transaction = new Transaction
            {
                AccountId = accountId,
                TransactionType = TransactionTypes.Debit,
                Amount = transferModel.Amount,
                Description = $"Transfer to {transferModel.AccountNumber}",
                Date = DateTime.Now


            };
            var account = await _bankingDbContext.Account.FirstOrDefaultAsync(x => x.Id == accountId);
            if (account == null)
            {
                throw new NotFoundException($"Account Of id={accountId} not found!!!");
            }
            if (account.Balance < transaction.Amount)
            {
                throw new InsufficientBalance("Insufficient Balance!!!!");

            }
            var toAccount = await _bankingDbContext.Account.FirstOrDefaultAsync(x => x.AccountNumber == transferModel.AccountNumber);
            if (toAccount == null)
            {
                throw new NotFoundException($"Account Of id={accountId} not found!!!");
            }

            account.Balance -= transaction.Amount;
            toAccount.Balance += transaction.Amount;


            var toTransaction = new Transaction
            {
                AccountId = toAccount.Id,
                TransactionType = TransactionTypes.credit,
                Amount = transferModel.Amount,
                Description = $"Transfer From {account.AccountNumber}",
                Date = DateTime.Now


            };
            await _bankingDbContext.AddAsync(toTransaction);

            await _bankingDbContext.AddAsync(transaction);
            return await _bankingDbContext.SaveChangesAsync();
        }
    }
}
