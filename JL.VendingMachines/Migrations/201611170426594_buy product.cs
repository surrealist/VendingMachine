namespace JL.VendingMachines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Machines", "TotalAmount");
        }
    }
}
