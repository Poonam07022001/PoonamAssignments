
using BankingApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Command.AddTransaction
{
    public record AddTransactionCommand(int accountId, TransactionAddModel TransactionAddModel) : IRequest<TransactionAddModel>;

}
