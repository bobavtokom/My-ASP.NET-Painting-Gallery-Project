namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LikeCountAndDislikeCountPropsAddedToPaintingEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paintings", "LikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Paintings", "DislikeCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paintings", "DislikeCount");
            DropColumn("dbo.Paintings", "LikeCount");
        }
    }
}
