using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Wallet.Currencies.Commands.CreateCurrency;
using Core.Application.Wallet.Currencies.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CurrenciesController : WalletBaseController
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/currencies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CurrencyCommandRequestModel command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/currencies/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CurrencyCommandRequestModel command)
        {
            command.ID = id;

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
