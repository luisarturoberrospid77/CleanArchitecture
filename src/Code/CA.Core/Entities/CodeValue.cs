using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
    public partial class CodeValue
    {
        public int RowId { get; set; }
        public int ValueId { get; set; }
        public int Codenamespaceid { get; set; }
        public string Description { get; set; }
        public bool Isroot { get; set; }
        public int Parentid { get; set; }
        public int Orderby { get; set; }
        public bool? Issystemrow { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime Creationdate { get; set; }
        public int AccountIdCreationdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public int? AccountIdUpdatedate { get; set; }
        public DateTime? Deletedate { get; set; }
        public int? AccountIdDeletedate { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual CodeNamespace CodeNameSpaces { get; set; }
    }
}
