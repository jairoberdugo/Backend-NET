using System;
using System.Collections.Generic;

namespace projectBack.Models;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

    public string? Species { get; set; }

    public string? Type { get; set; }

    public string? Gender { get; set; }

    public int? OriginId { get; set; }

    public int? LocationId { get; set; }

    public string? Image { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Episode> Episodes { get; set; } = new List<Episode>();
}
