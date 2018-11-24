using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class WalletAccountCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool RegistrationDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
