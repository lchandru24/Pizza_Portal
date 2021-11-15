using Microsoft.AspNetCore.Mvc;
using Pizza_Portal.Data.Cart;
using Pizza_Portal.Data.Services;
using Pizza_Portal.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pizza_Portal.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IPizzaService pizzaService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _pizzaService = pizzaService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

/*        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }*/

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

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _pizzaService.GetPizzaByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _pizzaService.GetPizzaByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
            return View("OrderCompleted", orders);
        }


    }
}
