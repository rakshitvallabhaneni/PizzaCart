using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaCart.Models;

namespace PizzaCart.Data
{
    public class PizzaCartContext : DbContext
    {
        public PizzaCartContext (DbContextOptions<PizzaCartContext> options)
            : base(options)
        {
        }

        public DbSet<PizzaCart.Models.Product> Product { get; set; }
    }
}
