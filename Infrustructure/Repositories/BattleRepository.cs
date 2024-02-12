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
    public class BattleRepository : IBattleRepository
    {
        private readonly ApplicationDbContext _context;
        public BattleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Battle battle)
        {
          await  _context.Battles.AddAsync(battle);
        }

        public async Task<List<Battle>> GetAllAsync()
        {
            var battles = await _context.Battles.AsNoTracking().ToListAsync();

            return battles; 
        }

        public async Task<Battle?> GetByIdAsync(int id)
        {
            var battle = await _context.Battles.FindAsync(id);

             return battle;
        }

        public async Task<SamuraiBattle?> GetSamuraiBattleByAsync(int battleId, int samuraiId)
        {
            return await _context.SamuraisBattle.Where(b =>
              (b.BattleId == battleId)
            && (b.SamuraiId == samuraiId)
            && (!b.EndRodeDate.HasValue)).SingleOrDefaultAsync();
        }

        public async Task<bool> IsUniqueName(string name)
        {
            return !await _context.Battles.AnyAsync(h => h.Name == name);
        }

        public async Task SetFinishedAsync(int id ,DateTime finishedDate)
        {
            var battle = await _context.Battles.FindAsync(id);

            battle.FinishedDate = finishedDate;
        }

        public void Update(Battle battle)
        {
            _context.Battles.Update(battle);
        }
    }
}
