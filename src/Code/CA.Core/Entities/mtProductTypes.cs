using System;

namespace CA.Core.Entities
{
  public class mtProductTypes
  {
    public int producttype_id { get; set; }
    public string description { get; set; }
    public int account_id { get; set; }
    public DateTime creationdate { get; set; }
    public DateTime? updatedate { get; set; }
  }
}
