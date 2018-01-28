namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changinColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtist", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.TbArtist", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TbArtist", "Name", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.TbArtist", "LastName");
        }
    }
}
