using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class CodeValue : EntityBase<int>
  {
    public int ValueId { get; set; }
    public int CodeNameSpaceId { get; set; }
    public string Description { get; set; }
    public bool IsRoot { get; set; }
    public int ParentId { get; set; }
    public int OrderBy { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual CodeNamespace CodeNameSpace { get; set; }
  }
}
