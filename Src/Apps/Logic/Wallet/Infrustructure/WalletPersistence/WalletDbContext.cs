using Microsoft.EntityFrameworkCore;
using WalletDomain.Entities;
using WalletPersistence.Extensions;

namespace WalletPersistence
{
    class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
        }

        public DbSet<WalletUser> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
