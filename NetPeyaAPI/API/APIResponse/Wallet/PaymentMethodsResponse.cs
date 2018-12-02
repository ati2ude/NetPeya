using API.Controllers.Wallet;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Domain.Wallet.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.APIResponse.Wallet
{
    public class PaymentMethodsResponse : NPResponse
    {

        protected IStringLocalizer<PaymentMethodsController> _currencyLocalizer;

        public PaymentMethodsResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<PaymentMethodsController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _currencyLocalizer = localizer;

            PaymentMethod paymentMethod;

            try
            {
                paymentMethod = obj as PaymentMethod;
            }
            catch (Exception)
            {
                paymentMethod = new PaymentMethod { ID = 0 };
            }

            var responseObj = paymentMethod;
            if (paymentMethod != null)
            {
                responseObj = paymentMethod.ID == 0 ? null : paymentMethod;
            }

            if (obj is ICollection)
            {
                key += "s";
                Response.Add(_currencyLocalizer[key].Value, obj);
            }
            else
            {
                Response.Add(_currencyLocalizer[key].Value, responseObj);
            }
        }
    }
}
