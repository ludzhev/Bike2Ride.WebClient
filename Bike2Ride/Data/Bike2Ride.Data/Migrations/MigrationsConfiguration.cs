using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using Bike2Ride.Data.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bike2Ride.Data.Migrations
{
    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public MigrationsConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            this.SeedUsers(context);
            this.SeedLocations(context);

            base.Seed(context);
        }

        private void SeedLocations(MsSqlDbContext context)
        {
            var center = new Location()
            {
                Lat = 42.70,
                Lng = 23.317
            };

            var existingCenter = context
                .Locations
                .FirstOrDefault(l => l.Lat == center.Lat && l.Lng == center.Lng)
                ?? center;

            City sofia = new City
            {
                Name = "Sofia",
                Center = existingCenter,
                ZoomLevel = 12,
                Locations = new List<Location>()
                {
                    new Location()
                    {
                        Lat = 42.705,
                        Lng = 23.297
                    },
                    new Location()
                    {
                        Lat = 42.690,
                        Lng = 23.337
                    },
                    new Location()
                    {
                        Lat = 42.651,
                        Lng = 23.379
                    },
                    new Location()
                    {
                        Lat = 42.674,
                        Lng = 23.310
                    }
                }
            };

            context.Cities.AddOrUpdate(c => c.Name, sofia);
        }

        private void SeedUsers(MsSqlDbContext context)
        {
            const string AdministratorUserName = "bike2ride@gmail.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
