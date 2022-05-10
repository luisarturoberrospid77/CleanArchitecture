using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class Brand : EntityBase<int>
    {
        public Brand()
        {
            Articles = new HashSet<Article>();
        }

        public string Name { get; set; }
        public int SupplierId { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
