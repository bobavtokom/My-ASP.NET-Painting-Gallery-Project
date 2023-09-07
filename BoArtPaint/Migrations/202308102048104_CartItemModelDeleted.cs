namespace BoArtPaint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartItemModelDeleted : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
