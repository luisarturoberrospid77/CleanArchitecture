using System;

namespace CA.Core.DTO
{
  public class StoreDTO
  {
    public int StoreId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int AccountId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
  }
}
