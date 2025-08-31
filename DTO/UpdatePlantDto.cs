namespace WinnerGardenAPI.DTOs;

public class UpdatePlantDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? Price { get; set; }
    public List<string> Images { get; set; } = new();
}
