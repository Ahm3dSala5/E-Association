﻿using Domain.Entities.Securities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ApplicationUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            builder.HasKey(x => new { x.UserId, x.Id });

            builder.HasOne<ApplicationUser>()
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

        }
    }
}