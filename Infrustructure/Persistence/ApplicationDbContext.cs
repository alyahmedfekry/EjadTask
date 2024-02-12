using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Samurai> Samurais { get; set; }
        public virtual DbSet<Horse> Horses { get; set; }
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<SamuraiBattle> SamuraisBattle { get; set; }
    }
}
