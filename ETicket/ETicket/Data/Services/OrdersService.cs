using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext context;

        public OrdersService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(
            string userId, string userRole)
        {
            //return await context.Orders
            //    .Include(n => n.OrderItems)
            //    .ThenInclude(n => n.Movie)
            //    .Where(n => n.UserId == userId)
            //    .ToListAsync();
            var orders = await context.Orders
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Movie)
                .Include(n => n.User)
                .ToListAsync();

            if (userRole != "Admin")
            {
                orders = await context.Orders
                .Where(n => n.UserId == userId)
                .ToListAsync();
            }

            return orders;
        }

        public async Task StoreOrderAsync(
            List<ShoppingCartItem> items, 
            string userId, 
            string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            foreach (var i in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = i.Amount,
                    MovieId = i.Movie.Id,
                    OrderId = order.Id,
                    Price = i.Movie.Price
                };
                await context.OrderItems.AddAsync(orderItem);
            }
            await context.SaveChangesAsync();
        }
    }
}
