using System.ComponentModel.DataAnnotations;

namespace APAM_API.Models
{
    public class AutoPartCategory
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}