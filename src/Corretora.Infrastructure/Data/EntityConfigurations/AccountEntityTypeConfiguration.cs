using Corretora.Domain.AggregatesModel.Accounts;
using Corretora.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corretora.Infrastructure.Data.EntityConfigurations
{
    internal class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .ToTable(nameof(Account))
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
               .HasOne<User>()
               .WithMany()
               .HasForeignKey(nameof(Account.UserId));

            builder.OwnsOne(
                navigationExpression: e => e.Number,
                buildAction: Number =>
                {
                    Number.Property(n => n.Value).HasColumnName("Number").HasMaxLength(6).IsRequired();
                });
        }
    }
}
