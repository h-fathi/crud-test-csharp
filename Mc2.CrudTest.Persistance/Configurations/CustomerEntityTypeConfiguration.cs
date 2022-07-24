using Mc2.CrudTest.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Mc2.CrudTest.Persistance.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<CustomerState>
    {
        public void Configure(EntityTypeBuilder<CustomerState> builder)
        {
            builder.ToTable("Customers");

            builder.Property(x => x.Id).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.Firstname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();    
            builder.Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.BankAccountNumber).HasMaxLength(20).IsRequired();

        }
    }
}
