namespace FirstApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class put : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ArtistInfoes", new[] { "userId" });
            CreateTable(
                "dbo.ArtistInfoImages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        imageUrl = c.String(),
                        imageInfo = c.String(),
                        artistInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ArtistInfoes", t => t.artistInfoId, cascadeDelete: true)
                .Index(t => t.artistInfoId);
            
            AddColumn("dbo.Users", "GuId", c => c.String());
            CreateIndex("dbo.ArtistInfoes", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistInfoImages", "artistInfoId", "dbo.ArtistInfoes");
            DropIndex("dbo.ArtistInfoes", new[] { "UserId" });
            DropIndex("dbo.ArtistInfoImages", new[] { "artistInfoId" });
            DropColumn("dbo.Users", "GuId");
            DropTable("dbo.ArtistInfoImages");
            CreateIndex("dbo.ArtistInfoes", "userId");
        }
    }
}
