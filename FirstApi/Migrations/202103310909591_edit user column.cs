namespace FirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editusercolumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "PasswordSalt");
            DropColumn("dbo.Users", "Authority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Authority", c => c.String());
            AddColumn("dbo.Users", "PasswordSalt", c => c.String(maxLength: 100));
        }
    }
}
