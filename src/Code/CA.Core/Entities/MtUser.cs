using System;
using System.Collections.Generic;

#nullable disable

namespace CA.Core.Entities
{
    public partial class MtUser
    {
        public MtUser()
        {
            MtArticles = new HashSet<MtArticle>();
            MtProductTypes = new HashSet<MtProductType>();
            MtStores = new HashSet<MtStore>();
        }

        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Passwordhash { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? Updatedate { get; set; }

        public virtual ICollection<MtArticle> MtArticles { get; set; }
        public virtual ICollection<MtProductType> MtProductTypes { get; set; }
        public virtual ICollection<MtStore> MtStores { get; set; }
    }
}
