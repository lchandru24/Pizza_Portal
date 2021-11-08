using Microsoft.EntityFrameworkCore;
using Pizza_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Portal.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAllOrderAsync()
        {
            var items = await _context.Order.ToListAsync();
            _context.Order.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
                var orders = await _context.Order.Include(n => n.OrderItems).ThenInclude(n => n.Pizza).Where(n => n.UserId == userId).ToListAsync();
                return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    PizzaId = item.Pizza.Id,
                    OrderId = order.Id,
                    Price = item.Pizza.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
