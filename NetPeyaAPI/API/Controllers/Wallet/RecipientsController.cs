using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Recipients;
using Core.Application.Wallet.Recipients.Commands.CreateRecipient;
using Core.Application.Wallet.Recipients.Commands.DeleteRecipient;
using Core.Application.Wallet.Recipients.Commands.UpdateRecipient;
using Core.Application.Wallet.Recipients.Queries.GetMultipleRecipientsQuery;
using Core.Application.Wallet.Recipients.Queries.GetSingleRecipientQuery;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet.RecipientsController
{
    public class RecipientsController : WalletBaseController
    {
        private readonly IStringLocalizer<RecipientsController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public RecipientsController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<RecipientsController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }
        
        [HttpPost]
        [Route("api/wallet/recipients")]
        public async Task<IActionResult> GetRecipients([FromForm] GetMultipleRecipientsQuery command)
        {
            List<Recipient> taskReturn = await Mediator.Send(command);
            return Ok(new RecipientsResponse(nameof(Recipient), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
        }
        
        [HttpGet("{id}")]
        [Route("api/wallet/recipients/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            Recipient taskReturn = await Mediator.Send(new GetSingleRecipientQuery { ID = id });
            return Ok(new RecipientsResponse(nameof(Recipient), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
        }
        
        [HttpPost]
        [Route("api/wallet/recipients/add")]
        public async Task<IActionResult> Create([FromForm] CreateRecipientCommand command)
        {
            if (ModelState.IsValid)
            {
                Recipient taskReturn = await Mediator.Send(command);
                return Ok(new RecipientsResponse(nameof(Recipient), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        
        [HttpPut("{id}")]
        [Route("api/wallet/recipients/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateRecipientCommand command)
        {
            command.ID = id;

            if (ModelState.IsValid)
            {
                Recipient taskReturn = await Mediator.Send(command);
                return Ok(new RecipientsResponse(nameof(Recipient), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        
        [HttpDelete("{id}")]
        [Route("api/wallet/recipients/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Recipient taskReturn = await Mediator.Send(new DeleteRecipientCommand { ID = id });
                return Ok(new RecipientsResponse(nameof(Recipient), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
