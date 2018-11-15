using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence.Wallet
{
    public class WalletDbContextFactory : DesignTimeDbContextFactoryBase<WalletDbContext>
    {
        protected override WalletDbContext CreateNewInstance(DbContextOptions<WalletDbContext> options)
        {
            return new WalletDbContext(options);
        }
    }
}
