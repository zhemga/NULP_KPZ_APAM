using APAM_API.Models.Identity_Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models
{
    public class AutoPart
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Part Name")]
        public string AutoName { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("AutoPartCategory")]
        public string AutoPartCategoryId { get; set; }
        public virtual AutoPartCategory AutoPartCategory { get; set; }

        [Required]
        [ForeignKey("AutoPartManufacturer")]
        public string AutoPartManufacturerId { get; set; }
        public virtual AutoPartManufacturer AutoPartManufacturer { get; set; }

        [Required]
        [ForeignKey("AutoPartSupplier")]
        public string AutoPartSupplierId { get; set; }
        public virtual AutoPartSupplier AutoPartSupplier { get; set; }
    }
}