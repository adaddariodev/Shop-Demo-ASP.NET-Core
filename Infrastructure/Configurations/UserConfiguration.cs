using Core.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Userx>
    {
        public void Configure(EntityTypeBuilder<Userx> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Surnmame)
                .IsRequired()
                .HasMaxLength(20);
            
        }
    }
}
