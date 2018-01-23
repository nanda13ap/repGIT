namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtist", "About", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TbArtist", "About");
        }
    }
}
