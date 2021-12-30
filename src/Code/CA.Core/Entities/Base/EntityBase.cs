using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CA.Core.Interfaces.Management;

namespace CA.Core.Entities.Base
{
  public abstract class EntityBase<TKey> : IEntityBase<TKey>
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }
    public bool IsSystemRow { get; set; }
    public int AccountIdCreationDate { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int? AccountIdUpdateDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeleteDate { get; set; }
    public int? AccountIdDeleteDate { get; set; }
  }
}
