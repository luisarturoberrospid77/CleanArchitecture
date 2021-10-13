using System;

namespace CA.Core.Entities
{
  public class mtStores
  {
    public int store_id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public int account_id { get; set; }
    public DateTime creationdate { get; set; }
    public DateTime? updatedate { get; set; }
  }
}
