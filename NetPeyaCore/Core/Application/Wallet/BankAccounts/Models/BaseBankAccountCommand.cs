using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Models
{
    public class BaseBankAccountCommand : BankAccount, IRequest<BankAccount>
    {
    }
}
