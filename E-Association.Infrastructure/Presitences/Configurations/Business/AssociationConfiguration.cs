using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class AssociationConfiguration : IEntityTypeConfiguration<Association>
    {
        public void Configure(EntityTypeBuilder<Association> builder)
        {
            builder.ToTable("Association").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();
        }
    }
}
