using Core.Application.Wallet.BankAccounts.Models;
using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Commands.DeleteBankAccount
{
    public class DeleteBankAccountCommand : BankAccount, IRequest<BankAccount>
    {
    }
}
