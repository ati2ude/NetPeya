using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount;
using Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount.UpdateBankAccount;
using Core.Application.Wallet.BankAccounts.Commands.DeleteBankAccount;
using Core.Application.Wallet.BankAccounts.Queries.GetAllBankAccounts;
using Core.Application.Wallet.BankAccounts.Queries.GetSingleBankAccount;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class BankAccountsController : WalletBaseController
    {
        private readonly IStringLocalizer<BankAccountsController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public BankAccountsController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<BankAccountsController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }

        // GET api/wallet/bankaccounts/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                BankAccount taskReturn = await Mediator.Send(new GetSingleBankAccountQuery { BankAccountID = id });
                return Ok(new BankAccountsResponse(nameof(BankAccount), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET api/wallet/bankaccounts/getall
        [HttpPost]
        public async Task<IActionResult> GetAll([FromForm] GetMultipleBankAccountsQuery command)
        {
            if (ModelState.IsValid)
            {
                List<BankAccount> taskReturn = await Mediator.Send(command);

                if(taskReturn.Count > 0)
                {
                    return Ok(new BankAccountsResponse(nameof(BankAccount), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    BankAccount account = new BankAccount { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new BankAccountsResponse(nameof(BankAccount), account, account.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/wallet/bankaccounts/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBankAccountCommand command)
        {
            if (ModelState.IsValid)
            {
                BankAccount taskReturn = await Mediator.Send(command);
                return Ok(new BankAccountsResponse(nameof(BankAccount), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/wallet/bankaccounts/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBankAccountCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                BankAccount taskReturn = await Mediator.Send(command);
                return Ok(new BankAccountsResponse(nameof(BankAccount), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/wallet/bankaccounts/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                BankAccount taskReturn = await Mediator.Send(new DeleteBankAccountCommand { ID = id });
                return Ok(new BankAccountsResponse(nameof(BankAccount), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
