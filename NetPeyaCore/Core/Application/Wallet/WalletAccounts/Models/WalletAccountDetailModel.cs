using Core.Domain.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccounts.Models
{
    public class WalletAccountDetailModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public Currency Currency { get; set; }
        public WalletAccountCategory WalletAccountCategory { get; set; }
        public string WalletAccountCode { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set; }
    }
}
