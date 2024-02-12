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
    public class BattleConfiguration : IEntityTypeConfiguration<Battle>
    {
        public void Configure(EntityTypeBuilder<Battle> builder)
        {
            var westBattle = new Battle("West Battle");
            var northBattle = new Battle("North Battle");

            List<Battle> battles = new List<Battle>();
            battles.Add(westBattle);
            battles.Add(northBattle);

            builder.ToTable("Battle").HasData(battles);

            builder.Property(r => r.Name).HasMaxLength(250);
        }
    }
}
