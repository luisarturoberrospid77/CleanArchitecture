namespace CA.Core.DTO
{
  public class DeleteSupplierDTO
  {
    public int Id { get; set; }
    public bool AutoSave { get; set; }
    public int? AccountIdDeleteDate { get; set; }
  }
}
