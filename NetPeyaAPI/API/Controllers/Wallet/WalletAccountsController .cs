using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Wallet.WalletAccounts.Commands.CreateWalletAccount;
using Core.Application.Wallet.WalletAccounts.Queries;
using Core.Application.Wallet.WalletAccounts.Queries.GetUserWalletAccounts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class WalletAccountsController : WalletBaseController
    {
        // POST api/walletaccounts
        [HttpPost]
        public async Task<IActionResult> create([FromForm]CreateWalletAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new WalletAccountDetailQuery { ID = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserWalletAccounts(int id)
        {
            return Ok(await Mediator.Send(new GetUserWalletAccountsQuery { UserID = id }));
        }
    }
}
