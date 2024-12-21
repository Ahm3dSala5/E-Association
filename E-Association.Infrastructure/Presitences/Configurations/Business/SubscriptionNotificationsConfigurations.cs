using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class SubscriptionNotificationsConfigurations : IEntityTypeConfiguration<SubscriptionNotifications>
    {
        public void Configure(EntityTypeBuilder<SubscriptionNotifications> builder)
        {
            builder.ToTable("SubscriptionNotifications").HasKey(x => new { x.SubScriptionId, x.NotificationsId });

        }
    }
}
