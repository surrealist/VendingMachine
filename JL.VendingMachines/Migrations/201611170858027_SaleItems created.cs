namespace JL.VendingMachines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleItemscreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Slot_Id = c.Int(nullable: false),
                        Machine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.Slot_Id, cascadeDelete: true)
                .ForeignKey("dbo.Machines", t => t.Machine_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Slot_Id)
                .Index(t => t.Machine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleItems", "Machine_Id", "dbo.Machines");
            DropForeignKey("dbo.SaleItems", "Slot_Id", "dbo.Slots");
            DropForeignKey("dbo.SaleItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.SaleItems", new[] { "Machine_Id" });
            DropIndex("dbo.SaleItems", new[] { "Slot_Id" });
            DropIndex("dbo.SaleItems", new[] { "Product_Id" });
            DropTable("dbo.SaleItems");
        }
    }
}
