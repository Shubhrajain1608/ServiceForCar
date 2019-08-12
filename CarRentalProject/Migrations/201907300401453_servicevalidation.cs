namespace CarRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicevalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Details", c => c.String());
        }
    }
}
