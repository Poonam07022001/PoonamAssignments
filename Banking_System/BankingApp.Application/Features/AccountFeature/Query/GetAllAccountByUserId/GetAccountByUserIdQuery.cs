using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Query.GetAllAccountByUserId
{
    public record GetAccountByUserIdQuery(string uId) : IRequest<IEnumerable<Account>>;

}
