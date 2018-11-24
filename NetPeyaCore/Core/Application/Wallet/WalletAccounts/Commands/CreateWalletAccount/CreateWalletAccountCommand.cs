using Core.Domain.Wallet.Entities;
using MediatR;
using System;

namespace Core.Application.Wallet.WalletAccounts.Commands.CreateWalletAccount
{
    public class CreateWalletAccountCommand : IRequest
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CurrencyID { get; set; }
        public int WalletAccountCategoryID { get; set; }
        public string WalletAccountCode { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

