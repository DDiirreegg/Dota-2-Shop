using Dota2_Shop.Date.Base;
using Dota2_Shop.Date.ViewModels;
using Dota2_Shop.Models;

namespace Dota2_Shop.Date.Services
{
    public interface IItemsService: IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<NewItemDropdownVM> GetNewItemDropdownsValues();
        Task AddNewItemAsync(NewItemVM date);
        Task UpdateItemAsync(NewItemVM date);
       

    }
}
