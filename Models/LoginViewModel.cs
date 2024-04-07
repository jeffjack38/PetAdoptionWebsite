using System.ComponentModel.DataAnnotations;

namespace PetAdoptionWebsite.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(255)]
        public string? Password { get; set; }

        public string? ReturnURL { get; set; }

        public bool RememberMe { get; set; }

    }
}
