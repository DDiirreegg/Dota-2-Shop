using Dota2_Shop.Date.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemImage { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public Rarity Rarity { get; set; }
        public PartOfSet PartOfSet { get; set; }
        

    }
}
