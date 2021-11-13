using ETicket.Data.Cart;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService moviesService;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrdersService orderService;

        public OrdersController(
            IMoviesService moviesService, 
            ShoppingCart shoppingCart, 
            IOrdersService orderService)
        {
            this.moviesService = moviesService;
            this.shoppingCart = shoppingCart;
            this.orderService = orderService;
        }
        
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirst(ClaimTypes.Role).Value;
            var orders = await orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        // RedirectToActionResult and IActionResult work the same
        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string userEmailAddress = User.FindFirst(ClaimTypes.Email).Value;
            await orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
