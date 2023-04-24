namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedRentalTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Rentals", "Painting_Id", "dbo.Paintings");
            DropIndex("dbo.Rentals", new[] { "Artist_Id" });
            DropIndex("dbo.Rentals", new[] { "Painting_Id" });
            DropTable("dbo.Rentals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Artist_Id = c.Int(),
                        Painting_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Rentals", "Painting_Id");
            CreateIndex("dbo.Rentals", "Artist_Id");
            AddForeignKey("dbo.Rentals", "Painting_Id", "dbo.Paintings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
