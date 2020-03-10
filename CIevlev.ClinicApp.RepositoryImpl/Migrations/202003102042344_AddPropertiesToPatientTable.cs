namespace CIevlev.ClinicApp.RepositoryImpl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToPatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Email", c => c.String());
            AddColumn("dbo.Patient", "Token", c => c.String());
            AddColumn("dbo.Patient", "BonusPercent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "BonusPercent");
            DropColumn("dbo.Patient", "Token");
            DropColumn("dbo.Patient", "Email");
        }
    }
}
