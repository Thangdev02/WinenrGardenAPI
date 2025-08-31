using System.Collections.Generic;
using System.Threading.Tasks;
using WinnerGardenAPI.Models;

namespace WinnerGardenAPI.Repositories.Interfaces
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetAllAsync();
        Task<Plant?> GetByIdAsync(string id);
        Task<Plant> AddAsync(Plant plant);
        Task<Plant?> UpdateAsync(Plant plant);
        Task<bool> DeleteAsync(string id);
    }
}
