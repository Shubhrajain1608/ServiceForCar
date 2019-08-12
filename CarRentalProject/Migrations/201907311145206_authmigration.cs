namespace CarRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            DropColumn("dbo.Cars", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
