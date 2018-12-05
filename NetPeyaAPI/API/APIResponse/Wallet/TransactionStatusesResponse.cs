using API.Controllers.Wallet;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Domain.Wallet.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;

namespace API.APIResponse.Wallet
{
    public class TransactionStatusesResponse : NPResponse
    {
        protected IStringLocalizer<TransactionStatusesController> _recipientLocalizer;

        public TransactionStatusesResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<TransactionStatusesController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            TransactionStatus statusType;

            try
            {
                statusType = obj as TransactionStatus;
            }
            catch (Exception)
            {
                statusType = new TransactionStatus { ID = 0 };
            }

            var responseObj = statusType;
            if (statusType != null)
            {
                responseObj = statusType.ID == 0 ? null : statusType;
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
