using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.BankAccounts.Queries.GetAllBankAccounts
{
    public class GetMultipleBankAccountsQuery : IRequest<List<BankAccount>>
    {
        public int? UserID { get; set; }
    }
}
