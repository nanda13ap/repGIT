namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtist", "Name", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.TbArtist", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TbArtist", "Nome", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.TbArtist", "Name");
        }
    }
}
