using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ApplicationUserSubscriptionsConfiguration : IEntityTypeConfiguration<UserSubscriptions>
    {
        public void Configure(EntityTypeBuilder<UserSubscriptions> builder)
        {
            builder.ToTable("UserSubscriptions").HasKey(x => new { x.UserId, x.SubscriptionId });

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

            builder.HasOne(x => x.SubScription)
                .WithMany(s => s.UserSubscriptions)
                .HasForeignKey(x => x.SubscriptionId);
        }
    }
}
