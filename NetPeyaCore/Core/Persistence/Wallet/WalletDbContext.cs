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

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WalletAccountCategory> WalletAccountCategories { get; set; }
        public DbSet<WalletAccount> WalletAccounts { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CardType> CardTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // WalletAccount
            modelBuilder.Entity<Currency>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Currency>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<Currency>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // User
            modelBuilder.Entity<User>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // WalletAccountCategory
            modelBuilder.Entity<WalletAccountCategory>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<WalletAccountCategory>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<WalletAccountCategory>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // WalletAccount
            modelBuilder.Entity<WalletAccount>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<WalletAccount>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<WalletAccount>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // BankAccount
            modelBuilder.Entity<BankAccount>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<BankAccount>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<BankAccount>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // Country
            modelBuilder.Entity<Country>().Property(x => x.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>().Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            // CardType
            modelBuilder.Entity<CardType>().Property(x => x.ID).ValueGeneratedOnAdd();

            modelBuilder.ApplyAllConfigurations();
        }
    }
}
