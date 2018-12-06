using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Wallet.Users.Commands.RegisterUser;
using Core.Application.Wallet.Users.Queries.GetUserDetails;
using Microsoft.Extensions.Localization;
using Core.Application.Wallet.Users.Models;
using API.APIResponse.Wallet;
using Core.Domain.Wallet.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class UsersController : WalletBaseController
    {
        private readonly IStringLocalizer<UsersController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public UsersController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<UsersController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }

        [HttpGet("{id}")]
        [Route("api/wallet/users/{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery { UserID = id }));
        }

        [HttpPost]
        [Route("api/wallet/users/register")]
        public async Task<IActionResult> Register([FromForm]RegisterUserCommand command)
        {
            if (ModelState.IsValid)
            {
                User taskReturn = await Mediator.Send(command);
                return Ok(new UsersResponse(nameof(User), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
