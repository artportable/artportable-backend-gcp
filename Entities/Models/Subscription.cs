using System;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string CustomerId { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
