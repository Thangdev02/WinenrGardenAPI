using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class PlantReview
{
    public int Id { get; set; }

    public string PlantId { get; set; } = null!;

    public string? UserName { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Plant Plant { get; set; } = null!;
}
