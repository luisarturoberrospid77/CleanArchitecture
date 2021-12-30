using System;

namespace CA.Domain.Interfaces.Management
{
  public interface IDeleteEntity<TKey> : IAddEntity<TKey>
  {
    public bool IsDeleted { get; set; }
    public DateTime? DeleteDate { get; set; }
    public int? AccountIdDeleteDate { get; set; }
  }
}
