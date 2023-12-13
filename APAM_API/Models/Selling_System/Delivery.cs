using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models.Selling_System
{

    public class Delivery
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Location From")]
        public string LocationFrom { get; set; }

        [Required]
        [Display(Name = "Location To")]
        public string LocationTo { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Status")]
        [ForeignKey("Status")]
        public string Status_Id { get; set; }
        public DeliveryStatus Status { get; set; }

        [Required]
        [Display(Name = "Estimated Delivery Time")]
        [DataType(DataType.DateTime)]
        public DateTime EstimatedDeliveryTime { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

}