using API.Controllers.Wallet.CurrenciesController;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Domain.Wallet.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;

namespace API.APIResponse.Wallet
{
    public class CurrenciesResponse : NPResponse
    {
        protected IStringLocalizer<CurrenciesController> _currencyLocalizer;

        public CurrenciesResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<CurrenciesController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _currencyLocalizer = localizer;

            Currency currency;

            try
            {
                currency = obj as Currency;
            }
            catch (Exception)
            {
                currency = new Currency { ID = 0 };
            }

            var responseObj = currency;
            if (currency != null)
            {
                responseObj = currency.ID == 0 ? null : currency;
            }

            if (obj is ICollection)
            {
                key = "Currencies";
                Response.Add(_currencyLocalizer[key].Value, obj);
            }
            else
            {
                Response.Add(_currencyLocalizer[key].Value, responseObj);
            }
        }
    }
}
