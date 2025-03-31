using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Command.AddAccount
{
   public record AddAccountCommand (AccountAddModel account): IRequest<AccountAddModel>;
  
}
