using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dota2_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemImage { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public Rarity Rarity { get; set; }
        public PartOfSet PartOfSet { get; set; }

        //Relationships
        public int HeroId { get; set; }
        [ForeignKey("HeroId")]
        public Hero Hero { get; set; }



    }
}
