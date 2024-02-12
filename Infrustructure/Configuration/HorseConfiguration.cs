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
    public class HorseConfiguration : IEntityTypeConfiguration<Horse>
    {
        public void Configure(EntityTypeBuilder<Horse> builder)
        {
            var defenseHorse = new Horse("Defense Horse", 20.5, "Black", 15, 50);
            var heavyHorse = new Horse("heavy Horse",35, "White", 20, 30);
            List<Horse> horses = new List<Horse>();
            horses.Add(heavyHorse);
            horses.Add(defenseHorse);

            builder.ToTable("Horse");
            builder.Property(r => r.Name).HasMaxLength(250);
            builder.Property(r => r.Color).HasMaxLength(250);
        }
    }
}
