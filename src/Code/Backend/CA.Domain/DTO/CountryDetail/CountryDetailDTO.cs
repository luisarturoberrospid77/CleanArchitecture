using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Domain.DTO
{
    public class CountryDetailDTO
    {
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public int FederalEntityCode { get; set; }
        public string FederalEntityName { get; set; }
        public int MunicipalityCode { get; set; }
        public string MunicipalityName { get; set; }
        public string CityName { get; set; }
        public string ZoneName { get; set; }
        public int PostalCode { get; set; }
        public int TownshipId { get; set; }
        public string TownshipName { get; set; }
        public int TownshipTypeId { get; set; }
        public string TownshipTypeName { get; set; }
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
