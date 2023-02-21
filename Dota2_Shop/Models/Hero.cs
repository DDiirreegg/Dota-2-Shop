using Dota2_Shop.Date.Base;
using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Hero:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Hero Picture")]
        public string HeroImage { get; set; }

        [Display(Name = "Hero Name")]
        public string HeroName { get; set; }

        [Display(Name = "Hero Role")]
        public HeroRole HeroRole { get; set; }

        [Display(Name = "S. Attributes")]
        public string StreghtAttributes { get; set; }

        [Display(Name = "A. Attributes")]
        public string AgilityAttributes { get; set; }

        [Display(Name = "I. Attributes")]
        public string IntelligenceAttributes { get; set; }

        [Display(Name = "1 Ability")]
        public string FirstAbility { get; set; }

        [Display(Name = "2 Ability")]
        public string SecondAbility { get; set; }

        [Display(Name = "3 Ability")]
        public string ThirdAbility { get; set; }

        [Display(Name = "Ultimate")]
        public string UltimateAbility { get; set; }

        [Display(Name = "Biography")]
        public string HeroBio { get; set; }

        //Relationships
        public List<Item> Items { get; set; }
    }
}
