using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.Models;

public partial class Level
{
    public int LId { get; set; }

    public string LDescription { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; } = new List<Resource>();
}
