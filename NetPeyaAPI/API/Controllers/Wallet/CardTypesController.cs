using System.Threading.Tasks;
using Core.Application.Wallet.CardTypes.Commands.CreateCardType;
using Core.Application.Wallet.CardTypes.Commands.DeleteCardType;
using Core.Application.Wallet.CardTypes.Commands.UpdateCardType;
using Core.Application.Wallet.CardTypes.Queries.GetAllCardTypes;
using Core.Application.Wallet.CardTypes.Queries.GetSingleCardType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CardTypesController : WalletBaseController
    {
        // GET api/cardtypes/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSingleCardTypeQuery { ID = id }));
        }

        // GET api/cardtypes/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCardTypesQuery()));
        }

        // POST api/cardtypes/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCardTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/cardtypes/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCardTypeCommand command)
        {
            command.ID = id;

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/cardtypes/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCardTypeCommand { ID = id }));
        }
    }
}
