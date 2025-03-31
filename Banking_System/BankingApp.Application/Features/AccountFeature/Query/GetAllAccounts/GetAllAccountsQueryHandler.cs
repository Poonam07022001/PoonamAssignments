using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Query.GetAllAccounts
{
    internal class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
    {
        readonly IAccountRepository _accountRepository;
        public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var allAccount = await _accountRepository.GetAllAccounts();
            return allAccount;

        }
    }
}
