using Core.Domain.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Persistence.Wallet.Extensions;
using System.Threading.Tasks;

namespace Core.Persistence.Wallet
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
