using System;
using System.Collections.Generic;

#nullable disable

namespace CA.Core.Entities
{
    public partial class MtArticle
    {
        public int SkuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public int ProducttypeId { get; set; }
        public int StoreId { get; set; }
        public int AccountId { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual MtUser Account { get; set; }
        public virtual MtProductType Producttype { get; set; }
        public virtual MtStore Store { get; set; }
    }
}
