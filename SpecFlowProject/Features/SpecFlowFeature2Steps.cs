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
    public class SpecFlowFeature2Steps
    {
        private readonly IPizzaService pizzaService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrdersService ordersService;

        public AppDbContext context { get; set; }
        public OrdersController obj1;
        public PizzaController pizza;
        public ShoppingCart cart;

        public int OrderId;

        public int expectedOrderQuantity;
        public int OrderQuantity;

        public int expectedPizzaId;
        public int PizzaId;

        public double expectedPrice;
        public double Price;

        public SpecFlowFeature2Steps()
        {
            obj1 = new OrdersController(pizzaService, shoppingCart, ordersService);
            pizza = new PizzaController(pizzaService, ordersService);
            context = new AppDbContext();
            cart = new ShoppingCart(context);
        }

        [Given(@"the order id is (.*)")]
        public void GivenTheOrderIdIs(int p0)
        {
            OrderId = p0;
        }
        
        [Then(@"order quantity should be (.*)")]
        public void ThenOrderQuantityShouldBe(int p0)
        {
            expectedOrderQuantity = p0;
            OrderQuantity = context.OrderItems.FirstOrDefault(x => x.OrderId == OrderId).Amount;
            OrderQuantity.Should().Be(expectedOrderQuantity);
        }
        
        [Then(@"the Pizza Id should be (.*)")]
        public void ThenThePizzaIdShouldBe(int p0)
        {
            expectedPizzaId = p0;
            PizzaId = context.OrderItems.FirstOrDefault(x => x.PizzaId == p0).PizzaId;
            PizzaId.Should().Be(expectedPizzaId);
        }
        
        [Then(@"the Pizza Price should be (.*)")]
        public void ThenThePizzaPriceShouldBe(int p0)
        {
            expectedPrice = p0;
            Price = context.OrderItems.FirstOrDefault(x => x.OrderId == OrderId).Price;

            Price.Should().Be((int)expectedPrice);
        }
    }
}
