using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
  public partial class CodeNamespace : EntityBase<int>
  {
    public CodeNamespace()
    {
      CodeValues = new HashSet<CodeValue>();
    }

    public string Name { get; set; }
    public string List { get; set; }

    public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual ICollection<CodeValue> CodeValues { get; set; }
  }
}
