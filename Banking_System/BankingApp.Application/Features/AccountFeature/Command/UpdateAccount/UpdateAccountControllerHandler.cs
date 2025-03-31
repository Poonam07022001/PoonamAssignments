using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Interface;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Command.UpdateAccount
{
   public class UpdateAccountControllerHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        readonly IAccountRepository _accountRepository;
        public UpdateAccountControllerHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {

            return await _accountRepository.UpdateAccountAsync(request.id, request.accounts);
        }
    }
}
