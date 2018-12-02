using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.CardTypes.Commands.CreateCardType;
using Core.Application.Wallet.CardTypes.Commands.DeleteCardType;
using Core.Application.Wallet.CardTypes.Commands.UpdateCardType;
using Core.Application.Wallet.CardTypes.Queries.GetAllCardTypes;
using Core.Application.Wallet.CardTypes.Queries.GetSingleCardType;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class CardTypesController : WalletBaseController
    {
        private readonly IStringLocalizer<CardTypesController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public CardTypesController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<CardTypesController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }

        // GET api/cardtypes/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                CardType taskReturn = await Mediator.Send(new GetSingleCardTypeQuery { ID = id });
                return Ok(new CardTypesResponse(nameof(CardType), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET api/cardtypes/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                List<CardType> taskReturn = await Mediator.Send(new GetMultipleCardTypesQuery());

                if (taskReturn.Count > 0)
                {
                    return Ok(new CardTypesResponse(nameof(CardType), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    CardType cardType = new CardType { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new CardTypesResponse(nameof(cardType), cardType, cardType.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/cardtypes/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCardTypeCommand command)
        {
            if (ModelState.IsValid)
            {
                CardType taskReturn = await Mediator.Send(command);
                return Ok(new CardTypesResponse(nameof(CardType), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/cardtypes/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCardTypeCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                CardType taskReturn = await Mediator.Send(command);
                return Ok(new CardTypesResponse(nameof(CardType), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/cardtypes/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                CardType taskReturn = await Mediator.Send(new DeleteCardTypeCommand { ID = id });
                return Ok(new CardTypesResponse(nameof(CardType), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
