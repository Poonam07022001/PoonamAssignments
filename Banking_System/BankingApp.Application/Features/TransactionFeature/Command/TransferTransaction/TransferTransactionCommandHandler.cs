﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Interface;
using MediatR;

namespace BankingApp.Application.Features.TransactionFeature.Command.TransferTransaction
{
    public class TransferTransactionCommandHandler : IRequestHandler<TransferTransactionCommand, int>
    {
        readonly ITransactionRepository _transactionRepository;

        public TransferTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<int> Handle(TransferTransactionCommand request, CancellationToken cancellationToken)
        {
            return _transactionRepository.TransferToAnotherAccountToAccountNumber(request.accountId, request.TransferModel);
        }

    }
}
