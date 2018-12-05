using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.APIResponse.Wallet;
using Core.Application.StatusCodes;
using Core.Application.Wallet.PaymentMethods.Commands.CreatePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Commands.DeletePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Commands.UpdatePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Queries.GetAllPaymentMethods;
using Core.Application.Wallet.PaymentMethods.Queries.GetSinglePaymentMethod;
using Core.Domain.Wallet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class PaymentMethodsController : WalletBaseController
    {
        private readonly IStringLocalizer<PaymentMethodsController> _localizer;
        private readonly IStringLocalizer<SharedLocaleController.SharedLocaleController> _baseLocalizer;

        public PaymentMethodsController(
            IStringLocalizer<SharedLocaleController.SharedLocaleController> baseLocalizer,
            IStringLocalizer<PaymentMethodsController> localizer)
        {
            _localizer = localizer;
            _baseLocalizer = baseLocalizer;
        }

        // GET api/wallet/paymentmethods/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                PaymentMethod taskReturn = await Mediator.Send(new GetSinglePaymentMethodQuery { ID = id });
                return Ok(new PaymentMethodsResponse(nameof(PaymentMethod), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET api/wallet/paymentmethods/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                List<PaymentMethod> taskReturn = await Mediator.Send(new GetMultiplePaymentMethodsQuery());

                if (taskReturn.Count > 0)
                {
                    return Ok(new PaymentMethodsResponse(nameof(PaymentMethod), taskReturn, taskReturn.FirstOrDefault().statusCode, _baseLocalizer, _localizer));
                }
                else
                {
                    PaymentMethod method = new PaymentMethod { ID = 0, statusCode = SharedStatusCodes.NotFound };
                    return Ok(new PaymentMethodsResponse(nameof(method), method, method.statusCode, _baseLocalizer, _localizer));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // POST api/wallet/paymentmethods/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePaymentMethodCommand command)
        {
            if (ModelState.IsValid)
            {
                PaymentMethod taskReturn = await Mediator.Send(command);
                return Ok(new PaymentMethodsResponse(nameof(PaymentMethod), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // PUT api/wallet/paymentmethods/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdatePaymentMethodCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;
                PaymentMethod taskReturn = await Mediator.Send(command);
                return Ok(new PaymentMethodsResponse(nameof(PaymentMethod), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/wallet/paymentmethods/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                PaymentMethod taskReturn = await Mediator.Send(new DeletePaymentMethodCommand { ID = id });
                return Ok(new PaymentMethodsResponse(nameof(PaymentMethod), taskReturn, taskReturn.statusCode, _baseLocalizer, _localizer));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
