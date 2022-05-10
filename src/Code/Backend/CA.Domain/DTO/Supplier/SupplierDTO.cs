using System;

namespace CA.Domain.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public string PostalCode { get; set; }
        public int FederalEntityCode { get; set; }
        public int MunicipalityCode { get; set; }
        public int NeighborhoodCode { get; set; }
        public bool IsSystemRow { get; set; }
        public int AccountIdCreationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AccountIdUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? AccountIdDeleteDate { get; set; }
    }
}
