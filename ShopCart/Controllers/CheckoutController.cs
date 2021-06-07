using Microsoft.AspNetCore.Mvc;
using PizzaCart.Helpers;
using PizzaCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCart.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(x => x.Product.Price * x.Quantity);
            return View();
        }
    }
}
