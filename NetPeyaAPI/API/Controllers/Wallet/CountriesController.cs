using System.Threading.Tasks;
using Core.Application.Wallet.Countries.Commands;
using Core.Application.Wallet.Countries.Commands.DeleteCountry;
using Core.Application.Wallet.Countries.Commands.UpdateUser;
using Core.Application.Wallet.Countries.Queries;
using Core.Application.Wallet.Countries.Queries.GetAllCountries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CountriesController : WalletBaseController
    {
        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSingleCountryQuery { ID = id }));
        }

        // GET api/currencies/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCountriesQuery()));
        }

        // POST api/countries/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCountryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/countries/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCountryCommand command)
        {
            command.ID = id;

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/countries/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCountryCommand { ID = id }));
        }
    }
}
