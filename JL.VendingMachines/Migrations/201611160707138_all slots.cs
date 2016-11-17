namespace JL.VendingMachines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allslots : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Machine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Machines", t => t.Machine_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Machine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "Machine_Id", "dbo.Machines");
            DropForeignKey("dbo.Slots", "Product_Id", "dbo.Products");
            DropIndex("dbo.Slots", new[] { "Machine_Id" });
            DropIndex("dbo.Slots", new[] { "Product_Id" });
            DropTable("dbo.Slots");
        }
    }
}
