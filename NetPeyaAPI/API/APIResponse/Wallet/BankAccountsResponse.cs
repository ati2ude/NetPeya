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
    public class BankAccountsResponse : NPResponse
    {
        protected IStringLocalizer<BankAccountsController> _bankAccountLocalizer;

        public BankAccountsResponse(string key, object obj, int state, IStringLocalizer<SharedLocaleController> baseLocalizer, IStringLocalizer<BankAccountsController> localizer)
            : base(key, obj, state, baseLocalizer)
        {
            _bankAccountLocalizer = localizer;

            BankAccount bankAccount;

            try
            {
                bankAccount = obj as BankAccount;
            }
            catch (Exception)
            {
                bankAccount = new BankAccount { ID = 0 };
            }

            var responseObj = bankAccount;
            if (bankAccount != null)
            {
                responseObj = bankAccount.ID == 0 ? null : bankAccount;
            }

            if (obj is ICollection)
            {
                key = "BankAccounts";
                Response.Add(_bankAccountLocalizer[key].Value, obj);
            }
            else
            {
                Response.Add(_bankAccountLocalizer[key].Value, responseObj);
            }
        }
    }
}