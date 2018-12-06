using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.SavedCards.Commands.CreateSavedCard;
using Core.Application.Wallet.SavedCards.Commands.DeleteSavedCard;
using Core.Application.Wallet.SavedCards.Commands.UpdateSavedCard;
using Core.Application.Wallet.SavedCards.Queries.GetSingleSavedCard;
using Core.Application.Wallet.SavedCards.Queries.GetUserSavedCards;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class SavedCardsController : WalletBaseController
    {
        private readonly IStringLocalizer<SavedCardsController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public SavedCardsController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<SavedCardsController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }
        
        [HttpGet("{id}")]
        [Route("api/wallet/savedcards/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                SavedCard taskReturn = await Mediator.Send(new GetSingleSavedCardQuery { ID = id });
                return Ok(new SavedCardsResponse(nameof(SavedCard), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpGet("{user_id}")]
        [Route("api/wallet/savedcards/getbyuser/{id}")]
        public async Task<IActionResult> GetByUserID(int user_id)
        {
            if (ModelState.IsValid)
            {
                List<SavedCard> taskReturn = await Mediator.Send(new GetUserSavedCardsQuery { UserID = user_id });

                if (taskReturn != null && taskReturn.Count > 0)
                {
                    return Ok(new SavedCardsResponse(nameof(SavedCard), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    SavedCard currency = new SavedCard { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new SavedCardsResponse(nameof(SavedCard), currency, currency.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPost]
        [Route("api/wallet/savedcards/add")]
        public async Task<IActionResult> Create([FromForm] CreateSavedCardCommand command)
        {
            if (ModelState.IsValid)
            {
                SavedCard taskReturn = await Mediator.Send(command);
                return Ok(new SavedCardsResponse(nameof(SavedCard), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpPut("{id}")]
        [Route("api/wallet/savedcards/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateSavedCardCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                SavedCard taskReturn = await Mediator.Send(command);
                return Ok(new SavedCardsResponse(nameof(SavedCard), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpDelete("{id}")]
        [Route("api/wallet/savedcards/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                SavedCard taskReturn = await Mediator.Send(new DeleteSavedCardCommand { ID = id });
                return Ok(new SavedCardsResponse(nameof(SavedCard), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
