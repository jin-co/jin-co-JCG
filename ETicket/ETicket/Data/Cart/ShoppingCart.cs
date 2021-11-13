using ETicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            this.context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            // if session exists get it using service provider
            ISession session = 
                service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = context.ShoppingCartItems
                .FirstOrDefault(n => n.Movie.Id == movie.Id &&
                n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = context.ShoppingCartItems
                .FirstOrDefault(n => n.Movie.Id == movie.Id &&
                n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? ( // ??: null check
                ShoppingCartItems = context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n => n.Movie)
                .ToList());
        }

        public double GetShoppingCartTotal()
        {
            return context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Movie.Price * n.Amount).Sum();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .ToListAsync();
            context.ShoppingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }
    }
}
