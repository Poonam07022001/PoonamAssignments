using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Query.GetAllAccountsById
{
  public  class GetAllAccountsByIdQueryHandler:IRequestHandler<GetAllAccountsByIdQuery, Account>
    {
        readonly IAccountRepository _accountRepository;
        public GetAllAccountsByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(GetAllAccountsByIdQuery request, CancellationToken cancellationToken)
        {
            var GetAllAccountById = await _accountRepository.GetAccountByIdAsync(request.id);
            return GetAllAccountById;
        }
    }
}
