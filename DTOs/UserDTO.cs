using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.DTOs
{
  public class UserDTO
  {
    [Required, StringLength(50, MinimumLength = 2)]
    public string Username { get; set; }
    [Required]
    public Guid KeycloakId { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; }
    [Required, StringLength(50)]
    public string Surname { get; set; }
    [Required, StringLength(254), EmailAddress]
    public string Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [StringLength(50)]
    public string Location { get; set; }
  }
}
