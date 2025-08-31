using Microsoft.EntityFrameworkCore;
using WinnerGardenAPI.Models;
using WinnerGardenAPI.Repositories.Interfaces;

namespace WinnerGardenAPI.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly WinnerGardenDbContext _context;

        public PlantRepository(WinnerGardenDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plant>> GetAllAsync()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant?> GetByIdAsync(string id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public async Task<Plant> AddAsync(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();
            return plant;
        }

        public async Task<Plant?> UpdateAsync(Plant plant)
        {
            var existing = await _context.Plants.FindAsync(plant.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(plant);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null) return false;

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
