using System;
using System.Collections.Generic;

#nullable disable

namespace CA.Core.Entities
{
    public partial class MtProductType
    {
        public MtProductType()
        {
            MtArticles = new HashSet<MtArticle>();
        }

        public int ProducttypeId { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual MtUser Account { get; set; }
        public virtual ICollection<MtArticle> MtArticles { get; set; }
    }
}
