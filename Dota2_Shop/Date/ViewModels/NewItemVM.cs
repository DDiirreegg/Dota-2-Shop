using Dota2_Shop.Date.Base;
using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dota2_Shop.Models
{
    public class NewItemVM
    {
        public int Id { get; set; }

        [Display(Name ="Insert image")]        
        public string ItemImage { get; set; }

        [Display(Name = "Enter a name")]
        public string ItemName { get; set; }

        [Display(Name = "Choose a price")]
        public double ItemPrice { get; set; }

        [Display(Name = "Select rarity")]
        public Rarity Rarity { get; set; }

        [Display(Name = "Select part")]
        public PartOfSet PartOfSet { get; set; }

        //Relationships
        [Display(Name = "Choose a hero")]
        public int HeroId { get; set; }

        

        
        



    }
}
