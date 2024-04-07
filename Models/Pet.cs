using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoptionWebsite.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Species { get; set; }

        [Required]
        [Range(0, 50)]
        public int Age { get; set; }

        public string BondedBuddyStatus { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public string SpecialCareInstructions { get; set; }

        // Navigation property for favorites
        public ICollection<Favorite>? Favorites { get; set; }

        public bool IsAdopted { get; set; }

    }
}
