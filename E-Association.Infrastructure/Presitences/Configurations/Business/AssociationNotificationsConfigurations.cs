using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class AssociationNotificationsConfigurations : IEntityTypeConfiguration<AssociationNotifications>
    {
        public void Configure(EntityTypeBuilder<AssociationNotifications> builder)
        {
            builder.ToTable("AssociationNotifications").HasKey(x => new { x.SubScriptionId, x.NotificationsId });

        }
    }
}
