﻿using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class StoreEntityTypeConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.StoreId);

            builder.HasMany(s => s.Products)
                .WithOne(s => s.Store)
                .HasForeignKey(s => s.StoreId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
