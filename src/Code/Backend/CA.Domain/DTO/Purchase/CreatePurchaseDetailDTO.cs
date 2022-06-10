namespace CA.Domain.DTO
{
    public class CreatePurchaseDetailDTO
    {
        public int Id { get; set; }
        public int SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public int AccountIdCreationDate { get; set; }
    }
}
