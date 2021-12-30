using CA.Core.Entities.Base;

namespace CA.Core.Entities
{
  public partial class MenuCategory : EntityBase<int>
  {
    public int? ParentId { get; set; }
    public int? ValueId { get; set; }
    public string Description { get; set; }
    public string Breadcrumb { get; set; }
    public int? Level { get; set; }
  }
}
