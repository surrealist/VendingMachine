namespace JL.VendingMachines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productaddweight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "WeightGrams", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "WeightGrams");
        }
    }
}
