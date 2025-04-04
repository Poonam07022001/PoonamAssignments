using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Query.GetAllTransactions
{
  public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return _transactionRepository.GetAllTransactions();
        }
    }
}
