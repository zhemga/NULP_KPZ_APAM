using System.ComponentModel.DataAnnotations;

namespace APAM_API.Models.Selling_System
{
    public class DeliveryStatus
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Status Name")]
        public string Name { get; set; }
    }
}