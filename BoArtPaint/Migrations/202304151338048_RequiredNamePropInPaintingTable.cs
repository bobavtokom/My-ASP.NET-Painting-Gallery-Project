namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredNamePropInPaintingTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paintings", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paintings", "Name", c => c.String());
        }
    }
}
