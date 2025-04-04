using BankingApp.Application.Features.TransactionFeature.Command.AddTransaction;
using BankingApp.Application.Features.TransactionFeature.Command.TransferTransaction;
using BankingApp.Application.Features.TransactionFeature.Query.GetAllTransactionByAccountId;
using BankingApp.Application.Features.TransactionFeature.Query.GetAllTransactions;
using BankingApp.Application.ViewModels.TransactionViewModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionController : Controller
    {
        readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTransaction")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var Transactions = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(Transactions);
        }

        [HttpGet("GetByAccountId")]
        public async Task<IActionResult> GetAllTransactionsByAccountID(int accountId)
        {
            var transaction = await _mediator.Send(new GetAllTransactionByAccountIdQuery(accountId));
            return Ok(transaction);
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromQuery] int id, [FromBody] TransactionAddModel transactionAddModel)
        {
            var transaction = await _mediator.Send(new AddTransactionCommand(id, transactionAddModel));
            return Ok(transaction);
        }

        [HttpPost("Transfer")]

        public async Task<IActionResult> TransferAmount([FromQuery] int id, [FromBody] TransactionTransferModel transferModel)
        {
            var transaction = await _mediator.Send(new TransferTransactionCommand(id, transferModel));
            return Ok(transaction);
        }
    }
}
