using ETicket.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.ViewComponents
{
    // there are three ways to get C# recognize Viewcomponent
    // 1: name it ~~ViewComponet
    // 2: use decoration [ViewComponent]
    // 3: inherit
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
