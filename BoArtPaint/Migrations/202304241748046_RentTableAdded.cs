namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfRent = c.DateTime(nullable: false),
                        DateOfReturn = c.DateTime(),
                        Artist_Id = c.Int(nullable: false),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Paintings", t => t.Painting_Id, cascadeDelete: false)
                .Index(t => t.Artist_Id)
                .Index(t => t.Painting_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Painting_Id", "dbo.Paintings");
            DropForeignKey("dbo.Rents", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Rents", new[] { "Painting_Id" });
            DropIndex("dbo.Rents", new[] { "Artist_Id" });
            DropTable("dbo.Rents");
        }
    }
}
