using System;

namespace CA.Core.DTO
{
  public class ProductTypeDTO
  {
    public int ProducttypeId { get; set; }
    public string Description { get; set; }
    public int AccountId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
  }
}
