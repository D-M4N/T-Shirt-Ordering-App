using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TshirtOrderingAPI.Api.Models;

namespace TshirtOrderingAPI.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(ShirtInfo context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Squeaky Bone",

                        Gender = "Male",

                        ShirtSize = "Medium",

                        DateOfOrder = "October",

                        ShirtName = "Crysis",

                        ShippingAddress = "Cape Town",

                        EmailAddress = "djbessick@gmail.com",

                        ContactDetails = "0782006868"


                    }
                ) ;

                context.SaveChanges();
            }
        }
    }
}
