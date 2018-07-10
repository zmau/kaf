namespace kaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class items : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemGroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        frontPosition = c.Int(nullable: false),
                        frontPic = c.String(),
                        picture = c.Int(nullable: false),
                        color = c.Int(nullable: false),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        taxGroupId = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        frontPosition = c.Int(nullable: false),
                        vipPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        group_id = c.Int(),
                        measureUnit_id = c.Int(),
                        type_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ItemGroups", t => t.group_id)
                .ForeignKey("dbo.MeasureUnits", t => t.measureUnit_id)
                .ForeignKey("dbo.ItemTypes", t => t.type_id)
                .Index(t => t.group_id)
                .Index(t => t.measureUnit_id)
                .Index(t => t.type_id);
            
            CreateTable(
                "dbo.MeasureUnits",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "type_id", "dbo.ItemTypes");
            DropForeignKey("dbo.Items", "measureUnit_id", "dbo.MeasureUnits");
            DropForeignKey("dbo.Items", "group_id", "dbo.ItemGroups");
            DropIndex("dbo.Items", new[] { "type_id" });
            DropIndex("dbo.Items", new[] { "measureUnit_id" });
            DropIndex("dbo.Items", new[] { "group_id" });
            DropTable("dbo.ItemTypes");
            DropTable("dbo.MeasureUnits");
            DropTable("dbo.Items");
            DropTable("dbo.ItemGroups");
        }
    }
}
