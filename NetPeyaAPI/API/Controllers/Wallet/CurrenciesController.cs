using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Wallet.Currencies.Commands.CreateCurrency;
using Core.Application.Wallet.Currencies.Commands.DeleteCurrency;
using Core.Application.Wallet.Currencies.Commands.Models;
using Core.Application.Wallet.Currencies.Queries.GetAllCurrenciesQuery;
using Core.Application.Wallet.Currencies.Queries.GetSingleCurrency;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CurrenciesController : WalletBaseController
    {
        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSingleCurrencyQuery { CurrencyID = id }));
        }

        // GET api/currencies/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCurrenciesQuery()));
        }

        // POST api/currencies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCurrencyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/currencies/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCurrencyCommand command)
        {
            command.ID = id;

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/currencies/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCurrencyCommand { CurrencyID = id }));
        }
    }
}
