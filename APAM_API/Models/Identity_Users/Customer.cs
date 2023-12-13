using APAM_API.Models.Selling_System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models.IdentityUsers
{
    public class Customer : IdentityUser
    {
        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}