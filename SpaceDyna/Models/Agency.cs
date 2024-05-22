using System.ComponentModel.DataAnnotations;

namespace SpaceDyna.Models
{
    public class Agency : BaseEntity
    {
        [MaxLength(64), Required]
        public string Work {  get; set; }
        [MaxLength(256),Required]
        public string Description { get; set;}
        [Required]
        public string ImageUrl { get; set; }

    }
}
