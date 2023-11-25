namespace Interviews.Models;

public partial class Resource
{
    public int RId { get; set; }

    public string RName { get; set; } = null!;

    public string RUrl { get; set; } = null!;

    public int RCategoryId { get; set; }

    public int RCompanyId { get; set; }

    public int RLevelId { get; set; }

    public virtual Category RCategory { get; set; } = null!;

    public virtual Company RCompany { get; set; } = null!;

    public virtual Level RLevel { get; set; } = null!;
}
