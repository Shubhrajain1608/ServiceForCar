namespace CarRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queryForCascadeDeleteEmptyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "UserId" });
            DropColumn("dbo.Cars", "UserId");
        }
        
        public override void Down()
        {
        }
    }
}
