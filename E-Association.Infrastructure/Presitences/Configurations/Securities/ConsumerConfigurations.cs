using Domain.Entities.Business;
using Domain.Entities.Securities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ConsumerConfigurations : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("Consumer").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

            builder.HasMany(u => u.SubScriptions)
                .WithMany(s => s.Users)
                .UsingEntity<ConsumerAssociations>(
                    join => join.HasOne(us => us.Association)
                                .WithMany(s => s.UserSubscriptions)
                                .HasForeignKey(us => us.SubscriptionId),
                    join => join.HasOne(us => us.User)
                                .WithMany(u => u.UserSubscriptions)
                                .HasForeignKey(us => us.UserId)
                );

            builder.HasOne(x => x.Balance)
                .WithOne(x => x.User)
                .HasForeignKey<Consumer>(x => x.BalanceId)
                .IsRequired(false);
        }
    }
}
