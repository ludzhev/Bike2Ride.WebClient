namespace Bike2Ride.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Cities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ZoomLevel = c.Int(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Center_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Center_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Center_Id);
            
            AddColumn("dbo.Locations", "City_Id", c => c.Guid());
            AddColumn("dbo.MapRoutes", "ZoomLevel", c => c.Int());
            AddColumn("dbo.MapRoutes", "Center_Id", c => c.Guid());
            CreateIndex("dbo.Locations", "City_Id");
            CreateIndex("dbo.MapRoutes", "Center_Id");
            AddForeignKey("dbo.Locations", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.MapRoutes", "Center_Id", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapRoutes", "Center_Id", "dbo.Locations");
            DropForeignKey("dbo.Locations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Center_Id", "dbo.Locations");
            DropIndex("dbo.MapRoutes", new[] { "Center_Id" });
            DropIndex("dbo.Locations", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Center_Id" });
            DropIndex("dbo.Cities", new[] { "IsDeleted" });
            DropColumn("dbo.MapRoutes", "Center_Id");
            DropColumn("dbo.MapRoutes", "ZoomLevel");
            DropColumn("dbo.Locations", "City_Id");
            DropTable("dbo.Cities");
        }
    }
}
