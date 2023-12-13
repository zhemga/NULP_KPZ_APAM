using APAM_API.Models.Selling_System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models.Identity_Users
{
    public class Seller : IdentityUser
    {
        [InverseProperty("Seller")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}