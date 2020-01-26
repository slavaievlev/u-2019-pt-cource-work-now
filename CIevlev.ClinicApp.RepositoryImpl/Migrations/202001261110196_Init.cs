namespace CIevlev.ClinicApp.RepositoryImpl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDoctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        ImplementDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        PatientStatus = c.Int(nullable: false),
                        Phone = c.String(),
                        Bonus = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PayStory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayStory", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.OrderDoctor", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderDoctor", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.PayStory", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "PatientId" });
            DropIndex("dbo.OrderDoctor", new[] { "DoctorId" });
            DropIndex("dbo.OrderDoctor", new[] { "OrderId" });
            DropTable("dbo.PayStory");
            DropTable("dbo.Patient");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDoctor");
            DropTable("dbo.Doctor");
        }
    }
}
