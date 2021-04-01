namespace FirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "createdAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "createdAt", c => c.DateTime(nullable: false));
        }
    }
}
