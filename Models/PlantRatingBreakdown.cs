using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class PlantRatingBreakdown
{
    public int Id { get; set; }

    public string PlantId { get; set; } = null!;

    public int? Stars { get; set; }

    public int? Count { get; set; }

    public virtual Plant Plant { get; set; } = null!;
}
