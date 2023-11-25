using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.Models;

public partial class Company
{
    public int CompId { get; set; }

    public string CompName { get; set; } = null!;

    public int CompPositionId { get; set; }

    public virtual Position CompPosition { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; } = new List<Resource>();
}
