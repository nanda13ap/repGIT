namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcatalog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbArtist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        About = c.String(nullable: false),
                        Email = c.String(),
                        TelephoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TbArtWork",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileURL = c.String(nullable: false),
                        ThumbNailURL = c.String(nullable: false),
                        OriginalName = c.String(nullable: false),
                        GeneratedName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ContentType = c.String(),
                        ContentLength = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        PaintingType = c.Int(nullable: false),
                        IdArtista = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TbArtist", t => t.IdArtista, cascadeDelete: true)
                .Index(t => t.IdArtista);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbArtWork", "IdArtista", "dbo.TbArtist");
            DropIndex("dbo.TbArtWork", new[] { "IdArtista" });
            DropTable("dbo.TbArtWork");
            DropTable("dbo.TbArtist");
        }
    }
}
