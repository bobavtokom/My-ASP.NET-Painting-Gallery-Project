namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavPropAddedToPaintingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paintings", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paintings", "ArtistId");
            AddForeignKey("dbo.Paintings", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paintings", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Paintings", new[] { "ArtistId" });
            DropColumn("dbo.Paintings", "ArtistId");
        }
    }
}
