using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Configuration
{
    public class SamuraiBattleConfiguration : IEntityTypeConfiguration<SamuraiBattle>
    {
        public void Configure(EntityTypeBuilder<SamuraiBattle> builder)
        {
            builder.ToTable("SamuraiBattle");

            builder.HasOne(r => r.Horse)
                   .WithMany()
                   .HasForeignKey(r => r.HorseId)
                   .IsRequired();

            builder.HasOne(r => r.Battle)
                   .WithMany()
                   .HasForeignKey(r => r.BattleId)
                   .IsRequired();

            builder.HasOne(r => r.Samurai)
                   .WithMany()
                   .HasForeignKey(r => r.SamuraiId)
                   .IsRequired();
        }
    }
}
