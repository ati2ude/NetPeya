using Core.Domain.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence.Wallet.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.ID)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DefaultCurrency).HasMaxLength(60);
            builder.Property(e => e.Name).HasMaxLength(60);
            builder.Property(e => e.Code).HasMaxLength(60);
        }
    }
}
