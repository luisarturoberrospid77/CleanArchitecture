using System;
using System.Collections.Generic;

#nullable disable

namespace CA.Core.Entities
{
    public partial class VwArticle
    {
        public int SkuId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public string StoreName { get; set; }
        public string ProductTypeName { get; set; }
    }
}
