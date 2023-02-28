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
        private readonly IOrdersService _ordersService;
        public OrdersController(IItemsService itemsService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _itemsService = itemsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
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

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
