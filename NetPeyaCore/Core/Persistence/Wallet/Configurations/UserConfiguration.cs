using Core.Domain.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Persistence.Wallet.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.ID)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).HasMaxLength(60);
            builder.Property(e => e.LastName).HasMaxLength(60);
            builder.Property(e => e.Email).HasMaxLength(60);
            builder.Property(e => e.CountryID).HasMaxLength(3);
        }
    }
}
