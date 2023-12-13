using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APAM_API.Models.Identity_Users
{
    public class AutoPartSupplier : IdentityUser
    {
        public virtual ICollection<AutoPart> AutoParts { get; set; }
    }
}