using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.Wallet.Currencies.Commands.DeleteCurrency;
using Core.Application.Wallet.Currencies.Commands.Models;
using Core.Application.Wallet.Currencies.Queries.GetAllCurrenciesQuery;
using Core.Application.Wallet.Currencies.Queries.GetSingleCurrency;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet.CurrenciesController
{
    public class CurrenciesController : WalletBaseController
    {
        private readonly IStringLocalizer<CurrenciesController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public CurrenciesController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<CurrenciesController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }

        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                Currency taskReturn = await Mediator.Send(new GetSingleCurrencyQuery { CurrencyID = id });
                return Ok(new CurrenciesResponse(nameof(Currency), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET api/currencies/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Currency> taskReturn = await Mediator.Send(new GetMultipleCurrenciesQuery());
                return Ok(new CurrenciesResponse(nameof(Currency), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/currencies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCurrencyCommand command)
        {
            if (ModelState.IsValid)
            {
                Currency taskReturn = await Mediator.Send(command);
                return Ok(new CurrenciesResponse(nameof(Currency), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/currencies/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCurrencyCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                Currency taskReturn = await Mediator.Send(command);
                return Ok(new CurrenciesResponse(nameof(Currency), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/currencies/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Currency taskReturn = await Mediator.Send(new DeleteCurrencyCommand { ID = id });
                return Ok(new CurrenciesResponse(nameof(Currency), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
