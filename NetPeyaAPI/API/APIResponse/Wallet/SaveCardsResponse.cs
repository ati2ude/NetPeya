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
    public class SavedCardsResponse : NPResponse
    {
        protected IStringLocalizer<SavedCardsController> _recipientLocalizer;

        public SavedCardsResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<SavedCardsController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            SavedCard card;

            try
            {
                card = obj as SavedCard;
            }
            catch (Exception)
            {
                card = new SavedCard { ID = 0 };
            }

            var responseObj = card;
            if (card != null)
            {
                responseObj = card.ID == 0 ? null : card;
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
