using System.Collections.Generic;
using System.Text.Json.Serialization;

using MediatR;
using Newtonsoft.Json.Converters;

using CA.Domain.Wrappers;
using CA.Domain.DTO.Base;
using CA.Domain.Enumerations;

namespace CA.Domain.DTO
{
    public class CreateSaleDTO : CommandDTO, IRequest<ApiResponse<CreateSaleDTO>>
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusOrderEnum StatusOrder { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TypeOrderEnum TypeOrder { get; set; }
        public string Comments { get; set; }
        public int AccountIdCreationDate { get; set; }
        public List<CreateSaleDetailDTO> SaleDetail { get; set; }
    }
}
