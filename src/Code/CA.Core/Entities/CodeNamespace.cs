using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
    public partial class CodeNamespace
    {
        public CodeNamespace()
        {
      CodeValues = new HashSet<CodeValue>();
        }

        public int Codenamespaceid { get; set; }
        public string Name { get; set; }
        public string List { get; set; }
        public bool? Issystemrow { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime Creationdate { get; set; }
        public int AccountIdCreationdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public int? AccountIdUpdatedate { get; set; }
        public DateTime? Deletedate { get; set; }
        public int? AccountIdDeletedate { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual ICollection<CodeValue> CodeValues { get; set; }
    }
}
