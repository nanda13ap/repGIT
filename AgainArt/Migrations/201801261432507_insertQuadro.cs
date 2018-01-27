namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertQuadro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtWork", "ContentType", c => c.String());
            DropColumn("dbo.TbArtWork", "ContentType_Boundary");
            DropColumn("dbo.TbArtWork", "ContentType_CharSet");
            DropColumn("dbo.TbArtWork", "ContentType_MediaType");
            DropColumn("dbo.TbArtWork", "ContentType_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TbArtWork", "ContentType_Name", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_MediaType", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_CharSet", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_Boundary", c => c.String());
            DropColumn("dbo.TbArtWork", "ContentType");
        }
    }
}
