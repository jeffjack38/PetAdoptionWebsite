namespace PetAdoptionWebsite.Models
{
    public class PetListViewModel
    {
        public List<Pet> Pets { get; set; }
        private List<string> species;  // Declare species field

        public List<string> Species
        {
            get => species;
            set
            {
                species = value;
                species.Insert(0, "All");
            }
        }

        // Method to help the view determine the active link
        public string CheckActiveSpecies(string s) =>
            s.ToLower() == ActiveSpecies.ToLower() ? "active" : "";

        // Add this method to PetListViewModel
        public List<string> GetDistinctSpecies()
        {
            // Implement the logic to get distinct species from your Pets list
            // Assuming Pet has a property called Species

            var distinctSpecies = Pets?.Select(p => p.Species).Distinct().ToList() ?? new List<string>();

            // Insert "All" at the beginning of the list
            distinctSpecies.Insert(0, "All");

            return distinctSpecies;
        }

        public string ActiveSpecies { get; set; } = "all";
    }
}
