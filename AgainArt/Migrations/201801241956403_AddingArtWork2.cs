namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingArtWork2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtWork", "ContentType_Boundary", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_CharSet", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_MediaType", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentType_Name", c => c.String());
            AddColumn("dbo.TbArtWork", "ContentLength", c => c.Int(nullable: false));
            AddColumn("dbo.TbArtWork", "ImageData", c => c.Binary());
            AddColumn("dbo.TbArtWork", "IdArtista", c => c.Int(nullable: false));
            CreateIndex("dbo.TbArtWork", "IdArtista");
            AddForeignKey("dbo.TbArtWork", "IdArtista", "dbo.TbArtist", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbArtWork", "IdArtista", "dbo.TbArtist");
            DropIndex("dbo.TbArtWork", new[] { "IdArtista" });
            DropColumn("dbo.TbArtWork", "IdArtista");
            DropColumn("dbo.TbArtWork", "ImageData");
            DropColumn("dbo.TbArtWork", "ContentLength");
            DropColumn("dbo.TbArtWork", "ContentType_Name");
            DropColumn("dbo.TbArtWork", "ContentType_MediaType");
            DropColumn("dbo.TbArtWork", "ContentType_CharSet");
            DropColumn("dbo.TbArtWork", "ContentType_Boundary");
        }
    }
}
