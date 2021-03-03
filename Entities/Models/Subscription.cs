using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
  public class Subscription
  {
    [Key]
    public int Id { get; set; }


    [MaxLength(20)]
    public string Name { get; set; }


    public IEnumerable<User> Users { get; set; }
  }
}
