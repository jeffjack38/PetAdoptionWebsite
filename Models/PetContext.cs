using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace PetAdoptionWebsite.Models
{
    public class PetContext : IdentityDbContext<User>
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; } // add User info to database
        public DbSet<Favorite> Favorites { get; set; } // add User favorite to database



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Custom configurations for the Pet entity go here

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Name = "Fluffy", Species = "Cat", Age = 2, Description = "A cute fluffy cat.", BondedBuddyStatus = "None", SpecialCareInstructions = "Needs exercise" },
                new Pet { Id = 2, Name = "Buddy", Species = "Dog", Age = 3, Description = "A friendly dog looking for a home.", BondedBuddyStatus = "None", SpecialCareInstructions = "Is diabetic" },
                new Pet { Id = 3, Name = "Moo", Species = "Cat", Age = 1, Description = "Bonded Buddies with Colby. An affectionate cat who meows a lot.", BondedBuddyStatus = "Colby", SpecialCareInstructions = "Has to go with Colby. Needs a good home." },
                new Pet { Id = 4, Name = "Colby", Species = "Cat", Age = 5, Description = "Bonded Buddies with Moo. Very skitish, but loves to be pet.", BondedBuddyStatus = "Moo", SpecialCareInstructions = "Has to go with Moo. Needs a good home." },
                new Pet { Id = 5, Name = "Juno", Species = "Bunny", Age = 10, Description = "Elderly bunny who needs a new home. Loves carrots.", BondedBuddyStatus = "None", SpecialCareInstructions = "Needs a specialized diet to maintain health." },
                new Pet { Id = 6, Name = "Peaches", Species = "Dog", Age = 6, Description = "An affectionate dog who loves to play.", BondedBuddyStatus = "None", SpecialCareInstructions = "Requires 10 hours of play a week." },
                new Pet { Id = 7, Name = "Olo", Species = "Dog", Age = 4, Description = "A overly affectionate dog who needs a new home.", BondedBuddyStatus = "None", SpecialCareInstructions = "Not good with kids." },
                new Pet { Id = 8, Name = "Daisey", Species = "Reptile", Age = 19, Description = "A turtle who loves to swim and stare at you.", BondedBuddyStatus = "None", SpecialCareInstructions = "Great with kids, needs to be with people or gets too lonely." },
                 new Pet { Id = 9, Name = "Raven", Species = "Cat", Age = 2, Description = "enchants with her silky midnight-blue fur and eyes that gleam like twin crescent moons, exuding an aura of serene elegance and quiet wisdom.", BondedBuddyStatus = "Yoshi", SpecialCareInstructions = "Needs attention" },
                new Pet { Id = 10, Name = "Worm", Species = "Dog", Age = 3, Description = "a gentle soul, displaying a heartwarming affection by leaning into every pat and responding to commands with a calm and eager demeanor.", BondedBuddyStatus = "None", SpecialCareInstructions = "Afraid of worms" },
                 new Pet { Id = 11, Name = "Jack", Species = "Cat", Age = 2, Description = "a calm observer, finding solace in quiet corners and displaying a gentle, affectionate nature by curling up in laps during cozy evenings.", BondedBuddyStatus = "None", SpecialCareInstructions = "Needs litter to be extra clean" },
                new Pet { Id = 12, Name = "Inu", Species = "Dog", Age = 3, Description = "a lively bundle of joy, his tail in a perpetual state of enthusiastic wagging as he greets everyone with boundless energy.", BondedBuddyStatus = "None", SpecialCareInstructions = "Is diabetic" },
                 new Pet { Id = 13, Name = "Yoshi", Species = "Reptile", Age = 22, Description = "a patient and resilient friend, gracefully gliding through the water with a quiet determination and occasionally retreating into her shell to reflect", BondedBuddyStatus = "Daisey", SpecialCareInstructions = "Needs alone time" },
                new Pet { Id = 14, Name = "Touka", Species = "Reptile", Age = 39, Description = "embodies an enigmatic grace, sinuously navigating her surroundings with hypnotic movements.", BondedBuddyStatus = "None", SpecialCareInstructions = "Good with kids" },
                 new Pet { Id = 15, Name = "Meryl", Species = "Reptile", Age = 20, Description = "moves through life with a calm and deliberate pace, his shell adorned with the wisdom of ages ", BondedBuddyStatus = "None", SpecialCareInstructions = "Good with other pets" },
                new Pet { Id = 16, Name = "Patches", Species = "Bunny", Age = 3, Description = "a curious and nimble explorer, darting around with playful hops.", BondedBuddyStatus = "Dusty", SpecialCareInstructions = "Is skitish" },
                 new Pet { Id = 17, Name = "Dusty", Species = "Bunny", Age = 5, Description = "a mischievous delight, showcasing a penchant for binkying through open spaces, executing playful jumps with contagious excitement", BondedBuddyStatus = "Patches", SpecialCareInstructions = "Needs extra love" },
                new Pet { Id = 18, Name = "Pixie", Species = "Bunny", Age = 13, Description = "a serene and gentle companion, preferring quiet moments of nibbling on fresh greens and lounging in sunlit spots.", BondedBuddyStatus = "None", SpecialCareInstructions = "Needs to be the only pet" },
                 new Pet { Id = 19, Name = "Destiny", Species = "Cat", Age = 4, Description = "Mystique, the cat, boasts a sleek onyx coat and captivating green eyes, exuding an air of graceful mystery and feline elegance.", BondedBuddyStatus = "None", SpecialCareInstructions = "None" },
                new Pet { Id = 20, Name = "Chilli", Species = "Dog", Age = 6, Description = "an adventurous spirit, always ready for a new escapade, whether it's exploring the outdoors or chasing after frisbees.", BondedBuddyStatus = "None", SpecialCareInstructions = "None" }

                );


            //configure relationship for favorite and User
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);




            base.OnModelCreating(modelBuilder);



        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            using var scoped = serviceProvider.CreateScope();
            UserManager<User> userManager = scoped.ServiceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();





            string username = "petadmin";
            string pwd = "Adminpet!52";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User() { UserName = username };

                var result = await userManager.CreateAsync(user, pwd);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
