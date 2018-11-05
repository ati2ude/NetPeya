using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Entities;

namespace WalletPersistence.Configurations
{
    class WalletUserConfiguration : IEntityTypeConfiguration<WalletUser>
    {
        public void Configure(EntityTypeBuilder<WalletUser> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasMaxLength(5)
                .ValueGeneratedNever();

            builder.Property(e => e.FirstName).HasMaxLength(60)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.LastName).HasMaxLength(15)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Phone).HasMaxLength(30);

            builder.Property(e => e.Password).HasMaxLength(30);

            builder.Property(e => e.Country).HasMaxLength(15);

            builder.Property(e => e.DefaultCurrency).HasMaxLength(24);
        }
    }
}
