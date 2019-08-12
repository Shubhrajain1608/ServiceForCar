namespace CarRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Style", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Color", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Color", c => c.String());
            AlterColumn("dbo.Cars", "Style", c => c.String());
        }
    }
}
