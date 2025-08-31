namespace WinnerGardenAPI.DTOs
{
    public class PlantDTO
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        public int? RatingCount { get; set; }
        public int? Price { get; set; }
        public int? OriginalPrice { get; set; }
        public string? StockStatus { get; set; }
        public string? Sku { get; set; }
        public string? Description { get; set; }
    }
}
