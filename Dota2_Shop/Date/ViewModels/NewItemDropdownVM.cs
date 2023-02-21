using Dota2_Shop.Models;

namespace Dota2_Shop.Date.ViewModels
{
    public class NewItemDropdownVM
    {
        public NewItemDropdownVM()
        {
            Heroes = new List<Hero>();
        }
        public List<Hero> Heroes { get; set; }           
    }
}
