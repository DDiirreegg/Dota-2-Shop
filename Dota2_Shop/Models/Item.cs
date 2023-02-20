using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dota2_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Image")]
        public string ItemImage { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Price")]
        public double ItemPrice { get; set; }

        [Display(Name = "Rarity")]
        public Rarity Rarity { get; set; }

        [Display(Name = "Part Of Set")]
        public PartOfSet PartOfSet { get; set; }

        //Relationships
        public int HeroId { get; set; }
        [ForeignKey("HeroId")]

        [Display(Name = "Hero")]
        public Hero Hero { get; set; }



    }
}
