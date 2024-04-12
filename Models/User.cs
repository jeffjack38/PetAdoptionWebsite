using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PetAdoptionWebsite.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public override string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50)]
        public string LastName { get; set; }


        // Navigation property for favorites
        public ICollection<Favorite>? Favorites { get; set; }


    }
}
