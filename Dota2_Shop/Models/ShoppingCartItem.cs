using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Total { get; set; }
        public string ShoppingCartId { get; set; }


    }
}
