using Core.Application.Wallet.BankAccounts.Models;
using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Commands.DeleteBankAccount
{
    public class DeleteBankAccountCommand : IRequest<BankAccount>
    {
        int _bankAccountID;

        public int BankAccountID
        {
            get { return _bankAccountID; }
            set { _bankAccountID = Int32.Parse(value.ToString()); }
        }
    }
}
