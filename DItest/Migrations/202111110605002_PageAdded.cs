namespace DItest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Rate = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DeliveryAddress = c.String(),
                        SaleDateTime = c.DateTime(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.SaleProducts", new[] { "ProductId" });
            DropIndex("dbo.SaleProducts", new[] { "SaleId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
