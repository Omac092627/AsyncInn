﻿using AsyncInn.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AsyncInn.Models
{


    public class RoleInitializer
    {



        //create a list of identity roles
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.DistrictManager, NormalizedName = ApplicationRoles.DistrictManager.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.PropertyManager, NormalizedName = ApplicationRoles.PropertyManager.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            new IdentityRole{Name = ApplicationRoles.Agent, NormalizedName = ApplicationRoles.Agent.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() }
            };


        //method that creates/checks the roles
        //add the roles into the db directly



        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AsyncInnDbContext(serviceProvider.GetRequiredService<DbContextOptions<AsyncInnDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        public static void AddRoles(AsyncInnDbContext context)
        {
            if (context.Roles.Any()) return;

            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }





    }


}
