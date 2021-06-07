using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PizzaCart.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PizzaCartUser class
    public class PizzaCartUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(200)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }

    }
}
