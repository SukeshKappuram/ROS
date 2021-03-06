﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ROS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ROS.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.Recipe> Recipes { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.CartItem> CartItems { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.ShippingAddress> ShippingAddresses { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.SalesOrder> SalesOrders { get; set; }
        public System.Data.Entity.DbSet<ROS.Models.OrderDetails> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.SpecialOffer> SpecialOffers { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.RestaurantTable> RestaurantTables { get; set; }

        public System.Data.Entity.DbSet<ROS.Models.Feedback> Feedbacks { get; set; }
    }
}