using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pizza_Portal.Controllers;
using Pizza_Portal.Data;
using Pizza_Portal.Data.Cart;
using Pizza_Portal.Data.Services;
using Pizza_Portal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnit_Test
{
    public class Tests
    {
        private readonly IPizzaService pizzaService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrdersService ordersService;

        public AppDbContext context { get; set; }
        public OrdersController obj1;
        public PizzaController pizza;
        public ShoppingCart cart;
        public Tests()
        {
            obj1 = new OrdersController(pizzaService, shoppingCart, ordersService);
            pizza = new PizzaController(pizzaService, ordersService);
            cart = new ShoppingCart(context);
           
        }

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task Index()
        {
            //Act
            Task<IActionResult> result = (Task<IActionResult>)pizza.Index();

            //Assert
            Assert.IsNotNull(result);
            
        }

        [Test]
        public void ShoppingCart()
        {
            //Act
            double res = cart.GetShoppingCartTotal();

            //Assert
            Assert.AreEqual(0, res);

        }

        [Test]
        public void AddItemToShoppingCart()
        {
            var res1 = obj1.AddItemToShoppingCart(7);

            Assert.IsNotNull(res1);
        }

        [Test]
        public void RemoveItemToShoppingCart()
        {
            var res1 = obj1.RemoveItemFromShoppingCart(7);

            Assert.IsNotNull(res1);
        }

        [Test]
        public void CompleteOrder()
        {
            var res1 = obj1.CompleteOrder();

            Assert.IsNotNull(res1);
        }

    }
}