using System.ComponentModel.DataAnnotations;

namespace APAM_API.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}