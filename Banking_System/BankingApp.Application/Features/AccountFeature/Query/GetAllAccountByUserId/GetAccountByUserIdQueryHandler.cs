using BankingApp.Application.Features.AccountFeature.Query.GetAllAccountByUserId;
using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankApp.Application.Features.AccountFeature.Query.GetAccountsByUserId
{
    public class GetAccountByUserIdQueryHandler : IRequestHandler<GetAccountByUserIdQuery, IEnumerable<Account>>
    {
        readonly IAccountRepository _accountRepository;
        public GetAccountByUserIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IEnumerable<Account>> Handle(GetAccountByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountByUserIdAsync(request.uId);
        }
    }
}