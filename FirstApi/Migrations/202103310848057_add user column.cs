namespace FirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusercolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        avatar = c.String(),
                        email = c.String(nullable: false, maxLength: 30),
                        password = c.String(nullable: false, maxLength: 50),
                        PasswordSalt = c.String(maxLength: 100),
                        Authority = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        fullname = c.String(nullable: false),
                        phone = c.String(nullable: false, maxLength: 50),
                        isArtist = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
