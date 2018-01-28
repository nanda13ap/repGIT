namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertColumsArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbArtist", "Email", c => c.String());
            AddColumn("dbo.TbArtist", "TelephoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TbArtist", "TelephoneNumber");
            DropColumn("dbo.TbArtist", "Email");
        }
    }
}
