using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ConsumerAssociationsConfigurations : IEntityTypeConfiguration<ConsumerAssociations>
    {
        public void Configure(EntityTypeBuilder<ConsumerAssociations> builder)
        {
            builder.ToTable("ConsumerAssociations").HasKey(x => new { x.UserId, x.SubscriptionId });

            builder.Property(x => x.UserId)
                .HasColumnName("User_Number")
                .HasColumnType("uniqueidentifier").
                ValueGeneratedOnAdd(); ; // Match ApplicationUser.Id type

            builder.Property(x => x.SubscriptionId)
                .HasColumnName("Subscription_Number")
                .HasColumnType("uniqueidentifier").ValueGeneratedOnAdd(); ;

            builder.HasOne(x => x.User)
                .WithMany(u => u.UserSubscriptions)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Association)
                .WithMany(s => s.UserSubscriptions)
                .HasForeignKey(x => x.SubscriptionId);
        }
    }
}
