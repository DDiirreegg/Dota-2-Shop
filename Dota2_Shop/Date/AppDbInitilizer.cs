using Dota2_Shop.Date.Static;
using Dota2_Shop.Models;
using Microsoft.AspNetCore.Identity;

namespace Dota2_Shop.Date
{
    public class AppDbInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Heros
                if(!context.Heros.Any())
                {
                    context.Heros.AddRange(new List<Hero>()
                    {
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/Pudge.png",
                           HeroName = "Pudge",
                           HeroRole = Enum.HeroRole.Midlane,
                           StreghtAttributes = "25 + 3",
                           AgilityAttributes = "14 + 1.4",
                           IntelligenceAttributes = "16 + 1.8",
                           FirstAbility = "Meat Hook",
                           SecondAbility = "Rot",
                           ThirdAbility = "Flesh Heap",
                           UltimateAbility = "Dismember",
                           HeroBio = "When I'm through with these vermin, they'll be fit for a pie!"
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/Anti-Mage.png",
                           HeroName = "Anti-Mage",
                           HeroRole = Enum.HeroRole.Carry,
                           StreghtAttributes = "21 + 1.6",
                           AgilityAttributes = "24 + 2.8",
                           IntelligenceAttributes = "12 + 1.8",
                           FirstAbility = "Mana Break",
                           SecondAbility = "Blink",
                           ThirdAbility = "Counterspell",
                           UltimateAbility = "Mana Void",
                           HeroBio = "hey who live by the wand shall die by my blade."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/ancient_apparition.png",
                           HeroName = "Ancient Apparition",
                           HeroRole = Enum.HeroRole.Support,
                           StreghtAttributes = "20 + 1.9",
                           AgilityAttributes = "20 + 2.2",
                           IntelligenceAttributes = "23 + 3.4",
                           FirstAbility = "Cold Feet",
                           SecondAbility = "Ice Vortex",
                           ThirdAbility = "Chilling Touch",
                           UltimateAbility = "Ice Blast",
                           HeroBio = "One day, ice will cover these lands, and it will be as if this war never happened."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/axe.png",
                           HeroName = "Axe",
                           HeroRole = Enum.HeroRole.Offlane,
                           StreghtAttributes = "25 + 2.8",
                           AgilityAttributes = "20 + 2",
                           IntelligenceAttributes = "18 + 1.6",
                           FirstAbility = "Berserker's Call",
                           SecondAbility = "Battle Hunger",
                           ThirdAbility = "Counter Helix",
                           UltimateAbility = "Culling Blade",
                           HeroBio = "Axe is all the reinforcement this army needs!"
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/crystal_maiden.png",
                           HeroName = "Crystal Maiden",
                           HeroRole = Enum.HeroRole.Support,
                           StreghtAttributes = "17 + 2.2",
                           AgilityAttributes = "16 + 1.6",
                           IntelligenceAttributes = "16 + 3.3",
                           FirstAbility = "Crystal Nova",
                           SecondAbility = "Frostbite",
                           ThirdAbility = "Arcane Aura",
                           UltimateAbility = "Freezing Field",
                           HeroBio = "When Hell freezes over, I'll start calling it Heaven."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/earth_spirit.png",
                           HeroName = "Earth Spirit",
                           HeroRole = Enum.HeroRole.Offlane,
                           StreghtAttributes = "22 + 3.8",
                           AgilityAttributes = "17 + 2.4",
                           IntelligenceAttributes = "20 + 2.1",
                           FirstAbility = "Boulder Smash",
                           SecondAbility = "Rolling Boulder",
                           ThirdAbility = "Geomagnetic Grip",
                           UltimateAbility = "Magnetize",
                           HeroBio = "Through conflict, one's nature is revealed."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/ember_spirit.png",
                           HeroName = "Ember Spirit",
                           HeroRole = Enum.HeroRole.Midlane,
                           StreghtAttributes = "22 + 2.6",
                           AgilityAttributes = "22 + 3.2",
                           IntelligenceAttributes = "20 + 2.2",
                           FirstAbility = "Searing Chains",
                           SecondAbility = "Sleight of Fist",
                           ThirdAbility = "Flame Guard",
                           UltimateAbility = "Fire Remnant",
                           HeroBio = "Balance in all things."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/juggernaut.png",
                           HeroName = "Juggernaut",
                           HeroRole = Enum.HeroRole.Carry,
                           StreghtAttributes = "20 + 2.2",
                           AgilityAttributes = "34 + 2.8",
                           IntelligenceAttributes = "14 + 1.4",
                           FirstAbility = "Blade Fury",
                           SecondAbility = "Healing Ward",
                           ThirdAbility = "Blade Dance",
                           UltimateAbility = "Omnislash",
                           HeroBio = "By the Visage of Vengeance, which drowned in the Isle of Masks, I will carry on the rites of the Faceless Ones."
                        },
                        new Hero()
                        {
                           HeroImage = "/img/Heroes/Legion_Commander.png",
                           HeroName = "Legion Commander",
                           HeroRole = Enum.HeroRole.Carry,
                           StreghtAttributes = "25 + 3.3",
                           AgilityAttributes = "18 + 1.7",
                           IntelligenceAttributes = "20 + 2.2",
                           FirstAbility = "Overwhelming Odds",
                           SecondAbility = "Press the Attack",
                           ThirdAbility = "Moment of Courage",
                           UltimateAbility = "Duel",
                           HeroBio = "If they want war, then we shall give it to them!"
                        },
                    });
                    context.SaveChanges();
                }

                //Artifacts
                if (!context.Artifacts.Any())
                {
                    context.Artifacts.AddRange(new List<Artifact>()
                    { 
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/100px-Arcane_boots_hi_res.png",
                           ArtifactName = "Arcane Boots",
                           ArtifactBonus = "+250 Mana\r\n+45 Movement Speed",
                           ArtifactCost = 1300,
                           ArtifactDisription = "Restores 175 mana to all nearby allies."
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/Assault_Cuirass.png",
                           ArtifactName = "Assault Cuirass",
                           ArtifactBonus = "+10 Armor\r\n+30 Attack Speed",
                           ArtifactCost = 5125,
                           ArtifactDisription = "Grants 30 attack speed and 5 armor to nearby allied units and structures, and decreases nearby enemy unit and structure armor by 5."
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/basher.png",
                           ArtifactName = "Skull Basher",
                           ArtifactBonus = "+10 Strength\r\n+25 Attack Damage",
                           ArtifactCost = 2875,
                           ArtifactDisription = "Grants melee heroes a 25% chance on hit to stun the target for 1.5 seconds and deal 100 bonus physical damage. Bash chance for ranged heroes is 10%"
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/batterfly.png",
                           ArtifactName = "Butterfly",
                           ArtifactBonus = "++35 Agility\r\n+35% Evasion\r\n+25 Attack Damage\r\n+30 Attack Speed",
                           ArtifactCost = 4975,
                           ArtifactDisription = "Only the mightiest and most experienced of warriors can wield the Butterfly, but it provides incredible dexterity in combat."
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/desolator.png",
                           ArtifactName = "Desolator",
                           ArtifactBonus = "+50 Attack Damage",
                           ArtifactCost = 3500,
                           ArtifactDisription = "Attacks reduce the target's armor by 6 for 7 seconds."
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/dota2-sticker-items-dota-2-divine-11563146702lwzb6kcpjx.png",
                           ArtifactName = "Arcane Boots",
                           ArtifactBonus = "+350 Attack Damage",
                           ArtifactCost = 5950,
                           ArtifactDisription = "Dropped on death, and cannot be destroyed."
                        },
                        new Artifact()
                        {
                           ArtifactImage = "/img/Artifacts/travel_boots_lg200.png",
                           ArtifactName = "Boots of Travel",
                           ArtifactBonus = "+90/110 Movement Speed",
                           ArtifactCost = 2500,
                           ArtifactDisription = "Upgrades your Town Portal Scroll, allowing it to target units, reduces cooldown and does not consume a charge on usage."
                        },
                    });
                    context.SaveChanges();
                }

                //Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    { 
                        new Item()
                        {
                           ItemImage = "/img/Items/Anti-mage_Head_Hair of the Survivor.png",
                           ItemName = "Hair of the Survivor",
                           ItemPrice = 46.38,
                           Rarity = Enum.Rarity.Immortal,
                           PartOfSet = Enum.PartOfSet.Head,
                           HeroId = 2,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Antion_Apparation_Shatterblast Crown.png",
                           ItemName = "Shatterblast Crown",
                           ItemPrice = 96.53,
                           Rarity = Enum.Rarity.Rare,
                           PartOfSet = Enum.PartOfSet.Head,
                           HeroId = 3,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Axe_Genuine Axe of Phractos_Weapon.png",
                           ItemName = "Genuine Axe of Phractos",
                           ItemPrice = 14.61,
                           Rarity = Enum.Rarity.Immortal,
                           PartOfSet = Enum.PartOfSet.Weapon,
                           HeroId = 4,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Earth_Spirit_Weapon_Genuine Demon Vanquisher.png",
                           ItemName = "Genuine Demon Vanquisher",
                           ItemPrice = 99.99,
                           Rarity = Enum.Rarity.Legendary,
                           PartOfSet = Enum.PartOfSet.Weapon,
                           HeroId = 6,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Ember_Spirit_Head_Governor's Salakot.png",
                           ItemName = "Governor's Salakot",
                           ItemPrice = 20.87,
                           Rarity = Enum.Rarity.Mythical,
                           PartOfSet = Enum.PartOfSet.Head,
                           HeroId = 7,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Feast_of_Abscession_Pudge.png",
                           ItemName = "Feast_of_Abscession",
                           ItemPrice = 138.97,
                           Rarity = Enum.Rarity.Arcana,
                           PartOfSet = Enum.PartOfSet.Torso,
                           HeroId = 1,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Golden Ice Blossom_Crystal_Maiden_Weapon.png",
                           ItemName = "Golden Ice Blossom",
                           ItemPrice = 11.01,
                           Rarity = Enum.Rarity.Common,
                           PartOfSet = Enum.PartOfSet.Weapon,
                           HeroId = 5,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Juggernaut_Weapon_Genuine Kantusa the Script Sword.png",
                           ItemName = "Genuine Kantusa the Script Sword",
                           ItemPrice = 85.55,
                           Rarity = Enum.Rarity.Rare,
                           PartOfSet = Enum.PartOfSet.Weapon,
                           HeroId = 8,
                        },
                        new Item()
                        {
                           ItemImage = "/img/Items/Legion_Commander_Weapon_Exalted Blades of Voth Domosh.png",
                           ItemName = "Exalted Blades of Voth Domosh",
                           ItemPrice = 23.76,
                           Rarity = Enum.Rarity.Arcana,
                           PartOfSet = Enum.PartOfSet.Weapon,
                           HeroId = 9,
                        },
                    });
                    context.SaveChanges();

                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles 
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUserEmail = "admin@dota2shop.com";
                var adminUser = await userManager.FindByEmailAsync("admin@dota2shop.com");
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Name = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Dota2bestgame!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                var appUserEmail = "user@dota2shop.com";
                var appUser = await userManager.FindByEmailAsync("admin@dota2shop.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        Name = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Dota2bestgame!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
