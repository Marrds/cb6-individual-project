namespace IndividualProjectRev3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "UnRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "UnRead");
        }
    }
}
