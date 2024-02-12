using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface ISamuraiRepository
    {
        Task CreateAsync(Samurai samurai);
        Task<Samurai?> GetByIdAsync(int id);
        Task<List<Samurai>> GetAllAsync();
        Task<bool> IsUniqueName(string name);
        void Update(Samurai samurai);
        Task<bool> IsAvailable(int id);
        Task SetIsAvailableStatus(int id, bool isAvailable);
    }
}
