using System;

namespace CA.Core.DTO
{
  public class UserDTO
  {
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Passwordhash { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
  }
}
