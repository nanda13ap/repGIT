namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingArtWork : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TbArtWork");
        }
    }
}
