namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LikeDislikeModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikeDislikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        IsLiked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LikeDislikes");
        }
    }
}
