namespace JL.VendingMachines.Migrations {
  using System;
  using System.Data.Entity.Migrations;

  public partial class InitialCreate : DbMigration {
    public override void Up() {
      CreateTable(
          "dbo.Machines",
          c => new {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(),
            AcceptableCoinsText = c.String(),
            Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
          })
          .PrimaryKey(t => t.Id);

      CreateTable(
          "dbo.Products",
          c => new {
            Id = c.Int(nullable: false, identity: true),
            Name = c.String(nullable: false, maxLength: 100),
            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            PictureUrl = c.String(maxLength: 500),
            IsFeatured = c.Boolean(nullable: false),
            Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
          })
          .PrimaryKey(t => t.Id);

    }

    public override void Down() {
      DropTable("dbo.Products");
      DropTable("dbo.Machines");
    }
  }
}
