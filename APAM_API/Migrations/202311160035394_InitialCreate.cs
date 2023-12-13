namespace APAM_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoPartCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AutoPartManufacturers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AutoParts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AutoName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AutoPartCategoryId = c.String(nullable: false, maxLength: 128),
                        AutoPartManufacturerId = c.String(nullable: false, maxLength: 128),
                        AutoPartSupplierId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoPartCategories", t => t.AutoPartCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AutoPartManufacturers", t => t.AutoPartManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AutoPartSupplierId, cascadeDelete: true)
                .Index(t => t.AutoPartCategoryId)
                .Index(t => t.AutoPartManufacturerId)
                .Index(t => t.AutoPartSupplierId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        SellerId = c.String(nullable: false, maxLength: 128),
                        AutoPartId = c.String(nullable: false, maxLength: 128),
                        Delivery_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AutoParts", t => t.AutoPartId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SellerId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.SellerId)
                .Index(t => t.AutoPartId)
                .Index(t => t.Delivery_Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LocationFrom = c.String(nullable: false),
                        LocationTo = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status_Id = c.String(nullable: false, maxLength: 128),
                        EstimatedDeliveryTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryStatus", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.DeliveryStatus",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Deliveries", "Status_Id", "dbo.DeliveryStatus");
            DropForeignKey("dbo.Orders", "Delivery_Id", "dbo.Deliveries");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "AutoPartId", "dbo.AutoParts");
            DropForeignKey("dbo.AutoParts", "AutoPartSupplierId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AutoParts", "AutoPartManufacturerId", "dbo.AutoPartManufacturers");
            DropForeignKey("dbo.AutoParts", "AutoPartCategoryId", "dbo.AutoPartCategories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Deliveries", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "Delivery_Id" });
            DropIndex("dbo.Orders", new[] { "AutoPartId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AutoParts", new[] { "AutoPartSupplierId" });
            DropIndex("dbo.AutoParts", new[] { "AutoPartManufacturerId" });
            DropIndex("dbo.AutoParts", new[] { "AutoPartCategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.DeliveryStatus");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AutoParts");
            DropTable("dbo.AutoPartManufacturers");
            DropTable("dbo.AutoPartCategories");
        }
    }
}
