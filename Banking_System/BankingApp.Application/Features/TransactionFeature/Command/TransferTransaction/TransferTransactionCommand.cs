using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.ViewModels.TransactionViewModel;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Command.TransferTransaction
{
    public record TransferTransactionCommand(int accountId, TransactionTransferModel TransferModel) : IRequest<int>;

}
