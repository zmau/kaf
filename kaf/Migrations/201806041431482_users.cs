namespace kaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        roleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.roleID, cascadeDelete: true)
                .Index(t => t.roleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleID" });
            DropTable("dbo.Users");
        }
    }
}
