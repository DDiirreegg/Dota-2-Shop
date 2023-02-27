using Dota2_Shop.Date.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Dota2_Shop.Date.ViewComponents
{
    public class ShoppingCartIcon:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartIcon(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
