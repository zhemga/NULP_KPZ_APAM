using System.ComponentModel.DataAnnotations;

namespace APAM_API.Models
{
    public class AutoPartManufacturer
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
    }
}