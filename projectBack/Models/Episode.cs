using System;
using System.Collections.Generic;

namespace projectBack.Models;

public partial class Episode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? AirDate { get; set; }

    public string? EpisodeCode { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
