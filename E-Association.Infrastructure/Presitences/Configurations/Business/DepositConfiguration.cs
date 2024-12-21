using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.ToTable("Deposit").HasKey(x=>x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Deposites)
                .HasForeignKey(x=>x.UserId);

            builder.HasOne(x => x.Balance)
                .WithMany(x => x.Deposits)
                .HasForeignKey(x => x.BalanceId);
        }
    }
}
