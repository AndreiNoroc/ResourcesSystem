using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.Models;

public partial class Category
{
    public int CId { get; set; }

    public string CName { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; } = new List<Resource>();
}
