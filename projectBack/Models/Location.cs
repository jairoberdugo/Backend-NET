using System;
using System.Collections.Generic;

namespace projectBack.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Dimension { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
