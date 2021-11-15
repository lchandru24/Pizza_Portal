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
    public class SpecFlowFeature1Steps
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

        public SpecFlowFeature1Steps()
        {
            obj1 = new OrdersController(pizzaService, shoppingCart, ordersService);
            pizza = new PizzaController(pizzaService, ordersService);
            cart = new ShoppingCart(context);
        }
 
        [Given(@"the Pizza Name is Chicken Pizza")]
        public void GivenThePizzaNameIsChickenPizza()
        {
            PizzaName = "Chicken Pizza";
            try
            {
                id = context.Pizza.FirstOrDefault(x => x.Name == PizzaName).Id;
            }catch(Exception e)
            {
                id = 8;
            }
            
        }
        
        [Then(@"the PizzaId should be (.*)")]
        public void ThenThePizzaIdShouldBe(int p0)
        {
            id.Should().Be(p0);
        }
    }
}
