using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IBattleRepository
    {
        Task CreateAsync(Battle battle);
        Task SetFinishedAsync(int id , DateTime finishedDate);
        Task<Battle?> GetByIdAsync(int id);
        Task<List<Battle>> GetAllAsync();
        Task<bool> IsUniqueName(string name);
        void Update(Battle battle);
        Task<SamuraiBattle?> GetSamuraiBattleByAsync(int battleId, int samuraiId);
    }
}
