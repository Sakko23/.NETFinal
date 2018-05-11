using RentApartmentFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApartmentFinal.Data
{
    public class DbInitializer
    {


        public static void Initialize(RentContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Regions.Any()) { return; }

            var regions = new Region[]
            {
                new Region {Name="District 1", Tax=10},
                new Region {Name="District 2", Tax=15},
                new Region {Name="District 3", Tax=30},
                new Region {Name="District 4", Tax=50},
            };
            foreach (Region r in regions)
            {
                context.Regions.Add(r);
            }
            context.SaveChanges();

            var apartments = new Apartment[]
            {
                new Apartment {Address="Street 1", RegionID=1, Price=15000},
                new Apartment {Address="Street 2", RegionID=1, Price=140000},

                new Apartment {Address="Street 3", RegionID=2, Price=85000},
                new Apartment {Address="Street 4", RegionID=2, Price=100000},

                new Apartment {Address="Street 5", RegionID=3, Price=67000},
                new Apartment {Address="Street 6", RegionID=3, Price=55000},
                

                new Apartment {Address="Street 7", RegionID=4, Price=75000},
                new Apartment {Address="Street 8", RegionID=4, Price=85000},
            };
            foreach (Apartment a in apartments)
            {
                context.Apartments.Add(a);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer {Username="user1", Password="user1"},
                new Customer {Username="user2", Password="user2"},
                new Customer {Username="user3", Password="user3"},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var rents = new Rent[]
            {
                new Rent {CustomerID=5, TotalPrice=550000},
            };
            foreach (Rent r in rents)
            {
                context.Rents.Add(r);
            }
            context.SaveChanges();

            var rentDetails = new RentDetail[]
            {
                new RentDetail {RentID=1, ApartmentID=1},
                new RentDetail {RentID=1, ApartmentID=2},
                new RentDetail {RentID=1, ApartmentID=3},
            };
            foreach(RentDetail rd in rentDetails)
            {
                context.RentDetails.Add(rd);
            }
            context.SaveChanges();
        }
    }
}
