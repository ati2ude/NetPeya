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
    public class WalletAccountsResponse :NPResponse
    {

        protected IStringLocalizer<WalletAccountsController> _recipientLocalizer;

        public WalletAccountsResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<WalletAccountsController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _recipientLocalizer = localizer;

            WalletAccount walletAccount;

            try
            {
                walletAccount = obj as WalletAccount;
            }
            catch (Exception)
            {
                walletAccount = new WalletAccount { ID = 0 };
            }

            var responseObj = walletAccount;
            if (walletAccount != null)
            {
                responseObj = walletAccount.ID == 0 ? null : walletAccount;
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
