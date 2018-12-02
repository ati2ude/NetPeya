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
    public class CountriesResponse : NPResponse
    {
        protected IStringLocalizer<CountriesController> _recipientLocalizer;

        public CountriesResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<CountriesController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            Country country;

            try
            {
                country = obj as Country;
            }
            catch (Exception)
            {
                country = new Country { ID = 0 };
            }

            var responseObj = country;
            if (country != null)
            {
                responseObj = country.ID == 0 ? null : country;
            }

            if (obj is ICollection)
            {
                key = "Countries";
                Response.Add(_recipientLocalizer[key].Value, obj);
            }
            else
            {
                Response.Add(_recipientLocalizer[key].Value, responseObj);
            }


        }
    }
}
