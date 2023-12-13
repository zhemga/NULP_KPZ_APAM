using APAM_API.Models.Selling_System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace APAM_API.Data
{
    public class APAM_APIContext : IdentityDbContext<IdentityUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.E
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public APAM_APIContext() : base("name=APAM_APIContext")
        {
            Database.SetInitializer(new APAM_Seeder());

            Database.Initialize(true);

            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Seller)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
               .HasRequired(o => o.Customer)
               .WithMany(s => s.Orders)
               .HasForeignKey(o => o.CustomerId)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }


        public System.Data.Entity.DbSet<APAM_API.Models.Identity_Users.AutoPartSupplier> AutoPartSuppliers { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.IdentityUsers.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.Identity_Users.Seller> Sellers { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.AutoPart> AutoParts { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.AutoPartCategory> AutoPartCategories { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.AutoPartManufacturer> AutoPartManufacturers { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.Selling_System.Delivery> Deliveries { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.Selling_System.DeliveryStatus> DeliveryStatuses { get; set; }

        public System.Data.Entity.DbSet<APAM_API.Models.Selling_System.Order> Orders { get; set; }

    }
}
