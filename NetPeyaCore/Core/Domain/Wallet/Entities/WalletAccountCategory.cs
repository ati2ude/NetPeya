using Core.Persistence.Wallet;
using System;
using System.Linq;

namespace Core.Domain.Wallet.Entities
{
    public class WalletAccountCategory : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool RegistrationDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public WalletAccountCategory GetWalletAccountCategory(WalletDbContext _context)
        {
            return _context.WalletAccountCategories.SingleOrDefault(b => b.RegistrationDefault == true);
        }
    }
}
