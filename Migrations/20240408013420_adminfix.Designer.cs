﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetAdoptionWebsite.Models;

#nullable disable

namespace PetAdoptionWebsite.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20240408013420_adminfix")]
    partial class adminfix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BondedBuddyStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsAdopted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SpecialCareInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 2,
                            BondedBuddyStatus = "None",
                            Description = "A cute fluffy cat.",
                            IsAdopted = false,
                            Name = "Fluffy",
                            SpecialCareInstructions = "Needs exercise",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 2,
                            Age = 3,
                            BondedBuddyStatus = "None",
                            Description = "A friendly dog looking for a home.",
                            IsAdopted = false,
                            Name = "Buddy",
                            SpecialCareInstructions = "Is diabetic",
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 3,
                            Age = 1,
                            BondedBuddyStatus = "Colby",
                            Description = "Bonded Buddies with Colby. An affectionate cat who meows a lot.",
                            IsAdopted = false,
                            Name = "Moo",
                            SpecialCareInstructions = "Has to go with Colby. Needs a good home.",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 4,
                            Age = 5,
                            BondedBuddyStatus = "Moo",
                            Description = "Bonded Buddies with Moo. Very skitish, but loves to be pet.",
                            IsAdopted = false,
                            Name = "Colby",
                            SpecialCareInstructions = "Has to go with Moo. Needs a good home.",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 5,
                            Age = 10,
                            BondedBuddyStatus = "None",
                            Description = "Elderly bunny who needs a new home. Loves carrots.",
                            IsAdopted = false,
                            Name = "Juno",
                            SpecialCareInstructions = "Needs a specialized diet to maintain health.",
                            Species = "Bunny"
                        },
                        new
                        {
                            Id = 6,
                            Age = 6,
                            BondedBuddyStatus = "None",
                            Description = "An affectionate dog who loves to play.",
                            IsAdopted = false,
                            Name = "Peaches",
                            SpecialCareInstructions = "Requires 10 hours of play a week.",
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 7,
                            Age = 4,
                            BondedBuddyStatus = "None",
                            Description = "A overly affectionate dog who needs a new home.",
                            IsAdopted = false,
                            Name = "Olo",
                            SpecialCareInstructions = "Not good with kids.",
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 8,
                            Age = 19,
                            BondedBuddyStatus = "None",
                            Description = "A turtle who loves to swim and stare at you.",
                            IsAdopted = false,
                            Name = "Daisey",
                            SpecialCareInstructions = "Great with kids, needs to be with people or gets too lonely.",
                            Species = "Reptile"
                        },
                        new
                        {
                            Id = 9,
                            Age = 2,
                            BondedBuddyStatus = "Yoshi",
                            Description = "enchants with her silky midnight-blue fur and eyes that gleam like twin crescent moons, exuding an aura of serene elegance and quiet wisdom.",
                            IsAdopted = false,
                            Name = "Raven",
                            SpecialCareInstructions = "Needs attention",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 10,
                            Age = 3,
                            BondedBuddyStatus = "None",
                            Description = "a gentle soul, displaying a heartwarming affection by leaning into every pat and responding to commands with a calm and eager demeanor.",
                            IsAdopted = false,
                            Name = "Worm",
                            SpecialCareInstructions = "Afraid of worms",
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 11,
                            Age = 2,
                            BondedBuddyStatus = "None",
                            Description = "a calm observer, finding solace in quiet corners and displaying a gentle, affectionate nature by curling up in laps during cozy evenings.",
                            IsAdopted = false,
                            Name = "Jack",
                            SpecialCareInstructions = "Needs litter to be extra clean",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 12,
                            Age = 3,
                            BondedBuddyStatus = "None",
                            Description = "a lively bundle of joy, his tail in a perpetual state of enthusiastic wagging as he greets everyone with boundless energy.",
                            IsAdopted = false,
                            Name = "Inu",
                            SpecialCareInstructions = "Is diabetic",
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 13,
                            Age = 22,
                            BondedBuddyStatus = "Daisey",
                            Description = "a patient and resilient friend, gracefully gliding through the water with a quiet determination and occasionally retreating into her shell to reflect",
                            IsAdopted = false,
                            Name = "Yoshi",
                            SpecialCareInstructions = "Needs alone time",
                            Species = "Reptile"
                        },
                        new
                        {
                            Id = 14,
                            Age = 39,
                            BondedBuddyStatus = "None",
                            Description = "embodies an enigmatic grace, sinuously navigating her surroundings with hypnotic movements.",
                            IsAdopted = false,
                            Name = "Touka",
                            SpecialCareInstructions = "Good with kids",
                            Species = "Reptile"
                        },
                        new
                        {
                            Id = 15,
                            Age = 20,
                            BondedBuddyStatus = "None",
                            Description = "moves through life with a calm and deliberate pace, his shell adorned with the wisdom of ages ",
                            IsAdopted = false,
                            Name = "Meryl",
                            SpecialCareInstructions = "Good with other pets",
                            Species = "Reptile"
                        },
                        new
                        {
                            Id = 16,
                            Age = 3,
                            BondedBuddyStatus = "Dusty",
                            Description = "a curious and nimble explorer, darting around with playful hops.",
                            IsAdopted = false,
                            Name = "Patches",
                            SpecialCareInstructions = "Is skitish",
                            Species = "Bunny"
                        },
                        new
                        {
                            Id = 17,
                            Age = 5,
                            BondedBuddyStatus = "Patches",
                            Description = "a mischievous delight, showcasing a penchant for binkying through open spaces, executing playful jumps with contagious excitement",
                            IsAdopted = false,
                            Name = "Dusty",
                            SpecialCareInstructions = "Needs extra love",
                            Species = "Bunny"
                        },
                        new
                        {
                            Id = 18,
                            Age = 13,
                            BondedBuddyStatus = "None",
                            Description = "a serene and gentle companion, preferring quiet moments of nibbling on fresh greens and lounging in sunlit spots.",
                            IsAdopted = false,
                            Name = "Pixie",
                            SpecialCareInstructions = "Needs to be the only pet",
                            Species = "Bunny"
                        },
                        new
                        {
                            Id = 19,
                            Age = 4,
                            BondedBuddyStatus = "None",
                            Description = "Mystique, the cat, boasts a sleek onyx coat and captivating green eyes, exuding an air of graceful mystery and feline elegance.",
                            IsAdopted = false,
                            Name = "Destiny",
                            SpecialCareInstructions = "None",
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 20,
                            Age = 6,
                            BondedBuddyStatus = "None",
                            Description = "an adventurous spirit, always ready for a new escapade, whether it's exploring the outdoors or chasing after frisbees.",
                            IsAdopted = false,
                            Name = "Chilli",
                            SpecialCareInstructions = "None",
                            Species = "Dog"
                        });
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PetAdoptionWebsite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PetAdoptionWebsite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoptionWebsite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PetAdoptionWebsite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.Favorite", b =>
                {
                    b.HasOne("PetAdoptionWebsite.Models.Pet", "Pet")
                        .WithMany("Favorites")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetAdoptionWebsite.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.Pet", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("PetAdoptionWebsite.Models.User", b =>
                {
                    b.Navigation("Favorites");
                });
#pragma warning restore 612, 618
        }
    }
}
