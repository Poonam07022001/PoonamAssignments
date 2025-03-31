using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.ViewModels.AccountViewModels;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Command.UpdateAccount
{
    public record UpdateAccountCommand(int id, AccountUpdateModel accounts) : IRequest<int>;


}
