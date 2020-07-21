﻿using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
            // Intentionally left blank
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Low-Key",
                    StreetAddress = "12345 California Ave Sw, Seattle Wa 98116",
                    City = "Seattle",
                    State = "Wa",
                    Phone = "(206)555-1212"
                },
                new Hotel
                {
                    Id = 2,
                    Name = "High-Key",
                    StreetAddress = "12345 Stone Way Ave Sw, Seattle Wa 98006",
                    City = "Seattle",
                    State = "Wa",
                    Phone = "(206)545-1212"
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Whack",
                    StreetAddress = "12345 Denny Ave Sw, Seattle Wa 98186",
                    City = "Seattle",
                    State = "Wa",
                    Phone = "(206)455-1212"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "The Workshop",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    Id = 2,
                    Name = "London Flat",
                    Layout = Layout.Studio
                },
                new Room
                {
                    Id = 3,
                    Name = "Icheon Penthouse",
                    Layout = Layout.TwoBedroom
                }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    Id = 1,
                    Name = "Workbench"
                },
                new Amenity
                {
                    Id = 2,
                    Name = "Tea Pot"
                },
                new Amenity
                {
                    Id = 3,
                    Name = "Infinity Pool"
                }
                );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
