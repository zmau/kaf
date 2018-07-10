namespace kaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userrole_attribute : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "roleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "roleID" });
            RenameColumn(table: "dbo.Users", name: "roleID", newName: "role_id");
            AlterColumn("dbo.Users", "role_id", c => c.Int());
            CreateIndex("dbo.Users", "role_id");
            AddForeignKey("dbo.Users", "role_id", "dbo.Roles", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "role_id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "role_id" });
            AlterColumn("dbo.Users", "role_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Users", name: "role_id", newName: "roleID");
            CreateIndex("dbo.Users", "roleID");
            AddForeignKey("dbo.Users", "roleID", "dbo.Roles", "id", cascadeDelete: true);
        }
    }
}
