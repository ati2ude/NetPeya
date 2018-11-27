using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Queries.GetSingleBankAccount
{
    public class GetSingleBankAccountQuery : IRequest<BankAccount>
    {
        int _bankAccountID;

        public int BankAccountID
        {
            get { return _bankAccountID; }
            set { _bankAccountID = Int32.Parse(value.ToString()); }
        }
    }
}
