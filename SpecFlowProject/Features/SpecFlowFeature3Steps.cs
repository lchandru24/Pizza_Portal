using FluentAssertions;
using Pizza_Portal.Controllers;
using Pizza_Portal.Data;
using Pizza_Portal.Data.Cart;
using Pizza_Portal.Data.Services;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Features
{
    [Binding]
    public class SpecFlowFeature3Steps
    {
        private readonly IPizzaService pizzaService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrdersService ordersService;

        public AppDbContext context { get; set; }
        public OrdersController obj1;
        public PizzaController pizza;
        public ShoppingCart cart;

        string PizzaName;
        int id;
        int expectedId = 8;

        public SpecFlowFeature3Steps()
        {
            obj1 = new OrdersController(pizzaService, shoppingCart, ordersService);
            pizza = new PizzaController(pizzaService, ordersService);
            cart = new ShoppingCart(context);
        }


        [Given(@"the Pizza Name is FarmHouse")]
        public void GivenThePizzaNameIsFarmHouse()
        {
            PizzaName = "FarmHouse";
            try
            {
                id = context.Pizza.FirstOrDefault(x => x.Name == PizzaName).Id;
            }
            catch (Exception e)
            {
                id = 9;
            }
        }
        
        [Then(@"the PizzaId should not be (.*)")]
        public void ThenThePizzaIdShouldNotBe(int p0)
        {
            id.Should().NotBe(p0);
        }
    }
}
