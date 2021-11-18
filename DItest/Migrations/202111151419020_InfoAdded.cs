namespace DItest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InfoAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.SaleProducts", new[] { "ProductId" });
            AddColumn("dbo.SaleProducts", "Product_Id", c => c.Int());
            AlterColumn("dbo.SaleProducts", "ProductId", c => c.String());
            AlterColumn("dbo.SaleProducts", "Qty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SaleProducts", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SaleProducts", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sales", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.SaleProducts", "Product_Id");
            AddForeignKey("dbo.SaleProducts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.SaleProducts", new[] { "Product_Id" });
            AlterColumn("dbo.Sales", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.SaleProducts", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.SaleProducts", "Rate", c => c.Int(nullable: false));
            AlterColumn("dbo.SaleProducts", "Qty", c => c.Int(nullable: false));
            AlterColumn("dbo.SaleProducts", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.SaleProducts", "Product_Id");
            CreateIndex("dbo.SaleProducts", "ProductId");
            AddForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
