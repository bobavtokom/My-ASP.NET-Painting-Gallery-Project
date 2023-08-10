namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaintingModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paintings", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paintings", "Quantity");
        }
    }
}
