using Dota2_Shop.Date.Cart;
using Dota2_Shop.Date.Services;
using Dota2_Shop.Date.Static;
using Dota2_Shop.Date.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dota2_Shop.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
