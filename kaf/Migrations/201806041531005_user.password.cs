namespace kaf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "userName", c => c.String());
            AddColumn("dbo.Users", "password", c => c.String());
            AddColumn("dbo.Users", "cardCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "cardCode");
            DropColumn("dbo.Users", "password");
            DropColumn("dbo.Users", "userName");
        }
    }
}
