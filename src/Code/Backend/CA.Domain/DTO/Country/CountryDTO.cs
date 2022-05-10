using System;

namespace CA.Domain.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Iso { get; set; }
        public string NameCountry { get; set; }
        public string Nicename { get; set; }
        public string Iso3 { get; set; }
        public short? Numcode { get; set; }
        public int Phonecode { get; set; }
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
