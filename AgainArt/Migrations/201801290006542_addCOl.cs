namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCOl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtWork", "PaintingType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TbArtWork", "PaintingType");
        }
    }
}
