using Domain.Entities.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Business
{
    public class BalanceConfigurations : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable("Balance").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

        }
    }
}
