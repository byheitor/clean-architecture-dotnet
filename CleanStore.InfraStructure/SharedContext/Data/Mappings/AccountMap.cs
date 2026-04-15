using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Domain.AccountContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanStore.InfraStructure.SharedContext.Data.Mappings;

public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Account");

        #region Columns

        builder.OwnsOne(x => x.Email, email =>
        {
            email.HasIndex(e => e.Address)
                .HasName("IX_Account_Email")
                .IsUnique();

            email.Property(e => e.Address)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(Email.MaxLength)
                .HasColumnName("Email");

            email.Property(e => e.Hash)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .HasColumnName("EmailHash");
            
        #endregion
        });
    }
}