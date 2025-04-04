using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Interface;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Command.AddAccount
{
    public class AddAccountControllerHandler : IRequestHandler<AddAccountCommand, AccountAddModel>
    {
        readonly IAccountRepository _accountRepository;
        public AddAccountControllerHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

 
        public async Task<AccountAddModel> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            //var acc = await _accountRepository.AddAccountAsync(request.UId, request.account);
            var acc = await _accountRepository.AddAccountAsync(request.UId, request.account);
            return acc;
        }

    }
}
