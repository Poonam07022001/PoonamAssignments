using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.AccountFeature.Query.GetAllAccounts
{
    public record GetAllAccountsQuery() : IRequest<IEnumerable<Account>>;

}
