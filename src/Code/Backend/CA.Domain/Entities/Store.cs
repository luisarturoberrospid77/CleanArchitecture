using System.Collections.Generic;

using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class Store : EntityBase<int>
    {
        public Store()
        {
            Assignments = new HashSet<Assignment>();
            ItemMovementOriginStores = new HashSet<ItemMovement>();
            ItemMovementPostingStores = new HashSet<ItemMovement>();
            Orders = new HashSet<Order>();
            StockArticles = new HashSet<StockInventory>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public int PostalCode { get; set; }
        public int CountryCode { get; set; }
        public int FederalEntityCode { get; set; }
        public int MunicipalityCode { get; set; }
        public int NeighborhoodCode { get; set; }

        public virtual User AccountIdCreationdateNavigation { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<ItemMovement> ItemMovementOriginStores { get; set; }
        public virtual ICollection<ItemMovement> ItemMovementPostingStores { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StockInventory> StockArticles { get; set; }
    }
}
