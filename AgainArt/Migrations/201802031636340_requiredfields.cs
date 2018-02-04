namespace AgainArt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TbArtist", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TbArtist", "Email", c => c.String());
        }
    }
}
