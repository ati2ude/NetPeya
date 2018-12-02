using API.Controllers.Wallet.RecipientsController;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Application.StatusCodes.Recipients;
using Core.Domain.Wallet.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;

namespace API.APIResponse.Recipients
{
    public class RecipientsResponse : NPResponse
    {
        protected IStringLocalizer<RecipientsController> _recipientLocalizer;

        public RecipientsResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<RecipientsController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            switch (state)
            {
                case RecipientStatusCodes.MissingEmailandPhone:
                    Response.Add(_baseLocalizer["Status"].Value, _baseLocalizer["Failed"].Value);
                    Response.Add(_baseLocalizer["Message"].Value, _recipientLocalizer["please_provide_either_email_or_phone"].Value);
                    break;
                default:
                    break;
            }
            
            Recipient recipient;

            try
            {
                recipient = obj as Recipient;
            }
            catch (Exception)
            {
                recipient = new Recipient { ID = 0 };
            }

            var responseObj  = recipient;
            if (recipient != null)
            {
                responseObj = recipient.ID == 0 ? null : recipient;
            }

            if(obj is ICollection)
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
