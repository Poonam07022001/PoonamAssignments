using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Query.GetAllTransactionByAccountId
{
   public class GetAllTransactionByAccountIdQueryHandler : IRequestHandler<GetAllTransactionByAccountIdQuery, IEnumerable<Transaction>>
    {
    
        readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionByAccountIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionByAccountIdQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetTransactionByAccountIdAsync(request.accountId);

        }
    }
}
