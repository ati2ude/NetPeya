using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.TransactionStatuses.Commands.CreateTransactionStatus;
using Core.Application.Wallet.TransactionStatuses.Queries.GetAllTransactionStatuses;
using Core.Application.Wallet.TransactionStatuses.Queries.GetSingleTransactionStatus;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class TransactionStatusesController : WalletBaseController
    {
        private readonly IStringLocalizer<TransactionStatusesController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public TransactionStatusesController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<TransactionStatusesController> localizer)
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
                TransactionStatus taskReturn = await Mediator.Send(new GetSingleTransactionStatusQuery { ID = id });
                return Ok(new TransactionStatusesResponse(nameof(TransactionStatus), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
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
                List<TransactionStatus> taskReturn = await Mediator.Send(new GetAllTransactionStatusesQuery());

                if (taskReturn != null && taskReturn.Count > 0)
                {
                    return Ok(new TransactionStatusesResponse(nameof(TransactionStatus), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    TransactionStatus status = new TransactionStatus { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new TransactionStatusesResponse(nameof(Currency), status, status.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/currencies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTransactionStatusCommand command)
        {
            if (ModelState.IsValid)
            {
                TransactionStatus taskReturn = await Mediator.Send(command);
                return Ok(new TransactionStatusesResponse(nameof(TransactionStatus), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
