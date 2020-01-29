namespace DatabaseAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(),
                        ManagerSurname = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SquareMeter = c.Int(nullable: false),
                        RoomCount = c.Int(nullable: false),
                        LivingRoomCount = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        NumberOfFloors = c.Int(nullable: false),
                        PropertyTypeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeId, cascadeDelete: true)
                .Index(t => t.PropertyTypeId);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Properties", "PropertyTypeId", "dbo.PropertyTypes");
            DropIndex("dbo.Properties", new[] { "PropertyTypeId" });
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Properties");
            DropTable("dbo.Companies");
        }
    }
}
