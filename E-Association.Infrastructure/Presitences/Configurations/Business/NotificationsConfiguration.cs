using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class NotificationsConfiguration : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.ToTable("Notifications").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

            builder.HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .IsRequired();

            //create relationship many to many
            builder.HasMany(x => x.Subscriptions)
                .WithMany(x => x.Notifications)
                .UsingEntity<SubscriptionNotifications>
                (
                join => join.
                  HasOne(x => x.SubScription).
                  WithMany(x => x.SubscriptionNotifications).
                  HasForeignKey(x => x.SubScriptionId),

                join => join.
                  HasOne(x => x.Notification).
                  WithMany(x => x.SubscriptionNotifications).
                  HasForeignKey(x => x.NotificationsId)
                );

        }
    }
}
