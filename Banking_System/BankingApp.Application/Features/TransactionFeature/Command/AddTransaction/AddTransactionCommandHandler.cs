using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.ViewModels.TransactionViewModel;
using BankingApp.Domain.Interface;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Command.AddTransaction
{
   public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, TransactionAddModel>
    {
        readonly ITransactionRepository _transactionRepository;

        public AddTransactionCommandHandler (ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionAddModel> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.AddTransactionAsync(request.accountId, request.TransactionAddModel);
        }
    }
}
