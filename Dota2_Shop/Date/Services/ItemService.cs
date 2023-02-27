using Dota2_Shop.Date.Base;
using Dota2_Shop.Date.Enum;
using Dota2_Shop.Date.ViewModels;
using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dota2_Shop.Date.Services
{
    public class ItemService:EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task AddNewItemAsync(NewItemVM date)
        {
            var newItem = new Item()
            {
                ItemImage = date.ItemImage,
                ItemName = date.ItemName,
                ItemPrice = date.ItemPrice,
                Rarity = date.Rarity,
                PartOfSet = date.PartOfSet,
                HeroId = date.HeroId
            };
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }

       
        public async Task<Item> GetItemByIdAsync(int id)
        {
            var itemDetails = await _context.Items.Include(h => h.Hero).FirstOrDefaultAsync(n => n.Id == id);
            return itemDetails;
        }

        public async Task<NewItemDropdownVM> GetNewItemDropdownsValues()
        {
            var respons = new NewItemDropdownVM();
            respons.Heros = await _context.Heros.OrderBy(n => n.HeroName).ToListAsync();
            return respons;
        }

        public async Task UpdateItemAsync(NewItemVM date)
        {
            var dbItem = await _context.Items.FirstOrDefaultAsync(n => n.Id == date.Id);

            if (dbItem != null)
            {
                dbItem.ItemImage = date.ItemImage;
                dbItem.ItemName = date.ItemName;
                dbItem.ItemPrice = date.ItemPrice;
                dbItem.Rarity = date.Rarity;
                dbItem.PartOfSet = date.PartOfSet;
                dbItem.HeroId = date.HeroId;
                await _context.SaveChangesAsync();
            }             
        }
    }
}

