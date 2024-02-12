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
    public class SamuraiConfiguration : IEntityTypeConfiguration<Samurai>
    {
        public void Configure(EntityTypeBuilder<Samurai> builder)
        {

            var Samurai1 = new Samurai("Kenin", 35,"defense",120,88);
            var Samurai2 = new Samurai("Mounted ", 20, "defense", 110, 60);
            List<Samurai> samurais = new List<Samurai>();
            samurais.Add(Samurai1);
            samurais.Add(Samurai2);
            builder.ToTable("Samurai").HasData(samurais);

            builder.Property(r => r.Name).HasMaxLength(250);
            builder.Property(r => r.Role).HasMaxLength(250);
        }
    }
}
