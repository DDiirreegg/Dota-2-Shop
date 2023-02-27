using Dota2_Shop.Models;

namespace Dota2_Shop.Date.ViewModels
{
    public class NewItemDropdownVM
    {
        public NewItemDropdownVM()
        {
            Heros = new List<Hero>();
        }
        public List<Hero> Heros { get; set; }           
    }
}
