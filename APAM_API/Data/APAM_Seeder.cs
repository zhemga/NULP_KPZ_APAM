using APAM_API.Models;
using APAM_API.Models.Identity_Users;
using APAM_API.Models.IdentityUsers;
using APAM_API.Models.Selling_System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace APAM_API.Data
{
    public class APAM_Seeder : DropCreateDatabaseIfModelChanges<APAM_APIContext>
    {
        protected override void Seed(APAM_APIContext context)
        {
            // Add Users (AutoPartSupplier, Customer, Seller)
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var autoPartSupplierRole = new IdentityRole { Name = "AutoPartSupplier" };
            var customerRole = new IdentityRole { Name = "Customer" };
            var sellerRole = new IdentityRole { Name = "Selller" };
            roleManager.Create(autoPartSupplierRole);
            roleManager.Create(customerRole);
            roleManager.Create(sellerRole);

            var autoPartSupplier1 = new AutoPartSupplier { Id = "4", UserName = "AutoPartSupplier2" };
            var autoPartSupplier2 = new AutoPartSupplier { Id = "5", UserName = "AutoPartSupplier3" };
            var autoPartSupplier3 = new AutoPartSupplier { Id = "6", UserName = "AutoPartSupplier4" };
            var autoPartSupplier4 = new AutoPartSupplier { Id = "7", UserName = "AutoPartSupplier5" };
            var autoPartSupplier5 = new AutoPartSupplier { Id = "8", UserName = "AutoPartSupplier6" };

            var customer1 = new Customer { Id = "9", UserName = "Customer2" };
            var customer2 = new Customer { Id = "10", UserName = "Customer3" };
            var customer3 = new Customer { Id = "11", UserName = "Customer4" };
            var customer4 = new Customer { Id = "12", UserName = "Customer5" };
            var customer5 = new Customer { Id = "13", UserName = "Customer6" };

            var seller1 = new Seller { Id = "14", UserName = "Seller2" };
            var seller2 = new Seller { Id = "15", UserName = "Seller3" };
            var seller3 = new Seller { Id = "16", UserName = "Seller4" };
            var seller4 = new Seller { Id = "17", UserName = "Seller5" };
            var seller5 = new Seller { Id = "18", UserName = "Seller6" };

            userManager.Create(autoPartSupplier1, "Password123");
            userManager.Create(autoPartSupplier2, "Password123");
            userManager.Create(autoPartSupplier3, "Password123");
            userManager.Create(autoPartSupplier4, "Password123");
            userManager.Create(autoPartSupplier5, "Password123");

            userManager.AddToRole(autoPartSupplier1.Id, autoPartSupplierRole.Name);
            userManager.AddToRole(autoPartSupplier2.Id, autoPartSupplierRole.Name);
            userManager.AddToRole(autoPartSupplier3.Id, autoPartSupplierRole.Name);
            userManager.AddToRole(autoPartSupplier4.Id, autoPartSupplierRole.Name);
            userManager.AddToRole(autoPartSupplier5.Id, autoPartSupplierRole.Name);

            userManager.Create(customer1, "Password123");
            userManager.Create(customer2, "Password123");
            userManager.Create(customer3, "Password123");
            userManager.Create(customer4, "Password123");
            userManager.Create(customer5, "Password123");

            userManager.AddToRole(customer1.Id, customerRole.Name);
            userManager.AddToRole(customer2.Id, customerRole.Name);
            userManager.AddToRole(customer3.Id, customerRole.Name);
            userManager.AddToRole(customer4.Id, customerRole.Name);
            userManager.AddToRole(customer5.Id, customerRole.Name);

            userManager.Create(seller1, "Password123");
            userManager.Create(seller2, "Password123");
            userManager.Create(seller3, "Password123");
            userManager.Create(seller4, "Password123");
            userManager.Create(seller5, "Password123");

            userManager.AddToRole(seller1.Id, sellerRole.Name);
            userManager.AddToRole(seller2.Id, sellerRole.Name);
            userManager.AddToRole(seller3.Id, sellerRole.Name);
            userManager.AddToRole(seller4.Id, sellerRole.Name);
            userManager.AddToRole(seller5.Id, sellerRole.Name);

            // Add AutoPartCategories
            var categories = new List<AutoPartCategory>
            {
                new AutoPartCategory { Id = "1", Name = "Engine Parts" },
                new AutoPartCategory { Id = "2", Name = "Brake System" },
                new AutoPartCategory { Id = "3", Name = "Suspension Parts" },
                new AutoPartCategory { Id = "4", Name = "Electrical Components" },
                new AutoPartCategory { Id = "5", Name = "Transmission Parts" },
            };
            context.AutoPartCategories.AddRange(categories);
            context.SaveChanges();

            // Add AutoPartManufacturers
            var manufacturers = new List<AutoPartManufacturer>
            {
                new AutoPartManufacturer { Id = "1", Name = "Robert Bosch GmbH", Country = "Germany" },
                new AutoPartManufacturer { Id = "2", Name = "Denso Corp", Country = "Japan" },
                new AutoPartManufacturer { Id = "3", Name = "ACDelco", Country = "USA" },
                new AutoPartManufacturer { Id = "4", Name = "Bridgestone Corporation", Country = "Japan" },
            };
            context.AutoPartManufacturers.AddRange(manufacturers);
            context.SaveChanges();

            // Add AutoParts
            var autoParts = new List<AutoPart>
            {
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "1", AutoName = "Piston Assembly", Price = 120.00m, AutoPartCategoryId = "1", AutoPartSupplierId = autoPartSupplier1.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[1].Id, Id = "2", AutoName = "Brake Pad Set", Price = 35.50m, AutoPartCategoryId = "2", AutoPartSupplierId = autoPartSupplier1.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[2].Id, Id = "3", AutoName = "Shock Absorber", Price = 80.00m, AutoPartCategoryId = "3", AutoPartSupplierId = autoPartSupplier2.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[3].Id, Id = "4", AutoName = "Spark Plug Set", Price = 15.00m, AutoPartCategoryId = "4", AutoPartSupplierId = autoPartSupplier2.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "5", AutoName = "Transmission Kit", Price = 250.00m, AutoPartCategoryId = "5", AutoPartSupplierId = autoPartSupplier2.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[1].Id, Id = "6", AutoName = "Alternator Assembly", Price = 120.00m, AutoPartCategoryId = "4", AutoPartSupplierId = autoPartSupplier3.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[2].Id, Id = "7", AutoName = "Brake Rotor Set", Price = 45.00m, AutoPartCategoryId = "2", AutoPartSupplierId = autoPartSupplier3.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[3].Id, Id = "8", AutoName = "Strut Assembly", Price = 100.00m, AutoPartCategoryId = "3", AutoPartSupplierId = autoPartSupplier3.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "9", AutoName = "Ignition Coil Pack", Price = 30.00m, AutoPartCategoryId = "4", AutoPartSupplierId = autoPartSupplier4.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "10", AutoName = "Clutch Kit", Price = 150.00m, AutoPartCategoryId = "5", AutoPartSupplierId = autoPartSupplier1.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[1].Id, Id = "11", AutoName = "Starter Motor", Price = 80.00m, AutoPartCategoryId = "4", AutoPartSupplierId = autoPartSupplier4.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[2].Id, Id = "12", AutoName = "Wheel Bearing Set", Price = 25.00m, AutoPartCategoryId = "3", AutoPartSupplierId = autoPartSupplier4.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[3].Id, Id = "13", AutoName = "Fuel Pump Assembly", Price = 70.00m, AutoPartCategoryId = "1", AutoPartSupplierId = autoPartSupplier5.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[1].Id, Id = "14", AutoName = "Oxygen Sensor", Price = 40.00m, AutoPartCategoryId = "4", AutoPartSupplierId = autoPartSupplier5.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[2].Id, Id = "15", AutoName = "Control Arm Kit", Price = 120.00m, AutoPartCategoryId = "3", AutoPartSupplierId = autoPartSupplier5.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[2].Id, Id = "16", AutoName = "Water Pump Assembly", Price = 50.00m, AutoPartCategoryId = "1", AutoPartSupplierId = autoPartSupplier4.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[3].Id, Id = "17", AutoName = "Power Steering Pump", Price = 90.00m, AutoPartCategoryId = "5", AutoPartSupplierId = autoPartSupplier3.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "18", AutoName = "Exhaust Manifold", Price = 60.00m, AutoPartCategoryId = "1", AutoPartSupplierId = autoPartSupplier1.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "19", AutoName = "Thermostat Housing", Price = 15.00m, AutoPartCategoryId = "1", AutoPartSupplierId = autoPartSupplier1.Id },
                new AutoPart {AutoPartManufacturerId = manufacturers[0].Id, Id = "20", AutoName = "CV Joint Kit", Price = 35.00m, AutoPartCategoryId = "5", AutoPartSupplierId = autoPartSupplier1.Id },
            };
            context.AutoParts.AddRange(autoParts);
            context.SaveChanges();

            // Add DeliveryStatus
            var deliveryStatuses = new List<DeliveryStatus>
            {
                new DeliveryStatus { Id = "1", Name = "Processing" },
                new DeliveryStatus { Id = "2", Name = "Shipped" },
                new DeliveryStatus { Id = "3", Name = "Delivered" },
                new DeliveryStatus { Id = "4", Name = "Returned" },
                new DeliveryStatus { Id = "5", Name = "Delayed" },
            };
            context.DeliveryStatuses.AddRange(deliveryStatuses);
            context.SaveChanges();

            // Add Orders
            var orders = new List<Order>
            {
                new Order { Id = "1", CustomerId = customer1.Id, SellerId = seller1.Id, AutoPartId = autoParts[0].Id },
                new Order { Id = "2", CustomerId = customer1.Id, SellerId = seller2.Id, AutoPartId = autoParts[1].Id },
                new Order { Id = "3", CustomerId = customer2.Id, SellerId = seller3.Id, AutoPartId = autoParts[2].Id },
                new Order { Id = "4", CustomerId = customer2.Id, SellerId = seller4.Id, AutoPartId = autoParts[3].Id },
                new Order { Id = "5", CustomerId = customer3.Id, SellerId = seller5.Id, AutoPartId = autoParts[4].Id },
                new Order { Id = "6", CustomerId = customer3.Id, SellerId = seller1.Id, AutoPartId = autoParts[5].Id },
                new Order { Id = "7", CustomerId = customer4.Id, SellerId = seller2.Id, AutoPartId = autoParts[6].Id },
                new Order { Id = "8", CustomerId = customer4.Id, SellerId = seller3.Id, AutoPartId = autoParts[7].Id },
                new Order { Id = "9", CustomerId = customer5.Id, SellerId = seller4.Id, AutoPartId = autoParts[8].Id },
                new Order { Id = "10", CustomerId = customer5.Id, SellerId = seller5.Id, AutoPartId = autoParts[9].Id },
                new Order { Id = "11", CustomerId = customer2.Id, SellerId = seller4.Id, AutoPartId = autoParts[10].Id },
                new Order { Id = "12", CustomerId = customer2.Id, SellerId = seller2.Id, AutoPartId = autoParts[11].Id },
                new Order { Id = "13", CustomerId = customer2.Id, SellerId = seller1.Id, AutoPartId = autoParts[12].Id },
                new Order { Id = "14", CustomerId = customer2.Id, SellerId = seller2.Id, AutoPartId = autoParts[13].Id },
                new Order { Id = "15", CustomerId = customer1.Id, SellerId = seller3.Id, AutoPartId = autoParts[14].Id },
                new Order { Id = "16", CustomerId = customer1.Id, SellerId = seller4.Id, AutoPartId = autoParts[15].Id },
                new Order { Id = "17", CustomerId = customer2.Id, SellerId = seller5.Id, AutoPartId = autoParts[16].Id },
                new Order { Id = "18", CustomerId = customer2.Id, SellerId = seller3.Id, AutoPartId = autoParts[17].Id },
                new Order { Id = "19", CustomerId = customer3.Id, SellerId = seller1.Id, AutoPartId = autoParts[18].Id },
                new Order { Id = "20", CustomerId = customer3.Id, SellerId = seller1.Id, AutoPartId = autoParts[19].Id },
                new Order { Id = "21", CustomerId = customer4.Id, SellerId = seller2.Id, AutoPartId = autoParts[0].Id },
                new Order { Id = "22", CustomerId = customer4.Id, SellerId = seller3.Id, AutoPartId = autoParts[1].Id },
                new Order { Id = "23", CustomerId = customer5.Id, SellerId = seller4.Id, AutoPartId = autoParts[2].Id },
                new Order { Id = "24", CustomerId = customer5.Id, SellerId = seller5.Id, AutoPartId = autoParts[3].Id },
                new Order { Id = "25", CustomerId = customer3.Id, SellerId = seller5.Id, AutoPartId = autoParts[4].Id },
                new Order { Id = "26", CustomerId = customer2.Id, SellerId = seller5.Id, AutoPartId = autoParts[5].Id },
                new Order { Id = "27", CustomerId = customer1.Id, SellerId = seller1.Id, AutoPartId = autoParts[6].Id },
                new Order { Id = "28", CustomerId = customer5.Id, SellerId = seller2.Id, AutoPartId = autoParts[7].Id },
                new Order { Id = "29", CustomerId = customer1.Id, SellerId = seller3.Id, AutoPartId = autoParts[8].Id },
                new Order { Id = "30", CustomerId = customer1.Id, SellerId = seller4.Id, AutoPartId = autoParts[9].Id },
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

            // Add Deliveries
            var deliveries = new List<Delivery>
            {
                new Delivery
                {
                    Id = "1",
                    LocationFrom = "Warehouse A",
                    LocationTo = "Customer Address",
                    Price = 15.00m,
                    Status_Id = deliveryStatuses[1].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(3),
                    Orders = orders.GetRange(0, 3)
                },
                new Delivery
                {
                    Id = "2",
                    LocationFrom = "Warehouse B",
                    LocationTo = "Customer Address",
                    Price = 20.00m,
                    Status_Id = deliveryStatuses[2].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(4),
                    Orders = orders.GetRange(3, 3)
                },
                new Delivery
                {
                    Id = "3",
                    LocationFrom = "Warehouse C",
                    LocationTo = "Customer Address",
                    Price = 18.00m,
                    Status_Id = deliveryStatuses[3].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(2),
                    Orders = orders.GetRange(6, 4)
                },
                new Delivery
                {
                    Id = "4",
                    LocationFrom = "Warehouse B",
                    LocationTo = "Customer Address",
                    Price = 25.00m,
                    Status_Id = deliveryStatuses[2].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(5),
                    Orders = orders.GetRange(10, 2)
                },
                new Delivery
                {
                    Id = "5",
                    LocationFrom = "Warehouse C",
                    LocationTo = "Customer Address",
                    Price = 30.00m,
                    Status_Id = deliveryStatuses[2].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(6),
                    Orders = orders.GetRange(12, 2)
                },
                new Delivery
                {
                    Id = "6",
                    LocationFrom = "Warehouse A",
                    LocationTo = "Customer Address",
                    Price = 20.00m,
                    Status_Id = deliveryStatuses[2].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(4),
                    Orders = orders.GetRange(14, 2)
                },
                new Delivery
                {
                    Id = "7",
                    LocationFrom = "Warehouse B",
                    LocationTo = "Customer Address",
                    Price = 18.00m,
                    Status_Id = deliveryStatuses[3].Id,
                    EstimatedDeliveryTime = DateTime.Now.AddDays(3),
                    Orders = orders.GetRange(16, 5)
                },
            };

            context.Deliveries.AddRange(deliveries);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
