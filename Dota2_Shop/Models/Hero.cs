using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string HeroImage { get; set; }
        public string HeroName { get; set; }
        public HeroRole HeroRole { get; set; }
        public string StreghtAttributes { get; set; }
        public string AgilityAttributes { get; set; }
        public string IntelligenceAttributes { get; set; }
        public string FirstAbility { get; set; }
        public string SecondAbility { get; set; }
        public string ThirdAbility { get; set; }
        public string UltimateAbility { get; set; }
        public string HeroBio { get; set; }
    }
}
