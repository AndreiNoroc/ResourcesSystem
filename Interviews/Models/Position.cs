using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.Models;

public partial class Position
{
    public int PId { get; set; }

    public string PName { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; } = new List<Company>();
}
