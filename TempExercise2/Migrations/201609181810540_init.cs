namespace TempExercise2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        LicenseNumber = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.LicenseNumber);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        LicenseNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.LicenseNumber, cascadeDelete: true)
                .Index(t => t.LicenseNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "LicenseNumber", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "LicenseNumber" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
