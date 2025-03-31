using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Query.GetAllAccountsById
{
    public record GetAllAccountsByIdQuery(int id) :IRequest<Account>;
   
}
