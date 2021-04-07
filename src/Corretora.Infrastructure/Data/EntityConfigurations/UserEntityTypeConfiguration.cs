using Corretora.Domain.AggregatesModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corretora.Infrastructure.Data.EntityConfigurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(nameof(User))
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(
                navigationExpression: e => e.Cpf,
                buildAction: Cpf =>
                {
                    Cpf.Property(n => n.Value).HasColumnName("Cpf").HasMaxLength(11).IsRequired();
                });
        }
    }
}
