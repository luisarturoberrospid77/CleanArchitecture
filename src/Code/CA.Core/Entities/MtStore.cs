using System;
using System.Collections.Generic;

#nullable disable

namespace CA.Core.Entities
{
    public partial class MtStore
    {
        public MtStore()
        {
            MtArticles = new HashSet<MtArticle>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AccountId { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual MtUser Account { get; set; }
        public virtual ICollection<MtArticle> MtArticles { get; set; }
    }
}
