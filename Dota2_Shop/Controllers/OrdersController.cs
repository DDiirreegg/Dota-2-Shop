using Dota2_Shop.Date.Cart;
using Dota2_Shop.Date.Services;
using Dota2_Shop.Date.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dota2_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IItemsService _itemsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersServer _ordersServer;
        public OrdersController(IItemsService itemsService, ShoppingCart shoppingCart, IOrdersServer ordersServer)
        {
            _itemsService = itemsService;
            _shoppingCart = shoppingCart;
            _ordersServer = ordersServer;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        //Add item to cart
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var scitem = await _itemsService.GetItemByIdAsync(id);
            if(scitem != null)
            {
                _shoppingCart.AddItemToCart(scitem);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        //Remove item from cart
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var scitem = await _itemsService.GetItemByIdAsync(id);
            if (scitem != null)
            {
                _shoppingCart.RemoveItemFromCart(scitem);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        //Complete order
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersServer.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
