using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class PlantSize
{
    public int Id { get; set; }

    public string PlantId { get; set; } = null!;

    public string? Size { get; set; }

    public virtual Plant Plant { get; set; } = null!;
}
