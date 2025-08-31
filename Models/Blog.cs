using System;
using System.Collections.Generic;

namespace WinnerGardenAPI.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? Image { get; set; }

    public string AuthorId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User Author { get; set; } = null!;
}
