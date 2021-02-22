using System.ComponentModel.DataAnnotations;

namespace Artportable.API.Entities.Model
{
    public class ImageForUpdate
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
