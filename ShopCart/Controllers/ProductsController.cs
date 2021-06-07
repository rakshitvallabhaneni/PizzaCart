using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaCart.Data;
using PizzaCart.Models;

namespace PizzaCart.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly PizzaCartContext _context;

        public ProductsController(PizzaCartContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var products = from x in _context.Product
                           select x;

            if(!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Name.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                default:
                    products = products.OrderBy(x => x.Id);
                    break;
            }

            sortOrder = null;
            return View(await products.AsNoTracking().ToListAsync());
        }
    }
}
