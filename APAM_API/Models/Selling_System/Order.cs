using APAM_API.Models.Identity_Users;
using APAM_API.Models.IdentityUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models.Selling_System
{
    public class Order
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        [InverseProperty("Orders")]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey("Seller")]
        [InverseProperty("Orders")]
        public string SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        [Required]
        [ForeignKey("AutoPart")]
        public string AutoPartId { get; set; }
        public virtual AutoPart AutoPart { get; set; }
    }
}