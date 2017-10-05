namespace ROS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cartId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.cartId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.productId, cascadeDelete: true)
                .Index(t => t.cartId)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderId = c.Guid(nullable: false),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        trackingNumber = c.Guid(nullable: false),
                        specialOfferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalesOrders", t => t.orderId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.SpecialOffers", t => t.specialOfferId, cascadeDelete: true)
                .Index(t => t.orderId)
                .Index(t => t.productId)
                .Index(t => t.specialOfferId);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        customerId = c.Guid(nullable: false),
                        shippingId = c.Int(nullable: false),
                        totalCost = c.Single(nullable: false),
                        orderCost = c.Single(nullable: false),
                        shippingCost = c.Single(nullable: false),
                        status = c.String(),
                        orderDate = c.DateTime(),
                        dueDate = c.DateTime(),
                        shippingDate = c.DateTime(),
                        deliveryDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShippingAddresses", t => t.shippingId, cascadeDelete: true)
                .Index(t => t.shippingId);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        location = c.String(),
                        state = c.String(),
                        pincode = c.Int(nullable: false),
                        userId = c.Guid(nullable: false),
                        phoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        offerName = c.String(),
                        discount = c.Single(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        MinQ = c.Int(nullable: false),
                        MaxQ = c.Int(nullable: false),
                        description = c.String(),
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
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
                        OutletName = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetails", "specialOfferId", "dbo.SpecialOffers");
            DropForeignKey("dbo.OrderDetails", "productId", "dbo.Recipes");
            DropForeignKey("dbo.OrderDetails", "orderId", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "shippingId", "dbo.ShippingAddresses");
            DropForeignKey("dbo.CartItems", "productId", "dbo.Recipes");
            DropForeignKey("dbo.Restaurants", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CartItems", "cartId", "dbo.Carts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SalesOrders", new[] { "shippingId" });
            DropIndex("dbo.OrderDetails", new[] { "specialOfferId" });
            DropIndex("dbo.OrderDetails", new[] { "productId" });
            DropIndex("dbo.OrderDetails", new[] { "orderId" });
            DropIndex("dbo.Restaurants", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropIndex("dbo.CartItems", new[] { "productId" });
            DropIndex("dbo.CartItems", new[] { "cartId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SpecialOffers");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Categories");
            DropTable("dbo.Recipes");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
