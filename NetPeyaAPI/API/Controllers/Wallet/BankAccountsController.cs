using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount;
using Core.Application.Wallet.BankAccounts.Commands.CreateBankAccount.UpdateBankAccount;
using Core.Application.Wallet.BankAccounts.Commands.DeleteBankAccount;
using Core.Application.Wallet.BankAccounts.Queries.GetAllBankAccounts;
using Core.Application.Wallet.BankAccounts.Queries.GetSingleBankAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class BankAccountsController : WalletBaseController
    {
        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSingleBankAccountQuery { BankAccountID = id }));
        }

        // GET api/currencies/getall
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            return Ok(await Mediator.Send(new GetAllBankAccountsQuery { UserID = userId}));
        }

        // POST api/currencies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBankAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/currencies/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBankAccountCommand command)
        {
            command.ID = id;

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/currencies/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteBankAccountCommand { BankAccountID = id }));
        }
    }
}
