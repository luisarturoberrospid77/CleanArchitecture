using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Newtonsoft.Json.Converters;

using CA.Domain.Enumerations;

namespace CA.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusOrderEnum StatusOrder { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeOrderEnum TypeOrder { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SaleSubTotal { get; set; }
        public decimal SaleTax { get; set; }
        public decimal SaleGrandTotal { get; set; }
        public string Comments { get; set; }
        public bool IsSystemRow { get; set; }
        public int AccountIdCreationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AccountIdUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? AccountIdDeleteDate { get; set; }
        public IEnumerable<OrderDetailDTO> OrderDetails { get; set; }
    }
}
