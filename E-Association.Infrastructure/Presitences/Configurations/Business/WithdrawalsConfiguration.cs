using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class WithdrawalsConfiguration : IEntityTypeConfiguration<Withdrawals>
    {
        public void Configure(EntityTypeBuilder<Withdrawals> builder)
        {
            builder.ToTable("Withdrawals").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

            builder.HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Withdrawals)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x=>x.Balance)
                .WithMany(x=>x.Withdrawals)
                .HasForeignKey(x=>x.BalanceId);

        }
    }
}
