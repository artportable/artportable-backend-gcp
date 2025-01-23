using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
