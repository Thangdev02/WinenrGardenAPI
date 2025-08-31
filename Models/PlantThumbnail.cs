using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class PlantThumbnail
{
    public int Id { get; set; }

    public string PlantId { get; set; } = null!;

    public string? ThumbnailUrl { get; set; }

    public virtual Plant Plant { get; set; } = null!;
}
