using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.Countries.Commands;
using Core.Application.Wallet.Countries.Commands.DeleteCountry;
using Core.Application.Wallet.Countries.Commands.UpdateUser;
using Core.Application.Wallet.Countries.Queries;
using Core.Application.Wallet.Countries.Queries.GetAllCountries;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CountriesController : WalletBaseController
    {
        private readonly IStringLocalizer<CountriesController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public CountriesController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<CountriesController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }
        
        [HttpGet]
        [Route("api/wallet/countries")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                List<Country> taskReturn = await Mediator.Send(new GetMultipleCountriesQuery());

                if (taskReturn.Count > 0)
                {
                    return Ok(new CountriesResponse(nameof(Country), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    Country country = new Country { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new CountriesResponse(nameof(Country), country, country.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        [Route("api/wallet/countries/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                Country taskReturn = await Mediator.Send(new GetSingleCountryQuery { ID = id });
                return Ok(new CountriesResponse(nameof(Country), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPost]
        [Route("api/wallet/countries/add")]
        public async Task<IActionResult> Create([FromForm]CreateCountryCommand command)
        {
            if (ModelState.IsValid)
            {
                Country taskReturn = await Mediator.Send(command);
                return Ok(new CountriesResponse(nameof(Country), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPut("{id}")]
        [Route("api/wallet/countries/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCountryCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                Country taskReturn = await Mediator.Send(command);
                return Ok(new CountriesResponse(nameof(Country), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        [Route("api/wallet/countries/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Country taskReturn = await Mediator.Send(new DeleteCountryCommand { ID = id });
                return Ok(new CountriesResponse(nameof(Country), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
