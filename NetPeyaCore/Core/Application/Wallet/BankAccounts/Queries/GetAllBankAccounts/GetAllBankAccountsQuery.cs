using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Queries.GetAllBankAccounts
{
    public class GetAllBankAccountsQuery : IRequest<List<BankAccount>>
    {
        int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = Int32.Parse(value.ToString()); }
        }
    }
}
