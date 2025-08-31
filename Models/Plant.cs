using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class Plant
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

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<PlantRatingBreakdown> PlantRatingBreakdowns { get; set; } = new List<PlantRatingBreakdown>();

    public virtual ICollection<PlantReview> PlantReviews { get; set; } = new List<PlantReview>();

    public virtual ICollection<PlantSize> PlantSizes { get; set; } = new List<PlantSize>();

    public virtual ICollection<PlantTag> PlantTags { get; set; } = new List<PlantTag>();

    public virtual ICollection<PlantThumbnail> PlantThumbnails { get; set; } = new List<PlantThumbnail>();
}
