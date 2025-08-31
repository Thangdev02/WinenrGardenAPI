using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class OrderProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string PlantId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Plant Plant { get; set; } = null!;
}
