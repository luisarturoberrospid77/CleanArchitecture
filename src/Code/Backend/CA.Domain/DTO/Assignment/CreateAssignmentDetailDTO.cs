namespace CA.Domain.DTO
{
    public class CreateAssignmentDetailDTO
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public int AccountIdCreationDate { get; set; }
    }
}
