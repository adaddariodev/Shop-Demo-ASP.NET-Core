using Core.Domain.Entities.CatalogueItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class CatalogueItemConfiguration : IEntityTypeConfiguration<CatalogueItem>
    {
        public void Configure(EntityTypeBuilder<CatalogueItem> builder)
        {
            builder.Property(p => p.ImagePath)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.User)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
