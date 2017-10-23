namespace Bike2Ride.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Main_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.MapRoutes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Path = c.String(nullable: false),
                        Distance = c.Double(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        EndLocation_Id = c.Guid(),
                        StartLocation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.EndLocation_Id)
                .ForeignKey("dbo.Locations", t => t.StartLocation_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.EndLocation_Id)
                .Index(t => t.StartLocation_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        Duration = c.Double(),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Route_Id = c.Guid(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapRoutes", t => t.Route_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Route_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Trips", "Route_Id", "dbo.MapRoutes");
            DropForeignKey("dbo.MapRoutes", "StartLocation_Id", "dbo.Locations");
            DropForeignKey("dbo.MapRoutes", "EndLocation_Id", "dbo.Locations");
            DropIndex("dbo.Trips", new[] { "User_Id" });
            DropIndex("dbo.Trips", new[] { "Route_Id" });
            DropIndex("dbo.Trips", new[] { "IsDeleted" });
            DropIndex("dbo.MapRoutes", new[] { "StartLocation_Id" });
            DropIndex("dbo.MapRoutes", new[] { "EndLocation_Id" });
            DropIndex("dbo.MapRoutes", new[] { "IsDeleted" });
            DropIndex("dbo.Locations", new[] { "IsDeleted" });
            DropTable("dbo.Trips");
            DropTable("dbo.MapRoutes");
            DropTable("dbo.Locations");
        }
    }
}
