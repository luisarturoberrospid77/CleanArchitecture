using System;

namespace CA.Core.DTO
{
  public class BrandDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int SupplierId { get; set; }
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
