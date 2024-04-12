using System.ComponentModel.DataAnnotations;

namespace PetAdoptionWebsite.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name for the pet. ")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a species for the pet.")]
        [StringLength(50)]
        public string Species { get; set; }

        [Required(ErrorMessage = "Please enter an age for the pet.")]
        [Range(0, 50, ErrorMessage = "Please enter an age less than 50.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter a bonded buddy status")]
        [StringLength(20)]
        public string BondedBuddyStatus { get; set; }

        [Required(ErrorMessage = "Please enter a description for the pet. ")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter special care instructions.")]
        [StringLength(200)]
        public string SpecialCareInstructions { get; set; }

        // Navigation property for favorites
        public ICollection<Favorite>? Favorites { get; set; }

        public bool IsAdopted { get; set; }

    }
}
