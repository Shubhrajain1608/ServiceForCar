namespace CarRentalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queryForCascadeDeleteEmptyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "UserId");
            AddForeignKey("dbo.Cars", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
