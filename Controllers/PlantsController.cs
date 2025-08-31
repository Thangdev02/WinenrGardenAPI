using Microsoft.AspNetCore.Mvc;
using WinnerGardenAPI.DTOs;
using WinnerGardenAPI.Models;
using WinnerGardenAPI.Repositories;
using WinnerGardenAPI.Repositories.Interfaces;

namespace WinnerGardenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantRepository _repository;

        public PlantsController(IPlantRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Plant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantDTO>>> GetPlants()
        {
            var plants = await _repository.GetAllAsync();
            var result = plants.Select(p => new PlantDTO
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Rating = p.Rating,
                RatingCount = p.RatingCount,
                Price = p.Price,
                OriginalPrice = p.OriginalPrice,
                StockStatus = p.StockStatus,
                Sku = p.Sku,
                Description = p.Description
            });
            return Ok(result);
        }

        // GET: api/Plant/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDTO>> GetPlant(string id)
        {
            var plant = await _repository.GetByIdAsync(id);
            if (plant == null) return NotFound();

            return Ok(new PlantDTO
            {
                Id = plant.Id,
                Name = plant.Name,
                Image = plant.Image,
                Rating = plant.Rating,
                RatingCount = plant.RatingCount,
                Price = plant.Price,
                OriginalPrice = plant.OriginalPrice,
                StockStatus = plant.StockStatus,
                Sku = plant.Sku,
                Description = plant.Description
            });
        }

        // POST: api/Plant
        [HttpPost]
        public async Task<ActionResult<PlantDTO>> CreatePlant([FromBody] PlantDTO dto)
        {
            var plant = new Plant
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Image = dto.Image,
                Rating = dto.Rating,
                RatingCount = dto.RatingCount,
                Price = dto.Price,
                OriginalPrice = dto.OriginalPrice,
                StockStatus = dto.StockStatus,
                Sku = dto.Sku,
                Description = dto.Description
            };

            var created = await _repository.AddAsync(plant);
            return CreatedAtAction(nameof(GetPlant), new { id = created.Id }, dto);
        }

        // PUT: api/Plant/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlant(string id, [FromBody] PlantDTO dto)
        {
            var plant = new Plant
            {
                Id = id,
                Name = dto.Name,
                Image = dto.Image,
                Rating = dto.Rating,
                RatingCount = dto.RatingCount,
                Price = dto.Price,
                OriginalPrice = dto.OriginalPrice,
                StockStatus = dto.StockStatus,
                Sku = dto.Sku,
                Description = dto.Description
            };

            var updated = await _repository.UpdateAsync(plant);
            if (updated == null) return NotFound();

            return NoContent();
        }

        // DELETE: api/Plant/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(string id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
