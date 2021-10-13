using System;

namespace CA.Core.Entities
{
  public class mtArticles
  {
    public int sku_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public int total_in_shelf { get; set; }
    public int total_in_vault { get; set; }
    public int producttype_id { get; set; }
    public int store_id { get; set; }
    public int account_id { get; set; }
    public DateTime creationdate { get; set; }
    public DateTime? updatedate { get; set; }
  }
}
