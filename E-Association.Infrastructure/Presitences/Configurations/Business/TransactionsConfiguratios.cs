using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Business;
namespace Presitences.Configurations.Business
{
    public class TransactionsConfiguratios : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transaction").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Balance)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BalanceId);
        }
    }
}
