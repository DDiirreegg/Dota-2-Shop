using Dota2_Shop.Date.Base;
using Dota2_Shop.Date.ViewModels;
using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date.Services
{
    public class ItemService:EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var itemDetails = await _context.Items.Include(h => h.Hero).FirstOrDefaultAsync(n => n.Id == id);
            return itemDetails;
        }

        public async Task<NewItemDropdownVM> GetNewItemDropdownsValues()
        {
            var respons = new NewItemDropdownVM();
            respons.Heroes = await _context.Heros.OrderBy(n => n.HeroName).ToListAsync();
            return respons;
        }
    }
}
