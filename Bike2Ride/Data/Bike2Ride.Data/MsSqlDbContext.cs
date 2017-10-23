﻿using System;
using System.Data.Entity;
using System.Linq;

using Bike2Ride.Data.Models;
using Bike2Ride.Data.Models.Contracts;

using Microsoft.AspNet.Identity.EntityFramework;

namespace Bike2Ride.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        private const string LocalConnection = "LocalConnection";

        public MsSqlDbContext()
            : base(LocalConnection, throwIfV1Schema: false)
        {
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

    }
}
