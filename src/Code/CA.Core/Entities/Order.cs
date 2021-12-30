using System;
using System.Collections.Generic;

namespace CA.Core.Entities
{
    public partial class Order
    {
        public Order()
        {
      OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int StatusOrder { get; set; }
        public int TypeOrder { get; set; }
        public string Comments { get; set; }
        public bool? Issystemrow { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime Creationdate { get; set; }
        public int AccountIdCreationdate { get; set; }
        public DateTime? Updatedate { get; set; }
        public int? AccountIdUpdatedate { get; set; }
        public DateTime? Deletedate { get; set; }
        public int? AccountIdDeletedate { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
    public virtual Store Stores { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
