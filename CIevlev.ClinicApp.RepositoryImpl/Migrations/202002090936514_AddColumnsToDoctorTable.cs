namespace CIevlev.ClinicApp.RepositoryImpl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "DeleteAt", c => c.DateTime());
            AddColumn("dbo.Doctor", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "IsActive");
            DropColumn("dbo.Doctor", "DeleteAt");
        }
    }
}
