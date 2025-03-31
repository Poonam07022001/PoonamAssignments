using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.Exceptions;
using BankingApp.Domain.Interface;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Command.DeleteAccount
{
    class DeleteAccountControllerHandler : IRequestHandler<DeleteAccountCommand, int>
    {
        readonly IAccountRepository _accountRepository;

        public DeleteAccountControllerHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<int> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByIdAsync(request.id);
            if (account is null)
            {
                throw new NotFoundException($"Account With {request.id} is not found!!");
            }
            return await _accountRepository.DeleteAccountAsync(account.Id);
        }
    }
}
