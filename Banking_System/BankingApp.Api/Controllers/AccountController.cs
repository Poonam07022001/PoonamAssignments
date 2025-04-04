using BankApp.Identity.Models;
using BankingApp.Application.Features.AccountFeature.Command.AddAccount;
using BankingApp.Application.Features.AccountFeature.Command.DeleteAccount;
using BankingApp.Application.Features.AccountFeature.Command.UpdateAccount;
using BankingApp.Application.Features.AccountFeature.Query;
using BankingApp.Application.Features.AccountFeature.Query.GetAllAccountByUserId;
using BankingApp.Application.Features.AccountFeature.Query.GetAllAccounts;
using BankingApp.Application.Features.AccountFeature.Query.GetAllAccountsById;
using BankingApp.Application.ViewModels.AccountViewModels;
using BankingApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAccount()
        {
          var allGetAccounts= await _mediator.Send(new GetAllAccountsQuery());
            return Ok(allGetAccounts);

        }
        [Authorize(Roles = "User")]
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddBooksAsync(AccountAddModel account)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userId);


            var accounttt = await _mediator.Send(new AddAccountCommand(user.Id, account));
            return Ok(accounttt);
        }

        [Authorize(Roles = "Administartor")]
        [HttpGet("GetAllAccountsById")]
        public async Task<IActionResult> GetAllAccountsById(int id)
        {
            var account = await _mediator.Send(new GetAllAccountsByIdQuery(id));
            return Ok(account);
        }
        [Authorize(Roles = "User")]
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

        [Authorize(Roles = "User")]
        [HttpGet("MyAccounts")]
        public async Task<IActionResult> GetAllAccountsByUserId()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userId);
            var account = await _mediator.Send(new GetAccountByUserIdQuery(user.Id));
            return Ok(account);
        }
    }
}
