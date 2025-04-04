using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Models;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Query.GetAllTransactions
{
    public record GetAllTransactionsQuery() : IRequest<IEnumerable<Transaction>>;

}
