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
    public class HorseRepository : IHorseRepository
    {
        private readonly ApplicationDbContext _context;
        public HorseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Horse horse)
        {
           await _context.Horses.AddAsync(horse);
        }

        public async Task<List<Horse>> GetAllAsync()
        {
            return await _context.Horses.AsNoTracking().ToListAsync();
        }

        public async Task<Horse?> GetByIdAsync(int id)
        {
            var horse = await _context.Horses.FindAsync(id);

            return horse;
        }

        public async Task<bool> IsAvailable(int id)
        {
            return await _context.Horses.Where(h => h.Id == id)
                .Select(d => d.IsAvailable).SingleOrDefaultAsync();
        }
        public async Task<bool> IsUniqueName(string name)
        {
            return !await _context.Horses.AnyAsync(h => h.Name == name);
        }

        public void Update(Horse horse)
        {
            _context.Update(horse);
        }
        public async Task SetIsAvailableStatus(int id, bool isAvailable)
        {
            var horse = await this.GetByIdAsync(id);
            if (horse != null)
            {
                horse.IsAvailable = isAvailable;
            }
        }
    }
}
