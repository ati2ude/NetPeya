using System.Threading.Tasks;
using Core.Application.Wallet.PaymentMethods.Commands.CreatePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Commands.DeletePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Commands.UpdatePaymentMethod;
using Core.Application.Wallet.PaymentMethods.Queries.GetAllPaymentMethods;
using Core.Application.Wallet.PaymentMethods.Queries.GetSinglePaymentMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Wallet
{
    public class PaymentMethodsController : WalletBaseController
    {
        // GET api/currencies/get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSinglePaymentMethodQuery { ID = id }));
        }

        // GET api/currencies/getall
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPaymentMethodsQuery()));
        }

        // POST api/paymentmethods/create
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePaymentMethodCommand command)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Mediator.Send(command));
            } else
            {
                return BadRequest(ModelState);
            }
                
        }

        // PUT api/paymentmethods/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdatePaymentMethodCommand command)
        {
            if (ModelState.IsValid)
            {
                command.ID = id;

                return Ok(await Mediator.Send(command));
            } else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/paymentmethods/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePaymentMethodCommand { ID = id }));
        }
    }
}
