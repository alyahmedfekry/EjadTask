using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IHorseRepository
    {
        Task CreateAsync(Horse horse);
        Task<Horse?> GetByIdAsync(int id);
        Task<List<Horse>> GetAllAsync();
        Task<bool>IsUniqueName(string name);
        Task<bool> IsAvailable(int id);
        Task SetIsAvailableStatus(int id, bool isAvailable);
        void Update(Horse horse);
    }
}
