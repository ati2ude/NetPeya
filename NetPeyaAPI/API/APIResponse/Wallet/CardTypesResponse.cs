using API.Controllers.Wallet;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Domain.Wallet.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;

namespace API.APIResponse.Wallet
{
    public class CardTypesResponse : NPResponse
    {
        protected IStringLocalizer<CardTypesController> _recipientLocalizer;

        public CardTypesResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<CardTypesController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            CardType cardType;

            try
            {
                cardType = obj as CardType;
            }
            catch (Exception)
            {
                cardType = new CardType { ID = 0 };
            }

            var responseObj = cardType;
            if (cardType != null)
            {
                responseObj = cardType.ID == 0 ? null : cardType;
            }

            if (obj is ICollection)
            {
                key += "s";
                Response.Add(_recipientLocalizer[key].Value, obj);
            }
            else
            {
                Response.Add(_recipientLocalizer[key].Value, responseObj);
            }


        }
    }
}
