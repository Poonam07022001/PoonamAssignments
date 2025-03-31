using BankingApp.Application.Features.AccountFeature.Command.AddAccount;
using BankingApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankingApp.Application.Features.AccountFeature.Command.UpdateAccount;
using BankingApp.Application.Features.AccountFeature.Query;
using BankingApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankingApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAccount()
        {
          var allGetAccounts= await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allGetAccounts);

        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddBooksAsync(AccountAddModel account)
        {
            var result = await _mediator.Send(new AddAccountCommand(account));
            return Ok(result);
        }

          [HttpGet("GetAllAccountsById")]
        public async Task<IActionResult> GetAllAccountsById(int id)
        {
            var account = await _mediator.Send(new GetAllAccountsByIdQuery(id));
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _mediator.Send(new DeleteAccountCommand(id));
            return Ok(account);
        }
        [HttpPut ("Update")]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateModel account)
        {

            var accounts = await _mediator.Send(new UpdateAccountCommand(id, account));
            return Ok(accounts);
        }
    }
}
