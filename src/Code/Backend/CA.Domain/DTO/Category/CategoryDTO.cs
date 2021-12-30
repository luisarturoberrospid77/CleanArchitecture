using System;

namespace CA.Domain.DTO
{
  public class CategoryDTO
  {
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int? ValueId { get; set; }
    public string Description { get; set; }
    public string Breadcrumb { get; set; }
    public int? Level { get; set; }
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
