using API.Controllers.Wallet;
using API.Controllers.Wallet.SharedLocaleController;
using Core.Application.Wallet.Users.Models;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.APIResponse.Wallet
{
    public class UsersResponse : NPResponse
    {
        protected IStringLocalizer<UsersController> _recipientLocalizer;

        public UsersResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<UsersController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            UserDetailsModel userDetails;

            try
            {
                userDetails = obj as UserDetailsModel;
            }
            catch (Exception)
            {
                userDetails = new UserDetailsModel { UserID = 0 };
            }

            var responseObj = userDetails;
            if (userDetails != null)
            {
                responseObj = userDetails.UserID == 0 ? null : userDetails;
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
