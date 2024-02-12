using Domain.Abstractions.Repositories;
using Domain.Entities;
using Infrustructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class SamuraiRepository : ISamuraiRepository
    {
        private readonly ApplicationDbContext _context;
        public SamuraiRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Samurai samurai)
        {
           await _context.Samurais.AddAsync(samurai);
        }

        public async Task<Samurai?> GetByIdAsync(int id)
        {
            return await _context.Samurais.FindAsync(id);
        }

        public async Task<List<Samurai>> GetAllAsync()
        {
            return await _context.Samurais.AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsUniqueName(string name)
        {
           return !await _context.Samurais.AnyAsync(s => s.Name == name);
        }

        public void Update(Samurai samurai)
        {
            _context.Samurais.Update(samurai);
        }

        public Task<bool> IsAvailable(int id)
        {
            throw new NotImplementedException();
        }
        public async Task SetIsAvailableStatus(int id, bool isAvailable)
        {
            var samurai = await this.GetByIdAsync(id);
            if (samurai != null)
            {
                samurai.IsAvailable = isAvailable;
            }
        }
    }
}
