using System;

namespace CA.Core.Interfaces.Management
{
  public interface IAddEntity<TKey>
  {
    public TKey Id { get; set; }
    public bool IsSystemRow { get; set; }
    public int AccountIdCreationDate { get; set; }
    public DateTime CreationDate { get; set; }
  }
}
