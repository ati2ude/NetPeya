using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Wallet.Users.Commands.RegisterUser;
using Core.Application.Wallet.Users.Queries.GetUserDetails;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class UsersController : WalletBaseController
    {
        // POST api/customers
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery { UserID = id }));
        }
    }
}
